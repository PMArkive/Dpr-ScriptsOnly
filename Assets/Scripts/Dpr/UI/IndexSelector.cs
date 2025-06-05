using System;
using UnityEngine;

namespace Dpr.UI
{
    [Serializable]
    public class IndexSelector
    {
        [SerializeField]
        [Tooltip("インデックスの範囲外になった場合に始端・終端で止める")]
        private bool IsStopInEnd = true;
        [SerializeField]
        [Tooltip("インデックスの範囲外になった場合にリピート移動を止める")]
        private bool IsStopRepeatMovingWhenOutOfRanges = true;
        [SerializeField]
        [Tooltip("インデックスの範囲外になった場合にループする")]
        private bool IsLoop = true;
        private MoveState moveState;

        public int CurrentIndex { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public bool IsLooping { get; set; }

        public IndexSelector(bool isStopInEnd, bool isStopRepeatMovingWhenOutOfRange, bool isLoop)
        {
            IsStopInEnd = isStopInEnd;
            IsStopRepeatMovingWhenOutOfRanges = isStopRepeatMovingWhenOutOfRange;
            IsLoop = isLoop;
        }

        // TODO
        public void Setup(int minCount, int maxCount) { }

        // TODO
        public bool Move(int moveValue) { return false; }

        // TODO
        public void ResumeMoveState() { }

        // TODO
        public void SetCurrentIndex(int index) { }

        private enum MoveState : int
        {
            Neutral = 0,
            Moving = 1,
            Stop = 2,
            Resume = 3,
        }
    }
}