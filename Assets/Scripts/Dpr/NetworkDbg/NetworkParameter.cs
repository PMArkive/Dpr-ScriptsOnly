using INL1;

namespace Dpr.NetworkDbg
{
	public class NetworkParameter
	{
		public IlcaNetSessionNetworkType networkType;
		public IlcaNetSessionInitMode matchingMode;
		public ushort gameMode;
		public ushort playerNumMax;
		public string password = string.Empty;
		public IlcaNetSessionGamingStartMode gamingStartMode;
		
		public void Reset()
		{
			networkType = IlcaNetSessionNetworkType.Local;
			matchingMode = IlcaNetSessionInitMode.Random;
			gameMode = (ushort)SessionGameMode.Contest;
			playerNumMax = 2;
			password = string.Empty;
			gamingStartMode = IlcaNetSessionGamingStartMode.Natural;
        }
	}
}