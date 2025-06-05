using Dpr.NetworkUtils;

namespace Dpr.Battle.Logic.Net.Data
{
	public class BattleCommandSCNetData : ANetData<BattleCommandSC>
	{
		public override byte GetDataID { get => (byte)SendDataTypeBtl.BattleCommandSC; }
	}
}