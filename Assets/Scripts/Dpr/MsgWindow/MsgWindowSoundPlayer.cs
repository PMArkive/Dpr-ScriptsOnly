using Audio;
using Dpr.Message;
using System.Collections.Generic;

namespace Dpr.MsgWindow
{
    public class MsgWindowSoundPlayer
    {
        private Dictionary<int, uint> soundDataTablePtr;
        private bool bIsPlaying;
        private bool bWaiting;

        public void Setup(MsgWindowDataContainer dataContainer)
        {
            soundDataTablePtr = dataContainer.SoundTagDataTable;
        }

        public bool WaitFinishSE { get => bWaiting; }

        public void Reset()
        {
            bIsPlaying = false;
            bWaiting = false;
        }

        public void PlayDecideSE()
        {
            AudioManager.Instance.CreateSe(AK.EVENTS.UI_COMMON_DECIDE, 0).Play(null, false);
        }

        public void PerformCallbackOne(float value)
        {
            if (value > 1.0f)
            {
                if (soundDataTablePtr.ContainsKey((int)value))
                {
                    PlayCallbackSE(soundDataTablePtr[(int)value]);
                    return;
                }

                MessageHelper.EmitLog(string.Format("CallbackOne Tag Value is not found!!!!!!!! : {0}", value), UnityEngine.LogType.Error);
            }

            if (bIsPlaying)
                bWaiting = true;
        }

        private void PlayCallbackSE(uint eventId)
        {
            if (bIsPlaying)
                MessageHelper.EmitLog("SE Playing!!!", UnityEngine.LogType.Warning);

            AudioManager.Instance.CreateSe(eventId, 0).Play(OnFinishCallbackSEPlay, false);
            bIsPlaying = true;
        }

        private void OnFinishCallbackSEPlay(AudioInstance seInstance)
        {
            bIsPlaying = false;
            bWaiting = false;
        }
    }
}