using System;

namespace Nintendo.MessageStudio.Lib
{
    public struct BlockInfo
    {
        public IntPtr Data;
        public byte[] BlockName;
        public uint DataSize;
        public ushort Flags;
        public ushort Padding;
    }
}