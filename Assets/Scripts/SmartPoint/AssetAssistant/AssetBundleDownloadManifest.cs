using SmartPoint.AssetAssistant.UnityExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    public class AssetBundleDownloadManifest
    {
        private const int currentVersion = 6;

        [SerializeField]
        private int _version = currentVersion;
        [SerializeField]
        private string _projectName = string.Empty;
        [SerializeField]
        private AssetBundleRecord[] _records;
        [SerializeField]
        private string[] _assetBundleNamesWithVariant = ArrayHelper.Empty<string>();
        [NonSerialized]
        private Dictionary<string, HashSet<string>> _variantMap;
        [NonSerialized]
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetBundleName;
        [NonSerialized]
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetPath;
        [NonSerialized]
        private bool _dirty;
        [NonSerialized]
        private string _path = string.Empty;
        [NonSerialized]
        private AssetBundleDownloadManifest _latest;

        public string projectName { get => _projectName; set => _projectName = value; }
        public string path { get => _path; set => _path = value; }

        public AssetBundleDownloadManifest latest
        {
            get => _latest;
            set
            {
                _latest = value;
                MarkDifference(value);
            }
        }

        public int recordCount { get => _records.Length; }
        public AssetBundleRecord[] records { get => _records; }
        public long totalSize { get => _recordLookupFromAssetBundleName.Values.Sum(x => x.size); }
        public long installSize { get => _recordLookupFromAssetBundleName.Values.Sum(x => x.latest == null ? 0 : x.size); }
        public int installCount { get => _records.Where(x => x.latest != null).Count(); }
        public AssetBundleRecord[] installAssetBundleRecords { get => _records.Where(x => x.latest != null).ToArray(); }

        public static AssetBundleDownloadManifest Load(byte[] data)
        {
            AssetBundleDownloadManifest manifest = null;

            using (var stream = new MemoryStream(data))
            {
                var deserialized = stream.DeserializeBinaryFormatter();

                if (deserialized != null && deserialized is AssetBundleDownloadManifest)
                    manifest = deserialized as AssetBundleDownloadManifest;
            }

            return manifest;
        }

        public static AssetBundleDownloadManifest Load(string path, bool isSimulation = false)
        {
            AssetBundleDownloadManifest manifest = null;
            string dirPath;

            if (path.IsUrl())
            {
                var request = UnityWebRequest.Get(path);
                var op = request.SendWebRequest();
                do
                {
                    if (request.isHttpError || request.isNetworkError)
                        return null;
                }
                while (!op.isDone);

                var data = request.downloadHandler.data;
                manifest = Load(data);

                if (manifest._version != currentVersion)
                    manifest.Clear();

                dirPath = Path.GetDirectoryName(path) + "/";
            }
            else
            {
                if (File.Exists(path))
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var deserialized = stream.DeserializeBinaryFormatter();

                        if (deserialized != null && deserialized is AssetBundleDownloadManifest)
                            manifest = deserialized as AssetBundleDownloadManifest;
                    }

                    if (manifest._version != currentVersion)
                        manifest.Clear();

                    dirPath = Path.GetDirectoryName(path) + "/";
                }
            }

            if (manifest == null)
            {
                manifest = new AssetBundleDownloadManifest();
                manifest._dirty = true;
                manifest._projectName = Path.GetFileNameWithoutExtension(path);
                manifest._path = Path.GetDirectoryName(path) + "/";
            }
            else
            {
                if (isSimulation)
                {
                    for (int i=0; i<manifest._records.Length; i++)
                    {
                        if (StartupSettings.assetBundlesForEditor.Any(__ => __ == manifest._records[i].assetBundleName))
                            Debug.Log("Invalid simulation: " + manifest._records[i].assetBundleName);
                        else
                            manifest._records[i].isSimulation = true;
                    }
                }
                manifest.BuildLookupTables();
            }

            return manifest;
        }
        
        public static AssetBundleDownloadManifest Load(string targetPath, AssetBundleManifest other, OnRecordCreated callback)
        {
            var manifest = new AssetBundleDownloadManifest();
            manifest.LoadFromAssetBundleManifest(targetPath, other, callback);
            return manifest;
        }

        public string[] GetDependencies(string assetBundleName)
        {
            var record = _records.FirstOrDefault(x => x.assetBundleName == assetBundleName);
            if (record != null)
                return record.allDependencies;

            return ArrayHelper.Empty<string>();
        }

        private void LoadFromAssetBundleManifest(string targetPath, AssetBundleManifest other, OnRecordCreated callback)
        {
            var newList = new List<AssetBundleRecord>(_records);
            _projectName = Path.GetFileNameWithoutExtension(targetPath);
            _assetBundleNamesWithVariant = other.GetAllAssetBundlesWithVariant();
            var allBundleNames = other.GetAllAssetBundles();

            for (int i=0; i<allBundleNames.Length; i++)
            {
                var bundleName = allBundleNames[i];
                var hash = RecordedHash.Parse(other.GetAssetBundleHash(bundleName).ToString());
                var fileInfo = new FileInfo(Path.Combine(targetPath, bundleName));

                var newRecord = new AssetBundleRecord(_projectName, bundleName);
                newList.Add(newRecord);

                newRecord.allDependencies = other.GetAllDependencies(bundleName);
                newRecord.hash = hash;
                newRecord.lastWriteTime = fileInfo.LastWriteTimeUtc;
                newRecord.size = fileInfo.Length;

                callback?.Invoke(newRecord);
            }

            _records = newList.ToArray();
            _dirty = true;
        }

        public void Save(string path, bool force = false)
        {
            if (_dirty || force)
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                stream.SerializeBinaryFormatter(this);
                if (stream != null)
                    stream.Dispose();
            }

            _dirty = false;
        }

        public AssetBundleDownloadManifest()
        {
            _records = ArrayHelper.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName = new Dictionary<string, AssetBundleRecord>();
            _dirty = false;
        }

        public void Append(string projectName, AssetBundleDownloadManifest appendManifest)
        {
            var newList = new List<AssetBundleRecord>(_records);
            for (int i=0; i<appendManifest._records.Length; i++)
            {
                var record = appendManifest._records[i];
                var lookupRecord = GetAssetBundleRecord(record.assetBundleName);
                if (lookupRecord == null)
                {
                    lookupRecord = new AssetBundleRecord(record);
                    lookupRecord.projectName = projectName;
                    newList.Add(lookupRecord);
                    lookupRecord.latest = record;
                    _dirty = true;
                }
                else
                {
                    if (record.hash != lookupRecord.hash && record.lastWriteTime >= lookupRecord.lastWriteTime)
                    {
                        lookupRecord.projectName = projectName;
                        lookupRecord.allDependencies = record.allDependencies;
                        lookupRecord.assetPaths = record.assetPaths;
                        lookupRecord.size = record.size;
                        lookupRecord.latest = record;
                        _dirty = true;
                    }
                }
            }

            _records = newList.ToArray();
            if (_dirty)
                _assetBundleNamesWithVariant = _assetBundleNamesWithVariant.Union(appendManifest._assetBundleNamesWithVariant).ToArray();
            BuildLookupTables();
        }

        private void MarkDifference(AssetBundleDownloadManifest latestManifest)
        {
            var newList = new List<AssetBundleRecord>(_records);
            if (latestManifest != null)
            {
                for (int i=0; i<_records.Length; i++)
                {
                    var record = _records[i];
                    var lookupRecord = GetAssetBundleRecord(record.assetBundleName);
                    if (lookupRecord == null)
                    {
                        lookupRecord = new AssetBundleRecord(record);
                        newList.Add(lookupRecord);
                        lookupRecord.latest = record;
                        _dirty = true;
                    }
                    else
                    {
                        if (record.hash != lookupRecord.hash && record.lastWriteTime >= lookupRecord.lastWriteTime)
                        {
                            lookupRecord.projectName = record.projectName;
                            lookupRecord.allDependencies = record.allDependencies;
                            lookupRecord.assetPaths = record.assetPaths;
                            lookupRecord.size = record.size;
                            lookupRecord.latest = record;
                            _dirty = true;
                        }
                    }
                }

                _records = newList.ToArray();
                if (_assetBundleNamesWithVariant != latestManifest._assetBundleNamesWithVariant)
                {
                    _assetBundleNamesWithVariant = latestManifest._assetBundleNamesWithVariant;
                    _dirty = true;
                }
            }

            BuildLookupTables();
        }

        private void BuildLookupTables()
        {
            _recordLookupFromAssetBundleName = _records.ToDictionary(x => x.assetBundleName, x => x);
            _recordLookupFromAssetPath = new Dictionary<string, AssetBundleRecord>();
            _variantMap = new Dictionary<string, HashSet<string>>();

            for (int i=0; i<_records.Length; i++)
            {
                var record = _records[i];

                if (record.assetPaths != null)
                {
                    for (int j=0; j<record.assetPaths.Length; j++)
                    {
                        var path = record.assetPaths[j];
                        path.ToLowerSelf();
                        string key = path.RemoveStart("assets/");

                        if (_recordLookupFromAssetPath.ContainsKey(key))
                            Debug.Log("What?" + record.assetBundleName + ":" + path);

                        _recordLookupFromAssetPath.Add(key, record);
                    }
                }
            }

            if (_assetBundleNamesWithVariant != null)
            {
                for (int i=0; i<_assetBundleNamesWithVariant.Length; i++)
                {
                    var name = _assetBundleNamesWithVariant[i];
                    int length = name.LastIndexOf('.');
                    string filename = name.Substring(0, length);
                    string extension = name.Substring(length+1);

                    if (!_variantMap.TryGetValue(extension, out HashSet<string> variant))
                    {
                        variant = new HashSet<string>();
                        _variantMap.Add(extension, variant);
                    }
                    variant.Add(filename);
                }
            }
        }

        public AssetBundleRecord AddRecord(string projectName, string assetBundleName)
        {
            Array.Resize(ref _records, _records.Length + 1);
            var record = new AssetBundleRecord(projectName, assetBundleName);
            _records[_records.Length - 1] = record;
            BuildLookupTables();

            return record;
        }

        public void Clear()
        {
            _records = ArrayHelper.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName?.Clear();
            _variantMap?.Clear();

            _variantMap = null;
            _recordLookupFromAssetPath = null;
            _version = currentVersion;
            MarkDifference(_latest);
        }

        public bool IsExist(string assetBundleName)
        {
            return _recordLookupFromAssetBundleName.ContainsKey(assetBundleName);
        }

        public string[] GetExists(string[] assetBundleNames)
        {
            return _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) != -1).Select(x => x.assetBundleName).ToArray();
        }

        public void RemoveRecords(string[] assetBundleNames)
        {
            _records = _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) == -1).ToArray();
            _dirty = true;
        }

        public void RestrictRecords(string[] assetBundleNames)
        {
            _records = _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) != -1).ToArray();
            _dirty = true;
        }

        public string[] GetAllAssetBundleNames()
        {
            return _recordLookupFromAssetBundleName.Keys.ToArray();
        }

        public string[] GetAssetBundleNamesWithVariant()
        {
            return _assetBundleNamesWithVariant;
        }

        public string FindMatchAssetBundleNameWithVariants(string assetBundleName, string[] variants)
        {
            int dotIndex = assetBundleName.IndexOf('.');
            if (dotIndex != -1)
                assetBundleName = assetBundleName.Substring(0, dotIndex);

            for (int i=0; i<variants.Length; i++)
            {
                var variant = variants[i];
                if (_variantMap.TryGetValue(variant, out HashSet<string> set) && set.Contains(assetBundleName))
                    return assetBundleName + "." + variant;
            }

            return assetBundleName;
        }

        public string GetAssetBundleNameAtPath(string path)
        {
            if (_recordLookupFromAssetPath != null)
            {
                if (_recordLookupFromAssetPath.TryGetValue(path.ToLower().RemoveStart("assets/"), out AssetBundleRecord value))
                    return value.assetBundleName;

                return null;
            }

            return null;
        }

        public AssetBundleRecord GetAssetBundleRecord(string assetBundleName)
        {
            if (_recordLookupFromAssetBundleName.TryGetValue(assetBundleName, out AssetBundleRecord value))
                return value;

            return null;
        }

        public AssetBundleRecord[] GetAssetBundleRecordsWithDependencies(string assetBundleName)
        {
            var record = GetAssetBundleRecord(assetBundleName);
            if (record == null)
                return ArrayHelper.Empty<AssetBundleRecord>();

            var deps = new List<AssetBundleRecord>();
            for (int i=0; i<record.allDependencies.Length; i++)
            {
                var depName = record.allDependencies[i];
                deps.Add(GetAssetBundleRecord(depName));
            }

            return deps.ToArray();
        }

        public delegate void OnRecordCreated(AssetBundleRecord record);
    }
}