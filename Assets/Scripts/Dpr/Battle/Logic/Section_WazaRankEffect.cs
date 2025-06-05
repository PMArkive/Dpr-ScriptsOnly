using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaRankEffect : Section
	{
		public Section_WazaRankEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool rankEffect(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager) { return default; }
		
		// TODO
		private bool rankEffectCore(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager) { return default; }

		public class Description
		{
			public WazaParam pWazaParam;
			public BTL_POKEPARAM pAttacker;
			public BTL_POKEPARAM pTarget;
			public uint actionSerialNo;
			public bool fAlmost;
		}

		public class Result
		{
			public bool isEffective;
		}
	}
}