using SmartPoint.AssetAssistant;

namespace Dpr
{
    public class AssetBundleUnloader : RefCounted
    {
        private string _assetBundleName;
        private bool _isUnloadAllLoadedObjects;
        private int _unloadDelayFrameCount = 3;
        private bool _isUnloaded;

        public string assetBundleName { get => _assetBundleName; set => _assetBundleName = value; }
        public bool isUnloadAllLoadedObjects { get => _isUnloadAllLoadedObjects; set => _isUnloadAllLoadedObjects = value; }
        public int unloadDelayFrameCount { get => _unloadDelayFrameCount; set => _unloadDelayFrameCount = value; }
        public bool isUnloaded { get => _isUnloaded; set => _isUnloaded = value; }

        public override int Release()
        {
            if (referencedCount != 0)
            {
                var baseResult = base.Release();
                if (baseResult != 0)
                    return baseResult;

                _unloadDelayFrameCount = 3;
                AssetBundleUnloadManager.RegisterUnload(this);
            }

            return 0;
        }
    }
}