using System;

namespace DPData
{
    [Serializable]
    public struct RECORD_ADD_DATA
    {
        public RECORD_HEAD[] head;
        public RECORD_RANKING[] rankingFlag;
    }
}