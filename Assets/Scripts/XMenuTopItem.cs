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

    public void Setup(XMenuTop.ItemType itemType, bool isActived, bool isNew, bool enabled)
    {
        _itemType = itemType;

        if (itemType == XMenuTop.ItemType.Bag)
        {
            var bagdata = UIManager.Instance.GetPlayerCharacterBagData();

            _spriteIcons = new Sprite[]
            {
                UIManager.Instance.GetAtlasSprite(SpriteAtlasID.COMMON, bagdata.XMenuDefault),
                UIManager.Instance.GetAtlasSprite(SpriteAtlasID.COMMON, bagdata.XMenuSelect),
            };

            _imageShadow.sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.COMMON, bagdata.XMenuShadow);
        }

        _animator = GetComponentInChildren<Animator>();
        gameObject.SetActive(isActived);

        if (isActived)
            Select(false);

        _duplicate = UIManager.DuplicateImageMaterials(_root);
        UIManager.Instance.Grayscale(_root, enabled ? 0.0f : 1.0f);

        _newIcon.enabled = isNew;
    }

    private void OnDestroy()
    {
        UIManager.RestoreDuplicateImageMaterials(_duplicate);
    }

    public void PlayAnimation(int shortNameHash)
    {
        _animator.Play(shortNameHash, 0, 0.0f);
    }

    public void EnableSwapMode(bool enabled)
    {
        _root.anchoredPosition = enabled ? new Vector2(17.77778f, 10.0f) : Vector2.zero;
    }

    public void Select(bool enabled)
    {
        _icon.sprite = enabled ? _spriteIcons[1] : _spriteIcons[0];

        if (enabled)
        {
            _animator.Play(_animStateSelect);
            _newIcon.enabled = false;
        }
        else
        {
            _animator.Play(_animStateNormal);
        }
    }

    public void ShowName(bool enabled)
    {
        _name.gameObject.SetActive(enabled);
    }

    public void Decide(UnityAction<XMenuTopItem> onDecided)
    {
        StartCoroutine(OpDecide(onDecided));
    }

    private IEnumerator OpDecide(UnityAction<XMenuTopItem> onDecided)
    {
        PlayAnimation(_animStateDecide);

        yield return new WaitWhile(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);

            if (state.shortNameHash == _animStateDecide)
                return state.normalizedTime < 1.0f;
            else
                return true;
        });

        onDecided?.Invoke(this);
    }
}