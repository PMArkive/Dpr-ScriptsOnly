using UnityEngine;
using System.Collections.Generic;
using SmartPoint.AssetAssistant.SmartPoint.AssetAssistant;

namespace SmartPoint.AssetAssistant
{
    public class AssetRequestOperation : CustomYieldInstruction
    {
        private IAssetRequestItem[] _requests;

        public IAssetRequestItem[] requests { get => _requests; }
        public IAssetRequestItem request { get => _requests[0]; }
        public AssetRequestItem assetRequest { get => _requests[0] as AssetRequestItem; }
        public AssetRequestItem[] assetRequests { get => _requests as AssetRequestItem[]; }
        public AssetBundleRequestItem assetBundleRequest { get => _requests[0] as AssetBundleRequestItem; }
        public AssetBundleRequestItem[] assetBundleRequests { get => _requests as AssetBundleRequestItem[]; }
        public override bool keepWaiting
        {
            get
            {
                foreach (var req in _requests)
                {
                    if (!req.isComplete && string.IsNullOrEmpty(req.error))
                        return true;
                }

                return false;
            }
        }

        public AssetRequestOperation(IAssetRequestItem requestItem)
        {
            _requests = new IAssetRequestItem[] { requestItem };
        }

        public AssetRequestOperation(IAssetRequestItem[] requestItems)
        {
            _requests = new IAssetRequestItem[requestItems.Length];
            for (int i=0; i<requestItems.Length; i++)
                _requests[i] = requestItems[i];
        }

        public AssetRequestOperation(List<IAssetRequestItem> requestItems)
        {
            _requests = new IAssetRequestItem[requestItems.Count];
            for (int i=0; i<requestItems.Count; i++)
                _requests[i] = requestItems[i];
        }
    }
}