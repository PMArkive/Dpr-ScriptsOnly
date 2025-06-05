using Dpr.NetworkDbg;
using INL1;

namespace Dpr.NetworkUtils
{
	public class NetworkParam
	{
		public IlcaNetSessionNetworkType networkType;
		public IlcaNetSessionInitMode matchingMode;
		public IlcaNetSessionGamingStartMode gamingStartMode;
		public IlcaNetSessionCallbackLastEventLeave lastEventLeave;
		public ushort gameMode;
		public ushort playerNumMax;
		public string password = string.Empty;
		public bool ngsLogin;
		public bool bAutoSessionOpen = true;
		public bool bAutoSessionClose = true;
		public uint[] attributeValueArray;
		public uint[] attributeMinValueArray;
		public uint[] attributeMaxValueArray;
		
		public void Reset()
		{
			lastEventLeave = IlcaNetSessionCallbackLastEventLeave.LastCall;
			gameMode = (ushort)SessionGameMode.Contest;
			networkType = IlcaNetSessionNetworkType.Lan;
			matchingMode = IlcaNetSessionInitMode.Random;
			password = string.Empty;
			bAutoSessionOpen = true;
			bAutoSessionClose = true;
			attributeValueArray = null;
			attributeMinValueArray = null;
			attributeMaxValueArray = null;
			ngsLogin = false;
		}
	}
}