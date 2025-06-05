using Dpr.BallDeco;
using Pml.PokePara;

namespace Dpr.BattleMatching
{
	public class BattleMatchingPlayerData
	{
		public int stationIndex;
		public string name;
		public uint id;
		public int language;
		public int colorId;
		public int avatarId;
		public int sexId;
		public int battleTeamNum;
		public int battlePokemonNum;
		public PokemonParam[] battleTeam;
		public PokemonParam[] battlePokemon;
		public CapsuleData[] capsule;
		public bool isReady;
		public int resume;
		public int cassetVersion;
	}
}