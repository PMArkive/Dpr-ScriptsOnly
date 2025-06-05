using System;

namespace Dpr.Item
{
    [Serializable]
    public struct SaveItem
    {
        public int Count;
        public bool VanishNew;
        public bool FavoriteFlag;
        public bool ShowWazaNameFlag;
        private byte Dummy1;
        private byte Dummy2;
        public ushort SortNumber;
    }
}