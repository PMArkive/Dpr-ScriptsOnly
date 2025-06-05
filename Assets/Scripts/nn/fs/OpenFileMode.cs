using System;

namespace nn.fs
{
	[Flags]
	public enum OpenFileMode : int
	{
		Read = 1,
		Write = 2,
		AllowAppend = 4,
	}
}