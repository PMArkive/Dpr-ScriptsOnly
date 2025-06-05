using System;

namespace DPData
{
    [Serializable]
    public struct DENDOU_SAVE_ADD
    {
        public DENDOU_SAVE_ADD_POKE_MEMBER[] data;

        // TODO
        public DENDOU_SAVE_ADD(int langid)
        {
            data = null;
        }
    }
}