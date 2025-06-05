using System;

namespace DPData
{
    [Serializable]
    public struct _FIELDOBJ_SAVE
    {
        public const int MAX = 1000;
        public FIELD_OBJ_SAVE_DATA[] fldobj_sv;
    }
}