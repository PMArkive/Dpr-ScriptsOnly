using System;

namespace DPData
{
    [Serializable]
    public struct TOPMENU_WORK
    {
        public TOPMENUITEM_WORK[] items;
        public TOPMENUITEMTYPE selectType;
    }
}