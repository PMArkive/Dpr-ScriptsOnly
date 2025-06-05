using SmartPoint.AssetAssistant.UnityExtensions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class SceneDatabase : SingletonScriptableObject<SceneDatabase>
    {
        [SerializeField]
        private SceneProperty[] _properties = ArrayHelper.Empty<SceneProperty>();
        [NonSerialized]
        private Dictionary<string, SceneProperty> _sceneDictionary;

        protected override void OnEnable()
        {
            base.OnEnable();
            InternalUpdate();
        }

        public void InternalUpdate()
        {
            _sceneDictionary = new Dictionary<string, SceneProperty>();
            foreach (var property in _properties)
                _sceneDictionary.Add(property.scenePath, property);
        }

        public static bool Contains(string scenePath)
        {
            return instance._sceneDictionary.ContainsKey(scenePath);
        }

        public static string GUIDToPath(string guid)
        {
            foreach (var scene in instance._sceneDictionary.Values)
            {
                if (scene.guid == guid)
                    return scene.scenePath;
            }

            return string.Empty;
        }

        public static bool IsExist(string scenePath)
        {
            return instance._sceneDictionary.ContainsKey(scenePath);
        }

        public static SceneProperty GetProperty(string scenePath)
        {
            if (instance._sceneDictionary.TryGetValue(scenePath, out SceneProperty sceneProperty))
                return sceneProperty;

            return null;
        }

        public static string GetAssetBundleName(string scenePath)
        {
            if (instance._sceneDictionary.TryGetValue(scenePath, out SceneProperty sceneProperty))
                return string.IsNullOrEmpty(sceneProperty.assetBundleName) ? string.Empty : sceneProperty.assetBundleName;

            return string.Empty;
        }

        public static void AddProperty(string path)
        {
            if (instance._sceneDictionary.ContainsKey(path))
                return;

            instance._sceneDictionary.Add(path, new SceneProperty(path));
        }

        public static Dictionary<string, SceneProperty> GetAllSceneProperty()
        {
            return instance._sceneDictionary;
        }

        [Serializable]
        public class SceneProperty
        {
            [SerializeField]
            private string _scenePath = string.Empty;
            [SerializeField]
            private string _guid = string.Empty;
            [SerializeField]
            private string _assetBundleName = string.Empty;
            [SerializeField]
            private bool _dontDiscard;
            [SerializeField]
            private bool _leaveHistory = true;
            [SerializeField]
            private string[] _includes = ArrayHelper.Empty<string>();

            public SceneProperty(string path)
            {
                _scenePath = path;
            }

            public string scenePath { get => _scenePath; }
            public string guid { get => _guid; }
            public string assetBundleName { get => _assetBundleName; }
            public bool dontDiscard { get => _dontDiscard; }
            public bool leaveHistroy { get => _leaveHistory; }
            public string[] includes { get => _includes; }
        }
    }
}