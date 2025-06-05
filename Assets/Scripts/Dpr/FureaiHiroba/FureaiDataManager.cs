using Pml.PokePara;
using Pml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;
using System;

namespace Dpr.FureaiHiroba
{
    public class FureaiDataManager : MonoBehaviour
    {
        public static FureaiDataManager Instance = null;
        private const string Path_MasterData = "fureai/masterdata";
        private const string Path_Prefabs = "fureai/prefabs";
        public const string ASSET_BUNDLE_PATH_FX = "effect/prefab/battle";
        private GameObject FureaiManager;
        public Dictionary<int, UnityEngine.Object> PokeAssets = new Dictionary<int, UnityEngine.Object>();
        private Dictionary<Type, UnityEngine.Object> MasterData = new Dictionary<Type, UnityEngine.Object>();

        public List<FureaiPokeScaleTable.SheetTable> scaleTable { get; set; }
        public List<FreeSanpoGridPosition.SheetSheet1> gridPositions { get; set; }
        public List<PokeWalkingActionNakayoshi.SheetSheet1> nakayoshiHoseiData { get; set; }
        public List<PokeWalkingActionSeikaku.SheetSheet1> seikakuHoseiData { get; set; }
        public List<HirobaPokeTalk.SheetSheet1> talkList { get; set; }
        public List<FreeSanpoKuse.SheetSheet1> ActionKuseList { get; set; }
        public List<FreeSanpoCanActions.SheetSheet1> CanActionList { get; set; }
        public List<FreeSanpoActionProbability.SheetSheet1> ActionProbabilityList { get; set; }
        public List<MonohiroiKinomi.SheetSheet1> MonohiroiKinomiList { get; set; }
        public List<MonohiroiSonota.SheetSheet1> MonohiroiSonotaList { get; set; }
        public List<EffectPosData> EffectPosData { get; set; }
        public List<GameObject> EffectList { get; set; }

        public List<int> EnterblePokeList = new List<int>();
        public static readonly Vector2Int[] DontEnterPoints = new Vector2Int[20]
        {
            new Vector2Int(42, 11), new Vector2Int(41, 10), new Vector2Int(42, 10), new Vector2Int(43, 10),
            new Vector2Int(41, 9),  new Vector2Int(42, 9),  new Vector2Int(43, 9),  new Vector2Int(50, 11),
            new Vector2Int(49, 10), new Vector2Int(50, 10), new Vector2Int(51, 10), new Vector2Int(49, 9),
            new Vector2Int(50, 9),  new Vector2Int(51, 9),  new Vector2Int(12, 49), new Vector2Int(11, 48),
            new Vector2Int(11, 49), new Vector2Int(51, 49), new Vector2Int(52, 49), new Vector2Int(52, 48),
        };

        // TODO
        private void Awake() { }

        // TODO
        public void Destroy() { }

        // TODO
        public IEnumerator Start() { return null; }

        // TODO
        public IEnumerator Init() { return null; }

        // TODO
        public UnityEngine.Object GetPokeAsset(PokemonParam pokePara) { return null; }

        // TODO
        public T GetMD<T>() { return default(T); }

        // TODO
        public IEnumerator LoadMD() { return null; }

        // TODO
        public static IEnumerator LoadPokeAsset(MonsNo monsNo, Dictionary<int, UnityEngine.Object> Assets, ushort formNo, Sex sex, bool isRare = false, int AssetBundleType = 1) { return null; }

        // TODO
        public IEnumerator LoadManagerPrefab() { return null; }

        // TODO
        public GameObject GetEffect(EffectName effect) { return null; }

        // TODO
        public void GetObjectByName(Transform Tra, string searchName, string path, EffectPosData data) { }

        // TODO
        public Vector3 GetHeadPosition(int MonsNo) { return Vector3.zero; }

        public enum EffectName : int
        {
            Sleep = 0,
        }
    }
}