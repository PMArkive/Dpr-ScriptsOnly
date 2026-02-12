using Pml.PokePara;
using System;

namespace Dpr.Box
{
    [Serializable]
    public struct SaveBoxTrayData
    {
        public SerializedPokemonFull[] pokemonParam;

        public static void Swap(ref SaveBoxTrayData lhs, ref SaveBoxTrayData rhs)
        {
        	var uVar2 = 0;
        	var lVar3 = 0x20;
        	while ((uVar2 < lhs.Length && (uVar2 < rhs.Length))) {
        	  SerializedPokemonFull.Swap(lhs + lVar3,rhs + lVar3);
        	  uVar2 = uVar2 + 1;
        	  lVar3 = lVar3 + 8;
        	  if (uVar2 == 0x1e) {
        	  }
        	}
        }

        // TODO
        public void Clear() { }
    }
}