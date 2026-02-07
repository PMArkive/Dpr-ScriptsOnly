using DPData;
using Dpr.Message;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class MsgWindowDataModel
    {
        private const int SPEAKR_NAME_CHAR_NUM = 10;
        private const string USER_LABEL = "HERO";
        private const string RIVAL_LABEL = "RIVAL";
        private const string RIVAL_MOTHER_LABEL = "RIVALMAMA";
        private const string ORIGINAL_NAME_LABEL = "ORIGINAL";
        private MsgWindowParam currentMsgParam;
        private MessageTextParseDataModel currentMessageDataModel;
        private Dictionary<int, RoadsignViewData> roadsignViewDataTable;
        private Dictionary<int, string> speakerNameTable;
        private float[] msgSpeedArray;
        private TMP_FontAsset useFontAsset;
        private MsgWindowState msgState;
        private WaitTimer waitTimer = new WaitTimer();
        private string speakerName = string.Empty;
        private float showOneFontTimeSec;
        private float defaultShowOneFontTimeSec;
        private float fontSize;
        private bool inputEnabled = true;

        public void Initialize(float[] msgSpeedArray, int waitFinishFrame, MsgWindowDataContainer dataContainer)
        {
            this.msgSpeedArray = msgSpeedArray;
            speakerNameTable = dataContainer.SpeakerNameTable;
            roadsignViewDataTable = dataContainer.RoadsignViewDataTable;
            msgState = MsgWindowState.Inactive;
            ChangeMsgSpeed(PlayerWork.config.msg_speed);
            waitTimer.SetLimitTime(waitFinishFrame * 0.03333334f);
        }

        public void OnFinalize()
        {
            Clear();
        }

        public void Clear()
        {
            msgState = MsgWindowState.Inactive;
            if (currentMsgParam != null)
                currentMsgParam = null;

            if (currentMessageDataModel != null)
                currentMessageDataModel = null;
        }

        public bool IsOpen { get => msgState != MsgWindowState.Inactive && msgState != MsgWindowState.PlayingClose; }
        public MsgWindowState MsgState { get => msgState; }

        public void ChangeMsgState(MsgWindowState nextState)
        {
            MessageHelper.EmitLog(string.Format("Change Msg State : {0}", nextState), LogType.Log);
            msgState = nextState;
        }

        public void ChangeMsgSpeed(MSGSPEED msgSpeed)
        {
            MessageHelper.EmitLog(string.Format("Change Msg Speed : {0}", msgSpeed));
            showOneFontTimeSec = msgSpeedArray[(int)msgSpeed];
            defaultShowOneFontTimeSec = msgSpeedArray[(int)msgSpeed];
        }

        public bool InputEnabled { get => inputEnabled; }
        public bool IsShowLastKeywaitIcon { get => currentMsgParam.showLastKeywaitIcon; }
        public bool IsShowLoadingIcon { get => currentMsgParam.showLoadingIcon; }

        public void SetInputEnabled(bool enabled)
        {
            inputEnabled = enabled;
        }

        public bool CanInputClose { get => currentMsgParam.inputEnabled && currentMsgParam.inputCloseEnabled; }
        public string LabelName
        {
            get
            {
                if (!string.IsNullOrEmpty(currentMsgParam.labelName))
                    return currentMsgParam.labelName;

                if (currentMsgParam.textDataModel != null)
                    return currentMsgParam.textDataModel.LabelName;

                return string.Empty;
            }
        }

        public bool HasSpeakerName()
        {
            return !string.IsNullOrEmpty(speakerName);
        }

        public string SpeakerName { get => speakerName; }

        public void ClearSpeakerName()
        {
            speakerName = string.Empty;
        }

        public MessageTextParseDataModel MessageData { get => currentMessageDataModel ?? currentMsgParam.textDataModel; }
        public float ShowOneFontTimeSec { get => currentMsgParam != null && currentMsgParam.forceSetMsgSpeed != MSGSPEED.MSGSPEED_MAX ? msgSpeedArray[(int)currentMsgParam.forceSetMsgSpeed] : showOneFontTimeSec; }
        public bool IsUnknownMessage { get => MessageData != null ? MessageData.IsUnknownMessage : false; }
        public bool HasBattleOnelineTag { get => MessageData != null ? MessageData.IsOneLineTagMessage() : false; }
        public bool IsNetwork { get => currentMsgParam?.isNetwork ?? false; }

        public void FormatTextData()
        {
            MessageData?.ApplyFormat();
        }

        public void FormatItemGetTextData()
        {
            SetPocketIconData();
            MessageData.ApplyFormat();
        }

        private void SetPocketIconData()
        {
            if (MessageData == null || MessageData.TagDataList.Count <= 0)
                return;

            var itemInfo = ItemWork.GetItemInfo(currentMsgParam.dataValue);
            if (itemInfo == null)
            {
                MessageHelper.EmitLog(string.Format("Item Nomber {0} is not found", currentMsgParam.dataValue), LogType.Error);
                return;
            }

            foreach (var tag in MessageData.TagDataList)
            {
                switch (tag.tagGroupId)
                {
                    case MessageEnumData.GroupTagID.Name:
                        switch ((MessageEnumData.NameID)tag.tagId)
                        {
                            case MessageEnumData.NameID.Pocket:
                            case MessageEnumData.NameID.BagPocketIcon:
                            case MessageEnumData.NameID.PocketIcon:
                                MessageWordSetHelper.SetPocketNameWord(tag.index, currentMsgParam.dataValue);
                                break;
                        }
                        break;

                    case MessageEnumData.GroupTagID.Character1:
                        switch ((MessageEnumData.Character1ID)tag.tagId)
                        {
                            case MessageEnumData.Character1ID.PocketIcon:
                                tag.strValue = MessageHelper.ConvertUnicodeToChar(MessageDataConstants.POCKET_ICON_CODE_TABLE[(int)itemInfo.Category]).ToString();
                                break;
                        }
                        break;
                }
            }
        }

        public void SetBtlMsgWindowParam(MsgWindowParam btlMsgWindowParam)
        {
            currentMsgParam = btlMsgWindowParam;
            SetWindowParameters();
            showOneFontTimeSec = defaultShowOneFontTimeSec;
            SetWindowDataFromMessageData();
        }

        public void ResetParam()
        {
            waitTimer.ResetTimer();
        }

        public void SetMsgWindowParam(MsgWindowParam msgWindowParam)
        {
            currentMsgParam = msgWindowParam;
            currentMessageDataModel = msgWindowParam.GetTextParseDataModel();
            SetWindowParameters();
            showOneFontTimeSec = msgWindowParam.bBatchDisplay ? 0.0f : defaultShowOneFontTimeSec;
            SetWindowDataFromMessageData();
        }

        public void SetBoardMsgWindowParam(MsgWindowParam msgWindowParam)
        {
            currentMsgParam = msgWindowParam;
            currentMessageDataModel = msgWindowParam.GetTextParseDataModel();
            SetWindowParameters();
            showOneFontTimeSec = 0.0f;
            SetWindowDataFromMessageData();
        }

        private void SetWindowParameters()
        {
            speakerName = CreateSpeakerName();
            inputEnabled = currentMsgParam.inputEnabled;
        }

        private string CreateSpeakerName()
        {
            var key = string.IsNullOrEmpty(currentMsgParam.labelName)
                ? (currentMsgParam.textDataModel == null ? string.Empty : currentMsgParam.textDataModel.LabelName)
                : currentMsgParam.labelName;
            var hash = key.GetHashCode();

            if (!speakerNameTable.ContainsKey(hash))
                return string.Empty;

            var speaker = speakerNameTable[hash];
            if (speaker == USER_LABEL)
                return PlayerWork.userName.GetInvalidRichText();
            else if (speaker == RIVAL_LABEL)
                return MessageManager.Instance.GetRivalName().GetInvalidRichText();
            else if (speaker == RIVAL_MOTHER_LABEL)
                return MessageManager.Instance.GetRivalMotherName().GetInvalidRichText();
            else if (speaker == ORIGINAL_NAME_LABEL)
            {
                if (currentMsgParam != null)
                    return currentMsgParam.originalSpeakerName;

                MessageHelper.EmitLog("ORIGINAL_NAME_LABEL : currentMsgParam is null", LogType.Log);
                return string.Empty;
            }
            else
                return MessageManager.Instance.GetNameMessage(MessageDataConstants.SPEAKER_NAME_FILE_NAME, speaker);
        }

        private void SetWindowDataFromMessageData()
        {
            if (MessageData == null)
                MessageHelper.EmitLog("currentMessageDataModel is null", LogType.Error);
            else
                fontSize = MessageData.FontSize;
        }

        public void OnStartOpen()
        {
            ChangeMsgState(MsgWindowState.PlayingOpen);
        }

        public void OnFinishedOpen()
        {
            ChangeMsgState(MsgWindowState.FinishedOpen);
            currentMsgParam.onFinishedOpenWindow?.Invoke();
        }

        public void OnFinishedMessage()
        {
            msgState = MsgWindowState.WaitFinishMessage;
        }

        public void CheckWaitFinishTime(float deltaTime)
        {
            if (waitTimer.IsFinishWait(deltaTime))
            {
                ChangeMsgState(MsgWindowState.FinishedShowMessage);
                currentMsgParam.onFinishedShowAllMessage?.Invoke();
            }
        }

        public void OnClose()
        {
            ChangeMsgState(MsgWindowState.PlayingClose);
        }

        public void OnFinishedClose()
        {
            ChangeMsgState(MsgWindowState.Inactive);
            currentMsgParam.onFinishedCloseWindow?.Invoke();
        }

        public void CallFinishedCallback()
        {
            currentMsgParam?.onFinishedCloseWindow?.Invoke();
        }

        public Vector2? WndAnchorPosition { get => currentMsgParam.wndAnchorPos; }
        public int TextWidth { get => MessageData != null ? MessageData.TextWidth : 0; }
        public float FrameWidth { get => MessageData != null ? MessageData.TextWidth * MessageDataConstants.ASPECT_SCALE.x : 0.0f; }
        public int SortingOrder { get => currentMsgParam.sortingOrder; }
        public float SpeakerFrameWidth { get => MessageFontDataConstants.FONT_SIZE_TABLE[1] * 12.0f; }
        public float SpeakerNameFontSize { get => MessageFontDataConstants.FONT_SIZE_TABLE[1]; }
        public float FontSize { get => IsUnknownMessage ? MessageDataConstants.UNKNOWN_MSG_FONT_SIZE : fontSize; }
        public float FontScale { get => fontSize / useFontAsset.creationSettings.pointSize; }
        public Color FontColor { get => MessageData != null ? MessageData.GetFontColor() : MessageFontDataConstants.DEFAULT_FONT_COLOR; }
        public Color NetworkFonrColor { get => MessageFontDataConstants.NETWORK_TEXT_COLOR; }
        public TMP_FontAsset FontAsset { get => useFontAsset; set => useFontAsset = value; }

        public bool CheckShowRoadsignByPattern(int pattern)
        {
            return roadsignViewDataTable.ContainsKey(pattern) && pattern > 0;
        }

        public RoadsignViewData GetRoadsignViewDataByPattern(int pattern)
        {
            return roadsignViewDataTable[pattern];
        }

        public void ClearCallbackFunc()
        {
            MessageHelper.EmitLog("Clear All MsgWindowCallback!!", LogType.Log);
            if (currentMsgParam == null)
                return;

            currentMsgParam.onFinishedOpenWindow = null;
            currentMsgParam.onFinishedCloseWindow = null;
            currentMsgParam.onFinishedShowAllMessage = null;
        }

        public enum MsgWindowState : int
        {
            Inactive = 0,
            PlayingOpen = 1,
            FinishedOpen = 2,
            PlayingMessage = 3,
            EnterKeywait = 4,
            Keywait = 5,
            WaitFinishMessage = 6,
            FinishedShowMessage = 7,
            PlayingClose = 8,
        }

        public enum WindowFrameType : int
        {
            Frame_Brown = 0,
            Frame_Green = 1,
            Frame_Gray = 2,
            Frame_Blue = 3,
            Num = 4,
            Default = 5,
        }
    }
}
