using Pml;

namespace Dpr.Battle.Logic
{
	public class Section
	{
		private MainModule m_pMainModule;
		private BattleEnv m_pBattleEnv;
		private ServerCommandQueue m_pServerCmdQueue;
		private ServerCommandPutter m_pServerCmdPutter;
		private WazaCommandPutter m_pWazaCmdPutter;
		private EventSystem m_pEventSystem;
		private EventLauncher m_pEventLauncher;
		private SectionSharedData m_pSharedData;
		private PokeActionContainer m_pPokemonActionContainer;
		private PokeChangeRequest m_pPokeChangeRequest;
		private CaptureInfo m_pCaptureInfo;
		private SectionContainer m_pSectionContainer;
		
		public Section(in CommonParam param)
		{
			m_pMainModule = param.pMainModule;
			m_pBattleEnv = param.pBattleEnv;
			m_pServerCmdQueue = param.pServerCmdQueue;
			m_pServerCmdPutter = param.pServerCmdPutter;
			m_pWazaCmdPutter = param.pWazaCmdPutter;
			m_pEventSystem = param.pEventSystem;
			m_pEventLauncher = param.pEventLauncher;
			m_pSharedData = param.pSharedData;
			m_pPokemonActionContainer = param.pPokemonActionContainer;
			m_pPokeChangeRequest = param.pPokeChangeRequest;
			m_pCaptureInfo = param.pCaptureInfo;
			m_pSectionContainer = param.pSectionContainer;
		}
		
		protected MainModule GetMainModule()
		{
			return m_pMainModule;
		}
		
		protected BattleEnv GetBattleEnv()
		{
			return m_pBattleEnv;
		}
		
		protected ServerCommandQueue GetServerCommandQueue()
		{
			return m_pServerCmdQueue;
		}
		
		protected ServerCommandPutter GetServerCommandPutter()
		{
			return m_pServerCmdPutter;
		}
		
		protected WazaCommandPutter GetWazaCommandPutter()
		{
			return m_pWazaCmdPutter;
		}
		
		protected EventSystem GetEventSystem()
		{
			return m_pEventSystem;
		}
		
		protected EventLauncher GetEventLauncher()
		{
			return m_pEventLauncher;
		}
		
		protected SectionSharedData GetSharedData()
		{
			return m_pSharedData;
		}
		
		protected ActionSharedData GetActionSharedData()
		{
			return m_pSharedData.GetActionSharedDataStack().GetCurrentData();
		}
		
		protected PokeActionContainer GetPokemonActionContainer()
		{
			return m_pPokemonActionContainer;
		}
		
		protected PokeChangeRequest GetPokeChangeRequest()
		{
			return m_pPokeChangeRequest;
		}
		
		protected CaptureInfo GetCaptureInfo()
		{
			return m_pCaptureInfo;
		}
		
		protected SectionContainer GetSectionContainer()
		{
			return m_pSectionContainer;
		}
		
		protected byte GetPokeID(BtlPokePos pos)
		{
			if (pos == BtlPokePos.POS_NULL)
				return PokeID.INVALID;

			return GetPokeParam(pos).GetID();
		}
		
		protected BTL_POKEPARAM GetPokeParam(byte pokeID)
		{
            return m_pBattleEnv.GetPokeCon().GetPokeParam(pokeID);
        }
		
		protected BTL_POKEPARAM GetPokeParam(BtlPokePos pos)
		{
			return m_pBattleEnv.GetPokeCon().GetFrontPokeData(pos);
        }
		
		protected BTL_POKEPARAM GetPokeParam(byte clientID, byte posIdx)
		{
            return m_pBattleEnv.GetPokeCon().GetClientPokeData(clientID, posIdx);
        }
		
		protected BtlPokePos GetPokePos(BTL_POKEPARAM poke)
		{
			return m_pBattleEnv.GetPosPoke().GetPokeExistPos(poke.GetID());
        }
		
		protected BtlPokePos GetPokePos(byte pokeID)
		{
            return m_pBattleEnv.GetPosPoke().GetPokeExistPos(pokeID);
        }
		
		protected BtlSide GetPokeSide(BTL_POKEPARAM poke)
		{
			return GetMainModule().PokeIDtoSide(poke.GetID());
		}
		
		protected BtlSide GetPokeSide(byte pokeID)
        {
            return GetMainModule().PokeIDtoSide(pokeID);
        }
		
		protected BTL_PARTY GetPokeParty(byte clientID)
		{
			return GetBattleEnv().GetPokeCon().GetPartyData(clientID);
		}
		
		protected BtlRule GetRule()
		{
			return GetMainModule().GetRule();
		}
		
