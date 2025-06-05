using Pml.PokePara;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class BattleResult
    {
        // TODO
        public static void ApplyBattlePartyStateOnly(BATTLE_SETUP_PARAM setupParam, BattleEnv pBattleEnvForServer, BattleEnv pBattleEnvForClient, MainModule mainModule, byte myClientId) { }

        // TODO
        public static void ApplyBattlePartyData(BATTLE_SETUP_PARAM setupParam, BattleEnv pBattleEnvForServer, BattleEnv pBattleEnvForClient, MainModule mainModule, byte myClientId) { }

        // TODO
        private static bool isBossBattle(MainModule pMainModule, BATTLE_SETUP_PARAM pSetupParam) { return false; }

        // TODO
        private static void addFriendshipByBossBattle(PokeParty pParty) { }

        // TODO
        private static bool needRevertItem(MainModule mainModule, BATTLE_SETUP_PARAM pSetupParam) { return false; }

        // TODO
        private static void revertItem(PokeParty pSrcParty, PokeParty pOrgParty) { }

        // TODO
        private static void adjustMaxHP(PokeParty pSrcParty, PokeParty pOrgParty) { }

        // TODO
        private static void resetForm(PokeParty party, PokeParty orgParty) { }

        // TODO
        private static void resetForm(PokemonParam pokeParam, in PokemonParam orgParam) { }

        // TODO
        private static void clearUnknownUBNickName(MainModule mainModule, PokeParty party) { }

        // TODO
        public static void ApplyRecordHeader(BATTLE_SETUP_PARAM setupParam, MainModule mainModule, byte myClientId, BtlResult result) { }

        // TODO
        private unsafe static uint GetRecTurnCount(byte* recordData, uint recordDataSize) { return 0; }

        // TODO
        private static BtlRecordResult1 GetRecResult1(BtlResult result) { return BtlRecordResult1.BTL_RECORD_RESULT_1_WIN; }

        // TODO
        private static BtlRecordResult2 GetRecResult2(MainModule mainModule, BtlResult result) { return BtlRecordResult2.BTL_RECORD_RESULT_2_DEAD; }
    }
}