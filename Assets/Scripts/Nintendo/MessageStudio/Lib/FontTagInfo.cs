using System;

namespace Nintendo.MessageStudio.Lib
{
    public class FontTagInfo : ITagInfo
    {
	    public ushort Tag { get => 1; }
        public ushort TagGroup { get => 0; }
        public ushort Index { get; private set; }

        public FontTagInfo(byte[] param)
        {
            Index = BitConverter.ToUInt16(param, 0);
        }
    }
}