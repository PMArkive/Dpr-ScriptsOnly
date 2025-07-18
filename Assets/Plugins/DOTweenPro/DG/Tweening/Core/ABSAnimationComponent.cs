﻿using UnityEngine;
using UnityEngine.Events;

namespace DG.Tweening.Core
{
    [AddComponentMenu(menuName: "")]
    public abstract class ABSAnimationComponent : MonoBehaviour 
    {
        public UpdateType updateType;
        public bool isSpeedBased;
        public bool hasOnStart;
        public bool hasOnPlay;
        public bool hasOnUpdate;
        public bool hasOnStepComplete;
        public bool hasOnComplete;
        public bool hasOnTweenCreated;
        public bool hasOnRewind;
        public UnityEvent onStart;
        public UnityEvent onPlay;
        public UnityEvent onUpdate;
        public UnityEvent onStepComplete;
        public UnityEvent onComplete;
        public UnityEvent onTweenCreated;
        public UnityEvent onRewind;
        public Tween tween;

        public abstract void DOPlay();

        public abstract void DOPlayBackwards();

        public abstract void DOPlayForward();

        public abstract void DOPause();

        public abstract void DOTogglePause();

        public abstract void DORewind();

        public abstract void DORestart();

        public abstract void DORestart(bool fromHere);

        public abstract void DOComplete();

        public abstract void DOKill();
    }
}