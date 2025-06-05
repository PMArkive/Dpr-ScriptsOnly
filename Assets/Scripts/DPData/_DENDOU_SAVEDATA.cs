using System;

namespace DPData
{
    [Serializable]
    public struct _DENDOU_SAVEDATA
    {
        public DENDOU_RECORD[] record;
        public uint savePoint;
        public uint latestNumber;

        // TODO
        public _DENDOU_SAVEDATA(int a)
        {
            record = null;
            savePoint = 0;
            latestNumber = 0;
        }
    }
}