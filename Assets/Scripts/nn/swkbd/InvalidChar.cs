using System;

namespace nn.swkbd
{
	[Flags]
	public enum InvalidChar : int
	{
		Space = 2,
		AtMark = 4,
		Percent = 8,
		Slash = 16,
		BackSlash = 32,
		Numeric = 64,
		OutsideOfDownloadCode = 128,
		OutsideOfMiiNickName = 256,
        Force32 = -1,
    }
}