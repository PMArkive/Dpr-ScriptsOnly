using Pml.PokePara;
using System;

[Serializable]
public struct AzukariyaData
{
    public SerializedPokemonFull[] pokemonParam;
    public bool eggExist;
    public ulong eggSeed;
    public int eggStepCount;

    // TODO
    public void Get(PokemonParam pp, int index) { }

    // TODO
    public PokemonParam Get(int index) { return null; }

    // TODO
    public void Set(int index, PokemonParam pp) { }

    // TODO
    public void Clear() { }

    // TODO
    public void Initialize() { }
}