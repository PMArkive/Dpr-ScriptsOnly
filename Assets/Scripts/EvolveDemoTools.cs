using Dpr.Demo;
using Pml.PokePara;
using Pml;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public static class EvolveDemoTools
{
    // TODO
    public static bool CanEvolve(out MonsNo nextMonsNo, out uint evolutionRoot, PokeParty playerParty, PokemonParam poke, EvolveSituation situation, [Optional] PokemonParam pairPoke, ItemNo itemNo = ItemNo.DUMMY_DATA)
    {
        nextMonsNo = MonsNo.NULL;
        evolutionRoot = 0;
        return false;
    }

    // TODO
    public static bool DoEvolve(Param param, [Optional] Action<Demo_Evolve.Result> onResult, [Optional] PokemonParam pairPoke, [Optional, DefaultParameterValue(ItemNo.DUMMY_DATA)] ItemNo itemNo, [Optional] Action onEndDemo, bool isUseEndExitFade = true) { return false; }

    // TODO
    public static IEnumerator RegisterZukanCoroutine(PokemonParam capturedPokemon, [Optional] Action onEnd) { return null; }

    public struct Param
    {
	    public PokeParty party;
        public PokemonParam pp;
        public int criticalCount;
        public EvolveSituation situation;
    }
}