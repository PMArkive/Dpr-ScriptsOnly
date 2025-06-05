using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

public sealed class BattleConnector : SceneConnector
{
	private static AssetRequestOperation bgRequestOperatioin = null;
	private static AssetRequestOperation skyRequestOperatioin = null;
	private static List<AssetRequestOperation> prefetchAssetBundleList = new List<AssetRequestOperation>(0x20); // TODO: Find a const for this?
	public static bool isKeepSetup = false;
	private static ArenaInfo.SheetArenaData _currentArenaData = null;
	private static ArenaInfo.SheetArenaData _prevArenaData = null;
	private static GameObject _cachedBackgroundObject = null;
	private static GameObject _cachedSkyObject = null;
	private static BattleFieldObject _battleFieldObject = null;
	
	public static int arenaIndex { get; set; }
	
	// TODO
	public static ArenaInfo.SheetArenaData currentArenaData { get; set; }
	
	// TODO
	public GameObject cachedBackgroundObject { get; }
	
	// TODO
	public GameObject cachedSkyObject { get; }
	
	// TODO
	public static BattleFieldObject BattleFieldObject { get; }
	
	// TODO
	public override bool SwitchingOperation(SceneID target) { return default; }
	
	// TODO
	public override IEnumerator PrepareOperation() { return default; }
	
	// TODO
	public static void PrepareOperationStatic() { }
	
	// TODO
	public override IEnumerator SetupOperation() { return default; }
	
	// TODO
	private static void DestroyBackgrounds() { }
	
	// TODO
	private static void PrefetchAssetBundles(BATTLE_SETUP_PARAM bsp) { }
	
	// TODO
	private static void prefetchPlayer(MyStatus myStatus) { }
	
	// TODO
	private static void prefetchTrainer(BSP_TRAINER_DATA trainerData) { }
	
	// TODO
	private static void prefetchPoke(PokemonParam pp, [Optional] string forcedAssetBundleName) { }
	
	// TODO
	public static void ReleasePrefetchAssetBundles() { }
	
	// TODO
	private static void prefetchAssetBundleRequest(string path) { }
	
	// TODO
	private static bool isKeepWaitingPrefetchAssetBundles() { return default; }
}