namespace Dpr.Battle.Logic
{
	public sealed class PokeIDRec
	{
		private const int CAPACITY_PER_CLIENT = 6;

		private byte[][] m_registeredID = RectangularArrays.RectangularDefaultArray<byte>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM, CAPACITY_PER_CLIENT);
		
		public PokeIDRec()
		{
			Clear();
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void Clear() { }
		
		// TODO
		public void Register(byte pokeID) { }
		
		// TODO
		public bool IsRegistered(byte pokeID) { return default; }
		
		// TODO
		public bool IsRegisteredRecent(byte pokeID, byte checkCount) { return default; }
		
		// TODO
		private void removeID(byte clientID, byte pokeID) { }
		
		// TODO
		private void addID(byte clientID, byte pokeID) { }
		
		// TODO
		private int findIndex(byte clientID, byte pokeID) { return default; }
	}
}