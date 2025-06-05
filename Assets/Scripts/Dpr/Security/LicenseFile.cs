using System.Text;

namespace Dpr.Security
{
	public class LicenseFile
	{
		private static readonly byte[] INIT_VECTOR = Encoding.UTF8.GetBytes("w1ae5rlz");

		private const string MOUNT_NAME = "sd";
		private const string LICENSE_FILE_NAME = "Dpr.lic";

		public bool IsValid;
		public string OfficeName = string.Empty;
		public string UserName = string.Empty;
		public bool WaterMarkEnable;
		
		// TODO
		public bool Check() { return default; }
		
		// TODO
		private bool Decode(ref byte[] buffer, string user) { return default; }
		
		// TODO
		private string GetUserName() { return default; }
		
		// TODO
		private string GetKeyFromUser(string user) { return default; }
	}
}