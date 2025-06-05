using System;

namespace nn.hid
{
	[Flags]
	public enum NpadButton : long
	{
		None = 0,
		A = 1,
		B = 2,
		X = 4,
		Y = 8,
		StickL = 16,
		StickR = 32,
		L = 64,
		R = 128,
		ZL = 256,
		ZR = 512,
		Plus = 1024,
		Minus = 2048,
		Left = 4096,
		Up = 8192,
		Right = 16384,
		Down = 32768,
		StickLLeft = 65536,
		StickLUp = 131072,
		StickLRight = 262144,
		StickLDown = 524288,
		StickRLeft = 1048576,
		StickRUp = 2097152,
		StickRRight = 4194304,
		StickRDown = 8388608,
		LeftSL = 16777216,
		LeftSR = 33554432,
		RightSL = 67108864,
		RightSR = 134217728,
	}
}