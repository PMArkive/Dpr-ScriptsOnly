using System;

namespace Dpr.BallDeco
{
    [Serializable]
    public struct CapsuleData
    {
        public uint AttachPokemonId;
        public uint AttachPersonalRnd;
        public bool Is3DEditMode;
        public bool IsAppliedTemplate;
        public byte AffixSealCount;
        public AffixSealData[] AffixSealDatas;

        // TODO
        public void Clear() { }

        // TODO
        public void CopyFrom(in CapsuleData src) { }
    }
}