using Pml;
using poketool;
using XLSXContent;

namespace Dpr.Battle.View
{
    public struct SimpleParam
    {
        public MonsNo monsNo;
        public int formNo;
        public Sex sex;
        public bool isRare;
        public bool isEgg;
        public float scale;
        public int perRand;
        public PokeGType gType;
        public int adjustHeight;
        public int speciesValue;

        public SimpleParam(MonsNo monsNo = MonsNo.NULL, int formNo = 0, Sex sex = Sex.MALE, bool isRare = false, bool isEgg = false, float scale = 1.0f, int perRand = 0, PokeGType gType = PokeGType.NONE, int adjustHeight = 100, int speciesValue = -1)
        {
            this.monsNo = monsNo;
            this.formNo = formNo;
            this.sex = sex;
            this.isRare = isRare;
            this.isEgg = isEgg;
            this.scale = scale;
            this.perRand = perRand;
            this.gType = gType;
            this.adjustHeight = adjustHeight;
            this.speciesValue = speciesValue;
        }

        public SimpleParam(PokemonInfo.SheetCatalog catalog, bool isContest)
        {
            monsNo = catalog.MonsNo;
            formNo = catalog.FormNo;
            sex = catalog.Sex;
            isRare = catalog.Rare;
            isEgg = false;
            scale = isContest ? catalog.ContestScale : catalog.BattleScale;
            perRand = 0;
            gType = PokeGType.NONE;
            adjustHeight = catalog.BattleAjustHeight;
            speciesValue = 0;
        }

        public SimpleParam(SimpleParam other)
        {
            monsNo = other.monsNo;
            formNo = other.formNo;
            sex = other.sex;
            isRare = other.isRare;
            isEgg = other.isEgg;
            scale = other.scale;
            perRand = other.perRand;
            gType = other.gType;
            adjustHeight = other.adjustHeight;
            speciesValue = other.speciesValue;
        }
    }
}