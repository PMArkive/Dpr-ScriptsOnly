namespace NexPlugin
{
	public class StationURL
	{
		public enum URLType : int
		{
			unknown = 0,
			prudp = 1,
			prudps = 2,
			udp = 3,
		}

		public enum Flags : int
		{
			BehindNAT = 1,
			Public = 2,
			DetectedByNatCheck = 4,
			DetectedByNgs = 8,
		}
	}
}