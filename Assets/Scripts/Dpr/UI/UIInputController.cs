namespace Dpr.UI
{
    public class UIInputController
    {
        private bool _inputEnabled = true;
        private int _autoPushButton;

        public bool inputEnabled { get => _inputEnabled; set => _inputEnabled = value; }

        public bool IsPushButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.push & button) != 0;
        }

        public bool IsReleaseButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.release & button) != 0;
        }

        public bool IsRepeatButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.repeat & button) != 0;
        }

        public bool IsOnButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.on & button) != 0;
        }

        public bool IsPushOrRepeatButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.push & button) != 0 || (GameController.repeat & button) != 0;
        }

        public bool IsAccelButton(int button, bool isForce = false)
        {
            if (CheckAutoButton(button))
                return true;

            if (!isForce && !_inputEnabled)
                button = 0;

            return (GameController.accel & button) != 0;
        }

        public void SetAutoButton(int button)
        {
            _autoPushButton = button;
        }

        public bool CheckAutoButton(int button)
        {
            if ((_autoPushButton & button) != 0)
            {
                _autoPushButton = 0;
                return true;
            }

            return false;
        }
    }
}