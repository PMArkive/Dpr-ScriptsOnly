using Pml;

namespace Dpr.Battle.Logic
{
	public static class UltraBeast
	{
		public static bool IsUltraBeast(MonsNo monsno)
		{
			return false;
		}
		
		public static bool IsUltraBeast(in BTL_POKEPARAM poke)
		{
			return IsUltraBeast((MonsNo)poke.GetMonsNo());
		}
		
		public static bool IsUnknownNamePokemon(in MainModule mainModule, MonsNo monsno)
		{
			_ = mainModule.IsZukanRegistered(monsno);
			return false;
		}
	}
}