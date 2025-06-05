using DG.Tweening;
using Effect;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.UnderGround.LightStone
{
	public class LightStoneManager : SingletonMonoBehaviour<LightStoneManager>
	{
		[SerializeField]
		private LightStoneTable bonusTable;
		[SerializeField]
		private LightStonePosTable posTable;
		[SerializeField]
		private GameObject lightStonePrefab;
		[SerializeField]
		private float pokemonDigRange = 5.0f;
		[SerializeField]
		private float lightStoneGetRange = 1.0f;
		[SerializeField]
		private Vector3 getEffectOffset = Vector3.zero;
		[SerializeField]
		private float smallEffectScale = 1.2f;
		[SerializeField]
		private float largeEffectScale = 1.5f;
		[SerializeField]
		private float getEffectScale = 1.2f;

		private Dictionary<ZoneID, LightStonePosTable.SheetData> tableData = new Dictionary<ZoneID, LightStonePosTable.SheetData>();
		private Dictionary<UgZoneID, LightStoneTable.SheetData> bonusTableData = new Dictionary<UgZoneID, LightStoneTable.SheetData>();
		private List<LightStone> allDigletList = new List<LightStone>();
		private List<LightStone> allDugtrioList = new List<LightStone>();
		private List<LightStone> activeLightStoneList = new List<LightStone>();
		private List<LightStone> deleteList = new List<LightStone>();
		private EffectData lightStoneSmallEfData;
		private EffectData lightStoneLargeEfData;
		private EffectData smokeEfData;
		private EffectData lightStoneGetEfData;
		private bool isBonus;
		private Tween bonusTween;
		
		public bool IsBonusTime { get => UgFieldManager.Instance.isKousekiBonus; }
		public int LightStoneCount { get => UgFieldManager.Instance.KousekiCount; }
		public int LightStoneMaxNum { get => UgFieldManager.KOUSEKI_BONUS_START_NUM; }
		public int LightStoneCountMine { get; set; }
		public EffectData LightStoneSmallEfData { get => lightStoneSmallEfData; }
		public EffectData LightStoneLargeEfData { get => lightStoneLargeEfData; }
		public EffectData SmokeEfData { get => smokeEfData; }
		public float SmallEffectScale { get => smallEffectScale; }
		public float LargeEffectScale { get => largeEffectScale; }
		public float PokemonDigRange { get => pokemonDigRange; }
		public float LightStoneGetRange { get => lightStoneGetRange; }
		
		// TODO
		public static int BonusTimeMax { get; }

        private static Dictionary<UgZoneID, List<ZoneID>> UgZoneList = new Dictionary<UgZoneID, List<ZoneID>>()
		{
			{
				UgZoneID.UGA, new List<ZoneID>()
				{
					ZoneID.UGA01, ZoneID.UGA02, ZoneID.UGA03, ZoneID.UGA04,
					ZoneID.UGA05, ZoneID.UGA06, ZoneID.UGA07, ZoneID.UGA08,
                    ZoneID.UGA09, ZoneID.UGA10,
                }
			},
            {
                UgZoneID.UGB, new List<ZoneID>()
                {
                    ZoneID.UGB01, ZoneID.UGB02, ZoneID.UGB03, ZoneID.UGB04,
                    ZoneID.UGB05, ZoneID.UGB06, ZoneID.UGB07,
                }
            },
            {
                UgZoneID.UGC, new List<ZoneID>()
                {
                    ZoneID.UGC01,
                }
            },
            {
                UgZoneID.UGD, new List<ZoneID>()
                {
                    ZoneID.UGD01, ZoneID.UGD02, ZoneID.UGD03, ZoneID.UGD04,
                    ZoneID.UGD05,
                }
            },
            {
                UgZoneID.UGE, new List<ZoneID>()
                {
                    ZoneID.UGE01, ZoneID.UGE02, ZoneID.UGE03, ZoneID.UGE04,
                    ZoneID.UGE05,
                }
            },
            {
                UgZoneID.UGF, new List<ZoneID>()
                {
                    ZoneID.UGF01, ZoneID.UGF02, ZoneID.UGF03, ZoneID.UGF04,
                    ZoneID.UGF05, ZoneID.UGF06, ZoneID.UGF07,
                }
            },
        };

        // TODO
		public static IEnumerator GetBonusTimeMax(Action<int> onLoad) { return default; }
		
		// TODO
		public static void StartBonusTime() { }
		
		// TODO
		private IEnumerator Start() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void AddLightStone(int num) { }
		
		// TODO
		public int GetBonusTimeMinuteMax() { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateLightStone(float deltaTime) { }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private void RestartEffect() { }
		
		// TODO
		private LightStone ActiveLightStone(Vector2Int gridPos, MonsNo monsNo) { return default; }
		
		// TODO
		public void StartBonus() { }
		
		// TODO
		private void SaveReport() { }
		
		// TODO
		private void ResetLightStone() { }
		
		// TODO
		private void Clear() { }
		
		// TODO
		private LightStone SpawnLightStone(MonsNo monsNo) { return default; }
		
		// TODO
		private List<Vector2Int> LotteryPosiiton(ZoneID zoneID) { return default; }
		
		// TODO
		private MonsNo LotteryMonsNo(ZoneID zoneID) { return default; }
		
		// TODO
		private UgZoneID GetUgZoneID(ZoneID zoneID) { return default; }

		private enum UgZoneID : int
		{
			NONE = 0,
			UGA = 1,
			UGB = 2,
			UGC = 3,
			UGD = 4,
			UGE = 5,
			UGF = 6,
		}
	}
}