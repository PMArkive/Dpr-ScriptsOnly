using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TweenClip
{
    [SerializeField]
    public string name;
    [SerializeField]
    public List<TweenElement> elements = new List<TweenElement>();
    [SerializeField]
    public AnimationClip animationClip;
    private Sequence sequence;

    public void Build(Transform root)
    {
        Destroy();
        sequence = DOTween.Sequence();

        foreach (var elem in elements)
        {
            var target = elem.target == null ? root : elem.target;
            switch (elem.animationType)
            {
                case AnimationType.None:
                    continue;

                case AnimationType.Move:
                    elem.tween = target.DOMove(elem.value, elem.duration);
                    break;

                case AnimationType.LocalMove:
                    elem.tween = target.DOLocalMove(elem.value, elem.duration);
                    break;

                case AnimationType.Rotate:
                    elem.tween = target.DORotate(elem.value, elem.duration);
                    break;

                case AnimationType.LocalRotate:
                    elem.tween = target.DOLocalRotate(elem.value, elem.duration);
                    break;

                case AnimationType.Scale:
                    elem.tween = target.DOLocalRotate(elem.value, elem.duration);
                    break;
            }

            elem.tween.SetAutoKill(false);
            sequence.Insert(elem.delay, elem.tween);
        }

        sequence.Pause();
        sequence.SetAutoKill(false);
    }

    public void Destroy()
    {
        if (sequence != null)
        {
            sequence.Kill();
            sequence = null;
        }

        foreach (var elem in elements)
        {
            if (elem.tween != null)
            {
                elem.tween.Kill();
                elem.tween = null;
            }
        }
    }

    public bool isComplete { get => sequence == null || sequence.IsComplete(); }

    public void Play()
    {
        sequence.Rewind();
        sequence.Restart();
    }

    public void Rewind()
    {
        sequence.Complete(false);
        sequence.Rewind();
    }
}