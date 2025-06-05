using System;

namespace nn.hid
{
	[Flags]
	public enum GestureAttribute : int
	{
		IsNewTouch = 16,
		IsDoubleTap = 256,
	}
}