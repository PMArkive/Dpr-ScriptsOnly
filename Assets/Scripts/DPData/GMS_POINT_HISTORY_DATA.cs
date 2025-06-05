using System;

namespace DPData
{
    [Serializable]
    public struct GMS_POINT_HISTORY_DATA
    {
        public string receiveMonsNickname;
        public string receiveParentName;
        public ushort sendMonsNo;
        public ushort receiveMonsNo;
        public ushort year;
        public byte month;
        public byte day;
        public byte sendMonsFormNo;
        public byte sendMonsSex;
        public byte receiveMonsFormNo;
        public byte receiveMonsSex;
        public byte receiveMonsLanguage;
        public byte receiveMonsParentLanguage;
    }
}