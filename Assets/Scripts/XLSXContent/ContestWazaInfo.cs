using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class ContestWazaInfo : ScriptableObject
    {
        public SheetContestWazaData[] ContestWazaData;

        public SheetContestWazaData this[int index] => ContestWazaData[index];

        [Serializable]
        public class SheetContestWazaData
        {
            public bool valid_flag;
            public ushort id;
            public int wazaType;
            public int appealPoint;
            public int value1;
            public int value2;
            public string labelName;
        }
    }
}