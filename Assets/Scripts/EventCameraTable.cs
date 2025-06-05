using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EventCameraTable", fileName = "EvCamTable")]
public class EventCameraTable : ScriptableObject
{
    public EventCameraCurveTable curve;
    public EventCameraData[] table;

    public EventCameraData this[int index] => table[index];
}