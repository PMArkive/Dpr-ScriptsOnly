using UnityEngine;
using UnityEngine.UI;

namespace Dpr.MsgWindow
{
    public class UIWindowLayout
    {
        private RectTransform msgTextRect;
        private RectTransform frameRect;
        private RectTransform windowRect;
        private Image frameImage;
        private Canvas canvas;
        private Sprite currentWndFrameSpr;

        public void Setup(RectTransform msgTextRect, RectTransform windowRect, Canvas canvas, GameObject frameObj)
        {
            this.msgTextRect = msgTextRect;
            this.canvas = canvas;
            this.windowRect = windowRect;
            frameImage = frameObj.GetComponent<Image>();
            frameRect = frameObj.GetComponent<RectTransform>();
        }

        public int SortingOrder { get => canvas.sortingOrder; }

        public void SetWindowPos(Vector2 anchorPos)
        {
            windowRect.anchoredPosition = anchorPos;
        }

        public void SetSortingOrder(int sortingOrder)
        {
            canvas.sortingOrder = sortingOrder;
        }

        public void SetOffsetPosX(float posX)
        {
            msgTextRect.anchoredPosition = new Vector2(posX, msgTextRect.anchoredPosition.y);
        }

        public void SetWindowFrameSpr(Sprite newFrameSpr)
        {
            currentWndFrameSpr = newFrameSpr;
            SetCurrentSelectWindowSpr();
        }

        public void SetCurrentSelectWindowSpr()
        {
            frameImage.sprite = currentWndFrameSpr;
        }

        public void SetBoardFrameSpr(Sprite newBoardSpr)
        {
            frameImage.sprite = newBoardSpr;
        }

        public void SetWindowWidth(float width)
        {
            frameRect.sizeDelta = new Vector2(width, frameRect.sizeDelta.y);
        }
    }
}