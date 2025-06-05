using System;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class UIAnimationEvent : MonoBehaviour
    {
        public UnityAction<AnimationEventBase> onAnimationEvent;
        public UnityAction<TransitionID, UITransition.FadeType> onTransition;

        private void OnAnimEvent(string json)
        {
            var animEvent = JsonUtility.FromJson<AnimationEventBase>(json);
            if (animEvent.type == AnimationEventBase.EventType.Hoge)
                onAnimationEvent?.Invoke(JsonUtility.FromJson<AnimationEventHoge>(json));
            else
                onAnimationEvent?.Invoke(null);
        }

        private void OnAnimEventTransitionIn(int transitionId)
        {
            onTransition?.Invoke((TransitionID)transitionId, UITransition.FadeType.In);
        }

        private void OnAnimEventTransitionOut(int transitionId)
        {
            onTransition?.Invoke((TransitionID)transitionId, UITransition.FadeType.Out);
        }

        [Serializable]
        public class AnimationEventBase
        {
	        public EventType type;

            public enum EventType : int
            {
                Hoge = 0,
            }
        }

        [Serializable]
        public class AnimationEventHoge: AnimationEventBase
        {
            public int hoge = 123;
        }
    }
}