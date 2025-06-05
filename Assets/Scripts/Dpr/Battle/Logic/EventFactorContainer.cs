namespace Dpr.Battle.Logic
{
    public sealed class EventFactorContainer
    {
        private const uint FACTOR_PER_POKE = 12;
        private const uint FACTOR_MAX_FOR_POKE = 72;
        private const uint FACTOR_MAX_FOR_SIDEEFF = 44;
        private const uint FACTOR_MAX_FOR_POSEFF = 30;
        private const uint FACTOR_MAX_FOR_FIELD = 10;
        private const uint FACTOR_MAX_ALLOWANCE = 16;
        private const uint FACTOR_REGISTER_MAX = 172;

        private EventFactor[] m_factors = new EventFactor[FACTOR_REGISTER_MAX];
        private EventFactor m_pRunningFactor;
        private EventFactor m_pStoredFactor;

        private const uint SUBPRI_BIT_WIDTH = 24;
        private const uint SUBPRI_MAX = 16777215;

        private static uint calcFactorPriority(EventPriority mainPri, uint subPri)
        {
            // TODO: Is there a more natural way to do this?
            return ((9 - (uint)mainPri) * 0x1000000) | subPri;
        }

        private static bool isDependPokeFactorType(EventFactorType factorType)
        {
            switch (factorType)
            {
                case EventFactorType.WAZA:
                case EventFactorType.TOKUSEI:
                case EventFactorType.ITEM:
                    return true;

                default:
                    return false;
            }
        }

        public EventFactorContainer()
        {
            m_pRunningFactor = null;
            m_pStoredFactor = null;

            createFactors();
            storeAllFactors();
        }

        private void createFactors()
        {
            for (ushort i=0; i<m_factors.Length; i++)
                m_factors[i] = new EventFactor(i);
        }

        private void storeAllFactors()
        {
            m_pRunningFactor = null;
            m_pStoredFactor = null;

            for (ushort i=0; i<m_factors.Length; i++)
                storeFactor(m_factors[i]);
        }

        // TODO
        public void CopyFrom(in EventFactorContainer src) { }

        private EventFactor getFactor(ushort instanceID)
        {
            for (ushort i=0; i<m_factors.Length; i++)
            {
                var factor = m_factors[i];
                if (factor.GetInstanceID() == instanceID)
                    return factor;
            }

            return null;
        }

        public void Clear()
        {
            storeAllRunningFactor();
        }

        public EventFactor AddFactor(EventFactorType factorType, ushort subID, EventPriority mainPri, uint subPri, byte dependID, EventFactor.EventHandlerTable[] handlerTable, byte handlerNum, ushort eventLevel)
        {
            if (m_pStoredFactor == null)
                return null;

            m_pStoredFactor.Unlink();
            byte pokeID = isDependPokeFactorType(factorType) ? dependID : (byte)31;

            m_pStoredFactor.Clear();
            m_pStoredFactor.SetPriority(calcFactorPriority(mainPri, subPri));
            m_pStoredFactor.SetFactorType(factorType);
            m_pStoredFactor.SetHandlerTable(handlerTable, handlerNum);
            m_pStoredFactor.SetDependID(dependID);
            m_pStoredFactor.SetSubID(subID);
            m_pStoredFactor.SetPokeID(pokeID);
            m_pStoredFactor.SetEventLevel(eventLevel);
            m_pStoredFactor.SetExistFlag(true);

            addRunningFactor(m_pStoredFactor);

            return m_pStoredFactor;
        }

        public void RemoveFactor(EventFactor pFactor)
        {
            if (m_pRunningFactor == pFactor)
                m_pRunningFactor = pFactor.GetNext();

            storeFactor(pFactor);
        }

        public EventFactor GetFirstFactor()
        {
            return m_pRunningFactor;
        }

        public EventFactor SeekFactor(EventFactorType factorType)
        {
            for (var factor = m_pRunningFactor; factor != null; factor = factor.GetNext())
            {
                if (factor.GetExistFlag() && factor.GetFactorType() == factorType && !factor.GetRemoveReserveFlag())
                    return factor;
            }

            return null;
        }

        public EventFactor SeekFactor(EventFactorType factorType, byte dependID)
        {
            for (var factor = m_pRunningFactor; factor != null; factor = factor.GetNext())
            {
                if (factor.GetExistFlag() && factor.GetFactorType() == factorType && factor.GetDependID() == dependID && !factor.GetRemoveReserveFlag())
                    return factor;
            }

            return null;
        }

        public EventFactor GetNextFactor(EventFactor pFactor, bool isSkipDependIDCheck = false)
        {
            if (pFactor == null)
                return null;

            var next = pFactor.GetNext();
            if (next == null)
                return null;

            if (isSkipDependIDCheck)
            {
                for (; next != null; next = next.GetNext())
                {
                    if (next.GetFactorType() == pFactor.GetFactorType() && !next.GetRemoveReserveFlag())
                        return next;
                }
            }
            else
            {
                for (; next != null; next = next.GetNext())
                {
                    if (next.GetFactorType() == pFactor.GetFactorType() && next.GetDependID() == pFactor.GetDependID() && !next.GetRemoveReserveFlag())
                        return next;
                }
            }

            return null;
        }

        private void storeFactor(EventFactor pFactor)
        {
            pFactor.Unlink();
            pFactor.Clear();
            pFactor.Link(m_pStoredFactor);
            m_pStoredFactor = pFactor;
        }

        private void storeAllRunningFactor()
        {
            var factor = m_pRunningFactor;

            if (factor != null)
            {
                do
                {
                    var next = factor.GetNext();
                    storeFactor(factor);
                    factor.CopyFrom(next);
                }
                while (true); // BUG: Infinite loop????
            }

            m_pRunningFactor = null;
        }

        private EventFactor pickStoredFactor(int instanceID = -1)
        {
            if (m_pStoredFactor == null)
                return null;

            if (instanceID < 0)
            {
                var stored = m_pStoredFactor;
                m_pStoredFactor = stored.GetNext();
                stored.Unlink();
                return m_pStoredFactor;
            }
            else
            {
                // TODO: This for is so confusing...
                for (var factor = m_pStoredFactor; factor != null; factor = factor.GetNext())
                {
                    if (factor.GetInstanceID() != instanceID)
                        continue;

                    if (m_pStoredFactor == factor)
                    {
                        m_pStoredFactor = m_pStoredFactor.GetNext();
                        factor = m_pStoredFactor;
                    }

                    factor.Unlink();
                    return factor;
                }

                return null;
            }
        }

        // TODO
        private void addRunningFactor(EventFactor pNewFactor) { }

        // TODO
        public bool SwapFactorsSideEffect(BtlSide side1, BtlSide side2, BtlSideEffect effect) { return false; }
    }
}