namespace Dpr.Battle.Logic
{
    public sealed class BTLV_STRPARAM
    {
        public ushort strID;
        public byte wait;
        public byte strType;
        public byte argCnt;
        public int[] args = new int[DefineConstants.BTL_STR_ARG_MAX];

        public static void Setup(BTLV_STRPARAM sp, BtlStrType strType, ushort strID)
        {
            for (int i=0; i<sp.args.Length; i++)
                sp.args[i] = 0;

            sp.argCnt = 0;
            sp.strID = strID;
            sp.strType = (byte)strType;
            sp.wait = 0;
        }

        public static void AddArg(BTLV_STRPARAM sp, int arg)
        {
            var currCnt = sp.argCnt;
            if (currCnt < sp.args.Length)
            {
                sp.argCnt++;
                sp.args[currCnt] = arg;
            }
        }

        public static void SetWait(BTLV_STRPARAM sp, byte wait)
        {
            sp.wait = wait;
        }
    }
}