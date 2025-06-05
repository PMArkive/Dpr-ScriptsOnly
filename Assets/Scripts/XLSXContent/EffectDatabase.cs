using Effect;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class EffectDatabase : ScriptableObject
    {
        public SheetFieldEffectData[] FieldEffectData;
        public SheetBattleEffectData[] BattleEffectData;
        public SheetContestEffectData[] ContestEffectData;
        public SheetMenuEffetData[] MenuEffetData;

        public SheetFieldEffectData this[int index] => FieldEffectData[index];

        [Serializable]
        public class SheetFieldEffectData : EffectManager.FieldLoadParam { }

        [Serializable]
        public class SheetBattleEffectData : EffectManager.LoadParam { }

        [Serializable]
        public class SheetContestEffectData: EffectManager.LoadParam { }

        [Serializable]
        public class SheetMenuEffetData: EffectManager.LoadParam { }
    }
}