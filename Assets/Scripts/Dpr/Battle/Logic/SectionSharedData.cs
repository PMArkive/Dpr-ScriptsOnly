﻿namespace Dpr.Battle.Logic
{
    public sealed class SectionSharedData
    {
        private ActionSharedDataStack m_actionSharedDataStack;
        private InterruptAccessor m_interruptAccessor;
        private PartyAllDeadRecorder m_partyAllDeadRecorder;
        private PokemonBattleInRegister m_pokemonBattleInRegister;
        private ushort[] m_itemChangeCounter;
        private byte m_turnCheckStep;
        private ulong m_turnFlag;

        // TODO
        public SectionSharedData(in SetupParam param) { }

        // TODO
        public void Initialize() { }

        // TODO
        public ActionSharedDataStack GetActionSharedDataStack() { return default; }

        // TODO
        public InterruptAccessor GetInterruptAccessor() { return default; }

        // TODO
        public PartyAllDeadRecorder GetPartyAllDeadRecorder() { return default; }

        // TODO
        public PokemonBattleInRegister GetPokemonBattleInRegister() { return default; }

        // TODO
        public byte GetTurnCheckStep() { return 0; }

        // TODO
        public void IncTurnCheckStep() { }

        // TODO
        public void ResetTurnCheckStep() { }

        // TODO
        public ushort GetItemChangeCount(byte pokeID) { return 0; }

        // TODO
        public void IncItemChangeCount(byte pokeID) { }

        // TODO
        public void ClearItemChangeCount() { }

        // TODO
        public bool GetTurnFlag(TurnFlag flag) { return false; }

        // TODO
        public void SetTurnFlag(TurnFlag flag) { }

        // TODO
        public void ResetTurnFlag(TurnFlag flag) { }

        // TODO
        public void ClearTurnFlag() { }

        public class SetupParam { }

        public enum TurnFlag : ulong
        {
            ESCAPE_MESSAGE_DISPLAYED = 0,
            TURN_START_PROCESS_DONE = 1,
            BEFORE_FIRST_FIGHT_PROCESS_DONE = 2,
            RAID_BOSS_EXTRA_ACTION_ADD = 3,
            GWALL_BREAK_EFFECT_DISPLAYED = 4,
            NUM = 5,
        }
    }
}