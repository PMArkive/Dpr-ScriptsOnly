using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class EventSystem
    {
        private MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private PokeActionContainer m_pPokeActionContainer;
        private PokeChangeRequest m_pPokeChangeRequest;
        private SectionContainer m_pSectionContainer;
        private SectionSharedData m_pSectionSharedData;
        private EventVarStack m_variableStack;
        private EventVarSetStack m_variableSetStack;
        private EventVarSet m_pCurrentEventVarSet;
        private uint m_eventLevel;

        public EventSystem(in SetupParam param)
        {
            m_pMainModule = param.pMainModule;
            m_pBattleEnv = param.pBattleEnv;
            m_pPokeActionContainer = param.pPokeActionContainer;
            m_pPokeChangeRequest = param.pPokeChangeRequest;
            m_pSectionContainer = param.pSectionContainer;
            m_pSectionSharedData = param.pSectionSharedData;
            m_variableStack = null;
            m_variableSetStack = null;
            m_pCurrentEventVarSet = null;
            m_eventLevel = 0;

            m_variableStack = new EventVarStack();
            m_variableSetStack = new EventVarSetStack();

            Initialize();
        }

        public void Initialize()
        {
            m_eventLevel = 0;
            m_pCurrentEventVarSet = null;
            m_variableSetStack.ToEmpty();
            m_variableStack.ToEmpty();
        }

        public EventFactorContainer GetFactorContainer()
        {
            return m_pBattleEnv.GetEventFactorContainer();
        }

        public EventFactor AddFactor(EventFactorType factorType, ushort subID, EventPriority mainPri, uint subPri, byte dependID, EventFactor.EventHandlerTable[] handlerTable, byte handlerNum)
        {
            return GetFactorContainer().AddFactor(factorType, subID, mainPri, subPri, dependID, handlerTable, handlerNum, (ushort)m_eventLevel);
        }

        public void RemoveFactor(EventFactor pFactor)
        {
            if (pFactor != null && pFactor.GetExistFlag())
            {
                if (pFactor.GetCallingFlag())
                    pFactor.SetRemoveReserverFlag(true);
                else
                    GetFactorContainer().RemoveFactor(pFactor);
            }
        }

        public void RemoveIsolateFactors()
        {
            var factor = getFirstFactor();
            while (factor != null)
            {
                var next = factor.GetNext();

                if (factor.GetFactorType() == EventFactorType.ISOLATE && factor.GetExistFlag())
                {
                    if (factor.GetCallingFlag())
                        factor.SetRemoveReserverFlag(true);
                    else
                        GetFactorContainer().RemoveFactor(factor);
                }

                factor = next;
            }
        }

        public void SleepFactors(ushort pokeID, EventFactorType factorType)
        {
            var factor = getFirstFactor();
            while (factor != null)
            {
                if (pokeID == factor.GetPokeID() && factor.GetFactorType() == factorType)
                    factor.Sleep();

                factor = factor.GetNext();
            }
        }

        public void WakeFactors(ushort pokeID, EventFactorType factorType)
        {
            var factor = getFirstFactor();
            while (factor != null)
            {
                if (pokeID == factor.GetPokeID() && factor.GetFactorType() == factorType)
                    factor.Wake();

                factor = factor.GetNext();
            }
        }

        public void WakeAllFactors()
        {
            var factor = getFirstFactor();
            while (factor != null)
            {
                factor.Wake();
                factor = factor.GetNext();
            }
        }

        public void CallEvent(EventID eventID)
        {
            callEventCore(eventID, EventFactorType.NUM, true);
        }

        public void CallEvent_Force(EventID eventID)
        {
            callEventCore(eventID, EventFactorType.NUM, false);
        }

        public void CallEvent_TargetType(EventID eventID, EventFactorType type)
        {
            callEventCore(eventID, type, true);
        }

        private void callEventCore(EventID eventID, EventFactorType targetFactorType, bool isSkipCheckEnable)
        {
            m_eventLevel++;
            notifyHandlers(eventID, targetFactorType, isSkipCheckEnable);
            m_eventLevel--;

            if (m_eventLevel - 1 == 0)
            {
                for (var running = getFirstFactor(); running != null; running = running.GetNext())
                    running.SetEventLevel(0);
            }
        }

        private void notifyHandlers(EventID eventID, EventFactorType targetFactorType, bool isSkipCheckEnable)
        {
            var factor = getFirstFactor();
            while (factor != null)
            {
                var handled = nofityHandler(eventID, targetFactorType, isSkipCheckEnable, factor);
                if (handled == null)
                    break;

                if (handled.GetExistFlag())
                    factor = handled;
                else
                    factor = handled.GetNext();
            }
        }

        private EventFactor nofityHandler(EventID eventID, EventFactorType targetFactorType, bool isSkipCheckEnable, EventFactor factor)
        {
            var next = factor.GetNext();

            if (factor.GetCallingFlag() && !factor.GetRecallEnableFlag())
                return next;

            if (factor.GetSleepFlag())
                return next;

            if (targetFactorType != EventFactorType.NUM && factor.GetFactorType() != targetFactorType)
                return next;

            if (factor.GetEventLevel() != 0 && m_eventLevel <= factor.GetEventLevel())
                return next;

            if (!factor.GetExistFlag())
                return next;

            if (eventID == EventID.USE_ITEM_TMP && !factor.GetTempItemFlag())
                return next;

            var handlers = factor.GetHandlerTable();
            for (byte i=0; i<factor.GetHandlerNum(); i++)
            {
                if (handlers[i].eventID == eventID)
                {
                    if (isSkipCheckEnable && checkHandlerSkip(factor, eventID))
                        return next;

                    factor.SetCallingFlag(true);

                    var args = new EventFactor.EventHandlerArgs();
                    args.pMainModule = m_pMainModule;
                    args.pBattleEnv = m_pBattleEnv;
                    args.pPokeActionContainer = m_pPokeActionContainer;
                    args.pPokeChangeRequest = m_pPokeChangeRequest;
                    args.pSectionContainer = m_pSectionContainer;
                    args.pSectionSharedData = m_pSectionSharedData;
                    args.pEventSystem = this;
                    args.pEventVar = m_pCurrentEventVarSet;
                    args.pMyFactor = factor;

                    handlers[i].eventHandler.Invoke(args, factor.GetDependID());

                    if (factor.GetRecallEnableFlag())
                        factor.ResetRecallEnable();
                    else
                        factor.SetCallingFlag(false);

                    if (!factor.GetRemoveReserveFlag())
                        return next;

                    while (next != null)
                    {
                        if (next.GetExistFlag())
                            break;

                        next = factor.GetNext();
                    }

                    if (factor == null)
                        return next;

                    RemoveFactor(factor);
                    return next;
                }
            }

            return next;
        }

        private bool checkHandlerSkip(EventFactor factor, EventID eventID)
        {
            BTL_POKEPARAM param = null;
            if (factor.GetPokeID() != PokeID.INVALID)
                param = m_pBattleEnv.GetPokeCon().GetPokeParam(factor.GetPokeID());

            if (param != null && factor.GetFactorType() == EventFactorType.TOKUSEI)
            {
                if (param.CheckSick(Pml.WazaData.WazaSick.WAZASICK_IEKI))
                    return true;

                if (param.IsTokuseiDisabledByKagakuHenkaGas())
                    return true;

                if (param.HENSIN_Check() && tables.CheckOmmitAfterHensin((TokuseiNo)factor.GetSubID()))
                    return true;

                if (param.IsGMode() && tables.CheckOmmitOnG((TokuseiNo)factor.GetSubID()))
                    return true;
            }


            for (var running = getFirstFactor(); running != null; running = running.GetNext())
            {
                var skipHandler = running.GetSkipCheckHandler();
                if (skipHandler == null)
                    continue;

                if (running.GetSleepFlag())
                    continue;

                if (running.GetFactorType() == EventFactorType.TOKUSEI)
                {
                    var paramConst = m_pBattleEnv.GetPokeCon().GetPokeParamConst(running.GetPokeID());
                    if (paramConst != null)
                    {
                        if (paramConst.CheckSick(Pml.WazaData.WazaSick.WAZASICK_IEKI))
                            continue;

                        if (paramConst.IsTokuseiDisabledByKagakuHenkaGas())
                            continue;
                    }
                }

                var args = new EventFactor.SkipCheckHandlerArgs();
                args.pMainModule = m_pMainModule;
                args.pBattleEnv = m_pBattleEnv;
                args.pMyFactor = running;
                args.eventID = eventID;
                args.factorType = factor.GetFactorType();
                args.subID = factor.GetSubID();
                args.dependID = factor.GetDependID();

                if (skipHandler.Invoke(args))
                    return true;
            }

            return false;
        }

        private EventFactor getFirstFactor()
        {
            return m_pBattleEnv.GetEventFactorContainer().GetFirstFactor();
        }

        public void EVENTVAR_Push()
        {
            m_variableStack.Push();
            m_variableSetStack.Push();
            m_pCurrentEventVarSet = m_variableSetStack.GetCurrent();
        }

        public void EVENTVAR_Pop()
        {
            m_variableSetStack.Pop();
            m_pCurrentEventVarSet = m_variableSetStack.GetCurrent();
            m_variableStack.Pop();
        }

        public void EVENTVAR_CheckStackCleared()
        {
            if (m_variableStack.IsEmpty())
                return;

            m_variableStack.ToEmpty();
            m_variableSetStack.ToEmpty();
            m_pCurrentEventVarSet = m_variableSetStack.GetCurrent();
        }

        public void EVENTVAR_SetValue(EventVar.Label label, int value)
        {
            var variable = m_variableStack.GetNewPoint(label);
            if (variable == null)
                return;

            variable.SetLabel(label);
            variable.SetValue(value);
            m_pCurrentEventVarSet.SetVariable(variable);
        }

        public void EVENTVAR_SetConstValue(EventVar.Label label, int value)
        {
            var variable = m_variableStack.GetNewPoint(label);
            if (variable == null)
                return;

            variable.SetLabel(label);
            variable.SetConstValue(value);
            m_pCurrentEventVarSet.SetVariable(variable);
        }

        public void EVENTVAR_SetRewriteOnceValue(EventVar.Label label, int value)
        {
            var variable = m_variableStack.GetNewPoint(label);
            if (variable == null)
                return;

            variable.SetLabel(label);
            variable.SetRewriteOnceValue(value);
            m_pCurrentEventVarSet.SetVariable(variable);
        }

        public void EVENTVAR_RecoveryRewriteOncePermission(EventVar.Label label)
        {
            m_pCurrentEventVarSet.GetVariable(label)?.RecoveryRewriteOncePermission();
        }

        public void EVENTVAR_SetMulValue(EventVar.Label label, int value, int mulMin, int mulMax)
        {
            var variable = m_variableStack.GetNewPoint(label);
            if (variable == null)
                return;

            variable.SetLabel(label);
            variable.SetMulValue(value, mulMin, mulMax);
            m_pCurrentEventVarSet.SetVariable(variable);
        }

        public bool EVENTVAR_RewriteValue(EventVar.Label label, int value)
        {
            var variable = m_pCurrentEventVarSet.GetVariable(label);
            if (variable == null)
                return false;

            return variable.RewriteValue(value);
        }

        public void EVENTVAR_MulValue(EventVar.Label label, int value)
        {
            var variable = m_pCurrentEventVarSet.GetVariable(label);
            if (variable == null)
                return;

            variable.MulValue(value);
        }

        public int EVENTVAR_GetValue(EventVar.Label label)
        {
            if (EVENTVAR_GetValueIfExist(label, out int value))
                return value;
            else
                return 0;
        }

        public bool EVENTVAR_GetValueIfExist(EventVar.Label label, out int pValue)
        {
            pValue = 0;

            var variable = m_pCurrentEventVarSet.GetVariable(label);
            if (variable == null)
                return false;

            pValue = variable.GetValue();
            return true;
        }

        public void EVENTVAR_SetWorkAddress(EventVar.Label label, object p)
        {
            var variable = m_variableStack.GetNewPoint(label);
            if (variable == null)
                return;

            variable.SetLabel(label);
            variable.SetAddress(p);
            m_pCurrentEventVarSet.SetVariable(variable);
        }

        public object EVENTVAR_GetWorkAddress(EventVar.Label label)
        {
            var variable = m_pCurrentEventVarSet.GetVariable(label);
            if (variable == null)
                return null;

            return variable.GetAddress();
        }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public PokeActionContainer pPokeActionContainer;
            public PokeChangeRequest pPokeChangeRequest;
            public SectionContainer pSectionContainer;
            public SectionSharedData pSectionSharedData;
        }
    }
}