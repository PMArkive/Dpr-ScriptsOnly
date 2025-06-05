using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;

namespace Dpr.Message
{
    public class FontAssetLoader
    {
        private List<LoadFontAssetTask> loadTaskList = new List<LoadFontAssetTask>();
        private int loadTaskCount;
        private bool bRunning;

        public void OnAwake()
        {
            loadTaskList.Clear();
            loadTaskCount = 0;
            bRunning = false;
        }

        public void OnFinalize()
        {
            Sequencer.update -= OnUpdate;

            for (int i=0; i<loadTaskList.Count; i++)
            {
                if (!loadTaskList[i].IsDone)
                    MessageHelper.EmitLog("Warning!! : Rest Running Load Task : " + loadTaskList[i].fileName, UnityEngine.LogType.Error);

                loadTaskList[i].Dispose();
            }

            loadTaskList.Clear();
            loadTaskList = null;
        }

        public bool RunningLoad { get => bRunning; }

        public bool HasLoadTaskByLanguageId(MessageEnumData.MsgLangId langId)
        {
            return loadTaskList.FindIndex(x => x.langId == langId) != -1;
        }

        public void RegistLoadFontAssetTask(MessageEnumData.MsgLangId langId, Action<LoadFontAssetTask> onCompleteLoad)
        {
            if (HasLoadTaskByLanguageId(langId))
            {
                MessageHelper.EmitLog(string.Format("Language [{0}] is Already Add LoadTask!!", langId));
            }
            else
            {
                var task = new LoadFontAssetTask();
                task.onCompleteLoadAct = onCompleteLoad;
                task.langId = langId;
                task.fileName = GetFileNameByLanguageId(langId);
                loadTaskList.Add(task);
                loadTaskCount++;
            }
        }

        private string GetFileNameByLanguageId(MessageEnumData.MsgLangId langId)
        {
            return MessageFontDataConstants.FONT_FILE_NAME_ARRAY[MessageFontDataConstants.FONT_FILE_TABLE[(int)langId]];
        }

        public void PerformLoad()
        {
            foreach (var task in loadTaskList)
            {
                if (!task.bRunning)
                {
                    task.bRunning = true;
                    task.operation = AssetManager.RequestAssetBundle("font/" + task.fileName, true, null, null);
                }
            }

            if (bRunning)
                return;

            bRunning = true;

            Sequencer.update -= OnUpdate;
            Sequencer.update += OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            for (int i=0; i<loadTaskList.Count; i++)
            {
                var task = loadTaskList[i];
                if (task.bRunning && task.IsDone)
                {
                    task.onCompleteLoadAct?.Invoke(task);
                    task.OnFinishedLoad();
                    loadTaskCount--;
                    break;
                }
            }

            if (loadTaskCount > 0)
                return;

            bRunning = false;

            Sequencer.update -= OnUpdate;
        }
    }
}