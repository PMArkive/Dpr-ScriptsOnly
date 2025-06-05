using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class TamaHiroiData
    {
        public ushort ballItem;
        public bool ballValid;

        public static void Initialize(TamaHiroiData data)
        {
            data.ballItem = (ushort)ItemNo.DUMMY_DATA;
            data.ballValid = false;
        }

        public static void Copy(TamaHiroiData dst, TamaHiroiData src)
        {
            dst.ballItem = src.ballItem;
            dst.ballValid = src.ballValid;
        }
    }
}