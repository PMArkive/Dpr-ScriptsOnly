using SmartPoint.AssetAssistant;
using System.Collections.Generic;

namespace Dpr
{
    public static class AssetBundleUnloadManager
    {
        private static HashSet<AssetBundleUnloader> _unloads = new HashSet<AssetBundleUnloader>();
        private static bool isInitialized = false;

        public static void Initialize()
        {
            if (isInitialized)
                return;

            isInitialized = true;

            Sequencer.lateUpdate += OnLateUpdate;
        }

        public static void Terminate()
        {
            if (!isInitialized)
                return;

            isInitialized = false;

            Sequencer.lateUpdate -= OnLateUpdate;
        }

        public static void RegisterUnload(AssetBundleUnloader unloader)
        {
            if (!isInitialized)
                Initialize();

            _unloads.Add(unloader);
        }

        public static void UnloadDirect(AssetBundleUnloader unloader)
        {
            AssetBundleCache.ReleaseFromAssetBundleName(unloader.assetBundleName, unloader.isUnloadAllLoadedObjects);
            unloader.isUnloaded = true;
        }

        private static void OnLateUpdate(float deltaTime)
        {
            _unloads.RemoveWhere(unloader =>
            {
                if (unloader.unloadDelayFrameCount > 0)
                {
                    unloader.unloadDelayFrameCount--;
                    return false;
                }

                AssetBundleCache.ReleaseFromAssetBundleName(unloader.assetBundleName, unloader.isUnloadAllLoadedObjects);
                unloader.isUnloaded = true;
                return true;
            });
        }
    }
}