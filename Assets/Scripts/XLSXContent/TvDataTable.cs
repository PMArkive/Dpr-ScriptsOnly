using Dpr.EvScript;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class TvDataTable : ScriptableObject
    {
        public Sheetdata[] data;
        public Sheetmix_record[] mix_record;

        public Sheetdata this[int index] => data[index];

        [Serializable]
        public class Sheetdata
        {
	        public int TpicID;
            public int ProgramID;
            public int Channel;
            public EvWork.SYSFLAG_INDEX BroadCastOpenFlag;
            public string ReadScript;
            public int SetCRT;
            public EvWork.FLAG_INDEX StandFlag;
        }

        [Serializable]
        public class Sheetmix_record
        {
	        public int MixIndex;
            public int MixTpicID;
            public int MixStrIndex;
            public int MixIntIndex1;
            public int MixIntIndex2;
            public int MixBranchIndex;
        }
    }
}