using Dpr.Battle.View;
using Dpr.Trainer;

namespace Dpr.Contest
{
	public class AContestPlayerData
	{
		public PlayerType playerType;
		public int index;
		public PlayerInfo playerInfo = new PlayerInfo();
		public PokemonInfo pokemonInfo = new PokemonInfo();
		public BtlvBallInfo ballInfo;
		public PlayerVisualDataModel visualDataModel = new PlayerVisualDataModel();
		public PlayerDanceDataModel danceDataModel = new PlayerDanceDataModel();
		public int modelColorID;
		public TrainerType trainerType;
		public string trainerModelPath;
		public string pokemonModelPath;
		public string ballModelPath;
	}
}