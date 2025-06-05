using DPData;
using Dpr.BallDeco;
using Dpr.Battle.Logic;
using Pml.PokePara;
using XLSXContent;

namespace Dpr.SealPreview
{
	public struct SealPreviewSetupParam
	{
		public ArenaInfo.SheetArenaData arenaData;
		public MYSTATUS?[] trainerParams;
		public PokemonParam[] pokemonParams;
		public AffixSealData[][] affixSealDatas;
		public BtlRule btlRule;
	}
}