using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class InstallRequestItem : IAssetRequestItem
    {
        public InstallRequestItem(AssetBundleDownloadManifest _cacheManifest, string _uri)
        {
            manifest = _cacheManifest;
            uri = _uri;
            status = RequestStatus.RequestInstallation;
        }

        public RequestStatus status { get; set; }
        public AssetBundleDownloadManifest manifest { get; set; }
        public string uri { get; set; }
        public InstallItem[] items { get; set; }
        public long installSize { get; set; }
        public long totalSize { get; set; }
        public RequestEventCallback callback { get; set; }
        public string error { get; set; }
        public bool isComplete { get => status == RequestStatus.Complete; }
        public float progress
        {
            get
            {
                if (isComplete)
                    return 1.0f;

                long installedSize = installSize;
                for (int i=0; i<items.Length; i++)
                {
                    var item = items[i];
                    if (item.webRequest != null && !item.webRequest.isDone)
                    {
                        installedSize += (long)item.webRequest.downloadedBytes;
                    }
                }

                return (float)installedSize / totalSize;
            }
        }

        public class InstallItem
        {
	        public AssetBundleRecord record;
            public UnityWebRequest webRequest;
            public bool send;
        }
    } 
}