namespace Dpr
{
	public static class Regulation
	{
		public enum LevelRangeType : byte
		{
			SAME = 0,
			DRAG_DOWN = 1,
			NONE = 2,
		}

		public struct Data
		{
			public byte select_num_lo;
			public byte select_num_hi;
			public LevelRangeType level_range;
			private byte _bitsA;

			private const int bitsA0_sz = 1;
			private const int bitsA0_loc = 0;
			private const int bitsA1_sz = 1;
			private const int bitsA1_loc = 1;
			private const int bitsA2_sz = 1;
			private const int bitsA2_loc = 2;
			private const int bitsA0_mask = 1;
			private const int bitsA1_mask = 2;
			private const int bitsA2_mask = 4;
			
			public Data(byte pokeNumMin, byte pokeNumMax, LevelRangeType levelRange = LevelRangeType.SAME, bool isEnableLegend = true, bool isEnableSamePoke = true, bool isEnableSameItem = true)
			{
				select_num_lo = pokeNumMin;
				select_num_hi = pokeNumMax;
				level_range = levelRange;
				_bitsA = 0;
				enable_legend = isEnableLegend;
				enable_same_poke = isEnableSamePoke;
				enable_same_item = isEnableSameItem;
			}
			
			public bool enable_legend
			{
				get => ((_bitsA & bitsA0_mask) >> bitsA0_loc) == 1;
				set => _bitsA |= (byte)(value ? bitsA0_mask : 0);
			}
			
			public bool enable_same_poke
			{
                get => ((_bitsA & bitsA1_mask) >> bitsA1_loc) == 1;
                set => _bitsA |= (byte)(value ? bitsA1_mask : 0);
            }
			
			public bool enable_same_item
			{
                get => ((_bitsA & bitsA2_mask) >> bitsA2_loc) == 1;
                set => _bitsA |= (byte)(value ? bitsA2_mask : 0);
            }
		}
	}
}