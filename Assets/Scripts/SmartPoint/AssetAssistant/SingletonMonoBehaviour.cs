using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    [DisallowMultipleComponent]
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        protected static T _instance;

        public static bool isQuit { get; set; }

        private static Scene lastScene;

        public static bool isInstantiated
        {
            get { return _instance != null; }
        }

        public static GameObject GetGameObject()
        {
            return _instance?.gameObject;
        }

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    if (!_instance.enabled)
                        _instance.enabled = true;

                    return _instance;
                }
                else
                {
                    if (!Application.isPlaying)
                        isQuit = false;

                    if (isQuit)
                        return null;

                    if (lastScene.IsValid())
                    {
                        if (lastScene == SceneManager.GetActiveScene())
                            return null;
                    }

                    lastScene = SceneManager.GetActiveScene();
                    _instance = FindObjectOfType<T>();

                    _instance?.Awake();

                    return _instance;
                }
            }
        }

        protected virtual bool Awake()
        {
            if (_instance != null && _instance.enabled)
            {
                if (_instance == this)
                {
                    return true;
                }
                else
                {
                    this.enabled = false;
                    return false;
                }
            }

            _instance = this as T;
            return true;
        }

        protected virtual void OnApplicationQuit()
        {
            isQuit = true;
        }

        public static T Instantiate([Optional] string instanceName, [Optional] Transform parent)
        {
            if (Instance == null)
            {
                var go = new GameObject(typeof(T).ToString(), new Type[1]{ typeof(T) });
                _instance = go.GetComponent<T>();
            }

            if (_instance != null)
            {
                if (!string.IsNullOrEmpty(instanceName))
                    _instance.name = instanceName;

                if (parent != null)
                    _instance.transform.SetParent(parent);
            }

            return _instance;
        }
    }
}