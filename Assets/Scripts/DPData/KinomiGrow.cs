using System;

namespace DPData
{
    [Serializable]
    public struct KinomiGrow
    {
        public int tagNo;
        public int harvestCount;
        public int minutes;
        private byte _wet;
        private byte _selfPlant;
        private byte _padding0;
        private byte _padding1;

        public bool wet { get => _wet != 0; set => _wet = value ? (byte)1 : (byte)0; }
        public bool selfPlant { get => _selfPlant != 0; set => _selfPlant = value ? (byte)1 : (byte)0; }
    }
}