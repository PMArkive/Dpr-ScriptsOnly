using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public sealed class AffCounter
    {
        private const int COUNTER_MAX = 9999;
        private Data m_data = new Data();

        public ushort GetVoid()
        {
            return m_data.putVoid;
        }

        public ushort GetAdvantage()
        {
            return m_data.putAdvantage;
        }

        public ushort GetDisadvantage()
        {
            return m_data.putDisadvantage;
        }

        public ushort GetRecvVoid()
        {
            return m_data.recvVoid;
        }

        public ushort GetRecvAdvantage()
        {
            return m_data.recvAdvantage;
        }

        public ushort GetRecvDisadvantage()
        {
            return m_data.recvDisadvantage;
        }

        public AffCounter()
        {
            Clear();
        }

        public void CopyFrom(in AffCounter src)
        {
            m_data.CopyFrom(src.m_data);
        }

        public void Clear()
        {
            m_data.putVoid = 0;
            m_data.putAdvantage = 0;
            m_data.putDisadvantage = 0;
            m_data.recvVoid = 0;
            m_data.recvAdvantage = 0;
            m_data.recvDisadvantage = 0;
        }

        public void CountUp(in MainModule mainModule, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, TypeAffinity.AffinityID affinity)
        {
            var attID = attacker.GetID();
            var defID = defender.GetID();

            var attClient = MainModule.PokeIDtoClientID(attID);
            var defClient = MainModule.PokeIDtoClientID(defID);

            var isFriend = mainModule.IsFriendPokeID(attID, defID);

            if (attClient == (byte)BTL_CLIENT_ID.BTL_CLIENT_PLAYER)
            {
                if (!isFriend)
                {
                    if (affinity == TypeAffinity.AffinityID.TYPEAFF_0)
                        CountUp_Core(ref m_data.putVoid);
                    else if (affinity > TypeAffinity.AffinityID.TYPEAFF_1)
                        CountUp_Core(ref m_data.putAdvantage);
                    else if (affinity < TypeAffinity.AffinityID.TYPEAFF_1)
                        CountUp_Core(ref m_data.putDisadvantage);
                }
            }
            else if (defClient == (byte)BTL_CLIENT_ID.BTL_CLIENT_PLAYER)
            {
                if (!isFriend)
                {
                    if (affinity == TypeAffinity.AffinityID.TYPEAFF_0)
                        CountUp_Core(ref m_data.recvVoid);
                    else if (affinity > TypeAffinity.AffinityID.TYPEAFF_1)
                        CountUp_Core(ref m_data.recvAdvantage);
                    else if (affinity < TypeAffinity.AffinityID.TYPEAFF_1)
                        CountUp_Core(ref m_data.recvDisadvantage);
                }
            }
        }

        private void CountUp_Core(ref ushort pCnt)
        {
            if (pCnt < COUNTER_MAX)
                pCnt++;
        }

        private class Data
        {
            public ushort putVoid;
            public ushort putAdvantage;
            public ushort putDisadvantage;
            public ushort recvVoid;
            public ushort recvAdvantage;
            public ushort recvDisadvantage;

            public void CopyFrom(Data src)
            {
                putVoid = src.putVoid;
                putAdvantage = src.putAdvantage;
                putDisadvantage = src.putDisadvantage;
                recvVoid = src.recvVoid;
                recvAdvantage = src.recvAdvantage;
                recvDisadvantage += src.recvDisadvantage;
            }
        }
    }
}