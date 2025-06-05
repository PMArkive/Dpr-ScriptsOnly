using Dpr.Battle.View;
using Dpr.Trainer;
using GameData;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

namespace Dpr.UI
{
    public class UIModelViewController : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
    {
        [SerializeField]
        private RectTransform _modelBgRoot;
        [SerializeField]
        private Transform _modelRoot;
        [SerializeField]
        private ModelViewBgCamera _modelBgCamera;
        [SerializeField]
        private Camera _modelCamera;
        [SerializeField]
        private ModelViewReflectionCamera _reflectionCamera;
        [SerializeField]
        private EnvironmentController _modelEnvironmentController;
        [SerializeField]
        private EnvironmentSettings _environmentCharacter;
        [SerializeField]
        private EnvironmentSettings _environmentPokemon;
        private UIManager.EnvironmentControllerSaver _environmentControllerSaver = new UIManager.EnvironmentControllerSaver();
        private bool _isActived;
        private Vector2 _modelViewSize;
        private float _modelCameraFov = float.NegativeInfinity;
        private float _modelReflectionAlpha = float.NegativeInfinity;
        private Vector2 _modelCameraCenterOffset = Vector2.zero;
        private Vector3 _modelOffset = Vector3.zero;
        private Vector3 _modelRotation = Vector3.zero;
        private Vector3 _modelAttachOffset = Vector3.zero;
        private float _modelScale = 1.0f;
        private float _cameraRotationX;
        private int _loadRequestModelId;
        private ModelParam _modelParam;
        private SaveCameraParam _saveCameraParam = new SaveCameraParam();
        public const int defaultCacheModelNum = 6;
        private CacheList<ModelParam> _cacheParams = new CacheList<ModelParam>(defaultCacheModelNum);
        private ModelViewType _modelViewType = ModelViewType.Party;

        public ModelParam modelParam { get => _modelParam; }
        public RectTransform modelBgRoot { get => _modelBgRoot; }

        public void SetModelViewType(ModelViewType type)
        {
            _modelViewType = type;
        }

        public (Vector3, Vector3, float, Vector3, Vector2) GetModelViewParameters(ModelViewType type, PokemonParam pokemonParam)
        {
            var catalog = DataManager.GetPokemonCatalog(DataManager.GetUniqueID(pokemonParam));

            switch (type)
            {
                case ModelViewType.Party:
                    return (catalog.StatusModelOffset, catalog.StatusModelRotationAngle, catalog.StatusScale, Vector3.zero, Vector2.zero);

                case ModelViewType.Zukan:
                    return (catalog.ModelOffset, catalog.ModelRotationAngle, catalog.MenuScale, Vector3.zero, Vector2.zero);

                case ModelViewType.Box:
                    return (catalog.BoxModelOffset, catalog.BoxModelRotationAngle, catalog.BoxScale, Vector3.zero, Vector2.zero);

                case ModelViewType.Habitat:
                    return (catalog.DistributionModelOffset, catalog.DistributionModelRotationAngle, catalog.DistributionScale, Vector3.zero, Vector2.zero);

                case ModelViewType.Moving:
                    return (catalog.VoiceModelOffset, catalog.VoiceModelRotationAngle, catalog.VoiceScale, catalog.CenterPointOffset, catalog.RotationLimitAngle);

                case ModelViewType.Compare:
                    return (catalog.CompareModelOffset, catalog.CompareModelRotationAngle, catalog.CompareScale, Vector3.zero, Vector2.zero);

                default:
                    return (Vector3.zero, Vector3.zero, 1.0f, Vector3.zero, Vector2.zero);
            }
        }

        public int GetModelViewParameterIdleAnimation(ModelViewType type, PokemonParam pokemonParam)
        {
            var catalog = DataManager.GetPokemonCatalog(DataManager.GetUniqueID(pokemonParam));

            string clipName;
            switch (type)
            {
                case ModelViewType.Party:
                    clipName = catalog.StatusModelMotion;
                    break;

                case ModelViewType.Box:
                    clipName = catalog.BoxModelMotion;
                    break;

                case ModelViewType.Habitat:
                    clipName = catalog.DistributionModelMotion;
                    break;

                case ModelViewType.Moving:
                    clipName = catalog.VoiceModelMotion;
                    break;

                case ModelViewType.Compare:
                    clipName = catalog.CompareModelMotion;
                    break;

                default:
                    clipName = catalog.ModelMotion;
                    break;
            }

            return UIManager.Instance.modelView.GetAnimationIndexByClipName(clipName);
        }

