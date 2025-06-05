using System;
using UnityEngine;

namespace Dpr.Message
{
    [Serializable]
    public class MsbtData : ScriptableObject
    {
        public int hash;
        public MessageEnumData.MsgLangId langID;
        public bool isResident;
        public bool isKanji;
        public LabelData[] labelDataArray;
    }
}
