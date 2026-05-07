using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
    public sealed class AiWazaJudge : AiJudge
    {
        public MainModule m_mainModule;
        public BattleEnv m_pBattleEnv;
        public BTL_POKEPARAM m_atkPoke;
        public BTL_POKEPARAM m_defPoke;
        public Random m_randGenerator = new Random();
        public AiScript m_script;
        public AiScriptHandler m_scriptHandler;
        public AiScriptCommandHandler m_scriptCommandHandler;
        public byte m_pokeID;
        public byte m_atkClientID;
        public BtlPokePos m_atkPos;
        public BtlPokePos m_defPos;
        public byte m_currentWazaPos;
        public WazaNo m_currentWazaNo;
        public ushort m_itemId;
        public bool m_isGoingToStartG;
        public uint m_AIStep;
        public int[][] m_wazaScore = RectangularArrays.RectangularDefaultArray<int>(DefineConstants.BTL_POSIDX_MAX, BattleDefConst.PTL_WAZA_MAX);
        public ScoreStatus[][] m_wazaScoreStatus = RectangularArrays.RectangularScoreStatusArray(DefineConstants.BTL_POSIDX_MAX, BattleDefConst.PTL_WAZA_MAX);
        public bool[] m_usableWazaFlags = new bool[BattleDefConst.PTL_WAZA_MAX];
        public bool[] m_bTokuseiAppeared = new bool[PokeID.NUM];
        public int m_selectWazaScore;
        public byte m_selectWazaPos;
        public BtlPokePos m_selectTargetPos;
        public byte m_currentTargetIdx;
        public bool m_bTargetSideFriend;
        public bool m_bEscape;
        public bool m_bDecided;
        public bool m_bFinished;

        public AiWazaJudge(AiScript aiScript, MainModule mainModule, BattleEnv pBattleEnv, BattleSimulator pBattleSimulator, ulong randSeed, uint ai_bit, byte myClientID) :
            base(myClientID, BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MIN, BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MAX, ai_bit)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_atkPoke = null;
            m_defPoke = null;
            m_script = aiScript;
            m_scriptHandler = null;
            m_scriptCommandHandler = null;

            m_pokeID = PokeID.INVALID;
            m_atkClientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
            m_atkPos = BtlPokePos.POS_NULL;
            m_defPos = BtlPokePos.POS_NULL;
            m_currentWazaNo = WazaNo.NULL;
            m_itemId = (ushort)ItemNo.DUMMY_DATA;
            m_AIStep = 0;
            m_selectWazaScore = 0;
            m_selectWazaPos = 0;
            m_selectTargetPos = BtlPokePos.POS_NULL;
            m_currentTargetIdx = 0;
            m_bTargetSideFriend = false;
            m_bEscape = false;
            m_bDecided = false;
            m_bFinished = false;

            m_randGenerator.Initialize(randSeed);
            m_scriptHandler = new AiScriptHandler();
            m_scriptCommandHandler = new AiScriptCommandHandler(mainModule, pBattleSimulator, pBattleEnv, randSeed);
        }

        public override void Dispose()
        {
            m_scriptHandler = null;

            m_scriptCommandHandler?.Dispose();
            m_scriptCommandHandler = null;
        }

        public void SetJudgeParam(bool[] usableWazaFlags, BtlPokePos pos, byte pokeID, ushort itemId, bool isGoingToStartG)
        {
            m_isGoingToStartG = isGoingToStartG;
            m_pokeID = pokeID;
            m_atkPos = pos;
            m_itemId = itemId;
            m_atkPoke = m_pBattleEnv.GetPokeCon().GetPokeParamConst(pokeID);
            m_atkClientID = MainModule.PokeIDtoClientID(pokeID);

            for (int i=0; i<m_usableWazaFlags.Length; i++)
                m_usableWazaFlags[i] = usableWazaFlags[i];
        }

        public void StartJudge()
        {
            m_AIStep = 0;
            m_bDecided = false;
            m_bFinished = false;
            m_scriptCommandHandler.ResetEscape();
        }

        public override bool IsJudgeFinished()
        {
            return m_bFinished;
        }

        public override void UpdateJudge()
        {
            if (!IsJudgeFinished())
                subProc_Core();
        }

        // TODO
        private void subProc_Core()
        {
            switch ((SeqSubProc_Core)m_AIStep)
            {
                case SeqSubProc_Core.AISTEP_START:
                    wazaScore_Reset();
                    ResetScriptNo();
                    m_AIStep = (uint)SeqSubProc_Core.AISTEP_INIT;
                    break;

                case SeqSubProc_Core.AISTEP_INIT:
                    if (IsAllScriptFinished())
                    {
                        m_AIStep = (uint)SeqSubProc_Core.AISTEP_DONE;
                    }
                    else
                    {
                        m_currentTargetIdx = 0;
                        m_bTargetSideFriend = false;
                        m_currentWazaPos = 0;
                        m_AIStep = (uint)SeqSubProc_Core.AISTEP_CHECK_RUNNABLE_SCRIPT;
                        m_defPos = m_mainModule.GetOpponentPokePos(m_atkPos, 0);
                        m_currentWazaNo = getAttackerWazaNo(m_currentWazaPos);

                        if (!m_usableWazaFlags[m_currentWazaPos])
                        {
                            m_AIStep = (uint)SeqSubProc_Core.AISTEP_SWITCH_WAZA;
                        }
                        else
                        {
                            if (wazaScore_IsScoreless(m_currentWazaPos, m_defPos))
                            {
                                m_AIStep = (uint)SeqSubProc_Core.AISTEP_SWITCH_TARGET;
                            }
                            else
                            {
                                if (m_atkPos != m_defPos)
                                {
                                    m_defPoke = m_pBattleEnv.GetPokeCon().GetFrontPokeDataConst(m_defPos);

                                    if (m_defPoke != null && !m_defPoke.IsDead() &&
                                        (!m_mainModule.IsCompetitorScenarioMode() ||
                                         (!m_atkPoke.IsGMode() && !m_isGoingToStartG) ||
                                         m_atkPoke.IsRaidBoss() ||
                                         WAZADATA.IsDamage(m_currentWazaNo)))
                                    {
                                        m_AIStep = (uint)SeqSubProc_Core.AISTEP_SCRIPT_START;
                                        // TODO: GOTO 4
                                    }
                                    else
                                    {
                                        wazaScore_SetScoreless(m_currentWazaPos, m_defPos);
                                    }
                                }
                                else
                                {
                                    wazaScore_SetScoreless(m_currentWazaPos, m_defPos);
                                }
                            }
                        }
                    }
                    break;

                case SeqSubProc_Core.AISTEP_SWITCH_SCRIPT:
                    UpdateScriptNo();
                    m_AIStep = (uint)SeqSubProc_Core.AISTEP_INIT;
                    break;

                case SeqSubProc_Core.AISTEP_CHECK_RUNNABLE_SCRIPT:
                    break;
            }

            if (m_AIStep == (uint)SeqSubProc_Core.AISTEP_START)
            {
                wazaScore_Reset();
                ResetScriptNo();
                m_AIStep = (uint)SeqSubProc_Core.AISTEP_INIT;
                return;
            }

            if (m_AIStep == (uint)SeqSubProc_Core.AISTEP_INIT)
            {
                while (!IsAllScriptFinished())
                {
                    
                }

                m_AIStep = (uint)SeqSubProc_Core.AISTEP_DONE;
                return;

                m_currentTargetIdx = 0;
                m_bTargetSideFriend = false;
                m_currentWazaPos = 0;
                m_AIStep = (uint)SeqSubProc_Core.AISTEP_CHECK_RUNNABLE_SCRIPT;
                m_defPos = m_mainModule.GetOpponentPokePos(m_atkPos, 0);
                m_currentWazaNo = getAttackerWazaNo(m_currentWazaPos);

                if (!m_usableWazaFlags[m_currentWazaPos])
                {
                    m_AIStep = (uint)SeqSubProc_Core.AISTEP_SWITCH_WAZA;
                }
                else
                {
                    if (wazaScore_IsScoreless(m_currentWazaPos, m_defPos))
                    {
                        m_AIStep = (uint)SeqSubProc_Core.AISTEP_SWITCH_TARGET;
                    }
                    else
                    {
                        if (m_atkPos != m_defPos)
                        {
                            m_defPoke = m_pBattleEnv.GetPokeCon().GetFrontPokeDataConst(m_defPos);

                            if (m_defPoke != null && !m_defPoke.IsDead() &&
                                (!m_mainModule.IsCompetitorScenarioMode() ||
                                 (!m_atkPoke.IsGMode() && !m_isGoingToStartG) ||
                                 m_atkPoke.IsRaidBoss() ||
                                 WAZADATA.IsDamage(m_currentWazaNo)))
                            {
                                m_AIStep = (uint)SeqSubProc_Core.AISTEP_SCRIPT_START;
                                // TODO: GOTO 4
                            }
                            else
                            {
                                wazaScore_SetScoreless(m_currentWazaPos, m_defPos);
                            }
                        }
                        else
                        {
                            wazaScore_SetScoreless(m_currentWazaPos, m_defPos);
                        }
                    }
                }
            }
        }

        private bool incrementTargetIndex()
        {
            var pos = m_bTargetSideFriend ? m_mainModule.GetFrontPosNum(m_atkClientID) : m_mainModule.GetOpponentFrontPosNum(m_atkClientID);

            m_currentTargetIdx++;

            if (m_currentTargetIdx < pos)
                return true;

            if (!m_bTargetSideFriend && m_mainModule.GetRule() != BtlRule.BTL_RULE_SINGLE)
            {
                m_currentTargetIdx = 0;
                m_bTargetSideFriend = true;
                return true;
            }

            return false;
        }

        private BtlPokePos updateTargetPos(bool bFriendSide, byte targetIdx)
        {
            return bFriendSide ? m_mainModule.GetFriendPokePos(m_atkPos, targetIdx) : m_mainModule.GetOpponentPokePos(m_atkPos, targetIdx);
        }

        private bool isTargettingCoveragePos(WazaNo waza_no, BtlPokePos targetPos)
        {
            return m_atkPos != targetPos;
        }

        private BtlPokePos correctTargetPos(BtlPokePos targetPos, byte wazaIdx)
        {
            var waza = getAttackerWazaNo(wazaIdx);

            if (waza == WazaNo.NULL)
                return targetPos;

            var target = WAZADATA.GetWazaTarget(waza);
            var isFriend = m_mainModule.IsFriendPokePos(targetPos, m_atkPos);

            switch (target)
            {
                case WazaTarget.TARGET_FRIEND_USER_SELECT:
                    if (isFriend)
                        return targetPos;
                    else
                        return m_atkPos;

                case WazaTarget.TARGET_FRIEND_SELECT:
                    if (!isFriend)
                    {
                        var bestPos = searchBestScorePos(wazaIdx, m_atkPos, m_mainModule.PosToSide(m_atkPos));

                        if (isTargettingCoveragePos(waza, bestPos) && bestPos != BtlPokePos.POS_NULL)
                            return bestPos;
                    }
                    return targetPos;

                case WazaTarget.TARGET_ENEMY_SELECT:
                    if (isFriend)
                    {
                        var bestPos = searchBestScorePos(wazaIdx, m_atkPos, m_mainModule.GetOpponentSide(m_mainModule.PosToSide(m_atkPos)));

                        if (bestPos != BtlPokePos.POS_NULL)
                            return bestPos;
                    }
                    return targetPos;

                case WazaTarget.TARGET_USER:
                    return m_atkPos;

                default:
                    return targetPos;
            }
        }

        private BtlPokePos searchBestScorePos(byte wazaIdx, BtlPokePos atkPos, BtlSide side)
        {
            bool foundBestPos;
            BtlPokePos bestPos;
            int bestScore;

            if (m_wazaScoreStatus[0][wazaIdx] != ScoreStatus.STATUS_DISABLE)
            {
                var otherSide = m_mainModule.PosToSide(BtlPokePos.POS_1ST_0);

                foundBestPos = false;
                bestPos = BtlPokePos.POS_NULL;
                bestScore = 0;

                if (atkPos != BtlPokePos.POS_1ST_0 && otherSide == side)
                {
                    bestScore = m_wazaScore[0][wazaIdx];
                    bestPos = BtlPokePos.POS_1ST_0;
                    foundBestPos = true;
                }
            }
            else
            {
                foundBestPos = false;
                bestPos = BtlPokePos.POS_NULL;
                bestScore = 0;
            }

            for (int i=1; i<DefineConstants.BTL_POSIDX_MAX; i++)
            {
                if (m_wazaScoreStatus[i][wazaIdx] != ScoreStatus.STATUS_DISABLE)
                {
                    var otherSide = m_mainModule.PosToSide((BtlPokePos)i);

                    if (atkPos != (BtlPokePos)i && otherSide == side)
                    {
                        if (!foundBestPos || bestScore < m_wazaScore[i][wazaIdx])
                        {
                            bestScore = m_wazaScore[i][wazaIdx];
                            bestPos = (BtlPokePos)i;
                        }

                        foundBestPos = true;
                    }
                }
            }

            return bestPos;
        }

        private BTL_POKEPARAM decideTargetPoke(BtlPokePos target_pos)
        {
            return m_pBattleEnv.GetPokeCon().GetFrontPokeDataConst(target_pos);
        }

        private void wazaScore_Reset()
        {
            for (int i=0; i<DefineConstants.BTL_POSIDX_MAX; i++)
            {
                m_wazaScore[i][0] = SCORE_FLAT;
                m_wazaScoreStatus[i][0] = ScoreStatus.STATUS_DISABLE;
                m_wazaScore[i][1] = SCORE_FLAT;
                m_wazaScoreStatus[i][1] = ScoreStatus.STATUS_DISABLE;
                m_wazaScore[i][2] = SCORE_FLAT;
                m_wazaScoreStatus[i][2] = ScoreStatus.STATUS_DISABLE;
                m_wazaScore[i][3] = SCORE_FLAT;
                m_wazaScoreStatus[i][3] = ScoreStatus.STATUS_DISABLE;
            }
        }

        private int wazaScore_Add(byte wazaIdx, BtlPokePos targetPos, int score)
        {
            if (wazaIdx >= BattleDefConst.PTL_WAZA_MAX || (int)targetPos >= DefineConstants.BTL_POSIDX_MAX)
                return 0;

            m_wazaScoreStatus[(int)targetPos][wazaIdx] = ScoreStatus.STATUS_NORMAL;
            m_wazaScore[(int)targetPos][wazaIdx] += score;

            return m_wazaScore[(int)targetPos][wazaIdx];
        }

        private void wazaScore_SetScoreless(byte wazaIdx, BtlPokePos targetPos)
        {
            if (wazaIdx >= BattleDefConst.PTL_WAZA_MAX || (int)targetPos >= DefineConstants.BTL_POSIDX_MAX)
                return;

            m_wazaScoreStatus[(int)targetPos][wazaIdx] = ScoreStatus.STATUS_DISCOURAGE;
            m_wazaScore[(int)targetPos][wazaIdx] = SCORE_DISCOURAGE;
        }

        private bool wazaScore_IsScoreless(byte wazaIdx, BtlPokePos targetPos)
        {
            if (wazaIdx >= BattleDefConst.PTL_WAZA_MAX || (int)targetPos >= DefineConstants.BTL_POSIDX_MAX)
                return false;

            return m_wazaScoreStatus[(int)targetPos][wazaIdx] == ScoreStatus.STATUS_DISCOURAGE &&
                m_wazaScore[(int)targetPos][wazaIdx] == SCORE_DISCOURAGE;
        }

        private void wazaScore_DecideBest()
        {
            var highestScore = SCORE_FLAT;
            ulong sameScores = 0;

            for (int i=0; i<DefineConstants.BTL_POSIDX_MAX; i++)
            {
                for (int j=0; j<BattleDefConst.PTL_WAZA_MAX; j++)
                {
                    if (m_wazaScoreStatus[i][j] == ScoreStatus.STATUS_NORMAL)
                    {
                        if (m_mainModule.IsFriendPokePos(m_atkPos, (BtlPokePos)i) && m_wazaScore[i][j] < SCORE_FLAT)
                        {
                            m_wazaScoreStatus[i][j] = ScoreStatus.STATUS_DISCOURAGE;
                        }
                        else
                        {
                            if (sameScores > 0)
                            {
                                var wazaScore = m_wazaScore[i][j];
                                if (wazaScore <= highestScore)
                                {
                                    if (wazaScore == highestScore)
                                        sameScores++;

                                    continue;
                                }
                            }

                            highestScore = m_wazaScore[i][j];
                            sameScores = 1;
                        }
                    }
                }
            }

            if (sameScores == 0)
            {
                var moves = new byte[BattleDefConst.PTL_WAZA_MAX];
                var moveCount = m_atkPoke.WAZA_GetCount();
                var usableMoves = 0;

                for (byte i=0; i<moveCount; i++)
                {
                    if (m_usableWazaFlags[i])
                    {
                        usableMoves++;
                        moves[usableMoves-1] = i;
                    }
                }

                if (usableMoves == 0)
                {
                    m_bDecided = false;
                    return;
                }

                var randomMove = m_randGenerator.GetValue(moveCount);

                m_selectWazaScore = SCORE_FLAT;
                m_selectWazaPos = moves[randomMove];

                ulong saveWork = 0;
                m_selectTargetPos = calc.DecideWazaTargetAutoForClient(m_mainModule, m_pBattleEnv.GetPokeCon(), m_atkPoke, getAttackerWazaNo(m_selectWazaPos), ref saveWork);
                m_bDecided = true;
                return;
            }
            else
            {
                var randomMove = m_randGenerator.GetValue(sameScores);

                for (int i=0; i<DefineConstants.BTL_POSIDX_MAX; i++)
                {
                    for (byte j=0; j<BattleDefConst.PTL_WAZA_MAX; j++)
                    {
                        var status = m_wazaScoreStatus[i][j];

                        if (status == ScoreStatus.STATUS_NORMAL && m_wazaScore[i][j] == highestScore)
                        {
                            if (randomMove == 0)
                            {
                                m_selectTargetPos = correctTargetPos((BtlPokePos)i, j);
                                m_selectWazaPos = j;
                                m_selectWazaScore = m_wazaScore[i][j];
                                m_bDecided = true;
                                return;
                            }
                            else
                            {
                                randomMove--;
                            }
                        }
                    }
                }
            }
        }

        private void wazaScore_DecideRaidBoss()
        {
            var arr = Arrays.InitializeWithDefaultInstances<ScoreData>(DefineConstants.BTL_POSIDX_MAX * BattleDefConst.PTL_WAZA_MAX);

            var foundMoves = 0;
            for (int i=0; i<DefineConstants.BTL_POSIDX_MAX; i++)
            {
                for (byte j=0; j<BattleDefConst.PTL_WAZA_MAX; j++)
                {
                    var status = m_wazaScoreStatus[i][j];
                    var score = m_wazaScore[i][j];

                    if (status == ScoreStatus.STATUS_NORMAL)
                    {
                        arr[foundMoves].score = score;
                        arr[foundMoves].wazaIdx = j;
                        arr[foundMoves].targetPos = (BtlPokePos)i;

                        foundMoves++;
                    }
                }
            }

            if (foundMoves != 0)
            {
                // Bubble sort
                for (int floor=0; floor<foundMoves; floor++)
                {
                    for (int i=floor+1; i<foundMoves; i++)
                    {
                        var a0 = arr[floor];
                        var a1 = arr[i];

                        if (a0.score < a1.score)
                        {
                            arr[floor] = a1;
                            arr[i] = a0;
                        }
                    }
                }

                if (foundMoves > 9)
                    foundMoves = 10;

                var randScore = m_randGenerator.GetValue((ulong)foundMoves);

                m_selectTargetPos = arr[randScore].targetPos;
                m_selectWazaPos = arr[randScore].wazaIdx;
                m_selectWazaScore = arr[randScore].score;

                m_bDecided = true;
            }
            else
            {
                m_bDecided = false;
            }
        }

        private WazaNo getAttackerWazaNo(byte wazaIdx)
        {
            var wazano = m_atkPoke.WAZA_GetID(wazaIdx);

            if (m_atkPoke.IsGMode() || m_isGoingToStartG)
                return wazano;
            else
                return GWaza.GetGWaza(wazano);
        }

        public bool IsEnemyEscape()
        {
            return m_scriptCommandHandler.IsEscapeSelected();
        }

        public bool IsWazaSelected()
        {
            return m_bDecided;
        }

        public int GetSelectedWazaScore()
        {
            return m_selectWazaScore;
        }

        public void GetSelectedWaza(ref byte wazaIdx, ref BtlPokePos targetPos)
        {
            if (m_bDecided)
            {
                wazaIdx = m_selectWazaPos;
                targetPos = m_selectTargetPos;
            }
        }

        public enum ScoreStatus : int
        {
            STATUS_NORMAL = 0,
            STATUS_DISABLE = 1,
            STATUS_DISCOURAGE = 2,
        }

        private enum SeqSubProc_Core : int
        {
            AISTEP_START = 0,
            AISTEP_INIT = 1,
            AISTEP_SWITCH_SCRIPT = 2,
            AISTEP_CHECK_RUNNABLE_SCRIPT = 3,
            AISTEP_SCRIPT_START = 4,
            AISTEP_SETUP_WAZA = 5,
            AISTEP_SCRIPT_WAIT = 6,
            AISTEP_SWITCH_WAZA = 7,
            AISTEP_SWITCH_TARGET = 8,
            AISTEP_DONE = 9,
        }

        private class ScoreData
        {
            public int score;
            public byte wazaIdx;
            public BtlPokePos targetPos;
        }
    }
}