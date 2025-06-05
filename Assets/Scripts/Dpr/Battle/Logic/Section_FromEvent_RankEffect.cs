using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankEffect : Section
	{
		public Section_FromEvent_RankEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }
		
		// TODO
		private bool checkTokuseiWindowDisplay(in Description description) { return default; }
		
		// TODO
		private bool checkEffectiveAny(byte targetPokeCount, byte[] targetPokeID, WazaRankEffect rankType, sbyte rankVolume) { return default; }
		
		// TODO
		private bool addRankEffect(in Description description) { return default; }
		
		// TODO
		private StrParam getPreMessage(in Description description) { return default; }
		
		// TODO
		private bool addRankEffect(byte attackerID, BTL_POKEPARAM target, WazaRankEffect effect, int volume, RankEffectCause cause, ushort itemID, uint rankEffSerial, bool isSpFailMessageDisplay, bool isMigawariThrew, bool isStandardMessageEnable, StrParam preMessage, RankEffectViewType effectViewType) { return default; }
		
		// TODO
		private BTL_POKEPARAM getPoke(byte pokeID) { return default; }

		public class Description
		{
			public byte pokeID;
			public byte targetPokeCount;
			public byte[] targetPokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			public WazaRankEffect rankType;
			public sbyte rankVolume;
			public RankEffectCause cause;
			public ushort itemID;
			public uint effectSerial;
			public bool isDisplayTokuseiWindow;
			public bool isStandardMessageDisable;
			public bool isSpFailMessageDisplay;
			public bool byWazaEffect;
			public bool isPreEffectMessageEnable;
			public RankEffectViewType effectViewType;
			public bool isMigawariThrew;
			public StrParam message = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeCount = 0;
				rankType = WazaRankEffect.NONE;
				rankVolume = 0;
				cause = RankEffectCause.OTHER;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				effectSerial = 0;
				isDisplayTokuseiWindow = false;
				isStandardMessageDisable = false;
				isSpFailMessageDisplay = false;
				byWazaEffect = false;
				isPreEffectMessageEnable = false;
				effectViewType = RankEffectViewType.ENABLE;
				isMigawariThrew = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}