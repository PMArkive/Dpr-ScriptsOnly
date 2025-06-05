using System;

namespace Nintendo.MessageStudio.Lib
{
    public class SizeTagInfo : ITagInfo
    {
	    public ushort Tag { get => 2; }
        public ushort TagGroup { get => 0; }
        public ushort Size { get; set; }

        public SizeTagInfo(byte[] param)
        {
            Size = BitConverter.ToUInt16(param, 0);
        }
    }
}