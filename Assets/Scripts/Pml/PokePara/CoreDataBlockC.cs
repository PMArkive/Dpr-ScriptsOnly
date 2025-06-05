namespace Pml.PokePara
{
	public struct CoreDataBlockC
	{
		public const int POKEJOB_LEN = 14;

        public unsafe fixed char pastParentsName[PmlConstants.PERSON_NAME_BUFFER_SIZE];
		public byte pastParentsSex;
		public byte pastParentLangID;
		public byte ownedByOthers;
		public ushort othersFriendshipTrainerId;
		public byte othersFriendship;
		public byte othersMemoriesLevel;
		public byte othersMemoriesCode;
		public byte othersMemoriesFeel;
		public ushort othersMemoriesData;
        public unsafe fixed byte pokejob[POKEJOB_LEN];
		public byte enjoy;
		public byte nadeNadeValue;
		public byte getCassette;
		public byte battleRomMark;
		public byte padding_1;
		public byte padding_2;
		public byte langId;
		public uint multiWork;
		public byte equipRibbon;
        public unsafe fixed byte padding[15];
	}
}