using Content.Shared.Alert;
using Content.Shared.Mood;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Audio;

namespace Content.Shared.Kiss;


[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
[Access(typeof(SharedKissSystem))]
public sealed partial class KissComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite), DataField, AutoNetworkedField]
    public bool CanBeKissedMode;

    [DataField, AutoNetworkedField]
    public bool CanKissMode;

    [DataField]
    public EntityUid? Target;

    [DataField]
    public SoundSpecifier? KissSound;

    [DataField]
    public float MaxKissDistance = 1f;

    // Funny Jitter Extras
    [DataField]
    public float JitterAmplitude = 3f;

    [DataField]
    public float JitterFrequency = 1.5f;

    [DataField]
    public TimeSpan JitterTime = TimeSpan.FromSeconds(0.5);


    [DataField]
    public ProtoId<AlertPrototype> KissAlert = "Kiss";

    // This is just to show the heart effects when kissed.
    [DataField]
    public string Effect = "EffectHearts";

    [DataField]
    public ProtoId<MoodEffectPrototype> MoodEffect = "BeingKissed";
}
