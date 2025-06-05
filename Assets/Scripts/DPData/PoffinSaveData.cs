using System;

namespace DPData
{
    [Serializable]
    public struct PoffinSaveData
    {
        public PoffinData[] Poffins;
        public int CookingCount;

        // TODO
        public void Reset() { }

        // TODO
        public bool AddPoffin(PoffinData poffin) { return false; }

        // TODO
        public void SortPoffin() { }

        // TODO
        public bool DelPoffin(PoffinData poffin) { return false; }

        // TODO
        public void _DebugFull(int mod = 1) { }

        // TODO
        public void SetNewFlag(PoffinData poffin, bool newFlag) { }

        // TODO
        public bool isHavePoffin() { return false; }

        // TODO
        private int GetPoffinNum() { return 0; }

        // TODO
        public PoffinData GetPoffin(int index) { return default; }

        // TODO
        public PoffinData[] GetHavePoffins() { return null; }

        // TODO
        public bool isCanMakePoffin() { return false; }
    }
}