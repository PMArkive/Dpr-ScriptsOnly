using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    namespace SmartPoint.AssetAssistant
    {
        public class AssetRequestItem : IAssetRequestItem
        {
            public AssetRequestItem(AssetBundleDownloadManifest _manifest, string _assetName)
            {
                uri = _assetName;
                manifest = _manifest;
                assetBundleName = null;
                status = RequestStatus.ResolveDependencies;
            }

            public Object asset
            {
                get
                {
                    if (resourceRequest != null)
                    {
                        if (resourceRequest is AssetBundleRequest)
                            return (resourceRequest as AssetBundleRequest).asset;

                        if (resourceRequest is ResourceRequest)
                            return (resourceRequest as ResourceRequest).asset;
                    }

                    return null;
                }
            }

            public bool isComplete { get => status == RequestStatus.Complete; }
            public RequestStatus status { get; set; }
            public AssetBundleDownloadManifest manifest { get; set; }
            public string uri { get; set; }
            public string assetBundleName { get; set; }
            public AsyncOperation resourceRequest { get; set; }
            public RequestEventCallback callback { get; set; }
            public string error { get; set; }
        }
    }
}