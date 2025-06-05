using Dpr;
using UnityEngine;

public class FieldCameraShake
{
    public Vector3 ShakeOffset { get; set; } = Vector3.zero;

    private FieldFloatMove Time = new FieldFloatMove();
    private Vector3 DefaultShakeOffset;
    private float Cycle;

    // TODO
    public void Update(float deltaTime) { }

    public void Shake(Vector3 shakeOfs, float time, float cycle)
    {
        DefaultShakeOffset = shakeOfs;
        ShakeOffset = shakeOfs;
        Time.SetValue(0.0f);
        Time.MoveTime(1.0f, time);
        Cycle = cycle;
    }
}