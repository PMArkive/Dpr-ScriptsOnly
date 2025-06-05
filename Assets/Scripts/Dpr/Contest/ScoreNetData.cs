using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class ScoreNetData : ANetData<ScoreData>
	{
		public override byte GetDataID { get => (byte)SendDataType.Score; }
	}
}