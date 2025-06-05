﻿using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class CharacterDressData : ScriptableObject
    {
        public SheetData[] Data;

        public SheetData this[int index] => Data[index];

        [Serializable]
        public class SheetData
        {
            public int Index;
            public string ID;
            public string BattleGraphic;
            public string FieldGraphic;
            public int Scale;
            public string MSLabel;
        }
    }
}