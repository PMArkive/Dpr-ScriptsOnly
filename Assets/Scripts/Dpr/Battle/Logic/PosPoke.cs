namespace Dpr.Battle.Logic
{
    public sealed class PosPoke
    {
        private State[] m_state = Arrays.InitializeWithDefaultInstances<State>(DefineConstants.BTL_POSIDX_MAX);
        private BtlPokePos[] m_lastPosInst = new BtlPokePos[DefineConstants.BTL_POSIDX_MAX * DefineConstants.BTL_PARTY_MEMBER_MAX];
        private BtlPokePos m_lastPosDmy;

        private void setLastPos(int i, BtlPokePos pos)
        {
            if (i > -1 && i < m_lastPosInst.Length)
                m_lastPosInst[i] = pos;
            else
                m_lastPosDmy = pos;
        }

        private BtlPokePos getLastPos(int i)
        {
            if (i > -1 && i < m_lastPosInst.Length)
                return m_lastPosInst[i];
            else
                return m_lastPosDmy;
        }

        public PosPoke()
        {
            // Empty
        }

        public void CopyFrom(in PosPoke src)
        {
            for (int i=0; i<m_state.Length; i++)
                m_state[i].CopyFrom(src.m_state[i]);

            for (int i=0; i<m_lastPosInst.Length; i++)
                m_lastPosInst[i] = src.m_lastPosInst[i];
        }

        public void Init(MainModule mainModule, POKECON pokeCon)
        {
            for (int i=0; i<m_state.Length; i++)
            {
                m_state[i].fEnable = false;
                m_state[i].existPokeID = PokeID.INVALID;
                m_state[i].clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
            }

            for (int i=0; i<m_lastPosInst.Length; i++)
                m_lastPosInst[i] = BtlPokePos.POS_NULL;

            var maxPos = mainModule.GetValidPosMax();
            for (BtlPokePos i=0; i!=maxPos; i++)
                if (mainModule.IsPokePosExist(i))
                    ExtendPos(mainModule, i);

            for (BtlPokePos i=0; i!=maxPos; i++)
                setInitialFrontPokemon(mainModule, pokeCon, i);
        }

        private void setInitialFrontPokemon(MainModule mainModule, POKECON pokeCon, BtlPokePos pos)
        {
            mainModule.BtlPosToClientID_and_PosIdx(pos, out byte clientID, out byte posIdx);

            if (clientID != (byte)BTL_CLIENT_ID.BTL_CLIENT_NUM)
            {
                var pokeParam = pokeCon.GetClientPokeDataConst(clientID, posIdx);
                if (pokeParam != null && !pokeParam.IsDead())
                {
                    var pokeID = pokeParam.GetID();
                    m_state[(int)pos].existPokeID = pokeID;
                    setLastPos(pokeID, pos);
                }
                else
                {
                    m_state[(int)pos].existPokeID = PokeID.INVALID;
                }
            }
        }

        public void ExtendPos(in MainModule mainModule, BtlPokePos pos)
        {
            if (!m_state[(int)pos].fEnable)
            {
                var clientID = mainModule.BtlPosToClientID(pos);

                if (clientID == (byte)BTL_CLIENT_ID.BTL_CLIENT_NUM)
                {
                    m_state[(int)pos].fEnable = true;
                    m_state[(int)pos].clientID = clientID;
                    m_state[(int)pos].existPokeID = PokeID.INVALID;
                }
            }
        }

        public void PokeOut(byte pokeID)
        {
            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];
                if (state.fEnable && state.existPokeID == pokeID)
                {
                    state.existPokeID = PokeID.INVALID;
                    break;
                }
            }
        }

        public void PokeIn(MainModule mainModule, BtlPokePos pos, byte pokeID, POKECON pokeCon)
        {
            m_state[(int)pos].existPokeID = pokeID;

            setLastPos(pokeID, pos);
            checkConfrontRec(mainModule, pos, pokeCon);
        }

        private void checkConfrontRec(MainModule mainModule, BtlPokePos pos, POKECON pokeCon)
        {
            var targetPokeID = m_state[(int)pos].existPokeID;

            if (targetPokeID == PokeID.INVALID)
                return;

            for (int i=0; i<m_state.Length; i++)
            {
                var otherState = m_state[i];

                if (otherState.fEnable)
                {
                    var otherPokeID = otherState.existPokeID;

                    if (otherPokeID != PokeID.INVALID && otherPokeID != targetPokeID && !mainModule.IsFriendPokeID(otherPokeID, targetPokeID))
                    {
                        pokeCon.GetPokeParam(otherState.existPokeID).Confront_Set(targetPokeID);
                        pokeCon.GetPokeParam(targetPokeID).Confront_Set(otherState.existPokeID);
                    }
                }
            }
        }

        public void Swap(BtlPokePos pos1, BtlPokePos pos2)
        {
            var temp = m_state[(int)pos1];
            m_state[(int)pos1] = m_state[(int)pos2];
            m_state[(int)pos2] = temp;

            updateLastPos(pos1);
            updateLastPos(pos2);
        }

        private void updateLastPos(BtlPokePos pos)
        {
            var pokeID = m_state[(int)pos].existPokeID;
            if (pokeID != PokeID.INVALID)
            {
                if (pokeID < m_lastPosInst.Length)
                    m_lastPosInst[pokeID] = pos;
                else
                    m_lastPosDmy = pos;
            }
        }

        public byte GetClientEmptyPos(byte clientID, BtlPokePos[] pos)
        {
            byte result = 0;

            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];
                if (state.fEnable && state.clientID == clientID && state.existPokeID == PokeID.INVALID)
                {
                    pos[result] = (BtlPokePos)i;
                    result++;
                }
            }

            return result;
        }

        public byte GetClientEmptyPosCount(byte clientID)
        {
            byte result = 0;

            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];

                if (state.fEnable && state.clientID == clientID && state.existPokeID == PokeID.INVALID)
                    result++;
            }

            return result;
        }

        public bool IsExist(byte pokeID)
        {
            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];

                if (state.fEnable && state.existPokeID == PokeID.INVALID)
                    return i != (byte)BtlPokePos.POS_NULL;
            }

            return false;
        }

        public bool IsExistFrontPos(MainModule mainModule, byte pokeID)
        {
            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];

                if (state.fEnable && state.existPokeID == pokeID)
                    return i != (byte)BtlPokePos.POS_NULL && mainModule.IsFrontPos((BtlPokePos)i);
            }

            return false;
        }

        public BtlPokePos GetPokeExistPos(byte pokeID)
        {
            for (int i=0; i<m_state.Length; i++)
            {
                var state = m_state[i];

                if (state.fEnable && state.existPokeID == pokeID)
                    return (BtlPokePos)i;
            }

            return BtlPokePos.POS_NULL;
        }

        public BtlPokePos GetPokeLastPos(byte pokeID)
        {
            if (pokeID > m_lastPosInst.Length)
                return m_lastPosDmy;

            return m_lastPosInst[pokeID];
        }

        public byte GetExistPokeID(BtlPokePos pos)
        {
            return m_state[(int)pos].existPokeID;
        }

        private sealed class State
        {
            public bool fEnable;
            public byte clientID;
            public byte existPokeID;

            public void CopyFrom(State src)
            {
                fEnable = src.fEnable;
                clientID = src.clientID;
                existPokeID = src.existPokeID;
            }
        }
    }
}