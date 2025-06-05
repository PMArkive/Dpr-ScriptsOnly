using System;

namespace Nintendo.MessageStudio.Lib
{
    public class ColorTagInfo : ITagInfo
    {
	    public ushort Tag { get => 3; }
        public ushort TagGroup { get => 0; }
        public LMSColor Color { get; set; }
        public ushort Index { get; set; }

        public ColorTagInfo(byte[] param)
        {
            if (param.Length == 2)
                Index = BitConverter.ToUInt16(param, 0);
            else if (param.Length == 4)
                Color = new LMSColor(param[0], param[1], param[2], param[3]);
        }
    }
}