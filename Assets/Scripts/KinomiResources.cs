using GameData;
using SmartPoint.AssetAssistant;
using UnityEngine;

public class KinomiResources
{
    private static readonly string[] CommonAssetNames = new string[3]
    {
        "gimmick/kinowet", "gimmick/kinomori", "gimmick/kinoseeding",
    };
    private GameObject[] CommonObjects;
    private AssetRequestOperation[] CommonObjectLoads;
    private GameObject[] GrowedObjects;
    private AssetRequestOperation[] GrowedObjectLoads;
    private int LoadRequestCount = -1;
    private int LoadedCount;

    public void LoadAll()
    {
        CommonObjects = new GameObject[3];
        CommonObjectLoads = new AssetRequestOperation[3];

        for (int i=0; i<CommonAssetNames.Length; i++)
        {
            int index = i;
            CommonObjectLoads[i] = AssetManager.AppendAssetBundleRequest(CommonAssetNames[i], true, (type, name, content) =>
            {
                if (type != RequestEventType.Activated)
                    return;

                OnLoadedCommonObject(index, content);
            }, null);
        }

        int growedLength = DataManager.KinomiData.Data.Length;
        GrowedObjects = new GameObject[growedLength];
        GrowedObjectLoads = new AssetRequestOperation[growedLength];

        for (int i=0; i<growedLength; i++)
        {
            int index = i;
            GrowedObjectLoads[i] = AssetManager.AppendAssetBundleRequest(string.Format("gimmick/kino{0:D3}", i+1), true, (type, name, content) =>
            {
                if (type != RequestEventType.Activated)
                    return;

                OnLoadedGrowedObject(index, content);
            }, null);
        }

        LoadRequestCount = growedLength + 3;
        LoadedCount = 0;

        AssetManager.DispatchRequests(null);
    }

    public void ReleaseAll()
    {
        for (int i=0; i<CommonObjects.Length; i++)
            CommonObjects[i] = null;

        CommonObjects = null;

        for (int i=0; i<GrowedObjects.Length; i++)
            GrowedObjects[i] = null;

        GrowedObjects = null;

        for (int i=0; i<CommonObjectLoads.Length; i++)
        {
            if (CommonObjectLoads[i] != null)
            {
                AssetManager.UnloadAssetBundle(CommonObjectLoads[i].assetBundleRequest.uri);
                CommonObjectLoads[i] = null;
            }
        }

        CommonObjectLoads = null;

        for (int i=0; i<GrowedObjectLoads.Length; i++)
        {
            if (GrowedObjectLoads[i] != null)
            {
                AssetManager.UnloadAssetBundle(GrowedObjectLoads[i].assetBundleRequest.uri);
                GrowedObjectLoads[i] = null;
            }
        }

        GrowedObjectLoads = null;
        LoadRequestCount = -1;
        LoadedCount = 0;
    }

    private void OnLoadedCommonObject(int index, Object content)
    {
        var go = content as GameObject;
        CommonObjects[index] = go;
        LoadedCount++;
    }

    private void OnLoadedGrowedObject(int index, Object content)
    {
        var go = content as GameObject;
        GrowedObjects[index] = go;
        LoadedCount++;
    }

    public bool IsValid()
    {
        return -1 < LoadRequestCount && LoadRequestCount <= LoadedCount;
    }

    public GameObject GetCommonObject(CommonObjectType type)
    {
        return CommonObjects[(int)type];
    }

    public GameObject GetGrowedObject(int tagNo)
    {
        return GrowedObjects[tagNo - 1];
    }

    public enum CommonObjectType : int
    {
        WetSoil = 0,
        MoriSoil = 1,
        Seeding = 2,
        Max = 3,
    }
}