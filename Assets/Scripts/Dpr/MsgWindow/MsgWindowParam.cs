using DPData;
using Dpr.Message;
using System;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class MsgWindowParam
    {
        public string labelName = string.Empty;
        public int labelIndex = -1;
        public MessageMsgFile useMsgFile;
        public MessageTextParseDataModel textDataModel;
        public bool bBatchDisplay;
        public int dataValue;
        public bool inputEnabled = true;
        public bool inputCloseEnabled;
        public bool playTextFeedSe;
        public MsgWindowDataModel.WindowFrameType frameTypeIndex = MsgWindowDataModel.WindowFrameType.Default;
        public Vector2? wndAnchorPos;
        public int sortingOrder = -1;
        public MSGSPEED forceSetMsgSpeed = MSGSPEED.MSGSPEED_MAX;
        public string originalSpeakerName = string.Empty;
        public bool showLastKeywaitIcon;
        public bool isNetwork;
        public bool showLoadingIcon;
        public Action onFinishedOpenWindow;
        public Action onFinishedCloseWindow;
        public Action onFinishedShowAllMessage;

        public bool HasLabelName { get => !string.IsNullOrEmpty(labelName); }

        public MessageTextParseDataModel GetTextParseDataModel()
        {
            if (useMsgFile == null)
            {
                MessageHelper.EmitLog("Failed Format Message.Because useMsgFile is null", LogType.Error);
                return null;
            }

            if (!string.IsNullOrEmpty(labelName))
                return useMsgFile.GetTextDataModel(labelName);

            if (labelIndex > -1)
                return useMsgFile.GetTextDataModelByIndex(labelIndex);

            MessageHelper.EmitLog("Failed GetTextDataModel : Index not setting", LogType.Error);
            return null;
        }

        public string SDMessageGetLabelName()
        {
            return textDataModel != null ? textDataModel.LabelName : string.Empty;
        }

        public bool IsPlayTextFeedSe()
        {
            return inputCloseEnabled && playTextFeedSe;
        }
    }
}
