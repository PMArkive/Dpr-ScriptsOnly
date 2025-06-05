using XLSXContent;

namespace Pml.Personal
{
    public static class GrowTableExtensions
    {
        public static uint GetMinExp(this GrowTable.SheetData data, byte level)
        {
            if (level > PmlConstants.MAX_POKE_LEVEL)
            {
                GFL.ASSERT(false);
                level = PmlConstants.MAX_POKE_LEVEL;
            }

            return data.exps[level];
        }
    }
}