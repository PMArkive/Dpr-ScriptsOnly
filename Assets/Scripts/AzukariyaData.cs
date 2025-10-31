using Pml.PokePara;
using System;

[Serializable]
public struct AzukariyaData
{
    public SerializedPokemonFull[] pokemonParam;
    public bool eggExist;
    public ulong eggSeed;
    public int eggStepCount;

    public void Get(PokemonParam pp, int index)
    {
        pp.Deserialize_Full(pokemonParam[index]);
    }

    public PokemonParam Get(int index)
    {
        var param = new PokemonParam();
        Get(param, index);
        return param;
    }

    public void Set(int index, PokemonParam pp)
    {
        pp.Serialize_Full(pokemonParam[index].buffer);
    }

    public void Clear()
    {
        pokemonParam = new SerializedPokemonFull[AzukariyaWork.POKE_MAX];
        for (int i = 0; i < pokemonParam.Length; i++)
            pokemonParam[i].CreateWorkIfNeed();
    }

    public void Initialize()
    {
        Clear();
    }
}