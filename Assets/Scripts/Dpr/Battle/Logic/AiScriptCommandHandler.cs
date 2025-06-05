using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class AiScriptCommandHandler
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BattleSimulator m_pBattleSimulator;
        private CommandParam m_commandParam;
        private WazaNo[][] m_usedWaza;
        private bool m_isEscapeSelected;
        private Random m_randGenerator;

        // TODO
        public AiScriptCommandHandler(MainModule mainModule, BattleSimulator pBattleSimulator, BattleEnv pBattleEnv, ulong randSeed) { }

        // TODO
        public void Dispose() { }

        // TODO
        public void SetCommandParam(in CommandParam commandParam) { }

        // TODO
        public CommandParam GetCommandParam() { return null; }

        // TODO
        public Random GetRandGenerator() { return null; }

        // TODO
        public MainModule GetMainModule() { return null; }

        // TODO
        public BattleSimulator GetBattleSimulator() { return null; }

        // TODO
        public POKECON GetPokeCon() { return null; }

        // TODO
        public BattleEnv GetBattleEnv() { return null; }

        // TODO
        public BTL_POKEPARAM GetAttackPokeParam() { return null; }

        // TODO
        public BTL_POKEPARAM GetDefensePokeParam() { return null; }

        // TODO
        public BtlPokePos GetAttackPokePos() { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BtlPokePos GetDefensePokePos() { return BtlPokePos.POS_1ST_0; }

        // TODO
        private BtlPokePos GetPokePos(BTL_POKEPARAM pokeParam) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BTL_POKEPARAM GetBenchPokeParam() { return null; }

        // TODO
        public byte GetCurrentWazaIndex() { return 0; }

        // TODO
        public WazaNo GetCurrentWazaNo() { return WazaNo.NULL; }

        // TODO
        public ushort GetCurrentItemNo() { return 0; }

        // TODO
        public BTL_POKEPARAM GetBpp(BtlPokePos pos) { return null; }

        // TODO
        public BTL_POKEPARAM GetBppByAISide(uint ai_side) { return null; }

        // TODO
        public byte AISideToClientID(uint ai_side) { return 0; }

        // TODO
        public BtlPokePos AISideToPokePos(uint ai_side) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public TokuseiNo CheckTokuseiByAISide(int ai_side) { return TokuseiNo.NULL; }

        // TODO
        public uint CalcMaxDamage(BTL_POKEPARAM atkPoke, BTL_POKEPARAM defPoke, bool loss_flag) { return 0; }

        // TODO
        public void StoreUsedWaza(BTL_POKEPARAM bpp) { }

        // TODO
        public bool CheckWazaStored(BTL_POKEPARAM bpp, WazaNo waza_no) { return false; }

        // TODO
        public void ResetEscape() { }

        // TODO
        public void NotifyEscapeByAI() { }

        // TODO
        public bool IsEscapeSelected() { return false; }

        public class CommandParam
        {
            public byte clientID;
            public BTL_POKEPARAM attackPoke;
            public BTL_POKEPARAM defensePoke;
            public byte currentWazaIndex;
            public WazaNo currentWazaNo;
            public ushort currentItemNo;
            public BTL_POKEPARAM currentBenchPoke;
            public bool isGWazaUseTurn;

            public CommandParam()
            {
                Clear();
            }

            public void CopyFrom(CommandParam src)
            {
                clientID = src.clientID;
                attackPoke = src.attackPoke;
                defensePoke = src.defensePoke;
                currentWazaIndex = src.currentWazaIndex;
                currentWazaNo = src.currentWazaNo;
                currentItemNo = src.currentItemNo;
                currentBenchPoke = src.currentBenchPoke;
                isGWazaUseTurn = src.isGWazaUseTurn;
            }

            public void Clear()
            {
                clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
                attackPoke = null;
                defensePoke = null;
                currentBenchPoke = null;
                currentWazaIndex = 0;
                currentWazaNo = WazaNo.NULL;
                currentItemNo = (ushort)ItemNo.DUMMY_DATA;
                isGWazaUseTurn = false;
            }
        }
    }
}