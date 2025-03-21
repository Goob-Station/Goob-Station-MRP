using Content.Shared.IdentityManagement;
using Content.Shared.InteractionVerbs;
using Content.Shared.Popups;

namespace Content.Shared.Kiss;

public abstract class SharedKissSystem : EntitySystem
{
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    public override void Initialize()
    {
        SubscribeLocalEvent<KissComponent, MoveEvent>(OnMove);
    }

    public void TryKissPerson(EntityUid uid, InteractionArgs args)
    {
        if (!TryComp<KissComponent>(args.Target, out var component))
            return;
        if(!TryComp<KissComponent>(uid, out var offerKiss))
            return;

        // Only when the Ugly trait is enabled
        if (offerKiss.CanBeKissed == false)
        {
            _popup.PopupEntity(Loc.GetString(
                    "kiss-ugly",
                    ("target", Identity.Entity(args.Target, EntityManager))),
                    uid,uid);
            return;
        }
        else if (component.CanBeKissed == false)
        {
            _popup.PopupEntity(Loc.GetString(
                    "kiss-ugly-target",
                    ("user", Identity.Entity(uid, EntityManager))),
                uid, uid);
            return;
        }

        offerKiss.Target = args.Target;
        offerKiss.CanBeKissedMode = false;

        component.Target = uid;
        component.CanBeKissedMode = true;

        _popup.PopupEntity(Loc.GetString(
                "kiss-try-target",
            ("user", Identity.Entity(uid, EntityManager))),
            offerKiss.Target.Value, offerKiss.Target.Value);
    }

    private void OnMove(EntityUid uid, KissComponent component, MoveEvent args)
    {
        if (component.Target == null)
            return;

        // Check if the distance becomes to great for the action to work
        // So the person being offered the kiss can reject the kisser.
        if (args.NewPosition.InRange(
            EntityManager,
            _transform,
            Transform(component.Target.Value).Coordinates,
            component.MaxKissDistance))
            return;
        CancelKiss(uid, component);
    }
    protected void CancelKiss(EntityUid uid, KissComponent component, bool showRejectKissPopup = true)
    {
        if (TryComp<KissComponent>(component.Target, out var offerKiss) && component.Target != null)
        {
            if (showRejectKissPopup)
            {
                _popup.PopupEntity(
                    Loc.GetString(
                        "cancel-kiss-try",
                        ("target", Identity.Entity(component.Target.Value, EntityManager))),
                    uid,
                    uid);
                _popup.PopupEntity(
                    Loc.GetString(
                        "cancel-kiss-try-target",
                        ("user", Identity.Entity(uid, EntityManager))),
                    component.Target.Value,
                    component.Target.Value);
                _popup.PopupEntity(
                    Loc.GetString(
                        "cancel-kiss-try-other",
                        ("user", Identity.Entity(uid, EntityManager)),
                        ("target", Identity.Entity(component.Target.Value, EntityManager))),
                        component.Target.Value);
            }
            offerKiss.CanBeKissedMode = false;
            offerKiss.Target = null;
        }

        component.CanBeKissedMode = false;
        component.Target = null;

    }

}
