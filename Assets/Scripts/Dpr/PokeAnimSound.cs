using System;
using UnityEngine;

namespace Dpr
{
    [Serializable]
    public class PokeAnimSound
    {
        public const uint SND_SWITCH_GROUP = 3000483895;
        public const uint SND_SWITCH_STATE = 1893047300;
        public AnimEventData[] AnimEvent;

        public bool Enable { get; set; }

        private AnimationPlayer _animationPlayer;
        private int _oldClipIndex = -1;
        private int _oldEventIndex = -1;

        public void Init(AnimationPlayer animationPlayer)
        {
            _animationPlayer = animationPlayer;
            _oldClipIndex = -1;
            _oldEventIndex = -1;
        }

        // TODO
        public void Update(Transform transform) { }

        // TODO
        private int getAnimEventIndex(int clipIndex, float time) { return 0; }

        [Serializable]
        public class AnimEventData
        {
            public int[] Frame;
            public uint[] EventSymbol;
        }
    }
}