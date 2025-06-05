using UnityEngine;

public class KinomiObject
{
    public Transform Parent;
    public int TagNo;
    private GameObject[] Objects = new GameObject[7];
    private static readonly string[] GrowedObjectName = new string[3] { "Miki", "Hana", "Mi" };

    // TODO
    public void SetGrowPhase(KinomiWork.GrowPhase grouPhase, bool isWet) { }

    // TODO
    public void Invisible() { }

    // TODO
    public void Visible(ObjectType type) { }

    // TODO
    public void Destroy() { }

    // TODO
    public void Setup(ObjectType type) { }

    // TODO
    private void SetParent(GameObject gameObject) { }

    private KinomiResources KinomiResources { get => FieldManager.Instance.KinomiResources; }

    public enum ObjectType : int
    {
        Soil = 0,
        Seeding = 1,
        Wet = 2,
        Growed = 3,
        GrowedMiki = 4,
        GrowedHana = 5,
        GrowedMi = 6,
        Max = 7,
    }
}