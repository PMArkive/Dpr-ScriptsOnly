using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class SceneBrowser
    {
        private static Dictionary<string, SceneEntity> _sceneEntities;
        private static SceneEntity _targetScene;
        private static SceneEntity _currentScene;
        private static HashSet<SceneEntity> _requestScenes; 
        private static List<SceneEntity> _removedScenes;
        private static Stack<string> _sceneHistory;
        private static bool _startupSceneChanged;

        private static event ChangeSceneCallback _sceneNavigated;
        private static event ChangeSceneCallback _beforeSceneChanged;
        private static event PrepareForSceneSwitching _prepareForSceneSwitching;
        private static event SceneBrowserUpdateCallback _delayCall;

        private static List<MethodInfo> _sceneRestoreOperationMethods;
        private static List<MethodInfo> _sceneBeforeActivateOperationMethods;
        private static Scene _initialScene;
        private static List<Coroutine> _changeSceneCoroutines;

        public static bool hasHistory { get => _sceneHistory.Count > 0; }
        public static string[] histories { get => _sceneHistory.ToArray(); }
        public static SceneEntity currentScene { get => _currentScene; }
        public static bool isRequested { get => _requestScenes.Count > 0; }

        public static MethodInfo GetSceneRestoreOperationMethod(Type type)
        {
            foreach (var method in _sceneRestoreOperationMethods)
            {
                // TODO: Remove this null check once all the affected methods are implemented.
                if (method != null)
                {
                    if (type == method.DeclaringType || type.IsSubclassOf(method.DeclaringType))
                        return method;
                }
            }

            return null;
        }

        public static MethodInfo GetSceneBeforeActivateOperationMethod(Type type)
        {
            foreach (var method in _sceneBeforeActivateOperationMethods)
            {
                // TODO: Remove this null check once all the affected methods are implemented.
                if (method != null)
                {
                    if (type == method.DeclaringType || type.IsSubclassOf(method.DeclaringType))
                        return method;
                }
            }

            return null;
        }

        public static event ChangeSceneCallback sceneNavigated
        {
            add => _sceneNavigated += value;
            remove => _sceneNavigated -= value;
        }

        public static event SceneBrowserUpdateCallback delayCall
        {
            add
            {
                if (!AssetManager.isReady)
                    _delayCall += value;

                value.Invoke();
            }
            remove => _delayCall -= value;
        }

        public static event ChangeSceneCallback beforeSceneChanged
        {
            add => _beforeSceneChanged += value;
            remove => _beforeSceneChanged -= value;
        }

        public static event PrepareForSceneSwitching prepareForSceneSwitching
        {
            add => _prepareForSceneSwitching += value;
            remove => _prepareForSceneSwitching -= value;
        }

        [AssetAssistantInitializeMethod]
        private static void Initialize()
        {
            if (!StartupSettings.useSceneBrowser)
                return;

            Debug.Log("Initialize Scene Browser.");
            var camera = Sequencer.AddComponent<Camera>();
            camera.allowHDR = false;
            camera.allowMSAA = false;
            camera.useOcclusionCulling = false;
            camera.cullingMask = 0;
            camera.clearFlags = CameraClearFlags.Color;
            camera.depth = -100.0f;
            camera.backgroundColor = Color.black;

            _sceneEntities = new Dictionary<string, SceneEntity>();
            _sceneHistory = new Stack<string>();
            _requestScenes = new HashSet<SceneEntity>();
            _removedScenes = new List<SceneEntity>();
            _initialScene = SceneManager.GetActiveScene();

            if (!SceneDatabase.Contains(_initialScene.path))
                _targetScene = new SceneEntity(_initialScene);
            else
                _targetScene = AppendScene(_initialScene.path, true);

            _currentScene = null;

            if (_targetScene != null)
            {
                if (string.IsNullOrEmpty(StartupSettings.startupScenePath) || StartupSettings.startupScenePath == _targetScene.path)
                {
                    if (Application.isEditor)
                    {
                        foreach (var include in _targetScene.includes)
                        {
                            bool foundScene = false;
                            for (int i=0; i<SceneManager.sceneCount; i++)
                            {
                                if (SceneManager.GetSceneAt(i).path == include.path)
                                {
                                    foundScene = true;
                                    break;
                                }
                            }

                            if (!foundScene)
                                RequestScene(include);
                        }

                        AssetManager.DispatchRequests(null);
                    }
                }

                _requestScenes.Add(_targetScene);
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;

            _sceneRestoreOperationMethods = new List<MethodInfo>();
            foreach (var method in StartupSettings.sceneRestoreOperationMethods)
                _sceneRestoreOperationMethods.Add(method.GetMethodInfo());

            _sceneBeforeActivateOperationMethods = new List<MethodInfo>();
            foreach (var method in StartupSettings.sceneBeforeActivateOperationMethods)
                _sceneBeforeActivateOperationMethods.Add(method.GetMethodInfo());
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (!SceneDatabase.Contains(scene.path))
                SceneDatabase.AddProperty(scene.path);

            if (!_sceneEntities.ContainsKey(scene.path))
                AppendScene(scene.path, true);

            var entity = _sceneEntities[scene.path];
            entity.isLoaded = true;

            if (_initialScene.isLoaded)
            {
                _initialScene = default;
                Sequencer.Start(WaitForAssetReady());
            }
        }

        private static IEnumerator WaitForAssetReady()
        {
            while (!AssetManager.isReady)
                yield return null;

            if (!string.IsNullOrEmpty(StartupSettings.startupScenePath))
            {
                if (StartupSettings.startupScenePath != _targetScene.path)
                {
                    _currentScene = _targetScene;
                    _targetScene = null;
                    Open(StartupSettings.startupScenePath, false, true, true);
                }
            }

            _delayCall?.Invoke();
            _delayCall = null;

            Sequencer.update += Update;
        }

        private static void Update(float deltaTime)
        {
            _removedScenes.Clear();

            foreach (var requestScene in _requestScenes)
            {
                if (!requestScene.isActivatable)
                    continue;

                if (_targetScene != requestScene || IsFinishedPrepareForSceneSwitching())
                {
                    if (_targetScene == requestScene)
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(requestScene.path));
                        if (Application.isEditor && StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                            Sequencer.editorProxy.ReloadEditorSkyboxShader();

                        _beforeSceneChanged?.Invoke(_currentScene, _targetScene);

                        if (_currentScene != null)
                        {
                            SuspendSceneObjects(_currentScene);
                            if (!_currentScene.property.dontDiscard)
                                UnloadScenes(_currentScene);
                        }

                        _currentScene = _targetScene;
                        _targetScene = null;

                        if (!_startupSceneChanged)
                        {
                            Sequencer.RemoveComponent<Camera>();
                            _startupSceneChanged = true;
                        }
                    }

                    _removedScenes.Add(requestScene);
                    ResumeSceneObjects(requestScene);
                }
            }

            foreach (var removedScene in _removedScenes)
            {
                _requestScenes.Remove(removedScene);
            }
        }

        private static bool IsFinishedPrepareForSceneSwitching()
        {
            if (_changeSceneCoroutines == null)
            {
                if (_prepareForSceneSwitching != null)
                {
                    _changeSceneCoroutines = new List<Coroutine>();
                    var invoList = _prepareForSceneSwitching.GetInvocationList();
                    for (int i=0; i<invoList.Length; i++)
                    {
                        var coroutine = Sequencer.Start((invoList[i] as PrepareForSceneSwitching).Invoke(_currentScene, _targetScene));
                        _changeSceneCoroutines.Add(coroutine);
                    }

                    var scripts = _targetScene.FindScripts();
                    for (int i=0; i<scripts.Length; i++)
                    {
                        if (scripts[i] != null)
                        {
                            var method = GetSceneBeforeActivateOperationMethod(scripts[i].GetType());
                            if (method != null)
                            {
                                var coroutine = Sequencer.Start((IEnumerator)method.Invoke(scripts[i], new object[] { _targetScene.clusterRootTransform }));
                                _changeSceneCoroutines.Add(coroutine);
                            }
                        }
                    }
                }
            }
            else
            {
                var newCoroutines = new List<Coroutine>();

                foreach (var coroutine in _changeSceneCoroutines)
                {
                    if (!Sequencer.IsFinished(coroutine))
                        newCoroutines.Add(coroutine);
                }

                if (newCoroutines.Count < 1)
                    _changeSceneCoroutines = null;
                else
                    _changeSceneCoroutines = newCoroutines;
            }

            return _changeSceneCoroutines == null;
        }

        private static void SuspendSceneObjects(SceneEntity scene)
        {
            if (scene == null)
                return;

            foreach (var include in scene.includes)
                include.Suspend();

            scene.Suspend();
        }

        private static void ResumeSceneObjects(SceneEntity scene)
        {
            if (scene == null)
                return;

            foreach (var include in scene.includes)
                include.Resume();

            scene.Resume();
        }

        public static SceneEntity Open(string scenePath, bool useSubScene = true)
        {
            return Open(scenePath, true, false, useSubScene);
        }

        public void Close(SceneEntity entity)
        {
            UnloadScenes(entity);
        }

        public static void Close(Component component)
        {
            UnloadScenes(GetEntity(component.gameObject.scene.path));
        }

        private static void UnloadScene(SceneEntity scene)
        {
            if (scene?.Release() == 0)
            {
                _sceneEntities.Remove(scene.path);
                if (scene.isLoaded)
                    SceneManager.UnloadSceneAsync(scene.path);
            }
        }

        private static void UnloadScenes(SceneEntity scene)
        {
            foreach (var subscene in scene.includes)
            {
                if (!subscene.property.dontDiscard)
                {
                    UnloadScene(subscene);
                }
                else if (subscene != null)
                {
                    SuspendSceneObjects(subscene);
                }
            }

            UnloadScene(scene);
        }

        private static SceneEntity AppendScene(string scenePath, bool useSubScene)
        {
            if (SceneDatabase.Contains(scenePath))
            {
                SceneEntity entity;
                if (_sceneEntities.TryGetValue(scenePath, out entity))
                {
                    entity.AddRef();
                }
                else
                {
                    entity = new SceneEntity(scenePath);
                    _sceneEntities.Add(scenePath, entity);
                }

                if (useSubScene)
                {
                    entity.includes = new SceneEntity[entity.property.includes.Length];

                    for (int i = 0; i < entity.property.includes.Length; i++)
                    {
                        SceneEntity includeEntity;
                        if (_sceneEntities.TryGetValue(entity.property.includes[i], out includeEntity))
                        {
                            includeEntity.AddRef();
                        }
                        else
                        {
                            includeEntity = new SceneEntity(entity.property.includes[i]);
                            _sceneEntities.Add(entity.property.includes[i], includeEntity);
                        }

                        entity.includes[i] = includeEntity;
                    }
                }

                return entity;
            }
            else
            {
                Debug.LogError("AppendScene: Scene not found!!: " + scenePath);
                return null;
            }
        }

        private static string GetFullPath(string sceneName)
        {
            if (!sceneName.StartsWith("Assets/"))
                sceneName = "Assets/" + sceneName;

            if (!sceneName.EndsWith(".unity"))
                sceneName += ".unity";

            return sceneName;
        }

        private static void RequestScene(SceneEntity scene)
        {
            if (!scene.isLoaded && !scene.isRequested)
            {
                scene.isRequested = true;
                AssetManager.AppendAssetRequest(scene.path, null);
            }
        }

        private static SceneEntity Open(string scenePath, bool noHistory, bool navigate, bool useSubScene = true)
        {
            if (_sceneEntities == null)
                return null;

            if (scenePath != string.Empty)
                scenePath = GetFullPath(scenePath);

            foreach (var scene in _requestScenes)
            {
                if (scene.path == scenePath)
                    return scene;
            }

            if (_targetScene != null && !_targetScene.property.dontDiscard)
                UnloadScenes(_targetScene);

            var newScene = AppendScene(scenePath, useSubScene);

            if (!noHistory && _currentScene != null && _currentScene.property.leaveHistroy)
            {
                Debug.Log("Add Scene History: " + _currentScene.path);
                if (_sceneHistory.Count == 0 || _sceneHistory.Peek() != _currentScene.path)
                    _sceneHistory.Push(_currentScene.path);
            }

            if (_currentScene == newScene)
            {
                UnloadScene(newScene);
                return newScene;
            }

            _requestScenes.Add(newScene);

            if (navigate)
            {
                _targetScene = newScene;
                _sceneNavigated?.Invoke(_currentScene, _targetScene);
            }

            if (newScene.isActivatable)
                return newScene;

            if (useSubScene)
            {
                foreach (var include in newScene.includes)
                {
                    RequestScene(include);
                }
            }

            RequestScene(newScene);

            AssetManager.DispatchRequests(null);
            return newScene;
        }

        public static SceneEntity Navigate(string scenePath, bool noHistory = false)
        {
            return Open(scenePath, noHistory, true, true);
        }

        public static bool CanBack()
        {
            return _sceneHistory.Count != 0;
        }

        public static bool GoBack()
        {
            while (CanBack())
            {
                var lastPath = _sceneHistory.Pop();
                if (lastPath != _currentScene.path)
                {
                    Debug.Log("Back To Scene: " + lastPath);
                    Open(lastPath, true, true, true);
                    return true;
                }
            }

            return false;
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            // Empty
        }

        public static GameObject InstantiateTo(Scene scene, UnityEngine.Object asset)
        {
            var go = UnityEngine.Object.Instantiate(asset);
            SceneManager.MoveGameObjectToScene(go as GameObject, scene);
            return go as GameObject;
        }

        public static SceneEntity GetEntity(string path)
        {
            path = GetFullPath(path);

            if (_sceneEntities.TryGetValue(path, out SceneEntity scene))
                return scene;

            return null;
        }

        public static SceneEntity GetEntity(Component compoent)
        {
            return GetEntity(compoent.gameObject.scene.path);
        }

#if UNITY_EDITOR
        public static void DebugOnSceneLoaded()
        {
            OnSceneLoaded(_initialScene, LoadSceneMode.Single);
        }
#endif

        public delegate void ChangeSceneCallback(SceneEntity currentScene, SceneEntity targetScene);
        public delegate void SceneBrowserUpdateCallback();
        public delegate IEnumerator PrepareForSceneSwitching(SceneEntity currentScene, SceneEntity targetScene);
    }
}