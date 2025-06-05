using INL1;

namespace Dpr.NetworkUtils
{
    public interface INetData
    {
        // TODO
        void ReceivePacket(PacketReader pr);

        int FromStationIndex { get; }
        byte GetDataID { get; }
        INetData Clone { get; }
    }
}