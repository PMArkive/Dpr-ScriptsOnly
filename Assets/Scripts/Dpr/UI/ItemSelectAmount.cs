using TMPro;
using UnityEngine;

namespace Dpr.UI
{
    public class ItemSelectAmount : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform upArrowRectTransform;
        [SerializeField]
        protected RectTransform downArrowRectTransform;
        [SerializeField]
        protected TextMeshProUGUI amountValueText;
        [SerializeField]
        protected TextMeshProUGUI descriptionText;
        [SerializeField]
        protected IndexSelector indexSelector;

        public bool IsShow { get; set; }
        public int CurrentAmount { get => indexSelector.CurrentIndex; }

        // TODO
        public void Show() { }

        // TODO
        public void Hide() { }

        // TODO
        public void Set(int min, int max) { }

        // TODO
        public void SetDescriptionText(string text) { }

        // TODO
        public bool ChangeAmount(int value) { return false; }

        // TODO
        public void ResumeChangeAmount() { }

        // TODO
        protected bool AddAmount(int value) { return false; }

        // TODO
        protected void UpdateAmountValueText() { }
    }
}