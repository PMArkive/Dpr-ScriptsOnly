using DPData;
using Dpr.Message;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class MsgWindow : MonoBehaviour
    {
        [SerializeField]
        private bool autoResize = true;
        [SerializeField]
        private MsgWindowConfig config;
        private WindowMessage windowMessage;
        private WindowUIContents uiContents;
        private WindowAnimator windowAnimator = new WindowAnimator();
        private MsgWindowDataModel dataModel = new MsgWindowDataModel();
        private MsgWindowSoundPlayer soundPlayer = new MsgWindowSoundPlayer();
        private MsgWindowInput wndInput = new MsgWindowInput();
        private RectTransform contextMenuRect;
        private WaitTimer waitAutoTimer = new WaitTimer();
        private bool bInitialize;
        private bool bIsAutoMessage;

        private void Start()
        {
            SetActive(false);
        }

        public void Initialize()
        {
            if (bInitialize)
                return;

            ConfigWork.onValueChanged -= OnChangedConfig;
            ConfigWork.onValueChanged += OnChangedConfig;

            SetComponents();
            dataModel.Initialize(config.msgSpeed, config.waitAfterFinishMsgFrame, MsgWindowManager.Instance.DataContainer);
            windowAnimator.Initialize(config.wndAnimType, this.FindDeep("Frame", true), this.FindDeep("Content", true));
            windowMessage.Initialize(config, OnFoundCallbackOneTag);
            uiContents.Initialize(dataModel, config, MsgWindowManager.Instance.DataContainer);

            Sequencer.Start(IE_Initialize());
            soundPlayer.Setup(MsgWindowManager.Instance.DataContainer);

            bIsAutoMessage = false;
            waitAutoTimer.SetLimitTime(0.0f);
            bInitialize = true;
        }

        private IEnumerator IE_Initialize()
        {
            var dataContainer = MsgWindowManager.Instance.DataContainer;

            while (dataContainer.Loading)
                yield return null;

            uiContents.SetupAssetBundleResource(dataContainer);
            MessageHelper.EmitLog("MsgWindow Initialized", LogType.Log);
        }

        private void SetComponents()
        {
            uiContents = GetComponent<WindowUIContents>();
            contextMenuRect = this.FindDeep("ContextMenuAnchor", true).GetComponent<RectTransform>();
            windowMessage = this.FindDeep("WindowMessage", true).GetComponent<WindowMessage>();
        }

        public void OnFinalize()
        {
            ConfigWork.onValueChanged -= OnChangedConfig;
            if (windowMessage != null)
                windowMessage.OnFinalize();

            if (uiContents != null)
                uiContents.OnFinalize();

            dataModel.OnFinalize();
        }

        public bool IsOpen { get => dataModel.IsOpen; }
        public MsgWindowDataModel.MsgWindowState MsgState { get => dataModel.MsgState; }

        public Vector2 CalcContextMenuPos()
        {
            return contextMenuRect.position;
        }

        public bool IsEnabledInput { get => dataModel.InputEnabled; }
        public bool IsEnabledCloseSelf { get => dataModel.CanInputClose; }
        public int SortingOrder { get => uiContents.SortingOrder; }
        public bool IsNetwork { get => dataModel.IsNetwork; }
        public bool IsAuto { get => bIsAutoMessage; }

        public void SetInputEnable(bool enabled)
        {
            dataModel.SetInputEnabled(enabled);
            if (enabled)
            {
                if (dataModel.MsgState == MsgWindowDataModel.MsgWindowState.Keywait || dataModel.MsgState == MsgWindowDataModel.MsgWindowState.FinishedShowMessage)
                    uiContents.ShowKeywaitIcon();
            }
            else
            {
                uiContents.HideKeywaitIcon();
            }
        }

        private void ChangeWndType(WINTYPE wndType)
        {
            uiContents.ChangeWndType(wndType);
        }

        private void ChangeMsgSpeed(MSGSPEED msgSpeed)
        {
            dataModel.ChangeMsgSpeed(msgSpeed);
            windowMessage.SetPlayMsgTime(dataModel.ShowOneFontTimeSec);
        }

        public void HideKeywaitIcon()
        {
            uiContents.HideKeywaitIcon();
        }

        public void OpenWindow(MsgWindowParam msgWindowParam)
        {
            if (CanOpenMsgWindow(msgWindowParam))
            {
                MessageHelper.EmitLog("OpenWindow", LogType.Log);

                NormalMsgDataSetting(msgWindowParam);
                SetMsgWindowParam();
                SetupWindowLayout();
                SetMessageLineData();
                DoAutoResize();
                NormalLayoutSetting();
                StartOpenAnimation();
            }
            else
            {
                msgWindowParam.onFinishedShowAllMessage?.Invoke();
            }
        }

        private void NormalMsgDataSetting(MsgWindowParam msgWindowParam)
        {
            dataModel.SetMsgWindowParam(msgWindowParam);
            dataModel.FormatTextData();
        }

        private void NormalLayoutSetting()
        {
            if (!dataModel.IsNetwork)
                windowMessage.ResetTextColor();
            else
                windowMessage.SetTextColor(MessageFontDataConstants.NETWORK_TEXT_COLOR);

            uiContents.ResetDefaultWndFrame();
        }

        public void ReplaceMessage(MsgWindowParam msgWindowParam)
        {
            MessageHelper.EmitLog("ReplaceMessage", LogType.Log);

            NormalMsgDataSetting(msgWindowParam);
            SetMsgWindowParam();
            SetupWindowLayout();
            SetMessageLineData();
            DoAutoResize();
            NormalLayoutSetting();

            if (msgWindowParam.IsPlayTextFeedSe())
                soundPlayer.PlayDecideSE();

            dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.PlayingMessage);
            windowMessage.RestartMessage();

            if (dataModel.HasSpeakerName())
                uiContents.ShowSpeakerName(dataModel.SpeakerName);
        }

        public void OpenBoardWindow(MsgWindowParam msgWindowParam, int roadsignPattern)
        {
            if (!CanOpenMsgWindow(msgWindowParam))
            {
                msgWindowParam.onFinishedShowAllMessage?.Invoke();
            }
            else
            {
                MessageHelper.EmitLog(string.Format("OpenBoardWindow : roadsignPattern [{0}]", roadsignPattern), LogType.Log);

                BoardMsgDataSetting(msgWindowParam);
                SetMsgWindowParam();
                SetupWindowLayout();
                SetMessageLineData();
                DoAutoResize();
                BoardLayoutSetting(roadsignPattern);
                StartOpenAnimation();
            }
        }

        private void BoardMsgDataSetting(MsgWindowParam msgWindowParam)
        {
            dataModel.SetBoardMsgWindowParam(msgWindowParam);
            dataModel.FormatTextData();
            uiContents.SetBoardWndFrame(msgWindowParam.frameTypeIndex);
        }

        private void BoardLayoutSetting(int roadsignPattern)
        {
            dataModel.ClearSpeakerName();
            windowMessage.SetTextColor(dataModel.FontColor);

            if (!dataModel.CheckShowRoadsignByPattern(roadsignPattern))
                return;

            uiContents.SetWindowWidth(dataModel.FrameWidth + config.windowWidthOffset + config.offsetMessagePosX);
            uiContents.ShowRoadsign(dataModel.GetRoadsignViewDataByPattern(roadsignPattern), config.offsetMessagePosX);
        }

        public void OpenItemGetWindow(MsgWindowParam msgWindowParam)
        {
            if (!CanOpenMsgWindow(msgWindowParam))
            {
                msgWindowParam.onFinishedShowAllMessage?.Invoke();
            }
            else
            {
                MessageHelper.EmitLog("OpenItemGetWindow", LogType.Log);

                ItemGetMsgDataSetting(msgWindowParam);
                SetMsgWindowParam();
                SetupWindowLayout();
                SetMessageLineData();
                DoAutoResize();
                ItemGetWindowLayoutSetting();
                StartOpenAnimation();
            }
        }

        private void ItemGetMsgDataSetting(MsgWindowParam msgWindowParam)
        {
            dataModel.SetMsgWindowParam(msgWindowParam);
            dataModel.FormatItemGetTextData();
        }

        private void ItemGetWindowLayoutSetting()
        {
            windowMessage.ResetTextColor();
            dataModel.ClearSpeakerName();
            uiContents.ResetDefaultWndFrame();
        }

        public void OpenBtlMsgWindow(MsgWindowParam btlMsgWindowParam)
        {
            if (!CanOpenMsgWindow(btlMsgWindowParam))
            {
                btlMsgWindowParam.onFinishedShowAllMessage?.Invoke();
            }
            else
            {
                MessageHelper.EmitLog("OpenBtlMsgWindow", LogType.Log);

                dataModel.SetBtlMsgWindowParam(btlMsgWindowParam);
                SetMsgWindowParam();
                SetupWindowLayout();
                SetMessageLineData();
                DoAutoResize();
                BtlMsgLayoutSetting();
                StartOpenAnimation();
            }
        }

        private void BtlMsgLayoutSetting()
        {
            windowMessage.ResetTextColor();
            uiContents.ResetDefaultWndFrame();
        }

        public void ReplaceBtlMessage(MsgWindowParam btlMsgWindowParam)
        {
            dataModel.SetBtlMsgWindowParam(btlMsgWindowParam);
            SetMsgWindowParam();
            SetupWindowLayout();
            SetMessageLineData();
            DoAutoResize();
            BtlMsgLayoutSetting();

            if (btlMsgWindowParam.IsPlayTextFeedSe())
                soundPlayer.PlayDecideSE();

            dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.PlayingMessage);
            windowMessage.RestartMessage();

            if (dataModel.HasSpeakerName())
                uiContents.ShowSpeakerName(dataModel.SpeakerName);
        }

        private bool CanOpenMsgWindow(MsgWindowParam msgWindowParam)
        {
            if (msgWindowParam == null)
            {
                MessageHelper.EmitLog("textData is Null!!!", LogType.Error);
                return false;
            }

            if (!bInitialize)
            {
                MessageHelper.EmitLog("Not Call Initialize Method!!!", LogType.Error);
                return false;
            } 

            return true;
        }

        private void SetMsgWindowParam()
        {
            dataModel.ResetParam();
            wndInput.SubscribeToGameController();
            windowMessage.SetPlayMsgTime(dataModel.ShowOneFontTimeSec);
            soundPlayer.Reset();
        }

        private void SetupWindowLayout()
        {
            uiContents.SetupLayout(dataModel.WndAnchorPosition, dataModel.SortingOrder, dataModel.IsNetwork);

            if (autoResize)
            {
                windowMessage.SetTextParam(dataModel.FontSize, dataModel.TextWidth);
                uiContents.SetWindowWidth(config.windowWidthOffset + dataModel.FrameWidth);
            }

            if (dataModel.IsUnknownMessage)
            {
                dataModel.FontAsset = null;
                windowMessage.ChangeUnknownFont();
            }
            else
            {
                ChangeFontAsset();
            }

            if (dataModel.IsShowLoadingIcon)
                uiContents.ShowLoadingIcon();
            else
                uiContents.HideLoadingIcon();
        }

        private void ChangeFontAsset()
        {
            var newFontAsset = FontManager.Instance.GetFontAsset();
            if (dataModel.FontAsset == newFontAsset)
                return;

            dataModel.FontAsset = newFontAsset;
            windowMessage.SetUseFontAsset(newFontAsset);
            uiContents.ChangeFontAsset(newFontAsset);
        }

        private void SetMessageLineData()
        {
            if (!dataModel.HasBattleOnelineTag || !dataModel.MessageData.IsOneLineTagMessage())
            {
                if (dataModel == null)
                    return;

                windowMessage.SetUseMessageLineDataArray(dataModel.MessageData.GetLineMessageDataArray());
            }
            else
            {
                windowMessage.SetUseMessageLineDataArray(dataModel.MessageData.CreateOneLineMessageDataArray(dataModel.FontScale, dataModel.TextWidth));
            }
        }

        private void DoAutoResize()
        {
            if (!dataModel.IsUnknownMessage && autoResize)
                windowMessage.CheckTextResize(dataModel.MessageData, dataModel.FontScale, dataModel.TextWidth);
        }

        private void StartOpenAnimation()
        {
            windowAnimator.ResetAnim();
            SetActive(true);

            if (windowAnimator.IsAnimation)
            {
                windowAnimator.ChangeTweenAnimationEnd();
                MessageHelper.EmitLog("windowAnimator playing close animation", LogType.Log);
            }

            windowMessage.ResetMessage();
            dataModel.OnStartOpen();
            windowAnimator.OpenWindow();
        }

        public void DoOnCloseCallback()
        {
            dataModel.CallFinishedCallback();
        }

        public void CloseWindow()
        {
            if (!dataModel.IsOpen)
                return;

            if (windowAnimator.IsAnimation)
                windowAnimator.ChangeTweenAnimationEnd();

            DisableAutoMode();
            windowMessage.ResetMessage();
            wndInput.RemoveFromGameController();
            uiContents.HideKeywaitIcon();
            uiContents.HideLoadingIcon();
            uiContents.HideSpeakerName();
            dataModel.OnClose();
            windowAnimator.CloseWindow();
        }

        public void MoveNextPage()
        {
            if (dataModel.MsgState != MsgWindowDataModel.MsgWindowState.Keywait)
            {
                MessageHelper.EmitLog("MsgWindow State Not KeyWait : " + dataModel.MsgState, LogType.Warning);
                return;
            }

            DoNextPage();
        }

        public void OnUpdate(float deltaTime)
        {
            if (dataModel.MsgState != MsgWindowDataModel.MsgWindowState.Inactive)
                UpdateMsgWindow(deltaTime);
        }

        private void UpdateMsgWindow(float deltaTime)
        {
            switch (dataModel.MsgState)
            {
                case MsgWindowDataModel.MsgWindowState.PlayingOpen:
                    UpdateStatePlayingOpen(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.FinishedOpen:
                    UpdateStateFinishedOpen(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.PlayingMessage:
                    UpdateStatePlayingMessage(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.EnterKeywait:
                    UpdateStateEnterkeywait();
                    break;

                case MsgWindowDataModel.MsgWindowState.Keywait:
                    UpdateStateKeywait(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.WaitFinishMessage:
                    UpdateStateWaitFinishMessage(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.FinishedShowMessage:
                    UpdateStateFinishedMessage(deltaTime);
                    break;

                case MsgWindowDataModel.MsgWindowState.PlayingClose:
                    UpdateStatePlayingClose(deltaTime);
                    break;
            }
        }

        private void UpdateStatePlayingOpen(float deltaTime)
        {
            windowAnimator.OnUpdate(deltaTime);
            if (windowAnimator.CurrentState != WindowAnimator.AnimState.FinishedOpen)
                return;

            dataModel.OnFinishedOpen();

            if (dataModel.HasSpeakerName())
                uiContents.ShowSpeakerName(dataModel.SpeakerName);
            else
                uiContents.HideSpeakerName();

            windowMessage.StartPlayMessage();
            UpdateStatePlayingMessage(deltaTime);
        }

        private void UpdateStateFinishedOpen(float deltaTime)
        {
            dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.PlayingMessage);
            UpdateStatePlayingMessage(deltaTime);
        }

        private void UpdateStatePlayingMessage(float deltaTime)
        {
            if (soundPlayer.WaitFinishSE)
                return;

            CheckPlayMsgSpeedUp();

            windowMessage.UpdateMessage(deltaTime);

            switch (windowMessage.CurrentMsgState)
            {
                case WindowMessage.MsgState.KeyWait:
                    dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.EnterKeywait);
                    break;

                case WindowMessage.MsgState.End:
                    if (dataModel.IsShowLastKeywaitIcon && dataModel.InputEnabled)
                        uiContents.ShowKeywaitIcon();

                    if (bIsAutoMessage)
                    {
                        if (!UpdateAutoMessageWait(deltaTime))
                        {
                            uiContents.UpdateKeywaitIcon(deltaTime);
                            break;
                        }
                    }
                    dataModel.OnFinishedMessage();
                    break;
            }
        }

        private void CheckPlayMsgSpeedUp()
        {
            if (bIsAutoMessage || !dataModel.InputEnabled)
                return;

            if (wndInput.IsInputDecideButtonPush())
                windowMessage.SetPlaySpeedUpFlag(true);
            else if (wndInput.IsInputDecideButtonRelease())
                windowMessage.SetPlaySpeedUpFlag(false);
        }

        private void UpdateStateEnterkeywait()
        {
            if (dataModel.InputEnabled)
                uiContents.ShowKeywaitIcon();

            dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.Keywait);
        }

        private void UpdateStateKeywait(float deltaTime)
        {
            if (!dataModel.InputEnabled)
                return;

            uiContents.UpdateKeywaitIcon(deltaTime);

            if (bIsAutoMessage)
            {
                if (!UpdateAutoMessageWait(deltaTime))
                    return;
            }
            else
            {
                if (!wndInput.IsInputDecideButtonPush())
                    return;
            }

            soundPlayer.PlayDecideSE();
            DoNextPage();
        }

        private void DoNextPage()
        {
            windowMessage.DoNextPage();
            uiContents.HideKeywaitIcon();
            uiContents.HideLoadingIcon();
            dataModel.ChangeMsgState(MsgWindowDataModel.MsgWindowState.PlayingMessage);
        }

        private void UpdateStateWaitFinishMessage(float deltaTime)
        {
            dataModel.CheckWaitFinishTime(deltaTime);
        }

        private void UpdateStateFinishedMessage(float deltaTime)
        {
            uiContents.UpdateKeywaitIcon(deltaTime);

            if (!dataModel.CanInputClose)
                return;

            if (wndInput.IsInputDecideButtonPush())
                CloseWindow();
        }

        private void UpdateStatePlayingClose(float deltaTime)
        {
            windowAnimator.OnUpdate(deltaTime);

            if (windowAnimator.CurrentState != WindowAnimator.AnimState.FinishedClose)
                return;

            dataModel.OnFinishedClose();

            if (dataModel.IsOpen)
                return;

            windowMessage.Clear();
            dataModel.Clear();

            SetActive(false);
        }

        private void OnFoundCallbackOneTag(float value)
        {
            soundPlayer.PerformCallbackOne(value);
        }

        private void OnChangedConfig(ConfigID configID, int value)
        {
            switch (configID)
            {
                case ConfigID.MessageSpeed:
                    ChangeMsgSpeed((MSGSPEED)value);
                    break;

                case ConfigID.WindowType:
                    ChangeWndType((WINTYPE)value);
                    break;
            }
        }

        public void ClearCallbackFunc()
        {
            dataModel.ClearCallbackFunc();
        }

        private void SetActive(bool active)
        {
            if (gameObject.activeSelf != active)
                gameObject.SetActive(active);
        }

        public void EnableAutoMode(MSGSPEED msgSpeed, float waitTime = 0.0f)
        {
            waitAutoTimer.SetLimitTime(waitTime);
            bIsAutoMessage = true;
            waitAutoTimer.ResetTimer();

            ChangeMsgSpeed(msgSpeed);
        }

        public void DisableAutoMode()
        {
            if (!bIsAutoMessage)
                return;

            bIsAutoMessage = false;
            waitAutoTimer.ResetTimer();
            ChangeMsgSpeed(PlayerWork.config.msg_speed);
        }

        private bool UpdateAutoMessageWait(float deltaTime)
        {
            if (waitAutoTimer.IsFinishWait(deltaTime))
            {
                waitAutoTimer.ResetTimer();
                return true;
            }

            return false;
        }
    }
}