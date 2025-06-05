using System;
using UnityEngine;

namespace Pml.PokePara
{
    [Serializable]
    public struct SavePokeParty
    {
        [SerializeField]
        private SerializedPokemonFull[] members;
        [SerializeField]
        private byte memberCount;
        [SerializeField]
        private byte markingIndex;

        // TODO
        public void Serialize_Full(PokeParty party) { }

        // TODO
        public void Deserialize_Full(PokeParty party) { }

        // TODO
        public void CreateWorkIfNeed() { }

        // TODO
        public void Clear() { }
    }
}