using System;

namespace DPData
{
    [Serializable]
    public struct ZUKAN_PERSONAL_RND_DATA
    {
        private const int PattiiruPersonalRndSize = 4;
        private const int ReservedSize = 17;
        public uint[] PattiiruSeePersonalRnds;
        public uint[] PattiiruGetPersonalRnds;
        public uint[] Reserved;

        // TODO
        public void Clear() { }
    }
}