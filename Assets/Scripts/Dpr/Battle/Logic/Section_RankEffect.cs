using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RankEffect : Section
	{
		public Section_RankEffect(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description desc) { }
		
		// TODO
		private bool checkEffective(in Description desc) { return default; }
		
		// TODO
		private int rankValueChangeEvent(in Description desc) { return default; }
		
		// TODO
		private void rankEffectFixEvent(in Description desc, int volume) { }
		
		// TODO
		private bool checkReflect(in Description desc, int volume) { return default; }
		
		// TODO
		private void reflectRankEffect(in Description desc, int volume) { }

		public class Description
		{
			public byte atkPokeID;
			public BTL_POKEPARAM pTarget;
			public WazaRankEffect effect;
			public int volume;
			public RankEffectCause cause;
			public ushort itemID;
			public uint rankEffSerial;
			public bool canPutFailMessage;
			public bool bMigawariThrew;
			public SimpleEffectFailManager pSimpleEffectFailManager;
			public bool fStdMsg;
			public StrParam preMessage;
			public RankEffectViewType effectViewType;
			
			public Description()
			{
				atkPokeID = PokeID.INVALID;
				pTarget = null;
				pSimpleEffectFailManager = null;
				effect = WazaRankEffect.NONE;
				volume = 0;
				cause = RankEffectCause.OTHER;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				rankEffSerial = 0;
				canPutFailMessage = false;
				bMigawariThrew = false;
				preMessage = null;
				fStdMsg = false;
				effectViewType = RankEffectViewType.DISABLE;
			}
		}

		public class Result
		{
			public bool isValid;
			public int effectedVolume;
		}
	}
}