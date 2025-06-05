using INL1;

namespace Dpr.SubContents
{
	public struct MatchingParam
	{
		public ushort GameModeID;
		public byte SessionMaxPlayerCount;
		public IlcaNetSessionNetworkType netType;
		public IlcaNetSessionGamingStartMode startMode;
		public string password;
	}
}