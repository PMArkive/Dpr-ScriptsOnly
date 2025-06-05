using UnityEngine;

namespace SmartPoint.Components
{
    public class MultiTouch
    {
        public static Status status = new Status();

        // TODO
        private static Phase GetLogicalButton(LogicalTapType type) { return default; }

        // TODO
        public static Status GetTouchStatus() { return default; }

        public enum LogicalTapType : int
        {
            Z = 0,
            MouseLeft = 1,
            MouseMiddle = 2,
            Max = 3,
        }

        public class Status
        {
            public int count;
            public Touch[] touches;
            public float distance;
            public float deltaDistance;
            public Touch lastTouch;

            // TODO
            public Status() { }

            public class Touch
            {
                public Phase phase;
                public Vector2 delta;
                public Vector2 position;
            }
        }

        public enum Phase : int
        {
            Began = 0,
            Moved = 1,
            Ended = 3,
            Canceld = 4,
            Empty = -1,
        }
    }
}