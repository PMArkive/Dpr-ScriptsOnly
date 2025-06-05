using SmartPoint.AssetAssistant;
using UnityEngine;

namespace Effect
{
    public class EffectData : RefCounted
    {
        private GameObject _prefab;
        private bool _isLooped;
        private string _assetBundleName;

        public GameObject prefab { get => _prefab; }
        public bool isLooped { get => _isLooped; }
        public string assetBundleName { get => _assetBundleName; }

        public EffectData(string assetBundleName)
        {
            _assetBundleName = assetBundleName;
        }

        public void Setup(GameObject prefab)
        {
            _prefab = prefab;
            _isLooped = ComputeIsLooped(prefab, out ParticleSystem _);
        }

        // TODO
        public static bool ComputeIsLooped(GameObject prefab, out ParticleSystem baseParticleSystem)
        {
            baseParticleSystem = null;
            return false;
        }

        public override int Release()
        {
            var refs = base.Release();

            if (refs == 0 && EffectManager.isInstantiated)
                EffectManager.Instance._Unload(this);

            return refs;
        }
    }
}