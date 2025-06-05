namespace Dpr.Battle.Logic
{
	public sealed class FrontPokeAccessor
	{
		private readonly MainModule m_pMainModule;
		private readonly BattleEnv m_pBattleEnv;
		private byte m_clientID;
		private byte m_pokeIndex;
		private bool m_endFlag;
		
		public FrontPokeAccessor(MainModule pMainModule, BattleEnv pBattleEnv)
		{
			m_pMainModule = pMainModule;
			m_pBattleEnv = pBattleEnv;
			m_clientID = 0;
			m_pokeIndex = 0;
			m_endFlag = true;
		}
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public bool GetNext(out BTL_POKEPARAM bpp)
		{
			bpp = default;
			return default;
		}
		
		// TODO
		private bool isAccessTarget(BTL_POKEPARAM bpp) { return default; }
	}
}