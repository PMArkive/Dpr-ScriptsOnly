namespace Nintendo.MessageStudio.Lib
{
    public class CustomTagInfo : ITagInfo   
    {
	    public ushort Tag { get; set; }
        public ushort TagGroup { get; set; }
        public byte[] Params { get; set; }

        public CustomTagInfo(ushort group, ushort tag, byte[] param)
        {
            Params = param;
            TagGroup = group;
            Tag = tag;
        }
    }
}