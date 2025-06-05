using System;
namespace DPData
{
    [Serializable]
    public struct DENDOU_RECORD
    {
        public DENDOU_POKEMON_DATA_INSIDE[] pokemon;
        public GMTIME time;
    }
}