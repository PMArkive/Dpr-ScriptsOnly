namespace NexPlugin
{
	public class VSocket
	{
		public const uint MAX_DATA_SIZE = 1250;
		public const uint MARGIN_SIZE = 12;
		public const uint DEFAULT_MAX_RECV_PACKTES = 128;
		public const uint TOTAL_NAT_TRAVERSAL_TIMEOUT_MS = 120000;

		public enum Result : int
		{
			Success = 0,
			Error = 1,
			WouldBlock = 2,
			PacketBufferFull = 3,
		}
	}
}