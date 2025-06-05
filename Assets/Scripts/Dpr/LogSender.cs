using UnityEngine;

namespace Dpr
{
    public class LogSender
    {
        public static bool IsBusy { get; set; }

        public static void Start()
        {
            // Empty
        }

        public static void Stop()
        {
            // Empty
        }

        private static void SendToTargetManager(string condition, string stackTrace, LogType type)
        {
            // Empty
        }
    }
}