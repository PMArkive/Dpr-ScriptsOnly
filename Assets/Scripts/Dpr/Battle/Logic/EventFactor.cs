namespace Dpr.Battle.Logic
{
    public sealed class EventFactor
    {
        public const uint EVENT_HANDLER_WORK_ELEMS = 7;
        private ushort m_instanceID;
        private EventFactor m_prevFactor;
        private EventFactor m_nextFactor;
        private Data m_data = new Data();

        public EventFactor(ushort factorID)
        {
            m_instanceID = factorID;

            m_prevFactor = null;
            m_nextFactor = null;

            Clear();
        }

        public void CopyFrom(in EventFactor src)
        {
            m_instanceID = src.m_instanceID;
            m_data.CopyFrom(src.m_data);
        }

        public void Clear()
        {
            m_prevFactor = null;
            m_nextFactor = null;

            m_data.Clear();
        }

        public ushort GetInstanceID()
        {
            return m_instanceID;
        }

        public void ClearWork()
        {
            m_data.ClearWork();
        }

        public int[] GetWork()
        {
            return m_data.work;
        }

        public int GetWorkValue(byte workIdx)
        {
            return GetWork()[workIdx];
        }

        public void SetWorkValue(byte workIdx, int value)
        {
            GetWork()[workIdx] = value;
        }

        public void SetTmpItemFlag()
        {
            m_data.tmpItemFlag = true;
        }

        public void SetRecallEnable()
        {
            if (m_data.callingFlag)
                m_data.recallEnableFlag = true;
        }

        public void ResetRecallEnable()
        {
            m_data.recallEnableFlag = false;
        }

        public byte GetPokeID()
        {
            return m_data.pokeID;
        }

        public void AttachSkipCheckHandler(SkipCheckHandler handler)
        {
            m_data.skipCheckHandler = handler;
        }

        public void DetachSkipCheckHandler()
        {
            m_data.skipCheckHandler = null;
        }

        public SkipCheckHandler GetSkipCheckHandler()
        {
            return m_data.skipCheckHandler;
        }

        public void ConvertForIsolate()
        {
            m_data.factorType = EventFactorType.ISOLATE;
        }

        public bool IsIsolateMode()
        {
            return m_data.factorType == EventFactorType.ISOLATE;
        }

        public bool Sleep()
        {
            if (m_data.sleepFlag)
                return false;

            m_data.sleepFlag = true;
            return true;
        }

        public bool Wake()
        {
            if (!m_data.sleepFlag)
                return false;

            m_data.sleepFlag = false;
            return true;
        }

        public void Link(EventFactor next)
        {
            m_nextFactor = next;

            if (next != null)
                next.m_prevFactor = this;
        }

        public void Unlink()
        {
            var prev = m_prevFactor;
            var next = m_nextFactor;

            if (prev != null)
                prev.m_nextFactor = next;

            if (next != null)
                next.m_prevFactor = prev;

            m_prevFactor = null;
            m_nextFactor = null;
        }

        public EventFactor GetNext()
        {
            return m_nextFactor;
        }

        public EventFactor GetPrev()
        {
            return m_prevFactor;
        }

        public ushort GetEventLevel()
        {
            return (ushort)m_data.eventLevel;
        }

        public void SetEventLevel(ushort value)
        {
            m_data.eventLevel = value;
        }

        public EventFactorType GetFactorType()
        {
            return m_data.factorType;
        }

        public uint GetPriority()
        {
            return m_data.priority;
        }

        public byte GetDependID()
        {
            return m_data.dependID;
        }

        public ushort GetSubID()
        {
            return m_data.subID;
        }

        public bool GetExistFlag()
        {
            return m_data.existFlag;
        }

        public bool GetRemoveReserveFlag()
        {
            return m_data.rmReserveFlag;
        }

        public bool GetCallingFlag()
        {
            return m_data.callingFlag;
        }

        public bool GetRecallEnableFlag()
        {
            return m_data.recallEnableFlag;
        }

        public bool GetSleepFlag()
        {
            return m_data.sleepFlag;
        }

        public bool GetTempItemFlag()
        {
            return m_data.tmpItemFlag;
        }

        public EventHandlerTable[] GetHandlerTable()
        {
            return m_data.handlerTable;
        }

        public byte GetHandlerNum()
        {
            return (byte)m_data.numHandlers;
        }

        public void SetFactorType(EventFactorType type)
        {
            m_data.factorType = type;
        }

        public void SetPriority(uint value)
        {
            m_data.priority = value;
        }

        public void SetSubID(ushort value)
        {
            m_data.subID = value;
        }

        public void SetDependID(byte value)
        {
            m_data.dependID = value;
        }

        public void SetPokeID(byte pokeID)
        {
            m_data.pokeID = pokeID;
        }

        public void SetExistFlag(bool value)
        {
            m_data.existFlag = value;
        }

        public void SetRemoveReserverFlag(bool value)
        {
            m_data.rmReserveFlag = value;
        }

        public void SetCallingFlag(bool value)
        {
            m_data.callingFlag = value;
        }

        public void SetHandlerTable(EventHandlerTable[] handlerTable, byte handlerNum)
        {
            m_data.handlerTable = handlerTable;
            m_data.numHandlers = handlerNum;
        }

        public class EventHandlerArgs
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public PokeActionContainer pPokeActionContainer;
            public PokeChangeRequest pPokeChangeRequest;
            public SectionContainer pSectionContainer;
            public SectionSharedData pSectionSharedData;
            public EventSystem pEventSystem;
            public EventVarSet pEventVar;
            public EventFactor pMyFactor;
        }

        public delegate void EventHandler(in EventHandlerArgs args, byte dependID);

        public class EventHandlerTable
        {
            public EventID eventID;
            public EventHandler eventHandler;

            public EventHandlerTable(EventID eventID, EventHandler eventHandler)
            {
                this.eventHandler = eventHandler;
                this.eventID = eventID;
            }
        }

        public class SkipCheckHandlerArgs
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public EventFactor pMyFactor;
            public EventID eventID;
            public EventFactorType factorType;
            public ushort subID;
            public byte dependID;
        }

        public delegate bool SkipCheckHandler(in SkipCheckHandlerArgs args);

        private class Data
        {
            public EventHandlerTable[] handlerTable;
            public SkipCheckHandler skipCheckHandler;
            public EventFactorType factorType;
            public uint priority;
            public ushort subID;
            public byte dependID;
            public byte pokeID;
            public uint eventLevel;
            public uint numHandlers;
            public bool callingFlag;
            public bool recallEnableFlag;
            public bool rmReserveFlag;
            public bool sleepFlag;
            public bool tmpItemFlag;
            public bool existFlag;
            public int[] work = new int[EVENT_HANDLER_WORK_ELEMS];

            public void Clear()
            {
                handlerTable = null;
                skipCheckHandler = null;
                factorType = EventFactorType.WAZA;
                priority = 0;
                subID = 0;
                dependID = 0;
                pokeID = 0;
                eventLevel = 0;
                numHandlers = 0;
                callingFlag = false;
                recallEnableFlag = false;
                rmReserveFlag = false;
                sleepFlag = false;
                tmpItemFlag = false;
                existFlag = false;

                ClearWork();
            }

            public void ClearWork()
            {
                for (int i=0; i<work.Length; i++)
                    work[i] = 0;
            }

            public void CopyFrom(Data src)
            {
                handlerTable = src.handlerTable;
                skipCheckHandler = src.skipCheckHandler;
                factorType = src.factorType;
                priority = src.priority;
                subID = src.subID;
                dependID = src.dependID;
                pokeID = src.pokeID;
                eventLevel = src.eventLevel;
                numHandlers = src.numHandlers;
                callingFlag = src.callingFlag;
                recallEnableFlag = src.recallEnableFlag;
                rmReserveFlag = src.rmReserveFlag;
                sleepFlag = src.sleepFlag;
                tmpItemFlag = src.tmpItemFlag;
                existFlag = src.existFlag;

                for (int i=0; i<work.Length; i++)
                    work[i] = src.work[i];
            }
        }
    }
}