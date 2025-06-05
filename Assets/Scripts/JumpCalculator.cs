using UnityEngine;

public class JumpCalculator
{
    private float _duration;
    private float _gravity;
    private Vector3 _velocity;
    private Vector3 _startingPoint;
    private float _timeSinceStartup;

    public void Startup(Transform transform, float moveDistance = 2.0f, float relativeHeight = 0.75f, float relativeLower = -0.5f, float duration = 0.5f)
    {
        float denom;
        if (Mathf.Approximately(relativeLower, 0.0f))
            denom = duration * 0.5f;
        else
            denom = (relativeHeight - Mathf.Sqrt((relativeHeight - relativeLower) * relativeHeight)) / relativeLower * duration;

        _duration = duration;
        _gravity = (relativeHeight * -2.0f) / (denom * denom);
        _startingPoint = transform.position;

        var forw = transform.forward;
        _velocity = new Vector3(moveDistance / duration * forw.x, (relativeHeight + relativeHeight) / denom, moveDistance / duration * forw.z);
        _timeSinceStartup = 0.0f;
    }

    public Vector3 Process(float deltaTime, out bool isFinished)
    {
        _timeSinceStartup += deltaTime;
        isFinished = false;

        if (_timeSinceStartup >= _duration)
        {
            isFinished = true;
            _timeSinceStartup = _duration;
        }

        var pos = _startingPoint + (_velocity * _timeSinceStartup);
        pos.y += _timeSinceStartup * _gravity * _timeSinceStartup * 0.5f;

        return pos;
    }
}