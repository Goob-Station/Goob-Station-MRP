using Robust.Shared;
using Robust.Shared.Configuration;

<<<<<<< HEAD
namespace Content.Shared.CCVar
{
    // ReSharper disable once InconsistentNaming
    [CVarDefs]
    public sealed class CCVars : CVars
    {
        #region Server
        /*
         * Server
         */

        /// <summary>
        ///     Change this to have the changelog and rules "last seen" date stored separately.
        /// </summary>
        public static readonly CVarDef<string> ServerId =
            CVarDef.Create("server.id", "unknown_server_id", CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        ///     Guide Entry Prototype ID to be displayed as the server rules.
        /// </summary>
        public static readonly CVarDef<string> RulesFile =
            CVarDef.Create("server.rules_file", "DefaultRuleset", CVar.REPLICATED | CVar.SERVER);

        #endregion
        #region Ambience
        /*
         * Ambience
         */

        /// <summary>
        /// How long we'll wait until re-sampling nearby objects for ambience. Should be pretty fast, but doesn't have to match the tick rate.
        /// </summary>
        public static readonly CVarDef<float> AmbientCooldown =
            CVarDef.Create("ambience.cooldown", 0.1f, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        /// How large of a range to sample for ambience.
        /// </summary>
        public static readonly CVarDef<float> AmbientRange =
            CVarDef.Create("ambience.range", 8f, CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// Maximum simultaneous ambient sounds.
        /// </summary>
        public static readonly CVarDef<int> MaxAmbientSources =
            CVarDef.Create("ambience.max_sounds", 16, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        /// The minimum value the user can set for ambience.max_sounds
        /// </summary>
        public static readonly CVarDef<int> MinMaxAmbientSourcesConfigured =
            CVarDef.Create("ambience.min_max_sounds_configured", 16, CVar.REPLICATED | CVar.SERVER | CVar.CHEAT);

        /// <summary>
        /// The maximum value the user can set for ambience.max_sounds
        /// </summary>
        public static readonly CVarDef<int> MaxMaxAmbientSourcesConfigured =
            CVarDef.Create("ambience.max_max_sounds_configured", 64, CVar.REPLICATED | CVar.SERVER | CVar.CHEAT);

        /// <summary>
        /// Ambience volume.
        /// </summary>
        public static readonly CVarDef<float> AmbienceVolume =
            CVarDef.Create("ambience.volume", 1.5f, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        /// Ambience music volume.
        /// </summary>
        public static readonly CVarDef<float> AmbientMusicVolume =
            CVarDef.Create("ambience.music_volume", 1.5f, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        /// Lobby / round end music volume.
        /// </summary>
        public static readonly CVarDef<float> LobbyMusicVolume =
            CVarDef.Create("ambience.lobby_music_volume", 0.50f, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        /// UI volume.
        /// </summary>
        public static readonly CVarDef<float> InterfaceVolume =
            CVarDef.Create("audio.interface_volume", 0.50f, CVar.ARCHIVE | CVar.CLIENTONLY);

        #endregion
        #region Status
        /*
         * Status
         */

        public static readonly CVarDef<string> StatusMoMMIUrl =
            CVarDef.Create("status.mommiurl", "", CVar.SERVERONLY);

        public static readonly CVarDef<string> StatusMoMMIPassword =
            CVarDef.Create("status.mommipassword", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

        #endregion
        #region Events
        /*
         * Events
         */

        /// <summary>
        ///     Controls if the game should run station events
        /// </summary>
        public static readonly CVarDef<bool>
            EventsEnabled = CVarDef.Create("events.enabled", true, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Average time (in minutes) for when the ramping event scheduler should stop increasing the chaos modifier.
        ///     Close to how long you expect a round to last, so you'll probably have to tweak this on downstreams.
        /// </summary>
        public static readonly CVarDef<float>
            EventsRampingAverageEndTime = CVarDef.Create("events.ramping_average_end_time", 40f, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Average ending chaos modifier for the ramping event scheduler.
        ///     Max chaos chosen for a round will deviate from this
        /// </summary>
        public static readonly CVarDef<float>
            EventsRampingAverageChaos = CVarDef.Create("events.ramping_average_chaos", 6f, CVar.ARCHIVE | CVar.SERVERONLY);

        #endregion
        #region Game
        /*
         * Game
         */

        /// <summary>
        ///     Disables most functionality in the GameTicker.
        /// </summary>
        public static readonly CVarDef<bool>
            GameDummyTicker = CVarDef.Create("game.dummyticker", false, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls if the lobby is enabled. If it is not, and there are no available jobs, you may get stuck on a black screen.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyEnabled = CVarDef.Create("game.lobbyenabled", true, CVar.ARCHIVE);

        /// <summary>
        ///     Controls the duration of the lobby timer in seconds. Defaults to 2 minutes and 30 seconds.
        /// </summary>
        public static readonly CVarDef<int>
            GameLobbyDuration = CVarDef.Create("game.lobbyduration", 150, CVar.ARCHIVE);

        /// <summary>
        ///     Controls if players can latejoin at all.
        /// </summary>
        public static readonly CVarDef<bool>
            GameDisallowLateJoins = CVarDef.Create("game.disallowlatejoins", false, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls the default game preset.
        /// </summary>
        public static readonly CVarDef<string>
            GameLobbyDefaultPreset = CVarDef.Create("game.defaultpreset", "secret", CVar.ARCHIVE);

        /// <summary>
        ///     Controls if the game can force a different preset if the current preset's criteria are not met.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyFallbackEnabled = CVarDef.Create("game.fallbackenabled", true, CVar.ARCHIVE);

        /// <summary>
        ///     The preset for the game to fall back to if the selected preset could not be used, and fallback is enabled.
        /// </summary>
        public static readonly CVarDef<string>
            GameLobbyFallbackPreset = CVarDef.Create("game.fallbackpreset", "Traitor,Extended", CVar.ARCHIVE);

        /// <summary>
        ///     Controls if people can win the game in Suspicion or Deathmatch.
        /// </summary>
        public static readonly CVarDef<bool>
            GameLobbyEnableWin = CVarDef.Create("game.enablewin", true, CVar.ARCHIVE);

        /// <summary>
        ///     Minimum time between Basic station events in seconds
        /// </summary>
        public static readonly CVarDef<int> // 5 Minutes
            GameEventsBasicMinimumTime = CVarDef.Create("game.events_basic_minimum_time", 300, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Maximum time between Basic station events in seconds
        /// </summary>
        public static readonly CVarDef<int> // 25 Minutes
            GameEventsBasicMaximumTime = CVarDef.Create("game.events_basic_maximum_time", 1500, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Minimum time between Ramping station events in seconds
        /// </summary>
        public static readonly CVarDef<int> // 4 Minutes
            GameEventsRampingMinimumTime = CVarDef.Create("game.events_ramping_minimum_time", 240, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Maximum time between Ramping station events in seconds
        /// </summary>
        public static readonly CVarDef<int> // 12 Minutes
            GameEventsRampingMaximumTime = CVarDef.Create("game.events_ramping_maximum_time", 720, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Minimum time between Oscillating station events in seconds. This is the bare minimum which will never be violated, unlike with ramping events.
        /// </summary>
        public static readonly CVarDef<int> // 40 seconds
            GameEventsOscillatingMinimumTime = CVarDef.Create("game.events_oscillating_minimum_time", 40, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Time between Oscillating station events in seconds at 1x chaos level. Events may occur at larger intervals if current chaos is lower than that.
        /// </summary>
        public static readonly CVarDef<int> // 20 Minutes - which constitutes a minimum of 120 seconds between events in Irregular and 280 seconds in Extended Irregular
            GameEventsOscillatingAverageTime = CVarDef.Create("game.events_oscillating_average_time", 1200, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        ///     Controls the maximum number of character slots a player is allowed to have.
        /// </summary>
        public static readonly CVarDef<int>
            GameMaxCharacterSlots = CVarDef.Create("game.maxcharacterslots", 30, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        ///     Controls the game map prototype to load. SS14 stores these prototypes in Prototypes/Maps.
        /// </summary>
        public static readonly CVarDef<string>
            GameMap = CVarDef.Create("game.map", string.Empty, CVar.SERVERONLY);

        /// <summary>
        /// If roles should be restricted based on whether or not they are whitelisted.
        /// </summary>
        public static readonly CVarDef<bool>
            GameRoleWhitelist = CVarDef.Create("game.role_whitelist", true, CVar.SERVER | CVar.REPLICATED);


        /// <summary>
        ///     Controls whether to use world persistence or not.
        /// </summary>
        public static readonly CVarDef<bool>
            UsePersistence = CVarDef.Create("game.usepersistence", false, CVar.ARCHIVE);

        /// <summary>
        ///     If world persistence is used, what map prototype should be initially loaded.
        ///     If the save file exists, it replaces MapPath but everything else stays the same (station name and such).
        /// </summary>
        public static readonly CVarDef<string>
            PersistenceMap = CVarDef.Create("game.persistencemap", "Empty", CVar.ARCHIVE);

        /// <summary>
        ///     Prototype to use for map pool.
        /// </summary>
        public static readonly CVarDef<string>
            GameMapPool = CVarDef.Create("game.map_pool", "DefaultMapPool", CVar.SERVERONLY);

        /// <summary>
        /// The depth of the queue used to calculate which map is next in rotation.
        /// This is how long the game "remembers" that some map was put in play. Default is 16 rounds.
        /// </summary>
        public static readonly CVarDef<int>
            GameMapMemoryDepth = CVarDef.Create("game.map_memory_depth", 16, CVar.SERVERONLY);

        /// <summary>
        /// Is map rotation enabled?
        /// </summary>
        public static readonly CVarDef<bool>
            GameMapRotation = CVarDef.Create("game.map_rotation", true, CVar.SERVERONLY);

        /// <summary>
        /// If roles should be restricted based on time.
        /// </summary>
        public static readonly CVarDef<bool>
            GameRoleTimers = CVarDef.Create("game.role_timers", true, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether or not disconnecting inside of a cryopod should remove the character or just store them until they reconnect.
        /// </summary>
        public static readonly CVarDef<bool>
            GameCryoSleepRejoining = CVarDef.Create("game.cryo_sleep_rejoining", false, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     When enabled, guests will be assigned permanent UIDs and will have their preferences stored.
        /// </summary>
        public static readonly CVarDef<bool> GamePersistGuests =
            CVarDef.Create("game.persistguests", true, CVar.ARCHIVE | CVar.SERVERONLY);

        public static readonly CVarDef<bool> GameDiagonalMovement =
            CVarDef.Create("game.diagonalmovement", true, CVar.ARCHIVE);

        public static readonly CVarDef<int> SoftMaxPlayers =
            CVarDef.Create("game.soft_max_players", 30, CVar.SERVERONLY | CVar.ARCHIVE);

        /// <summary>
        /// If a player gets denied connection to the server,
        /// how long they are forced to wait before attempting to reconnect.
        /// </summary>
        public static readonly CVarDef<int> GameServerFullReconnectDelay =
            CVarDef.Create("game.server_full_reconnect_delay", 30, CVar.SERVERONLY);

        /// <summary>
        /// Whether or not panic bunker is currently enabled.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerEnabled =
            CVarDef.Create("game.panic_bunker.enabled", false, CVar.NOTIFY | CVar.REPLICATED);

        /// <summary>
        /// Whether or not the panic bunker will disable when an admin comes online.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerDisableWithAdmins =
            CVarDef.Create("game.panic_bunker.disable_with_admins", false, CVar.SERVERONLY);

        /// <summary>
        /// Whether or not the panic bunker will enable when no admins are online.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerEnableWithoutAdmins =
            CVarDef.Create("game.panic_bunker.enable_without_admins", false, CVar.SERVERONLY);

        /// <summary>
        /// Whether or not the panic bunker will count deadminned admins for
        /// <see cref="PanicBunkerDisableWithAdmins"/> and
        /// <see cref="PanicBunkerEnableWithoutAdmins"/>
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerCountDeadminnedAdmins =
            CVarDef.Create("game.panic_bunker.count_deadminned_admins", false, CVar.SERVERONLY);

        /// <summary>
        /// Show reason of disconnect for user or not.
        /// </summary>
        public static readonly CVarDef<bool> PanicBunkerShowReason =
            CVarDef.Create("game.panic_bunker.show_reason", false, CVar.SERVERONLY);

        /// <summary>
        /// Minimum age of the account (from server's PoV, so from first-seen date) in hours.
        /// </summary>
        public static readonly CVarDef<int> PanicBunkerMinAccountAge =
            CVarDef.Create("game.panic_bunker.min_account_age", 24, CVar.SERVERONLY);

        /// <summary>
        /// Minimal overall played time.
        /// </summary>
        public static readonly CVarDef<int> PanicBunkerMinOverallHours =
            CVarDef.Create("game.panic_bunker.min_overall_hours", 10, CVar.SERVERONLY);

        /// <summary>
        /// A custom message that will be used for connections denied to the panic bunker
        /// If not empty, then will overwrite <see cref="PanicBunkerShowReason"/>
        /// </summary>
        public static readonly CVarDef<string> PanicBunkerCustomReason =
            CVarDef.Create("game.panic_bunker.custom_reason", string.Empty, CVar.SERVERONLY);

        /// <summary>
        /// Allow bypassing the panic bunker if the user is whitelisted.
        /// </summary>
        public static readonly CVarDef<bool> BypassBunkerWhitelist =
            CVarDef.Create("game.panic_bunker.whitelisted_can_bypass", true, CVar.SERVERONLY);

        /*
         * TODO: Remove baby jail code once a more mature gateway process is established. This code is only being issued as a stopgap to help with potential tiding in the immediate future.
         */

        /// <summary>
        /// Whether the baby jail is currently enabled.
        /// </summary>
        public static readonly CVarDef<bool> BabyJailEnabled  =
            CVarDef.Create("game.baby_jail.enabled", false, CVar.NOTIFY | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// Show reason of disconnect for user or not.
        /// </summary>
        public static readonly CVarDef<bool> BabyJailShowReason =
            CVarDef.Create("game.baby_jail.show_reason", false, CVar.SERVERONLY);

        /// <summary>
        /// Maximum age of the account (from server's PoV, so from first-seen date) in hours that can access baby
        /// jailed servers.
        /// </summary>
        public static readonly CVarDef<int> BabyJailMaxAccountAge =
            CVarDef.Create("game.baby_jail.max_account_age", 24, CVar.SERVERONLY);

        /// <summary>
        /// Maximum overall played time allowed to access baby jailed servers.
        /// </summary>
        public static readonly CVarDef<int> BabyJailMaxOverallHours =
            CVarDef.Create("game.baby_jail.max_overall_hours", 2, CVar.SERVERONLY);

        /// <summary>
        /// A custom message that will be used for connections denied due to the baby jail.
        /// If not empty, then will overwrite <see cref="BabyJailShowReason"/>
        /// </summary>
        public static readonly CVarDef<string> BabyJailCustomReason =
            CVarDef.Create("game.baby_jail.custom_reason", string.Empty, CVar.SERVERONLY);

        /// <summary>
        /// Allow bypassing the baby jail if the user is whitelisted.
        /// </summary>
        public static readonly CVarDef<bool> BypassBabyJailWhitelist =
            CVarDef.Create("game.baby_jail.whitelisted_can_bypass", true, CVar.SERVERONLY);

        /// <summary>
        /// Make people bonk when trying to climb certain objects like tables.
        /// </summary>
        public static readonly CVarDef<bool> GameTableBonk =
            CVarDef.Create("game.table_bonk", false, CVar.REPLICATED);

        /// <summary>
        /// Whether or not status icons are rendered for everyone.
        /// </summary>
        public static readonly CVarDef<bool> GlobalStatusIconsEnabled =
            CVarDef.Create("game.global_status_icons_enabled", true, CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether or not status icons are rendered on this specific client.
        /// </summary>
        public static readonly CVarDef<bool> LocalStatusIconsEnabled =
            CVarDef.Create("game.local_status_icons_enabled", true, CVar.CLIENTONLY);

        /// <summary>
        /// Whether or not coordinates on the Debug overlay should only be available to admins.
        /// </summary>
        public static readonly CVarDef<bool> DebugCoordinatesAdminOnly =
            CVarDef.Create("game.debug_coordinates_admin_only", true, CVar.SERVER | CVar.REPLICATED);


        /// <summary>
        ///     Whether to allow characters to select traits.
        /// </summary>
        public static readonly CVarDef<bool> GameTraitsEnabled =
            CVarDef.Create("game.traits_enabled", true, CVar.REPLICATED);

        /// <summary>
        ///     How many traits a character can have at most.
        /// </summary>
        public static readonly CVarDef<int> GameTraitsMax =
            CVarDef.Create("game.traits_max", 10, CVar.REPLICATED);

        /// <summary>
        ///     How many points a character should start with.
        /// </summary>
        public static readonly CVarDef<int> GameTraitsDefaultPoints =
            CVarDef.Create("game.traits_default_points", 10, CVar.REPLICATED);

        /// <summary>
        ///     Whether the game will SMITE people who used cheat engine to spawn with all of the traits.
        ///     Illegal trait totals will still be logged even if this is disabled.
        ///     If you are intending to decrease the trait points availability, or modify the costs of traits, consider temporarily disabling this.
        /// </summary>
        public static readonly CVarDef<bool> TraitsPunishCheaters =
            CVarDef.Create("game.traits_punish_cheaters", false, CVar.REPLICATED);

        /// <summary>
        ///     Whether to allow characters to select loadout items.
        /// </summary>
        public static readonly CVarDef<bool> GameLoadoutsEnabled =
            CVarDef.Create("game.loadouts_enabled", true, CVar.REPLICATED);

        /// <summary>
        ///     How many points to give to each player for loadouts.
        /// </summary>
        public static readonly CVarDef<int> GameLoadoutsPoints =
            CVarDef.Create("game.loadouts_points", 14, CVar.REPLICATED);


        /// <summary>
        ///     Whether to repeat eating doafters after completion
        /// </summary>
        public static readonly CVarDef<bool> GameAutoEatFood =
            CVarDef.Create("game.auto_eat_food", false, CVar.REPLICATED);

        /// <summary>
        ///     Whether to repeat drinking doafters after completion
        /// </summary>
        public static readonly CVarDef<bool> GameAutoEatDrinks =
            CVarDef.Create("game.auto_eat_drinks", false, CVar.REPLICATED);

        /// <summary>
        ///     Whether item slots, such as power cell slots or AME fuel cell slots, should support quick swap if it is not otherwise specified in their YAML prototype.
        /// </summary>
        public static readonly CVarDef<bool> AllowSlotQuickSwap =
            CVarDef.Create("game.slot_quick_swap", false, CVar.REPLICATED);

#if EXCEPTION_TOLERANCE
        /// <summary>
        ///     Amount of times round start must fail before the server is shut down.
        ///     Set to 0 or a negative number to disable.
        /// </summary>
        public static readonly CVarDef<int> RoundStartFailShutdownCount =
            CVarDef.Create("game.round_start_fail_shutdown_count", 5, CVar.SERVERONLY | CVar.SERVER);
#endif

        /// <summary>
        /// Delay between station alert level changes.
        /// </summary>
        public static readonly CVarDef<int> GameAlertLevelChangeDelay =
            CVarDef.Create("game.alert_level_change_delay", 30, CVar.SERVERONLY);

        /// <summary>
        /// The time in seconds that the server should wait before restarting the round.
        /// Defaults to 2 minutes.
        /// </summary>
        public static readonly CVarDef<float> RoundRestartTime =
            CVarDef.Create("game.round_restart_time", 120f, CVar.SERVERONLY);

        /// <summary>
        /// The prototype to use for secret weights.
        /// </summary>
        public static readonly CVarDef<string> SecretWeightPrototype =
            CVarDef.Create("game.secret_weight_prototype", "Secret", CVar.SERVERONLY);

        /// <summary>
        /// The id of the sound collection to randomly choose a sound from and play when the round ends.
        /// </summary>
        public static readonly CVarDef<string> RoundEndSoundCollection =
            CVarDef.Create("game.round_end_sound_collection", "RoundEnd", CVar.SERVERONLY);

        #endregion
        #region Announcers

        /*
         * Announcers
         */

        /// <summary>
        ///     Weighted list of announcers to choose from
        /// </summary>
        public static readonly CVarDef<string> AnnouncerList =
            CVarDef.Create("announcer.list", "RandomAnnouncers", CVar.REPLICATED);

        /// <summary>
        ///     Optionally force set an announcer
        /// </summary>
        public static readonly CVarDef<string> Announcer =
            CVarDef.Create("announcer.announcer", "", CVar.SERVERONLY);

        /// <summary>
        ///     Optionally blacklist announcers
        ///     List of IDs separated by commas
        /// </summary>
        public static readonly CVarDef<string> AnnouncerBlacklist =
            CVarDef.Create("announcer.blacklist", "", CVar.SERVERONLY);

        /// <summary>
        ///     Changes how loud the announcers are for the client
        /// </summary>
        public static readonly CVarDef<float> AnnouncerVolume =
            CVarDef.Create("announcer.volume", 0.5f, CVar.ARCHIVE | CVar.CLIENTONLY);

        /// <summary>
        ///     Disables multiple announcement sounds from playing at once
        /// </summary>
        public static readonly CVarDef<bool> AnnouncerDisableMultipleSounds =
            CVarDef.Create("announcer.disable_multiple_sounds", false, CVar.ARCHIVE | CVar.CLIENTONLY);


        #endregion
        #region Queue
        /*
         * Queue
         */

        /// <summary>
        ///     Controls if the connections queue is enabled
        ///     If enabled plyaers will be added to a queue instead of being kicked after SoftMaxPlayers is reached
        /// </summary>
        public static readonly CVarDef<bool> QueueEnabled =
            CVarDef.Create("queue.enabled", false, CVar.SERVERONLY);

        #endregion
        #region Discord

        /*
         * Discord
         */

        /// <summary>
        /// The role that will get mentioned if a new SOS ahelp comes in.
        /// </summary>
        public static readonly CVarDef<string> DiscordAhelpMention =
            CVarDef.Create("discord.on_call_ping", string.Empty, CVar.SERVERONLY | CVar.CONFIDENTIAL);

        /// <summary>
        /// URL of the discord webhook to relay unanswered ahelp messages.
        /// </summary>
        public static readonly CVarDef<string> DiscordOnCallWebhook =
            CVarDef.Create("discord.on_call_webhook", string.Empty, CVar.SERVERONLY | CVar.CONFIDENTIAL);

        /// <summary>
        /// URL of the Discord webhook which will relay all ahelp messages.
        /// </summary>
        public static readonly CVarDef<string> DiscordAHelpWebhook =
            CVarDef.Create("discord.ahelp_webhook", string.Empty, CVar.SERVERONLY | CVar.CONFIDENTIAL);

        /// <summary>
        /// The server icon to use in the Discord ahelp embed footer.
        /// Valid values are specified at https://discord.com/developers/docs/resources/channel#embed-object-embed-footer-structure.
        /// </summary>
        public static readonly CVarDef<string> DiscordAHelpFooterIcon =
            CVarDef.Create("discord.ahelp_footer_icon", string.Empty, CVar.SERVERONLY);

        /// <summary>
        /// The avatar to use for the webhook. Should be an URL.
        /// </summary>
        public static readonly CVarDef<string> DiscordAHelpAvatar =
            CVarDef.Create("discord.ahelp_avatar", string.Empty, CVar.SERVERONLY);

        /// <summary>
        /// URL of the Discord webhook which will relay all custom votes. If left empty, disables the webhook.
        /// </summary>
        public static readonly CVarDef<string> DiscordVoteWebhook =
            CVarDef.Create("discord.vote_webhook", string.Empty, CVar.SERVERONLY);

        /// URL of the Discord webhook which will relay round restart messages.
        /// </summary>
        public static readonly CVarDef<string> DiscordRoundUpdateWebhook =
            CVarDef.Create("discord.round_update_webhook", string.Empty, CVar.SERVERONLY | CVar.CONFIDENTIAL);

        /// <summary>
        /// Role id for the Discord webhook to ping when the round ends.
        /// </summary>
        public static readonly CVarDef<string> DiscordRoundEndRoleWebhook =
            CVarDef.Create("discord.round_end_role", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     Enable Discord linking, show linking button and modal window
        /// </summary>
        public static readonly CVarDef<bool> DiscordAuthEnabled =
            CVarDef.Create("discord.auth_enabled", false, CVar.SERVERONLY);

        /// <summary>
        ///     URL of the Discord auth server API
        /// </summary>
        public static readonly CVarDef<string> DiscordAuthApiUrl =
            CVarDef.Create("discord.auth_api_url", "", CVar.SERVERONLY);

        /// <summary>
        ///     Secret key of the Discord auth server API
        /// </summary>
        public static readonly CVarDef<string> DiscordAuthApiKey =
            CVarDef.Create("discord.auth_api_key", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

        #endregion
        #region Tips
        /*
         * Tips
         */

        /// <summary>
        ///     Whether tips being shown is enabled at all.
        /// </summary>
        public static readonly CVarDef<bool> TipsEnabled =
            CVarDef.Create("tips.enabled", true);

        /// <summary>
        ///     The dataset prototype to use when selecting a random tip.
        /// </summary>
        public static readonly CVarDef<string> TipsDataset =
            CVarDef.Create("tips.dataset", "Tips");

        /// <summary>
        ///     The number of seconds between each tip being displayed when the round is not actively going
        ///     (i.e. postround or lobby)
        /// </summary>
        public static readonly CVarDef<float> TipFrequencyOutOfRound =
            CVarDef.Create("tips.out_of_game_frequency", 60f * 1.5f);

        /// <summary>
        ///     The number of seconds between each tip being displayed when the round is actively going
        /// </summary>
        public static readonly CVarDef<float> TipFrequencyInRound =
            CVarDef.Create("tips.in_game_frequency", 60f * 60);

        public static readonly CVarDef<string> LoginTipsDataset =
            CVarDef.Create("tips.login_dataset", "Tips");

        /// <summary>
        ///     The chance for Tippy to replace a normal tip message.
        /// </summary>
        public static readonly CVarDef<float> TipsTippyChance =
            CVarDef.Create("tips.tippy_chance", 0.01f);

        #endregion
        #region Console
        /*
         * Console
         */

        public static readonly CVarDef<bool> ConsoleLoginLocal =
            CVarDef.Create("console.loginlocal", true, CVar.ARCHIVE | CVar.SERVERONLY);

        /// <summary>
        /// Automatically log in the given user as host, equivalent to the <c>promotehost</c> command.
        /// </summary>
        public static readonly CVarDef<string> ConsoleLoginHostUser =
            CVarDef.Create("console.login_host_user", "", CVar.ARCHIVE | CVar.SERVERONLY);


        #endregion
        #region Database stuff
        /*
         * Database stuff
         */

        public static readonly CVarDef<string> DatabaseEngine =
            CVarDef.Create("database.engine", "sqlite", CVar.SERVERONLY);

        public static readonly CVarDef<string> DatabaseSqliteDbPath =
            CVarDef.Create("database.sqlite_dbpath", "preferences.db", CVar.SERVERONLY);

        /// <summary>
        /// Milliseconds to asynchronously delay all SQLite database acquisitions with.
        /// </summary>
        /// <remarks>
        /// Defaults to 1 on DEBUG, 0 on RELEASE.
        /// This is intended to help catch .Result deadlock bugs that only happen on postgres
        /// (because SQLite is not actually asynchronous normally)
        /// </remarks>
        public static readonly CVarDef<int> DatabaseSqliteDelay =
            CVarDef.Create("database.sqlite_delay", DefaultSqliteDelay, CVar.SERVERONLY);

        /// <summary>
        /// Amount of concurrent SQLite database operations.
        /// </summary>
        /// <remarks>
        /// Note that SQLite is not a properly asynchronous database and also has limited read/write concurrency.
        /// Increasing this number may allow more concurrent reads, but it probably won't matter much.
        /// SQLite operations are normally ran on the thread pool, which may cause thread pool starvation if the concurrency is too high.
        /// </remarks>
        public static readonly CVarDef<int> DatabaseSqliteConcurrency =
            CVarDef.Create("database.sqlite_concurrency", 3, CVar.SERVERONLY);

#if DEBUG
        private const int DefaultSqliteDelay = 1;
#else
        private const int DefaultSqliteDelay = 0;
#endif


        public static readonly CVarDef<string> DatabasePgHost =
            CVarDef.Create("database.pg_host", "localhost", CVar.SERVERONLY);

        public static readonly CVarDef<int> DatabasePgPort =
            CVarDef.Create("database.pg_port", 5432, CVar.SERVERONLY);

        public static readonly CVarDef<string> DatabasePgDatabase =
            CVarDef.Create("database.pg_database", "ss14", CVar.SERVERONLY);

        public static readonly CVarDef<string> DatabasePgUsername =
            CVarDef.Create("database.pg_username", "postgres", CVar.SERVERONLY);

        public static readonly CVarDef<string> DatabasePgPassword =
            CVarDef.Create("database.pg_password", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

        /// <summary>
        /// Max amount of concurrent Postgres database operations.
        /// </summary>
        public static readonly CVarDef<int> DatabasePgConcurrency =
            CVarDef.Create("database.pg_concurrency", 8, CVar.SERVERONLY);

        /// <summary>
        /// Milliseconds to asynchronously delay all PostgreSQL database operations with.
        /// </summary>
        /// <remarks>
        /// This is intended for performance testing. It works different from <see cref="DatabaseSqliteDelay"/>,
        /// as the lag is applied after acquiring the database lock.
        /// </remarks>
        public static readonly CVarDef<int> DatabasePgFakeLag =
            CVarDef.Create("database.pg_fake_lag", 0, CVar.SERVERONLY);

        // Basically only exists for integration tests to avoid race conditions.
        public static readonly CVarDef<bool> DatabaseSynchronous =
            CVarDef.Create("database.sync", false, CVar.SERVERONLY);

        #endregion
        #region Interface
        /*
         * Interface
         */

        public static readonly CVarDef<string> UIClickSound =
            CVarDef.Create("interface.click_sound", "/Audio/UserInterface/click.ogg", CVar.REPLICATED);

        public static readonly CVarDef<string> UIHoverSound =
            CVarDef.Create("interface.hover_sound", "/Audio/UserInterface/hover.ogg", CVar.REPLICATED);

        #endregion
        #region Outline
        /*
         * Outline
         */

        public static readonly CVarDef<bool> OutlineEnabled =
            CVarDef.Create("outline.enabled", true, CVar.CLIENTONLY);


        #endregion
        #region Parallax
        /*
         * Parallax
         */

        public static readonly CVarDef<bool> ParallaxEnabled =
            CVarDef.Create("parallax.enabled", true, CVar.CLIENTONLY);

        public static readonly CVarDef<bool> ParallaxDebug =
            CVarDef.Create("parallax.debug", false, CVar.CLIENTONLY);

        public static readonly CVarDef<bool> ParallaxLowQuality =
            CVarDef.Create("parallax.low_quality", false, CVar.ARCHIVE | CVar.CLIENTONLY);

        #endregion
        #region Physics
        /*
         * Physics
         */

        /// <summary>
        /// When a mob is walking should its X / Y movement be relative to its parent (true) or the map (false).
        /// </summary>
        public static readonly CVarDef<bool> RelativeMovement =
            CVarDef.Create("physics.relative_movement", true, CVar.ARCHIVE | CVar.REPLICATED);

        public static readonly CVarDef<float> TileFrictionModifier =
            CVarDef.Create("physics.tile_friction", 40.0f, CVar.ARCHIVE | CVar.REPLICATED);

        public static readonly CVarDef<float> StopSpeed =
            CVarDef.Create("physics.stop_speed", 0.1f, CVar.ARCHIVE | CVar.REPLICATED);

        /// <summary>
        /// Whether mobs can push objects like lockers.
        /// </summary>
        /// <remarks>
        /// Technically client doesn't need to know about it but this may prevent a bug in the distant future so it stays.
        /// </remarks>
        public static readonly CVarDef<bool> MobPushing =
            CVarDef.Create("physics.mob_pushing", false, CVar.REPLICATED);

        #endregion
        #region Music
        /*
         * Music
         */

        public static readonly CVarDef<bool> LobbyMusicEnabled =
            CVarDef.Create("ambience.lobby_music_enabled", true, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<bool> EventMusicEnabled =
            CVarDef.Create("ambience.event_music_enabled", true, CVar.ARCHIVE | CVar.CLIENTONLY);

        #endregion
        #region Specific Sounds

        /*
         * Specific Sounds
         */
        // Round  end sound (APC Destroyed)
        public static readonly CVarDef<bool> RestartSoundsEnabled =
            CVarDef.Create("ambience.restart_sounds_enabled", true, CVar.ARCHIVE | CVar.CLIENTONLY);


        #endregion
        #region Admin Sounds
        /*
         * Admin sounds
         */

        public static readonly CVarDef<bool> AdminSoundsEnabled =
            CVarDef.Create("audio.admin_sounds_enabled", true, CVar.ARCHIVE | CVar.CLIENTONLY);
        public static readonly CVarDef<string> AdminChatSoundPath =
            CVarDef.Create("audio.admin_chat_sound_path", "/Audio/Items/pop.ogg", CVar.ARCHIVE | CVar.CLIENT | CVar.REPLICATED);
        public static readonly CVarDef<float> AdminChatSoundVolume =
            CVarDef.Create("audio.admin_chat_sound_volume", -5f, CVar.ARCHIVE | CVar.CLIENT | CVar.REPLICATED);

        #endregion
        #region HUD
        /*
         * HUD
         */

        public static readonly CVarDef<int> HudTheme =
            CVarDef.Create("hud.theme", 0, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<bool> HudHeldItemShow =
            CVarDef.Create("hud.held_item_show", true, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<bool> CombatModeIndicatorsPointShow =
            CVarDef.Create("hud.combat_mode_indicators_point_show", true, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<bool> OfferModeIndicatorsPointShow =
            CVarDef.Create("hud.offer_mode_indicators_point_show", true, CVar.ARCHIVE | CVar.CLIENTONLY);
        public static readonly CVarDef<bool> LoocAboveHeadShow =
            CVarDef.Create("hud.show_looc_above_head", true, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<float> HudHeldItemOffset =
            CVarDef.Create("hud.held_item_offset", 28f, CVar.ARCHIVE | CVar.CLIENTONLY);

        public static readonly CVarDef<bool> HudFpsCounterVisible =
            CVarDef.Create("hud.fps_counter_visible", false, CVar.CLIENTONLY | CVar.ARCHIVE);

        #endregion
        #region NPCs
        /*
         * NPCs
         */

        public static readonly CVarDef<int> NPCMaxUpdates =
            CVarDef.Create("npc.max_updates", 128);

        public static readonly CVarDef<bool> NPCEnabled = CVarDef.Create("npc.enabled", true);

        /// <summary>
        /// Should NPCs pathfind when steering. For debug purposes.
        /// </summary>
        public static readonly CVarDef<bool> NPCPathfinding = CVarDef.Create("npc.pathfinding", true);

        #endregion
        #region Net
        /*
         * Net
         */

        public static readonly CVarDef<float> NetAtmosDebugOverlayTickRate =
            CVarDef.Create("net.atmosdbgoverlaytickrate", 3.0f);

        public static readonly CVarDef<float> NetGasOverlayTickRate =
            CVarDef.Create("net.gasoverlaytickrate", 3.0f);

        public static readonly CVarDef<int> GasOverlayThresholds =
            CVarDef.Create("net.gasoverlaythresholds", 20);

        #endregion
        #region Admin
        /*
         * Admin
         */

        public static readonly CVarDef<bool> AdminAnnounceLogin =
            CVarDef.Create("admin.announce_login", true, CVar.SERVERONLY);

        public static readonly CVarDef<bool> AdminAnnounceLogout =
            CVarDef.Create("admin.announce_logout", true, CVar.SERVERONLY);

        /// <summary>
        ///     The token used to authenticate with the admin API. Leave empty to disable the admin API. This is a secret! Do not share!
        /// </summary>
        public static readonly CVarDef<string> AdminApiToken =
            CVarDef.Create("admin.api_token", string.Empty, CVar.SERVERONLY | CVar.CONFIDENTIAL);


        /// <summary>
        /// Should users be able to see their own notes? Admins will be able to see and set notes regardless
        /// </summary>
        public static readonly CVarDef<bool> SeeOwnNotes =
            CVarDef.Create("admin.see_own_notes", false, CVar.ARCHIVE | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// Should the server play a quick sound to the active admins whenever a new player joins?
        /// </summary>
        public static readonly CVarDef<bool> AdminNewPlayerJoinSound =
            CVarDef.Create("admin.new_player_join_sound", false, CVar.SERVERONLY);

        /// <summary>
        /// The amount of days before the note starts fading. It will slowly lose opacity until it reaches stale. Set to 0 to disable.
        /// </summary>
        public static readonly CVarDef<double> NoteFreshDays =
            CVarDef.Create("admin.note_fresh_days", 91.31055, CVar.ARCHIVE | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// The amount of days before the note completely fades, and can only be seen by admins if they press "see more notes". Set to 0
        /// if you want the note to immediately disappear without fading.
        /// </summary>
        public static readonly CVarDef<double> NoteStaleDays =
            CVarDef.Create("admin.note_stale_days", 365.2422, CVar.ARCHIVE | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// How much time does the user have to wait in seconds before confirming that they saw an admin message?
        /// </summary>
        public static readonly CVarDef<float> MessageWaitTime =
            CVarDef.Create("admin.message_wait_time", 3f, CVar.ARCHIVE | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// Default severity for role bans
        /// </summary>
        public static readonly CVarDef<string> RoleBanDefaultSeverity =
            CVarDef.Create("admin.role_ban_default_severity", "medium", CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Default severity for department bans
        /// </summary>
        public static readonly CVarDef<string> DepartmentBanDefaultSeverity =
            CVarDef.Create("admin.department_ban_default_severity", "medium", CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Default severity for server bans
        /// </summary>
        public static readonly CVarDef<string> ServerBanDefaultSeverity =
            CVarDef.Create("admin.server_ban_default_severity", "High", CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether a server ban will ban the player's ip by default.
        /// </summary>
        public static readonly CVarDef<bool> ServerBanIpBanDefault =
            CVarDef.Create("admin.server_ban_ip_ban_default", true, CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether a server ban will ban the player's hardware id by default.
        /// </summary>
        public static readonly CVarDef<bool> ServerBanHwidBanDefault =
            CVarDef.Create("admin.server_ban_hwid_ban_default", true, CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether to use details from last connection for ip/hwid in the BanPanel.
        /// </summary>
        public static readonly CVarDef<bool> ServerBanUseLastDetails =
            CVarDef.Create("admin.server_ban_use_last_details", true, CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether to erase a player's chat messages and their entity from the game when banned.
        /// </summary>
        public static readonly CVarDef<bool> ServerBanErasePlayer =
            CVarDef.Create("admin.server_ban_erase_player", false, CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        ///     Minimum players sharing a connection required to create an alert. -1 to disable the alert.
        /// </summary>
        /// <remarks>
        ///     If you set this to 0 or 1 then it will alert on every connection, so probably don't do that.
        /// </remarks>
        public static readonly CVarDef<int> AdminAlertMinPlayersSharingConnection =
            CVarDef.Create("admin.alert.min_players_sharing_connection", -1, CVar.SERVERONLY);

        /// <summary>
        ///     Minimum explosion intensity to create an admin alert message. -1 to disable the alert.
        /// </summary>
        public static readonly CVarDef<int> AdminAlertExplosionMinIntensity =
            CVarDef.Create("admin.alert.explosion_min_intensity", 60, CVar.SERVERONLY);

        /// <summary>
        ///     Minimum particle accelerator strength to create an admin alert message.
        /// </summary>
        public static readonly CVarDef<int> AdminAlertParticleAcceleratorMinPowerState =
            CVarDef.Create("admin.alert.particle_accelerator_min_power_state", 3, CVar.SERVERONLY);

        /// <summary>
        ///     Should the ban details in admin channel include PII? (IP, HWID, etc)
        /// </summary>
        public static readonly CVarDef<bool> AdminShowPIIOnBan =
            CVarDef.Create("admin.show_pii_onban", false, CVar.SERVERONLY);

        /// <summary>
        /// If an admin joins a round by reading up or using the late join button, automatically
        /// de-admin them.
        /// </summary>
        public static readonly CVarDef<bool> AdminDeadminOnJoin =
            CVarDef.Create("admin.deadmin_on_join", false, CVar.SERVERONLY);

        /// <summary>
        ///     Overrides the name the client sees in ahelps. Set empty to disable.
        /// </summary>
        public static readonly CVarDef<string> AdminAhelpOverrideClientName =
            CVarDef.Create("admin.override_adminname_in_client_ahelp", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     The threshold of minutes to appear as a "new player" in the ahelp menu
        ///     If 0, appearing as a new player is disabled.
        /// </summary>
        public static readonly CVarDef<int> NewPlayerThreshold =
            CVarDef.Create("admin.new_player_threshold", 0, CVar.ARCHIVE | CVar.REPLICATED | CVar.SERVER);

        /// <summary>
        /// How long an admin client can go without any input before being considered AFK.
        /// </summary>
        public static readonly CVarDef<float> AdminAfkTime =
            CVarDef.Create("admin.afk_time", 600f, CVar.SERVERONLY);

        /// <summary>
        /// If true, admins are able to connect even if
        /// <see cref="SoftMaxPlayers"/> would otherwise block regular players.
        /// </summary>
        public static readonly CVarDef<bool> AdminBypassMaxPlayers =
            CVarDef.Create("admin.bypass_max_players", true, CVar.SERVERONLY);

        /// <summary>
        /// Determine if custom rank names are used.
        /// If it is false, it'd use the actual rank name regardless of the individual's title.
        /// </summary>
        /// <seealso cref="AhelpAdminPrefix"/>
        /// <seealso cref="AhelpAdminPrefixWebhook"/>
        public static readonly CVarDef<bool> AdminUseCustomNamesAdminRank =
            CVarDef.Create("admin.use_custom_names_admin_rank", true, CVar.SERVERONLY);

        /// <summary>
        ///     Determines whether admins count towards the total playercount when determining whether the server is over <see cref="SoftMaxPlayers"/>
        ///     Ideally this should be used in conjuction with <see cref="AdminBypassPlayers"/>.
        ///     This also applies to playercount limits in whitelist conditions
        ///     If false, then admins will not be considered when checking whether the playercount is already above the soft player cap
        /// </summary>
        public static readonly CVarDef<bool> AdminsCountForMaxPlayers =
            CVarDef.Create("admin.admins_count_for_max_players", false, CVar.SERVERONLY);

        #endregion
        #region AHELP
        /*
         * AHELP
         */

        /// <summary>
        /// Ahelp rate limit values are accounted in periods of this size (seconds).
        /// After the period has passed, the count resets.
        /// </summary>
        /// <seealso cref="AhelpRateLimitCount"/>
        public static readonly CVarDef<float> AhelpRateLimitPeriod =
            CVarDef.Create("ahelp.rate_limit_period", 2f, CVar.SERVERONLY);

        /// <summary>
        /// How many ahelp messages are allowed in a single rate limit period.
        /// </summary>
        /// <seealso cref="AhelpRateLimitPeriod"/>
        public static readonly CVarDef<int> AhelpRateLimitCount =
            CVarDef.Create("ahelp.rate_limit_count", 10, CVar.SERVERONLY);

        /// <summary>
        /// Should the administrator's position be displayed in ahelp.
        /// If it is is false, only the admin's ckey will be displayed in the ahelp.
        /// </summary>
        /// <seealso cref="AdminUseCustomNamesAdminRank"/>
        /// <seealso cref="AhelpAdminPrefixWebhook"/>
        public static readonly CVarDef<bool> AhelpAdminPrefix =
            CVarDef.Create("ahelp.admin_prefix", true, CVar.SERVERONLY);

        /// <summary>
        /// Should the administrator's position be displayed in the webhook.
        /// If it is is false, only the admin's ckey will be displayed in webhook.
        /// </summary>
        /// <seealso cref="AdminUseCustomNamesAdminRank"/>
        /// <seealso cref="AhelpAdminPrefix"/>
        public static readonly CVarDef<bool> AhelpAdminPrefixWebhook =
            CVarDef.Create("ahelp.admin_prefix_webhook", true, CVar.SERVERONLY);

        /// <summary>
        ///     If an admin replies to users from discord, should it use their discord role color? (if applicable)
        ///     Overrides DiscordReplyColor and AdminBwoinkColor.
        /// </summary>
        public static readonly CVarDef<bool> UseDiscordRoleColor =
            CVarDef.Create("admin.use_discord_role_color", false, CVar.SERVERONLY);

        /// <summary>
        ///     If an admin replies to users from discord, should it use their discord role color? (if applicable)
        ///     Overrides DiscordReplyColor and AdminBwoinkColor.
        /// </summary>
        public static readonly CVarDef<bool> UseDiscordRoleName =
            CVarDef.Create("admin.use_discord_role_name", false, CVar.SERVERONLY);

        /// <summary>
        ///     The text before an admin's name when replying from discord to indicate they're speaking from discord.
        /// </summary>
        public static readonly CVarDef<string> DiscordReplyPrefix =
            CVarDef.Create("admin.discord_reply_prefix", "(DC) ", CVar.SERVERONLY);

        /// <summary>
        ///     The color of the names of admins. This is the fallback color for admins.
        /// </summary>
        public static readonly CVarDef<string> AdminBwoinkColor =
            CVarDef.Create("admin.admin_bwoink_color", "red", CVar.SERVERONLY);

        /// <summary>
        ///     The color of the names of admins who reply from discord. Leave empty to disable.
        ///     Overrides AdminBwoinkColor.
        /// </summary>
        public static readonly CVarDef<string> DiscordReplyColor =
            CVarDef.Create("admin.discord_reply_color", string.Empty, CVar.SERVERONLY);

        /// <summary>
        ///     Use the admin's Admin OOC color in bwoinks.
        ///     If either the ooc color or this is not set, uses the admin.admin_bwoink_color value.
        /// </summary>
        public static readonly CVarDef<bool> UseAdminOOCColorInBwoinks =
            CVarDef.Create("admin.bwoink_use_admin_ooc_color", false, CVar.SERVERONLY);

        #endregion
        #region Explosions
        /*
         * Explosions
         */

        /// <summary>
        ///     How many tiles the explosion system will process per tick
        /// </summary>
        /// <remarks>
        ///     Setting this too high will put a large load on a single tick. Setting this too low will lead to
        ///     unnaturally "slow" explosions.
        /// </remarks>
        public static readonly CVarDef<int> ExplosionTilesPerTick =
            CVarDef.Create("explosion.tiles_per_tick", 100, CVar.SERVERONLY);

        /// <summary>
        ///     Upper limit on the size of an explosion before physics-throwing is disabled.
        /// </summary>
        /// <remarks>
        ///     Large nukes tend to generate a lot of shrapnel that flies through space. This can functionally cripple
        ///     the server TPS for a while after an explosion (or even during, if the explosion is processed
        ///     incrementally.
        /// </remarks>
        public static readonly CVarDef<int> ExplosionThrowLimit =
            CVarDef.Create("explosion.throw_limit", 400, CVar.SERVERONLY);

        /// <summary>
        ///     If this is true, explosion processing will pause the NodeGroupSystem to pause updating.
        /// </summary>
        /// <remarks>
        ///     This only takes effect if an explosion needs more than one tick to process (i.e., covers more than <see
        ///     cref="ExplosionTilesPerTick"/> tiles). If this is not enabled, the node-system will rebuild its graph
        ///     every tick as the explosion shreds the station, causing significant slowdown.
        /// </remarks>
        public static readonly CVarDef<bool> ExplosionSleepNodeSys =
            CVarDef.Create("explosion.node_sleep", true, CVar.SERVERONLY);

        /// <summary>
        ///     Upper limit on the total area that an explosion can affect before the neighbor-finding algorithm just
        ///     stops. Defaults to a 60-rile radius explosion.
        /// </summary>
        /// <remarks>
        ///     Actual area may be larger, as it currently doesn't terminate mid neighbor finding. I.e., area may be that of a ~51 tile radius circle instead.
        /// </remarks>
        public static readonly CVarDef<int> ExplosionMaxArea =
            CVarDef.Create("explosion.max_area", (int) 3.14f * 256 * 256, CVar.SERVERONLY);

        /// <summary>
        ///     Upper limit on the number of neighbor finding steps for the explosion system neighbor-finding algorithm.
        /// </summary>
        /// <remarks>
        ///     Effectively places an upper limit on the range that any explosion can have. In the vast majority of
        ///     instances, <see cref="ExplosionMaxArea"/> will likely be hit before this becomes a limiting factor.
        /// </remarks>
        public static readonly CVarDef<int> ExplosionMaxIterations =
            CVarDef.Create("explosion.max_iterations", 500, CVar.SERVERONLY);

        /// <summary>
        ///     Max Time in milliseconds to spend processing explosions every tick.
        /// </summary>
        /// <remarks>
        ///     This time limiting is not perfectly implemented. Firstly, a significant chunk of processing time happens
        ///     due to queued entity deletions, which happen outside of the system update code. Secondly, explosion
        ///     spawning cannot currently be interrupted & resumed, and may lead to exceeding this time limit.
        /// </remarks>
        public static readonly CVarDef<float> ExplosionMaxProcessingTime =
            CVarDef.Create("explosion.max_tick_time", 7f, CVar.SERVERONLY);

        /// <summary>
        ///     If the explosion is being processed incrementally over several ticks, this variable determines whether
        ///     updating the grid tiles should be done incrementally at the end of every tick, or only once the explosion has finished processing.
        /// </summary>
        /// <remarks>
        ///     The most notable consequence of this change is that explosions will only punch a hole in the station &
        ///     create a vacumm once they have finished exploding. So airlocks will no longer slam shut as the explosion
        ///     expands, just suddenly at the end.
        /// </remarks>
        public static readonly CVarDef<bool> ExplosionIncrementalTileBreaking =
            CVarDef.Create("explosion.incremental_tile", false, CVar.SERVERONLY);

        /// <summary>
        ///     This determines for how many seconds an explosion should stay visible once it has finished expanding.
        /// </summary>
        public static readonly CVarDef<float> ExplosionPersistence =
            CVarDef.Create("explosion.persistence", 1.0f, CVar.SERVERONLY);

        /// <summary>
        ///     If an explosion covers a larger area than this number, the damaging/processing will always start during
        ///     the next tick, instead of during the same tick that the explosion was generated in.
        /// </summary>
        /// <remarks>
        ///     This value can be used to ensure that for large explosions the area/tile calculation and the explosion
        ///     processing/damaging occurs in separate ticks. This helps reduce the single-tick lag if both <see
        ///     cref="ExplosionMaxProcessingTime"/> and <see cref="ExplosionTilesPerTick"/> are large. I.e., instead of
        ///     a single tick explosion, this cvar allows for a configuration that results in a two-tick explosion,
        ///     though most of the computational cost is still in the second tick.
        /// </remarks>
        public static readonly CVarDef<int> ExplosionSingleTickAreaLimit =
            CVarDef.Create("explosion.single_tick_area_limit", 400, CVar.SERVERONLY);

        /// <summary>
        ///     Whether or not explosions are allowed to create tiles that have
        ///     <see cref="ContentTileDefinition.MapAtmosphere"/> set to true.
        /// </summary>
        public static readonly CVarDef<bool> ExplosionCanCreateVacuum =
            CVarDef.Create("explosion.can_create_vacuum", true, CVar.SERVERONLY);

        #endregion
        #region Radiation
        /*
         * Radiation
         */

        /// <summary>
        ///     What is the smallest radiation dose in rads that can be received by object.
        ///     Extremely small values may impact performance.
        /// </summary>
        public static readonly CVarDef<float> RadiationMinIntensity =
            CVarDef.Create("radiation.min_intensity", 0.1f, CVar.SERVERONLY);

        /// <summary>
        ///     Rate of radiation system update in seconds.
        /// </summary>
        public static readonly CVarDef<float> RadiationGridcastUpdateRate =
            CVarDef.Create("radiation.gridcast.update_rate", 1.0f, CVar.SERVERONLY);

        /// <summary>
        ///     If both radiation source and receiver are placed on same grid, ignore grids between them.
        ///     May get inaccurate result in some cases, but greatly boost performance in general.
        /// </summary>
        public static readonly CVarDef<bool> RadiationGridcastSimplifiedSameGrid =
            CVarDef.Create("radiation.gridcast.simplified_same_grid", true, CVar.SERVERONLY);

        /// <summary>
        ///     Max distance that radiation ray can travel in meters.
        /// </summary>
        public static readonly CVarDef<float> RadiationGridcastMaxDistance =
            CVarDef.Create("radiation.gridcast.max_distance", 50f, CVar.SERVERONLY);

        #endregion
        #region Admin logs
        /*
         * Admin logs
         */

        /// <summary>
        ///     Controls if admin logs are enabled. Highly recommended to shut this off for development.
        /// </summary>
        public static readonly CVarDef<bool> AdminLogsEnabled =
            CVarDef.Create("adminlogs.enabled", true, CVar.SERVERONLY);

        public static readonly CVarDef<float> AdminLogsQueueSendDelay =
            CVarDef.Create("adminlogs.queue_send_delay_seconds", 5f, CVar.SERVERONLY);

        // When to skip the waiting time to save in-round admin logs, if no admin logs are currently being saved
        public static readonly CVarDef<int> AdminLogsQueueMax =
            CVarDef.Create("adminlogs.queue_max", 5000, CVar.SERVERONLY);

        // When to skip the waiting time to save pre-round admin logs, if no admin logs are currently being saved
        public static readonly CVarDef<int> AdminLogsPreRoundQueueMax =
            CVarDef.Create("adminlogs.pre_round_queue_max", 5000, CVar.SERVERONLY);

        // When to start dropping logs
        public static readonly CVarDef<int> AdminLogsDropThreshold =
            CVarDef.Create("adminlogs.drop_threshold", 20000, CVar.SERVERONLY);

        // How many logs to send to the client at once
        public static readonly CVarDef<int> AdminLogsClientBatchSize =
            CVarDef.Create("adminlogs.client_batch_size", 1000, CVar.SERVERONLY);

        public static readonly CVarDef<string> AdminLogsServerName =
            CVarDef.Create("adminlogs.server_name", "unknown", CVar.SERVERONLY);

        #endregion
        #region Atmos
        /*
         * Atmos
         */

        /// <summary>
        ///     Whether gas differences will move entities.
        /// </summary>
        public static readonly CVarDef<bool> SpaceWind =
            CVarDef.Create("atmos.space_wind", true, CVar.SERVERONLY);

        /// <summary>
        ///     Divisor from maxForce (pressureDifference * 2.25f) to force applied on objects.
        /// </summary>
        public static readonly CVarDef<float> SpaceWindPressureForceDivisorThrow =
            CVarDef.Create("atmos.space_wind_pressure_force_divisor_throw", 15f, CVar.SERVERONLY);

        /// <summary>
        ///     Divisor from maxForce (pressureDifference * 2.25f) to force applied on objects.
        /// </summary>
        public static readonly CVarDef<float> SpaceWindPressureForceDivisorPush =
            CVarDef.Create("atmos.space_wind_pressure_force_divisor_push", 2500f, CVar.SERVERONLY);

        /// <summary>
        ///     The maximum velocity (not force) that may be applied to an object by atmospheric pressure differences.
        ///     Useful to prevent clipping through objects.
        /// </summary>
        public static readonly CVarDef<float> SpaceWindMaxVelocity =
            CVarDef.Create("atmos.space_wind_max_velocity", 15f, CVar.SERVERONLY);

        /// <summary>
        ///     The maximum force that may be applied to an object by pushing (i.e. not throwing) atmospheric pressure differences.
        ///     A "throwing" atmospheric pressure difference ignores this limit, but not the max. velocity limit.
        /// </summary>
        public static readonly CVarDef<float> SpaceWindMaxPushForce =
            CVarDef.Create("atmos.space_wind_max_push_force", 20f, CVar.SERVERONLY);

        /// <summary>
        ///     If an object's mass is below this number, then this number is used in place of mass to determine whether air pressure can throw an object.
        ///     This has nothing to do with throwing force, only acting as a way of reducing the odds of tiny 5 gram objects from being yeeted by people's breath
        /// </summary>
        /// <remarks>
        ///     If you are reading this because you want to change it, consider looking into why almost every item in the game weighs only 5 grams
        ///     And maybe do your part to fix that? :)
        /// </remarks>
        public static readonly CVarDef<float> SpaceWindMinimumCalculatedMass =
            CVarDef.Create("atmos.space_wind_minimum_calculated_mass", 10f, CVar.SERVERONLY);

        /// <summary>
        /// 	Calculated as 1/Mass, where Mass is the physics.Mass of the desired threshold.
        /// 	If an object's inverse mass is lower than this, it is capped at this. Basically, an upper limit to how heavy an object can be before it stops resisting space wind more.
        /// </summary>
        public static readonly CVarDef<float> SpaceWindMaximumCalculatedInverseMass =
            CVarDef.Create("atmos.space_wind_maximum_calculated_inverse_mass", 0.04f, CVar.SERVERONLY);

        /// <summary>
        ///     Whether monstermos tile equalization is enabled.
        /// </summary>
        public static readonly CVarDef<bool> MonstermosEqualization =
            CVarDef.Create("atmos.monstermos_equalization", true, CVar.SERVERONLY);

        /// <summary>
        ///     Whether monstermos explosive depressurization is enabled.
        ///     Needs <see cref="MonstermosEqualization"/> to be enabled to work.
        /// </summary>
        public static readonly CVarDef<bool> MonstermosDepressurization =
            CVarDef.Create("atmos.monstermos_depressurization", true, CVar.SERVERONLY);

        /// <summary>
        ///     Whether monstermos explosive depressurization will rip tiles..
        ///     Needs <see cref="MonstermosEqualization"/> and <see cref="MonstermosDepressurization"/> to be enabled to work.
		///     WARNING: This cvar causes MAJOR contrast issues, and usually tends to make any spaced scene look very cluttered.
		///     This not only usually looks strange, but can also reduce playability for people with impaired vision. Please think twice before enabling this on your server.
		///     Also looks weird on slow spacing for unrelated reasons. If you do want to enable this, you should probably turn on instaspacing.
        /// </summary>
        public static readonly CVarDef<bool> MonstermosRipTiles =
            CVarDef.Create("atmos.monstermos_rip_tiles", true, CVar.SERVERONLY);

        /// <summary>
        ///     Taken as the cube of a tile's mass, this acts as a minimum threshold of mass for which air pressure calculates whether or not to rip a tile from the floor
        ///     This should be set by default to the cube of the game's lowest mass tile as defined in their prototypes, but can be increased for server performance reasons
        /// </summary>
        public static readonly CVarDef<float> MonstermosRipTilesMinimumPressure =
            CVarDef.Create("atmos.monstermos_rip_tiles_min_pressure", 7500f, CVar.SERVERONLY);

        /// <summary>
        ///     Taken after the minimum pressure is checked, the effective pressure is multiplied by this amount.
        ///		This allows server hosts to finely tune how likely floor tiles are to be ripped apart by air pressure
        /// </summary>
        public static readonly CVarDef<float> MonstermosRipTilesPressureOffset =
            CVarDef.Create("atmos.monstermos_rip_tiles_pressure_offset", 0.44f, CVar.SERVERONLY);

        /// <summary>
        ///     Whether explosive depressurization will cause the grid to gain an impulse.
        ///     Needs <see cref="MonstermosEqualization"/> and <see cref="MonstermosDepressurization"/> to be enabled to work.
        /// </summary>
        public static readonly CVarDef<bool> AtmosGridImpulse =
            CVarDef.Create("atmos.grid_impulse", false, CVar.SERVERONLY);

        /// <summary>
        ///     What fraction of air from a spaced tile escapes every tick.
        ///     1.0 for instant spacing, 0.2 means 20% of remaining air lost each time
        /// </summary>
        public static readonly CVarDef<float> AtmosSpacingEscapeRatio =
            CVarDef.Create("atmos.mmos_spacing_speed", 0.05f, CVar.SERVERONLY);

        /// <summary>
        ///     Minimum amount of air allowed on a spaced tile before it is reset to 0 immediately in kPa
        ///     Since the decay due to SpacingEscapeRatio follows a curve, it would never reach 0.0 exactly
        ///     unless we truncate it somewhere.
        /// </summary>
        public static readonly CVarDef<float> AtmosSpacingMinGas =
            CVarDef.Create("atmos.mmos_min_gas", 2.0f, CVar.SERVERONLY);

        /// <summary>
        ///     How much wind can go through a single tile before that tile doesn't depressurize itself
        ///     (I.e spacing is limited in large rooms heading into smaller spaces)
        /// </summary>
        public static readonly CVarDef<float> AtmosSpacingMaxWind =
            CVarDef.Create("atmos.mmos_max_wind", 500f, CVar.SERVERONLY);

        /// <summary>
        /// Increases default airflow calculations to O(n^2) complexity, for use with heavy space wind optimizations. Potato servers BEWARE
        /// This solves the problem of objects being trapped in an infinite loop of slamming into a wall repeatedly.
        /// </summary>
        public static readonly CVarDef<bool> MonstermosUseExpensiveAirflow =
            CVarDef.Create("atmos.mmos_expensive_airflow", true, CVar.SERVERONLY);

        /// <summary>
        ///     Whether atmos superconduction is enabled.
        /// </summary>
        /// <remarks> Disabled by default, superconduction is awful. </remarks>
        public static readonly CVarDef<bool> Superconduction =
            CVarDef.Create("atmos.superconduction", false, CVar.SERVERONLY);

        /// <summary>
        ///     Heat loss per tile due to radiation at 20 degC, in W.
        /// </summary>
        public static readonly CVarDef<float> SuperconductionTileLoss =
            CVarDef.Create("atmos.superconduction_tile_loss", 30f, CVar.SERVERONLY);

        /// <summary>
        ///     Whether excited groups will be processed and created.
        /// </summary>
        public static readonly CVarDef<bool> ExcitedGroups =
            CVarDef.Create("atmos.excited_groups", true, CVar.SERVERONLY);

        /// <summary>
        ///     Whether all tiles in an excited group will clear themselves once being exposed to space.
        ///     Similar to <see cref="MonstermosDepressurization"/>, without none of the tile ripping or
        ///     things being thrown around very violently.
        ///     Needs <see cref="ExcitedGroups"/> to be enabled to work.
        /// </summary>
        public static readonly CVarDef<bool> ExcitedGroupsSpaceIsAllConsuming =
            CVarDef.Create("atmos.excited_groups_space_is_all_consuming", false, CVar.SERVERONLY);

        /// <summary>
        ///     Maximum time in milliseconds that atmos can take processing.
        /// </summary>
        public static readonly CVarDef<float> AtmosMaxProcessTime =
            CVarDef.Create("atmos.max_process_time", 3f, CVar.SERVERONLY);

        /// <summary>
        ///     Atmos tickrate in TPS. Atmos processing will happen every 1/TPS seconds.
        /// </summary>
        public static readonly CVarDef<float> AtmosTickRate =
            CVarDef.Create("atmos.tickrate", 15f, CVar.SERVERONLY);

        /// <summary>
        ///     Scale factor for how fast things happen in our atmosphere
        ///     simulation compared to real life. 1x means pumps run at 1x
        ///     speed. Players typically expect things to happen faster
        ///     in-game.
        /// </summary>
        public static readonly CVarDef<float> AtmosSpeedup =
            CVarDef.Create("atmos.speedup", 8f, CVar.SERVERONLY);

        /// <summary>
        ///     Like atmos.speedup, but only for gas and reaction heat values. 64x means
        ///     gases heat up and cool down 64x faster than real life.
        /// </summary>
        public static readonly CVarDef<float> AtmosHeatScale =
            CVarDef.Create("atmos.heat_scale", 8f, CVar.SERVERONLY);

        /// <summary>
        ///     A multiplier on the amount of force applied to Humanoid entities, as tracked by HumanoidAppearanceComponent
        ///     This multiplier is added after all other checks are made, and applies to both throwing force, and how easy it is for an entity to be thrown.
        /// </summary>
        public static readonly CVarDef<float> AtmosHumanoidThrowMultiplier =
            CVarDef.Create("atmos.humanoid_throw_multiplier", 2f, CVar.SERVERONLY);

        #endregion
        #region MIDI instruments
        /*
         * MIDI instruments
         */

        public static readonly CVarDef<int> MaxMidiEventsPerSecond =
            CVarDef.Create("midi.max_events_per_second", 1000, CVar.REPLICATED | CVar.SERVER);

        public static readonly CVarDef<int> MaxMidiEventsPerBatch =
            CVarDef.Create("midi.max_events_per_batch", 60, CVar.REPLICATED | CVar.SERVER);

        public static readonly CVarDef<int> MaxMidiBatchesDropped =
            CVarDef.Create("midi.max_batches_dropped", 1, CVar.SERVERONLY);

        public static readonly CVarDef<int> MaxMidiLaggedBatches =
            CVarDef.Create("midi.max_lagged_batches", 8, CVar.SERVERONLY);

        #endregion
        #region Holidays
        /*
         * Holidays
         */

        public static readonly CVarDef<bool> HolidaysEnabled = CVarDef.Create("holidays.enabled", true, CVar.SERVERONLY);

        #endregion
        #region Branding stuff
        /*
         * Branding stuff
         */

        public static readonly CVarDef<bool> BrandingSteam = CVarDef.Create("branding.steam", false, CVar.CLIENTONLY);

        #endregion
        #region OOC
        /*
         * OOC
         */

        public static readonly CVarDef<bool> OocEnabled = CVarDef.Create("ooc.enabled", true, CVar.NOTIFY | CVar.REPLICATED);

        public static readonly CVarDef<bool> AdminOocEnabled =
            CVarDef.Create("ooc.enabled_admin", true, CVar.NOTIFY);

        /// <summary>
        /// If true, whenever OOC is disabled the Discord OOC relay will also be disabled.
        /// </summary>
        public static readonly CVarDef<bool> DisablingOOCDisablesRelay = CVarDef.Create("ooc.disabling_ooc_disables_relay", true, CVar.SERVERONLY);

        /// <summary>
        /// Whether or not OOC chat should be enabled during a round.
        /// </summary>
        public static readonly CVarDef<bool> OocEnableDuringRound =
            CVarDef.Create("ooc.enable_during_round", false, CVar.NOTIFY | CVar.REPLICATED | CVar.SERVER);

        public static readonly CVarDef<bool> ShowOocPatronColor =
            CVarDef.Create("ooc.show_ooc_patron_color", true, CVar.ARCHIVE | CVar.REPLICATED | CVar.CLIENT);

        #endregion
        #region LOOC
        /*
         * LOOC
         */
=======
namespace Content.Shared.CCVar;
>>>>>>> 4bad9289c72b28ec02f213346d9732de2a240a43

/// <summary>
/// Contains all the CVars used by content.
/// </summary>
/// <remarks>
/// NOTICE FOR FORKS: Put your own CVars in a separate file with a different [CVarDefs] attribute. RT will automatically pick up on it.
/// </remarks>
[CVarDefs]
public sealed partial class CCVars : CVars
{
    // Only debug stuff lives here.

    /// <summary>
    /// A simple toggle to test <c>OptionsVisualizerComponent</c>.
    /// </summary>
    public static readonly CVarDef<bool> DebugOptionVisualizerTest =
        CVarDef.Create("debug.option_visualizer_test", false, CVar.CLIENTONLY);

    /// <summary>
    /// Set to true to disable parallel processing in the pow3r solver.
    /// </summary>
    public static readonly CVarDef<bool> DebugPow3rDisableParallel =
        CVarDef.Create("debug.pow3r_disable_parallel", true, CVar.SERVERONLY);
}
