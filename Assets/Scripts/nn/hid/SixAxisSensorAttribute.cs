using System;

namespace nn.hid
{
	[Flags]
	public enum SixAxisSensorAttribute : int
	{
		IsConnected = 1,
		IsInterpolated = 2,
	}
}