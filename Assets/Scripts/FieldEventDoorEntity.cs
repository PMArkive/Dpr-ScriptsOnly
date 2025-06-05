using FieldDoor;
using UnityEngine;

public class FieldEventDoorEntity : FieldEventEntity
{
    public StartVectol startVectol;
    public string connectionName = "";
    public DoorType doorType;
    public bool doorEnable = true;
    public CallLabel callLabel = CallLabel.none;
    public ExitLabel exitLabel = ExitLabel.none;
    [HideInInspector]
    public int[] locatorArray;
    [HideInInspector]
    public int[] mdIndexArray;

    public override string entityType { get => "FieldEventDoorEntity"; }
}