using Dpr.NetworkUtils;

namespace Dpr.Battle.Logic.Net.Data
{
	public class SignalNetData : ANetData<Signal>
	{
		public override byte GetDataID { get => (byte)SendDataTypeBtl.Signal; }
	}
}