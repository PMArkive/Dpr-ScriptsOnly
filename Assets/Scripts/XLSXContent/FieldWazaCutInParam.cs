using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FieldWazaCutInParam : ScriptableObject
    {
        public SheetPokemonParam[] PokemonParam;
        public SheetCommonParam[] CommonParam;

        public SheetPokemonParam this[int index] => PokemonParam[index];

        [Serializable]
        public class SheetPokemonParam
        {
            public int UniqueID;
            public float ModelScale;
            public string ModelMotion;
            public Vector3 ModelOffset;
            public Vector3 ModelRotationAngle;
        }

        [Serializable]
        public class SheetCommonParam
        {
            public float param;
        }
    }
}