using System;

namespace Dpr.Box
{
    [Serializable]
    public struct SaveBoxData
    {
        public _STR17[] trayName;
        public _STR11[] teamName;
        public ushort[] teamPos;
        public byte teamLock;
        public byte trayMax;
        public byte currentTray;
        public bool isOpened;
        public byte[] wallPaper;
        public ushort statusPut;

        // TODO
        public void Clear() { }

        [Serializable]
        public struct _STR17
        {
            public string str;
        }

        [Serializable]
        public struct _STR11
        {
            public string str;
        }
    }
}