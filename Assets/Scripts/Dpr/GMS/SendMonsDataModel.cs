using Pml;
using Pml.PokePara;

namespace Dpr.GMS
{
	public class SendMonsDataModel : ATradeMonsData
	{
		public PokemonParam selectPokeParam;
		public PokemonParam demoPokeParam;
		public MonsNo sendMonsNo;
		public uint sendMonsFormNo;
		public Sex sendMonsSex;
		public int trayIndex;
		public int indexInTray;
		
		// TODO
		public void Clear() { }
		
		// TODO
		public void CreateDemoPokeParam(in byte[] coreData) { }
		
		// TODO
		public void CopySendCoreData(in byte[] coreData) { }
	}
}