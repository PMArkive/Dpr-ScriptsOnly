using Pml.PokePara;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
    public static class BattleCommon
    {
        public static bool IsPokeSick(Sick sickID)
        {
            return (int)sickID < BattleCommonConst.POKESICK_MAX;
        }

        public static bool IsPokeSick(WazaSick sickID)
        {
            return (int)sickID < BattleCommonConst.POKESICK_MAX;
        }
    }
}