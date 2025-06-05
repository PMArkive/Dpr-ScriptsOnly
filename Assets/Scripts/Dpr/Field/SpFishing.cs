using Pml;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field
{
    public static class SpFishing
    {
        public const int FISH_POINT_MAX = 4;
        private const int SP_FISH_LV_MAX = 20;
        private const int SP_FISH_LV_MIN = 10;
        private const MonsNo SP_MONS_NO = MonsNo.HINBASU;
        private static RareFishTable _rareFishTable;

        // TODO
        public static bool CheckPoint(ref Vector2Int position) { return false; }

        // TODO
        private static void LotPoint(ref int[] point) { }

        public static void SpFishing_GetMaxMinLv(out int outMaxLv, out int outMinLv)
        {
            outMaxLv = SP_FISH_LV_MAX;
            outMinLv = SP_FISH_LV_MIN;
        }

        public static void SpFishing_GetMonsNo(out MonsNo outMonsNo)
        {
            outMonsNo = SP_MONS_NO;
        }

        public static IEnumerator LoadFishingData()
        {
            if (_rareFishTable == null)
            {
                AssetManager.AppendAssetBundleRequest("spfishing", true, null, null);
                yield return AssetManager.DispatchRequests((eventType, name, asset) =>
                {
                    if (asset == null)
                        return;

                    _rareFishTable = asset as RareFishTable;
                });

                _ = _rareFishTable == null;
            }
        }

        public static void UnloadFishngData()
        {
            _rareFishTable = null;
        }
    }
}