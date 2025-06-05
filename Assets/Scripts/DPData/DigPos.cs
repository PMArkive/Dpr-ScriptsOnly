using System;
using UnityEngine;

namespace DPData
{
    [Serializable]
    public struct DigPos
    {
        public short GridX;
        public short GridY;

        public DigPos(short x, short y)
        {
            GridX = x;
            GridY = y;
        }

        public bool IsNull { get => GridX == -1 || GridY == -1; }

        public static implicit operator DigPos(Vector2Int v)
        {
            return new DigPos((short)v.x, (short)v.y);
        }
    }
}