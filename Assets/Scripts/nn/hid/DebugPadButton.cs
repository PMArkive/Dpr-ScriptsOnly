using System;

namespace nn.hid
{
	[Flags]
	public enum DebugPadButton : int
	{
		A = 1,
		B = 2,
		X = 4,
		Y = 8,
		L = 16,
		R = 32,
		ZL = 64,
		ZR = 128,
		Start = 256,
		Select = 512,
		Left = 1024,
		Up = 2048,
		Right = 4096,
		Down = 8192,
	}
}