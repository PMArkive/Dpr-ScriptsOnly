using Pml.PokePara;
using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class Common
    {
        private const int FALSE = 0;
        private const int TRUE = 1;
        internal static ushort[] SortTargetsByAgility_rank = new ushort[6];

        // TODO
        public static int GetEventVar(in EventFactor.EventHandlerArgs args, EventVar.Label label) { return 0; }

        // TODO
        public static WazaFailCause GetEventVar_FAIL_CAUSE(in EventFactor.EventHandlerArgs args) { return WazaFailCause.NONE; }

        // TODO
        public static WazaDamageType GetEventVar_DAMAGE_TYPE(in EventFactor.EventHandlerArgs args) { return WazaDamageType.NONE; }

        // TODO
        public static bool RewriteEventVar(in EventFactor.EventHandlerArgs args, EventVar.Label label, int value) { return false; }

        // TODO
        public static bool RewriteEventVar_FAIL_CAUSE(in EventFactor.EventHandlerArgs args, WazaFailCause value) { return false; }

        // TODO
        public static void MulEventVar(in EventFactor.EventHandlerArgs args, EventVar.Label label, int value) { }

        // TODO
        public static bool GetEventVarIfExist(in EventFactor.EventHandlerArgs args, EventVar.Label label, out int value)
        {
            value = 0;
            return false;
        }

        // TODO
        public static object GetEventVarAddress(in EventFactor.EventHandlerArgs args, EventVar.Label label) { return null; }

        // TODO
        public static ushort GetSubID(in EventFactor.EventHandlerArgs args) { return 0; }

        // TODO
        public static int GetWorkValue(in EventFactor.EventHandlerArgs args, byte workIdx) { return 0; }

        // TODO
        public static void SetWorkValue(in EventFactor.EventHandlerArgs args, byte workIdx, int value) { }

        // TODO
        public static void RemoveFactor(in EventFactor.EventHandlerArgs args) { }

        // TODO
        public static BTL_POKEPARAM GetPokeParam(in EventFactor.EventHandlerArgs args, byte pokeID) { return null; }

        // TODO
        public static byte GetExistPokeID(in EventFactor.EventHandlerArgs args, BtlPokePos pos) { return 0; }

        // TODO
        public static byte GetMyAddCounter(in EventFactor.EventHandlerArgs args, BtlSide side) { return 0; }

        // TODO
        public static byte GetWeatherCausePokeID(in EventFactor.EventHandlerArgs args) { return 0; }

        // TODO
        public static BtlRule GetRule(in EventFactor.EventHandlerArgs args) { return BtlRule.BTL_RULE_SINGLE; }

        // TODO
        public static BtlSide PokeIDtoSide(in EventFactor.EventHandlerArgs args, in byte pokeID) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static BtlSide PokeIDtoSide(in EventFactor.EventHandlerArgs args, in EventVar.Label label) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static BtlSide PokeIDtoOpponentSide(in EventFactor.EventHandlerArgs args, in byte pokeID) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static BtlSide GetOpponentSide(in EventFactor.EventHandlerArgs args, BtlSide side) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static bool IsFriendPokeID(in EventFactor.EventHandlerArgs args, byte pokeID1, byte pokeID2) { return false; }

        // TODO
        public static bool IsFriendPokeID(in EventFactor.SkipCheckHandlerArgs args, byte pokeID1, byte pokeID2) { return false; }

        // TODO
        public static BtlGround GetGround(in EventFactor.EventHandlerArgs args) { return BtlGround.BTL_GROUND_NONE; }

        // TODO
        public static BTL_FIELD_SITUATION GetFieldSituation(in EventFactor.EventHandlerArgs args) { return null; }

        // TODO
        public static void AttachSkipCheckHandler(in EventFactor.EventHandlerArgs args, in EventFactor.SkipCheckHandler handler) { }

        // TODO
        public static void DetachSkipCheckHandler(in EventFactor.EventHandlerArgs args) { }

        // TODO
        public static BtlPokePos GetPokeLastPos(in EventFactor.EventHandlerArgs args, byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static byte GetFrontPokeID(in EventFactor.EventHandlerArgs args, in BtlPokePos pos) { return 0; }

        // TODO
        public static BtlPokePos PokeIDtoPokePos(in EventFactor.EventHandlerArgs args, in byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static byte GetTurnCount(in EventFactor.EventHandlerArgs args) { return 0; }

        // TODO
        public static PosEffect.EffectParam GetEffectParam(in EventFactor.EventHandlerArgs args, in BtlPokePos pos, in BtlPosEffect posEffect) { return default; }

        // TODO
        public static PokeAction SearchByPokeID(in EventFactor.EventHandlerArgs args, byte pokeID, bool isSkipGStart, bool isSkipNull = false) { return null; }

        // TODO
        public static WazaRec GetWazaRec(in EventFactor.EventHandlerArgs args) { return null; }

        // TODO
        public static BtlCompetitor GetCompetitor(in EventFactor.EventHandlerArgs args) { return BtlCompetitor.BTL_COMPETITOR_WILD; }

        // TODO
        public static bool IsPlayerSide(in EventFactor.EventHandlerArgs args, in BtlSide side) { return false; }

        // TODO
        public static bool GetSetupStatusFlag(in EventFactor.EventHandlerArgs args, in BTL_STATUS_FLAG flag) { return false; }

        // TODO
        public static bool CheckWazaEffectEnable(in EventFactor.EventHandlerArgs args) { return false; }

        // TODO
        public static bool CheckFieldEffect(in EventFactor.EventHandlerArgs args, in EffectType effType) { return false; }

        // TODO
        public static bool IsExistBenchPoke(in EventFactor.EventHandlerArgs args, in byte pokeID) { return false; }

        // TODO
        public static void SetRecallEnable(in EventFactor.EventHandlerArgs args) { }

        // TODO
        public static bool IsExistPokeChangeRequest(in EventFactor.EventHandlerArgs args) { return false; }

        // TODO
        public static bool IsExistPoke(in EventFactor.EventHandlerArgs args, in byte pokeID) { return false; }

        // TODO
        public static bool IsAllActDoneByPokeID(in EventFactor.EventHandlerArgs args, in byte pokeID) { return false; }

        // TODO
        public static void ConvertForIsolate(in EventFactor.EventHandlerArgs args) { }

        // TODO
        public static bool TokuseiWindow_In(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool TokuseiWindow_Out(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool RecoverHP(in EventFactor.EventHandlerArgs args, in Section_RecoverHP.Description desc) { return false; }

        // TODO
        public static bool DrainHp(in EventFactor.EventHandlerArgs args, in Section_FromEvent_DrainHP.Description desc) { return false; }

        // TODO
        public static bool Damage(in EventFactor.EventHandlerArgs args, in Section_FromEvent_Damage.Description desc) { return false; }

        // TODO
        public static bool ShiftHP(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ShiftHP.Description desc) { return false; }

        // TODO
        public static bool RecoverPP(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RecoverPP.Description desc) { return false; }

        // TODO
        public static bool DecrementPP(in EventFactor.EventHandlerArgs args, in Section_FromEvent_DecrementPP.Description desc) { return false; }

        // TODO
        public static bool CureSick(in EventFactor.EventHandlerArgs args, in Section_CureSick.Description desc) { return false; }

        // TODO
        public static bool CanAddSick(in EventFactor.EventHandlerArgs args, in Section_AddSickCheckFail.Description desc) { return false; }

        // TODO
        public static bool AddSick(in EventFactor.EventHandlerArgs args, in Section_AddSick.Description desc) { return false; }

        // TODO
        public static bool AddSick_Kodawari(in EventFactor.EventHandlerArgs args, byte targetID, WazaNo actWazaNo, WazaNo orgWazaNo) { return false; }

        // TODO
        public static bool RankEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RankEffect.Description desc) { return false; }

        // TODO
        public static bool RankSet(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RankSet.Description desc) { return false; }

        // TODO
        public static bool RankReset(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RankReset.Description desc) { return false; }

        // TODO
        public static bool RankFlat_Recover(in EventFactor.EventHandlerArgs args, in Section_RankFlat_Recover.Description desc) { return false; }

        // TODO
        public static bool RankFlat_Weaken(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RankFlat_Weaken.Description desc) { return false; }

        // TODO
        public static bool SetPower(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetPower.Description desc) { return false; }

        // TODO
        public static bool Kill(in EventFactor.EventHandlerArgs args, in Section_FromEvent_Kill.Description desc) { return false; }

        // TODO
        public static bool ChangeType(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ChangePokeType.Description desc) { return false; }

        // TODO
        public static bool ExtendType(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ExtendPokeType.Description desc) { return false; }

        // TODO
        public static void Message(in EventFactor.EventHandlerArgs args, in Section_FromEvent_Message.Description desc) { }

        // TODO
        public static bool SetTurnFlag(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetTurnFlag.Description desc) { return false; }

        // TODO
        public static bool ResetTurnFlag(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ResetTurnFlag.Description desc) { return false; }

        // TODO
        public static bool SetContFlag(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetContFlag.Description desc) { return false; }

        // TODO
        public static bool ResetContFlag(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ResetContFlag.Description desc) { return false; }

        // TODO
        public static void SetPermFlag(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetPermFlag.Description desc) { }

        // TODO
        public static bool AddSideEffect(in EventFactor.EventHandlerArgs args, in Section_SideEffect_Add.Description desc) { return false; }

        // TODO
        public static bool RemoveSideEffect(in EventFactor.EventHandlerArgs args, in Section_SideEffect_Remove.Description desc) { return false; }

        // TODO
        public static bool SleepSideEffect(in EventFactor.EventHandlerArgs args, in Section_SideEffect_Sleep.Description desc) { return false; }

        // TODO
        public static bool SwapSideEffect(in EventFactor.EventHandlerArgs args, BtlSide side1, BtlSide side2, Section_SideEffect_Swap.SidefEffectSwapCheck check) { return false; }

        // TODO
        public static bool AddFieldEffect(in EventFactor.EventHandlerArgs args, in Section_FieldEffect_Add.Description desc) { return false; }

        // TODO
        public static bool RemoveFieldEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_FieldEffect_Remove.Description desc) { return false; }

        // TODO
        public static BtlWeather GetWeather(in EventFactor.EventHandlerArgs args) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public static BtlWeather GetLocalWeather(in EventFactor.EventHandlerArgs args, byte pokeID) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public static BtlWeather GetWeather_True(in EventFactor.EventHandlerArgs args) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public static BtlWeather GetDefaultWeather(in EventFactor.EventHandlerArgs args) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public static bool ChangeWeather(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ChangeWeather.Description desc) { return false; }

        // TODO
        public static bool AddPosEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_PosEffect_Add.Description desc) { return false; }

        // TODO
        public static void RemovePosEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_RemovePosEffect.Description desc) { }

        // TODO
        public static void UpdatePosEffectParam(in EventFactor.EventHandlerArgs args, in Section_FromEvent_UpdatePosEffectParam.Description desc) { }

        // TODO
        public static bool ChangeTokusei(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ChangeTokusei.Description desc) { return false; }

        // TODO
        public static void SkillSwap(in EventFactor.EventHandlerArgs args, in Section_SkillSwap.Description desc) { }

        // TODO
        public static bool SetItem(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetItem.Description desc) { return false; }

        // TODO
        public static bool SwapItem(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SwapItem.Description desc) { return false; }

        // TODO
        public static void CheckItemReaction(in EventFactor.EventHandlerArgs args, in Section_CheckItemReaction.Description desc) { }

        // TODO
        public static bool UseItem(in EventFactor.EventHandlerArgs args, in Section_UseItemEquip.Description desc) { return false; }

        // TODO
        public static bool UseItem_Force(in EventFactor.EventHandlerArgs args, in Section_FromEvent_UseItem_Force.Description desc) { return false; }

        // TODO
        public static void ConsumeItem(in EventFactor.EventHandlerArgs args, in Section_FromEvent_ConsumeItem.Description desc) { }

        // TODO
        public static ushort GetTamaHiroiBall(in EventFactor.EventHandlerArgs args) { return 0; }

        // TODO
        public static void UpdateWaza(in EventFactor.EventHandlerArgs args, in Section_FromEvent_UpdateWaza.Description desc) { }

        // TODO
        public static void SetPokeCounter(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetCounter.Description desc) { }

        // TODO
        public static bool DelayWazaDamage(in EventFactor.EventHandlerArgs args, in Section_FromEvent_DelayWazaDamage.Description desc) { return false; }

        // TODO
        public static bool QuitBattle(in EventFactor.EventHandlerArgs args, in Section_FromEvent_QuitBattle.Description desc) { return false; }

        // TODO
        public static bool MemberChange(in EventFactor.EventHandlerArgs args, in Section_FromEvent_MemberChange.Description desc) { return false; }

        // TODO
        public static void BattonTouch(in EventFactor.EventHandlerArgs args, in Section_FromEvent_BattonTouch.Description desc) { }

        // TODO
        public static bool Shrink(in EventFactor.EventHandlerArgs args, in Section_FromEvent_Shrink.Description desc) { return false; }

        // TODO
        public static void Relive(in EventFactor.EventHandlerArgs args, in Section_Relive.Description desc) { }

        // TODO
        public static void SetWeight(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetWeight.Description desc) { }

        // TODO
        public static bool PushOut(in EventFactor.EventHandlerArgs args, in Section_PushOut.Description desc) { return false; }

        // TODO
        public static bool InterruptPokeAction(in EventFactor.EventHandlerArgs args, in Section_FromEvent_InterruptAction.Description desc) { return false; }

        // TODO
        public static bool InterruptPokeAction_ByWaza(in EventFactor.EventHandlerArgs args, in Section_FromEvent_InterruptAction_ByWaza.Description desc) { return false; }

        // TODO
        public static bool PostponePokeAction(in EventFactor.EventHandlerArgs args, in Section_FromEvent_PostponeAction.Description desc) { return false; }

        // TODO
        public static bool SwapPoke(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SwapPoke.Description desc) { return false; }

        // TODO
        public static bool Hensin(in EventFactor.EventHandlerArgs args, in Section_FromEvent_Hensin.Description desc) { return false; }

        // TODO
        public static bool BreakIllusion(in EventFactor.EventHandlerArgs args, in Section_FromEvent_BreakIllusion.Description desc) { return false; }

        // TODO
        public static void VanishMessageWindow(in EventFactor.EventHandlerArgs args, in Section_FromEvent_VanishMessageWindow.Description desc) { }

        // TODO
        public static bool CancelTameHide(in EventFactor.EventHandlerArgs args, in Section_FromEvent_TameHideCancel.Description desc) { return false; }

        // TODO
        public static void AddViewEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_AddViewEffect.Description desc) { }

        // TODO
        public static bool FormChange(in EventFactor.EventHandlerArgs args, in Section_FromEvent_FormChange.Description desc) { return false; }

        // TODO
        public static void SetWazaEffectIndex(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetWazaEffectIndex.Description desc) { }

        // TODO
        public static void SetWazaEffectEnable(in EventFactor.EventHandlerArgs args, in Section_FromEvent_SetWazaEffectEnable.Description desc) { }

        // TODO
        public static void FriendshipEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_FriendshipEffect.Description desc) { }

        // TODO
        public static bool InsertWazaAction(in EventFactor.EventHandlerArgs args, in Section_FromEvent_InsertWazaAction.Description desc) { return false; }

        // TODO
        public static bool FreeFallStart(in EventFactor.EventHandlerArgs args, in Section_FromEvent_FreeFallStart.Description desc) { return false; }

        // TODO
        public static void FreeFallRelease(in EventFactor.EventHandlerArgs args, in Section_FreeFall_Release.Description desc) { }

        // TODO
        public static void FreeFallAppearTarget(in EventFactor.EventHandlerArgs args, in Section_AppearFreeFallTarget.Description desc) { }

        // TODO
        public static bool DeadCheck(in EventFactor.EventHandlerArgs args, in Section_FromEvent_DeadCheck.Description desc) { return false; }

        // TODO
        public static ushort CalcAgility(in EventFactor.EventHandlerArgs args, in Section_FromEvent_CalcAgility.Description desc) { return 0; }

        // TODO
        public static byte CalcAgilityOrder(in EventFactor.EventHandlerArgs args, in Section_FromEvent_CalcAgilityOrder.Description desc) { return 0; }

        // TODO
        public static BtlPokePos DecideWazaTargetAuto(in EventFactor.EventHandlerArgs args, byte pokeID, WazaNo wazano) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static bool CheckFloating(in EventFactor.EventHandlerArgs args, in Section_CheckFloating.Description desc) { return false; }

        // TODO
        public static uint GetWeight(in EventFactor.EventHandlerArgs args, in Section_FromEvent_GetWeight.Description desc) { return 0; }

        // TODO
        public static bool CanForceEscape(in EventFactor.EventHandlerArgs args, in Section_Escape_CheckForceSucceed.Description desc) { return false; }

        // TODO
        public static void PlayWazaEffect(in EventFactor.EventHandlerArgs args, in Section_FromEvent_PlayWazaEffect.Description desc) { }

        // TODO
        public static bool CheckSpecialWazaAdditionalEffectOccur(in EventFactor.EventHandlerArgs args, in Section_FromEvent_CheckSpecialWazaAdditionalEffectOccur.Description desc) { return false; }

        // TODO
        public static bool CheckTargetPokeID(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static byte getTaragetPokeID(EventSystem eventSystem, byte index) { return 0; }

        // TODO
        public static bool CheckTargetSide(in EventFactor.EventHandlerArgs args, BtlSide side) { return false; }

        // TODO
        public static bool CheckPokeOrderLast(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckActionDoneOnce(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckUnbreakablePokeItem(ushort monsno, ushort itemID) { return false; }

        // TODO
        public static bool CheckCantChangeItemPoke(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckCantStealWildPoke(in EventFactor.EventHandlerArgs args, byte attackPokeID) { return false; }

        // TODO
        public static bool CheckCantStealPoke(in EventFactor.EventHandlerArgs args, byte attackPokeID, byte targetPokeID) { return false; }

        // TODO
        public static bool CheckTameHidePoke(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static void MagicCoat_CheckSideEffWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void MagicCoat_Wait(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void MagicCoat_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void MulWazaBasePower(in EventFactor.EventHandlerArgs args, uint ratio) { }

        // TODO
        public static void SkipEscapeCalculation(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static bool CheckEscapeExMessage(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static uint GetKillCount(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static bool Boujin_WeatherReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool Boujin_WazaNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static byte GetMezapaType(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static bool GuardWazaSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick guardSick) { return false; }

        // TODO
        public static void Dorobou_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static bool Dorobou_CheckEnable(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static void SortTargetsByAgility(in EventFactor.EventHandlerArgs args, byte[] targetPokeIDAry, uint targetCount, byte myPokeID, bool bDownFriendPriority) { }

        // TODO
        public static Sick CheckPokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { return Sick.NONE; }

        // TODO
        public static bool CheckSimpleEffectOnlyAdvantage(WazaNo waza) { return false; }

        // TODO
        public static void KonoyubiTomare_TemptTarget(in EventFactor.EventHandlerArgs args, byte konoyubiPokeID, TemptTargetPriority temptPriority, TemptTargetCause temptCause) { }

        // TODO
        public static void HandCommon_TemptTarget(in EventFactor.EventHandlerArgs args, byte temptPokeID, TemptTargetPriority temptPriority, TemptTargetCause temptCause) { }

        // TODO
        public static bool Katayaburi_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return false; }

        // TODO
        public static bool CheckFreeFallUserPoke(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckFreeFallPoke(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckShowDown(in EventFactor.EventHandlerArgs args) { return false; }

        // TODO
        public static bool IsClientExist(in EventFactor.EventHandlerArgs args, BTL_CLIENT_ID clientID) { return false; }

        // TODO
        public static bool IsClientFriends(in EventFactor.EventHandlerArgs args, BTL_CLIENT_ID clientID1, BTL_CLIENT_ID clientID2) { return false; }

        // TODO
        public static BTL_PARTY GetPartyData(in EventFactor.EventHandlerArgs args, BTL_CLIENT_ID clientID) { return null; }

        // TODO
        public static BTL_PARTY GetPartyData(in EventFactor.EventHandlerArgs args, byte pokeID) { return null; }

        // TODO
        public static BTL_PARTY GetFriendPartyData(in EventFactor.EventHandlerArgs args, byte pokeID) { return null; }

        // TODO
        public static BtlPokePos GetFriendPokePos(in EventFactor.EventHandlerArgs args, BtlPokePos basePos, byte idx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static BtlPokePos GetOpponentPokePos(in EventFactor.EventHandlerArgs args, BtlPokePos basePos, byte idx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static BtlPokePos GetFacedPokePos(in EventFactor.EventHandlerArgs args, BtlPokePos basePos) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static BtlPokePos GetExistFrontPokePos(in EventFactor.EventHandlerArgs args, byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static bool CheckEvolutionIncompleted(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static bool CheckItemUsable(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static ushort GetUsableItem(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static byte GetAllOpponentFrontPokeID(in EventFactor.EventHandlerArgs args, byte basePokeID, byte[] dst) { return 0; }

        // TODO
        public static byte ExpandExistPokeID(in EventFactor.EventHandlerArgs args, in ExPokePos exPos, byte[] dst_pokeID) { return 0; }

        // TODO
        public static bool CheckChangeEnablePokeExist(in EventFactor.EventHandlerArgs args, byte pokeID) { return false; }

        // TODO
        public static byte GetFightEnableBenchPokeNum(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static byte GetMyBenchIndex(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static byte GetClientCoverPosCount(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static bool AddBonusMoney(in EventFactor.EventHandlerArgs args, uint volume) { return false; }

        // TODO
        public static void SetMoneyDoubleUp(in EventFactor.EventHandlerArgs args, byte pokeID, MoneyDblUpCause cause) { }

        // TODO
        public static bool CheckMemberOutInterruptActionProceeding(in EventFactor.EventHandlerArgs args) { return false; }

        // TODO
        public static void AddMagicCoatAction(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { }

        // TODO
        public static void EnableWazaSubEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static bool IsEscapeEnableBattle(in EventFactor.EventHandlerArgs args) { return false; }
    }
}