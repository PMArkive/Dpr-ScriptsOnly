namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnEnd : Section
	{
		public Section_TurnEnd(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void removeRaidBossReinforceHandler() { }
		
		// TODO
		private void updateRaidBossReinforceTurn() { }
		
		// TODO
		private void updateRaidBossGWazaUseSchedule() { }
		
		// TODO
		private void updateRaidBossGWall() { }
		
		// TODO
		private void updateGGauge() { }
		
		// TODO
		private void updateGMode() { }
		
		// TODO
		private void updateGMode(BTL_POKEPARAM poke) { }
		
		// TODO
		private bool needEndG(BTL_POKEPARAM pPoke) { return default; }
		
		// TODO
		private void reliveAllDeadPartyOnRaidBattle() { }
		
		// TODO
		private void reliveAllDeadPartyOnRaidBattle(BTL_CLIENT_ID clientID) { }
		
		// TODO
		private void updateGRights() { }
		
		// TODO
		private void updateGRights(BtlSide side) { }
		
		// TODO
		private bool checkTransferGRights(BtlSide side) { return default; }
		
		// TODO
		private void transferGRights(BtlSide side) { }
		
		// TODO
		private void clearPokeTurnFlag() { }
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pPokeSet) { }
		
		// TODO
		private void incPokeTurnCount() { }
		
		// TODO
		private bool checkForceQuitByTurnOver() { return default; }
		
		// TODO
		private void checkBattleTalk() { }
		
		// TODO
		private bool checkRaidBattleForceQuit() { return default; }

		public class Description { }

		public class Result { }
	}
}