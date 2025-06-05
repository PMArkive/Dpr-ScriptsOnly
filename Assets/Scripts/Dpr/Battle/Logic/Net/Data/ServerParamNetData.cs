using Dpr.NetworkUtils;

namespace Dpr.Battle.Logic.Net.Data
{
	public class ServerParamNetData : ANetData<ServerParam>
	{
		public override byte GetDataID { get => (byte)SendDataTypeBtl.ServerParam; }
	}
}