namespace Dpr.Battle.Logic
{
	public sealed class PokemonBattleInRegister
	{
		private bool[] m_isPokemonBattleIn = new bool[PokeID.NUM];
		
		public PokemonBattleInRegister()
		{
			Clear();
		}
		
		// TODO
		public void Register(byte pokeId) { }
		
		// TODO
		public bool Check(byte pokeId) { return default; }
		
		// TODO
		public void Clear() { }
	}
}