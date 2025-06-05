using INL1;
using System;

namespace Dpr.NetworkUtils
{
    public abstract class ANetData<T> : INetData
    {
        public static byte DataID;
        public T data = Activator.CreateInstance<T>();
        private int fromStationIndex;
        private static byte[] dataBuffer;
        private static int dataSize;

        public virtual byte GetDataID { get => DataID; }

        public ANetData()
        {
            CreateDataBuffer();
        }

        // TODO
        private void CreateDataBuffer() { }

        // TODO
        public void _Debug_ChangeFromStarionIndex(int idx) { }

        public int FromStationIndex { get => fromStationIndex; }
        public INetData Clone { get => MemberwiseClone() as INetData; }

        // TODO
        public int SendReliableData(int sendStationIndex, TransportType transportType = TransportType.Station) { return 0; }

        // TODO
        public int SendReliableDataToAll(TransportType transportType = TransportType.Station) { return 0; }

        // TODO
        public int SendUnReliableData(int sendStationIndex, TransportType transportType = TransportType.Station) { return 0; }

        // TODO
        public int SendUnReliableDataToAll(TransportType transportType = TransportType.Station) { return 0; }

        // TODO
        public PacketWriterRe CreateReliableData() { return default; }

        // TODO
        protected virtual PacketWriter CreateUnReliableData() { return default; }

        // TODO
        protected virtual void WriteSendData(PacketWriter appendTarget) { }

        // TODO
        protected byte[] ConvertStructToBytes() { return null; }

        // TODO
        public void ReceivePacket(PacketReader pr) { }

        // TODO
        protected virtual void ReadRecieveData(PacketReader pr) { }

        // TODO
        protected T ConvertBytesToStruct(PacketReader pr) { return default; }
    }
}