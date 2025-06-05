using System;
using UnityEngine;

namespace Pml.PokePara
{
    [Serializable]
    public struct SerializedPokemonFull
    {
        [SerializeField]
        public byte[] buffer;

        // TODO
        public void CopyFrom(in SerializedPokemonFull src) { }

        // TODO
        public static void Swap(ref SerializedPokemonFull lhs, ref SerializedPokemonFull rhs) { }

        // TODO
        public void CreateWorkIfNeed() { }
    }
}