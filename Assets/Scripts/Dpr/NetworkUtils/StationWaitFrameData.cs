using INL1;

namespace Dpr.NetworkUtils
{
	public class StationWaitFrameData : ANetData<StationWaitFrameParam>
	{
		public override byte GetDataID { get => 254; }
		
		// TODO
		public float CalcWaitTime() { return default; }
		
		// TODO
		public void SendWaitFrameData(TransportType transportType = TransportType.Station) { }
		
		// TODO
		public void RecieveWaitFrameData(PacketReader pr) { }
	}
}