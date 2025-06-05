using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    public class BUIActionSelectButton : BUIButtonBase<BUIActionSelectButton>
    {
        private Dictionary<BUIActionList.ActionButtonType, string> _buttonMsgLabels = new Dictionary<BUIActionList.ActionButtonType, string>()
        {
            { BUIActionList.ActionButtonType.Fight,         "msg_ui_btl_00" },
            { BUIActionList.ActionButtonType.Pokemon,       "msg_ui_btl_02" },
            { BUIActionList.ActionButtonType.Bag,           "msg_ui_btl_01" },
            { BUIActionList.ActionButtonType.Escape,        "msg_ui_btl_04" },
            { BUIActionList.ActionButtonType.Return,        "msg_ui_btl_08" },
            { BUIActionList.ActionButtonType.SafariBall,    "msg_ui_btl_SafariCommnadBallMsg" },
            { BUIActionList.ActionButtonType.SafariFood,    "msg_ui_btl_SafariCommnadEsaMsg" },
            { BUIActionList.ActionButtonType.SafariMud,     "msg_ui_btl_SafariCommnadDoroMsg" },
            { BUIActionList.ActionButtonType.SafariEscape,  "msg_ui_btl_SafariCommandEscapeMsg" },
        };
        [SerializeField]
        private Image _lightFrame;
        [SerializeField]
        private Image _iconImage;
        [SerializeField]
        private BUIActionList.ActionButtonType _buttonType;

        public BUIActionList.ActionButtonType ButtonType { get => _buttonType; }

        // TODO
        public bool Initialize(BUIActionList.ActionButtonType type, int index, bool isEnable) { return false; }

        // TODO
        private Sprite GetBagSprite(bool isDemoCapture) { return null; }

        // TODO
        protected override void OnChangeState(StateType type) { }
    }
}