using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExecStart : Section
	{
		public Section_WazaExecStart(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			var wazaParam1 = new WazaParam();
			var wazaParam2 = new WazaParam();
			var pokeSet = new PokeSet();

			var handlerPrio = ActPri.ToHandlerPri(description.pPokemonAction.priority);
			var wazaPrio = ActPri.ToWazaOrgPri(description.pPokemonAction.priority);

			var action = description.pPokemonAction;
			var actionDesc = action.actionDesc;
			var bpp = action.bpp;

			var reqwazaWork = new REQWAZA_WORK()
			{
				wazaID = WazaNo.NULL,
				targetPos = BtlPokePos.POS_NULL,
			};

			if (!bpp.IsGMode())
			{
				var encoreWaza = CheckEncoreWazaChange(action);
				if (encoreWaza != WazaNo.NULL)
				{
					GetEventLauncher().Event_ReplaceActWaza(bpp, action.actionParam_Fight.waza, encoreWaza);
					var encoreTargetPos = calc.DecideWazaTargetAuto(GetMainModule(), GetBattleEnv().GetPokeCon(), bpp, encoreWaza);
					action.actionParam_Fight.waza = encoreWaza;
					action.actionParam_Fight.targetPos = encoreTargetPos;
                }
			}

			var waza = action.actionParam_Fight.waza;
			var calculatedWaza = PokeAction.GetWazaID(description.pPokemonAction);

			var targetPos = action.actionParam_Fight.targetPos;
			var aimTargetID = action.actionParam_Fight.aimTargetID;

			var isWazaLock = bpp.CheckSick(WazaSick.WAZASICK_WAZALOCK);
			var isTameLock = bpp.CheckSick(WazaSick.WAZASICK_TAMELOCK);

			if (GWaza.IsGWaza(calculatedWaza))
			{
				GetServerCommandPutter().AddWazaHandler(bpp.GetID(), waza, handlerPrio);
				calculatedWaza = GetEventLauncher().Event_ChangeGWaza(bpp, calculatedWaza, waza);
                GetServerCommandPutter().RemoveWazaHandler(bpp.GetID(), waza);
            }

            GetServerCommandPutter().AddWazaHandler(bpp.GetID(), calculatedWaza, handlerPrio);
            event_StartWazaSeq(bpp, calculatedWaza);
			GetEventLauncher().Event_GetWazaParam(calculatedWaza, waza, waza, wazaPrio, bpp, wazaParam1);

			if (checkWazaFail_1st(bpp, wazaParam1, actionDesc, isWazaLock, isTameLock))
			{
				pResult.wazaParam.CopyFrom(wazaParam1);
				pResult.targetPos = targetPos;
				pResult.isWazaEffective = false;
				pResult.isPPUsed = false;
				pResult.resultCode = ResultCode.FAILED;
				return;
			}

			if (!GetEventLauncher().Event_GetReqWazaParam(bpp, waza, targetPos, reqwazaWork))
			{
				GetServerCommandPutter().Message_Waza(bpp.GetID(), waza, targetPos, false);
				GetEventLauncher().Event_GetWazaParam(waza, waza, waza, wazaPrio, bpp, wazaParam2);
				registerWazaTargets(bpp, wazaParam2, targetPos, aimTargetID, pokeSet);

				var isPPUsedReq = decrementPP(bpp, waza, calculatedWaza, pokeSet);

				onFailed(bpp, waza, WazaFailCause.OTHER);

				pResult.wazaParam.CopyFrom(wazaParam1);
				pResult.targetPos = targetPos;
				pResult.isPPUsed = isPPUsedReq;
				pResult.isWazaEffective = false;
				pResult.resultCode = ResultCode.FAILED;
				return;
			}

			var reqWazaID = reqwazaWork.wazaID;
			var isWazaKept = reqWazaID == WazaNo.NULL;

			if (!isWazaKept)
			{
				var reqTargetPos = reqwazaWork.targetPos;
				aimTargetID = GetPokeID(reqTargetPos);

				GetServerCommandPutter().AddWazaHandler(bpp.GetID(), reqWazaID, handlerPrio);
                var correctedReqTargetPos = correctReqWazaTargetPos(waza, targetPos);

				GetServerCommandPutter().Message_Waza(bpp.GetID(), waza, targetPos, false);
				GetServerCommandPutter().HaseiWazaEffect(bpp, waza, correctedReqTargetPos);

				calculatedWaza = reqWazaID;
				targetPos = reqTargetPos;
            }

			GetEventLauncher().Event_GetWazaParam(waza, waza, waza, wazaPrio, bpp, wazaParam2);
			GetEventLauncher().Event_GetWazaParam(calculatedWaza, waza, waza, wazaPrio, bpp, wazaParam1);

			if (!isWazaKept)
			{
				var failCause = checkReqWazaFail(bpp, wazaParam1);

				if (failCause != WazaFailCause.NONE)
				{
					onFailed(bpp, wazaParam1.wazaID, failCause);

                    var isPPUsedReqFail = decrementPP(bpp, waza, calculatedWaza, pokeSet);

                    pResult.wazaParam.CopyFrom(wazaParam1);
                    pResult.targetPos = targetPos;
                    pResult.isPPUsed = isPPUsedReqFail;
                    pResult.isWazaEffective = false;
                    pResult.resultCode = ResultCode.FAILED;
                    return;
                }
			}

			registerWazaTargets(bpp, wazaParam1, targetPos, aimTargetID, pResult.targets);

			var isPPUsed = false;
			if ((!isWazaLock || !isTameLock) && !actionDesc.isOdorikoReaction)
				isPPUsed = decrementPP(bpp, waza, calculatedWaza, pResult.targets);

            event_WazaCallDecide(bpp, wazaParam2, wazaParam1);
			GetEventLauncher().Event_CheckCombiWazaExe(bpp, wazaParam1);

			// Result ignored
			_ = bpp.GetID();

			putWazaMessage(bpp, waza, calculatedWaza, BtlPokePos.POS_NULL);

			if (checkWazaFail_2nd(bpp, wazaParam1, pResult.targets) ||
				checkWazaFail_Funjin(bpp, wazaParam1))
			{
                pResult.wazaParam.CopyFrom(wazaParam1);
                pResult.targetPos = targetPos;
                pResult.isPPUsed = isPPUsed;
                pResult.isWazaEffective = false;
                pResult.resultCode = ResultCode.FAILED;
                return;
            }

			GetBattleEnv().SetLastExecutedWaza(wazaParam1);

			if (bpp.CheckSick(WazaSick.WAZASICK_HITRATIO_UP))
			{
				cureSick(bpp, WazaSick.WAZASICK_HITRATIO_UP);
				bpp.TURNFLAG_Set(BTL_POKEPARAM.TurnFlag.TURNFLG_HITRATIO_UP);
            }

			if (checkWazaFail_3rd(bpp, wazaParam1, pResult.targets))
			{
                pResult.wazaParam.CopyFrom(wazaParam1);
                pResult.targetPos = targetPos;
                pResult.isPPUsed = isPPUsed;
                pResult.isWazaEffective = false;
                pResult.resultCode = ResultCode.FAILED;
                return;
            }

			if (setDelayWazaReady(ref pResult.isWazaEffective, bpp, wazaParam1, targetPos))
			{
                pResult.wazaParam.CopyFrom(wazaParam1);
                pResult.targetPos = targetPos;
                pResult.isPPUsed = isPPUsed;
                pResult.resultCode = ResultCode.DELAY_WAZA_SET;
                return;
            }

			if (setCombiWazaReady(bpp, calculatedWaza, targetPos))
			{
                pResult.wazaParam.CopyFrom(wazaParam1);
                pResult.targetPos = targetPos;
                pResult.isPPUsed = isPPUsed;
                pResult.resultCode = ResultCode.COMBI_WAZA_READY;
                return;
            }

			GetBattleEnv().GetWazaRec().Add(calculatedWaza, (uint)GetCounter(BattleCounter.UniqueCounter.BATTLE_TURN_COUNT), bpp.GetID());
			event_WazaExecDecide(bpp, wazaParam1);

			var isRobbed = checkWazaRob(bpp, calculatedWaza, pResult.targets, pResult.robParam);

            pResult.wazaParam.CopyFrom(wazaParam1);
            pResult.targetPos = targetPos;
            pResult.isPPUsed = isPPUsed;

			if (isRobbed)
			{
				pResult.isWazaEffective = false;
                pResult.resultCode = ResultCode.ROBBED;
            }
			else
			{
                pResult.isWazaEffective = true;
                pResult.resultCode = ResultCode.SUCCESSED;
            }
        }
		
		private void event_StartWazaSeq(BTL_POKEPARAM attacker, WazaNo waza)
		{
			GetEventLauncher().Event_StartWazaSeq(attacker, waza);
		}
		
		private bool checkWazaFail_1st(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc, bool isWazaLock, bool isTameLock)
		{
			var desc = new Section_WazaExec_CheckFail_1st.Description();
            desc.actionDesc = actionDesc;
            desc.attacker = attacker;
            desc.wazaParam = wazaParam;
            desc.isWazaLock = isWazaLock || isTameLock;

			var result = new Section_WazaExec_CheckFail_1st.Result();

			GetSectionContainer().GetSection_WazaExec_CheckFail_1st().Execute(result, desc);

			return result.isFailed;
        }
		
		private void registerWazaTargets(BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos targetPos, byte aimTargetID, PokeSet pTargets)
		{
			var desc = new Section_RegisterWazaTargets.Description();
            desc.pAttacker = pAttacker;
            desc.pPokeSet = pTargets;
            desc.pWazaParam = pWazaParam;
            desc.targetPos = targetPos;
            desc.aimTargetID = aimTargetID;

            var result = new Section_RegisterWazaTargets.Result();

            GetSectionContainer().GetSection_RegisterWazaTargets().Execute(result, desc);
        }
		
		private bool decrementPP(BTL_POKEPARAM attacker, WazaNo orgWaza, WazaNo actWaza, PokeSet targets)
		{
			var wazaIndex = attacker.WAZA_SearchIdx(orgWaza);

			if (wazaIndex == BattleDefConst.PTL_WAZA_MAX)
				return false;

			if (attacker.IsRaidBoss())
				return true;

			var volume = GetEventLauncher().Event_DecrementPPVolume(attacker, wazaIndex, orgWaza, targets);

			var desc = new Section_DecrementPP.Description();
            desc.poke = attacker;
            desc.wazaIndex = wazaIndex;
            desc.volume = (byte)volume;

            var result = new Section_DecrementPP.Result();

            GetSectionContainer().GetSection_DecrementPP().Execute(result, desc);

			if (!GWaza.IsGWaza(actWaza))
				GetServerCommandPutter().SetWazaUsedFlag(attacker.GetID(), wazaIndex);

			return result.isDecrement;
        }
		
		private void onFailed(BTL_POKEPARAM attacker, WazaNo waza, WazaFailCause failCause)
		{
			var desc = new Section_WazaExec_Failed.Description();
            desc.pAttacker = attacker;
            desc.waza = waza;
            desc.failCause = failCause;

            var result = new Section_WazaExec_Failed.Result();

            GetSectionContainer().GetSection_WazaExec_Failed().Execute(result, desc);
        }
		
		private BtlPokePos correctReqWazaTargetPos(WazaNo orgWaza, BtlPokePos defaultTargetPos)
		{
			var target = WAZADATA.GetWazaTarget(orgWaza);

			if (defaultTargetPos == BtlPokePos.POS_NULL && target == WazaTarget.TARGET_ENEMY_SELECT)
				return GetMainModule().GetOpponentPokePos(BtlPokePos.POS_NULL, 0);

			return defaultTargetPos;
		}
		
		private WazaFailCause checkReqWazaFail(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			if (CheckInvalidWaza(wazaParam.wazaID))
				return WazaFailCause.OTHER;

			if (attacker.CheckSick(WazaSick.WAZASICK_KAIHUKUHUUJI) && WAZADATA.GetFlag(wazaParam.wazaID, WazaFlag.KAIFUKU_HUUJI))
				return WazaFailCause.KAIHUKUHUUJI;

            if (attacker.CheckSick(WazaSick.WAZASICK_ZIGOKUDUKI) && WAZADATA.GetFlag(wazaParam.wazaID, WazaFlag.SOUND))
                return WazaFailCause.ZIGOKUDUKI;

			if (GetBattleEnv().GetFieldStatus().CheckEffect(EffectType.EFF_JURYOKU) && WAZADATA.GetFlag(wazaParam.wazaID, WazaFlag.FLYING))
				return WazaFailCause.JURYOKU;

			if (CheckSkyBattleFailWaza(wazaParam.wazaID))
				return WazaFailCause.SKYBATTLE;

			return WazaFailCause.NONE;
        }
		
		private void event_WazaCallDecide(BTL_POKEPARAM attacker, WazaParam wazaParamOrg, WazaParam wazaParamAct)
		{
			GetEventLauncher().Event_WazaCallDecide(attacker, wazaParamOrg, wazaParamAct);
		}
		
		private void putWazaMessage(BTL_POKEPARAM pAttacker, WazaNo orgWazaID, WazaNo actWazaID, BtlPokePos actTargetPos)
		{
			var strParam = new StrParam();

			if (checkWazaMsgCustom(pAttacker, orgWazaID, actWazaID, strParam))
                GetServerCommandPutter().Message(strParam);
            else
				GetWazaCommandPutter().ReserveMessage(GetActionSharedData().wazaMessageParam);
        }
		
		private bool checkWazaMsgCustom(BTL_POKEPARAM pAttacker, WazaNo orgWazaID, WazaNo actWazaID, StrParam pStrParam)
		{
			return GetEventLauncher().Event_CheckWazaMsgCustom(pAttacker, orgWazaID, actWazaID, pStrParam);
		}
		
		private bool checkWazaFail_2nd(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
        {
			var desc = new Section_WazaExec_CheckFail_2nd.Description();
			desc.attacker = attacker;
			desc.wazaParam = wazaParam;
			desc.targets = targets;

			var result = new Section_WazaExec_CheckFail_2nd.Result();

			GetSectionContainer().GetSection_WazaExec_CheckFail_2nd().Execute(result, desc);

			return result.isFailed;
        }
		
		private bool checkWazaFail_Funjin(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			var desc = new Section_WazaExec_CheckFail_Funjin.Description();
			desc.attacker = attacker;
			desc.wazaParam = wazaParam;

            var result = new Section_WazaExec_CheckFail_Funjin.Result();

            GetSectionContainer().GetSection_WazaExec_CheckFail_Funjin().Execute(result, desc);

            return result.isFailed;
        }
		
		private bool checkWazaFail_3rd(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
		{
			var desc = new Section_WazaExec_CheckFail_3rd.Description();
            desc.attacker = attacker;
            desc.wazaParam = wazaParam;
            desc.targets = targets;

            var result = new Section_WazaExec_CheckFail_3rd.Result();

            GetSectionContainer().GetSection_WazaExec_CheckFail_3rd().Execute(result, desc);

            return result.isFailed;
        }
		
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick)
		{
			var desc = new Section_CureSick.Description();
			desc.pokeID = poke.GetID();
            desc.sick = (WazaSickEx)sick;
			desc.targetPokeID[0] = poke.GetID();
			desc.targetPokeCount = 1;
			desc.isStandardMessageDisable = true;

            var result = new Section_CureSick.Result();

            GetSectionContainer().GetSection_CureSick().Execute(result, desc);
        }
		
		private bool setDelayWazaReady(ref bool pIsWazaEnable, BTL_POKEPARAM attacker, WazaParam wazaParam, BtlPokePos targetPos)
        {
            var desc = new Section_WazaExec_DelayWazaReady.Description();
			desc.pAttacker = attacker;
			desc.pWazaParam = wazaParam;
			desc.targetPos = targetPos;

            var result = new Section_WazaExec_DelayWazaReady.Result();

            GetSectionContainer().GetSection_WazaExec_DelayWazaReady().Execute(result, desc);

			pIsWazaEnable = result.isWazaEnable;

			return result.isReadyProcessed;
        }
		
		private bool setCombiWazaReady(BTL_POKEPARAM attacker, WazaNo waza, BtlPokePos targetPos)
		{
            var desc = new Section_WazaExec_CombiWazaReady.Description();
            desc.attacker = attacker;
            desc.waza = waza;
            desc.targetPos = targetPos;

            var result = new Section_WazaExec_CombiWazaReady.Result();

            GetSectionContainer().GetSection_WazaExec_CombiWazaReady().Execute(result, desc);

            return result.isReadied;
        }
		
		private void event_WazaExecDecide(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			GetEventLauncher().Event_WazaExeDecide(attacker, wazaParam, EventID.WAZA_EXE_DECIDE);
		}
		
		private bool checkWazaRob(BTL_POKEPARAM attacker, WazaNo waza, PokeSet targets, WazaRobParam robParam)
		{
			byte robberPokeID = PokeID.INVALID;
			byte robTargetRobID = PokeID.INVALID;

            var robbed = GetEventLauncher().Event_CheckWazaRob(attacker, waza, targets, ref robberPokeID, ref robTargetRobID);

			if (robberPokeID == PokeID.INVALID)
				return false;

			if (robTargetRobID == PokeID.INVALID)
				robParam.targetPos[0] = BtlPokePos.POS_NULL;
			else
                robParam.targetPos[0] = GetPokePos(robTargetRobID);

            robParam.robberPokeID[0] = robberPokeID;
			robParam.robberCount = 1;

			return true;
        }
		
		public void checkBattleTalk(byte pokeID, WazaNo waza)
		{
			// Empty
		}

		public enum ResultCode : int
		{
			FAILED = 0,
			SUCCESSED = 1,
			DELAY_WAZA_SET = 2,
			COMBI_WAZA_READY = 3,
			ROBBED = 4,
		}

		public class Description
		{
			public PokeAction pPokemonAction;
			
			public Description()
			{
				pPokemonAction = null;
			}
		}

		public class Result
		{
			public ResultCode resultCode;
			public bool isWazaEffective;
			public bool isPPUsed;
			public WazaParam wazaParam = new WazaParam();
			public BtlPokePos targetPos;
			public PokeSet targets = new PokeSet();
			public WazaRobParam robParam = new WazaRobParam();
		}
	}
}