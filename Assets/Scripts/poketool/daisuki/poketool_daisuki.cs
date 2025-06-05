using Pml;
using Pml.Item;
using Pml.PokePara;

namespace poketool.daisuki
{
    public static class poketool_daisuki
    {
        private static readonly sbyte[][] s_calcDaisukiTable = new sbyte[][]
        {
            new sbyte[] { 3,  2,  1 },
            new sbyte[] { 0,  0,  0 },
            new sbyte[] { 5,  3,  0 },
            new sbyte[] { 1,  1,  1 },
            new sbyte[] { -1, -1, -1 },
            new sbyte[] { -5, -5, -10 },
            new sbyte[] { 0,  0,  0 },
        };

        public static void Calc(CoreParam pParam, DaisukiType type)
        {
            CalcCore(pParam, s_calcDaisukiTable[(int)type]);
        }

        public static void CalcWhenWalk(CoreParam pParam)
        {
            Calc(pParam, DaisukiType.TSUREARUKI);
        }

        public static void CalcWhenUseItem(CoreParam pParam, ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);

            CalcCore(pParam, new sbyte[]
            {
                (sbyte)item.GetParam(ItemData.PrmID.FRIEND1_POINT),
                (sbyte)item.GetParam(ItemData.PrmID.FRIEND2_POINT),
                (sbyte)item.GetParam(ItemData.PrmID.FRIEND3_POINT),
            });
        }

        private static void CalcCore(CoreParam pParam, sbyte[] table)
        {
            if (pParam.IsEgg(EggCheckType.BOTH_EGG))
                return;

            var friendship = pParam.GetFriendship();
            int tier;

            if (friendship < 100)
                tier = 0;
            else if (friendship < 200)
                tier = 1;
            else
                tier = 2;

            var change = table[tier];

            if (change > 0)
            {
                if ((BallId)pParam.GetGetBall() == BallId.GOOZYASUBOORU)
                    change++;

                if (IsDaisukiUpItem(pParam.GetItem()))
                {
                    // This was compiled very oddly, but essentially it's a 1.5x multiplier
                    var newChange = (sbyte)(change * 150 / 100);
                    change = change < 0 ? (sbyte)(newChange - 1) : newChange;
                }
            }

            pParam.SetFriendship(friendship > PmlConstants.MAX_FRIENDSHIP ? PmlConstants.MAX_FRIENDSHIP : friendship);
        }

        private static bool IsDaisukiUpItem(uint itemno)
        {
            return itemno == (uint)ItemNo.YASURAGINOSUZU;
        }
    }
}