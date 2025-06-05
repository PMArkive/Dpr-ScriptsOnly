namespace Dpr.NetworkUtils
{
	public struct TranerData
	{
		public byte fashionId;
		public byte bodyType;
		public byte genderid;
		public byte langId;
		public byte tranerRank;
		public TranerCardData cardData;
		
		public bool IsNull { get => cardData.tranerId == 0; }
	}
}