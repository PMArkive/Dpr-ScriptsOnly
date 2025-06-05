using Dpr.FureaiHiroba;
using Dpr.Item;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.SubContents
{
    public class PoffinCookingSceneManager : SingletonMonoBehaviour<PoffinCookingSceneManager>
    {
        private UnityEngine.Object PofinManagerPrefab;
        private const string Path_MasterData = "fureai/masterdata";
        private const string Path_UIPrefabs = "ui/prefab/pofinplayingui";
        private const string Path_CookPrefabs_Pot = "objects/ob1014_00";
        private const string Path_CookPrefabs_Poffin = "objects/ob1014_01";
        private const string Path_PoffinManagerPrefab = "poffin/prefabs";
        public UnityEngine.Object uiPofinPlaying;
        public UnityEngine.Object Cook_Pot;
        public UnityEngine.Object Cook_Pofin;

        public List<PoffinResult.SheetSheet1> PofinData { get; set; }
        public List<PoffinNakayoshiScoreHosei.SheetSheet1> PofinNakayoshiScoreHoseiData { get; set; }

        private List<GameObject> PofinNonActives = new List<GameObject>();
        private Vector3 playerPos;

        // TODO
        private IEnumerator Start() { return null; }

        // TODO
        private void OnDestroy() { }

        // TODO
        public IEnumerator LoadMD() { return null; }

        // TODO
        public IEnumerator LoadPofinPrefab() { return null; }

        // TODO
        public IEnumerator CreatePofinManager(List<ItemInfo> kinomiList, Action OnComplete, [Optional] List<FureaiPokeModel> pokes) { return null; }

        // TODO
        public void SetActiveForPofin(bool isActive) { }

        // TODO
        private void SetActiveFureaiHiroba() { }

        // TODO
        private void SetActivePoffinHouse() { }
    }
}