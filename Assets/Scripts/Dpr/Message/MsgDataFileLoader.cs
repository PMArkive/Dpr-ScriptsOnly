using SmartPoint.AssetAssistant;
using System;

namespace Dpr.Message
{
    public class MsgDataFileLoader
    {
        private Action<LoadAssetBundleTask> OnCompleteLoadAssetAction;
        private Action<LoadMsbtFileTask> OnCompleteLoadMsbtAction;
        private bool bIsLoading;

        public bool IsLoading { get => bIsLoading; }

        public void Initialize(Action<LoadAssetBundleTask> onCompleteLoadAssetAct, Action<LoadMsbtFileTask> onCompleteLoadMsbtAct)
        {
            bIsLoading = false;
            OnCompleteLoadAssetAction = onCompleteLoadAssetAct;
            OnCompleteLoadMsbtAction = onCompleteLoadMsbtAct;
        }

        public void Dispose()
        {
            if (bIsLoading)
                MessageHelper.EmitLog("MSBT AssetBundle Load Process Running !!!!!!!", UnityEngine.LogType.Error);

            OnCompleteLoadAssetAction = null;
            OnCompleteLoadMsbtAction = null;
            bIsLoading = false;
        }

        public void RegistLoadCommonAssetBundleTask(string asssetBundleName)
        {
            AssetManager.AppendAssetBundleRequest(asssetBundleName, true, (requestEventType, name, asset) =>
            {
                if (requestEventType != RequestEventType.Activated)
                    return;

                MessageHelper.ExtractionLangNameByName(name);
                var msbtData = asset as MsbtData;

                var task = new LoadAssetBundleTask();
                task.fileName = name;
                task.msbtData = msbtData;
                OnCompleteLoadAssetAction?.Invoke(task);

            }, null);
        }

        public void RegistLoadAssetBundleTask(string asssetBundleName)
        {
            AssetManager.AppendAssetBundleRequest(asssetBundleName, true, (requestEventType, name, asset) =>
            {
                if (requestEventType != RequestEventType.Activated)
                    return;

                var msbtData = asset as MsbtData;

                var task = new LoadAssetBundleTask();
                task.fileName = name;
                task.msbtData = msbtData;
                OnCompleteLoadAssetAction?.Invoke(task);

            }, null);
        }

        public void RequestLoadAssetBundle(Action onFinishedLoadRequest)
        {
            bIsLoading = true;
            AssetManager.DispatchRequests((requestEventType, name, asset) =>
            {
                bIsLoading = false;
                onFinishedLoadRequest?.Invoke();
            });
        }
    }
}