namespace Nintendo.MessageStudio.Lib
{
    public class CustomTagInfo : ITagInfo   
    {
	    public ushort Tag { get; private set; }
        public ushort TagGroup { get; private set; }
        public byte[] Params { get; private set; }

        public CustomTagInfo(ushort group, ushort tag, byte[] param)
        {
            Params = param;
            TagGroup = group;
            Tag = tag;
        }
    }
}