using DPData;
using Dpr.Message;
using Pml.PokePara;
using Pml;
using SmartPoint.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Dpr.EvScript;
using GameData;
using Dpr.Item;
using Dpr.Trainer;
using Dpr.Box;
using Dpr.UI;
using Dpr.BallDeco;
using Dpr.Contest;
using Dpr.GMS;
using Dpr.NetworkUtils;
using SmartPoint.AssetAssistant;
using System.Security.Cryptography;
using Dpr.Battle.Logic;

public class PlayerWork : PlayerPrefsProvider<PlayerWork>
{
    [SerializeField]
    private SaveData _saveData;

    protected override void Initialization()
    {
        _saveData.version = SaveData.CURRENT_VERSION;
        _saveData.intValues = new int[(int)EvWork.WORK_INDEX.SCWK_WK_SAVE_SIZE];
        _saveData.boolValues = new bool[(int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE];
        _saveData.systemFlags = new bool[(int)EvWork.SYSFLAG_INDEX.SYSFLAG_SAVE_SIZE];
        zoneID = ZoneID.UNKNOWN;
        rivalName = "ジュン";
        locatorIndex = (int)ZoneID.UNKNOWN;
        _saveData.timeScale = 1440.0f;
        RandomGroupWork.Init();
        _saveData.saveItem = new SaveItem[ItemInfo.ItemSaveSize];
        _saveData.saveUgItem = new SaveUgItem[UgItemInfo.ItemSaveSize];
        _saveData.saveItemShortcut = new ushort[ItemInfo.ItemShortcutSaveSize];
        _saveData.playerParty.Clear();
        _saveData.boxData.Clear();
        _saveData.boxTray = new SaveBoxTrayData[BoxPokemonWork.TRAY_MAX];
        for (int i = 0; i < _saveData.boxTray.Length; i++)
            _saveData.boxTray[i].Clear();
        BoxWork.SetTrayMax(BoxWork.TRAY_NUM_1ST);

        _saveData.playerData = default;
        _saveData.zukanData = default;
        ZukanWork.Reset();
        _saveData.tr_battleData = new TR_BATTLE_DATA[(int)TrainerID.MAX];
        TrainerWork.Reset();
        _saveData.topMenuData = TopMenuWork.Create();
        _saveData.fieldObj_Save = default;
        _saveData.fieldObj_Save.fldobj_sv = new FIELD_OBJ_SAVE_DATA[_FIELDOBJ_SAVE.MAX];
        _saveData.fieldGimmickSaveData.GearRotate = new int[3];
        _saveData.kinomiGrowSaveData.kinomiGrows = new KinomiGrow[KinomiGrowSaveData.KinomiGrowsCount];

        _saveData.ugSaveData.TalkedNPCsID = null;
        _saveData.ugSaveData.OtherPlayerList = null;
        _saveData.ugSaveData.FriendPlayerList = null;
        _saveData.ugSaveData.ugRecord = default;
        _saveData.ugSaveData.ReturnUgZoneID = (int)ZoneID.C01;
        _saveData.ugSaveData.EncountPokePositions = null;
        _saveData.ugSaveData.EncountPokes = null;
        _saveData.ugSaveData.DigPoints = null;
        _saveData.ugSaveData.ReturnZenmetsu_Ground = default;
        _saveData.ugSaveData.ReturnPosY = 0;
        _saveData.ugSaveData.ReturnGridPosX = 0;
        _saveData.ugSaveData.ReturnGridPosZ = 0;
        _saveData.ugSaveData.ReturnZoneID = (int)ZoneID.C01;
        _saveData.ugSaveData.EncountPokes = new SerializedPokemonFull[15];
        _saveData.ugSaveData.EncountPokePositions = new Vector3[15];
        _saveData.ugSaveData.ugRecord.myBase.ugStoneStatue = new UgStoneStatue[30];
        _saveData.ugSaveData.TalkedNPCsID = new byte[100];

        _saveData.poffinSaveData.CookingCount = 0;
        _saveData.poffinSaveData.Poffins = null;
        _saveData.poffinSaveData.Reset();

        EncountDataWork.Create();
        RecordWork.Create();
        ContestWork.ResetContestData();
        GMSWork.ResetGMSData();
        NetworkHelper.InitNetworkData();
        _saveData.ballDecoData.Clear();
        _saveData.saveSeal = new SaveSealData[BallDecoWork.SealSaveSize];

        ConfigWork.Initialize(ref _saveData.playerData.config);
        _saveData.player_save_data = new PLAYER_SAVE_DATA(0);
        BtlTowerWork.Create();
        NetworkManager.Reset();
        _saveData.poketchData = new POKETCH_DATA(0);
        _saveData.azukariyaData = default;
        _saveData.azukariyaData.Initialize();
        _saveData.badgeSaveData.Clear();
        _saveData.boukenNote = new BoukenNote(0);
        TvWork.Initialize();
        _saveData.dendoudata = new _DENDOU_SAVEDATA(0);
        _saveData.zukanPersonalRndData.Clear();
        _saveData.mysteryGiftSaveData.Clear();
        _saveData.mtData.Clear();
        _saveData.playReportData = default;
        POKETCH_POKETORE_COUNT_ARRAY.CreatePoketoreData();
        _saveData.dendouSaveAdd = new DENDOU_SAVE_ADD(0);
        _saveData.ballDecoExtraData.Clear();
    }

    // TODO
    private void ToBytes<T>(T obj, ref byte[] bytes) { }

    // TODO
    private void LoadBytes<T>(byte[] bytes, ref T obj) { }

    // TODO
    protected override bool CustomLoadOperation() { return false; }

    // TODO
    protected override bool CustomSaveOperation() { return false; }

    // TODO
    protected override bool CustomLoadAsyncOperation() { return false; }

    // TODO
    private void OnPostLoadAsync(bool result) { }

    // TODO
    protected override bool CustomSaveAsyncOperation() { return false; }

    // TODO
    protected override void OnPostLoad() { }

    // TODO
    private static void OnPostLoad_NeedMD() { }

    // TODO
    protected override void OnPreSave() { }

    // TODO
    public static void DataSave(bool isAsync = false, bool writeMain = true, bool writeBackup = false) { }

    // TODO
    public static void SaveAsync(bool writeMain = true, bool writeBackup = false) { }

    // TODO
    public static void DataLoad(bool isAsync = false, bool fromBackup = false) { }

    // TODO
    public static void LoadAsync(bool fromBackup = false) { }

    // TODO
    public static bool IsSaveSystemBusy() { return false; }

    // TODO
    public static bool ExistBackUpData() { return false; }

    public static int GetInt(EvWork.WORK_INDEX index)
    {
        return instance._saveData.intValues[(int)index];
    }

    public static void SetInt(EvWork.WORK_INDEX index, int value)
    {
        instance._saveData.intValues[(int)index] = value;
    }

    public static bool GetBool(EvWork.FLAG_INDEX index)
    {
        return instance._saveData.boolValues[(int)index];
    }

    public static void SetBool(EvWork.FLAG_INDEX index, bool value)
    {
        instance._saveData.boolValues[(int)index] = value;
    }

    public static bool GetSytemFlag(EvWork.SYSFLAG_INDEX index)
    {
        switch (index)
        {
            // System flags marked by software updates
            case EvWork.SYSFLAG_INDEX.SYS_FLAG_WILDCARD_000:
            case EvWork.SYSFLAG_INDEX.SYS_FLAG_WILDCARD_001:
            case EvWork.SYSFLAG_INDEX.SYS_FLAG_WILDCARD_002:
            case EvWork.SYSFLAG_INDEX.SYS_FLAG_WILDCARD_003:
                return true;

            default:
                return instance._saveData.systemFlags[(int)index];
        }
    }

    public static void SetSytemFlag(EvWork.SYSFLAG_INDEX index, bool value)
    {
        instance._saveData.systemFlags[(int)index] = value;
    }

    public static void SetTransitionZone(ZoneID zoneID, int index = 0)
    {
        transitionZoneID = zoneID;
        locatorIndex = index;
    }

    public static void SetWarp(WarpType warp)
    {
        LOCATION_WORK? GetLocationWork()
        {
            // Weird method, I think this is right
            switch (warp)
            {
                case WarpType.Zenmetsu:
                    return instance._saveData.player_save_data.worpPoint.zenmetu;

                case WarpType.Teleport:
                    return instance._saveData.player_save_data.worpPoint.teleport;

                case WarpType.Ananuke:
                    return instance._saveData.player_save_data.worpPoint.ananuke;

                default:
                    return null;
            }
        }

        instance._transitionLocation = GetLocationWork();
        if (!instance._transitionLocation.HasValue)
        {
            if (warp != WarpType.Teleport)
                return;
        }
        else
        {
            if (warp != WarpType.Teleport)
            {
                instance._transitionZoneID = (ZoneID)instance._transitionLocation.Value.zoneID;
                instance._locatorIndex = 0;
                return;
            }

            if (instance._transitionLocation.Value.dir < 1)
            {
                instance._transitionZoneID = (ZoneID)instance._transitionLocation.Value.zoneID;
                instance._locatorIndex = 0;
            }
            else
            {
                instance._transitionZoneID = (ZoneID)instance._transitionLocation.Value.zoneID;
                instance._locatorIndex = instance._transitionLocation.Value.dir;
            }
        }

        instance._transitionLocation = null;
    }

    // TODO
    public static void SetWarpSorawotobu(ZoneID zoneId, int locatorIndex) { }

    [NonSerialized]
    private ZoneID _transitionZoneID = ZoneID.UNKNOWN;
    [NonSerialized]
    private int _locatorIndex = -1;
    [NonSerialized]
    private LOCATION_WORK? _transitionLocation;
    [NonSerialized]
    private bool _isBattling;
    [NonSerialized]
    private bool _isContest;
    [NonSerialized]
    private bool _isSealPreview;
    [NonSerialized]
    private bool _isEvolveDemo;
    [NonSerialized]
    private bool _isHatchDemo;
    [NonSerialized]
    private bool _isMass;
    [NonSerialized]
    private bool _isEncount;
    [NonSerialized]
    private bool _isDigFossil;
    [NonSerialized]
    private bool _isGMS;
    [NonSerialized]
    private LoadResult _loadResult;
    [NonSerialized]
    private BATTLE_SETUP_PARAM _battleSetupParam = new BATTLE_SETUP_PARAM();
    [NonSerialized]
    private PokeParty _playerParty;
    [NonSerialized]
    private PokemonParam _capturedPokemon;
    [NonSerialized]
    private List<EvolveDemoTools.Param> _evolveRequets = new List<EvolveDemoTools.Param>();
    [NonSerialized]
    private byte[] _writeSrcBuffer = new byte[Marshal.SizeOf(typeof(SaveData))];
    [NonSerialized]
    private bool _isMainSave = true;
    [NonSerialized]
    private bool _isBackupSave;

    public static int playerID { get => instance._saveData.playerData.mystatus.sex ? 1 : 2; }
    public static string userName { get => instance._saveData.playerData.mystatus.name; set => instance._saveData.playerData.mystatus.name = value; }
    public static bool playerSex
    {
        get => instance._saveData.playerData.mystatus.sex;
        set
        {
            instance._saveData.playerData.mystatus.sex = value;
            FlagWork.SetFlag(EvWork.FLAG_INDEX.FE_MAN_WOMAN, !value);
            ItemWork.SetBagIconSex(value);
        }
    }
    public static MessageEnumData.GenderID playerGenderId { get => playerSex ? MessageEnumData.GenderID.Masculine : MessageEnumData.GenderID.Feminine; }
    public static int playerFashion { get => instance._saveData.playerData.mystatus.fashion; set => instance._saveData.playerData.mystatus.fashion = (byte)value; }
    public static string rivalName { get => instance._saveData.rivalName; set => instance._saveData.rivalName = value; }
    public static ZoneID zoneID { get => instance._saveData.zoneID; set => instance._saveData.zoneID = value; }
    public static bool NoSavePlayerPos { get; set; }

    // TODO
    public static void SetPlayerPosData(FieldPlayerEntity player) { }

    public static Vector2Int grid { get => instance._saveData.playerData.mystatus.grid; }
    public static float height { get => instance._saveData.playerData.mystatus.height; }
    public static float rotation { get => instance._saveData.playerData.mystatus.rotation; }

    public static void SetPlayerGrid(Vector2Int vec)
    {
        instance._saveData.playerData.mystatus.grid = vec;
    }

    // TODO
    public static void SetPlayerHeight(float height) { }

    // TODO
    public static void SetPlayerRotation(float rot) { }

    public static ZoneID transitionZoneID { get => instance._transitionZoneID; set => instance._transitionZoneID = value; }
    public static int locatorIndex { get => instance._locatorIndex; set => instance._locatorIndex = value; }
    public static LOCATION_WORK? transitionLocation { get => instance._transitionLocation; set => instance._transitionLocation = value; }
    public static bool isBattling { get => instance._isBattling; set => instance._isBattling = value; }
    public static bool isContest { get => instance._isContest; set => instance._isContest = value; }
    public static bool isSealPreview { get => instance._isSealPreview; set => instance._isSealPreview = value; }
    public static bool isEvolveDemo { get => instance._isEvolveDemo; set => instance._isEvolveDemo = value; }
    public static bool isHatchDemo { get => instance._isHatchDemo; set => instance._isHatchDemo = value; }
    public static bool isDigFossil { get => instance._isDigFossil; set => instance._isDigFossil = value; }
    public static bool isGMS { get => instance._isGMS; set => instance._isGMS = value; }
    public static bool isMass { get => instance._isMass; set => instance._isMass = value; }
    public static bool isEncount { get => instance._isEncount; set => instance._isEncount = value; }
    public static int colorID { get => instance._saveData.playerData.mystatus.body_type; set => instance._saveData.playerData.mystatus.body_type = (byte)value; }
    public static byte badge { get => instance._saveData.playerData.mystatus.badge; set => instance._saveData.playerData.mystatus.badge = value; }
    public static MessageEnumData.MsgLangId msgLangID
    {
        get => (MessageEnumData.MsgLangId)instance._saveData.playerData.config.msg_lang_id;
        set
        {
            instance._saveData.playerData.config.msg_lang_id = (int)value;
            instance._saveData.playerData.mystatus.region_code = (byte)value;
        }
    }
    public static int cassetVersion { get => instance._saveData.playerData.mystatus.rom_code == 0 ? CassetVersion.DPR_B : CassetVersion.DPR_S; set => instance._saveData.playerData.mystatus.rom_code = value != CassetVersion.DPR_B ? (byte)1 : (byte)0; }
    public static bool isKanji { get => instance._saveData.playerData.config.is_kanji; set => instance._saveData.playerData.config.is_kanji = value; }

    // TODO
    public static void SetMoney(int value) { }

    // TODO
    public static int GetMoney() { return 0; }

    public static BTLTOWER_SAVEWORK btlTowerSave { set => instance._saveData.btlTowerSave = value; get => instance._saveData.btlTowerSave; }

    public static void SetItem(int itemno, SaveItem value)
    {
        instance._saveData.saveItem[itemno] = value;
    }

    public static SaveItem GetItem(int itemno)
    {
        return instance._saveData.saveItem[itemno];
    }

    // TODO
    public static void SetUgItem(int ugItemNo, SaveUgItem value) { }

    // TODO
    public static SaveUgItem GetUgItem(int ugItemNo) { return default; }

    // TODO
    public static void SetItemShortcut(int id, ushort itemNo) { }

    // TODO
    public static ushort GetItemShortcut(int id) { return 0; }

    // TODO
    public static int GetItemShortcutId(ushort itemNo) { return 0; }

    // TODO
    public static int GetItemShortcutRegisteredCount() { return 0; }

    // TODO
    public static SaveBoxData GetBoxData() { return default; }

    // TODO
    public static SaveBoxTrayData GetBoxTray(int tray) { return default; }

    // TODO
    public static SaveBallDecoData GetBallDecoData() { return default; }

    // TODO
    public static SaveSealData GetSealData(int id) { return default; }

    // TODO
    public static SaveSealData SetSealData(int id, SaveSealData value) { return default; }

    // TODO
    public static SaveBallDecoExtraData GetBallDecoExtraData() { return default; }

    // TODO
    public static void SetFormNormal() { }

    // TODO
    public static bool IsFormNormal() { return false; }

    // TODO
    public static void SetFormBicycle() { }

    // TODO
    public static bool IsFormBicycle() { return false; }

    // TODO
    public static void SetFormSwim() { }

    // TODO
    public static bool IsFormSwim() { return false; }

    public static bool bicycleGear { get => instance._saveData.player_save_data.gear_type; set => instance._saveData.player_save_data.gear_type = value; }
    public static byte bicycleColor { get => instance._saveData.player_save_data.bic_color; set => instance._saveData.player_save_data.bic_color = value; }
    public static BATTLE_SETUP_PARAM battleSetupParam { get => instance._battleSetupParam; }
    public static PokeParty playerParty
    {
        get
        {
            if (instance._playerParty == null && DataManager.IsLoaded())
                instance._playerParty = new PokeParty();
            return instance._playerParty;
        }
    }
    public static PokemonParam capturedPokemon { get => instance._capturedPokemon; set => instance._capturedPokemon = value; }
    public static MonsNo capturedMonsNo { get; set; } = MonsNo.NULL;
    public static int capturedBallCountTvTopic { get; set; } = 0;
    public static List<EvolveDemoTools.Param> evolveRequets { get => instance._evolveRequets; }
    public static bool encountEnable { get; set; } = true;
    public static bool isDebugDash { get => false; }
    public static bool isDebugWalk { get; set; } = false;
    public static bool isDebugPlayerVisible { get; set; } = false;
    public static bool isDebugBattleTextView { get; set; }

    private static bool _isPlayerInputActive;
    public static bool _isPlayerInputActive_ContactEvent = true;
    public static bool IsFieldKuruKuruStart = false;
    public static bool IsFieldFallStart = false;
    public static bool IsToUg = false;
    public static bool IsFromUg = false;
    public static bool ReserveZoneChangeNaminoriEnd = false;

    public static ref PLAYER_DATA playerData { get => ref instance._saveData.playerData; }
    public static ref MYSTATUS playerStatus { get => ref instance._saveData.playerData.mystatus; }
    public static ref CONFIG config { get => ref instance._saveData.playerData.config; }
    public static ref CONTEST_DATA contestData { get => ref instance._saveData.playerData.contestdata; }
    public static ref CON_PHOTO_LANG_DATA contestPhotoLangData { get => ref instance._saveData.contstPhotoLangData; }
    public static ref CON_PHOTO_EXT_DATA[] contestPhotoExtData { get => ref instance._saveData.contestPhotoExtData; }
    public static ref GMS_DATA gmsData { get => ref instance._saveData.gmsdata; }
    public static ref GMS_POINT_HISTORY_EXT_DATA[] gmsExtData { get => ref instance._saveData.gmsPointExtData; }
    public static ref PLAYER_NETWORK_DATA networkData { get => ref instance._saveData.networkdata; }
    public static ZUKAN_WORK zukan { set => instance._saveData.zukanData = value; get => instance._saveData.zukanData; }
    public static bool isPlayerInputActive { set => _isPlayerInputActive = value; get => _isPlayerInputActive && _isPlayerInputActive_ContactEvent; }
    public static uint uniqueID { set => instance._saveData.playerData.mystatus.id = value; get => instance._saveData.playerData.mystatus.id; }
    public static DefaultPokeType defaultPokeType { set => instance._saveData.playerData.mystatus.defaultPokeType = value; get => instance._saveData.playerData.mystatus.defaultPokeType; }
    public static MonsNo defaultPokeNo
    {
        get
        {
            if (defaultPokeType == DefaultPokeType.KUSA)
                return MonsNo.NAETORU;
            else if (defaultPokeType == DefaultPokeType.MIZU)
                return MonsNo.POTTYAMA;
            else
                return MonsNo.HIKOZARU;
        }
    }
    public static DefaultPokeType rivalPokeType
    {
        get
        {
            if (defaultPokeType == DefaultPokeType.KUSA)
                return DefaultPokeType.HONOO;
            else if (defaultPokeType == DefaultPokeType.MIZU)
                return DefaultPokeType.KUSA;
            else
                return DefaultPokeType.MIZU;
        }
    }
    public static MonsNo rivalPokeNo
    {
        get
        {
            if (defaultPokeType == DefaultPokeType.KUSA)
                return MonsNo.HIKOZARU;
            else if (defaultPokeType == DefaultPokeType.MIZU)
                return MonsNo.NAETORU;
            else
                return MonsNo.POTTYAMA;
        }
    }
    public static DefaultPokeType supportPokeType
    {
        get
        {
            if (rivalPokeType == DefaultPokeType.KUSA)
                return DefaultPokeType.HONOO;
            else if (rivalPokeType == DefaultPokeType.MIZU)
                return DefaultPokeType.KUSA;
            else
                return DefaultPokeType.MIZU;
        }
    }
    public static MonsNo supportPokeNo
    {
        get
        {
            if (rivalPokeType == DefaultPokeType.KUSA)
                return MonsNo.HIKOZARU;
            else if (rivalPokeType == DefaultPokeType.MIZU)
                return MonsNo.NAETORU;
            else
                return MonsNo.POTTYAMA;
        }
    }

    // TODO
    public static bool GetGakusyuusoutiFlag() { return false; }

    // TODO
    public static uint GenerateUniqueId() { return 0; }

    public static TR_BATTLE_DATA[] tr_battleData { set => instance._saveData.tr_battleData = value; get => instance._saveData.tr_battleData; }
    public static TOPMENU_WORK topMenu { get => instance._saveData.topMenuData; set => instance._saveData.topMenuData = value; }

    // TODO
    public static void CreateAlpha1Party(PokeParty party) { }

    public static _FIELDOBJ_SAVE fieldObjSave { set => instance._saveData.fieldObj_Save = value; get => instance._saveData.fieldObj_Save; }
    public static RECORD_ARRAY record { set => instance._saveData.record = value; get => instance._saveData.record; }
    public static RECORD_ADD_DATA recordAddData { set => instance._saveData.recodeAddData = value; get => instance._saveData.recodeAddData; }

    // TODO
    public static void DebugResetWork() { }

    public static string FieldWorpLinkName { get; set; } = "";
    public static string FieldWorpLabel { get; set; } = "";
    public static bool isDebugNpcVisble { get; set; } = false;
    public static bool isDebugNpcPokeVisble { get; set; } = false;
    public static MonsNo DebugEncountMonsNo { get; set; } = MonsNo.NULL;
    public static SYS_WEATHER FieldWeather { get; set; } = SYS_WEATHER.SUNNY;
    public static ENC_SV_DATA Enc_SV_Data { set => instance._saveData.enc_sv_data = value; get => instance._saveData.enc_sv_data; }
    public static byte BtlSearcherCharge
    {
        set
        {
            instance._saveData.enc_sv_data.BtlSearcherCharge = value;
            if (instance._saveData.enc_sv_data.BtlSearcherCharge > 100)
                instance._saveData.enc_sv_data.BtlSearcherCharge = 100;
        }
        get => instance._saveData.enc_sv_data.BtlSearcherCharge;
    }
    public static int HoneyLastTreeIndex { set => instance._saveData.enc_sv_data.HoneyTree.TreeNo = (byte)value; get => instance._saveData.enc_sv_data.HoneyTree.TreeNo; }
    public static HONEY_DATA[] HoneyData { get => instance._saveData.enc_sv_data.HoneyTree.HoneyData; }
    public static long HoneyLastUpdateMinutes { get => instance._saveData.enc_sv_data.HoneyTree.LastUpdateMinutes; set => instance._saveData.enc_sv_data.HoneyTree.LastUpdateMinutes = value; }
    public static int WalkEncountCount { get => instance._saveData.enc_sv_data.encountWalkCount; set => instance._saveData.enc_sv_data.encountWalkCount = value; }
    public static PLAYER_SAVE_DATA PlayerSaveData { set => instance._saveData.player_save_data = value; get => instance._saveData.player_save_data; }
    public static float WalkCount { set => instance._saveData.player_save_data.walkcount = value; get => instance._saveData.player_save_data.walkcount; }
    public static DoubleSlot DoubleSlot { get => DoubleSlot.None; }
    public static _RANDOM_GROUP RandomGroup { set => instance._saveData.randomGroup = value; get => instance._saveData.randomGroup; }
    public static int[] GimmickGearRotate { set => instance._saveData.fieldGimmickSaveData.GearRotate = value; get => instance._saveData.fieldGimmickSaveData.GearRotate; }
    public static KinomiGrow[] KinomiGrows { get => instance._saveData.kinomiGrowSaveData.kinomiGrows; }
    public static long KinomiGrowLastUpdateMinutes { get => instance._saveData.kinomiGrowSaveData.LastUpdateMinutes; set => instance._saveData.kinomiGrowSaveData.LastUpdateMinutes = value; }
    public static DayOfWeek Week
    {
        get
        {
            if (DebugWeek >= 0 && DebugWeek < 7)
                return (DayOfWeek)DebugWeek;
            else
                return GameManager.nowTime.DayOfWeek;
        }
    }
    public static int DebugWeek { get; set; } = -1;

    public const int InputNormal = 0;
    public const int InputLR = 1;
    public const int InputUD = 2;
    public const int InputCross = 3;

    public static int FieldInputMode { get; set; } = InputNormal;

    public static void GetDateTime(out int year, out int month, out int day)
    {
        DateTime nowTime = GameManager.nowTime;
        year = nowTime.Year;
        month = nowTime.Month;
        day = nowTime.Day;
    }

    public static bool IsZenmetuFlag { get; set; } = false;
    public static bool IsNeedUnloadOnFieldConnector { get; set; } = false;
    public static WarpType Warp { get; set; } = WarpType.None;
    public static bool Telescope { get; set; } = false;
    public static bool TelescopeReturn { get; set; } = false;

    public static void SetPlayerStatus([Optional, DefaultParameterValue(4)] int selectIndex, [Optional] string name)
    {
        SetPlayerStatus(selectIndex < 4, selectIndex & 3, name);
    }

    public static void SetPlayerStatus(bool sex, int colorId, [Optional] string name)
    {
        int rnd;
        do
            rnd = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        while (rnd == 0);

        uniqueID = (uint)rnd;
        playerSex = sex;
        colorID = colorId;

        if (playerSex)
        {
            playerFashion = 0;
            if (string.IsNullOrEmpty(name))
                userName = "コウキ";
            else
                userName = name;
        }
        else
        {
            playerFashion = 100;
            if (string.IsNullOrEmpty(name))
                userName = "ヒカリ";
            else
                userName = name;
        }

        SystemTimeWork.SetStartTime();
        TvWork.MakeDailyTopic();
    }

    // TODO
    public static CON_PHOTO_DATA GetPhotoDataByCategoryID(CategoryID categoryID) { return default; }

    // TODO
    public static void SetPhotoDataByCategoryID(CategoryID categoryID, CON_PHOTO_DATA newData) { }

    // TODO
    public static MessageEnumData.MsgLangId GetPhotoLangIdByCategoryID(CategoryID categoryID) { return MessageEnumData.MsgLangId.JPN; }

    public static UgSaveData ugSaveData { get => instance._saveData.ugSaveData; set => instance._saveData.ugSaveData = value; }
    public static int ReturnZoneID { get => instance._saveData.ugSaveData.ReturnZoneID; set => instance._saveData.ugSaveData.ReturnZoneID = value; }
    public static int ReturnUgZoneID { get => instance._saveData.ugSaveData.ReturnUgZoneID; set => instance._saveData.ugSaveData.ReturnUgZoneID = value; }
    public static Vector3 UgReturnPos
    {
        get => new Vector3(instance._saveData.ugSaveData.ReturnGridPosX, instance._saveData.ugSaveData.ReturnPosY, instance._saveData.ugSaveData.ReturnGridPosZ);
        set
        {
            instance._saveData.ugSaveData.ReturnGridPosX = (int)value.x;
            instance._saveData.ugSaveData.ReturnPosY = (int)value.y;
            instance._saveData.ugSaveData.ReturnGridPosZ = (int)value.z;
        }
    }
    public static ref UGRecord UgRecord { get => ref instance._saveData.ugSaveData.ugRecord; }
    public static ref UgCountRecord UgCountRecord { get => ref instance._saveData.ugCountRecord; }
    public static PoffinSaveData poffinSaveData { get => instance._saveData.poffinSaveData; }
    public static int CookingCount { get => instance._saveData.poffinSaveData.CookingCount; set => instance._saveData.poffinSaveData.CookingCount = value; }
    public static bool FieldCacheFlag { get; set; } = false;
    public static int SafariBallNum { get; set; }
    public static int SafariStepCount { get; set; }
    public static List<MonsNo> SafariCaptureMonsNo { get; set; } = new List<MonsNo>();
    public static int IsCpuBoostMode { get; set; } = 3;
    public static ItemInfo UsedFieldItem { get; set; } = null;
    public static WazaNo UsedFieldWazaNo { get; set; } = WazaNo.NULL;
    public static int UsedFieldWazaTemotiNo { get; set; } = 0;
    public static bool Kiribarai { get => FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_KIRIBARAI); set => FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_KIRIBARAI, value); }
    public static bool Flash { get; set; }

    public static List<WazaNo> UsedFieldWazaInArea = new List<WazaNo>();

    public static SYSTEMDATA SystemData { get => instance._saveData.systemData; set => instance._saveData.systemData = value; }
    public static bool PoketchOpen { get; set; } = false;
    public static POKETCH_DATA PoketchData { get => instance._saveData.poketchData; set => instance._saveData.poketchData = value; }
    public static uint PoketchPedometer { get => instance._saveData.poketchData.pedometer; set => instance._saveData.poketchData.pedometer = value; }
    public static int TureWalkMemberIndex { get => instance._saveData.playerData.mystatus.turewalkMemberIndex; set => instance._saveData.playerData.mystatus.turewalkMemberIndex = value; }
    public static ref AzukariyaData AzukariyaData { get => ref instance._saveData.azukariyaData; }
    public static bool IsMovePokemon { get => MovePokemonIndex > -1; }
    public static int MovePokemonIndex { get; set; } = -1;
    public static bool IsD26Key { get; set; } = false;
    public static _DENDOU_SAVEDATA dendoudata { get => instance._saveData.dendoudata; set => instance._saveData.dendoudata = value; }
    public static BadgeSaveData BadgeData { get => instance._saveData.badgeSaveData; set => instance._saveData.badgeSaveData = value; }

    // TODO
    public static int GetTrainerRank() { return 0; }

    public static int natuki_walkcnt { set => instance._saveData.player_save_data.natuki_walkcnt = value; get => instance._saveData.player_save_data.natuki_walkcnt; }
    public static BoukenNote boukenNote { set => instance._saveData.boukenNote = value; get => instance._saveData.boukenNote; }
    public static TV_DATA tvData { set => instance._saveData.tvData = value; get => instance._saveData.tvData; }
    public static UnionSaveData unionSaveData { set => instance._saveData.unionSaveData = value; get => instance._saveData.unionSaveData; }
    public static MysteryGiftSaveData MysteryGiftData { get => instance._saveData.mysteryGiftSaveData; set => instance._saveData.mysteryGiftSaveData = value; }
    public static ZUKAN_PERSONAL_RND_DATA zukanPersonalRndData { set => instance._saveData.zukanPersonalRndData = value; get => instance._saveData.zukanPersonalRndData; }

    // TODO
    public static bool IsEasyInput() { return false; }

    public static POKETCH_POKETORE_COUNT_ARRAY poketoreCountArray { set => instance._saveData.poketoreCountArray = value; get => instance._saveData.poketoreCountArray; }
    public static DENDOU_SAVE_ADD dendouSaveAdd { set => instance._saveData.dendouSaveAdd = value; get => instance._saveData.dendouSaveAdd; }
    public static ReBuffnameData reBuffNameData { set => instance._saveData.reBuffNameData = value; get => instance._saveData.reBuffNameData; }

    // TODO
    public static bool VerifySaveData(byte[] byteArray) { return false; }

    private void makeSaveDataHash(ref byte[] buf)
    {
        var crypto = new MD5CryptoServiceProvider();
        Array.Clear(buf, SaveData.SAVEDATA_HASH_ADDR, SaveData.SAVEDATA_HASH_SIZE);

        var count = Marshal.SizeOf(typeof(SaveData));
        var hash = crypto.ComputeHash(buf, 0, count);
        Array.Copy(hash, 0, buf, SaveData.SAVEDATA_HASH_ADDR, SaveData.SAVEDATA_HASH_SIZE);

        crypto?.Dispose();
    }

    public static LoadResult GetLoadResult()
    {
        return instance._loadResult;
    }

    private static void TakeOverOldVersion()
    {
        var saveVersion = instance._saveData.version;

        if (saveVersion < SaveData.CURRENT_VERSION_24)
        {
            DendouiriWork.NicNameTakeOver();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_26)
        {
            RecordWork.CreateAddData();
            RecordWork.PatchLanguage();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_27)
        {
            ZukanWork.CheckLangFlags();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_28)
        {
            POKETCH_POKETORE_COUNT_ARRAY.CreatePoketoreData();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_29)
        {
            GMSWork.ResetGMSData();
            GC.Collect();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_2B)
        {
            DendouiriWork.UpdateSaveData_v2B();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_2E)
        {
            isNeedFixPokemonExp = true;
        }

        if (saveVersion < SaveData.CURRENT_VERSION_2F)
        {
            RecordWork.Sub(RECORD_ID.RECID_CAPTURE_POKE);
        }

        if (saveVersion < SaveData.CURRENT_VERSION_31)
        {
            BtlTowerWork.ResetBtlAve();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_32)
        {
            TvWork.Initialize();
        }

        if (saveVersion < SaveData.CURRENT_VERSION_34)
        {
            BallDecoWork.ResetBallDecoExtraData();
        }
    }

    public static bool IsAutoSaveSystemBusy()
    {
        return instance._autosaveCoroutineIsBusy || instance._autosaveWindowCoroutineIsBusy;
    }

    public static void AutoSave(bool mainsave, bool backup)
    {
        if (instance._autosaveCoroutineIsBusy)
            return;

        instance._autosaveCoroutineIsBusy = true;
        Sequencer.Start(AutoSaveCoroutine(mainsave, backup));
    }

    public static IEnumerator AutoSaveCoroutine(bool mainsave, bool backup)
    {
        while (IsSaveSystemBusy())
            yield return null;

        SaveAsync(mainsave, backup);

        if (mainsave && !instance._autosaveWindowCoroutineIsBusy)
        {
            instance._autosaveWindowCoroutineIsBusy = true;
            Sequencer.Start(instance.AutoSaveWindowAnime());
        }

        while (IsSaveSystemBusy())
            yield return null;

        instance._autosaveCoroutineIsBusy = false;
    }

    private IEnumerator AutoSaveWindowAnime()
    {
        if (Fader.fillPower > 0.5f)
            yield return null;

        if (_autosaveWindow == null)
        {
            _autosaveWindow = UIManager.Instance.CreateUIWindow<AutoSaveWindow>(UIWindowID.FIELD_AUTOSAVE);
            _autosaveWindow.Open(UIWindow.WINDOWID_FIELD);
        }

        var limit = DataManager.GetFieldCommonParam(FieldCommon.ParamIndx.AutoSaveMinTime);
        _autosaveWindowCloseOpenTime = 0.0f;

        while (limit > _autosaveWindowCloseOpenTime)
        {
            _autosaveWindowCloseOpenTime += Time.deltaTime;
            yield return null;
        }

        _autosaveWindow.Close(window =>
        {
            _autosaveWindow = null;
            _autosaveWindowCoroutineIsBusy = false;
        }, UIWindow.WINDOWID_FIELD);
    }

    private static void CheckMoveAfterSaveGrid(ref Vector2Int pos)
    {
        if (DataManager.MoveAfterSaveGrid == null)
            return;

        for (int i = 0; i < DataManager.MoveAfterSaveGrid.data.Length; i++)
        {
            var data = DataManager.MoveAfterSaveGrid[i];
            if (data.zoneID == zoneID)
            {
                if (pos.x == data.grid.x && pos.y == data.grid.y)
                {
                    pos.x = data.regrid.x;
                    pos.y = data.regrid.y;
                    return;
                }
            }
        }
    }

    public static bool IsMyPokemon(CoreParam poke)
    {
        bool validFast = poke.StartFastMode();

        bool result = uniqueID == poke.GetID() &&
                      (playerSex ? Sex.MALE : Sex.FEMALE) == poke.GetParentSex() &&
                      userName == poke.GetParentName();

        poke.EndFastMode(validFast);
        return result;
    }

    public static PLAYREPORT_DATA playReportData { set => instance._saveData.playReportData = value; get => instance._saveData.playReportData; }
    public static ref PLAYREPORT_DATA playReportDataRef { get => ref instance._saveData.playReportData; }

    private bool _autosaveCoroutineIsBusy;
    private bool _autosaveWindowCoroutineIsBusy;
    private AutoSaveWindow _autosaveWindow;
    private float _autosaveWindowCloseOpenTime;
    private static bool isNeedFixPokemonExp = false;

    public static void FixPokemonExpAll()
    {
        for (uint i=0; i<playerParty.GetMemberCount(); i++)
            FixPokemonExp(playerParty.GetMemberPointer(i));

        var param = new PokemonParam();
        for (int i=0; i<BoxWork.TRAY_MAX; i++)
        {
            for (int j=0; j<BoxWork.TRAY_POKE_MAX; j++)
            {
                BoxPokemonWork.GetPokemon(param, i, j);
                if (FixPokemonExp(param))
                    BoxPokemonWork.UpdatePokemon(param, i, j);
            }
        }

        var azukariya = AzukariyaData;
        if (azukariya.pokemonParam.Length < 1)
            return;

        for (uint i=0; i<azukariya.pokemonParam.Length; i++)
        {
            param.Deserialize_Full(azukariya.pokemonParam[i]);
            if (FixPokemonExp(param))
                param.Serialize_Full(ref azukariya.pokemonParam[i]);
        }
    }

    private static bool FixPokemonExp(PokemonParam pp)
    {
        if (pp == null)
            return false;

        bool validFast = pp.StartFastMode();
        bool isNull = pp.IsNull();
        if (!isNull)
        {
            var currentExp = pp.GetExp();
            pp.SetExp(currentExp);
            var newExp = pp.GetExp();

            pp.EndFastMode(validFast);
            return !isNull && currentExp != newExp;
        }
        else
        {
            pp.EndFastMode(validFast);
            return false;
        }
    }

    private static void CheckDameTamago()
    {
        for (uint i=0; i<playerParty.GetMemberCount(); i++)
        {
            var member = playerParty.GetMemberPointer(i);
            if (member.IsNull())
                member.GetAccessor().SetFuseiTamagoFlag(true);
        }
    }

    public enum LoadResult : int
    {
        SUCCESS = 0,
	    NOT_EXIST = 1,
        CORRUPTED = 2,
        FAILED = 3,
    }

    [Serializable]
    public struct SaveData
    {
        public const int CURRENT_VERSION_1C = 28;
        public const int CURRENT_VERSION_20 = 32;
        public const int CURRENT_VERSION_21 = 33;
        public const int CURRENT_VERSION_22 = 34;
        public const int CURRENT_VERSION_23 = 35;
        public const int CURRENT_VERSION_24 = 36;
        public const int CURRENT_VERSION_25 = 37;
        public const int CURRENT_VERSION_26 = 38;
        public const int CURRENT_VERSION_27 = 39;
        public const int CURRENT_VERSION_28 = 40;
        public const int CURRENT_VERSION_29 = 41;
        public const int CURRENT_VERSION_2A = 42;
        public const int CURRENT_VERSION_2B = 43;
        public const int CURRENT_VERSION_2C = 44;
        public const int CURRENT_VERSION_2D = 45;
        public const int CURRENT_VERSION_2E = 46;
        public const int CURRENT_VERSION_2F = 47;
        public const int CURRENT_VERSION_30 = 48;
        public const int CURRENT_VERSION_31 = 49;
        public const int CURRENT_VERSION_32 = 50;
        public const int CURRENT_VERSION_33 = 51;
        public const int CURRENT_VERSION_34 = 52;
        public const int CURRENT_VERSION = 52;
        public const int LAUNCH_VERSION = 37;
        public static readonly int[] BINARY_SIZE = new int[16]
        {
            956456, 957416, 971096, 971144, 971144, 972416, 973856, 973856,
            973856, 973856, 973856, 973856, 973856, 978316, 978316, 979108,
        };
        public const int SAVEDATA_HASH_ADDR = 956440;
        public const int SAVEDATA_HASH_SIZE = 16;
        public const int GMS_WORK_ADDR = 643132;
        public const int GMS_WORK_SIZE = 201476;

        public int version;
        public int[] intValues;
        public bool[] boolValues;
        public bool[] systemFlags;
        public string rivalName;
        public ZoneID zoneID;
        public float timeScale;
        public SaveItem[] saveItem;
        public SaveUgItem[] saveUgItem;
        public ushort[] saveItemShortcut;
        public SavePokeParty playerParty;
        public SaveBoxData boxData;
        [SerializeField]
        public SaveBoxTrayData[] boxTray;
        public PLAYER_DATA playerData;
        public ZUKAN_WORK zukanData;
        public TR_BATTLE_DATA[] tr_battleData;
        public TOPMENU_WORK topMenuData;
        public _FIELDOBJ_SAVE fieldObj_Save;
        public RECORD_ARRAY record;
        public ENC_SV_DATA enc_sv_data;
        public PLAYER_SAVE_DATA player_save_data;
        public SaveBallDecoData ballDecoData;
        public SaveSealData[] saveSeal;
        public _RANDOM_GROUP randomGroup;
        public FieldGimmickSaveData fieldGimmickSaveData;
        public KinomiGrowSaveData kinomiGrowSaveData;
        public PoffinSaveData poffinSaveData;
        public BTLTOWER_SAVEWORK btlTowerSave;
        public SYSTEMDATA systemData;
        public POKETCH_DATA poketchData;
        public AzukariyaData azukariyaData;
        public _DENDOU_SAVEDATA dendoudata;
        public BadgeSaveData badgeSaveData;
        public BoukenNote boukenNote;
        public byte[] tvDataOld;
        public UgSaveData ugSaveData;
        public GMS_DATA gmsdata;
        public PLAYER_NETWORK_DATA networkdata;
        public UnionSaveData unionSaveData;
        public CON_PHOTO_LANG_DATA contstPhotoLangData;
        public ZUKAN_PERSONAL_RND_DATA zukanPersonalRndData;
        public CON_PHOTO_EXT_DATA[] contestPhotoExtData;
        public GMS_POINT_HISTORY_EXT_DATA[] gmsPointExtData;
        public UgCountRecord ugCountRecord;
        public ReBuffnameData reBuffNameData;
        public byte[] saveDataHash;
        public RECORD_ADD_DATA recodeAddData;
        public MysteryGiftSaveData mysteryGiftSaveData;
        public POKETCH_POKETORE_COUNT_ARRAY poketoreCountArray;
        public PLAYREPORT_DATA playReportData;
        public MT_DATA mtData;
        public DENDOU_SAVE_ADD dendouSaveAdd;
        public TV_DATA tvData;
        public SaveBallDecoExtraData ballDecoExtraData;
    }

    public enum WarpType : int
    {
         None = 0,
         Zenmetsu = 1,
         Teleport = 2,
         Ananuke = 3,
         Sorawotobu = 4,
    }
}