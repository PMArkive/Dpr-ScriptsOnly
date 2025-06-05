using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FieldWalkingPokeTalk : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public string ID;
            public string Motion;
            public string BaWaitMotion;
            public int PikaVoice;
            public int EevVoice;
            public int PokeVoice;
            public bool General;
            public int FriendshipMin;
            public int FriendshipMax;
            public int LifeRetioMin;
            public int LifeRetioMax;
            public int State;
            public int Type;
        }
    }
}