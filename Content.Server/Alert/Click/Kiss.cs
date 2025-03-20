using Content.Shared.Alert;
using Content.Server.Kiss;
using Content.Shared.Kiss;
using JetBrains.Annotations;

namespace Content.Server.Alert.Click;

[UsedImplicitly]
[DataDefinition]
public sealed partial class Kiss : IAlertClick
{
    public void AlertClicked(EntityUid user)
    {
        var entManager = IoCManager.Resolve<IEntityManager>();
        if (entManager.TryGetComponent(user, out KissComponent? kiss))
        {
            entManager.System<KissSystem>().KissPerson(user, kiss);
        }
    }
}
