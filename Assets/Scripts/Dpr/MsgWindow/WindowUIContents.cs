using DPData;
using Dpr.Message;
using TMPro;
using UnityEngine;

namespace Dpr.MsgWindow
{
    public class WindowUIContents : MonoBehaviour
    {
        private Sprite[] windowBGSprArrayPtr;
        private Sprite[] windowFrameSprArrayPtr;
        private UIWindowLayout uiLayout = new UIWindowLayout();
        private UIRoadsign uiRoadsign = new UIRoadsign();
        private UISpeakerName uiSpeakerName = new UISpeakerName();
        private UIKeywaitIcon uiKeywaitIcon = new UIKeywaitIcon();
        private UILoadingIcon uiLoadingIcon = new UILoadingIcon();
        private GameObject uiContent;
        private Vector2 defaultWindowAnchorPos = Vector2.zero;
        private float defaultMessagePosX;
        private int defaultSortingOrder;
        private bool isPrevNetworkFlag;
        private bool isMoveMessagePosX;

        public void Initialize(MsgWindowDataModel dataModel, MsgWindowConfig config, MsgWindowDataContainer dataContainer)
        {
            windowBGSprArrayPtr = dataContainer.WindowBGSprArray;
            windowFrameSprArrayPtr = dataContainer.WindowFrameSprArray;

            var msgTextContainer = this.FindDeep("MsgTextContainer", true).GetComponent<RectTransform>();
            var canvas = this.FindDeep("Content", true).GetComponent<Canvas>();
            defaultMessagePosX = msgTextContainer.anchoredPosition.x;
            defaultSortingOrder = canvas.sortingOrder;
            defaultWindowAnchorPos = GetComponent<RectTransform>().anchoredPosition;

            uiLayout.Setup(msgTextContainer, GetComponent<RectTransform>(), canvas, this.FindDeep("Frame", true));
            uiContent = this.FindDeep("UIContent", true);

            uiRoadsign.Setup(uiContent.FindDeep("RoadsignContent", true));
            uiSpeakerName.Setup(uiContent.FindDeep("SpeakerName", true), dataModel, config.speakerFrameWidthOffset, dataContainer.GetCommonSprByIndex(1));
            uiKeywaitIcon.Setup(uiContent.FindDeep("KeywaitIcon", true), config.iconMoveDist, config.addAngleSec, dataContainer.GetCommonSprByIndex(0));
            ChangeWndType(PlayerWork.config.window_type);
        }

        public void SetupAssetBundleResource(MsgWindowDataContainer dataContainer)
        {
            var loadingIcon = uiContent.FindDeep("LoadingIcon", true);
            var asset = dataContainer.GetInstantiadedAssetByIndex(0, loadingIcon.transform);
            uiLoadingIcon.Setup(asset);
        }

        public void OnFinalize()
        {
            uiLoadingIcon.OnFinalize();
        }

        public int SortingOrder { get => uiLayout.SortingOrder; }

        public void SetupLayout(Vector2? anchorPos, int sortingOrder, bool isNetwork)
        {
            ResetOffsetPosX();
            SetWindowPosition(anchorPos);
            SetSortingOrder(sortingOrder);

            uiRoadsign.HideRoadsignIcon();
            uiSpeakerName.SetSpeakerNameActive(false);
            uiKeywaitIcon.SetKeywaitIconActive(false);

            if (!isPrevNetworkFlag)
            {
                if (isNetwork)
                {
                    isPrevNetworkFlag = true;
                    uiLayout.SetWindowFrameSpr(windowFrameSprArrayPtr[(int)WINTYPE.WINTYPE_MAX]);
                }
            }
            else
            {
                if (!isNetwork)
                {
                    ChangeWndType(PlayerWork.config.window_type);
                    isPrevNetworkFlag = false;
                }
            }
        }

        public void ChangeFontAsset(TMP_FontAsset useFontAsset)
        {
            uiSpeakerName.SetSpeakerNameFontAsset(useFontAsset);
        }

        private void SetWindowPosition(Vector2? anchorPos)
        {
            if (anchorPos.HasValue)
                uiLayout.SetWindowPos(anchorPos.Value);
            else
                uiLayout.SetWindowPos(defaultWindowAnchorPos);
        }

        private void SetSortingOrder(int sortingOrder)
        {
            if (sortingOrder > -1)
            {
                uiLayout.SetSortingOrder(sortingOrder);
                return;
            }

            if (uiLayout.SortingOrder == defaultSortingOrder)
                return;

            uiLayout.SetSortingOrder(defaultSortingOrder);
        }

        public void SetWindowWidth(float width)
        {
            uiLayout.SetWindowWidth(width);
        }

        public void ChangeWndType(WINTYPE winType)
        {
            MessageHelper.EmitLog(string.Format("Change WindowType : {0}", winType), LogType.Log);
            uiLayout.SetWindowFrameSpr(windowFrameSprArrayPtr[(int)winType]);
        }

        public void ResetDefaultWndFrame()
        {
            uiLayout.SetCurrentSelectWindowSpr();
        }

        public void SetBoardWndFrame(MsgWindowDataModel.WindowFrameType winType)
        {
            if (winType == MsgWindowDataModel.WindowFrameType.Default)
                ResetDefaultWndFrame();
            else
                uiLayout.SetBoardFrameSpr(windowBGSprArrayPtr[(int)winType]);
        }

        public void SetNetworkFrame()
        {
            uiLayout.SetWindowFrameSpr(windowFrameSprArrayPtr[(int)WINTYPE.WINTYPE_MAX]);
        }

        public void ShowRoadsign(RoadsignViewData viewData, float posX)
        {
            uiRoadsign.ShowRoadsignIcon(viewData);
            if (isMoveMessagePosX)
                return;

            isMoveMessagePosX = true;
            uiLayout.SetOffsetPosX(posX);
        }

        private void ResetOffsetPosX()
        {
            if (!isMoveMessagePosX)
                return;

            isMoveMessagePosX = false;
            uiLayout.SetOffsetPosX(defaultMessagePosX);
        }

        public void ShowKeywaitIcon()
        {
            uiKeywaitIcon.ResetParam();
            uiKeywaitIcon.SetKeywaitIconActive(true);
        }

        public void HideKeywaitIcon()
        {
            uiKeywaitIcon.SetKeywaitIconActive(false);
        }

        public void UpdateKeywaitIcon(float deltaTime)
        {
            uiKeywaitIcon.OnUpdate(deltaTime);
        }

        public void ShowLoadingIcon()
        {
            uiLoadingIcon.SetLoadingIconActive(true);
            uiLoadingIcon.PlayAnim();
        }

        public void HideLoadingIcon()
        {
            uiLoadingIcon.SetLoadingIconActive(false);
        }

        public void ShowSpeakerName(string speakerName)
        {
            uiSpeakerName.SetSpeakerName(speakerName);
            uiSpeakerName.SetSpeakerNameActive(true);
        }

        public void HideSpeakerName()
        {
            uiSpeakerName.SetSpeakerNameActive(false);
        }
    }
}