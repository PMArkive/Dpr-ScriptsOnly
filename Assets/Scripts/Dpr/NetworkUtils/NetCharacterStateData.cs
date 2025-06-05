namespace Dpr.NetworkUtils
{
	public class NetCharacterStateData : ANetData<StateData>
	{
		public NetCharacterStateData()
		{
			// Empty, declared explicitly
		}
		
		public override byte GetDataID { get => 4; }
		public static byte DataID { get => 4; }
	}
}