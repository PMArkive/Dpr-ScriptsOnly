using nn.account;
using System.Runtime.InteropServices;
using System.Text;

namespace nn.friends
{
	public struct Profile
	{
		// TODO
		public NetworkServiceAccountId GetAccountId() { return default; }
		
		// TODO
		public Nickname GetNickname() { return default; }
		
		// TODO
		public Result GetProfileImageUrl(ref string outUrl, ImageSize imageSize) { return default; }
		
		// TODO
		public bool IsValid() { return default; }

		private static extern NetworkServiceAccountId GetAccountId(Profile profile);
		private static extern Nickname GetNickname(Profile profile);
		private static extern Result GetProfileImageUrl(Profile profile, [In] [Out] StringBuilder outUrl, ImageSize imageSize);
		private static extern bool IsValid(Profile profile);
	}
}