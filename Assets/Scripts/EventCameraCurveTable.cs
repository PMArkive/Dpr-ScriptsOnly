using UnityEngine;

[CreateAssetMenu(fileName = "EvCamCurveTable", menuName = "ScriptableObjects/EventCameraCurveTable")]
public class EventCameraCurveTable : ScriptableObject
{
    public AnimationCurve[] table;
}