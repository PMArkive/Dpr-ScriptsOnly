using Dpr.Message;
using System;
using TMPro;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public sealed class WindowMessage : MonoBehaviour
    {
        [SerializeField]
        private MsgTextContainer textContainer;
        private MessageTextLineDataModel[] textLineDataArray;
        private MessageTextLineDataModel currentLineData;
        private MessageEnumData.MsgEventID currentMsgEventId;
        private WaitTimer waitTimer = new WaitTimer();
        private MsgState currentMsgState;
        private float playLineMsgTime;
        private float showMsgTime;
        private float fastForwardMagnification = 1.0f;
        private int lineDataIndex;
        private int useTextIndex;
        private int currentLineStrNum;
        private bool isChangeTextColor;
        private bool playSpeedUpFlag;
        private Action<float> onMsgCallBack;
        private Action onFinishedShowOneLine;

        public void Initialize(MsgWindowConfig config, Action<float> onMsgCallBack)
        {
            this.onMsgCallBack = onMsgCallBack;
            fastForwardMagnification = config.fastForwardMagnification;
            currentMsgState = MsgState.Wait;
            textContainer.Initialize(config.scrollTextDuration, config.textLinePaddingOffset);
        }

        public void ResetMessage()
        {
            currentMsgState = MsgState.Wait;
            lineDataIndex = 0;
            useTextIndex = 0;
            showMsgTime = 0.0f;
            playSpeedUpFlag = false;

            SetCurrentLineData();

            textContainer.ResetUIText();
            if (currentLineData != null)
                textContainer.SetTextEnabled(currentLineData.IsCenterMessage);
        }

        public void Clear()
        {
            textLineDataArray = null;
            currentLineData = null;
            lineDataIndex = 0;
            useTextIndex = 0;
            showMsgTime = 0.0f;
            playSpeedUpFlag = false;
            textContainer.Clear();
        }

        public void ResetTextColor()
        {
            if (!isChangeTextColor)
                return;

            isChangeTextColor = false;
            textContainer.ResetTextColor();
        }

        public void OnFinalize()
        {
            textContainer.OnFinalize();
            currentLineData = null;
            onMsgCallBack = null;
            onFinishedShowOneLine = null;
        }

        public MsgState CurrentMsgState { get => currentMsgState; }

        public void SetUseFontAsset(TMP_FontAsset useFontAsset)
        {
            textContainer.SetUseFontAsset(useFontAsset);
        }

        public void ChangeUnknownFont()
        {
            textContainer.ChangeUnknownFont();
        }

        public void SetPlayMsgTime(float playMsgTime)
        {
            playLineMsgTime = playMsgTime;
            showMsgTime = 0.0f;
        }

        public void SetPlaySpeedUpFlag(bool flag)
        {
            playSpeedUpFlag = flag;
        }

        public void SetUseMessageLineDataArray(MessageTextLineDataModel[] textLineDataArray)
        {
            this.textLineDataArray = textLineDataArray;
        }

        private void SetCurrentLineData()
        {
            currentMsgEventId = MessageEnumData.MsgEventID.None;
            if (textLineDataArray == null)
                return;

            currentLineData = textLineDataArray[lineDataIndex];
            currentLineData.ResetMessageData();
            currentLineStrNum = currentLineData.TotalStringLength;
        }

        public void SetTextColor(Color newColor)
        {
            isChangeTextColor = true;
            textContainer.SetTextColor(newColor);
        }

        public void CheckTextResize(MessageTextParseDataModel currentMessageData, float fontScale, int windowWidth)
        {
            if (currentMessageData == null)
                return;

            float adjustedFontScale = CheckOverText(currentMessageData, fontScale, windowWidth);

            if (adjustedFontScale != 1.0f)
                textContainer.SetFontSize(adjustedFontScale * textContainer.FontSize);
        }

        private float CheckOverText(MessageTextParseDataModel currentMessageData, float fontScale, int windowWidth)
        {
            if (!currentMessageData.HasOverWidthLineData(fontScale, windowWidth, out float adjustedFontScale))
                adjustedFontScale = 1.0f;

            return adjustedFontScale;
        }

        public void SetTextParam(float fontSize, float textWidth)
        {
            textContainer.SetTextParam(fontSize, textWidth);
        }

        public void SetFontSize(float fontSize)
        {
            textContainer.SetFontSize(fontSize);
        }

        private bool IsRestMessageLine()
        {
            if (textLineDataArray == null)
                return false;

            return lineDataIndex < textLineDataArray.Length - 1;
        }

        private float GetEventValue()
        {
            if (currentLineData != null)
                return currentLineData.GetNowMessageDataValue();

            MessageHelper.EmitLog("currentLineData is null", LogType.Error);
            return 0.0f;
        }

        public void StartPlayMessage()
        {
            if (textLineDataArray != null)
            {
                textLineDataArray[lineDataIndex].ResetMessageData();
                textContainer.SetTextEnabled(currentLineData.IsCenterMessage);
            }

            currentMsgState = MsgState.Playing;
        }

        public void RestartMessage()
        {
            ResetMessage();
            currentMsgState = MsgState.Playing;
        }

        public void UpdateMessage(float deltaTime)
        {
            if (CanUpdateMessage())
            {
                if (!CheckWaitEvent(deltaTime))
                {
                    UpdateTextView(deltaTime);
                }
            }
        }

        private bool CanUpdateMessage()
        {
            return currentMsgState != MsgState.End;
        }

        private bool CheckWaitEvent(float deltaTime)
        {
            if (currentMsgState == MsgState.TextScroll)
            {
                CheckTextScrollState(deltaTime);
                return true;
            }
            else if (currentMsgState == MsgState.Wait)
            {
                return CheckWaitState(deltaTime);
            }

            return false;
        }

        private bool CheckWaitState(float deltaTime)
        {
            if (waitTimer.IsFinishWait(deltaTime))
                currentMsgState = MsgState.Playing;

            return true;
        }

        private bool CheckTextScrollState(float deltaTime)
        {
            if (textContainer.MovingPosition(deltaTime))
                return true;

            DoNextLine();
            currentMsgState = MsgState.Playing;

            return true;
        }

        private void UpdateTextView(float deltaTime)
        {
            int strNum;
            if (playLineMsgTime <= 0.0f)
            {
                strNum = currentLineStrNum;
            }
            else
            {
                showMsgTime += GetDeltaTime(deltaTime);
                strNum = (int)(showMsgTime / playLineMsgTime);
            }

            if (currentLineData == null)
                currentMsgEventId = MessageEnumData.MsgEventID.End;
            else
                textContainer.SetMessage(useTextIndex, SetLineMessage(strNum), currentLineData.IsCenterMessage);

            CheckLineEvent();
        }

        private float GetDeltaTime(float deltaTime)
        {
            if (playSpeedUpFlag)
                deltaTime *= fastForwardMagnification;

            return deltaTime;
        }

        private string SetLineMessage(int strIndex)
        {
            string msg = currentLineData.GetTextUntilIndex(strIndex <= currentLineStrNum ? strIndex : currentLineStrNum);
            currentMsgEventId = currentLineData.NowEventId;
            return msg;
        }

        private void CheckLineEvent()
        {
            switch (currentMsgEventId)
            {
                case MessageEnumData.MsgEventID.NewLine:
                    MsgEventNewLine();
                    break;

                case MessageEnumData.MsgEventID.Wait:
                    MsgEventWait();
                    break;

                case MessageEnumData.MsgEventID.ScrollPage:
                    MsgEventScrollPage();
                    break;

                case MessageEnumData.MsgEventID.ScrollLine:
                    MsgEventScrollLine();
                    break;

                case MessageEnumData.MsgEventID.CallBack:
                    MsgEventCallBack();
                    break;

                case MessageEnumData.MsgEventID.End:
                    MsgEventEnd();
                    break;
            }
        }

        private void MsgEventEnd()
        {
            MessageHelper.EmitLog("MsgEvent End", LogType.Log);
            currentMsgState = MsgState.End;
        }

        private void MsgEventWait()
        {
            MessageHelper.EmitLog("MsgEvent Wait", LogType.Log);
            waitTimer.SetLimitTime(GetEventValue());
            waitTimer.ResetTimer();
            currentMsgState = MsgState.Wait;
        }

        private void MsgEventCallBack()
        {
            MessageHelper.EmitLog(string.Format("MsgEvent CallBack : Event Value - {0}", GetEventValue()), LogType.Log);

            if (onMsgCallBack == null)
                return;

            onMsgCallBack.Invoke(GetEventValue());
        }

        private void MsgEventNewLine()
        {
            MessageHelper.EmitLog("MsgEvent NewLine", LogType.Log);
            onFinishedShowOneLine?.Invoke();
            showMsgTime = 0.0f;
            DoNextLine();
        }

        private void MsgEventScrollLine()
        {
            MessageHelper.EmitLog("MsgEvent ScrollLine", LogType.Log);
            showMsgTime = 0.0f;
            currentMsgState = MsgState.KeyWait;
        }

        private void MsgEventScrollPage()
        {
            MessageHelper.EmitLog("MsgEvent ScrollPage", LogType.Log);
            showMsgTime = 0.0f;
            currentMsgState = MsgState.KeyWait;
        }

        public void DoNextPage()
        {
            playSpeedUpFlag = false;
            switch (currentMsgEventId)
            {
                case MessageEnumData.MsgEventID.ScrollPage:
                    textContainer.ResetUIText();
                    DoScrollPage();
                    currentMsgState = MsgState.Playing;
                    break;

                case MessageEnumData.MsgEventID.ScrollLine:
                    textContainer.StartMovePositionY();
                    currentMsgState = MsgState.TextScroll;
                    break;

                default:
                    MessageHelper.EmitLog(string.Format("currentMsgEventId is Not ScrollLine or ScrollPage : {0}", currentMsgEventId), LogType.Error);
                    break;
            }
        }

        private void DoNextLine()
        {
            if (IsRestMessageLine())
            {
                lineDataIndex++;
                useTextIndex++;
                SetCurrentLineData();
            }
        }

        private void DoScrollPage()
        {
            if (IsRestMessageLine())
            {
                lineDataIndex++;
                useTextIndex = 0;
                SetCurrentLineData();
                textContainer.SetTextEnabled(currentLineData.IsCenterMessage);
            } 
        }

        public enum MsgState : int
        {
            Wait = 0,
            Playing = 1,
            KeyWait = 2,
            TextScroll = 3,
            End = 4,
        }
    }
}