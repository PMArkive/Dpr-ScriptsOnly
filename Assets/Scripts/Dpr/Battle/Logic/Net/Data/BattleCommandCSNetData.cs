using Dpr.NetworkUtils;

namespace Dpr.Battle.Logic.Net.Data
{
	public class BattleCommandCSNetData : ANetData<BattleCommandCS>
	{
		public override byte GetDataID { get => (byte)SendDataTypeBtl.BattleCommandCS; }
	}
}