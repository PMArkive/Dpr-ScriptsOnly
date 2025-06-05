using Dpr.Message;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class UIText : TextMeshProUGUI
    {
        [SerializeField]
        private MessageEnumData.UIFontSizeID _sizeId = MessageEnumData.UIFontSizeID.M;
        [SerializeField]
        private bool _useMessage = true;
        [SerializeField]
        private string _messageFile = "ss_xmenu";
        [SerializeField]
        private string _messageId = "SS_xmenu_30";
        [SerializeField]
        private bool _useTag = true;
        [SerializeField]
        private bool _isManual;
        [SerializeField]
        private int _fontMaterialDataIndex = -1;
        [SerializeField]
        private bool _uiTextEnable = true;
        private MessageMsgFile _msgFile;
        private int _messageIndex = -1;

        public bool useTag { get => _useTag; set => _useTag = value; }
        public bool useMessage { get => _useMessage; set => _useMessage = value; }

        protected override void Awake()
        {
            base.Awake();
            if (_uiTextEnable)
                MessageManager.onChangeKanjiMode += OnChangeKanjiMode;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_uiTextEnable)
                MessageManager.onChangeKanjiMode -= OnChangeKanjiMode;
        }

        private void OnChangeKanjiMode(bool isKanji)
        {
            if (_uiTextEnable)
                UpdateMessage(true, MessageEnumData.MsgLangId.Num);
        }

        protected override void Start()
        {
            base.Start();
            if (_uiTextEnable)
            {
                if (FontManager.Instance != null)
                {
                    fontSize = FontManager.Instance.GetFontAssetInfo().GetAbsFontSizeBySizeID(_sizeId);
                    font = FontManager.Instance.GetFontAsset();
                    if (_fontMaterialDataIndex > -1)
                        FontManager.Instance.ChangeFontMaterial(this, _fontMaterialDataIndex);
                }

                if (!_isManual)
                    UpdateMessage(true, MessageEnumData.MsgLangId.Num);
            }
        }

        public void SetupMessage(string messageFile, string messageId)
        {
            if (messageFile != null)
                _messageFile = messageFile;

            _messageId = messageId;
            _msgFile = null;
            _messageIndex = -1;
            _useMessage = true;
            _isManual = true;
            UpdateMessage(true, MessageEnumData.MsgLangId.Num);
        }

        public void SetupMessage(string messageFile, int messageIndex)
        {
            if (messageFile != null)
                _messageFile = messageFile;

            _messageId = null;
            _msgFile = null;
            _messageIndex = messageIndex;
            _useMessage = true;
            _isManual = true;
            UpdateMessage(true, MessageEnumData.MsgLangId.Num);
        }

        public void SetFormattedText(UnityAction onSet, [Optional] string messageFile, [Optional] string messageId)
        {
            if (messageFile != null)
                _messageFile = messageFile;

            if (messageId != null)
                _messageId = messageId;

            onSet.Invoke();
            _useMessage = true;
            _isManual = true;
            UpdateMessage(true, MessageEnumData.MsgLangId.Num);
        }

        public void ChangeLanguage(MessageEnumData.MsgLangId langId)
        {
            if (FontManager.Instance != null)
            {
                fontSize = FontManager.Instance.GetFontAssetInfoByLangId(langId).GetAbsFontSizeBySizeID(_sizeId);
                font = FontManager.Instance.GetFontAssetByLangId(langId);
                if (_fontMaterialDataIndex > -1)
                    FontManager.Instance.ChangeFontMaterial(this, _fontMaterialDataIndex);
            }

            _msgFile = null;
            _useMessage = true;
            _isManual = true;
            UpdateMessage(true, langId);
        }

        private void UpdateMessage(bool isForce = false, MessageEnumData.MsgLangId langId = MessageEnumData.MsgLangId.Num)
        {
            if (_useMessage && !string.IsNullOrEmpty(_messageFile) && (!string.IsNullOrEmpty(_messageId) || _messageIndex > -1))
            {
                if (MessageManager.Instance != null && MessageManager.Instance.IsInitialize)
                {
                    if (langId == MessageEnumData.MsgLangId.Num)
                        langId = MessageManager.Instance.UserLanguageID;

                    if (_msgFile != null)
                    {
                        if (_msgFile.LanguageID == MessageManager.Instance.UserLanguageID && !isForce)
                            return;
                    }

                    _msgFile = MessageManager.Instance.GetMsgFile(_messageFile, langId);
                    if (_msgFile != null)
                    {
                        if (!_useTag)
                        {
                            if (_messageId == null)
                                text = _msgFile.GetSimpleMessage(_messageIndex);
                            else
                                text = _msgFile.GetSimpleMessage(_messageId);
                        }
                        else
                        {
                            MessageTextParseDataModel dataModel;
                            if (_messageId == null)
                                dataModel = _msgFile.GetTextDataModel(_msgFile.GetLabel(_messageIndex));
                            else
                                dataModel = _msgFile.GetTextDataModel(_messageId);

                            if (dataModel != null)
                            {
                                dataModel.ApplyFormat();
                                text = dataModel.GetAllText();
                                dataModel.Dispose();
                            }
                        }
                    }
                }
            }
        }
    }
}