using Dpr.GMS;

namespace Dpr.NetworkUtils
{
	public class GMSTradeResult
	{
		public byte[] coreDatas;
		public GMstationTradeStatusEnum tradeResult = GMstationTradeStatusEnum.NONE;
		public TradeResult result;
		public int pointNo;
		public bool bNeedDelete;
		public bool bIsSuccess;
		
		public void Clear()
		{
			coreDatas = null;
			tradeResult = GMstationTradeStatusEnum.NONE;
			result = TradeResult.None;
			pointNo = -1;
			bNeedDelete = false;
			bIsSuccess = false;
		}
	}
}