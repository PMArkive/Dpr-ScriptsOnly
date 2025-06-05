using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeAction
    {
        public BTL_POKEPARAM bpp;
        public PokeActionCategory actionCategory;
        public PokeActionParam_Fight actionParam_Fight = new PokeActionParam_Fight();
        public PokeActionParam_Item actionParam_Item = new PokeActionParam_Item();
        public PokeActionParam_PokeChange actionParam_PokeChange = new PokeActionParam_PokeChange();
        public ActionDesc actionDesc = new ActionDesc();
        public uint priority;
        public byte clientID;
        public bool fDone;
        public bool fIntrCheck;
        public bool fRecalcPriority;

        // TODO
        public void CopyFrom(PokeAction src) { }

        // TODO
        public void Clear() { }

        // TODO
        public static void Copy(PokeAction dest, in PokeAction src) { }

        // TODO
        public static void Swap(PokeAction action1, PokeAction action2) { }

        // TODO
        public static void Clear(PokeAction action) { }

        // TODO
        public static WazaNo GetWazaID(PokeAction action) { return WazaNo.NULL; }

        // TODO
        public static bool IsGWazaFight(PokeAction action) { return false; }

        // TODO
        public static bool IsRaidBossFight(PokeAction action) { return false; }

        // TODO
        public static bool IsRaidBossGWaza(PokeAction action) { return false; }
    }
}