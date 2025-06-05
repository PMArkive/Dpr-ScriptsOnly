using Dpr;
using Dpr.Battle.View;
using Effect;
using SmartPoint.AssetAssistant;
using SmartPoint.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

namespace Effect
{
    public class EffectManager : SingletonMonoBehaviour<EffectManager>
    {
        private EffectDatabase _dbEffects;
        private Dictionary<string, EffectData> _effectDatas = new Dictionary<string, EffectData>();
        private List<EffectInstance> _effectInstances = new List<EffectInstance>();
        private ObjectPool<EffectData, EffectInstance> _objectPool = new ObjectPool<EffectData, EffectInstance>();

        private static int _id_BackgroundTexture = Shader.PropertyToID("g_BackgroundTexture");

        private DepthOfField _dof;
        private List<ShaderVariantCollection> _shaderVariantCollections = new List<ShaderVariantCollection>();
        private Dictionary<string, AssetBundleUnloader> _assetBundleRefDict = new Dictionary<string, AssetBundleUnloader>();
        private string[] _commonAssetBundleNames = new string[2] { "fxparticle", "effect_common" };
        private bool _isLoadedDatabase;
        private bool _isLoadedResidents;
        private CameraParam _cameraParam = new CameraParam();

        public EffectDatabase dbEffects { get => _dbEffects; }

        private IEnumerator Start()
        {
            Sequencer.onDestroy += Destroy;
            yield return null;
        }

        private void OnEnable()
        {
            // Empty
        }

        private void OnDisable()
        {
            // Empty
        }

        private void Destroy()
        {
            Sequencer.onDestroy -= Destroy;

            for (int i=0; i<_commonAssetBundleNames.Length; i++)
                AssetManager.UnloadAssetBundle(_commonAssetBundleNames[i]);
        }

        public bool isLoadedDatabase { get => _isLoadedDatabase; }

        public void LoadDatabase()
        {
            Sequencer.Start(OpLoadDatabase());
        }

        private IEnumerator OpLoadDatabase()
        {
            _isLoadedDatabase = false;

            string[] bundleNames = { "masterdatas/effectdatabase" };
            for (int i=0; i<bundleNames.Length; i++)
                AssetManager.AppendAssetBundleRequest(bundleNames[i], true, null, null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var scriptableObject = asset as ScriptableObject;
                if (scriptableObject == null)
                    return;

                if (name != "EffectDatabase")
                    return;

                _dbEffects = scriptableObject as EffectDatabase;
            });

            _isLoadedDatabase = true;
        }

        public bool isLoadedResidents { get => _isLoadedResidents; }

        public void LoadResidents()
        {
            Sequencer.Start(OpLoadResidentAssetBundles());
        }

        private IEnumerator OpLoadResidentAssetBundles()
        {
            _isLoadedResidents = false;
            _shaderVariantCollections.Clear();

            for (int i=0; i<_commonAssetBundleNames.Length; i++)
                AssetManager.AppendAssetBundleRequest(_commonAssetBundleNames[i], true, null, null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var shaderVariantCollection = asset as ShaderVariantCollection;
                if (shaderVariantCollection == null)
                    return;

                _shaderVariantCollections.Add(shaderVariantCollection);
            });

