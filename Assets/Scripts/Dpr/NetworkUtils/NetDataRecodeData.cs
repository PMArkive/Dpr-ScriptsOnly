namespace Dpr.NetworkUtils
{
    public class NetDataRecodeData : ANetData<NetRecodeData>
    {
        public override byte GetDataID { get => 20; }
        public static byte DataID { get => 20; }
    }
}