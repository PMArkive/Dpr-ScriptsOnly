using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public sealed class DmgAffRec
    {
        private AffinityData[] m_affinityData;

        // TODO
        public DmgAffRec() { }

        // TODO
        public void Init() { }

        // TODO
        public void Add(byte pokeID, TypeAffinity.AffinityID aff, bool isNoEffectByFloatingStatus) { }

        // TODO
        public TypeAffinity.AffinityID Get(byte pokeID) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public TypeAffinity.AffinityID GetIfEnable(byte pokeID) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public bool IsNoEffectByFloatingStatus(byte pokeID) { return false; }

        private class AffinityData
        {
            public TypeAffinity.AffinityID typeAffinity;
            public bool isNoEffectByFloatingStatus;

            // TODO
            public AffinityData() { }
        }
    }
}