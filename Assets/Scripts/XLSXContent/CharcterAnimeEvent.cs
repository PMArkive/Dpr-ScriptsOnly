using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class CharcterAnimeEvent : ScriptableObject
    {
        public SheetanimeEvent[] animeEvent;

        public SheetanimeEvent this[int index] => animeEvent[index];

        [Serializable]
        public class SheetanimeEvent
        {
            public int frame;
            public CharacterAnimEventMethod[] method;
            public int intparam;
        }
    }
}