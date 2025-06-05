using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.MsgWindow
{
    public class UIKeywaitIcon
    {
        private const float LIMIT_VALUE = 180;
        private GameObject iconContent;
        private RectTransform keywaitIconRect;
        private float iconMoveDist;
        private float addAngleSec;
        private float angle;

        public void Setup(GameObject iconContent, float iconMoveDist, float addAngleSec, Sprite iconSprite)
        {
            this.iconContent = iconContent;
            this.iconMoveDist = iconMoveDist;
            this.addAngleSec = addAngleSec;

            var iconImage = iconContent.FindDeep("IconImage", true);
            keywaitIconRect = iconImage.GetComponent<RectTransform>();
            iconImage.GetComponent<Image>().sprite = iconSprite;

            if (iconContent.activeSelf)
                iconContent.SetActive(false);
        }

        public void ResetParam()
        {
            angle = 0.0f;
            UpdateKeywaitIconPosition();
        }

        public void SetKeywaitIconActive(bool active)
        {
            if (iconContent.activeSelf != active)
                iconContent.SetActive(active);
        }

        public void OnUpdate(float deltaTime)
        {
            angle += addAngleSec * deltaTime;
            if (angle > LIMIT_VALUE)
                angle -= LIMIT_VALUE;

            UpdateKeywaitIconPosition();
        }

        private void UpdateKeywaitIconPosition()
        {
            double y = iconMoveDist - Math.Sin(angle * 0.01745329) * iconMoveDist;
            keywaitIconRect.anchoredPosition = new Vector2(keywaitIconRect.anchoredPosition.x, (float)y);
        }
    }
}