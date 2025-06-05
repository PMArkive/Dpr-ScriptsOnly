using System;

namespace Dpr.BallDeco
{
    [Serializable]
    public struct SaveBallDecoExtraData
    {
        public int[] AttachCapsuleTrays;
        public int[] AttachCapsulePositions;

        // TODO
        public void Clear() { }
    }
}