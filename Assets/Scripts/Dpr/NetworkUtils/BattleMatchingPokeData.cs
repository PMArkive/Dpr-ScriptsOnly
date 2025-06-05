namespace Dpr.NetworkUtils
{
	public struct BattleMatchingPokeData
	{
		public byte[] pokeData;
		public SealParam[] sealData;
		public uint attachPokemonId;
		public uint attachPersonalRnd;
		public byte index;
		public byte num;
		public byte is3DEditMode;
		public byte isAppliedTemplate;
		public byte affixSealCount;
	}
}