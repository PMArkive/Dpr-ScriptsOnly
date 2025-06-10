using Dpr.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class XMenuTopItem : MonoBehaviour
{
    [SerializeField]
    private RectTransform _root;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Image _newIcon;
    [SerializeField]
    private Image _imageShadow;
    [SerializeField]
    private UIText _name;
    [SerializeField]
    private Sprite[] _spriteIcons;
    private Animator _animator;

    private static readonly int _animStateSelect = Animator.StringToHash("select");
    private static readonly int _animStateNormal = Animator.StringToHash("normal");
    private static readonly int _animStateDecide = Animator.StringToHash("decide");
    public static readonly int animStateIn = Animator.StringToHash("in");
    public static readonly int animStateOut = Animator.StringToHash("out");

    private XMenuTop.ItemType _itemType = XMenuTop.ItemType.None;
    private List<UIManager.DuplicateImageMaterialParam> _duplicate;

    public XMenuTop.ItemType itemType { get => _itemType; }
    public bool isNew { get => _newIcon.enabled; }

    // TODO
    public void Setup(XMenuTop.ItemType itemType, bool isActived, bool isNew, bool enabled) { }

    // TODO
    private void OnDestroy() { }

    // TODO
    public void PlayAnimation(int shortNameHash) { }

    // TODO
    public void EnableSwapMode(bool enabled) { }

    // TODO
    public void Select(bool enabled) { }

    // TODO
    public void ShowName(bool enabled) { }

    // TODO
    public void Decide(UnityAction<XMenuTopItem> onDecided) { }

    // TODO
    private IEnumerator OpDecide(UnityAction<XMenuTopItem> onDecided) { return null; }
}