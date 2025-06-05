using UnityEngine;
using UnityEngine.UI;

namespace Dpr.MsgWindow
{
    public class UIRoadsign
    {
        private GameObject roadsignContent;
        private RectTransform roadsignImageRect;
        private Image roadsignImage;

        public void Setup(GameObject roadsignContent)
        {
            this.roadsignContent = roadsignContent;
            roadsignImage = roadsignContent.FindDeep("RoadsignImage", true).GetComponent<Image>();
            roadsignImageRect = roadsignImage.rectTransform;
            HideRoadsignIcon();
        }

        public void ShowRoadsignIcon(RoadsignViewData viewData)
        {
            roadsignImageRect.localPosition = viewData.position;
            roadsignImageRect.localRotation = Quaternion.AngleAxis(viewData.rotZ, Vector3.forward);

            if (roadsignImage.sprite != viewData.spritePtr)
            {
                roadsignImage.sprite = viewData.spritePtr;
                roadsignImageRect.sizeDelta = viewData.texSize;
            }

            if (!roadsignContent.activeSelf)
                roadsignContent.SetActive(true);
        }

        public void HideRoadsignIcon()
        {
            roadsignImageRect.localPosition = Vector3.zero;
            roadsignImageRect.localRotation = Quaternion.identity;
            SetRoadsignActive(false);
        }

        private void SetRoadsignActive(bool active)
        {
            if (roadsignContent.activeSelf != active)
                roadsignContent.SetActive(active);
        }
    }
}
