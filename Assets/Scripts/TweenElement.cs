using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class TweenElement
{
    [SerializeField]
    public AnimationType animationType = AnimationType.Move;
    [SerializeField]
    public Transform target;
    [SerializeField]
    public Ease easeType = Ease.OutQuad;
    [SerializeField]
    public Vector3 value;
    [SerializeField]
    public float delay;
    [SerializeField]
    public float duration = 1.0f;
    [NonSerialized]
    public Tween tween;
}