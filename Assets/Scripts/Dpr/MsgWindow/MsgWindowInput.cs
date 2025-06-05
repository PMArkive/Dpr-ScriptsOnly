using UnityEngine;

namespace Dpr.MsgWindow
{
    public class MsgWindowInput
    {
        private GameController.LogicalInput localInput = new GameController.LogicalInput();

        private void AssignInputDecide()
        {
            var baseMask = GameController.ButtonMask.A | GameController.ButtonMask.B | GameController.ButtonMask.ZL | GameController.ButtonMask.ZR;
            var choirakuMask = baseMask | GameController.ButtonMask.Right | GameController.ButtonMask.Down;
            localInput.Clear();
            localInput.Assign(0, PlayerWork.config.input_mode == DPData.INPUTMODE.INPUTMODE_CHOIRAKU ? choirakuMask : baseMask);
        }

        public void SubscribeToGameController()
        {
            AssignInputDecide();
            GameController.Subscribe(localInput);
        }

        public void RemoveFromGameController()
        {
            GameController.Remove(localInput);
            localInput.Clear();
        }

        public bool IsInputDecideButtonPush()
        {
            if (Input.GetKeyDown(KeyCode.L))
                return true;

            return IsButtonPush(GameController.ButtonMask.A);
        }

        public bool IsInputDecideButtonRelease()
        {
            if (Input.GetKeyUp(KeyCode.L))
                return true;

            return IsButtonRelease(GameController.ButtonMask.A);
        }

        private bool IsButtonPush(int assignValue)
        {
            return (assignValue & localInput.push) != 0;
        }

        private bool IsButtonRelease(int assignValue)
        {
            return (assignValue & localInput.release) != 0;
        }

        private enum KeyAssignId : int
        {
            Decide = 0,
        }

        private class KeyAssignValue
        {
            public const int InputDecide = 1;
        }
    }
}