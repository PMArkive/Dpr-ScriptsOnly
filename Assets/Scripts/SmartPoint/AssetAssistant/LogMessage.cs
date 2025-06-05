using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class LogMessage
    {
        public const int MaxLogCount = 256;
        public static int lastID = -1;
        public static int nextID = 0;
        public int id;
        public string condition;
        public string stackTrace;
        public LogType type;

        public LogMessage(int id)
        {
            this.id = id;
        }

        public void AdvanceAndSet(string condition, string stackTrace, LogType type)
        {
            lastID = nextID;

            nextID++;
            nextID %= MaxLogCount;

            this.condition = condition;
            this.stackTrace = stackTrace;
            this.type = type;
        }
    }
}