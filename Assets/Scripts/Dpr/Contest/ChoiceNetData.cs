using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class ChoiceNetData : ANetData<ChoiceData>
	{
		public override byte GetDataID { get => (byte)SendDataType.Choice; }
	}
}