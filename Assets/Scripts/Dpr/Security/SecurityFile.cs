namespace Dpr.Security
{
	public class SecurityFile
	{
		public static bool Check(string securityFileName)
		{
			return new SdCardAccess().FileExists("sd", securityFileName);
		}
	}
}