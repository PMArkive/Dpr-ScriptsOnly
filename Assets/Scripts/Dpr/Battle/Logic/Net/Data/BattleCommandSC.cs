namespace Dpr.Battle.Logic.Net.Data
{
	public struct BattleCommandSC
	{
		public ulong cmdseqno;
		public byte clientId;
		public byte divmax;
		public byte divcur;
		public byte _padding;
	}
}