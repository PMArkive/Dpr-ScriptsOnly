using System;

namespace DPData
{
    [Serializable]
    public struct TV_DATA
    {
        public TV_RECORD UseRecord;
        public TV_RECORD MyRecord;
        public TV_TOPIC UseTopic;
        public TV_TOPIC MyTopic;
        public INTERVIEWER_DATA InterviewerData;
        public int TvWatchCount;
    }
}