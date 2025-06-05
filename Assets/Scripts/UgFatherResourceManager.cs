using Dpr.UnderGround.UgFather;
using System;
using System.Collections;
using UnityEngine;

public class UgFatherResourceManager
{
    public const string DataAssetName = "ugfdata";

    public static UgFatherManager UgFather { get; set; }
    public static bool IsDataLoadEnd { get => ugFatherManagerPrefab != null; }

    private static GameObject ugFatherManagerPrefab;
    private static bool _isDataLoadRequest;
    private static bool _isDataLoadEnd;
    private static Action _onPostLoaded;

    // TODO
    public static void UnLoad() { }

    // TODO
    public static void DataLoadRequest(Action callback) { }

    // TODO
    private static IEnumerator DataLoad() { return null; }

    // TODO
    public static IEnumerator CreateAsset() { return null; }
}