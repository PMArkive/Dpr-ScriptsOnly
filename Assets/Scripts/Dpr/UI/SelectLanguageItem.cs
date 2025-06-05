using Dpr.Message;
using UnityEngine;

namespace Dpr.UI
{
    public class SelectLanguageItem : SelectOpeningItem
    {
        [SerializeField]
        private MessageEnumData.MsgLangId _langId = MessageEnumData.MsgLangId.USA;
        [SerializeField]
        private bool _useKanji;

        public MessageEnumData.MsgLangId langId { get => _langId; }
        public bool useKanji { get => _useKanji; }
    }
}