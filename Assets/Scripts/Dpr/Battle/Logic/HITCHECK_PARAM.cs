using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public sealed class HITCHECK_PARAM
    {
        public byte countMax;
        public byte count;
        public bool needCheckEveryTime;
        public bool isPluralHitWaza;
        public TypeAffinity.AffinityID pluralHitAffinity;
        public bool isDeadMessageDisplay;
        public bool isAffinityMessageDisplay;

        // TODO
        public bool IsPluralHitWaza(byte max) { return false; }

        // TODO
        public bool IsPluralHitException() { return false; }

        // TODO
        public bool IsFirstTime() { return false; }

        // TODO
        public void SetPluralHitAffinity(TypeAffinity.AffinityID affinity) { }

        // TODO
        public HITCHECK_PARAM() { }
    }
}