		protected BtlMultiMode GetMultiMode()
		{
			return GetMainModule().GetMultiMode();
		}
		
		protected BtlCompetitor GetCompetitor()
		{
			return GetMainModule().GetCompetitor();
		}
		
		protected bool CheckCommMode()
		{
			return GetMainModule().GetCommMode() != BtlCommMode.BTL_COMM_NONE;
		}
		
		protected bool CheckStatusFlag(BTL_STATUS_FLAG flag)
		{
			return GetMainModule().GetSetupStatusFlag(flag);
		}
		
		protected bool CheckFriendPoke(BTL_POKEPARAM poke1, BTL_POKEPARAM poke2)
		{
			return GetMainModule().IsFriendPokeID(poke1.GetID(), poke2.GetID());
		}
		
		protected bool CheckFriendPoke(byte pokeID1, byte pokeID2)
		{
            return GetMainModule().IsFriendPokeID(pokeID1, pokeID2);
        }
		
		protected bool CheckShowdown()
		{
			return SectionUtil.CheckShowdown(GetMainModule(), GetBattleEnv());
		}
		
		protected bool CheckAllDeadSide(BtlSide checkSide)
		{
			return SectionUtil.CheckAllDeadSide(GetMainModule(), GetBattleEnv(), checkSide);
		}
		
		protected bool CheckSkipBattleAfterShowdown()
		{
			return SectionUtil.CheckSkipBattleAfterShowdown(GetMainModule());
        }
		
		protected bool CheckTurnEnd(InterruptCode interruptCode)
		{
			return SectionUtil.CheckTurnEnd(interruptCode);
        }
		
		protected bool CheckPlayersClient(BTL_CLIENT_ID clientID)
		{
			return SectionUtil.CheckPlayersClient(GetMainModule(), clientID);
		}
		
		protected byte GetFriendship(BTL_POKEPARAM poke)
		{
			return SectionUtil.GetFriendship(GetMainModule(), poke);
		}
		
		protected bool CheckPlayersPoke(BTL_POKEPARAM poke)
        {
            return SectionUtil.CheckPlayersPoke(GetMainModule(), poke);
		}
		
		protected bool CheckPlayersPoke(byte pokeID)
		{
			return CheckPlayersPoke(GetBattleEnv().GetPokeCon().GetPokeParam(pokeID));
		}
		
		protected bool CheckPlayersFriendPoke(BTL_POKEPARAM poke)
		{
			return GetMainModule().IsFriendClientID(MainModule.PokeIDtoClientID(poke.GetID()), GetMainModule().GetPlayerClientID());
		}
		
		protected bool CheckPlayersFriendPoke(byte pokeID)
		{
			return CheckPlayersFriendPoke(GetBattleEnv().GetPokeCon().GetPokeParam(pokeID));
		}
		
		protected bool CheckMustHit(BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			return SectionUtil.CheckMustHit(GetMainModule(), attacker, target, GetBattleEnv().GetPosPoke());
		}
		
		protected bool CheckInvalidWaza(WazaNo waza)
		{
			return !WAZADATA.IsValid(waza);
		}
		
		protected bool CheckWazaEffectEnable()
		{
			return GetMainModule().IsWazaEffectEnable();
		}
		
		protected bool CheckSkyBattleFailWaza(WazaNo waza)
		{
			return SectionUtil.CheckSkyBattleFailWaza(GetMainModule(), waza);
		}
		
		protected WazaNo CheckEncoreWazaChange(PokeAction action)
		{
			return SectionUtil.CheckEncoreWazaChange(action);
		}
		
		protected ulong GetCounter(BattleCounter.UniqueCounter counterID)
		{
			return GetBattleEnv().GetBattleCounter().Get(counterID);
		}
		
		protected ulong GetCounter(BattleCounter.ClientCounter counterID, BTL_CLIENT_ID clientID)
        {
            return GetBattleEnv().GetBattleCounter().Get(counterID, clientID);
        }

		public class CommonParam
		{
			public MainModule pMainModule;
			public BattleEnv pBattleEnv;
			public ServerCommandQueue pServerCmdQueue;
			public ServerCommandPutter pServerCmdPutter;
			public WazaCommandPutter pWazaCmdPutter;
			public EventSystem pEventSystem;
			public EventLauncher pEventLauncher;
			public SectionSharedData pSharedData;
			public PokeActionContainer pPokemonActionContainer;
			public PokeChangeRequest pPokeChangeRequest;
			public CaptureInfo pCaptureInfo;
			public SectionContainer pSectionContainer;
		}
	}
}