        public void SaveEnvironmentController()
        {
            _environmentControllerSaver.Save(true);
        }

        public void EnableModelLight(bool enabled, ModelViewType type)
        {
            if (enabled)
            {
                _environmentControllerSaver.Save();
                if (IsEnableGlobalEnvironmentController())
                    EnableGlobalEnvironmentController(false);

                if (!_modelEnvironmentController.gameObject.activeSelf)
                {
                    _modelEnvironmentController.throughGlobal = true;
                    _modelEnvironmentController.gameObject.SetActive(true);
                }

                _modelEnvironmentController.SetLight(GetEnvironmentSettings(type), PeriodOfDay.Daytime, 0.0f);
                _modelEnvironmentController.cloudShadowEnable = false;
            }
            else
            {
                if (_modelEnvironmentController.gameObject.activeSelf)
                    _modelEnvironmentController.gameObject.SetActive(false);

                _environmentControllerSaver.Restore();
            }
        }

        private EnvironmentSettings GetEnvironmentSettings(ModelViewType type)
        {
            return type.HasFlag(ModelViewType.Character) ? _environmentCharacter : _environmentPokemon;
        }

        private bool IsEnableGlobalEnvironmentController()
        {
            if (EnvironmentController.global == null)
                return false;

            if (!EnvironmentController.global.gameObject.activeSelf)
                return false;

            return EnvironmentController.global.enabled;
        }

        private void EnableGlobalEnvironmentController(bool enabled)
        {
            if (EnvironmentController.global == null)
                return;

            EnvironmentController.global.SetActive(enabled);
            EnvironmentController.global.enabled = enabled;
        }

        public void ModelViewSize(float width, float height)
        {
            _modelViewSize = new Vector2(width, height);
        }

        public void ModelCameraFov(float fov)
        {
            _modelCameraFov = fov;
        }

        public void ModelReflection(float alpha)
        {
            _modelReflectionAlpha = alpha;
        }

        public void ModelCameraCenterOffsetX(float offsetX)
        {
            _modelCameraCenterOffset = new Vector2(offsetX, 0.0f);
        }

        public void ModelCameraCenterOffset(Vector2 offset)
        {
            _modelCameraCenterOffset = offset;
        }

        public void SetModelOffset(Vector3 offset)
        {
            _modelOffset = offset;
        }

        public void SetModelRotation(Vector3 rotation)
        {
            _modelRotation = rotation;
        }

        public Vector3 GetModelRotation()
        {
            return _modelRotation;
        }

        public void SetModelScale(float scale)
        {
            _modelScale = scale;
        }

        public void SetModelAttachOffset(Vector3 offset)
        {
            _modelAttachOffset = offset;
        }

        public float GetCameraRotationX()
        {
            return _cameraRotationX;
        }

        public void SetCameraRotationX(float x)
        {
            _cameraRotationX = x;
        }

        public Vector3 GetModelCameraPosition()
        {
            return _modelCamera.transform.position;
        }

        public int ResetCaches(int num, bool isUnload = true)
        {
            int count = _cacheParams.maxNum;

            _cacheParams.Reset(num, removeParam =>
            {
                if (removeParam == null)
                    return;

                if (removeParam.root == null)
                    return;

                if (removeParam.root.gameObject == null)
                    return;

                removeParam.Destroy();
            });

            return count;
        }

