using Robust.Shared.Configuration;

namespace Content.Shared._Goobstation.CCVar;

[CVarDefs]
public sealed partial class GoobCVars
{
    #region Mechs

    /// <summary>
    ///     Whether or not players can use mech guns outside of mechs.
    /// </summary>
    public static readonly CVarDef<bool> MechGunOutsideMech =
        CVarDef.Create("mech.gun_outside_mech", true, CVar.SERVER | CVar.REPLICATED);

    #endregion

    #region RMC

    public static readonly CVarDef<int> RMCPatronLobbyMessageTimeSeconds =
        CVarDef.Create("rmc.patron_lobby_message_time_seconds", 30, CVar.REPLICATED | CVar.SERVER);

    public static readonly CVarDef<int> RMCPatronLobbyMessageInitialDelaySeconds =
        CVarDef.Create("rmc.patron_lobby_message_initial_delay_seconds", 5, CVar.REPLICATED | CVar.SERVER);

    public static readonly CVarDef<string> RMCDiscordAccountLinkingMessageLink =
        CVarDef.Create("rmc.discord_account_linking_message_link", "", CVar.REPLICATED | CVar.SERVER);

    #endregion
}
