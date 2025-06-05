using System;
using UnityEngine;

namespace SmartPoint.Components
{
    public abstract class PlayerPrefsProvider<T> where T : PlayerPrefsProvider<T>
    {
        private bool _loaded;
        private static T _instance;

        protected virtual string key { get => typeof(T).FullName; }

        protected virtual void Initialization()
        {
            // Empty
        }

        protected virtual bool CustomLoadOperation()
        {
            return false;
        }

        protected virtual bool CustomSaveOperation()
        {
            return false;
        }

        protected virtual bool CustomLoadAsyncOperation()
        {
            if (CustomLoadOperation())
            {
                OnPostLoad();
                return true;
            }

            return false;
        }

        protected virtual bool CustomSaveAsyncOperation()
        {
            OnPreSave();
            return CustomSaveOperation();
        }

        protected virtual void OnPostLoad()
        {
            // Empty
        }

        protected virtual void OnPreSave()
        {
            // Empty
        }

        protected static T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                    _instance.Initialization();
                }
                return _instance;
            }
        }

        public static void Load(bool forceReload = false, bool isAsync = false)
        {
            if (_instance != null)
            {
                if (!forceReload)
                {
                    if (_instance._loaded)
                        return;
                }

                if (!isAsync)
                {
                    if (_instance.CustomLoadOperation())
                    {
                        _instance.OnPostLoad();
                        return;
                    }
                }
                else
                {
                    if (_instance.CustomLoadAsyncOperation())
                        return;
                }

                string value = PlayerPrefs.GetString(_instance.key);
                if (!string.IsNullOrEmpty(value))
                {
                    JsonUtility.FromJsonOverwrite(value, _instance);
                    _instance.OnPostLoad();
                    _instance._loaded = true;
                    Debug.Log("PlayerPrefs Loaded: " + _instance.key);
                }
            }
        }

        public static void Save(bool isAsync = false)
        {
            if (_instance != null)
            {
                if (!isAsync)
                {
                    _instance.OnPreSave();
                    if (_instance.CustomSaveOperation())
                        return;
                }
                else
                {
                    if (_instance.CustomSaveAsyncOperation())
                        return;
                }

                string value = JsonUtility.ToJson(_instance, false);
                PlayerPrefs.SetString(_instance.key, value);
            }
        }

        public static void Clear()
        {
            _instance = Activator.CreateInstance<T>();
            _instance.Initialization();
            Save(false);
        }
    }
}