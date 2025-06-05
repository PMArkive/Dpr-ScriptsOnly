using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaEffectParams
    {
        public WazaNo effectWazaID;
        public BtlPokePos attackerPos;
        public BtlPokePos targetPos;
        public byte effectIndex;
        public byte pluralHitIndex;
        public bool isGShockOccur;
        public bool fEnable;
        public bool fDone;
        public ushort commandQueuePos;
        public bool isSyncDamageEffect;
        public byte subEff_pokeCnt;
        public byte subEff_pokeID_1;
        public byte subEff_pokeID_2;
        public byte subEff_pokeID_3;
        public byte subEff_pokeID_4;
        public byte subEff_pokeID_5;

        // TODO
        public void CopyFrom(WazaEffectParams src) { }

        // TODO
        public void Clear() { }

        // TODO
        public void Setup(BTL_POKEPARAM attacker, PokeSet targets, in PosPoke posPoke) { }

        // TODO
        public void ChangeAttackerPos(BtlPokePos atkPos) { }

        // TODO
        public void ChangeEffectWazaID(WazaNo waza) { }

        // TODO
        public WazaNo GetEffectWazaID() { return WazaNo.NULL; }

        // TODO
        public void SetEnable() { }

        // TODO
        public void SetEnableDummy() { }

        // TODO
        public bool IsEnable() { return false; }

        // TODO
        public bool IsDone() { return false; }

        // TODO
        public void SetEffectIndex(byte index) { }

        // TODO
        public void AddSubEffectPoke(byte pokeID) { }

        // TODO
        public void ClearSubEffectParams() { }

        // TODO
        public bool IsSubEffectParamsValid() { return false; }

        // TODO
        public bool IsGShockOccur() { return false; }

        // TODO
        public void SetGShockOccur() { }

        // TODO
        public void SetSyncDamageEffectEnable() { }
    }
}