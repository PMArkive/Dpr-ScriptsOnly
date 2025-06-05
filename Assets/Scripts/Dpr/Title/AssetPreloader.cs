using Dpr.EvScript;
using GameData;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Title
{
    public static class AssetPreloader
    {
        private static List<string> _preloadRequestList = new List<string>();
        public static bool IsLoading { get; set; } = false;

        public static IEnumerator PreloadAssetBundle()
        {
            var sw = new SimpleStopwatch("AssetPreloader.PreloadAssetBundle()");
            IsLoading = true;

            // Result is ignored in decomp, so presumed log
            var elapsedStart = sw.elapsedMilliseconds;
            //Debug.Log(elapsedStart);

            if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            {
                var zoneData = GameManager.mapInfo[(int)PlayerWork.transitionZoneID];

                if (EntityManager.activeFieldPlayer == null)
                {
                    for (int i=0; i<DataManager.CharacterDressData.Data.Length; i++)
                    {
                        var item = DataManager.CharacterDressData.Data[i];
                        if (item.Index == PlayerWork.playerFashion)
                        {
                            _preloadRequestList.Add("persons/field/" + item.FieldGraphic);
                            if (AssetManager.AppendAssetBundleRequest("persons/field/" + item.FieldGraphic, true, null, null) != null)
                                yield return AssetManager.DispatchRequests(null);
                            else
                                break;
                        }
                    }

                    yield return LoadAssetBundle("persons/field/fc0001_00");
                }

                if (!PlayerWork.FieldCacheFlag)
                {
                    yield return LoadAssetBundle(zoneData.AssetBundleName ?? "");
                }
            }

            yield return LoadAssetBundle("sb/sbcontroller");

            yield return LoadAssetBundle("ev_script");

            if (PlayerWork.transitionZoneID == ZoneID.UNKNOWN)
                yield return EvDataManager.Instanse.PreRequestAssetSetUp(GameManager.mapInfo[(int)ZoneID.T01R0202].AreaID);
            else
                yield return EvDataManager.Instanse.PreRequestAssetSetUp(GameManager.mapInfo[(int)PlayerWork.transitionZoneID].AreaID);

            // Result is ignored in decomp, so presumed log
            var elapsedEnd = sw.elapsedMilliseconds;
            //Debug.Log(elapsedEnd);

            IsLoading = false;
            sw.Dispose();
        }

        public static IEnumerator LoadAssetBundle(string path)
        {
            _preloadRequestList.Add(path);
            AssetManager.RequestAssetBundle(path, true, null, null);
            yield return AssetManager.DispatchRequests(null);
        }

        public static void UnloadPreloadAssetBundle()
        {
            foreach (var item in _preloadRequestList)
                AssetManager.UnloadAssetBundle(item);

            _preloadRequestList.Clear();
        }
    }
}
