using System.Linq;
using Content.Server.Connection;
using Content.Server.DiscordAuth;
using Content.Shared.CCVar;
using Content.Shared.JoinQueue;
using Prometheus;
using Robust.Server.Player;
using Robust.Shared.Configuration;
using Robust.Shared.Enums;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using Content.Server._RMC14.LinkAccount;
using Content.Shared._Goobstation.CCVar;

namespace Content.Server.JoinQueue;

/// <summary>
///     Manages new player connections when the server is full and queues them up, granting access when a slot becomes free
/// </summary>
public sealed class JoinQueueManager
{
    private static readonly Gauge QueueCount = Metrics.CreateGauge(
        "join_queue_count",
        "Amount of players in queue.");

    private static readonly Counter QueueBypassCount = Metrics.CreateCounter(
        "join_queue_bypass_count",
        "Amount of players who bypassed queue by privileges.");

    private static readonly Histogram QueueTimings = Metrics.CreateHistogram(
        "join_queue_timings",
        "Timings of players in queue",
        new HistogramConfiguration()
        {
            LabelNames = new[] {"type"},
            Buckets = Histogram.ExponentialBuckets(1, 2, 14),
        });


    [Dependency] private readonly IPlayerManager _player = default!;
    [Dependency] private readonly IConnectionManager _connection = default!;
    [Dependency] private readonly IConfigurationManager _configuration = default!;
    [Dependency] private readonly IServerNetManager _net = default!;
    [Dependency] private readonly DiscordAuthManager _discordAuth = default!;
    [Dependency] private readonly LinkAccountManager _linkAccount = default!;


    /// <summary>
    ///     Queue of active player sessions
    /// </summary>
    private readonly List<ICommonSession> _queue = new();

    /// <summary>
    ///     Queue for Patreon supporters.
    /// </summary>
    private readonly List<ICommonSession> _patronQueue = new();

    private bool _isEnabled = false;
    private bool _patreonIsEnabled = true;

    public int PlayerInQueueCount => _queue.Count + _patronQueue.Count;
    public int ActualPlayersCount => _player.PlayerCount - PlayerInQueueCount; // Now it's only real value with actual players count that in game

    public void Initialize()
    {
        _net.RegisterNetMessage<QueueUpdateMessage>();

        _configuration.OnValueChanged(CCVars.QueueEnabled, OnQueueCVarChanged, true);
        _configuration.OnValueChanged(GoobCVars.PatreonSkip, OnPatronCvarChanged, true);
        _player.PlayerStatusChanged += OnPlayerStatusChanged;
        _discordAuth.PlayerVerified += OnPlayerVerified;
    }


    private void OnQueueCVarChanged(bool value)
    {
        _isEnabled = value;

        if (!value)
        {
            foreach (var session in _queue)
                session.Channel.Disconnect("Queue was disabled");
            foreach (var session in _patronQueue)
                session.Channel.Disconnect("Queue was disabled");
        }
    }

    private void OnPatronCvarChanged(bool value)
        => _patreonIsEnabled = value;

    private async void OnPlayerVerified(object? sender, ICommonSession session)
    {
        if (!_isEnabled)
        {
            SendToGame(session);
            return;
        }

        var isPrivileged = await _connection.HasPrivilegedJoin(session.UserId);
        var isPatron = _linkAccount.GetPatron(session)?.Tier != null;
        var currentOnline = _player.PlayerCount - 1;
        var haveFreeSlot = currentOnline < _configuration.GetCVar(CCVars.SoftMaxPlayers);
        if (isPrivileged || haveFreeSlot)
        {
            SendToGame(session);

            if (isPrivileged && !haveFreeSlot)
                QueueBypassCount.Inc();

            return;
        }

        if (isPatron && _patreonIsEnabled)
            _patronQueue.Add(session);
        else
            _queue.Add(session);

        ProcessQueue(false, session.ConnectedTime);
    }

    private async void OnPlayerStatusChanged(object? sender, SessionStatusEventArgs e)
    {
        if (e.NewStatus == SessionStatus.Disconnected)
        {
            var wasInQueue = _queue.Remove(e.Session) || _patronQueue.Remove(e.Session);

            if (!wasInQueue && e.OldStatus != SessionStatus.InGame) // Process queue only if player disconnected from InGame or from queue
                return;

            ProcessQueue(true, e.Session.ConnectedTime);

            if (wasInQueue)
                QueueTimings.WithLabels("Unwaited").Observe((DateTime.UtcNow - e.Session.ConnectedTime).TotalSeconds);
        }
    }


    /// <summary>
    ///     If possible, takes the first player in the queue and sends him into the game
    /// </summary>
    /// <param name="isDisconnect">Is method called on disconnect event</param>
    /// <param name="connectedTime">Session connected time for histogram metrics</param>
    private void ProcessQueue(bool isDisconnect, DateTime connectedTime)
    {
        var players = ActualPlayersCount;
        if (isDisconnect)
            players--; // Decrease currently disconnected session but that has not yet been deleted

        var haveFreeSlot = players < _configuration.GetCVar(CCVars.SoftMaxPlayers);
        var patronQueueContains = _patronQueue.Count > 0;
        var regularQueueContains = _queue.Count > 0;

        if (haveFreeSlot && (patronQueueContains || regularQueueContains))
        {
            ICommonSession session;
            if (patronQueueContains)
            {
                session = _patronQueue.First();
                _patronQueue.Remove(session);
            }
            else
            {
                session = _queue.First();
                _queue.Remove(session);
            }

            SendToGame(session);
            QueueTimings.WithLabels("Waited").Observe((DateTime.UtcNow - connectedTime).TotalSeconds);
        }

        SendUpdateMessages();
        QueueCount.Set(_queue.Count);
    }

// <summary>
    ///     Sends messages to all players in the queue with the current state of the queue
    /// </summary>
    private void SendUpdateMessages()
    {
        var totalInQueue = _patronQueue.Count + _queue.Count;
        var currentPosition = 1;

        for (var i = 0; i < _patronQueue.Count; i++, currentPosition++)
        {
            _patronQueue[i].Channel.SendMessage(new QueueUpdateMessage
            {
                Total = totalInQueue,
                Position = currentPosition,
                IsPatron = true,
            });
        }

        for (var i = 0; i < _queue.Count; i++, currentPosition++)
        {
            _queue[i].Channel.SendMessage(new QueueUpdateMessage
            {
                Total = totalInQueue,
                Position = currentPosition,
                IsPatron = false,
            });
        }
    }

    /// <summary>
    ///     Letting player's session into game, change player state
    /// </summary>
    /// <param name="session">Player session that will be sent to game</param>
    private void SendToGame(ICommonSession session)
    {
        Timer.Spawn(0, () => _player.JoinGame(session));
    }
}
