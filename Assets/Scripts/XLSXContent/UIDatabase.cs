using DPData;
using Pml;
using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class UIDatabase : ScriptableObject
    {
        public SheetUIWindow[] UIWindow;
        public SheetTransition[] Transition;
        public SheetSpriteAtlas[] SpriteAtlas;
        public SheetSharedSprite[] SharedSprite;
        public SheetCommonSprite[] CommonSprite;
        public SheetPokemonIcon[] PokemonIcon;
        public SheetAshiatoIcon[] AshiatoIcon;
        public SheetPokemonVoice[] PokemonVoice;
        public SheetMonsterBall[] MonsterBall;
        public SheetContextMenu[] ContextMenu;
        public SheetKeyguide[] Keyguide;
        public SheetCharacterBag[] CharacterBag;
        public SheetZukanDisplay[] ZukanDisplay;
        public SheetZukanComparePlayer[] ZukanComparePlayer;
        public SheetZukanCompareHeight[] ZukanCompareHeight;
        public SheetZukanCompareWeight[] ZukanCompareWeight;
        public SheetFloorDisplay[] FloorDisplay;
        public SheetShopMessage[] ShopMessage;
        public SheetPlaceMark[] PlaceMark;
        public SheetMarkColor[] MarkColor;
        public SheetWallpaper[] Wallpaper;
        public SheetBox[] Box;
        public SheetPokeColor[] PokeColor;
        public SheetDistributionMapchip[] DistributionMapchip;
        public SheetPolishedBadge[] PolishedBadge;
        public SheetSearchPokeIconSex[] SearchPokeIconSex;
        public SheetHideWazaName[] HideWazaName;
        public SheetHideTokusei[] HideTokusei;
        public SheetZukanRating[] ZukanRating;
        public SheetBoxOpenParam[] BoxOpenParam;
        public SheetSealTemplate[] SealTemplate;
        public SheetRankingDisplay[] RankingDisplay;

        public SheetUIWindow this[int index] => UIWindow[index];

        [Serializable]
        public class SheetUIWindow
        {
            public int WindowAnimId;
            public string AssetBundleName;
            public string AssetName;
            public bool Resident;
            public int UiCameraMode;
            public bool Firstload;
        }

        [Serializable]
        public class SheetTransition
        {
            public string AssetBundleName;
            public string AssetName;
        }

        [Serializable]
        public class SheetSpriteAtlas
        {
            public string AssetBundleName;
            public string AssetName;
            public bool Resident;
            public bool IsLanguage;
        }

        [Serializable]
        public class SheetSharedSprite
        {
            public string SpriteName;
        }

        [Serializable]
        public class SheetCommonSprite
        {
            public string SpriteName;
        }

        [Serializable]
        public class SheetPokemonIcon
        {
            public int UniqueID;
            public string AssetBundleName;
            public string AssetName;
            public string AssetBundleNameLarge;
            public string AssetNameLarge;
            public string AssetBundleNameDP;
            public string AssetNameDP;
            public Vector2 HallofFameOffset;
        }

        [Serializable]
        public class SheetAshiatoIcon
        {
            public int UniqueID;
            public string SideIconAssetName;
            public string BothIconAssetName;
        }

        [Serializable]
        public class SheetPokemonVoice
        {
            public int UniqueID;
            public string WwiseEvent;
            public string stopEventId;
            public Vector3 CenterPointOffset;
            public bool RotationLimits;
            public Vector2 RotationLimitAngle;
        }

        [Serializable]
        public class SheetMonsterBall
        {
            public BallId BallId;
            public ItemNo ItemNo;
        }

        [Serializable]
        public class SheetContextMenu
        {
            public string MessageFile;
            public string MessageLabel;
        }

        [Serializable]
        public class SheetKeyguide
        {
            public SharedSpriteID ButtonSpriteId;
            public string MessageFile;
            public string MessageLabel;
        }

        [Serializable]
        public class SheetCharacterBag
        {
            public int Index;
            public string XMenuDefault;
            public string XMenuSelect;
            public string XMenuShadow;
            public string BagHeader;
            public string BagBase;
            public string[] BagPockets;
        }

        [Serializable]
        public class SheetZukanDisplay
        {
            public int UniqueID;
            public Vector3 MoveLimit;
            public Vector3 ModelOffset;
            public Vector2 ModelRotationAngle;
        }

        [Serializable]
        public class SheetZukanComparePlayer
        {
            public bool Sex;
            public ushort Height;
            public ushort Weight;
        }

        [Serializable]
        public class SheetZukanCompareHeight
        {
            public int UniqueID;
            public float PlayerScaleFactor;
            public Vector3 PlayerOffset;
            public Vector2 PlayerRotationAngle;
        }

        [Serializable]
        public class SheetZukanCompareWeight
        {
            public int No;
            public ushort DiffMin;
            public ushort DiffMax;
        }

        [Serializable]
        public class SheetFloorDisplay
        {
            public string MessageFile;
            public string MessageLabel;
        }

        [Serializable]
        public class SheetShopMessage
        {
            public string[] Message0;
            public string[] Message1;
            public string[] Message2;
            public string[] Message3;
            public string[] Message4;
            public string[] Message5;
            public string[] Message6;
            public string[] Message7;
            public string[] Message8;
        }

        [Serializable]
        public class SheetPlaceMark
        {
            public string SpriteName;
            public int[] CassetVersions;
        }

        [Serializable]
        public class SheetMarkColor
        {
            public Color32 Color;
        }

        [Serializable]
        public class SheetWallpaper
        {
            public string MessageFile;
            public string MessageLabel;
            public Color32 Color;
        }

        [Serializable]
        public class SheetBox
        {
            public string MessageFile;
            public string MessageLabel;
            public WallpaperID Wallpaper;
        }

        [Serializable]
        public class SheetPokeColor
        {
            public Color32 Color;
        }

        [Serializable]
        public class SheetDistributionMapchip
        {
            public string SpriteName;
            public bool FlipX;
            public bool FlipY;
        }

        [Serializable]
        public class SheetPolishedBadge
        {
            public ushort Value;
        }

        [Serializable]
        public class SheetSearchPokeIconSex
        {
            public MonsNo MonsNo;
            public int Sex;
        }

        [Serializable]
        public class SheetHideWazaName
        {
            public string WazaID;
        }

        [Serializable]
        public class SheetHideTokusei
        {
            public string TokuseiID;
        }

        [Serializable]
        public class SheetZukanRating
        {
            public bool IsZenkokuZukan;
            public bool IsGetCount;
            public ZukanRatingConditionType OtherCondition;
            public ushort RatingMinCount;
            public ushort RatingMaxCount;
            public string MessageFile;
            public string MessageLabel1;
            public string MessageLabel2;
            public string MessageLabel3;
        }

        [Serializable]
        public class SheetBoxOpenParam
        {
            public int[] MonsNo;
            public int SelectCount;
            public int Level;
            public bool IsTrade;
            public bool IsEnableParty;
            public bool IsEnableDying;
        }

        [Serializable]
        public class SheetSealTemplate
        {
            public string MessageFile;
            public string TitleMessageLabel;
            public string NameMessageLabel;
            public string TrainerImageFile;
            public string TrainerEmblemFile;
        }

        [Serializable]
        public class SheetRankingDisplay
        {
            public int RankingId;
            public RECORD_ID RecordId;
            public int Category;
            public string RankingItem;
            public string Guide;
            public string Counter;
        }
    }
}