using DPData.MysteryGift;

namespace Dpr.UI
{
	public static class GiftMessageUtility
	{
		private const string MessageFileName = "ss_net_mystery_card";
		private const string PokemonTypeMessageFileName = "ss_zkn_type";
		private const string PokemonFormMessageFileName = "ss_zkn_form";

		private const int MonsNameTagIndex = 0;
		private const int PokemonTypeTagIndex = 1;
		private const int FormNameTagIndex = 2;
		private const int ParentNameTagIndex = 3;
		private const int Waza1TagIndex = 4;
		private const int Waza2TagIndex = 5;
		private const int Waza3TagIndex = 6;
		private const int Waza4TagIndex = 7;
		private const int ItemTagIndex = 8;
		private const int PokemonHaveItemTagIndex = 9;
		private const int SeasonTagIndex = 10;
		private const int AnotherNameAndPokemonTypeTagIndex = 11;
		private const int MoneyTagIndex = 12;
		private const int UnderGroundItemTagIndex = 13;
		
		// TODO
		public static bool IsValidMessageLabel(RecvData recvData) { return default; }
		
		// TODO
		public static void SetTitleText(RecvData recvData, UIText[] uiTexts) { }
	}
}