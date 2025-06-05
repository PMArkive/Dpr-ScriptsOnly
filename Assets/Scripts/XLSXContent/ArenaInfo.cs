using Dpr.Battle.View;
using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class ArenaInfo : ScriptableObject
    {
        public SheetArenaData[] ArenaData;

        public SheetArenaData this[int index] => ArenaData[index];

        [Serializable]
		public class SheetArenaData
		{
            public string Caption;
            public ArenaID ArenaID;
            public string GroundAssetBundleName;
            public string SkyAssetBundleName;
            public EnvironmentSettings RenderSettings;
            public bool EnableDarkBall;
            public byte MinomuttiFormNo;
            public WazaNo SizennotikaraWazaNo;
            public EffectBattleID FootEffectID;
            public JointName AttachJoint;
            public int ReflectionResolution;
            public int ShadowResolution;
            public bool IsIndoor;
        }
	}
}