using Dpr.UnderGround;
using Pml;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

public class UgResManager
{
    public const string DataAssetName = "data/ugdata";

    private static Dictionary<string, UgEncount> UgEncounts;
    private static UgPokemonData UgPokemonData;

    public static UgRandMark UgRandMark { private set; get; }
    public static UgMiniMap UgMiniMap { private set; get; }
    public static UgIconImages UgIconImages { private set; get; }
    public static GameObject UgCanvasPrefab { private set; get; }
    public static GameObject UgFieldManagerPrefab { private set; get; }

    private static GameObject UgEmoticonSetPrefab;

    public static UgEmoticonSet UgEmoticonSet { private set; get; }

    private static GameObject UgInfoSetPrefab;

    public static UgInfoSet UgInfoSet { private set; get; }
    public static UgEncountLevel UgEncountLevel { private set; get; }
    public static UgSpecialPokemon UgSpecialPokemon { private set; get; }
    public static UgPokemonPos UgPokemonPos { private set; get; }
    public static UgNpcPos UgNpcPos { private set; get; }
    public static UgNpcList UgNpcList { private set; get; }
    public static UgNpcTalk UgNpcTalk { private set; get; }
    public static UgDrillUsablePositions UgDrillUsablePositions { private set; get; }
    public static UgDigFossilePosGroups UgDigFossilePosGroups { private set; get; }
    public static UgAllDigFossilePos UgAllDigFossilePos { private set; get; }
    public static UgTamagoWazaIgnoreTable UgTamagoWazaIgnoreTable { private set; get; }

    private static bool _isDataLoadRequest;
    private static bool _isDataLoadEnd;
    private static Action _onPostLoaded;
    private static GameObject UgCanvas;
    private static GameObject _createDigManagerPrefab;
    private static List<AppendData> _assetOpe;
    
    public static bool IsDataLoadEnd
    {
        get =>  UgEncounts != null &&
            UgPokemonData != null &&
            UgRandMark != null &&
            UgMiniMap != null &&
            UgIconImages != null &&
            UgCanvasPrefab != null &&
            UgEncountLevel != null &&
            UgSpecialPokemon != null &&
            UgPokemonPos != null &&
            UgNpcPos != null &&
            UgNpcList != null &&
            UgNpcTalk != null &&
            UgDrillUsablePositions != null &&
            UgDigFossilePosGroups != null &&
            UgAllDigFossilePos != null &&
            UgTamagoWazaIgnoreTable != null &&
            UgEmoticonSetPrefab != null &&
            UgInfoSetPrefab != null;
    }

    // TODO
    public static void UnLoad() { }

    // TODO
    public static void DataLoadRequest(Action callback) { }

    // TODO
    private static IEnumerator DataLoad() { return null; }

    // TODO
    public static IEnumerator CreateAsset() { return null; }

    // TODO
    public static GameObject GetUgCanvas() { return null; }

    // TODO
    public static void AppendAsset(PokemonParam param, Action<GameObject> callback) { }

    // TODO
    public static IEnumerator DispathAsset() { return null; }

    // TODO
    public static void AssetBundleUnload() { }

    public static UgEncount GetUgEncount(int randMarkID)
    {
        return UgEncounts[Array.Find(UgRandMark.table, x => x.id == randMarkID).FileName];
    }

    public static UgPokemonData.Sheettable GetUgPokeData(MonsNo monsNo)
    {
        return Array.Find(UgPokemonData.table, x => x.monsno == monsNo);
    }

    public class AppendData
    {
	    public AssetRequestOperation Operation;
        public Action<GameObject> callback;
    }
}