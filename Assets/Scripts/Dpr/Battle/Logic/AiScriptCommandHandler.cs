using Pml;
using Pml.Personal;

namespace Dpr.Battle.Logic
{
    public sealed class AiScriptCommandHandler
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BattleSimulator m_pBattleSimulator;
        private CommandParam m_commandParam = new CommandParam();
        private WazaNo[][] m_usedWaza = RectangularArrays.RectangularDefaultArray<WazaNo>(PokeID.NUM, BattleDefConst.PTL_WAZA_MAX);
        private bool m_isEscapeSelected;
        private Random m_randGenerator = new Random();

        public AiScriptCommandHandler(MainModule mainModule, BattleSimulator pBattleSimulator, BattleEnv pBattleEnv, ulong randSeed)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_pBattleSimulator = pBattleSimulator;
            m_isEscapeSelected = false;
            m_randGenerator.Initialize(randSeed);

            for (int i=0; i<PokeID.NUM; i++)
            {
                m_usedWaza[i][0] = WazaNo.NULL;
                m_usedWaza[i][1] = WazaNo.NULL;
                m_usedWaza[i][2] = WazaNo.NULL;
                m_usedWaza[i][3] = WazaNo.NULL;
            }
        }

        public void Dispose()
        {
            m_pBattleSimulator = null;
            m_commandParam?.Clear();
            m_commandParam = null;
            m_usedWaza = null;
            m_randGenerator = null;
        }

        public void SetCommandParam(in CommandParam commandParam)
        {
            m_commandParam.CopyFrom(commandParam);
        }

        public CommandParam GetCommandParam()
        {
            return m_commandParam;
        }

        public Random GetRandGenerator()
        {
            return m_randGenerator;
        }

        public MainModule GetMainModule()
        {
            return m_mainModule;
        }

        public BattleSimulator GetBattleSimulator()
        {
            return m_pBattleSimulator;
        }

        public POKECON GetPokeCon()
        {
            return m_pBattleEnv.GetPokeCon();
        }

        public BattleEnv GetBattleEnv()
        {
            return m_pBattleEnv;
        }

        public BTL_POKEPARAM GetAttackPokeParam()
        {
            return m_commandParam.attackPoke;
        }

        public BTL_POKEPARAM GetDefensePokeParam()
        {
            return m_commandParam.defensePoke;
        }

        public BtlPokePos GetAttackPokePos()
        {
            return GetPokePos(GetAttackPokeParam());
        }

        public BtlPokePos GetDefensePokePos()
        {
            return GetPokePos(GetDefensePokeParam());
        }

        private BtlPokePos GetPokePos(BTL_POKEPARAM pokeParam)
        {
            if (pokeParam == null)
                return BtlPokePos.POS_NULL;

            return m_mainModule.PokeIDtoPokePos(GetPokeCon(), pokeParam.GetID());
        }

        public BTL_POKEPARAM GetBenchPokeParam()
        {
            return m_commandParam.currentBenchPoke;
        }

        public byte GetCurrentWazaIndex()
        {
            return m_commandParam.currentWazaIndex;
        }

        public WazaNo GetCurrentWazaNo()
        {
            return m_commandParam.currentWazaNo;
        }

        public ushort GetCurrentItemNo()
        {
            return m_commandParam.currentItemNo;
        }

        public BTL_POKEPARAM GetBpp(BtlPokePos pos)
        {
            return GetPokeCon().GetFrontPokeDataConst(pos);
        }

        public BTL_POKEPARAM GetBppByAISide(uint ai_side)
        {
            if (ai_side == (uint)AIStatusFlag.CHECK_BENCH)
                return GetBenchPokeParam();

            return GetBpp(AISideToPokePos(ai_side));
        }

        public byte AISideToClientID(uint ai_side)
        {
            if (ai_side == (uint)AIStatusFlag.CHECK_BENCH)
                ai_side = (uint)AIStatusFlag.CHECK_ATTACK;

            return m_mainModule.BtlPosToClientID(AISideToPokePos(ai_side));
        }

        public BtlPokePos AISideToPokePos(uint ai_side)
        {
            switch ((AIStatusFlag)ai_side)
            {
                case AIStatusFlag.CHECK_DEFENCE:
                    return GetDefensePokePos();

                case AIStatusFlag.CHECK_ATTACK:
                    return GetAttackPokePos();

                case AIStatusFlag.CHECK_DEFENCE_FRIEND:
                    {
                        var pos = GetDefensePokePos();
                        if (m_mainModule.GetRule() == BtlRule.BTL_RULE_DOUBLE)
                            return m_mainModule.GetFriendPokePos(pos, 1);
                        else
                            return pos;
                    }

                case AIStatusFlag.CHECK_ATTACK_FRIEND:
                    {
                        var pos = GetAttackPokePos();
                        if (m_mainModule.GetRule() == BtlRule.BTL_RULE_DOUBLE)
                            return m_mainModule.GetFriendPokePos(pos, 1);
                        else
                            return pos;
                    }

                case AIStatusFlag.CHECK_RAID_FRIEND1:
                    {
                        var pos = GetAttackPokePos();
                        if (m_mainModule.GetRule() != BtlRule.BTL_RULE_RAID)
                            return pos;
                        else
                            return m_mainModule.GetFriendPokePos(pos, 0);
                    }

                case AIStatusFlag.CHECK_RAID_FRIEND2:
                    {
                        var pos = GetAttackPokePos();
                        if (m_mainModule.GetRule() != BtlRule.BTL_RULE_RAID)
                            return pos;
                        else
                            return m_mainModule.GetFriendPokePos(pos, 1);
                    }

                case AIStatusFlag.CHECK_RAID_FRIEND3:
                    {
                        var pos = GetAttackPokePos();
                        if (m_mainModule.GetRule() != BtlRule.BTL_RULE_RAID)
                            return pos;
                        else
                            return m_mainModule.GetFriendPokePos(pos, 2);
                    }

                default:
                    return GetAttackPokePos();
            }
        }

        public TokuseiNo CheckTokuseiByAISide(int ai_side)
        {
            BTL_POKEPARAM bpp;
            if (ai_side == (uint)AIStatusFlag.CHECK_BENCH)
                bpp = GetBenchPokeParam();
            else
                bpp = GetPokeCon().GetFrontPokeDataConst(AISideToPokePos((uint)ai_side));

            if (bpp == null)
                return TokuseiNo.NULL;

            if (ai_side == (int)AIStatusFlag.CHECK_ATTACK || ai_side == (int)AIStatusFlag.CHECK_ATTACK_FRIEND)
                return (TokuseiNo)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI_EFFECTIVE);

            var tokuseiEffective = (TokuseiNo)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI_EFFECTIVE);
            if (tokuseiEffective == TokuseiNo.KAGEHUMI ||
                tokuseiEffective == TokuseiNo.ZIRYOKU ||
                tokuseiEffective == TokuseiNo.ARIZIGOKU)
                return tokuseiEffective;

            if (BattleAiSystem.IsTokuseiOpened(bpp.GetID()))
                return tokuseiEffective;

            var paramIDs = new ParamID[] { ParamID.TOKUSEI1, ParamID.TOKUSEI2, ParamID.TOKUSEI3 };
            var monsno = bpp.GetMonsNo();
            var formno = bpp.GetFormNo();
            var tokuseis = Arrays.InitializeWithDefaultInstances<TokuseiNo>(paramIDs.Length);

            ulong tokuseiCount = 0;
            for (int i=0; i<paramIDs.Length; i++)
            {
                var monTokusei = (TokuseiNo)calc.PERSONAL_GetParam(monsno, formno, paramIDs[i]);
                if (monTokusei != TokuseiNo.NULL)
                {
                    tokuseis[tokuseiCount] = monTokusei;
                    tokuseiCount++;
                }
            }

            if (tokuseiCount == 0)
                return tokuseiEffective;

            return tokuseis[m_randGenerator.GetValue(tokuseiCount)];
        }

        public uint CalcMaxDamage(BTL_POKEPARAM atkPoke, BTL_POKEPARAM defPoke, bool loss_flag)
        {
            var atkPokeID = atkPoke.GetID();
            var defPokeID = defPoke.GetID();

            ushort maxDmg = 0;
            for (byte i=0; i!=atkPoke.WAZA_GetCount(); i++)
            {
                var dmg = m_pBattleSimulator.CalcDamage(atkPokeID, defPokeID, atkPoke.WAZA_GetID(i), true, loss_flag);
                if (dmg > maxDmg)
                    maxDmg = dmg;
            }

            return maxDmg;
        }

        public void StoreUsedWaza(BTL_POKEPARAM bpp)
        {
            var prevWaza = bpp.GetPrevWazaID();
            var usedWaza = m_usedWaza[bpp.GetID()];

            if (usedWaza[0] == prevWaza)
                return;
            else if (usedWaza[0] == WazaNo.NULL)
            {
                usedWaza[0] = prevWaza;
                return;
            }

            if (usedWaza[1] == prevWaza)
                return;
            else if (usedWaza[1] == WazaNo.NULL)
            {
                usedWaza[1] = prevWaza;
                return;
            }

            if (usedWaza[2] == prevWaza)
                return;
            else if (usedWaza[2] == WazaNo.NULL)
            {
                usedWaza[2] = prevWaza;
                return;
            }

            if (usedWaza[3] == prevWaza)
                return;
            else if (usedWaza[3] == WazaNo.NULL)
            {
                usedWaza[3] = prevWaza;
                return;
            }
        }

        public bool CheckWazaStored(BTL_POKEPARAM bpp, WazaNo waza_no)
        {
            var usedWaza = m_usedWaza[bpp.GetID()];

            return (usedWaza[0] != WazaNo.NULL && usedWaza[0] == waza_no) ||
                   (usedWaza[1] != WazaNo.NULL && usedWaza[1] == waza_no) ||
                   (usedWaza[2] != WazaNo.NULL && usedWaza[2] == waza_no) ||
                   (usedWaza[3] != WazaNo.NULL && usedWaza[3] == waza_no);
        }

        public void ResetEscape()
        {
            m_isEscapeSelected = false;
        }

        public void NotifyEscapeByAI()
        {
            m_isEscapeSelected = true;
        }

        public bool IsEscapeSelected()
        {
            return m_isEscapeSelected;
        }

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