using SmartPoint.AssetAssistant;
using System;

namespace Audio
{
    public class AudioData : RefCounted
    {
        public string _bankName;
        public uint _bankId;
        public LoadState _loadState;

        public override int Release()
        {
            int baseResult = base.Release();

            if (baseResult == 0)
            {
                _loadState = LoadState.Unloading;
                AkSoundEngine.UnloadBank(_bankId, IntPtr.Zero,
                    (bankId_, bankPtr, result, data) =>
                        AudioManager._Unload(this),
                    this);
            }

            return baseResult;
        }

        public enum LoadState : int
        {
            None = 0,
            Loading = 1,
            Loaded = 2,
            Unloading = 3,
        }
    }
}
