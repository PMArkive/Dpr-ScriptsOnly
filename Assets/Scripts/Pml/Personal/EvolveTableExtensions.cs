using XLSXContent;

namespace Pml.Personal
{
    public static class EvolveTableExtensions
    {
        private const byte NEXT_FORMNO_INHERIT = 255;
        private const int UNITLEN_AR = 5;

        public static int Length(this EvolveTable.SheetEvolve self)
        {
            if (self.ar.Length > UNITLEN_AR - 1)
                return self.ar.Length / UNITLEN_AR;
            else
                return 0;
        }

        public static byte GetEvolutionRouteNum(this EvolveTable.SheetEvolve self)
        {
            byte count;
            for (count=0; count<self.Length(); count++)
            {
                if (self.GetEvolutionCondition(count) == EvolveCond.NONE)
                    break;
            }

            return count;
        }

        public static EvolveCond GetEvolutionCondition(this EvolveTable.SheetEvolve self, int index)
        {
            index *= UNITLEN_AR;

            if (index < self.ar.Length)
                return (EvolveCond)self.ar[index];
            else
                return EvolveCond.NONE;
        }

        public static EvolveCond GetEvolutionCondition(this EvolveTable.SheetEvolve self, MonsNo next_monsno)
        {
            var length = self.Length();

            for (int i=0; i<length; i++)
            {
                if (self.GetEvolvedMonsNo(i) == next_monsno)
                    return self.GetEvolutionCondition(i);
            }

            return EvolveCond.NONE;
        }

        public static ushort GetEvolutionParam(this EvolveTable.SheetEvolve self, int index)
        {
            index *= UNITLEN_AR;

            if (index + 1 < self.ar.Length)
                return self.ar[index + 1];
            else
                return 0;
        }

        public static MonsNo GetEvolvedMonsNo(this EvolveTable.SheetEvolve self, int index)
        {
            index *= UNITLEN_AR;

            if (index + 2 < self.ar.Length)
                return (MonsNo)self.ar[index + 2];
            else
                return MonsNo.NULL;
        }

        public static byte GetEvolvedFormNo(this EvolveTable.SheetEvolve self, int index)
        {
            index *= UNITLEN_AR;

            if (index + 3 < self.ar.Length)
                return (byte)self.ar[index + 3];
            else
                return 0;
        }

        public static bool IsEvolvedFormNoSpecified(this EvolveTable.SheetEvolve self, int route_index)
        {
            route_index *= UNITLEN_AR;

            if (route_index + 3 < self.ar.Length)
                return ((byte)self.ar[route_index + 3]) != NEXT_FORMNO_INHERIT;
            else
                return true;
        }

        public static byte GetEvolveEnableLevel(this EvolveTable.SheetEvolve self, int index)
        {
            index *= UNITLEN_AR;

            if (index + 4 < self.ar.Length)
                return (byte)self.ar[index + 4];
            else
                return 0;
        }
    }
}