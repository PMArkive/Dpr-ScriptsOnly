using SmartPoint.AssetAssistant.UnityExtensions;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class SceneEntity : RefCounted
    {
        private SceneDatabase.SceneProperty _property;
        private Scene _scene;
        private bool _isRequested;
        private bool _isLoaded;
        private GameObject _suspendObject;
        private SceneEntity[] _includes = ArrayHelper.Empty<SceneEntity>();
        private Dictionary<MonoBehaviour, Queue<Operation>> _activateOperations = new Dictionary<MonoBehaviour, Queue<Operation>>();

        public SceneEntity(string sceneName)
        {
            _property = SceneDatabase.GetProperty(sceneName);
        }

        public SceneEntity(Scene scene)
        {
            _scene = scene;
            _isRequested = false;
            _isLoaded = true;
            _property = new SceneDatabase.SceneProperty(scene.path);
        }

        public string path { get => _property.scenePath; }
        public SceneDatabase.SceneProperty property { get => _property; }
        public GameObject cluster { get => _suspendObject; }
        public SceneEntity[] includes { get => _includes; set => _includes = value; }
        public bool isRequested { get => _isRequested; set => _isRequested = value; }
        public Transform clusterRootTransform
        {
            get
            {
                if (_suspendObject != null)
                    return _suspendObject.transform;

                return null;
            }
        }
        public bool isLoaded
        {
            get => _isLoaded;
            set
            {
                if (_isLoaded != value)
                {
                    if (value)
                    {
                        _scene = SceneManager.GetSceneByPath(path);
                        var roots = _scene.GetRootGameObjects();
                        if (roots.Length != 0)
                            _suspendObject = roots[0];

                        if (Application.isEditor && StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                            Sequencer.editorProxy.ReloadEditorShadersInScene(_scene);

                        _activateOperations.Clear();
                        MonoBehaviour[] components = _suspendObject.GetComponentsInChildren<MonoBehaviour>(true);
                        foreach (MonoBehaviour component in components)
                        {
                            if (component != null)
                            {
                                MethodInfo method = SceneBrowser.GetSceneRestoreOperationMethod(component.GetType());
                                if (method != null)
                                {
                                    if (!_activateOperations.TryGetValue(component, out Queue<Operation> ops))
                                    {
                                        ops = new Queue<Operation>();
                                        _activateOperations.Add(component, ops);
                                    }

                                    Operation op = new Operation();
                                    op.behaviour = component;
                                    op.method = method;

                                    if (AssetManager.isReady)
                                    {
                                        SceneEntity[] paramArray = new SceneEntity[1];
                                        paramArray[0] = this;
                                        op.coroutine = Sequencer.Start((IEnumerator)method.Invoke(component, paramArray));
                                    }

                                    ops.Enqueue(op);
                                }
                            }
                        }
                    }

                    _isLoaded = value;
                }
            }
        }

        public MonoBehaviour[] FindScripts()
        {
            List<MonoBehaviour> scripts = new List<MonoBehaviour>();

            foreach (var include in _includes)
            {
                foreach (var rootGameObject in include.GetRootGameObjects())
                    scripts.AddRange(rootGameObject.GetComponentsInChildren<MonoBehaviour>(true));
            }

            foreach (var rootGameObject in _scene.GetRootGameObjects())
                scripts.AddRange(rootGameObject.GetComponentsInChildren<MonoBehaviour>(true));

            return scripts.ToArray();
        }

        public bool isActivatable
        {
            get
            {
                bool includesActivatable = true;
                for (int i=0; i<_includes.Length; i++)
                    includesActivatable &= _includes[i].CanActivate();

                return includesActivatable && CanActivate();
            }
        }

        private bool CanActivate()
        {
            if (!_isLoaded)
                return false;

            if (_activateOperations.Count == 0)
                return true;

            bool preventClear = false;

            foreach (var ops in _activateOperations.Values)
            {
                var op = ops.Peek();

                if (op.coroutine == null)
                {
                    SceneEntity[] paramArray = new SceneEntity[1];
                    paramArray[0] = this;
                    op.coroutine = Sequencer.Start((IEnumerator)op.method.Invoke(op.behaviour, paramArray));
                    preventClear = true;
                }
                else
                {
                    if (Sequencer.IsFinished(op.coroutine))
                        ops.Dequeue();

                    preventClear |= ops.Count > 0;
                }
            }

            if (!preventClear)
                _activateOperations.Clear();

            return _activateOperations.Count == 0;
        }

        private bool CanDeactivate()
        {
            return true;
        }

        public GameObject[] GetRootGameObjects()
        {
            Scene scene = SceneManager.GetSceneByPath(path);

            if (scene.IsValid() && scene.isLoaded)
                return scene.GetRootGameObjects();
            else
                return ArrayHelper.Empty<GameObject>();
        }

        public void Suspend()
        {
            if (_suspendObject == null)
            {
                _suspendObject = new GameObject("Suspend");
                _suspendObject.SetActive(false);
                SceneManager.MoveGameObjectToScene(_suspendObject, _scene);
            }

            var sceneObjs = GetRootGameObjects();
            for (int i=0; i<sceneObjs.Length; i++)
            {
                if (sceneObjs[i] != null && sceneObjs[i] != _suspendObject)
                    sceneObjs[i].transform.SetParent(_suspendObject.transform);
            }
        }

        public void Resume()
        {
            if (_suspendObject == null)
                return;

            if (!_suspendObject.activeSelf)
                _suspendObject.SetActive(true);

            var sceneObjs = new GameObject[_suspendObject.transform.childCount];
            if (_suspendObject.transform.childCount < 1)
            {
                _suspendObject.transform.DetachChildren();
            }
            else
            {
                for (int i=0; i<_suspendObject.transform.childCount; i++)
                    sceneObjs[i] = _suspendObject.transform.GetChild(i).gameObject;

                _suspendObject.transform.DetachChildren();

                for (int i=0; i<sceneObjs.Length; i++)
                    SceneManager.MoveGameObjectToScene(sceneObjs[i], _scene);
            }

            Object.Destroy(_suspendObject);
            _suspendObject = null;
        }

        private class Operation
        {
            public MonoBehaviour behaviour;
            public MethodInfo method;
            public Coroutine coroutine;
        }
    }
}