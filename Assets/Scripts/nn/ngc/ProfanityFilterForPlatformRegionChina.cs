using System.Runtime.InteropServices;
using System.Text;

namespace nn.ngc
{
	public static class ProfanityFilterForPlatformRegionChina
	{
		public static extern Result CheckProfanityWords(ref bool pOutCheckResult, [In] string pText);
		public static extern Result CheckProfanityWords(ref bool pOutCheckResult, [In] StringBuilder pText);
		public static extern Result MaskProfanityWords([In] [Out] StringBuilder pOutText);
	}
}