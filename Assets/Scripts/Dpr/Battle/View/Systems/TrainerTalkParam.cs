namespace Dpr.Battle.View.Systems
{
	public struct TrainerTalkParam
	{
		public byte clientId;
		public uint param;
		public bool isKeyWait;
		
		// TODO
		public static TrainerTalkParam Factory() { return default; }
	}
}