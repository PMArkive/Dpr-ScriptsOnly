using System;

namespace nn.hid
{
	[Flags]
	public enum NpadStyle : int
	{
		None = 0,
		FullKey = 1,
		Handheld = 2,
		JoyDual = 4,
		JoyLeft = 8,
		JoyRight = 16,
		Invalid = 32,
	}
}