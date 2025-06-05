using UnityEngine;

namespace Dpr.MsgWindow
{
    public class WaitTimer
    {
        private float limitTime;
        private float timer;

        public float Ratio { get => limitTime > 0.0f ? Mathf.Clamp01(timer / limitTime) : 0.0f; }

        public void SetLimitTime(float limitTime)
        {
            this.limitTime = limitTime;
        }

        public void SetCurrentTime(float time)
        {
            if (limitTime > time)
                timer = time;
            else
                timer = limitTime;
        }

        public void ResetTimer()
        {
            timer = 0.0f;
        }

        public bool IsFinishWait(float deltaTime)
        {
            timer += deltaTime;
            return limitTime <= timer;
        }
    }
}