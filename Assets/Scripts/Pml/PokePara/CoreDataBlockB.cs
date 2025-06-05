namespace Pml.PokePara
{
	public struct CoreDataBlockB
	{
		public unsafe fixed char nickname[PmlConstants.MONS_NAME_BUFFER_SIZE];
		public unsafe fixed ushort waza[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed byte pp[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed byte pointupUsedCount[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed ushort tamagoWaza[PmlConstants.MAX_WAZA_NUM];
		public ushort hp;
		public uint _bitsA;
		public byte effortG;
		public uint sick;
		public uint palma;
        public unsafe fixed byte padding[12];

		private const int bitsA0_sz = 5;
		private const int bitsA0_loc = 0;
		private const int bitsA1_sz = 5;
		private const int bitsA1_loc = 5;
		private const int bitsA2_sz = 5;
		private const int bitsA2_loc = 10;
		private const int bitsA3_sz = 5;
		private const int bitsA3_loc = 15;
		private const int bitsA4_sz = 5;
		private const int bitsA4_loc = 20;
		private const int bitsA5_sz = 5;
		private const int bitsA5_loc = 25;
		private const int bitsA6_sz = 1;
		private const int bitsA6_loc = 30;
		private const int bitsA7_sz = 1;
		private const int bitsA7_loc = 31;
		private const int bitsA0_mask = 31;
		private const int bitsA1_mask = 992;
		private const int bitsA2_mask = 31744;
		private const int bitsA3_mask = 1015808;
		private const int bitsA4_mask = 32505856;
		private const int bitsA5_mask = 1040187392;
		private const int bitsA6_mask = 1073741824;
		private const int bitsA7_mask = -2147483648;
		
		// TODO
		public uint talentHp { get; set; }
		
		// TODO
		public uint talentAtk { get; set; }
		
		// TODO
		public uint talentDef { get; set; }
		
		// TODO
		public uint talentAgi { get; set; }
		
		// TODO
		public uint talentSpatk { get; set; }
		
		// TODO
		public uint talentSpdef { get; set; }
		
		// TODO
		public bool tamagoFlag { get; set; }
		
		// TODO
		public bool nicknameFlag { get; set; }
	}
}