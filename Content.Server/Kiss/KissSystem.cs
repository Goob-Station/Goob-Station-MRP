using Content.Server.Popups;
using Content.Shared.Alert;
using Content.Shared.Kiss;
using Content.Shared.IdentityManagement;
using Content.Shared.Mood;
using Robust.Server.GameObjects;
using Robust.Server.Audio;
using Content.Shared.Jittering;

namespace Content.Server.Kiss;

public sealed class KissSystem : SharedKissSystem
{
    [Dependency] private readonly AlertsSystem _alertsSystem = default!;
    [Dependency] private readonly PopupSystem _popup = default!;
    [Dependency] private readonly TransformSystem _transform = default!;

    public override void Update(float deltaSeconds)
    {
        base.Update(deltaSeconds);

        var query = EntityQueryEnumerator<KissComponent>();
        while (query.MoveNext(out var uid, out var offerKiss))
        {
            if (!offerKiss.CanBeKissedMode || offerKiss.Target == null)
            {
                _alertsSystem.ClearAlert(uid, offerKiss.KissAlert);
                continue;
            }
            _alertsSystem.ShowAlert(uid, offerKiss.KissAlert);
        }
    }

    public void KissPerson(EntityUid uid, KissComponent? component = null)
    {
        if (!Resolve(uid, ref component) ||
            !TryComp<KissComponent>(component.Target, out var offerKiss))
            return;

        // Shake the kisser
        EntityManager.System<SharedJitteringSystem>().DoJitter(uid,
            time: component.JitterTime,
            refresh: false,
            amplitude: component.JitterAmplitude,
            frequency: component.JitterFrequency);

        // Shake the kissed
        EntityManager.System<SharedJitteringSystem>().DoJitter(component.Target.Value,
            time: offerKiss.JitterTime,
            refresh: false,
            amplitude: offerKiss.JitterAmplitude,
            frequency: offerKiss.JitterFrequency);

        // This might be some shitcode here, but I can't find a better way to run this.
        RaiseLocalEvent(uid, new MoodEffectEvent(component.MoodEffect));
        RaiseLocalEvent(component.Target.Value, new MoodEffectEvent(component.MoodEffect));

        EntityManager.System<AudioSystem>().PlayPvs(component.KissSound, uid);

        _popup.PopupEntity(
            Loc.GetString(
                "kiss-give",
                ("target", Identity.Entity(component.Target.Value, EntityManager))),
            uid,
            uid);
        _popup.PopupEntity(
            Loc.GetString(
                "kissed-other",
                ("user", Identity.Entity(component.Target.Value, EntityManager)),
                ("target", Identity.Entity(uid, EntityManager))),
            component.Target.Value);
        _popup.PopupEntity(
            Loc.GetString(
                "kissed-target",
                ("user", Identity.Entity(uid, EntityManager))),
            component.Target.Value,
            component.Target.Value);

        // Show the heart effect.
        Spawn(component.Effect, _transform.GetMapCoordinates(uid));
        Spawn(offerKiss.Effect, _transform.GetMapCoordinates(component.Target.Value));

        // Once everything is done, we reset everything back to normal. The showRejectKissPopup value is just to hide
        // the rejected kiss popup, so they don't overlap with the popups above.
        CancelKiss(uid, component, false);
    }
}
