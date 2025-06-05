using System;

namespace DPData
{
    [Serializable]
    public struct UgPlayerInfo
    {
        public string name;
        public int id;
        public byte langID;
        public byte sex;
        public byte avatorID;
        public bool isPreset;
    }
}