using System;
using UnityEngine;

namespace Dpr
{
    public class FieldFloatMove
    {
        public Func<float, float> EaseFunc = EaseDefault;

        public bool IsBusy { get => TargetTime > 0.0f; }
        public float CurrentValue { set; get; }
        public float TargetValue { set; get; }
        public float CurrentTime { set; get; }
        public float TargetTime { set; get; }

        private float BaseValue;

        public void SetValue(float value)
        {
            Stop();
            CurrentValue = value;
        }

        public void Stop()
        {
            TargetTime = 0.0f;
        }

        public void Update(float deltaTime)
        {
            if (TargetTime > 0.0f)
            {
                CurrentTime += deltaTime;
                if (CurrentTime >= TargetTime)
                {
                    CurrentValue = TargetValue;
                    TargetTime = 0.0f;
                }
                else
                {
                    CurrentValue = Mathf.Lerp(BaseValue, TargetValue, EaseFunc(CurrentTime / TargetTime));
                }
            }
        }

        public void MoveTime(float targetValue, float time)
        {
            if (time > 0.0f)
            {
                BaseValue = CurrentValue;
                TargetValue = targetValue;
                CurrentTime = 0.0f;
                TargetTime = time;
            }
            else
            {
                CurrentValue = targetValue;
                TargetTime = 0.0f;
            }
        }

        public static float EaseDefault(float inValue)
        {
            return inValue;
        }

        public static float EaseInOutSin(float inValue)
        {
            return (Mathf.Cos(inValue * Mathf.PI) - 1.0f) * -0.5f;
        }

        public static float EaseOutSin(float inValue)
        {
            return Mathf.Sin(inValue * Mathf.PI * 0.5f);
        }
    }
}