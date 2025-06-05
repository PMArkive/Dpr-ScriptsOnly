using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MapInfo : ScriptableObject
    {
        public SheetZoneData[] ZoneData;
        public SheetCamera[] Camera;

        public SheetZoneData this[int index] => ZoneData[index];

        [Serializable]
        public class SheetZoneData
        {
	        public string Caption;
            public string MSLabel;
            public string PokePlaceName;
            public string FlyingPlaceName;
            public MapType MapType;
            public bool IsField;
            public int LandmarkType;
            public Vector2 MiniMapOffset;
            public bool Bicycle;
            public bool Escape;
            public bool Fly;
            public bool BattleSearcher;
            public bool TureAruki;
            public bool KuruKuru;
            public bool Fall;
            public ArenaID[] BattleBg;
            public ZoneID ZoneID;
            public AreaID AreaID;
            public ZoneTable ZoneGrid;
            public AttributeMatrix Attribute;
            public AttributeMatrix AttributeEx;
            public AttributeMatrix SubAttribute;
            public AttributeMatrix SubAttributeEx;
            public string[] BGM;
            public string EnvironmentalSound;
            public SYS_WEATHER Weather;
            public EnvironmentSettings RenderSettings;
            public bool ReflectionCamera;
            public bool FixedTime;
            public string AssetBundleName;
            public bool RoomPanCamera;
            public Vector4[] Locators;
            public bool Reload;
        }

        [Serializable]
        public class SheetCamera
        {
	        public AreaID ariaID;
            public float pitch;
            public float fov;
            public float targetRange;
            public float panDistance;
            public float panPitch;
            public float panFov;
            public bool panpos_useflag;
            public float panMinposY;
            public float panMaxposY;
            public float panMinposZ;
            public float panMaxposZ;
            public float defocusStart;
            public float defocusEnd;
            public float distance;
        }
    }
}