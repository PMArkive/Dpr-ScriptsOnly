using SmartPoint.AssetAssistant.Forms;
using SmartPoint.AssetAssistant.SmartPoint.AssetAssistant;
using SmartPoint.AssetAssistant.UnityExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class AssetManager
    {
        private const int MaxInstallRequest = 20;

        public static int Timeout;
        private static byte[] _preallocatedBuffer;
        private static List<IAssetRequestItem> _errorRequestList;
        private static LinkedList<RequestItemPacket> _requestList;
        private static RequestItemPacket _requestPacket;
        private static RequestItemPacket _dependencyRequestPacket;
        private static UnityEngine.Object _waitObject;
        private static AssetBundleDownloadManifest _defaultManifest;
        private static bool _cacheEnabled;
        private static Dictionary<string, AssetBundleDownloadManifest> _installedTable;
        private static bool _ready;
        private static List<RequestItemPacket> _removePackets;
        private static List<Shader> _shaders;

        public OnRequestError onRequestError;

        public static string editorPath
        {
            get
            {
                string path = Path.Combine(StartupSettings.assetBundleTargetURI, "AssetBundles/Editor");

                if (Path.IsPathRooted(StartupSettings.assetBundleTargetURI))
                    return path;

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
                return Path.GetFullPath(fullPath);
            }
        }
        public static string cachePath
        {
            get
            {
                if (_cacheEnabled)
                    return Application.persistentDataPath + "/Cache";

                if (StartupSettings.assetBundleTarget == AssetBundleTarget.StreamingAssets)
                    return Application.streamingAssetsPath + "/AssetAssistant";

                if (string.IsNullOrEmpty(StartupSettings.assetBundleTargetURI))
                    return Directory.GetCurrentDirectory() + "/AssetBundles/" + StartupSettings.platformName;
             
                string path = Path.Combine(StartupSettings.assetBundleTargetURI, "AssetBundles/" + StartupSettings.platformName);

                if (Path.IsPathRooted(StartupSettings.assetBundleTargetURI))
                    return path;

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
                return Path.GetFullPath(fullPath);
            }
        }
        public static string buitinAssetsPath
        {
            get
            {
                string str0;
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:
                    case RuntimePlatform.Switch:
                        str0 = string.Empty;
                        break;
                    default:
                        str0 = "file://";
                        break;
                }
                return str0 + Application.streamingAssetsPath + "/AssetAssistant";
            }
        }
        public static AssetBundleDownloadManifest defaultDownloadManifest { get => _defaultManifest; }

        public static Shader FindShader(string name)
        {
            Shader shader = _shaders.Find(__ => __.name == name);
            if (shader != null)
                return shader;

            Debug.Log("Find Include Shader: " + name);
            return Shader.Find(name);
        }

        public static bool isReady { get => _ready; }

        [AssetAssistantInitializeMethod]
        private static void Initialize()
        {
            Debug.Log("Initialize Asset Manager.");

            _waitObject = Sequencer.Instance;
            _errorRequestList = new List<IAssetRequestItem>();
            _requestList = new LinkedList<RequestItemPacket>();
            _removePackets = new List<RequestItemPacket>();
            _installedTable = new Dictionary<string, AssetBundleDownloadManifest>();
            _shaders = new List<Shader>();
            _cacheEnabled = false;

            if (StartupSettings.clearCacheFiles)
                ClearCacheFiles();

            InstallHandler.installPath = cachePath;
            Sequencer.onFinalize += OnDestroy;
            Sequencer.Start(SetupOperation());
        }

        public static void ClearCacheFiles()
        {
            if (Directory.Exists(InstallHandler.installPath))
            {
                Debug.Log("Clear All Cached AssetBundles");
                Directory.Delete(cachePath, true);

                string path = cachePath + "/" + Application.productName;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach (AssetBundleDownloadManifest manifest in _installedTable.Values)
                    manifest.Clear();
            }
        }

        public static void Cleanup()
        {
            if (Directory.Exists(cachePath))
                ClearCacheFiles();
        }

        private static IEnumerator SetupOperation()
        {
            float startTime = Time.realtimeSinceStartup;

            Debug.Log("CreationTime: " + StartupSettings.creationTime);
            Debug.Log(string.Format("AssetManagerSetupOperation (Time: {0})", Time.realtimeSinceStartup));

            if (StartupSettings.assetBundleTarget != AssetBundleTarget.Nothing)
            {
                if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase || StartupSettings.externalProjectNames.Length != 0)
                {
                    if (StartupSettings.assetBundleTarget == AssetBundleTarget.BuildLocation)
                        _defaultManifest = AssetBundleDownloadManifest.Load("Temp/AssetAssistant/Manifest/Manifest.bin", false);
                    else
                        _defaultManifest = AssetBundleDownloadManifest.Load(cachePath + "/" + Application.productName + ".bin", false);
                }

                string downloadPath = null;
                if (StartupSettings.assetBundleTarget == AssetBundleTarget.StreamingAssets)
                {
                    downloadPath = buitinAssetsPath;
                }
                else if (StartupSettings.assetBundleTarget != AssetBundleTarget.RuntimeLocation)
                {
                    downloadPath = Directory.GetCurrentDirectory();
                    if (!string.IsNullOrEmpty(StartupSettings.assetBundleTargetURI))
                        downloadPath = downloadPath.CombinePath(StartupSettings.assetBundleTargetURI);

                    downloadPath = "file://" + downloadPath + "/AssetBundles/" + StartupSettings.platformName;
                }
                else if (!string.IsNullOrEmpty(StartupSettings.assetBundleTargetURI))
                {
                    downloadPath = StartupSettings.assetBundleTargetURI.CombinePath(StartupSettings.platformName);
                }

                if (!string.IsNullOrEmpty(downloadPath) && StartupSettings.assetBundleTarget == AssetBundleTarget.Nothing)
                {
                    string manifestURI = downloadPath.CombinePath(Application.productName + ".bin");
                    byte[] data;
                    if (Application.platform != RuntimePlatform.Switch)
                    {
                        var webRequest = UnityWebRequest.Get(manifestURI);
                        yield return webRequest.SendWebRequest();

                        // 1
                        Debug.Log("Manifest Error:" + webRequest.error);

                        data = webRequest.downloadHandler.data;
                        webRequest = null;
                    }

                    data = File.ReadAllBytes(manifestURI);

                    var manifest = AssetBundleDownloadManifest.Load(data);
                    manifest.path = manifestURI.RemoveEnd(".bin") + "/";

                    if (_defaultManifest == null)
                        _defaultManifest = manifest;

                    _defaultManifest.latest = manifest;
                    manifestURI = null;
                }
                
                if (_defaultManifest == null)
                {
                    _defaultManifest = new AssetBundleDownloadManifest();
                    _defaultManifest.latest = _defaultManifest;
                }

                if (StartupSettings.externalProjectNames.Length != 0)
                    Debug.Log(string.Format("Marge Manifest Start (Time: {0})", Time.realtimeSinceStartup));

                for (int i=0; i<StartupSettings.externalProjectNames.Length; i++)
                {
                    if (!string.IsNullOrEmpty(StartupSettings.externalProjectNames[i]))
                    {
                        string path = downloadPath.CombinePath(StartupSettings.externalProjectNames[i] + ".bin");

                        byte[] data;
                        if (Application.platform == RuntimePlatform.Switch)
                        {
                            if (!File.Exists(path))
                                break;

                            data = File.ReadAllBytes(path);
                        }
                        else
                        {
                            var request = UnityWebRequest.Get(path);
                            var op = request.SendWebRequest();
                            while (!op.isDone)
                            {
                                if (!string.IsNullOrEmpty(request.error))
                                {
                                    Debug.Log("Manifest Error: " + path + ": " + request.error);
                                    break;
                                }
                            }

                            data = request.downloadHandler.data;
                        }

                        Debug.Log(string.Format("Import Manifest: {0} ({1} byte)", StartupSettings.externalProjectNames[i], data.Length));

                        var manifest = AssetBundleDownloadManifest.Load(data);
                        if (manifest != null)
                            _defaultManifest.Append(StartupSettings.externalProjectNames[i], manifest);
                    }
                }

                downloadPath = null;
            }

            if (StartupSettings.externalProjectNames.Length != 0)
                Debug.Log(string.Format("Marge Manifest End (Time: {0})", Time.realtimeSinceStartup));

            for (int i=0; i<StartupSettings.preloadRequests.Length; i++)
            {
                if (!string.IsNullOrEmpty(StartupSettings.preloadRequests[i].assetBundleName))
                {
                    var record = GetAssetBundleRecord(_defaultManifest, StartupSettings.preloadRequests[i].assetBundleName);
                    if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase || !record.projectName.IsNullOrEmpty())
                    {
                        Debug.Log("PreloadRequest:" + StartupSettings.preloadRequests[i].assetBundleName);

                        var cache = LoadAssetBundle(_defaultManifest, record, StartupSettings.preloadRequests[i].loadAllAssets, true, null);
                        if (cache == null || cache.assetBundle == null)
                            Debug.Log("AssetBundle not found!:" + StartupSettings.preloadRequests[i].assetBundleName);
                    }
                }
            }

            Shader.WarmupAllShaders();
            Debug.Log(string.Format("WarmupSharesFinish (Time: {0})", Time.realtimeSinceStartup));

            GameObject permanentObjs = new GameObject("Parmanent Objects", new Type[1] { typeof(PermanentHolder) });
            UnityEngine.Object.DontDestroyOnLoad(permanentObjs);

            List<UnityEngine.Object> objsToAdd = new List<UnityEngine.Object>();

            for (int i=0; i<StartupSettings.permanentObjects.Length; i++)
            {
                UnityEngine.Object asset = StartupSettings.permanentObjects[i].asset;
                if (!string.IsNullOrEmpty(StartupSettings.permanentObjects[i].path))
                {
                    asset = LoadAsset(StartupSettings.permanentObjects[i].path, true);
                    Debug.Log("LoadAsset:" + StartupSettings.permanentObjects[i].path);
                }

                objsToAdd.Add(asset);

                if (asset != null && asset is GameObject)
                {
                    Debug.Log(string.Format("Instantiate Prefab {0}(Time: {1})", asset.name, Time.realtimeSinceStartup));

                    var permanentObj = UnityEngine.Object.Instantiate(asset, permanentObjs.transform, false);
                    permanentObj.name = asset.name;
                }
            }

            PermanentHolder.objects = objsToAdd.ToArray();
            _ready = true;

            for (int i=0; i<StartupSettings.assetManagerAfterSetupMethods.Length; i++)
                StartupSettings.assetManagerAfterSetupMethods[i].Invoke();

            Debug.Log(string.Format("AssetManagerSetup (TimeSpan: {0})", Time.realtimeSinceStartup));

            Sequencer.update += Update;
        }

        public static InstallRequestItem Install([Optional] AssetBundleDownloadManifest manifest, [Optional] string[] assetBundleNames)
        {
            if (manifest == null)
            {
                manifest = _defaultManifest;

                if (manifest == null)
                    return null;
            }

            var reqItem = new InstallRequestItem(manifest, manifest.latest.path);

            var source = manifest.installAssetBundleRecords;
            if (assetBundleNames != null && assetBundleNames.Length != 0)
                source = manifest.installAssetBundleRecords.Where(__ => assetBundleNames.Contains(__.assetBundleName)).ToArray();

            reqItem.items = new InstallRequestItem.InstallItem[source.Length];
            long totalSize = 0;
            for (int i=0; i<source.Length; i++)
            {
                source[i].isBeginInstalled = true;
                reqItem.items[i] = new InstallRequestItem.InstallItem();
                reqItem.items[i].record = source[i];
                totalSize += source[i].size;
            }

            reqItem.installSize = 0;
            reqItem.totalSize = totalSize;

            var packet = new RequestItemPacket();
            packet.packet.Add(reqItem);
            _requestList.AddLast(packet);

            return reqItem;
        }

        public static string[] GetAllAssetBundleNames()
        {
            if (!Application.isPlaying)
                return Sequencer.editorProxy.GetAllAssetBundleNames();

            if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                return _defaultManifest.GetAllAssetBundleNames();

            return Sequencer.editorProxy.GetAllAssetBundleNames().Union(_defaultManifest.GetAllAssetBundleNames()).ToArray();
        }

        public static string[] GetAssetBundleNamesWithVariant()
        {
            if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                return _defaultManifest.GetAssetBundleNamesWithVariant();

            return Sequencer.editorProxy.GetAssetBundleNamesWithVariant().Union(_defaultManifest.GetAssetBundleNamesWithVariant()).ToArray();
        }

        public static bool IsExistAssetBundle(string assetBundleName)
        {
            if (!Application.isPlaying)
                return GetAllAssetBundleNames().Any(__ => __ == assetBundleName);

            if (_defaultManifest.IsExist(assetBundleName))
                return true;

            if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                return false;

            return GetAllAssetBundleNames().Any(__ => __ == assetBundleName);
        }

        public static string[] FindAssetBundleNames(string filter)
        {
            var result = new List<string>();
            var allBundleNames = GetAllAssetBundleNames();

            for (int i=0; i<allBundleNames.Length; i++)
            {
                if (allBundleNames[i].Contains(filter))
                    result.Add(allBundleNames[i]);
            }

            return result.ToArray();
        }

        public static bool IsCached(string assetBundleName)
        {
            return AssetBundleCache.Contains(assetBundleName, false);
        }

        private static AssetBundleDownloadManifest GetManifest(string path, out string fileName)
        {
            string[] splitString = path.Split(':');
            if (splitString.Length < 2)
            {
                fileName = path;
                return _defaultManifest;
            }

            // Unsure if that's what's actually being used as the value here
            fileName = splitString[splitString.Length-1];

            if (_installedTable.TryGetValue(splitString[0], out AssetBundleDownloadManifest manifest))
                return manifest;

            Debug.LogError("Don't install manifest: " + splitString[0]);
            return _defaultManifest;
        }

        public static AssetRequestOperation AppendAssetBundleRequest(string assetBundleName, [Optional, DefaultParameterValue(true)] bool loadAllAssets, [Optional] RequestEventCallback callback, [Optional] string[] variants)
        {
            if (_requestPacket == null)
                _requestPacket = new RequestItemPacket();

            if (variants != null)
                assetBundleName = RemapVariantName(assetBundleName, variants);

            Debug.Log(string.Format("AppendAssetBundleRequest: {0} (Time: {1})", assetBundleName, Time.realtimeSinceStartup));

            var request = new AssetBundleRequestItem(_defaultManifest.GetAssetBundleRecord(assetBundleName) == null ? null : _defaultManifest, assetBundleName, loadAllAssets, true, variants);
            request.callback = callback;

            _requestPacket.packet.Add(request);
            return new AssetRequestOperation(request);
        }

        public static AssetRequestOperation RequestAssetBundle(string assetBundleName, [Optional, DefaultParameterValue(true)] bool loadAllAssets, [Optional] RequestEventCallback callback, [Optional] string[] variants)
        {
            if (variants != null)
                assetBundleName = RemapVariantName(assetBundleName, variants);

            Debug.Log(string.Format("RequestAssetBundle: {0} (Time: {1})", assetBundleName, Time.realtimeSinceStartup));

            var manifest = _defaultManifest.GetAssetBundleRecord(assetBundleName) != null ? _defaultManifest : null;
            var reqItem = new AssetBundleRequestItem(manifest, assetBundleName, loadAllAssets, true, variants);
            var packet = new RequestItemPacket();

            packet.callback = callback;
            reqItem.callback = callback;
            packet.packet.Add(reqItem);

            _requestList.AddLast(packet);
            return new AssetRequestOperation(reqItem);
        }

        public static AssetRequestOperation RequestAsset(string assetPath, [Optional] RequestEventCallback callback)
        {
            var reqItem = new AssetRequestItem(_defaultManifest, assetPath);
            var packet = new RequestItemPacket();

            packet.callback = callback;
            reqItem.callback = callback;
            packet.packet.Add(reqItem);

            _requestList.AddLast(packet);
            return new AssetRequestOperation(reqItem);
        }

        public static AssetRequestOperation AppendAssetRequest(string assetPath, [Optional] RequestEventCallback callback)
        {
            if (_requestPacket == null)
            {
                _requestPacket = new RequestItemPacket();
                _requestPacket.packet = new List<IAssetRequestItem>();
            }

            Debug.Log(string.Format("AppendAssetRequest:{0} (Time: {1})", assetPath, Time.realtimeSinceStartup));

            var item = new AssetRequestItem(_defaultManifest, assetPath);
            _requestPacket.packet.Add(item);

            return new AssetRequestOperation(item);
        }

        public static AssetRequestOperation DispatchRequests([Optional] RequestEventCallback callback)
        {
            if (_requestPacket == null)
                return null;

            _requestPacket.callback = callback;
            foreach (var packet in _requestPacket.packet)
            {
                if (packet.callback == null)
                    packet.callback = callback;
            }

            _requestList.AddLast(_requestPacket);
            var op = new AssetRequestOperation(_requestPacket.packet);
            _requestPacket = null;

            return op;
        }

        public static AssetBundleCache LoadAssetBundle(string assetBundleName)
        {
            if (string.IsNullOrEmpty(assetBundleName))
                return null;

            var record = GetAssetBundleRecord(_defaultManifest, assetBundleName);

            if (StartupSettings.assetBundleTarget == AssetBundleTarget.AssetDatabase && record.projectName.IsNullOrEmpty())
                return null;

            Debug.Log("LoadAssetBundle:" + assetBundleName);

            var cache = LoadAssetBundle(_defaultManifest, record, true, true, null);
            if (cache != null && cache.assetBundle != null)
                return cache;

            Debug.Log("AssetBundle not found!:" + assetBundleName);
            return cache;
        }

        private static AssetBundleCache LoadAssetBundle(AssetBundleDownloadManifest manifest, AssetBundleRecord record, [Optional, DefaultParameterValue(true)] bool loadAllAssets, [Optional, DefaultParameterValue(true)] bool loadDependency, [Optional] string[] variants)
        {
            Debug.Log(string.Format("LoadAssetBundle Start: {0} (Time: {1})", record.assetBundleName, Time.realtimeSinceStartup));

            var cache = AssetBundleCache.Get(record.assetBundleName);
            if (cache != null)
            {
                cache.AddRef();
                Debug.Log(string.Format("LoadAssetBundle Finished: {0} (Time: {1})", record.assetBundleName, Time.realtimeSinceStartup));
                return cache;
            }

            cache = AssetBundleCache.Add(record, false, variants);
            if (loadDependency && !record.projectName.IsNullOrEmpty())
            {
                for (int i=0; i<cache.remapDependencies.Length; i++)
                {
                    string dependency = cache.remapDependencies[i];
                    var depRecord = manifest.GetAssetBundleRecord(dependency);
                    LoadAssetBundle(manifest, depRecord, false, true, null);
                }
            }

            string basePath = cachePath.CombinePath(cache.record.projectName + "/");
            if (Application.isEditor && StartupSettings.assetBundlesForEditor.Any(__ => __ == record.assetBundleName))
            {
                string editorBundlePath = editorPath.CombinePath(record.assetBundleName);
                Debug.Log(editorBundlePath);
                cache.assetBundle = AssetBundle.LoadFromFile(editorBundlePath);
            }
            else
            {
                cache.assetBundle = AssetBundle.LoadFromFile(basePath.CombinePath(record.assetBundleName));
            }

            

            if (loadAllAssets)
            {
                var assets = cache.assetBundle.LoadAllAssets();
                if (assets == null)
                    cache.loadedAssets = ArrayHelper.Empty<UnityEngine.Object>();

                cache.loadedAssets = assets;

                for (int i=0; i<cache.loadedAssets.Length; i++)
                {
                    if (cache.loadedAssets[i] != null && cache.loadedAssets[i] is Shader)
                    {
                        Debug.Log("Register Shader: " + cache.loadedAssets[i].name);
                        _shaders.Add(cache.loadedAssets[i] as Shader);
                    }
                }

                cache.isLoaded = true;
            }

            Debug.Log(string.Format("LoadAssetBundle Finished: {0} (Time: {1})", record.assetBundleName, Time.realtimeSinceStartup));
            return cache;
        }

        public static UnityEngine.Object LoadAsset(string assetPath, bool cached = false)
        {
            if (SceneDatabase.Contains(assetPath))
                Debug.LogError("Scene is not supported!: " + assetPath);

            string bundleName = _defaultManifest.GetAssetBundleNameAtPath(assetPath);
            Debug.Log("LoadAsset:" + assetPath + bundleName);

            if (string.IsNullOrEmpty(bundleName))
                return Resources.Load(assetPath);

            var record = GetAssetBundleRecord(_defaultManifest, bundleName);
            Debug.Log("LoadAsset:" + record.projectName);

            if (StartupSettings.assetBundleTarget == AssetBundleTarget.AssetDatabase && record.projectName.IsNullOrEmpty())
                return Sequencer.editorProxy.LoadMainAssetAtPath(assetPath);

            var bundleCache = LoadAssetBundle(_defaultManifest, record, true, true, null);
            if (bundleCache == null || bundleCache.assetBundle == null)
                Debug.LogError("AssetBundle not found!:" + bundleName);

            var asset = bundleCache.assetBundle.LoadAsset(assetPath);
            if (Application.isEditor)
                Sequencer.editorProxy.ReloadEditorShaders(asset);

            if (!cached)
                AssetBundleCache.ReleaseFromAssetBundleName(bundleName, false);

            return asset;
        }

        public static int UnloadAssetBundleAtAssetPath(string assetPath)
        {
            var manifest = GetManifest(assetPath, out string fileName);

            if (SceneDatabase.Contains(fileName))
                Debug.LogError("Scene is not supported!: " + fileName);

            if (manifest == null)
                return 0;

            return AssetBundleCache.ReleaseFromAssetBundleName(manifest.GetAssetBundleNameAtPath(fileName), false);
        }

        public static int UnloadAssetBundle(string assetBundleName)
        {
            return AssetBundleCache.ReleaseFromAssetBundleName(assetBundleName, false);
        }

        public static bool isBusy { get => _requestList.Count > 0; }

        private static void Update(float deltaTime)
        {
            if (_errorRequestList.Count < 1)
            {
                _removePackets.Clear();

                foreach (var req in _requestList)
                {
                    bool done = true;
                    foreach (var reqItem in req.packet)
                        done &= ProcessRequestItem(reqItem);

                    if (done)
                        _removePackets.Add(req);
                }

                foreach (var packet in _removePackets)
                {
                    packet.callback?.Invoke(RequestEventType.Complete, string.Empty, null);
                    packet.packet.Clear();
                    packet.callback = null;
                    _requestList.Remove(packet);
                }

                if (_dependencyRequestPacket != null)
                {
                    _requestList.AddFirst(_dependencyRequestPacket);
                    _dependencyRequestPacket = null;
                }
            }
            else
            {
                // Message = "Retry?"
                // Caption = "Install Error"
                MessageBox.Show("リトライしますか？", "インストールエラー", MessageBoxButtons.RetryCancel, null, (result) =>
                {
                    if (result == MessageBoxResult.Cancel || result == MessageBoxResult.Retry)
                        _errorRequestList.Clear();
                });
            }
        }

        private static AssetBundleRecord GetAssetBundleRecord(AssetBundleDownloadManifest manifest, string assetBundleName)
        {
            if (manifest != null)
            {
                var record = manifest.GetAssetBundleRecord(assetBundleName);
                if (record != null)
                {
                    if (!record.isSimulation)
                        return record;

                    Debug.Log("Simulation AssetBundle: " + assetBundleName);
                }
                else
                {
                    if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                    {
                        Debug.LogError("AssetBundle not found!:" + assetBundleName);
                        return null;
                    }
                }
            }

            return new AssetBundleRecord("", assetBundleName);
        }

        private static void OnStreamWriteFinished(IAsyncResult asyncResult)
        {
            var state = asyncResult.AsyncState as AssetBundleRequestItem;
            state.cache.record.hash = state.cache.record.latest.hash;
            state.cache.record.latest = null;
            state.fileStream.EndWrite(asyncResult);
            state.fileStream.Close();
            state.fileStream = null;
            state.cache.Release();
        }

        // 1
        private static bool ProcessRequestItem_ResolveDependencies(IAssetRequestItem requestItem)
        {
            var callback = requestItem.callback;
            if (requestItem == null)
                return false;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;
            var assetRequestItem = requestItem as AssetRequestItem;

            if (bundleRequestItem == null)
            {
                if (assetRequestItem == null)
                    return false;

                string bundleName;
                if (SceneDatabase.Contains(assetRequestItem.uri))
                {
                    bundleName = SceneDatabase.GetAssetBundleName(assetRequestItem.uri);
                }
                else
                {
                    var record = GetAssetBundleRecord(assetRequestItem.manifest, assetRequestItem.assetBundleName);
                    bundleName = record == null ? Sequencer.editorProxy.GetAssetBundleNameAtPath(assetRequestItem.uri) : assetRequestItem.manifest.GetAssetBundleNameAtPath(assetRequestItem.uri);
                }

                if (!string.IsNullOrEmpty(bundleName))
                {
                    assetRequestItem.assetBundleName = bundleName;
                    var cache = AssetBundleCache.Get(bundleName, true);
                    if (cache != null)
                    {
                        cache.AddRef();
                        return ProcessRequestItem_LoadAsset(assetRequestItem);
                    } 

                    if (_dependencyRequestPacket == null)
                        _dependencyRequestPacket = new RequestItemPacket();

                    var newRequest = new AssetBundleRequestItem(assetRequestItem.manifest, bundleName, false, true, null);
                    _dependencyRequestPacket.packet.Add(newRequest);

                    assetRequestItem.status = RequestStatus.LoadAsset;
                    return false;
                }

                return ProcessRequestItem_LoadAsset(requestItem);
            }
            else
            {
                Debug.Log(string.Format("ResolveDependencies: {0} (Time: {1})", bundleRequestItem.uri, Time.realtimeSinceStartup));
                if (!string.IsNullOrEmpty(bundleRequestItem.uri))
                {
                    var cache = AssetBundleCache.Get(bundleRequestItem.uri, false);
                    if (cache != null)
                    {
                        if (StartupSettings.assetBundleTarget == AssetBundleTarget.AssetDatabase && cache.record == null && cache.variants != bundleRequestItem.variants)
                        {
                            while (true)
                            {
                                if (AssetBundleCache.ReleaseFromAssetBundleName(bundleRequestItem.uri, false) < 1)
                                    return false;
                            }
                        }

                        bundleRequestItem.cache = cache;
                        cache.AddRef();

                        for (int i=0; i<cache.record.allDependencies.Length; i++)
                        {
                            string dependency = cache.record.allDependencies[i];
                            string variant = RemapVariantName(dependency, bundleRequestItem.variants);

                            if (string.IsNullOrEmpty(variant) || AssetBundleCache.Get(variant, false) == null)
                            {
                                while (true)
                                {
                                    if (AssetBundleCache.ReleaseFromAssetBundleName(bundleRequestItem.uri, false) < 1)
                                        return false;
                                }
                            }
                        }

                        return ProcessRequestItem_WaitForCacheLoading(requestItem);
                    }
                }

                var record = GetAssetBundleRecord(bundleRequestItem.manifest, bundleRequestItem.uri);
                if (record != null)
                {
                    if (record.isStreamingSceneAssetBundle)
                        bundleRequestItem.loadAllAssets = false;

                    bundleRequestItem.cache = AssetBundleCache.Add(record, false, bundleRequestItem.variants);
                    if (!record.projectName.IsNullOrEmpty())
                    {
                        for (int i = 0; i < bundleRequestItem.cache.remapDependencies.Length; i++)
                        {
                            string dep = bundleRequestItem.cache.remapDependencies[i];
                            var cache = AssetBundleCache.Get(dep, true);
                            if (cache != null)
                            {
                                cache.AddRef();
                                continue;
                            }

                            if (_dependencyRequestPacket == null)
                                _dependencyRequestPacket = new RequestItemPacket();

                            var reqItem = new AssetBundleRequestItem(bundleRequestItem.manifest, dep, false, false, bundleRequestItem.variants);
                            var depRecord = bundleRequestItem.manifest.GetAssetBundleRecord(dep);
                            reqItem.cache = AssetBundleCache.Add(depRecord, false, bundleRequestItem.variants);

                            if (reqItem.cache.record == null)
                                Debug.LogError("AssetBundle not exists!: " + dep);

                            if (reqItem.cache.record.latest != null)
                                reqItem.status = reqItem.cache.record.isBeginInstalled ? RequestStatus.WaitForInstallation : RequestStatus­.LoadAndInstall;

                            _dependencyRequestPacket.packet.Add(reqItem);
                        }
                    }
                    else
                    {
                        bundleRequestItem.cache.isLoaded = true;
                    }

                    if (record.latest != null)
                    {
                        if (record.isBeginInstalled)
                            return ProcessRequestItem_WaitForInstallation(requestItem);

                        return ProcessRequestItem_LoadAndInstall(requestItem);
                    }

                    return ProcessRequestItem_LoadAssetBundle(requestItem);
                }

                bundleRequestItem.status = RequestStatus.FileNotFound;
                return false;
            }
        }

        // 2
        private static bool ProcessRequestItem_LoadAndInstall(IAssetRequestItem requestItem)
        {
            if (!_cacheEnabled)
                return ProcessRequestItem_LoadAssetBundle(requestItem);

            requestItem.status = RequestStatus.LoadAndInstall;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (!bundleRequestItem.error.IsNullOrEmpty())
            {
                bundleRequestItem.webRequest.Dispose();
                bundleRequestItem.webRequest = null;
                bundleRequestItem.error = null;
                return false;
            }

            if (bundleRequestItem.webRequest != null)
            {
                if (bundleRequestItem.webRequest.isHttpError || bundleRequestItem.webRequest.isNetworkError)
                {
                    bundleRequestItem.error = bundleRequestItem.webRequest.error.IsNullOrEmpty() ? bundleRequestItem.webRequest.error : "error";
                    _errorRequestList.Add(bundleRequestItem);
                    return false;
                }

                if (!bundleRequestItem.webRequest.isDone)
                    return false;

                if (bundleRequestItem.cache.record.hash.isValid)
                {
                    File.Delete(cachePath + "/" + Application.productName + "/" + bundleRequestItem.cache.record.hash.ToString());
                    bundleRequestItem.cache.record.hash = new RecordedHash();
                }

                bundleRequestItem.cache.AddRef();
                bundleRequestItem.createRequest = AssetBundle.LoadFromMemoryAsync(bundleRequestItem.webRequest.downloadHandler.data);

                bundleRequestItem.fileStream = new FileStream(cachePath + "/" + bundleRequestItem.manifest.projectName + "/" + bundleRequestItem.cache.record.latest.hash.ToString(), FileMode.Create, FileAccess.Write, FileShare.None, 0x1000, true);
                long size = bundleRequestItem.cache.record.size;
                bundleRequestItem.fileStream.BeginRead(bundleRequestItem.webRequest.downloadHandler.data, 0, (int)size, OnStreamWriteFinished, requestItem);

                return ProcessRequestItem_LoadAssetBundle(requestItem);
            }

            if (bundleRequestItem.manifest.latest != null && StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
            {
                var webRequest = UnityWebRequest.Get(bundleRequestItem.manifest.latest.path + bundleRequestItem.uri);
                webRequest.SendWebRequest();
                bundleRequestItem.webRequest = webRequest;
                return false;
            }

            Debug.LogError("Not found latest manifest!: " + bundleRequestItem.manifest.projectName);
            return false;
        }

        // 3
        private static bool ProcessRequestItem_RequestInstallation(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.RequestInstallation;

            var installRequestItem = requestItem as InstallRequestItem;

            if (installRequestItem.items.Length < 1)
                return ProcessRequestItem_LoadFinished(requestItem);

            for (int i=0; i<installRequestItem.items.Length; i++)
            {
                var item = installRequestItem.items[i];
                if (item.record.latest != null)
                {
                    if (item.webRequest != null)
                    {
                        item.webRequest.Dispose();
                        item.webRequest = null;
                    }

                    var request = UnityWebRequest.Get(installRequestItem.manifest.latest.path);
                    request.downloadHandler = new InstallHandler(installRequestItem.manifest.projectName + "/" + item.record.latest.hash.ToString(), _preallocatedBuffer);
                    request.timeout = 0;

                    if (i < MaxInstallRequest)
                    {
                        request.SendWebRequest();
                        request.timeout = Timeout;
                        item.send = true;
                    }

                    item.webRequest = request;
                }
            }

            return ProcessRequestItem_InstallAssetBundles(requestItem);
        }

        // 4
        private static bool ProcessRequestItem_InstallAssetBundles(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.InstallAssetBundles;

            var installRequestItem = requestItem as InstallRequestItem;

            bool error = false;
            bool finishedInstalling = true;
            int sendCount = 0;
            for (int i=0; i<installRequestItem.items.Length; i++)
            {
                var item = installRequestItem.items[i];
                if (item.webRequest == null || !item.send)
                    continue;

                if (item.webRequest.isHttpError || item.webRequest.isNetworkError)
                {
                    Debug.LogError("Install failed!: " + item.webRequest.url);
                    item.send = false;
                    error = true;
                    finishedInstalling = false;
                    continue;
                }

                if (item.webRequest.isDone)
                {
                    installRequestItem.installSize += (long)item.webRequest.downloadedBytes;
                    item.webRequest.Dispose();
                    item.webRequest = null;
                    item.record.hash = item.record.latest.hash;
                    item.record.lastWriteTime = item.record.latest.lastWriteTime;
                    item.record.latest = null;
                    item.record.isBeginInstalled = false;
                    item.send = false;
                    finishedInstalling = false;
                    continue;
                }

                finishedInstalling = false;

                if (item.send)
                    sendCount++;
            }

            if (error)
            {
                installRequestItem.status = RequestStatus.RequestInstallation;
                _errorRequestList.Add(installRequestItem);
                return false;
            }

            if (sendCount < MaxInstallRequest)
            {
                for (int i=0; i<installRequestItem.items.Length; i++)
                {
                    var item = installRequestItem.items[i];
                    if (item.webRequest != null && !item.send)
                    {
                        item.send = true;
                        item.webRequest.timeout = Timeout;
                        item.webRequest.SendWebRequest();

                        sendCount++;
                        if (sendCount == MaxInstallRequest)
                            break;
                    }
                }
            }

            if (!finishedInstalling)
                return false;

            if (_cacheEnabled)
                return ProcessRequestItem_SaveManifest(requestItem);

            return ProcessRequestItem_Complete(requestItem);
        }

        // 5
        private static bool ProcessRequestItem_SaveManifest(IAssetRequestItem requestItem)
        {
            var installRequestItem = requestItem as InstallRequestItem;
            installRequestItem.manifest.Save(cachePath + "/" + installRequestItem.manifest.projectName + ".bin", false);
            return ProcessRequestItem_Complete(requestItem);
        }

        // 6
        private static bool ProcessRequestItem_WaitForInstallation(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.WaitForInstallation;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (bundleRequestItem.cache.record.isBeginInstalled)
                return false;

            return ProcessRequestItem_LoadAssetBundle(requestItem);
        }

        // 7
        private static bool ProcessRequestItem_WaitForCacheLoading(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.WaitForCacheLoading;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (bundleRequestItem.cache.isLoaded)
            {
                if (bundleRequestItem.loadAllAssets)
                    return ProcessRequestItem_LoadAsset(requestItem);

                return ProcessRequestItem_LoadFinished(requestItem);
            }

            Debug.Log("Wait request " + bundleRequestItem.uri);
            return false;
        }

        // 8
        private static bool ProcessRequestItem_WaitForCacheWriting(IAssetRequestItem requestItem)
        {
            if (requestItem == null)
                return false;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (bundleRequestItem == null || bundleRequestItem.fileStream != null)
                return false;

            return ProcessRequestItem_SaveManifest(requestItem);
        }

        // 9
        private static bool ProcessRequestItem_WaitForReloadShaders(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.WaitForReloadShaders;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (bundleRequestItem.customInstruction.keepWaiting)
                return false;

            if (bundleRequestItem.callback != null)
            {
                for (int i=0; i<bundleRequestItem.cache.loadedAssets.Length; i++)
                    bundleRequestItem.callback.Invoke(RequestEventType.Activated, bundleRequestItem.cache.loadedAssets[i].name, bundleRequestItem.cache.loadedAssets[i]);
            }

            return ProcessRequestItem_LoadFinished(requestItem);
        }

        // 10
        private static bool ProcessRequestItem_LoadAssetBundle(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.LoadAssetBundle;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;

            if (bundleRequestItem.createRequest == null)
            {
                if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase || !bundleRequestItem.cache.record.projectName.IsNullOrEmpty())
                {
                    string basePath = cachePath.CombinePath(bundleRequestItem.cache.record.projectName + "/");

                    if (Application.isEditor && StartupSettings.assetBundlesForEditor.Any(__ => __ == bundleRequestItem.uri))
                    {
                        basePath = editorPath;
                        Debug.Log(editorPath.CombinePath(bundleRequestItem.uri));
                    }

                    string bundlePath;
                    if (_cacheEnabled)
                        bundlePath = basePath.CombinePath(bundleRequestItem.cache.record.hash.ToString());
                    else
                        bundlePath = basePath.CombinePath(bundleRequestItem.uri);

                    if (!_cacheEnabled || File.Exists(bundlePath))
                    {
                        if (AssetBundleMemory.GetBuffer(bundleRequestItem.uri, out byte[] buffer))
                        {
                            Debug.Log("AssetBundle in memory: " + bundleRequestItem.uri);
                            bundleRequestItem.createRequest = AssetBundle.LoadFromMemoryAsync(buffer);
                            if (bundleRequestItem.createRequest != null)
                                return false;
                        }
                        else
                        {
                            bundleRequestItem.createRequest = AssetBundle.LoadFromFileAsync(bundlePath);
                            if (bundleRequestItem.createRequest != null)
                                return false;
                        }

                        Debug.LogError("File not found!: " + bundleRequestItem.uri);
                        return false;
                    }

                    Debug.LogError("File not found!:" + bundlePath);
                    bundleRequestItem.status = RequestStatus.FileNotFound;
                    return false;
                }
            }
            else
            {
                if (!bundleRequestItem.createRequest.isDone)
                    return false;

                bundleRequestItem.cache.assetBundle = bundleRequestItem.createRequest.assetBundle;
                bundleRequestItem.cache.isLoaded = true;
            }

            if (bundleRequestItem.loadAllAssets)
                return ProcessRequestItem_LoadAsset(requestItem);

            return ProcessRequestItem_LoadFinished(requestItem);
        }

        // 11
        private static bool ProcessRequestItem_LoadAsset(IAssetRequestItem requestItem)
        {
            var callback = requestItem.callback;

            requestItem.status = RequestStatus.LoadAsset;

            if (requestItem == null)
                return false;

            var bundleRequestItem = requestItem as AssetBundleRequestItem;
            var assetRequestItem = requestItem as AssetRequestItem;

            if (bundleRequestItem == null)
            {
                if (assetRequestItem == null)
                    return false;

                UnityEngine.Object obj = null;

                if (assetRequestItem.resourceRequest == null)
                {
                    AssetBundleCache cache = null;
                    if (!string.IsNullOrEmpty(assetRequestItem.assetBundleName))
                    {
                        cache = AssetBundleCache.Get(assetRequestItem.assetBundleName);
                        if (cache == null || !cache.canLoadAsset)
                            return false;
                    }

                    if (SceneDatabase.Contains(assetRequestItem.uri))
                    {
                        if (StartupSettings.assetBundleTarget == AssetBundleTarget.AssetDatabase && assetRequestItem.assetBundleName != null)
                        {
                            var record = GetAssetBundleRecord(assetRequestItem.manifest, assetRequestItem.assetBundleName);
                            if (record != null)
                            {
                                assetRequestItem.resourceRequest = Sequencer.editorProxy.LoadLevelAdditiveAsyncInPlayMode(assetRequestItem.uri);
                                return false;
                            }
                        }

                        assetRequestItem.resourceRequest = SceneManager.LoadSceneAsync(assetRequestItem.uri, LoadSceneMode.Additive);
                        return false;
                    }

                    if (cache == null)
                    {
                        assetRequestItem.resourceRequest = Resources.LoadAsync(assetRequestItem.uri);
                        return false;
                    }

                    int foundIndex = Array.IndexOf(cache.record.assetPaths, assetRequestItem.uri);
                    if (foundIndex == -1)
                    {
                        Debug.LogWarning("Don't match asset uri: " + assetRequestItem.uri);
                        if (requestItem.manifest != null)
                        {
                            if (!cache.canLoadAsset)
                                return false;

                            if (cache.record.assetPaths.Length == 1)
                                assetRequestItem.resourceRequest = cache.assetBundle.LoadAllAssetsAsync();
                            else
                                assetRequestItem.resourceRequest = cache.assetBundle.LoadAssetAsync(assetRequestItem.uri);

                            cache.loadedAssets[foundIndex] = _waitObject;
                            return false;
                        }

                        Sequencer.editorProxy.LoadMainAssetAtPath(assetRequestItem.uri);
                    }
                    else
                    {
                        obj = cache.loadedAssets[foundIndex];

                        if (obj == null)
                        {
                            if (requestItem.manifest != null)
                            {
                                if (!cache.canLoadAsset)
                                    return false;

                                if (cache.record.assetPaths.Length == 1)
                                    assetRequestItem.resourceRequest = cache.assetBundle.LoadAllAssetsAsync();
                                else
                                    assetRequestItem.resourceRequest = cache.assetBundle.LoadAssetAsync(assetRequestItem.uri);

                                cache.loadedAssets[foundIndex] = _waitObject;
                                return false;
                            }

                            Sequencer.editorProxy.LoadMainAssetAtPath(assetRequestItem.uri);
                        }
                        else if (obj == _waitObject)
                        {
                            return false;
                        }
                        else if (callback == null)
                        {
                            return ProcessRequestItem_LoadFinished(requestItem);
                        }
                    }

                    if (callback == null)
                        return ProcessRequestItem_LoadFinished(requestItem);
                }
                else
                {
                    if (!assetRequestItem.resourceRequest.isDone)
                        return false;

                    if (callback == null || SceneDatabase.Contains(assetRequestItem.uri))
                        return ProcessRequestItem_LoadFinished(requestItem);

                    if (assetRequestItem.resourceRequest is AssetBundleRequest)
                        obj = (assetRequestItem.resourceRequest as AssetBundleRequest).asset;
                    if (assetRequestItem.resourceRequest is ResourceRequest)
                        obj = (assetRequestItem.resourceRequest as ResourceRequest).asset;

                    if (Application.isEditor)
                        Sequencer.editorProxy.ReloadEditorShaders(obj);
                }

                callback?.Invoke(RequestEventType.Activated, obj.name, obj);
                return ProcessRequestItem_LoadFinished(requestItem);
            }
            else
            {
                if (StartupSettings.assetBundleTarget == AssetBundleTarget.AssetDatabase && bundleRequestItem.cache.record.projectName.IsNullOrEmpty())
                {
                    var assetPaths = Sequencer.editorProxy.GetAssetPathsFromAssetBundle(bundleRequestItem.uri);
                    if (assetPaths.Length == 0)
                    {
                        Debug.LogError("File not found!:" + bundleRequestItem.uri);
                        bundleRequestItem.status = RequestStatus.FileNotFound;
                    }
                    else
                    {
                        for (int i=0; i<bundleRequestItem.cache.loadedAssets.Length; i++)
                        {
                            var obj = bundleRequestItem.cache.loadedAssets[i];

                            if (obj == _waitObject)
                                return false;

                            if (obj == null)
                            {
                                var loadedObj = Sequencer.editorProxy.LoadMainAssetAtPath(assetPaths[i]);
                                bundleRequestItem.cache.loadedAssets[i] = loadedObj;
                                Sequencer.editorProxy.ReloadVariantAssets(loadedObj, bundleRequestItem.variants);
                            }
                        }
                    }
                }
                else if (bundleRequestItem.assetRequest == null)
                {
                    if (!bundleRequestItem.cache.canLoadAsset)
                        return false;

                    if (!bundleRequestItem.cache.allLoaded)
                    {
                        bundleRequestItem.assetRequest = bundleRequestItem.cache.assetBundle.LoadAllAssetsAsync();
                        Debug.Log(string.Format("Loading all assets: {0} (Time: {1})", bundleRequestItem.uri, Time.realtimeSinceStartup));
                        return false;
                    }
                }
                else
                {
                    if (!bundleRequestItem.assetRequest.isDone)
                        return false;

                    var bundleAssetRequest = bundleRequestItem.assetRequest as AssetBundleRequest;

                    if (bundleAssetRequest.allAssets == null)
                        bundleRequestItem.cache.loadedAssets = ArrayHelper.Empty<UnityEngine.Object>();

                    bundleRequestItem.cache.loadedAssets = bundleAssetRequest.allAssets;

                    if (Application.isEditor)
                    {
                        for (int i = 0; i < bundleRequestItem.cache.loadedAssets.Length; i++)
                            Sequencer.editorProxy.ReloadEditorShaders(bundleRequestItem.cache.loadedAssets[i]);
                    }
                }

                for (int i=0; i<bundleRequestItem.cache.loadedAssets.Length; i++)
                    callback?.Invoke(RequestEventType.Activated, bundleRequestItem.cache.loadedAssets[i].name, bundleRequestItem.cache.loadedAssets[i]);

                return ProcessRequestItem_LoadFinished(requestItem);
            }
        }

        // 12
        private static bool ProcessRequestItem_LoadFinished(IAssetRequestItem requestItem)
        {
            var callback = requestItem.callback;

            requestItem.status = RequestStatus.LoadFinished;

            if (requestItem == null)
                return ProcessRequestItem_Complete(requestItem);

            var bundleRequestItem = requestItem as AssetBundleRequestItem;
            var assetRequestItem = requestItem as AssetRequestItem;

            if (bundleRequestItem == null)
            {
                if (assetRequestItem != null)
                {
                    if (string.IsNullOrEmpty(assetRequestItem.assetBundleName))
                        AssetBundleCache.ReleaseFromAssetBundleName(assetRequestItem.assetBundleName, false);
                }

                return ProcessRequestItem_Complete(requestItem);
            }
            else
            {
                Debug.Log(string.Format("AssetBundleFinished: {0} (Time: {1})", requestItem.uri, Time.realtimeSinceStartup));
                callback?.Invoke(RequestEventType.Cached, requestItem.uri, bundleRequestItem.cache.assetBundle);
                if (bundleRequestItem.fileStream == null)
                    return ProcessRequestItem_Complete(requestItem);

                if (bundleRequestItem.fileStream != null)
                    return false;

                return ProcessRequestItem_SaveManifest(requestItem);
            }
        }

        // 13
        private static bool ProcessRequestItem_Complete(IAssetRequestItem requestItem)
        {
            requestItem.status = RequestStatus.Complete;
            return true;
        }

        // Each case was split into its own method to make it more readable
        private static bool ProcessRequestItem(IAssetRequestItem requestItem)
        {
            switch (requestItem.status)
            {
                case RequestStatus.ResolveDependencies:
                    return ProcessRequestItem_ResolveDependencies(requestItem);

                case RequestStatus.LoadAndInstall:
                    return ProcessRequestItem_LoadAndInstall(requestItem);

                case RequestStatus.RequestInstallation:
                    return ProcessRequestItem_RequestInstallation(requestItem);

                case RequestStatus.InstallAssetBundles:
                    return ProcessRequestItem_InstallAssetBundles(requestItem);

                case RequestStatus.SaveManifest:
                    return ProcessRequestItem_SaveManifest(requestItem);

                case RequestStatus.WaitForInstallation:
                    return ProcessRequestItem_WaitForInstallation(requestItem);

                case RequestStatus.WaitForCacheLoading:
                    return ProcessRequestItem_WaitForCacheLoading(requestItem);

                case RequestStatus.WaitForCacheWriting:
                    return ProcessRequestItem_WaitForCacheWriting(requestItem);

                case RequestStatus.WaitForReloadShaders:
                    return ProcessRequestItem_WaitForReloadShaders(requestItem);

                case RequestStatus.LoadAssetBundle:
                    return ProcessRequestItem_LoadAssetBundle(requestItem);

                case RequestStatus.LoadAsset:
                    return ProcessRequestItem_LoadAsset(requestItem);

                case RequestStatus.LoadFinished:
                    return ProcessRequestItem_LoadFinished(requestItem);

                case RequestStatus.Complete:
                    return ProcessRequestItem_Complete(requestItem);

                default:
                    return false;
            }
        }

        public static string RemapVariantName(string assetBundleName, string[] variants)
        {
            if (variants == null || variants.Length == 0)
                return assetBundleName;

            string matchedName = _defaultManifest.FindMatchAssetBundleNameWithVariants(assetBundleName, variants);
            if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase)
                return matchedName;

            if (matchedName != assetBundleName)
                return matchedName;

            return Sequencer.editorProxy.FindMatchAssetBundleNameWithVariants(matchedName, variants);
        }

        public static void OnResumeSingleton()
        {
            for (int i=0; i<StartupSettings.permanentObjects.Length; i++)
            {
                if (!string.IsNullOrEmpty(StartupSettings.permanentObjects[i].path))
                    UnloadAssetBundleAtAssetPath(StartupSettings.permanentObjects[i].path);
            }

            AssetBundleCache.Destroy();
        }

        private static void OnDestroy()
        {
            for (int i=0; i<StartupSettings.permanentObjects.Length; i++)
            {
                var item = StartupSettings.permanentObjects[i];
                if (!string.IsNullOrEmpty(item.path))
                    UnloadAssetBundleAtAssetPath(item.path);
            }

            for (int i=0; i<StartupSettings.preloadRequests.Length; i++)
            {
                var item = StartupSettings.preloadRequests[i];
                if (!string.IsNullOrEmpty(item.assetBundleName))
                {
                    var record = GetAssetBundleRecord(_defaultManifest, item.assetBundleName);
                    if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase || !record.projectName.IsNullOrEmpty())
                        AssetBundleCache.ReleaseFromAssetBundleName(item.assetBundleName, false);
                }
            }

            AssetBundleCache.Destroy();
        }

        public delegate void OnRequestError();
    }
}