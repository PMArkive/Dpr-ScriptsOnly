using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class StatueEffectRawData : ScriptableObject
    {
        public Sheettable[] table;

        public Sheettable this[int index] => table[index];

        [Serializable]
        public class Sheettable
        {
            public ushort statueId;
            public int UgItemID;
            public ushort monsId;
            public byte rarity;
            public byte shader;
            public byte width;
            public byte height;
            public byte resultCameraNo;
            public sbyte type1Id;
            public sbyte type2Id;
            public short[] pokeTypeEffect;
            public int MSLabelId;
            public string motion;
            public int frame;
            public Vector3 offset;
            public float cameraDistance;
            public ushort FormNo;
            public Sex Sex;
            public bool Rare;
            public int ratio1;
            public int ratio2;
            public int ratio3;
            public int ratio4;
            public int ratio5;
            public int ratio6;
            public float fieldScale;
        }
    }
}