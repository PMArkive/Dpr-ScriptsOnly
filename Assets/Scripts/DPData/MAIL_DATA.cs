namespace DPData
{
	internal struct MAIL_DATA
	{
		public uint writerID;
		public byte sex;
		public byte region;
		public byte version;
		public byte design;
		public string name;
		public MAIL_ICON[] icon;
		public PMS_DATA[] msg;
	}
}