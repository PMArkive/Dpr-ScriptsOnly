using System.Collections.Generic;
using XLSXContent;

namespace Dpr.FureaiHiroba
{
    public sealed class PokeSanpoActionModel : PokeFureaiActionModel
    {
        private PokeAction PrevAction;
        private static readonly Dictionary<int, List<int>> ActionFlow = new Dictionary<int, List<int>>()
        {
            { 0, new List<int>() { 0, 1, 2, 3 } },
            { 1, new List<int>() { 0, 1, 2 } },
            { 2, new List<int>() { 0, 1, 2 } },
            { 3, new List<int>() { 0 } },
        };
        private List<PokeActionWhight> pokeActionWhights;

        public PokeSanpoActionModel(FreeSanpoActionProbability.SheetSheet1 actionProbability)
        {
            Init();
            IntervalTime = 0.0f;

            pokeActionWhights = new List<PokeActionWhight>
            {
                new PokeActionWhight("Kyoro", 0, actionProbability.Kyoro),
                new PokeActionWhight("Uro", 1, actionProbability.UroUro),
                new PokeActionWhight("Run", 2, actionProbability.Run),
                new PokeActionWhight("Sleep", 3, actionProbability.Sleep),
            };
        }

        public void Destroy()
        {
            pokeActionWhights?.Clear();
            pokeActionWhights = null;
        }

        public enum PokeAction : int
        {
            WaitKyoro = 0,
            UroUro = 1,
            Run = 2,
            Sleep = 3,
            Engi = 4,
            Dotuki = 5,
            Hoe = 6,
            Watya = 7,
            _None = 8,
        }
    }
}