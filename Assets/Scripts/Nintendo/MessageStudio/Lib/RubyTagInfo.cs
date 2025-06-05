using System;

namespace Nintendo.MessageStudio.Lib
{
    public class RubyTagInfo : ITagInfo
    {
	    public ushort Tag { get => 0; }
        public ushort TagGroup { get => 0; }
        public ushort ParentLength { get; set; }
        public string Ruby { get; set; }

        public RubyTagInfo(byte[] param)
        {
            ParentLength = BitConverter.ToUInt16(param, 0);
            Ruby = BitConverter.ToString(param, 4, BitConverter.ToUInt16(param, 2));
        }
    }
}