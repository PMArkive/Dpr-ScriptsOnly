using System;

namespace DPData
{
    [Serializable]
    public struct PLAYER_NETWORK_DATA
    {
        public byte[] publicKeyBASE64;
        public byte[] bcatFlagArray;
        public ulong nexUniqueId;
        public ulong nexUniqueIdPassword;
        public ushort publicKeyversion;
    }
}