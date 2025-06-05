using Pml.PokePara;
using System;

namespace Dpr.Box
{
    [Serializable]
    public struct SaveBoxTrayData
    {
        public SerializedPokemonFull[] pokemonParam;

        // TODO
        public static void Swap(ref SaveBoxTrayData lhs, ref SaveBoxTrayData rhs) { }

        // TODO
        public void Clear() { }
    }
}