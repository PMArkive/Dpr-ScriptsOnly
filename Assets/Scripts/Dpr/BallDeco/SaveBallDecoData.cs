using System;

namespace Dpr.BallDeco
{
    [Serializable]
    public struct SaveBallDecoData
    {
        public byte CapsuleCount;
        public CapsuleData[] CapsuleDatas;

        // TODO
        public void Clear() { }
    }
}