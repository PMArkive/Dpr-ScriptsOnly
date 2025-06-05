using SmartPoint.AssetAssistant.UnityExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleCache : RefCounted
    {
        private static Dictionary<string, AssetBundleCache> _container = new Dictionary<string, AssetBundleCache>();
        private AssetBundleRecord _record;
        private AssetBundle _assetBundle;
        private bool _isLoaded;
        private string[] _variants;
        private Object[] _loadedAssets = ArrayHelper.Empty<Object>();
        private bool _unloadAllLoadedObjects;
        private string[] _remapDependencies;

        public Object loadedFirstAsset { get => _loadedAssets[0]; }

        public T FindFirstAsset<T>() where T : Object
        {
            foreach (var asset in _loadedAssets)
            {
                if (asset != null && asset is T)
                    return (T)asset;
            }

            return null;
        }

        public Object[] loadedAssets { get => _loadedAssets; set => _loadedAssets = value ?? ArrayHelper.Empty<Object>(); }
        public string[] variants { get => _variants; }
        public string[] remapDependencies { get => _remapDependencies; }
        public bool allLoaded { get => _loadedAssets.All(x => x != null); }

        public AssetBundleRecord record
        {
            get => _record;
            set
            {
                if (_record != value)
                {
                    if (_record != null)
                    {
                        for (int i=0; i<_loadedAssets.Length; i++)
                            _loadedAssets[i] = null;

                        _container.Remove(_record.assetBundleName);
                    }

                    if (value == null)
                    {
                        _loadedAssets = ArrayHelper.Empty<Object>();
                    }
                    else
                    {
                        _container.Add(value.assetBundleName, this);
                        _loadedAssets = new Object[value.assetPaths.Length];
                    }
                }

                _record = value;
            }
        }

        public AssetBundle assetBundle { get => _assetBundle; set => _assetBundle = value; }
        public bool isLoaded { get => _isLoaded; set => _isLoaded = value; }

        public bool canLoadAsset
        {
            get
            {
                if (!_isLoaded)
                    return false;

                foreach (string dependency in _remapDependencies)
                {
                    if (string.IsNullOrEmpty(dependency))
                        return false;

                    if (!_container.TryGetValue(dependency, out AssetBundleCache cache) || cache == null || !cache.isLoaded)
                        return false;
                }

                return true;
            }
        }

        private AssetBundleCache()
        {
            // Empty
        }

        public override int Release()
        {
            if (base.Release() > 0)
            {
                _unloadAllLoadedObjects = false;
                return referencedCount;
            }

            // TODO: Fix the null ptr with _record
            Debug.Log("Unload asset-bundle: " + _record.assetBundleName);
            //Debug.Log("Unload asset-bundle: ");
            record = null;

            if (referencedCount > -1)
            {
                if (_assetBundle != null)
                {
                    _assetBundle.Unload(_unloadAllLoadedObjects);
                    _assetBundle = null;
                }

                return referencedCount;
            }

            // TODO: Fix the null ptr with _record
            Debug.LogWarning("Release AssetBundle Error: " + _record.assetBundleName + "(" + referencedCount + ")");
            //Debug.LogWarning("Release AssetBundle Error: " + "(" + referencedCount + ")");
            referencedCount = 0;
            return 0;
        }

        public static bool Contains(string assetBundleName, bool includeNotLoaded = false)
        {
            if (string.IsNullOrEmpty(assetBundleName))
                return false;

            if (_container.TryGetValue(assetBundleName, out AssetBundleCache cache) && (cache == null || cache._isLoaded))
                return cache != null;

            return false;
        }

        public static AssetBundleCache Add(AssetBundleRecord record, [Optional, DefaultParameterValue(false)] bool isLoaded, [Optional] string[] variants)
        {
            if (record == null)
                Debug.Log("Record is null!");

            AssetBundleCache cache = new AssetBundleCache
            {
                _isLoaded = isLoaded,
                record = record,
                _variants = variants
            };

            if (variants == null || variants.Length == 0)
            {
                cache._remapDependencies = record.allDependencies;
            }
            else
            {
                cache._remapDependencies = new string[record.allDependencies.Length];
                for (int i=0; i<record.allDependencies.Length; i++)
                {
                    cache._remapDependencies[i] = AssetManager.RemapVariantName(record.allDependencies[i], variants);
                }
            }

            return cache;
        }

        public static AssetBundleCache Get(string assetBundleName, bool includeNotLoaded = false)
        {
            if (string.IsNullOrEmpty(assetBundleName))
                return null;

            if (!_container.TryGetValue(assetBundleName, out AssetBundleCache cache))
                return null;

            if (cache != null && !includeNotLoaded && !cache.isLoaded)
                return null;

            return cache;
        }

        public static int ReleaseFromAssetBundleChache(AssetBundleCache cache, bool unloadAllLoadedObjects = false)
        {
            if (cache == null)
                return 0;

            foreach (var item in cache._remapDependencies)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (_container.TryGetValue(item, out AssetBundleCache depCache) && depCache != null && depCache.isLoaded)
                    {
                        depCache._unloadAllLoadedObjects = unloadAllLoadedObjects;
                        depCache.Release();
                    }
                }
            }

            cache._unloadAllLoadedObjects = unloadAllLoadedObjects;
            return cache.Release();
        }

        public static int ReleaseFromAssetBundleName(string assetBundleName, bool unloadAllLoadedObjects = false)
        {
            if (string.IsNullOrEmpty(assetBundleName))
                return ReleaseFromAssetBundleChache(null, unloadAllLoadedObjects);

            if (!_container.TryGetValue(assetBundleName, out AssetBundleCache cache))
                return ReleaseFromAssetBundleChache(null, unloadAllLoadedObjects);

            if (cache != null && !cache._isLoaded)
                return ReleaseFromAssetBundleChache(null, unloadAllLoadedObjects);

            return ReleaseFromAssetBundleChache(cache, unloadAllLoadedObjects);
        }

        public static void Destroy()
        {
            string log = string.Empty;
            int refs = 0;
            foreach (var item in _container)
            {
                refs += item.Value.referencedCount;
                log += item.Key + ": " + item.Value.referencedCount + "\n";
            }

            if (refs == 0)
                return;

            Debug.LogWarning("Asset-bundle leaks: object " + _container.Count + " reference " + refs + "\n" + log);
        }
    }
}