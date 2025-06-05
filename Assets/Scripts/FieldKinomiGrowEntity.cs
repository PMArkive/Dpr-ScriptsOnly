using DPData;
using XLSXContent;

public class FieldKinomiGrowEntity : FieldEventEntity
{
    public int KinomiPlaceIndex;
    private KinomiWork.GrowPhase NowGrowPhase = KinomiWork.GrowPhase.Invalid;
    private bool NowWet;
    private KinomiObject KinomiObject;

    // TODO
    protected override void Awake() { }

    // TODO
    protected override void OnDestroy() { }

    // TODO
    protected override void ProcessSequence(float deltaTime) { }

    // TODO
    public KinomiGrow GetGrow() { return default(KinomiGrow); }

    // TODO
    public KinomiPlaceData.SheetSheet1 GetPlaceData() { return null; }

    // TODO
    public KinomiWork.GrowPhase GetGrowPhase() { return KinomiWork.GrowPhase.Invalid; }

    // TODO
    public void UpdateStatus() { }
}