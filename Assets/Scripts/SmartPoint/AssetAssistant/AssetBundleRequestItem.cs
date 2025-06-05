using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleRequestItem : IAssetRequestItem
    {
        public AssetBundleRequestItem(AssetBundleDownloadManifest _manifest, string _uri, [Optional, DefaultParameterValue(true)] bool _loadAllAssets, [Optional, DefaultParameterValue(true)] bool _loadDependencies, [Optional] string[] _variants)
        {
            manifest = _manifest;
            uri = _uri;
            variants = _variants;
            status = _loadDependencies ? RequestStatus.ResolveDependencies : RequestStatus.LoadAssetBundle;
            loadAllAssets = _loadAllAssets;
        }

        public bool isComplete { get => status == RequestStatus.Complete; }
        public RequestStatus status { get; set; }
        public AssetBundleDownloadManifest manifest { get; set; }
        public string uri { get; set; }
        public UnityWebRequest webRequest { get; set; }
        public FileStream fileStream { get; set; }
        public string[] variants { get; set; }
        public bool loadAllAssets { get; set; }
        public AssetBundleCache cache { get; set; }
        public AssetBundleCreateRequest createRequest { get; set; }
        public AsyncOperation assetRequest { get; set; }
        public RequestEventCallback callback { get; set; }
        public string error { get; set; }
        public CustomYieldInstruction customInstruction { get; set; }
    }
}