namespace Dpr.Battle.Logic
{
	public static class SICKCONT
	{
		// TODO
		public static BTL_SICKCONT MakeNull() { return default; }
		
		// TODO
		public static bool IsNull(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeTurn(byte causePokeID, byte turns) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeTurnParam(byte causePokeID, byte turns, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePoke(byte causePokeID, byte pokeID) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanent(byte causePokeID) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentInc(byte causePokeID, byte count_max) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentParam(byte causePokeID, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentIncParam(byte causePokeID, byte count_max, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePokeTurn(byte causePokeID, byte pokeID, byte turns) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePokeTurnParam(byte causePokeID, byte pokeID, byte turns, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeMoudokuCont(byte causePokeID) { return default; }
		
		// TODO
		public static bool IsMoudokuCont(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static byte GetPokeID(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static void SetPokeID(ref BTL_SICKCONT cont, byte pokeID) { }
		
		// TODO
		public static byte GetTurnMax(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static void AddParam(ref BTL_SICKCONT cont, ushort param) { }
		
		// TODO
		public static ushort GetParam(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static void SetFlag(ref BTL_SICKCONT cont, bool flag) { }
		
		// TODO
		public static bool GetFlag(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static void IncTurn(ref BTL_SICKCONT cont, byte inc) { }
		
		// TODO
		public static void SetTurn(ref BTL_SICKCONT cont, byte turn) { }
		
		// TODO
		public static byte GetCausePokeID(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static void SetCausePokeID(ref BTL_SICKCONT cont, byte pokeID) { }
		
		// TODO
		public static void Split32bit(in BTL_SICKCONT cont, out uint high, out uint low)
		{
			high = default;
			low = default;
		}
		
		// TODO
		public static void Unite32bit(out BTL_SICKCONT cont, uint high, uint low)
		{
            cont = default;
        }
	}
}