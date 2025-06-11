using AK;
using Audio;
using DPData;
using Dpr.EvScript;
using Dpr.Message;
using Dpr.MsgWindow;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class XMenuTop : UIWindow, IViewportChangeHandler, IEventSystemHandler
    {
        [SerializeField]
        private RectTransform _itemRoot;
        [SerializeField]
        private RectTransform _reportWindow;
        [SerializeField]
        private RectTransform _safariRoot;
        [SerializeField]
        private UIText _safariBallNum;
        [SerializeField]
        private RectTransform _messageWindowRoot;
        [SerializeField]
        private RectTransform _gotoTownMapRoot;

        private bool _isActived;
        private GridLayoutGroup _gridLayoutGroup;
        private UnityAction<UIWindow> _saveOnClosed;
        private List<XMenuTopItem> _initItems = new List<XMenuTopItem>();
        private List<XMenuTopItem> _activeItems = new List<XMenuTopItem>();
        private int _selectIndex;

        private const int _upperColumnMax = 4;

        private XMenuTopItem _fromSwapItem;
        private Vector3 _fromSwapPisiton;
        private int _fromSwapSiblingIndex;
        private List<UIManager.DuplicateImageMaterialParam> _duplicate;
        private Coroutine _coroutineTownmapGuideMessage;
        private UIWindowID[] _windowIds = new UIWindowID[]
        {
            UIWindowID.ZUKAN, UIWindowID.POKEMON, UIWindowID.BAG,     UIWindowID.CARD,
            UIWindowID.MAP,   UIWindowID.SEAL,    UIWindowID.SETTING, UIWindowID.GIFT,
            UIWindowID.REPORT,
        };
        private Param _param;

        private void Awake()
        {
            _initItems.Clear();

            for (int i=0; i<_itemRoot.childCount; i++)
                _initItems.Add(_itemRoot.GetChild(i).GetComponent<XMenuTopItem>());

            GetComponentInChildren<CanvasGroup>(true).alpha = 0.0f;
            _gridLayoutGroup = _itemRoot.GetComponent<GridLayoutGroup>();
        }

        public override void OnCreate()
        {
            _canvas = GetComponentInChildren<Canvas>(true);
            _animator = GetComponentInChildren<Animator>(true);
            _animEvent = GetComponentInChildren<UIAnimationEvent>(true);

            if (_animator != null)
            {
                if (_animEvent == null)
                    _animEvent = _animator.gameObject.AddComponent<UIAnimationEvent>();
            }

            if (_animEvent != null)
                _animEvent.onTransition = OnTransition;
        }

        public void Open(Param param, UIWindowID prevWindowId = WINDOWID_FIELD)
        {
            if (prevWindowId == WINDOWID_FIELD)
            {
                _ = UIManager.Instance.GetUIWindowCount();
                bool existPoketch = UIManager.Instance.GetExistWindow(UIWindowID.POKETCH);
                bool existAutoSave = UIManager.Instance.GetExistWindow(UIWindowID.FIELD_AUTOSAVE);
                // There presumably was some logging going on here
            }

            Sequencer.Start(OpOpen(param, prevWindowId));
        }

        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId)
        {
            UIManager.Instance.EnableFureaiLimit(param.menuType == Param.MenuType.Fureai);
            UIManager.Instance.SetOnCloseXMenu(onClosed);
            _param = param;

            OnOpen(prevWindowId);

            if (prevWindowId == WINDOWID_FIELD)
                UIManager.Instance.FadeinBlurBg(onComplete: null);

            Sequencer.update += OnUpdate;
            _input.inputEnabled = true;

            var safariGO = _safariRoot.gameObject;
            if (param.menuType == Param.MenuType.SafariGame)
            {
                safariGO.SetActive(true);
                _reportWindow.gameObject.SetActive(false);
                _safariBallNum.SetFormattedText(() => MessageWordSetHelper.SetDigitWord(0, param.safari.ballNum), null, null);
            }
            else
            {
                safariGO.SetActive(false);
                _reportWindow.gameObject.SetActive(true);
            }

            _gridLayoutGroup.enabled = true;
            _gotoTownMapRoot.gameObject.SetActive(FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_TOWNMAP_GET));

            SetupItems();

            var keyguide = UIManager.Instance.GetKeyguide(null);
            keyguide.transform.SetParent(transform, false);
            
            var keyguideParam = new Keyguide.Param();
            keyguideParam.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.XMENU_DECIDE });

            if (IsSwap())
                keyguideParam.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.XMENU_SWAP });

            if (param.menuType == Param.MenuType.SafariGame)
                keyguideParam.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.XMENU_RETIRE });
            else
                keyguideParam.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.XMENU_REPORT });

            keyguideParam.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.XMENU_BACK });

            keyguide.Open(keyguideParam);

            yield return OpPlayOpenWindowAnimation(prevWindowId, null);

            for (int i=0; i<_activeItems.Count; i++)
                _activeItems[i].PlayAnimation(XMenuTopItem.animStateIn);

            SetupTownmapGuideMessageWindow();

            var selectIndex = -1;
            for (int i=0; i<_activeItems.Count; i++)
            {
                if (_activeItems[i].itemType == (ItemType)PlayerWork.topMenu.selectType)
                {
                    selectIndex = i;
                    break;
                }
            }

            SetSelectIndex(selectIndex, true);
            _isActived = true;
        }

        private void SetupTownmapGuideMessageWindow()
        {
            _coroutineTownmapGuideMessage = StartCoroutine(OpUpdateTownmapGuideMessageWindow());
        }

        private IEnumerator OpUpdateTownmapGuideMessageWindow()
        {
            var guide = UIManager.Instance.SetupCurrentTownmapGuideMessage();

            ZoneID tairyouHasseiZoneId;
            MonsNo tairyouHasseiMonsterNo;
            int[] messageTypes;

            if (EncountDataWork.IsTairyouHassei())
            {
                tairyouHasseiZoneId = ZoneWork.TairyouHassei_ZoneID();

                var monsLv = ZoneWork.TairyouHassei_MonsLv(tairyouHasseiZoneId);
                tairyouHasseiMonsterNo = (monsLv != null && monsLv.Length != 0) ? monsLv[0].monsNo : MonsNo.NULL;

                messageTypes = new int[] { 1, 0 };
            }
            else
            {
                tairyouHasseiZoneId = ZoneID.C01;
                tairyouHasseiMonsterNo = MonsNo.NULL;
                messageTypes = new int[] { 0 };
            }

            var messageIndex = 0;
            var waitSecounds = new WaitForSeconds(5.0f); // Typo in variable name in original code

            do
            {
                if (messageTypes[messageIndex] == 1)
                {
                    MessageWordSetHelper.SetPlaceNameWord(0, UIManager.Instance.GetPlaceNameData(tairyouHasseiZoneId).MessageLabel);
                    MessageWordSetHelper.SetMonsNameWord(1, tairyouHasseiMonsterNo);
                    OpenMessageWindow(new MsgWindowParam()
                    {
                        useMsgFile = MessageManager.Instance.GetMsgFile("ss_xmenu_timeline"),
                        labelName = "ui_msg_xmenu_timeline_pokeoutbreak_00",
                        inputEnabled = true,
                        inputCloseEnabled = false,
                    });
                }
                else if (messageTypes[messageIndex] == 0 && guide != null)
                {
                    MessageWordSetHelper.SetRivalNickNameWord(1);
                    MessageWordSetHelper.SetSupporterName(2);
                    OpenMessageWindow(new MsgWindowParam()
                    {
                        useMsgFile = MessageManager.Instance.GetMsgFile(guide.MSFile),
                        labelName = guide.MSLabel,
                        inputEnabled = true,
                        inputCloseEnabled = false,
                    });
                }

                if (messageTypes.Length == 1)
                {
                    yield return null;
                    break;
                }
                else
                {
                    yield return waitSecounds;
                    messageIndex = (messageIndex + 1) % messageTypes.Length;
                }
            }
            while (true);
        }

        private void StopTownmapGuideMessageWindow()
        {
            if (_coroutineTownmapGuideMessage != null)
            {
                StopCoroutine(_coroutineTownmapGuideMessage);
                _coroutineTownmapGuideMessage = null;
            }
        }

        void IViewportChangeHandler.OnViewportChange(int screenWidth, int screenHeight)
        {
            // Empty
        }

        private void SetupItems()
        {
            var list = new List<int>(Enumerable.Repeat(-1, TopMenuWork.TOPMENUITEM_NUM));

            for (int i = 0; i < TopMenuWork.TOPMENUITEM_NUM; i++)
            {
                var item = _initItems[i];
                item.name = string.Format("{0}", i);
                item.Setup((ItemType)i, IsActiveItem((ItemType)i), PlayerWork.topMenu.items[i].isNew, !IsLimitingItem((ItemType)i));

                list[PlayerWork.topMenu.items[i].index] = i;
            }

            if (IsActiveItem(ItemType.Zukan))
                _initItems[list[(int)ItemType.Zukan]].transform.SetSiblingIndex((int)ItemType.Zukan);

            if (IsActiveItem(ItemType.Pokemon))
                _initItems[list[(int)ItemType.Pokemon]].transform.SetSiblingIndex((int)ItemType.Pokemon);

            if (IsActiveItem(ItemType.Bag))
                _initItems[list[(int)ItemType.Bag]].transform.SetSiblingIndex((int)ItemType.Bag);

            if (IsActiveItem(ItemType.Card))
                _initItems[list[(int)ItemType.Card]].transform.SetSiblingIndex((int)ItemType.Card);

            if (IsActiveItem(ItemType.Map))
                _initItems[list[(int)ItemType.Map]].transform.SetSiblingIndex((int)ItemType.Map);

            if (IsActiveItem(ItemType.Seal))
                _initItems[list[(int)ItemType.Seal]].transform.SetSiblingIndex((int)ItemType.Seal);

            if (IsActiveItem(ItemType.Setting))
                _initItems[list[(int)ItemType.Setting]].transform.SetSiblingIndex((int)ItemType.Setting);

            if (IsActiveItem(ItemType.Gift))
                _initItems[list[(int)ItemType.Gift]].transform.SetSiblingIndex((int)ItemType.Gift);

            SetupActiveItems();

            _duplicate = UIManager.DuplicateImageMaterials(_reportWindow);

            switch (_param.menuType)
            {
                case Param.MenuType.Fureai:
                case Param.MenuType.SafariGame:
                case Param.MenuType.Mysterious:
                    UIManager.Instance.Grayscale(_reportWindow, 1.0f);
                    break;

                default:
                    UIManager.Instance.Grayscale(_reportWindow, 0.0f);
                    break;
            }
        }

        private bool IsActiveItem(ItemType type)
        {
            switch (type)
            {
                case ItemType.Zukan:
                    return FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_ZUKAN_GET);

                case ItemType.Pokemon:
                    return FlagWork.GetWork(EvWork.WORK_INDEX.WK_SCENE_L01) > 2;

                case ItemType.Bag:
                    return true;

                case ItemType.Card:
                    return FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_TRAINER_CARD_OPEN);

                case ItemType.Map:
                    return FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_TOWNMAP_GET);

                case ItemType.Seal:
                    return FlagWork.GetWork(EvWork.WORK_INDEX.WK_SCENE_C01) == 4;

                case ItemType.Setting:
                    return true;

                case ItemType.Gift:
                    return FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_HUSIGINAOKURIMONO_OPEN_FLAG);

                default:
                    return true;
            }
        }

        private bool IsSwap()
        {
            return IsActiveItem(ItemType.Zukan) &&
                   IsActiveItem(ItemType.Pokemon) &&
                   IsActiveItem(ItemType.Bag) &&
                   IsActiveItem(ItemType.Card) &&
                   IsActiveItem(ItemType.Map) &&
                   IsActiveItem(ItemType.Seal) &&
                   IsActiveItem(ItemType.Setting);
        }

        private void SetupActiveItems()
        {
            _activeItems.Clear();

            for (int i=0; i<_itemRoot.childCount; i++)
            {
                var item = _itemRoot.GetChild(i).GetComponent<XMenuTopItem>();
                if (item.gameObject.activeSelf)
                    _activeItems.Add(item);
            }
        }

        public static void CloseForce()
        {
            var xmenu = UIManager.Instance.GetExistWindow<XMenuTop>();

            if (xmenu != null && xmenu._isActived)
            {
                AudioManager.Instance.PlaySe(EVENTS.UI_TOP_XCLOSE, null);
                UIManager.Instance.CloseXMenu(onClosed_ => xmenu.Close(onClosed_, true, WINDOWID_FIELD));
            }
        }

        public void Close(UnityAction<UIWindow> onClosed_, bool isRemoveKeyguide, UIWindowID nextWindowId)
        {
            Sequencer.Start(OpClose(onClosed_, isRemoveKeyguide, nextWindowId));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, bool isRemoveKeyguide, UIWindowID nextWindowId)
        {
            StopTownmapGuideMessageWindow();
            CloseMessageWindow();

            _isActived = false;
            _input.inputEnabled = false;

            for (int i=0; i<_activeItems.Count; i++)
                _activeItems[i].PlayAnimation(XMenuTopItem.animStateOut);

            yield return OpPlayCloseWindowAnimationAndWaiting(nextWindowId);

            Sequencer.update -= OnUpdate;

            var topMenu = PlayerWork.topMenu;
            for (int i=0; i<_activeItems.Count; i++)
            {
                var item = _activeItems[i];

                if (IsSwap())
                    topMenu.items[(int)item.itemType].index = i;

                topMenu.items[(int)item.itemType].isNew = item.isNew;
            }

            topMenu.selectType = (TOPMENUITEMTYPE)_activeItems[_selectIndex].itemType;
            PlayerWork.topMenu = topMenu;

            if (isRemoveKeyguide)
                UIManager.Instance.ReleaseKeyguide();

            UIManager.RestoreDuplicateImageMaterials(_duplicate);
            UIManager.Instance._ReleaseUIWindow(this);

            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            if (!_isActived)
                return;

            if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this)
                return;

            if (_fromSwapItem == null && _input.IsPushButton(UIManager.ButtonB | UIManager.ButtonX))
            {
                AudioManager.Instance.PlaySe(EVENTS.UI_TOP_XCLOSE, null);
                UIManager.Instance.CloseXMenu(onClosed_ => Close(onClosed_, true, WINDOWID_FIELD));
            }

            if (_fromSwapItem == null && _input.IsPushButton(GameController.ButtonMask.L | GameController.ButtonMask.R))
            {
                if (_param.menuType == Param.MenuType.SafariGame)
                {
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
                    _input.inputEnabled = false;

                    StopTownmapGuideMessageWindow();

                    OpenMessageWindow(new MsgWindowParam()
                    {
                        useMsgFile = MessageManager.Instance.GetMsgFile("dp_scenario2"),
                        labelName = "130-msg_safari_retire_01",
                        inputEnabled = true,
                        inputCloseEnabled = false,
                        onFinishedShowAllMessage = () =>
                        {
                            CreateContextMenuYesNo(contextMenuItem =>
                            {
                                if (contextMenuItem.param.menuId != ContextMenuID.XMENU_YES)
                                {
                                    SetupTownmapGuideMessageWindow();
                                    _input.inputEnabled = true;
                                }
                                else
                                {
                                    _param.safari.onRetire?.Invoke();
                                }

                                return true;
                            }, null);
                        },
                    });
                }
                else
                {
                    switch (_param.menuType)
                    {
                        case Param.MenuType.Fureai:
                        case Param.MenuType.SafariGame:
                        case Param.MenuType.Mysterious:
                            AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_BEEP, null);
                            break;

                        case Param.MenuType.Normal:
                        case Param.MenuType.UnderGround:
                        default:
                            AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
                            _input.inputEnabled = false;
                            OpenItem(ItemType.Report);
                            break;
                    }
                }
            }

            if (_fromSwapItem == null && _input.IsPushButton(UIManager.ButtonPlusMinus))
            {
                var mapIndex = _activeItems.FindIndex(x => x.itemType == ItemType.Map);
                if (mapIndex > -1)
                {
                    var item = _activeItems[mapIndex];
                    _input.inputEnabled = false;
                    SetSelectIndex(mapIndex);
                    PlaySeDecide(item.itemType);
                    item.Decide(decideItem => OpenItem(item.itemType));
                }
            }

            if (_fromSwapItem == null && _input.IsPushButton(UIManager.ButtonA))
            {
                var selectItem = _activeItems[_selectIndex];
                PlaySeDecide(selectItem.itemType);

                if (!IsLimitingItem(selectItem.itemType))
                {
                    _input.inputEnabled = false;
                    selectItem.Decide(decideItem => OpenItem(selectItem.itemType));
                }
            }

            UpdateSelectItem(deltaTime);
            UpdateSwap(deltaTime);
        }

        private bool IsLimitingItem(ItemType itemType)
        {
            switch (_param.menuType)
            {
                case Param.MenuType.Fureai:
                    return itemType == ItemType.Bag ||
                           itemType == ItemType.Gift ||
                           itemType == ItemType.Report;

                case Param.MenuType.SafariGame:
                    return itemType == ItemType.Gift ||
                           itemType == ItemType.Report;

                case Param.MenuType.UnderGround:
                    return itemType == ItemType.Gift;

                case Param.MenuType.Mysterious:
                    return itemType == ItemType.Seal ||
                           itemType == ItemType.Gift ||
                           itemType == ItemType.Report;

                default:
                    return false;
            }
        }

        private void PlaySeDecide(ItemType itemType)
        {
            AudioManager.Instance.PlaySe(IsLimitingItem(itemType) ? EVENTS.UI_COMMON_BEEP : EVENTS.UI_COMMON_DECIDE, null);
        }

        private void OpenItem(ItemType itemType)
        {
            Close(__ =>
            {
                switch (itemType)
                {
                    case ItemType.Zukan:
                        {
                            var window = UIManager.Instance.CreateUIWindow<UIZukan>(UIWindowID.ZUKAN);
                            window.onClosed = OnItemClosed;
                            window.Open(instance.windowId);
                        }
                        break;

                    case ItemType.Pokemon:
                        {
                            var window = UIManager.Instance.CreateUIWindow<PokemonWindow>(UIWindowID.POKEMON);
                            window.onClosed = OnItemClosed;
                            window.Open(new PokemonWindow.Param() { selectIndex = 0 }, instance.windowId);
                        }
                        break;

                    case ItemType.Bag:
                        {
                            var window = UIManager.Instance.CreateUIWindow<UIBag>(UIWindowID.BAG);
                            window.onClosed = OnItemClosed;
                            window.Open(pokemonParam: null, prevWindowId: instance.windowId);
                        }
                        break;

                    case ItemType.Card:
                        {
                            var window = UIManager.Instance.CreateUIWindow<UICard>(UIWindowID.CARD);
                            window.onClosed = OnItemClosed;
                            window.Open(instance.windowId);
                        }
                        break;

                    case ItemType.Map:
                        {
                            var window = UIManager.Instance.CreateUIWindow<TownmapWindow>(UIWindowID.MAP);
                            window.onClosed = OnItemClosed;
                            window.Open(new TownmapWindow.Param() { type = Townmap.TownmapType.Default }, instance.windowId);
                        }
                        break;

                    case ItemType.Seal:
                        {
                            var window = UIManager.Instance.CreateUIWindow<UISeal>(UIWindowID.SEAL);
                            window.onClosed = OnItemClosed;
                            window.Open(prevWindowId: instance.windowId);
                        }
                        break;

                    case ItemType.Setting:
                        {
                            var window = UIManager.Instance.CreateUIWindow<SettingWindow>(UIWindowID.SETTING);
                            window.onClosed = OnItemClosed;
                            window.Open(instance.windowId);
                        }
                        break;

                    case ItemType.Gift:
                        {
                            var window = UIManager.Instance.CreateUIWindow<GiftWindow>(UIWindowID.GIFT);
                            window.onClosed = OnItemClosed;
                            window.Open(instance.windowId);
                        }
                        break;

                    case ItemType.Report:
                        {
                            var window = UIManager.Instance.CreateUIWindow<ReportWindow>(UIWindowID.REPORT);
                            window.onClosed = OnItemClosed;
                            window.Open(instance.windowId);
                        }
                        break;
                }
            }, false, GetWindowId(itemType));
        }

        private UIWindowID GetWindowId(ItemType itemType)
        {
            return _windowIds[(int)itemType];
        }

        private void OnItemClosed(UIWindow window)
        {
            var xmenu = UIManager.Instance.CreateUIWindow<XMenuTop>(UIWindowID.XMENU);
            xmenu.onClosed = _saveOnClosed;
            xmenu.Open(_param, window.instance.windowId);
            xmenu._prevWindowId = _prevWindowId;
        }

        private void UpdateSwap(float deltaTime)
        {
            if (!IsSwap())
                return;

            if (_fromSwapItem == null && _input.IsPushButton(UIManager.ButtonY))
            {
                _gridLayoutGroup.enabled = false;
                _fromSwapItem = _activeItems[_selectIndex];

                _fromSwapItem.EnableSwapMode(true);
                _fromSwapItem.Select(false);
                _fromSwapItem.ShowName(false);

                _fromSwapPisiton = _fromSwapItem.transform.localPosition;
                _fromSwapSiblingIndex = _fromSwapItem.transform.GetSiblingIndex();
                _fromSwapItem.transform.SetSiblingIndex(_itemRoot.childCount);

                AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CHANGE, null);
            }
            else if (_fromSwapItem != null && _input.IsPushButton(UIManager.ButtonA | UIManager.ButtonY))
            {
                var toSwapItem = _activeItems[_selectIndex];
                var toSwapSiblingIndex = toSwapItem.transform.GetSiblingIndex();

                _fromSwapItem.transform.localPosition = toSwapItem.transform.localPosition;
                _fromSwapItem.EnableSwapMode(false);
                _fromSwapItem.ShowName(true);
                _fromSwapItem.transform.SetSiblingIndex(toSwapSiblingIndex);

                toSwapItem.transform.localPosition = _fromSwapPisiton;
                toSwapItem.transform.SetSiblingIndex(_fromSwapSiblingIndex);

                toSwapItem.Select(false);
                _fromSwapItem = null;

                SetupActiveItems();

                _gridLayoutGroup­.enabled = true;

                AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
                SetSelectIndex(_selectIndex, true);
            }
            else if (_fromSwapItem != null && _input.IsPushButton(UIManager.ButtonB))
            {
                _fromSwapItem.transform.localPosition = _fromSwapPisiton;

                _fromSwapItem.EnableSwapMode(false);
                _fromSwapItem.Select(false);
                _fromSwapItem.ShowName(true);

                _fromSwapItem.transform.SetSiblingIndex(_fromSwapSiblingIndex);
                _fromSwapItem = null;

                _activeItems[_selectIndex].Select(true);
                _gridLayoutGroup.enabled = true;

                AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CANCEL, null);
            }

            if (_fromSwapItem != null)
                _fromSwapItem.transform.localPosition = _fromSwapItem != _activeItems[_selectIndex] ?
                                                        _activeItems[_selectIndex].transform.localPosition :
                                                        _fromSwapPisiton;
        }

        // TODO: Review the math on horizontal movement
        private void UpdateSelectItem(float deltaTime)
        {
            if (_input.IsPushButton(UIManager.StickLRight | UIManager.StickLLeft) &&
                _input.IsPushButton(UIManager.StickLDown | UIManager.StickLUp))
                return;

            if (_input.IsPushButton(UIManager.StickLRight))
            {
                var firstIndexOfRow = _selectIndex / _upperColumnMax * _upperColumnMax;

                var size = _activeItems.Count;
                if (_selectIndex < _upperColumnMax) // Not 100% sure why this is done, this accomplishes nothing
                    size = Mathf.Min(size, _upperColumnMax);

                var amountInRow = size - firstIndexOfRow;
                var indexInRow = _selectIndex % _upperColumnMax;
                var newIndex = (indexInRow + 1) % amountInRow;

                if (SetSelectIndex(firstIndexOfRow + newIndex))
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
            }
            else if (_input.IsRepeatButton(UIManager.StickLRight))
            {
                var size = _activeItems.Count;
                if (_selectIndex < _upperColumnMax) // Not 100% sure why this is done, this accomplishes nothing
                    size = Mathf.Min(size, _upperColumnMax);

                var newIndex = Mathf.Min(_selectIndex + 1, size - 1);

                if (SetSelectIndex(newIndex))
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
            }
            else if (_input.IsPushButton(UIManager.StickLLeft))
            {
                var firstIndexOfRow = _selectIndex / _upperColumnMax * _upperColumnMax;

                var size = _activeItems.Count;
                if (_selectIndex < _upperColumnMax) // Not 100% sure why this is done, this accomplishes nothing
                    size = Mathf.Min(size, _upperColumnMax);

                var amountInRow = size - firstIndexOfRow;
                var indexInRow = _selectIndex % _upperColumnMax;
                var newIndex = indexInRow == 0 ? (amountInRow - 1) : ((indexInRow - 1) % amountInRow); // Handle going to -1 properly. NOTE: This is freestyle code a little bit because the compiler made this overly complex

                if (SetSelectIndex(firstIndexOfRow + newIndex))
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
            }
            else if (_input.IsRepeatButton(UIManager.StickLLeft))
            {
                var firstIndexOfRow = _selectIndex / _upperColumnMax * _upperColumnMax;
                var newIndex = Mathf.Max(_selectIndex - 1, firstIndexOfRow);

                if (SetSelectIndex(newIndex))
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
            }

            if (_input.IsPushButton(UIManager.StickLDown))
            {
                if (_selectIndex + _upperColumnMax < _activeItems.Count)
                {
                    if (SetSelectIndex(_selectIndex + _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
                else if (_selectIndex - _upperColumnMax > -1)
                {
                    if (SetSelectIndex(_selectIndex - _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
                else
                {
                    if (SetSelectIndex(_selectIndex))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
            else if (_input.IsRepeatButton(UIManager.StickLDown))
            {
                if (_selectIndex + _upperColumnMax < _activeItems.Count)
                {
                    if (SetSelectIndex(_selectIndex + _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
            else if (_input.IsPushButton(UIManager.StickLUp))
            {
                if (_selectIndex - _upperColumnMax > -1)
                {
                    if (SetSelectIndex(_selectIndex - _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
                else if (_selectIndex + _upperColumnMax < _activeItems.Count)
                {
                    if (SetSelectIndex(_selectIndex + _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
                else
                {
                    if (SetSelectIndex(_selectIndex))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
            else if (_input.IsRepeatButton(UIManager.StickLUp))
            {
                if (_selectIndex - _upperColumnMax > -1)
                {
                    if (SetSelectIndex(_selectIndex - _upperColumnMax))
                        AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
        }

        private bool SetSelectIndex(int selectIndex, bool isInitialize = false)
        {
            if (isInitialize)
            {
                _selectIndex = selectIndex;
            }
            else
            {
                var prevIndex = _selectIndex;
                if (prevIndex == selectIndex)
                    return false;

                _selectIndex = selectIndex;

                if (prevIndex > -1)
                    _activeItems[prevIndex].Select(false);
            }

            if (_fromSwapItem != null && _fromSwapItem == _activeItems[_selectIndex])
                return true;

            _activeItems[_selectIndex].Select(true);
            return true;
        }

        protected override void OpenMessageWindow(MsgWindowParam messageParam)
        {
            base.OpenMessageWindow(messageParam);

            if (_messageWindowRoot != null)
                _messageWindow.transform.position = _messageWindowRoot.position;

            _gotoTownMapRoot.GetComponent<Canvas>().sortingOrder = _messageWindow.SortingOrder + 1;
        }

        protected override ContextMenuWindow CreateContextMenuYesNo(Func<ContextMenuItem, bool> onClicked, [Optional] ContextMenuWindow.Param contextMenuParam)
        {
            var contextMenu = base.CreateContextMenuYesNo(onClicked, contextMenuParam);

            if (_messageWindow != null)
                contextMenu.canvas.sortingOrder = _messageWindow.SortingOrder + 2;

            return contextMenu;
        }

        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.XMENU_YES });
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.XMENU_NO });
        }

        public enum ItemType : int
        {
            None = -1,
            Zukan = 0,
            Pokemon = 1,
            Bag = 2,
            Card = 3,
            Map = 4,
            Seal = 5,
            Setting = 6,
            Gift = 7,
            Report = 8,
        }

        public class Param
        {
	        public MenuType menuType;
            public Safari safari;

            [Flags]
            public enum MenuType : int
            {
                Normal = 0,
                Fureai = 1,
                SafariGame = 2,
                UnderGround = 3,
                Mysterious = 4,
            }

            public class Safari
            {
                public int ballNum = 12;
                public UnityAction onRetire;
            }
        } 
    }
}