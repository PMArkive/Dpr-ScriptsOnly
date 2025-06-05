using System;

namespace nn.fs
{
	[Flags]
	public enum WriteOption : int
	{
		None = 0,
		Flush = 1,
	}
}