using Dpr.EvScript;
using Dpr.SubContents;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public sealed class FureaiHiroba_PokeFactory : MonoBehaviour
    {
        private FureaiDataManager dataMng;

        public List<FureaiPokeModel> PokeList { get; set; }

        public List<int> NumberList;
        public List<KeyValuePair<int, int>> PairPosition = new List<KeyValuePair<int, int>>()
        {
            new KeyValuePair<int, int>(10, 11),
            new KeyValuePair<int, int>(12, 13),
            new KeyValuePair<int, int>(14, 15),
        };
        [Button("CreatePositionNoList", "再配置", new object[1] { 6 })]
        public int Button01;

        // TODO
        public void Init(FureaiDataManager mng) { }

        // TODO
        public void CreatePositionNoList(int pokeNum) { }

        // TODO
        public IEnumerator AddPoke(PokemonParam pokePara, Action<FureaiPokeModel> OnCreateModel, [Optional, DefaultParameterValue(false)] bool CreatePlayerPosition, [Optional] Vector2Int InitGrid) { return null; }

        // TODO
        private void OnTalk(EvDataManager.EntityParam param) { }

        // TODO
        private FureaiPokeModel CreateModel(FieldPokemonEntity pokeEntity, PokemonParam pokePara) { return null; }

        // TODO
        public static void SetPokeScale(Transform pokeTransform, PokemonParam p) { }

        // TODO
        public void SetFureaiPokeScale(Transform pokeTransform, PokemonParam p) { }

        // TODO
        public void SetPokePosition(bool CreatePlayerPosition, FieldPlayerEntity PlayerEntity, FureaiPokeModel pokeModel, Vector2Int InitGrid) { }

        // TODO
        public void SetPairModel(FureaiPokeModel model) { }

        // TODO
        private void OnDestroy() { }
    }
}