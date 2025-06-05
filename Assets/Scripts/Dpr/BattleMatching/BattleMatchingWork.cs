using Dpr.Battle.Logic;
using Dpr.NetworkUtils;
using INL1;
using Pml.PokePara;
using UnityEngine;

namespace Dpr.BattleMatching
{
    public static class BattleMatchingWork
    {
        public static int stationIndex = 0;
        public static int opponentStationIndex = 0;
        public static int hostStationIndex = 0;
        public static IlcaNetSessionNetworkType networkType = 0;
        public static BattleModeID battleModeID = 0;
        public static bool isColiseum = false;
        public static int coliseumTeam = 0;
        public static BtlResult battleResult = BtlResult.BTL_RESULT_LOSE;
        public static BattleMatchingPlayerData[] playerDataList = null;
        public static PokemonNum pokemonNum = 0;
        public static Regulation.LevelRangeType pokemonLevel = Regulation.LevelRangeType.NONE;
        public static bool isBanLegendPokemon = false;
        public static bool isBanSamePokemon = false;
        public static bool isBanSameItem = false;
        public static bool isBanIllegal = false;
        public static PokemonParam[] pokemonParams = null;
        public static int[] orderIndexList = null;
        public static int battleTeamIndex = -1;

        // TODO
        public static void Init() { }

        // TODO
        public static void SetBattleMatchingRule(BattleModeID battleModeID, bool coliseum) { }

        // TODO
        public static void SetBattleTowerRule(bool single) { }

        // TODO
        public static int GetPlayerNum() { return 0; }

        // TODO
        public static int GetPokemonNumMin(PokemonNum type) { return default; }

        // TODO
        public static int GetPokemonNumMax(PokemonNum type) { return default; }

        // TODO
        public static int GetIndexMine() { return 0; }

        // TODO
        public static int GetIndex(int stationIndex) { return 0; }

        // TODO
        public static int[] GetOtherStationIndex() { return null; }

        // TODO
        public static void SetReadyPlayer(int stationIndex) { }

        // TODO
        public static void ResetReadyPlayer() { }

        // TODO
        public static bool GetReadyAllPlayers() { return false; }

        // TODO
        public static void SetResumePlayer(int stationIndex, bool resume) { }

        // TODO
        public static void ResetResumePlayer() { }

        // TODO
        public static bool GetSelectResumeAllPlayer() { return false; }

        // TODO
        public static bool GetResumeAllPlayers() { return false; }

        // TODO
        public static bool GetNotResumePlayer() { return false; }

        // TODO
        public static int[] GetReadyBattleTeams() { return null; }

        // TODO
        public static bool GetReadyAllBattleTeams() { return false; }

        // TODO
        public static int[] GetReadyBattlePokemons() { return null; }

        // TODO
        public static bool GetReadyAllBattlePokemons() { return false; }

        // TODO
        public static void ResetPokemon() { }

        public static void EmitLog(string log, LogType logType = LogType.Log)
        {
            // Empty, probably commented out
        }
    }
}