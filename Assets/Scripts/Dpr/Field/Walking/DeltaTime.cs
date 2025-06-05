using SmartPoint.AssetAssistant;
using System;

namespace Dpr.Field.Walking
{
    [Serializable]
    public class DeltaTime
    {
        public static bool isPause;
        public static float TimeScale = 1.0f;

        public static float deltaTime { get => Sequencer.elapsedTime * TimeScale; }

        public void Update()
        {
            // Empty
        }

        public static void Pause()
        {
            isPause = true;
        }

        public static void UnPause()
        {
            isPause = false;
        }
    }
}