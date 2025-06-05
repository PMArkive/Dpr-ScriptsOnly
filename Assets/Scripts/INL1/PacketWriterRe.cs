namespace INL1
{
	public class PacketWriterRe : PacketWriter
	{
		public PacketWriterRe()
		{
			MyUserDataMax = 0x400;
			Reset();
		}
		
		~PacketWriterRe()
		{
			// Empty
		}
	}
}