        public IEnumerator OpLoadModel(ModelViewType modelViewType, int uniqueId, string assetBundleName, bool isDontClear, UnityAction<ModelParam> onSetupParam, UnityAction onSetup)
        {
            if (!_isActived)
                _isActived = true;

            _loadRequestModelId = uniqueId;
            var cacheParam = _cacheParams.Find(x => x.IsEnableCache(modelViewType, uniqueId));
            if (cacheParam == null)
            {
                SetupModelViewCameras(true);
                EnableModelLight(true, modelViewType);

                var param = new ModelParam
                {
                    modelViewType = modelViewType,
                    uniqueId = uniqueId
                };

                var unloader = new AssetBundleUnloader();
                unloader.assetBundleName = assetBundleName;
                unloader.isUnloadAllLoadedObjects = true;

                param.assetBundleUnloader = unloader;
                param.isDontClear = isDontClear;

                cacheParam = param;
                _cacheParams.Add(cacheParam);

                AssetManager.AppendAssetBundleRequest(assetBundleName, true, null, null);
                yield return AssetManager.DispatchRequests((eventType, name, asset) =>
                {
                    if (eventType != RequestEventType.Activated)
                        return;

                    var goAsset = asset as GameObject;
                    cacheParam.loaded = true;
                    if (goAsset != null)
                    {
                        var root = new GameObject("Root");
                        root.gameObject.SetActive(false);
                        root.transform.SetParent(_modelRoot, false);

                        var attach = new GameObject("Attach");
                        attach.transform.SetParent(root.transform, false);

                        var newGo = Instantiate(goAsset, attach.transform);

                        cacheParam.root = root.transform;
                        cacheParam.attachTo = attach.transform;
                        cacheParam.gameObject = newGo;

                        cacheParam.gameObject.SetActive(true);
                        cacheParam.baseEntity = newGo.GetComponent<BaseEntity>();

                        ModelAttachTransforms(cacheParam);
                        CacheParamMoveLast(cacheParam);

                        onSetupParam.Invoke(cacheParam);
                    }

                    if (_isActived && goAsset != null && _loadRequestModelId == uniqueId)
                    {
                        ClearModelView(false);
                        _modelParam = cacheParam;

                        CacheParamMoveLast(cacheParam);
                        _modelParam.Active(true);

                        onSetup.Invoke();
                    }
                });
            }
            else if (cacheParam.loaded && _loadRequestModelId == uniqueId)
            {
                ClearModelView(false);

                _modelParam = cacheParam;
                CacheParamMoveLast(cacheParam);

                _modelParam.Active(true);
                onSetup.Invoke();
            }
        }

        private void CacheParamMoveLast(ModelParam modelParam)
        {
            _cacheParams.MoveLast(modelParam, removeParam =>
            {
                if (removeParam.uniqueId == _loadRequestModelId)
                    return false;

                if (removeParam.root == null || removeParam.isDontClear)
                    return false;

                removeParam.Destroy();
                if (_modelParam == removeParam)
                    _modelParam = null;

                return true;
            });
        }

        public IEnumerator OpLoadCharacterModel(int uniqueId, string assetBundleName, [Optional, DefaultParameterValue(false)] bool isDontClear, [Optional] UnityAction<int> onSetup, TrainerType trainerType = TrainerType.INVALID)
        {
            yield return OpLoadModel(_modelViewType, uniqueId, assetBundleName, isDontClear, modelParam => { /* Do nothing */ }, () =>
            {
                SetupCharacterModel(trainerType);
                onSetup?.Invoke(uniqueId);
            });
        }

        public void EnableMainCameraByUiMode(bool enabled)
        {
            var camera = _saveCameraParam.camera;

            if (enabled)
            {
                if (camera != null)
                    return;

                _saveCameraParam.camera = Camera.main;

                if (_saveCameraParam.camera == null)
                    return;

                var cameras = _saveCameraParam.camera.GetComponentsInChildren<Camera>();
                _saveCameraParam.subCameraParams.Clear();

                for (int i=1; i<cameras.Length; i++)
                {
                    var param = new SaveCameraParam();
                    param.camera = cameras[i];
                    param.actived = cameras[i].enabled;
                    _saveCameraParam.subCameraParams.Add(param);
                    cameras[i].enabled = false;
                }

                _saveCameraParam.cullMask = _saveCameraParam.camera.cullingMask;
                _saveCameraParam.camera.cullingMask = Layer.UI;
            }
            else
            {
                if (camera == null)
                    return;

                _saveCameraParam.camera = null;

                for (int i=0; i<_saveCameraParam.subCameraParams.Count; i++)
                {
                    var param = _saveCameraParam.subCameraParams[i];
                    param.camera.enabled = param.actived;
                }

                camera.gameObject.SetActive(false);
                camera.gameObject.SetActive(true);
                camera.cullingMask = _saveCameraParam.cullMask;
            }
        }

        private void SetupCharacterModel(TrainerType trainerType)
        {
            if (trainerType == TrainerType.INVALID)
                trainerType = PlayerWork.playerSex ? TrainerType.BOY : TrainerType.GIRL;

            SetupModelViewCameras(true);
            
            _modelRoot.localPosition = Vector3.zero;
            _modelRoot.localRotation = Quaternion.identity;
            _modelRoot.localScale = Vector3.one;

            _modelParam.attachPosY = float.NegativeInfinity;
            _modelParam.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));

