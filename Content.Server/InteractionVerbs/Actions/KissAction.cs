using Content.Shared.InteractionVerbs;
using Content.Shared.Kiss;

namespace Content.Server.InteractionVerbs.Actions;

public sealed partial class KissAction : InteractionAction
{
    public override bool CanPerform(
        InteractionArgs args,
        InteractionVerbPrototype proto,
        bool beforeDelay,
        VerbDependencies deps
    )
    {
        return true;
    }

    public override bool Perform(InteractionArgs args, InteractionVerbPrototype proto, VerbDependencies deps)
    {
        var uid = args.User;
        deps.EntMan.System<SharedKissSystem>().TryKissPerson(uid, args);
        return true;
    }
}
