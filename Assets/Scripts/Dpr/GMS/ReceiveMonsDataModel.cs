using Pml.PokePara;

namespace Dpr.GMS
{
	public class ReceiveMonsDataModel : ATradeMonsData
	{
		public PokemonParam pokeParam;
		
		public void Clear()
		{
			pokeParam = null;
			coreData = null;
			pointIndex = -1;
		}
	}
}