using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class CharcterAnimeTable : ScriptableObject
    {
        public Sheetcliplist[] cliplist;

        public Sheetcliplist this[int index] => cliplist[index];

        [Serializable]
        public class Sheetcliplist
        {
            public int clipindex;
            public CharcterAnimeEvent data;
        }
    }
}