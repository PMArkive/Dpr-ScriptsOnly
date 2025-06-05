using System;
using AttributeData;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class BattleSetupEffectLots : ScriptableObject
    {
        public SheetAttEffTable[] AttEffTable;
        public SheetRuleEffTable[] RuleEffTable;
        public SheetArenaEffTable[] ArenaEffTable;

        public SheetAttEffTable this[int index] => AttEffTable[index];

        [Serializable]
        public class SheetAttEffTable
        {
            public MapAttributeEx AttributeEx;
            public ArenaID ArenaID;
            public EffectBattleID EffectID;
            public string SoundEventName;
        }

        [Serializable]
        public class SheetRuleEffTable
        {
            public BattleSetupEffectLot Rule;
            public BattleSetupEffectId BattleID;
        }

        [Serializable]
        public class SheetArenaEffTable
        {
            public ArenaID ArenaID;
            public EffectBattleID[] EffectID;
        }
    }
}