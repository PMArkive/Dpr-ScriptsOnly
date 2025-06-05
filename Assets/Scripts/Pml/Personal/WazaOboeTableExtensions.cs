using XLSXContent;

namespace Pml.Personal
{
    public static class WazaOboeTableExtensions
    {
        private const ushort WAZAOBOE_END_CODE = 65535;
        private const int UNITLEN_AR = 2;

        public static ushort GetLevel(this WazaOboeTable.SheetWazaOboe self, int index)
        {
            index *= UNITLEN_AR;

            if (index < self.ar.Length)
                return self.ar[index];
            else
                return 0;
        }

        public static ushort GetWazaNo(this WazaOboeTable.SheetWazaOboe self, int index)
        {
            index *= UNITLEN_AR;

            if (index < self.ar.Length)
                return self.ar[index+1];
            else
                return 0;
        }

        // TODO: Not sure what this does...
        public static int GetValidCodeNum(this WazaOboeTable.SheetWazaOboe self)
        {
            if (self.ar.Length <= 1)
                return 0;
            else if (self.ar.Length < 0)
                return (self.ar.Length + 1) / UNITLEN_AR;
            else
                return self.ar.Length / UNITLEN_AR;
        }

        public static OboeWazaKind GetOboeWazaKind(this WazaOboeTable.SheetWazaOboe self, ushort data_index)
        {
            if (self.GetValidCodeNum() <= data_index)
            {
                GFL.ASSERT(false);
                return OboeWazaKind.LEVEL;
            }

            var level = self.GetLevel(data_index);
            if (level == 0)
                return OboeWazaKind.EVOLVE;
            else if (level == 1)
                return OboeWazaKind.BASE;
            else
                return OboeWazaKind.LEVEL;
        }
    }
}