            var battleEntity = _modelParam.gameObject.GetComponent<BattleCharacterEntity>();
            if (battleEntity == null)
            {
                var fieldEntity = _modelParam.gameObject.GetComponent<FieldCharacterEntity>();
                var colorVariation = fieldEntity.GetComponent<ColorVariation>();
                if (colorVariation != null)
                    colorVariation.ColorIndex = PlayerWork.colorID;
            }
            else
            {
                var param = TrainerSimpleParam.Factory(trainerType);
                param.colorID = PlayerWork.colorID;
                battleEntity.Initialize(param, true);
            }

            EnableModelLight(true, _modelViewType);
        }

        public IEnumerator OpLoadPokemonModel(PokemonParam pokemonParam, [Optional, DefaultParameterValue(true)] bool isApplyOffset, [Optional, DefaultParameterValue(false)] bool isDontClear, [Optional] UnityAction<PokemonParam> onSetup)
        {
            if (pokemonParam != null)
            {
                int uniqueID = DataManager.GetUniqueID(pokemonParam.GetMonsNo(), pokemonParam.GetFormNo(), pokemonParam.GetSex(), pokemonParam.GetRareType(), pokemonParam.IsEgg(EggCheckType.BOTH_EGG));
                string bundleName = UIManager.GetPokemonAssetbundleName(uniqueID);

                yield return OpLoadModel(_modelViewType, uniqueID, bundleName, isDontClear, modelParam => { /* Do nothing */ }, () =>
                {
                    var modelViewParams = GetModelViewParameters(_modelViewType, pokemonParam);
                    _SetupPokemonModel(pokemonParam, isApplyOffset, modelViewParams.Item1, modelViewParams.Item2, modelViewParams.Item3, modelViewParams.Item4);
                    onSetup?.Invoke(pokemonParam);
                });
            }

            _loadRequestModelId = 0;
            SetupModelViewCameras(false);
        }

        private void ModelAttachTransforms(ModelParam modelParam)
        {
            var attachTransName = "Waist";
            modelParam.attachFrom = modelParam.gameObject.GetComponentsInChildren<Transform>(true).FirstOrDefault(x => x.name == attachTransName);
        }

        private void SetupPokemonModel(PokemonParam pokemonParam, bool isApplyOffset)
        {
            var parameters = GetModelViewParameters(_modelViewType, pokemonParam);
            _SetupPokemonModel(pokemonParam, isApplyOffset, parameters.Item1, parameters.Item2, parameters.Item3, parameters.Item4);
        }

        internal void _SetupPokemonModel(PokemonParam pokemonParam, bool isApplyOffset, Vector3 modelOffset, Vector3 modelRotation, float modelScale, Vector3 modelAttachOffset)
        {
            _modelRoot.localPosition = Vector3.zero;
            _modelRoot.localRotation = Quaternion.identity;
            _modelRoot.localScale = Vector3.one;

            SetupModelViewCameras(true);

            _modelParam.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

            if (isApplyOffset)
            {
                _modelRotation.Set(modelRotation.x, modelRotation.y, modelRotation.z);
                _modelOffset = modelOffset;
                _modelScale = modelScale;
                _modelAttachOffset = modelAttachOffset;
            }
            else
            {
                _modelRotation = Vector3.zero;
                _modelOffset = Vector3.zero;
                _modelScale = 1.0f;
                _modelAttachOffset = Vector3.zero;
            }

            _modelParam.attachPosY = float.NegativeInfinity;
            EnableModelLight(true, _modelViewType);

            var entity = _modelParam.baseEntity as FieldPokemonEntity;

            if (entity != null)
                entity.EnablePlayInitialIdleAnimation(false);

            var patcheel = _modelParam.gameObject.GetComponent<PatcheelPattern>();
            if (pokemonParam != null && patcheel != null)
                patcheel.SetPattern(pokemonParam.GetPersonalRnd());
        }

        public BoundingSphere ComputeBoundingSphereByPokemon(GameObject pokemonObj)
        {
            var prefabInfo = pokemonObj.GetComponent<PokemonPrefabInfo>();
            if (prefabInfo != null)
            {
                var pokemonAnime = pokemonObj.GetComponent<PokemonAnime>();

                PokemonPrefabInfo.AABBData aabbData;
                if (pokemonAnime != null)
                {
                    var motionName = pokemonAnime.mStates[0];
                    aabbData = prefabInfo.mAABBArray.FirstOrDefault(__ => __.motionName.IndexOf(motionName) != -1);
                }
                else
                {
                    aabbData = prefabInfo.mAABBArray[0];
                }

                var pos = new Vector3(-aabbData.center.x, aabbData.center.y, -aabbData.center.z) * 0.5f;
                float rad = Mathf.Sqrt((aabbData.size.x * aabbData.size.x + aabbData.size.y * aabbData.size.y + aabbData.size.z * aabbData.size.z) * 0.5f) * 0.5f;
                return new BoundingSphere(pos, rad);
            }
            else
            {
                var renderer = pokemonObj.GetComponent<SkinnedMeshRenderer>();
                var bounds = renderer.bounds;
                return new BoundingSphere(bounds.center, bounds.extents.magnitude);
            }
        }

        public void PlayAnimation(int anim, bool forceLoop = false)
        {
            if (_modelParam == null)
                return;

            var player = _modelParam.baseEntity.GetAnimationPlayer();
            if (player != null)
            {
                if (!player.IsValidCurrentPlayable)
                    return;

                player.cullingMode = AnimatorCullingMode.AlwaysAnimate;
                player.forceLoop = forceLoop;
                player.Play(anim);
            }
            else
            {
                var charaEntity = _modelParam.baseEntity as BattleCharacterEntity;
                if (charaEntity == null)
                    return;

                var layer = charaEntity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer);
                layer.IsForceLoop = true;
                layer.Play(anim);
            }
        }

        public void StopAnimation()
        {
            if (_modelParam == null)
                return;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            if (animPlayer != null)
            {
                if (animPlayer.IsValidCurrentPlayable)
                    animPlayer.Stop();
            }
            else
            {
                var entity = _modelParam.baseEntity as BattleCharacterEntity;

                if (entity == null)
                    return;

                // Result ignored
                entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer);
            }
        }

        public float GetCurrentRemaingTime()
        {
            if (_modelParam == null)
                return 0.0f;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            if (animPlayer != null)
                return animPlayer.IsValidCurrentPlayable ? animPlayer.currentRemaingTime : 0.0f;

            var entity = _modelParam.baseEntity as BattleCharacterEntity;

            if (entity == null)
                return 0.0f;

            return entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer).CurrentRemaingTime;
        }

        public int GetAnimationIndexByClipName(string clipName)
        {
            if (_modelParam == null)
                return -1;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            AnimationClip[] clips;
            if (animPlayer != null)
            {
                if (!animPlayer.IsValidCurrentPlayable)
                    return -1;

                clips = animPlayer.clips;
            }
            else
            {
                var entity = _modelParam.baseEntity as BattleCharacterEntity;

                if (entity == null)
                    return -1;

                clips = entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer).Clips;
            }

            return Array.FindIndex(clips, x => x != null && !string.IsNullOrEmpty(x.name) && (x.name.IndexOf(clipName) != -1));
        }

        public bool IsPlayAnimation()
        {
            if (_modelParam == null)
                return false;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            if (animPlayer != null)
                return animPlayer.IsValidCurrentPlayable && animPlayer.IsPlayingEnd;

            var entity = _modelParam.baseEntity as BattleCharacterEntity;

            if (entity == null)
                return false;

            return entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer).IsPlayingEnd;
        }

        public void PauseAnimation(bool paused)
        {
            if (_modelParam == null)
                return;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            if (animPlayer != null)
            {
                if (animPlayer.IsValidCurrentPlayable)
                {
                    if (paused)
                        animPlayer.Stop();
                    else
                        animPlayer.Resume();
                }
            }
            else
            {
                var entity = _modelParam.baseEntity as BattleCharacterEntity;

                if (entity == null)
                    return;

                entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer).AnimationSpeed = paused ? 0.0f : 1.0f;
            }
        }

        public void LoopAnimation(bool looped)
        {
            if (_modelParam == null)
                return;

            var animPlayer = _modelParam.baseEntity.GetAnimationPlayer();

            if (animPlayer != null)
            {
                if (animPlayer.IsValidCurrentPlayable)
                    animPlayer.forceLoop = looped;
            }
            else
            {
                var entity = _modelParam.baseEntity as BattleCharacterEntity;

                if (entity == null)
                    return;

                entity.GetAnimationPlayer().GetAnimationLayer(Playables.BattleAnimationPlayer.LayerIndex.BaseLayer).IsForceLoop = looped;
            }
        }

        internal void _UpdateModelView()
        {
            if (_modelParam == null)
                return;

            var root = _modelParam.root;
            if (root == null)
                return;

            if (!root.gameObject.activeSelf)
                return;

            if (!_modelEnvironmentController.IsActiveController())
            {
                _modelEnvironmentController.SetActiveController();
                EnableModelLight(true, _modelViewType);
            }

            _modelEnvironmentController.SetLight(_modelViewType.HasFlag(ModelViewType.Character) ? _environmentCharacter : _environmentPokemon, PeriodOfDay.Daytime, 0.0f);
            root.localPosition = _modelOffset;
            root.localRotation = Quaternion.Euler(_modelRotation.x, 0.0f, _modelRotation.z);
            _modelParam.attachTo.localRotation = Quaternion.Euler(0.0f, _modelRotation.y, 0.0f);
            root.localScale = new Vector3(_modelScale, _modelScale, _modelScale);

            if (float.IsNegativeInfinity(_modelParam.attachPosY))
            {
                if (_modelParam.attachFrom != null)
                {
                    _modelParam.attachPosY = _modelParam.attachFrom.position.y;
                    float posY = _modelParam.attachPosY - _modelParam.gameObject.transform.position.y;
                    _modelParam.attachTo.localPosition = new Vector3(_modelAttachOffset.x, _modelAttachOffset.y + posY, _modelAttachOffset.z);
                    _modelParam.gameObject.transform.localPosition = new Vector3(_modelAttachOffset.x, _modelAttachOffset.y - _modelParam.attachPosY, _modelAttachOffset.z);
                }
            }

            UpdateModelViewCameras();
        }

        public void SetupModelViewCameras(bool enableModelCamera)
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            _modelBgCamera.gameObject.SetActive(true);

            if (_modelBgCamera.camera.targetTexture == null ||
                _modelBgCamera.camera.targetTexture.width != _modelViewSize.x ||
                _modelBgCamera.camera.targetTexture.height != _modelViewSize.y)
            {
                if (_modelBgCamera.camera.targetTexture != null)
                    _modelBgCamera.camera.targetTexture.Release();

                // Why is format 22?
                _modelBgCamera.camera.targetTexture = new RenderTexture((int)_modelViewSize.x, (int)_modelViewSize.y, 24, (DefaultFormat)22);
            }

            SetupModelViewCamera(enableModelCamera, _modelCamera);

            if (float.IsNegativeInfinity(_modelReflectionAlpha))
            {
                SetupModelViewCamera(false, _reflectionCamera.camera);
                return;
            }

            SetupModelViewCamera(enableModelCamera, _reflectionCamera.camera);
            _modelBgCamera.Setup();
            _reflectionCamera.SetBgTexture(_modelBgCamera.renderTexture);

            if (float.IsNegativeInfinity(_modelReflectionAlpha))
                return;

            _reflectionCamera.SetAlpha(_modelReflectionAlpha);
        }

        private void SetupModelViewCamera(bool enableModelCamera, Camera camera)
        {
            camera.aspect = _modelViewSize.x / _modelViewSize.y;

            if (!float.IsNegativeInfinity(_modelCameraFov))
                camera.fieldOfView = _modelCameraFov;

            camera.targetTexture = _modelBgCamera.camera.targetTexture;
            camera.gameObject.SetActive(false);

            if (enableModelCamera)
                camera.gameObject.SetActive(true);
        }

        private void UpdateModelViewCameras()
        {
            if (_modelParam == null)
                return;

            var root = _modelParam.root;
            if (root == null)
                return;

            _modelCamera.ResetProjectionMatrix();
            var projectionM = _modelCamera.projectionMatrix;
            projectionM.m02 = 2 * _modelCameraCenterOffset.x;
            projectionM.m12 = 2 * _modelCameraCenterOffset.y;
            _modelCamera.projectionMatrix = projectionM;

            if (float.IsNegativeInfinity(_modelReflectionAlpha))
                return;

            _reflectionCamera.camera.ResetProjectionMatrix();
            _reflectionCamera.camera.ResetWorldToCameraMatrix();
            _reflectionCamera.camera.ResetCullingMatrix();

            var up = Vector3.up;
            var reflectM = ComputeReflectionMatrix(new Vector4(up.x, up.y, up.z, -Vector3.Dot(up, Vector3.zero)));

            _reflectionCamera.camera.worldToCameraMatrix = _modelCamera.worldToCameraMatrix * reflectM;
            _reflectionCamera.camera.projectionMatrix = _modelCamera.projectionMatrix;

            var orthoM = Matrix4x4.Ortho(-100.0f, 100.0f, -100.0f, 100.0f, 0.001f, 100.0f);
            var transM = Matrix4x4.Translate(Vector3.forward * -100.0f / 2.0f);

            _reflectionCamera.camera.cullingMatrix = orthoM * transM * _modelCamera.worldToCameraMatrix;
        }

        private Matrix4x4 ComputeReflectionMatrix(Vector4 n)
        {
            // There might be a way to do better math here. Result matrix should be:
            // [ 1-2x^2    -2xy    -2xz  -2xw ]
            // [   -2yx  1-2y^2    -2yz  -2yw ]
            // [   -2zx    -2zy  1-2z^2  -2zw ]
            // [      0       0       0     1 ]
            var m = new Matrix4x4(new Vector4(n.x, 0, 0, 0), new Vector4(n.y, 1, 0, 0), new Vector4(n.z, 0, 1, 0), Vector4.zero);
            m *= new Matrix4x4(-2*n, Vector4.zero, Vector4.zero, Vector4.zero);

            m.m00 += 1;
            m.m11 += 1;
            m.m22 += 1;
            m.m33 += 1;

            return m;
        }

        void IViewportChangeHandler.OnViewportChange(int screenWidth, int screenHeight)
        {
            _ = gameObject.activeSelf;
        }

        public RenderTexture GetModelViewRenderTexture()
        {
            if (_modelBgCamera != null)
                return _modelBgCamera.camera.targetTexture;

            return null;
        }

        public void ClearModelView(bool isFinish)
        {
            if (_modelParam != null && !_modelParam.isDontClear)
            {
                _modelParam.Active(false);
                _modelParam = null;
            }

            if (_modelCamera != null)
                _modelCamera.gameObject.SetActive(false);

            gameObject.SetActive(false);

            if (_isActived)
                _isActived = false;

            if (isFinish)
            {
                if (_modelEnvironmentController.gameObject.activeSelf)
                    _modelEnvironmentController.gameObject.SetActive(false);

                _environmentControllerSaver.Restore();
            }
        }

        private void SetActive(bool enabled)
        {
            if (_isActived != enabled)
                _isActived = enabled;
        }

        private void UnloadUnused()
        {
            // Empty
        }

        public class ModelParam
        {
	        public ModelViewType modelViewType;
            public int uniqueId;
            public bool loaded;
            public AssetBundleUnloader assetBundleUnloader;
            public GameObject gameObject;
            public BaseEntity baseEntity;
            public bool isDontClear;
            public Transform root;
            public Transform attachTo;
            public Transform attachFrom;
            public float attachPosY = float.NegativeInfinity;

            public void Active(bool enabled)
            {
                if (root != null)
                    root.gameObject.SetActive(enabled);

                if (attachTo != null && !attachTo.gameObject.activeSelf)
                    attachTo.gameObject.SetActive(enabled);

                if (gameObject != null && !gameObject.activeSelf)
                    gameObject.SetActive(enabled);
            }

            public void Destroy()
            {
                UnityEngine.Object.Destroy(gameObject);
                UnityEngine.Object.Destroy(root.gameObject);
                root = null;
                attachTo = null;
                attachFrom = null;
                gameObject = null;
                baseEntity = null;
                assetBundleUnloader.Release();
            }

            public bool IsEnableCache(ModelViewType modelViewType_, int uniqueId_)
            {
                if (((modelViewType ^ modelViewType_) & (ModelViewType.Pokemon | ModelViewType.Character)) != 0)
                    return false;

                return uniqueId == uniqueId_;
            }
        }

        private class SaveCameraParam
        {
	        public Camera camera;
            public bool actived;
            public int cullMask;
            public List<SaveCameraParam> subCameraParams = new List<SaveCameraParam>();
        }

        [Flags]
        public enum ModelViewType : int
        {
            None = 0,
            Pokemon = 1,
            Character = 2,
            Party = 5,
            Zukan = 9,
            Box = 17,
            Boutique = 34,
            Habitat = 65,
            Moving = 129,
            Compare = 257,
        }
    }
}