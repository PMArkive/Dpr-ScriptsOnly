namespace Pml.PokePara
{
	public static class BoxMarkController
	{
		private const ushort BOXMARK_UNIT_MASK = 3;
		private const ushort BOXMARK_UNIT_BIT_COUNT = 2;
		
		public static BoxMarkColor GetBoxMarkColor(ushort value, BoxMark mark)
		{
			var uVar1 = (mark & 0xf) << 1;
			return (value & 3 << (ulong)uVar1 & 0xffff) >> (ulong)uVar1;
		}
		
		public static ushort SetBoxMarkColor(ushort value, BoxMark mark, BoxMarkColor color)
		{
			var uVar1 = (mark & 0xf) << 1;
			return value & (3 << (ulong)uVar1 ^ 0xffffffffU) & 0xffff | color << (ulong)uVar1;
		}
	}
}