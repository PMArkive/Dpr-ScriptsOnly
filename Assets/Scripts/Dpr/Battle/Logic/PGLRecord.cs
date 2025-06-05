using Pml;

namespace Dpr.Battle.Logic
{
    public static class PGLRecord
    {
        // TODO
        public static bool IsNeed(MainModule pMainModule) { return false; }

        // TODO
        public static void PokeIDtoRecordIdx(out bool pIsPlayerSide, out byte pRecordIdx, MainModule pMainModule, byte pokeID)
        {
            pIsPlayerSide = false;
            pRecordIdx = 0;
        }

        // TODO
        public static void Record(BATTLE_PGL_RECORD_SET pBuffer, MainModule pMainModule, BTL_POKEPARAM pDeadPoke, PGLRecord.RecParam pRecParam) { }

        // TODO
        public static void Record(BATTLE_PGL_RECORD_SET pBuffer, MainModule pMainModule, BattleEnv pBattleEnv) { }

        // TODO
        private static BATTLE_PGL_RECORD GetTargetRecord(BATTLE_PGL_RECORD_SET pBuffer, MainModule pMainModule, byte pokeID) { return null; }

        public sealed class RecParam
        {
            public BTL_POKEPARAM attacker;
            public WazaNo wazaID;

            public RecParam(BTL_POKEPARAM _attacker, WazaNo _wazaID)
            {
                attacker = _attacker;
                wazaID = _wazaID;
            }
        }
    }
}