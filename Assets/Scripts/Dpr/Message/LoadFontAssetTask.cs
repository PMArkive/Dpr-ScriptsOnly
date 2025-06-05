using SmartPoint.AssetAssistant;
using System;
using TMPro;

namespace Dpr.Message
{
    public class LoadFontAssetTask
    {
        public bool bRunning;
        public MessageEnumData.MsgLangId langId;
        public string fileName;
        public AssetRequestOperation operation;
        public Action<LoadFontAssetTask> onCompleteLoadAct;

        public bool IsDone
        {
            get
            {
                if (operation != null)
                    return !operation.keepWaiting;

                return true;
            }
        }
        public UnityEngine.Object Asset { get => operation.assetBundleRequest.cache.FindFirstAsset<TMP_FontAsset>(); }

        public void OnFinishedLoad()
        {
            onCompleteLoadAct = null;
            bRunning = false;
        }

        public void Dispose()
        {
            if (operation != null)
            {
                // This line is presumed to have been commented out, the result of string.Format is ignored otherwise
                //Debug.Log(string.Format("Dispose FontAsset LoadTask [{0}]: refCnt [{1}]", fileName, operation.assetBundleRequest.cache.referencedCount));

                AssetBundleCache.ReleaseFromAssetBundleChache(operation.assetBundleRequest.cache, false);
            }

            operation = null;
            onCompleteLoadAct = null;
        }
    }
}