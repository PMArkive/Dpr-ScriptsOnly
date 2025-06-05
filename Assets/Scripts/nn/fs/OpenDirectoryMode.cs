using System;

namespace nn.fs
{
	[Flags]
	public enum OpenDirectoryMode : int
	{
		Directory = 1,
		File = 2,
		All = 3,
	}
}