using Dpr.Battle.Logic;
using Dpr.Message;
using Pml;
using Pml.PokePara;

namespace Dpr.Contest
{
	public class PokemonInfo
	{
		public string nickname;
		public bool isZIBAKOIRU;
		public PokemonParam pokeParam;
		public Size size;
		public PokeType wazaType;
		public WazaNo wazaNo;
		public int haveItemNo;
		public string wazaName;
		public float wazaSeqTime;
		public MessageEnumData.MsgLangId langID;
		public BTL_POKEPARAM btlPokeParam;
		
		// TODO
		public string LocalizeNickName() { return default; }
		
		// TODO
		public int GetContestParam(Condition conditionID) { return default; }
	}
}