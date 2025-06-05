using Dpr.UnderGround.LightStone;
using Pml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

public class LightStoneResourcesManager
{
    private const string DataAssetName = "lightstone/prefabs/lightstonemanager";
    private const string PokemonAssetPath = "pokemons/field/{0}";

    public static LightStoneManager LightStoneManager { get; set; }
    public static GameObject DhigudaPrefab { get; set; }
    public static GameObject DagutorioPrefab { get; set; }
    public static PokemonInfo.SheetCatalog DhigudaCatalog { get; set; }
    public static PokemonInfo.SheetCatalog DagutorioCatalog { get; set; }

    private static GameObject ugLightStoneManagerPrefab;

    public static bool IsDataLoadEnd { get => ugLightStoneManagerPrefab != null && DhigudaPrefab != null && DagutorioPrefab != null; }

    private static bool _isDataLoadRequest = false;
    private static bool _isDataLoadEnd = false;
    private static Action _onPostLoaded;
    private static List<string> _assetPaths = new List<string>();

    // TODO
    public static void UnLoad() { }

    // TODO
    public static void DataLoadRequest(Action callback) { }

    // TODO
    private static IEnumerator DataLoad() { return null; }

    // TODO
    public static IEnumerator CreateAsset() { return null; }

    // TODO
    private static PokemonInfo.SheetCatalog GetPokemonCatalog(MonsNo monsNo) { return null; }
}