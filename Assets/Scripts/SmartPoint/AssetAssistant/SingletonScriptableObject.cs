using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static string className { get => typeof(T).Name; }
        protected static T instance
        {
            get
            {
                if (_instance == null)
                {
                    if (Application.isEditor)
                    {
#if NON_DECOMP // [NON-DECOMP] We just do the same as the non-editor version.
                        _instance = Resources.Load(className) as T;
#else
                        if (Sequencer.editorProxy != null)
                            Debug.Log("Create Editor Proxy");
#endif
                    }
                    else
                    {
                        _instance = Resources.Load(className) as T;
                    }
                }

                return _instance;
            }
        }

        protected virtual void OnEnable()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
        }
    }
}