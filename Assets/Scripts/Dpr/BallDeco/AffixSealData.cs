using System;
using UnityEngine;

namespace Dpr.BallDeco
{
    [Serializable]
    public struct AffixSealData
    {
        public ushort SealId;
        public short PositionX;
        public short PositionY;
        public short PositionZ;

        // TODO
        public void Clear() { }

        // TODO
        public void SetPosition(Vector3 pos) { }

        // TODO
        public Vector3 GetPosition() { return Vector3.zero; }

        // TODO
        private static short ConvertPositionValue(float value) { return 0; }

        // TODO
        private static float ConvertPositionValue(short value) { return 0; }
    }
}