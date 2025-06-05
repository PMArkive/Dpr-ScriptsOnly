using Audio;
using DG.Tweening;
using Dpr.Message;
using Dpr.MsgWindow;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class SelectLanguageWindow : SelectOpeningBase
    {
        [SerializeField]
        private RectTransform _content;
        [SerializeField]
        private Cursor _cursor;
        private const int _columnNum = 2;
        private const int _rowNum = 5;
        private List<SelectLanguageItem> _items = new List<SelectLanguageItem>();
        private int _selectIndex;
        private int _reloadAllMsbtState = -1;
        public UnityAction onReloadLanguage;

        public int selectIndex { get => _selectIndex; }

        public override void OnCreate()
        {
            base.OnCreate();
            _animator = GetComponentInChildren<Animator>(true);
        }

        public void Open(UIWindowID prevWindowId)
        {
            Sequencer.Start(OpOpen(prevWindowId));
        }

        public IEnumerator OpOpen(UIWindowID prevWindowId)
        {
            OnOpen(prevWindowId);
            SetupBgs();
            _items.Clear();

            for (int i=0; i<_content.childCount; i++)
                _items.Add(_content.GetChild(i).GetComponent<SelectLanguageItem>());

            bool bIsLoadedLang = false;
            var langId = UIManager.GetMessageLangIdFromIetfCode(UIManager.GetCurrentIetfCode());
            SetLanguage(langId, false, () => bIsLoadedLang = true);

            while (!bIsLoadedLang)
                yield return null;

            var item = _items.FirstOrDefault(x => x.langId == langId);
            var siblingIndex = item.transform.GetSiblingIndex();
            _items.RemoveAt(siblingIndex);

            if (item.langId == MessageEnumData.MsgLangId.JPN)
            {
                var secondItem = _items[siblingIndex];
                _items.RemoveAt(siblingIndex);
                secondItem.transform.SetSiblingIndex(0);
                _items.Insert(0, secondItem);
            }

            item.transform.SetSiblingIndex(0);
            _items.Insert(0, item);

            _cursor.SetActive(true);
            SetSelectIndex(0, true);

            yield return OpPlayOpenWindowAnimation(prevWindowId, null);

            Sequencer.update += OnUpdate;
            _input.inputEnabled = true;
            OpenSelectLangMessageWindow();
        }

        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            Sequencer.Start(OpClose(onClosed_, nextWindowId));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            CloseMessageWindow();
            Sequencer.update -= OnUpdate;

            while (_reloadAllMsbtState == 0)
                yield return null;

            yield return OpPlayCloseWindowAnimationAndWaiting(nextWindowId);
        }

        public void Destroy(UnityAction<UIWindow> onClosed_)
        {
            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this)
                return;

            if (IsActiveMessageWindow())
                return;

            if (IsPushButton(UIManager.ButtonA))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
                _cursor.Play(Cursor.animStateDecide);
                _input.inputEnabled = false;

                if (_items[_selectIndex].langId == MessageEnumData.MsgLangId.JPN)
                {
                    SetLanguage(_items[_selectIndex].langId, _items[_selectIndex].useKanji, () =>
                    {
                        var msgWindowParam = new MsgWindowParam
                        {
                            useMsgFile = MessageManager.Instance.GetMsgFile("ss_language_select"),
                            labelName = "SS_language_select_003",
                            inputEnabled = true,
                            inputCloseEnabled = true,
                            onFinishedCloseWindow = () => OpenConfirmMessageWindow(),
                        };
                        OpenMessageWindow(msgWindowParam);
                    });
                }
                else
                {
                    SetLanguage(_items[_selectIndex].langId, _items[_selectIndex].useKanji, () => OpenConfirmMessageWindow());
                }
            }

            UpdateSelect(deltaTime);
        }

        private void SetLanguage(MessageEnumData.MsgLangId lang, bool isKanji, UnityAction callback)
        {
            PlayerWork.msgLangID = lang;
            PlayerWork.isKanji = isKanji;
            GameManager.ReloadLanguege(0, (isReload) => callback?.Invoke());
        }

        private void OpenConfirmMessageWindow()
        {
            var msgWindowParam = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile("ss_language_select"),
                labelName = "SS_language_select_004",
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () =>
                {
                    CreateContextMenuYesNo((contextMenuItem) =>
                    {
                        CloseMessageWindow();

                        if (contextMenuItem.param.menuId == ContextMenuID.SELECTLANGUAGE_YES)
                        {
                            DOVirtual.DelayedCall(0.3f, () => Close(onClosed, _prevWindowId));
                            DOVirtual.DelayedCall(0.6f, () =>
                            {
                                var unloadLangId = UIManager.GetMessageLangIdFromIetfCode(UIManager.GetCurrentIetfCode());
                                _reloadAllMsbtState = 0;
                                GameManager.AfterInitialize(GameManager.AfterInitType.LanguageSelect, unloadLangId, (state) =>
                                {
                                    if (state != GameManager.AfterLoadState.Ui)
                                        return;

                                    _reloadAllMsbtState = 1;
                                    onReloadLanguage?.Invoke();
                                    UIManager.Instance._ReleaseUIWindow(this);
                                    onClosed?.Invoke(this);
                                });
                            });
                        }
                        else
                        {
                            _input.inputEnabled = true;
                            OpenSelectLangMessageWindow();
                        }

                        return true;
                    }, 0);
                },
            };

            OpenMessageWindow(msgWindowParam);
        }

        private void OpenSelectLangMessageWindow()
        {
            var msgWindowParam = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile("ss_language_select"),
                labelName = "SS_language_select_000",
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () => { /* Empty */ },
            };
            OpenMessageWindow(msgWindowParam);
        }

        private void UpdateSelect(float deltaTime)
        {
            if (IsPushButton(UIManager.StickLRight | UIManager.StickLLeft) && IsPushButton(UIManager.StickLDown | UIManager.StickLUp))
                return;

            int x = _selectIndex / _rowNum;
            int y = _selectIndex % _rowNum;

            if (IsPushButton(UIManager.StickLRight))
            {
                x = UIManager.Repeat(x + 1, 0, _columnNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLRight))
            {
                x = Mathf.Min(x + 1, _columnNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsPushButton(UIManager.StickLLeft))
            {
                x = UIManager.Repeat(x - 1, 0, _columnNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLLeft))
            {
                x = Mathf.Max(x - 1, 0);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }

            if (IsPushButton(UIManager.StickLDown))
            {
                y = UIManager.Repeat(y + 1, 0, _rowNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLDown))
            {
                y = Mathf.Min(y + 1, _rowNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsPushButton(UIManager.StickLUp))
            {
                y = UIManager.Repeat(y - 1, 0, _rowNum - 1);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLUp))
            {
                y = Mathf.Max(y - 1, 0);
                if (SetSelectIndex(x * _rowNum + y))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
        }

        private bool SetSelectIndex(int index, bool isInitialized = false)
        {
            if (!isInitialized)
            {
                int beforeIndex = _selectIndex;
                if (beforeIndex == index)
                    return false;

                _selectIndex = index;
                _items[beforeIndex].Select(false);
            }
            else
            {
                _selectIndex = index;
            }

            _items[index].Select(true);
            _cursor.transform.SetParent(_items[index].transform, false);
            return true;
        }

        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            contextMenuItemParams.Add(new ContextMenuItem.Param { menuId = ContextMenuID.SELECTLANGUAGE_YES });
            contextMenuItemParams.Add(new ContextMenuItem.Param { menuId = ContextMenuID.SELECTLANGUAGE_NO });
        }
    }
}