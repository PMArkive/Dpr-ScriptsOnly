using System;
using System.Runtime.InteropServices;

namespace Dpr.UI
{
    public class ShopItemSelectAmount : ItemSelectAmount
    {
        private const int ChangeAmountValue = 1;
        private const int ChangeLotAmountValue = 10;
        private Action<int> onDecideSelectAmountCallback;
        private Action onCancelSelectAmountCallback;
        private Action<int> onSelectAmountValueChangedCallback;
        private UIInputController _input = new UIInputController();

        // TODO
        public void OnUpdate() { }

        // TODO
        public void ShowSelectAmount(int min, int max, Action<int> onDecide, Action onCancel, [Optional] Action<int> onAmountValueChanged) { }

        // TODO
        public void ChangeSelectAmount(bool isAdd, bool isLot) { }

        // TODO
        public void ResumeSelectAmountChange() { }

        // TODO
        public void DecideSelectAmount() { }

        // TODO
        public void CancelSelectAmount() { }

        // TODO
        public void SetSelectAmountDescriptionText(string text) { }
    }
}