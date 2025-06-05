using Audio;
using Dpr.Message;
using Dpr.MsgWindow;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class SelectPlayerVisualWindow : SelectOpeningBase
    {
        [SerializeField]
        private RectTransform _content;
        [SerializeField]
        private Cursor _cursor;
        private const int _columnNum = 4;
        private const int _rowNum = 2;
        private List<SelectPlayerVisualItem> _items = new List<SelectPlayerVisualItem>();
        private int _selectIndex;

        public SelectPlayerVisualItem selectItem { get => _items[_selectIndex]; }

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
                _items.Add(_content.GetChild(i).GetComponent<SelectPlayerVisualItem>());

            _cursor.SetActive(true);

            while (MessageManager.Instance.IsLoading)
                yield return null;

            SetSelectIndex(0, true);
            yield return OpPlayOpenWindowAnimation(prevWindowId, null);

            Sequencer.update += OnUpdate;
            _input.inputEnabled = true;

            OpenMessageWindow(new MsgWindowParam()
            {
                useMsgFile = MessageManager.Instance.GetMsgFile("ss_player_select"),
                labelName = "SS_player_select_000",
                inputEnabled = true,
                inputCloseEnabled = false,
                onFinishedShowAllMessage = () => { /* Empty */ },
            });
        }

        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            Sequencer.Start(OpClose(onClosed_, nextWindowId));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            CloseMessageWindow();
            Sequencer.update -= OnUpdate;

            yield return OpPlayCloseWindowAnimationAndWaiting(nextWindowId);

            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this || IsActiveMessageWindow())
                return;

            if (IsPushButton(UIManager.ButtonA))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
                deltaTime = 0.0f;
                _cursor.Play(Cursor.animStateDecide);
                _input.inputEnabled = false;
                Close(onClosed, _prevWindowId);
            }

            UpdateSelect(deltaTime);
        }

        private void UpdateSelect(float deltaTime)
        {
            if (IsPushButton(UIManager.StickLRight | UIManager.StickLLeft) && IsPushButton(UIManager.StickLDown | UIManager.StickLUp))
                return;

            int x = _selectIndex % _columnNum;
            int y = _selectIndex / _columnNum;

            if (IsPushButton(UIManager.StickLRight))
            {
                x = UIManager.Repeat(x + 1, 0, _columnNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLRight))
            {
                x = Mathf.Min(x + 1, _columnNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsPushButton(UIManager.StickLLeft))
            {
                x = UIManager.Repeat(x - 1, 0, _columnNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLLeft))
            {
                x = Mathf.Max(x - 1, 0);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }

            if (IsPushButton(UIManager.StickLDown))
            {
                y = UIManager.Repeat(y + 1, 0, _rowNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLDown))
            {
                y = Mathf.Min(y + 1, _rowNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsPushButton(UIManager.StickLUp))
            {
                y = UIManager.Repeat(y - 1, 0, _rowNum - 1);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
            else if (IsRepeatButton(UIManager.StickLUp))
            {
                y = Mathf.Max(y - 1, 0);
                if (SetSelectIndex(x + y * _columnNum))
                    AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_SELECT, null);
            }
        }

        private bool SetSelectIndex(int index, bool isInitialized = false)
        {
            if (!isInitialized)
            {
                if (_selectIndex == index)
                    return false;

                var beforeSelectIndex = _selectIndex;
                _selectIndex = index;
                _items[beforeSelectIndex].Select(false);
            }
            else
            {
                _selectIndex = index;
            }

            selectItem.Select(true);
            _cursor.transform.SetParent(selectItem.transform, false);

            return true;
        }

        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.SELECTLANGUAGE_YES });
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.SELECTLANGUAGE_NO });
        }
    }
}