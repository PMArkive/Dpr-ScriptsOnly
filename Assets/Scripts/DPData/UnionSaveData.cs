namespace DPData
{
    public struct UnionSaveData
    {
        public bool initNpcTalk;
        public int penartyCounter;
        public float penartyTime;

        public bool IsInitTalk { get => initNpcTalk; }
        public int GetPenartyCounter { get => penartyCounter; }
        public float GetDateTime { get => penartyTime; }
    }
}