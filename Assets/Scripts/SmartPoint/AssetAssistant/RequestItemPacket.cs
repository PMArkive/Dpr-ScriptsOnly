using System.Collections.Generic;

namespace SmartPoint.AssetAssistant
{
    public class RequestItemPacket
    {
        public List<IAssetRequestItem> packet;
        public RequestEventCallback callback;

        public RequestItemPacket()
        {
            packet = new List<IAssetRequestItem>();
        }

        public void Clear()
        {
            packet.Clear();
            callback = null;
        }
    }
}