            _isLoadedResidents = true;
        }

        public void Load(LoadParam[] loadParams, UnityAction<EffectData, bool> onLoaded)
        {
            StartCoroutine(OpLoad(loadParams, onLoaded));
        }

        public IEnumerator OpLoad(LoadParam[] loadParams, UnityAction<EffectData, bool> onLoaded)
        {
            int loadedCount = 0;

            List<EffectData> existData = null;
            if (onLoaded != null)
                existData = new List<EffectData>();

            for (int i=0; i<loadParams.Length; i++)
            {
                var param = loadParams[i];
                var data = FindEffectData(param.GetAssetName());
                if (data != null)
                {
                    loadedCount++;
                    data.AddRef();
                    if (onLoaded != null)
                        existData.Add(data);
                }
                else
                {
                    if (_assetBundleRefDict.TryGetValue(param.AssetBundleName, out AssetBundleUnloader unloader))
                    {
                        unloader.AddRef();
                    }
                    else
                    {
                        _assetBundleRefDict.Add(param.AssetBundleName, new AssetBundleUnloader()
                        {
                            assetBundleName = param.AssetBundleName,
                            isUnloadAllLoadedObjects = true,
                        });
                        AssetManager.AppendAssetBundleRequest(param.AssetBundleName, true, null, null);
                    }

                    _effectDatas.Add(param.GetAssetName(), new EffectData(param.AssetBundleName));
                }
            }

            if (loadedCount < loadParams.Length)
            {
                yield return AssetManager.DispatchRequests((eventType, name, asset) =>
                {
                    if (eventType != RequestEventType.Activated)
                        return;

                    var go = asset as GameObject;
                    if (go == null)
                        return;

                    loadedCount++;
                    var data = FindEffectData(name);

                    if (data == null)
                        return;

                    data.Setup(go);
                    var main = data.prefab.GetComponent<ParticleSystem>().main;
                    main.playOnAwake = false;

                    var param = loadParams.FirstOrDefault(x => x.GetAssetName() == name);
                    if (param == null)
                        return;

                    if (!_objectPool._dict.ContainsKey(data))
                        _objectPool.Instantiates(param.PoolCount, data, data.prefab, transform);

                    onLoaded?.Invoke(data, loadedCount == loadParams.Length);
                });
            }

            if (onLoaded == null)
                yield break;

            bool allLoaded;

            do
            {
                allLoaded = true;

                foreach (var data in existData)
                {
                    if (data.prefab == null)
                        allLoaded = false;
                    else
                        onLoaded.Invoke(data, loadedCount == loadParams.Length);
                }

                yield return null;
            }
            while (!allLoaded);
        }

        internal void _Unload(EffectData effectData)
        {
            if (_instance == null)
                return;

            for (int i=_instance._effectInstances.Count-1; i>-1; i--)
            {
                var instance = _instance._effectInstances[i];
                if (instance.effectData == effectData)
                    instance.Stop(0.0f, true);
            }

            _instance._effectDatas.Remove(effectData.prefab.name);
            _instance._objectPool.Destroies(effectData);
            if (_assetBundleRefDict[effectData.assetBundleName].Release() == 0)
                _assetBundleRefDict.Remove(effectData.assetBundleName);
        }

        public EffectData FindEffectData(string assetName)
        {
            _effectDatas.TryGetValue(assetName, out EffectData data);
            return data;
        }

        public EffectInstance Play(EffectData effectData, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform, [Optional] UnityAction<EffectInstance> onFinished)
        {
            return Create(effectData, position, rotation, attachedTransform).Play(onFinished);
        }

        public EffectInstance Create(EffectData effectData, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform)
        {
            var instance = _objectPool.Create(effectData, false);
            _effectInstances.Add(instance);
            instance._Setup(effectData, position, rotation, attachedTransform, OnFinishedInstance);
            return instance;
        }

        private void OnFinishedInstance(object reference)
        {
            var instance = reference as EffectInstance;
            instance.SetTransformParent(Instance.transform, false);

            if (_effectInstances.Remove(instance))
                _objectPool.Release(instance.effectData, instance);
        }

        public void RemoveInstances(bool isForce = true)
        {
            for (int i=_instance._effectInstances.Count-1; i>-1; i--)
            {
                var instance = _instance._effectInstances[i];
                instance.Stop(0.0f, isForce);
            }
        }

        public void RemoveInstancesByData(EffectData effectData)
        {
            for (int i=_instance._effectInstances.Count-1; i>-1; i--)
            {
                var instance = _instance._effectInstances[i];
                if (instance.effectData == effectData)
                    instance.Stop(0.0f, true);
            }
        }

        // TODO : I hate how this looks, figure out a pretty way to write this
        private void LateUpdate()
        {
            UpdateDistortionCamera();

            int u4 = 0;
            int u5 = _effectInstances.Count;
            for (int i=0; i<_effectInstances.Count; i++)
            {
                var instance = _effectInstances[i];
                bool updated = instance._Update(Time.deltaTime);
                u5 -= updated ? 0 : 1;
                u4 -= updated ? -1 : 0;

                if (u5 <= u4)
                {
                    if (u5 < 1)
                        break;

                    int j = 0;
                    do
                    {
                        _effectInstances[j]._UpdateTransform();
                        j++;
                    }
                    while (u5 != j);
                }
            }
        }

        private void UpdateDistortionCamera()
        {
            if (_cameraParam.camera != Camera.main)
            {
                _cameraParam.camera = Camera.main;
                if (_cameraParam.camera == null)
                    return;

                _cameraParam.camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Distortion"));
                _cameraParam.compositor = _cameraParam.camera.GetComponentInChildren<MultipleCameraCompositor>();

                if (_cameraParam.compositor == null)
                    _cameraParam.battleCompositor = _cameraParam.camera.GetComponentInChildren<BattleMultipleCameraCompositor>();

                SetDof();
            }

            if (_cameraParam.camera == null)
                return;

            SetupBackgroundTexture();
        }

        private void SetDof()
        {
            var postProcessor = _cameraParam.camera.GetComponentInChildren<PostProcessFilter>();

            if (postProcessor != null)
            {
                _dof = postProcessor.GetEffect<DepthOfField>();
            }
            else
            {
                var battlePostProcessor = _cameraParam.camera.GetComponentInChildren<BattlePostProcessFilter>();
                if (battlePostProcessor != null)
                    _dof = battlePostProcessor.GetEffect<DepthOfField>();
            }
        }

        private void SetupBackgroundTexture()
        {
            if (_dof == null)
                return;

            Shader.SetGlobalTexture(_id_BackgroundTexture, _dof.renderTexture);
        }

        public class LoadParam
        {
	        public string AssetBundleName;
            public string AssetName;
            public int PoolCount = 1;
            public bool Resident;

            public string GetAssetName()
            {
                if (string.IsNullOrEmpty(AssetName))
                    return Path.GetFileNameWithoutExtension(AssetBundleName);
                else
                    return AssetName;
            }
        }

        public class FieldLoadParam : LoadParam
        {
	        public bool InitLoad;
        }

        private class CameraParam
        {
	        public Camera camera;
            public MultipleCameraCompositor compositor;
            public BattleMultipleCameraCompositor battleCompositor;

            public bool IsFieldCamera()
            {
                return compositor != null;
            }
        }
    }
}