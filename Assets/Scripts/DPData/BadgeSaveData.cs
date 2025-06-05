using System;

namespace DPData
{
    [Serializable]
    public struct BadgeSaveData
    {
        public const byte DefaultCleanValue = 150;
        public byte[] CleanValues;

        // TODO
        public void Clear() { }
    }
}