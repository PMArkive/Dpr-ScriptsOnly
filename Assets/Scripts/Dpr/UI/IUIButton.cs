using UnityEngine;

namespace Dpr.UI
{
    public interface IUIButton
    {
        int GetIndex();

        void SetIndex(int index);

        RectTransform GetRectTransform();

        bool GetActive();

        void SetActive(bool isActive);

        void Select();

        void UnSelect();
    }
}