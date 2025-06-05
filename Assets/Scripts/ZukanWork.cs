using DPData;
using Dpr.Message;
using Pml.PokePara;
using Pml;

public static class ZukanWork
{
    public static int[] ShinouZukanNos = new int[151]
    {
        (int)MonsNo.NAETORU,    (int)MonsNo.HAYASIGAME, (int)MonsNo.DODAITOSU,  (int)MonsNo.HIKOZARU,   (int)MonsNo.MOUKAZARU,
        (int)MonsNo.GOUKAZARU,  (int)MonsNo.POTTYAMA,   (int)MonsNo.POTTAISI,   (int)MonsNo.ENPERUTO,   (int)MonsNo.MUKKURU,
        (int)MonsNo.MUKUBAADO,  (int)MonsNo.MUKUHOOKU,  (int)MonsNo.BIPPA,      (int)MonsNo.BIIDARU,    (int)MonsNo.KOROBOOSI,
        (int)MonsNo.KOROTOKKU,  (int)MonsNo.KORINKU,    (int)MonsNo.RUKUSIO,    (int)MonsNo.RENTORAA,   (int)MonsNo.KEESHI,
        (int)MonsNo.YUNGERAA,   (int)MonsNo.HUUDHIN,    (int)MonsNo.KOIKINGU,   (int)MonsNo.GYARADOSU,  (int)MonsNo.SUBOMII,
        (int)MonsNo.ROZERIA,    (int)MonsNo.ROZUREIDO,  (int)MonsNo.ZUBATTO,    (int)MonsNo.GORUBATTO,  (int)MonsNo.KUROBATTO,
        (int)MonsNo.ISITUBUTE,  (int)MonsNo.GOROON,     (int)MonsNo.GOROONYA,   (int)MonsNo.IWAAKU,     (int)MonsNo.HAGANEERU,
        (int)MonsNo.ZUGAIDOSU,  (int)MonsNo.RAMUPARUDO, (int)MonsNo.TATETOPUSU, (int)MonsNo.TORIDEPUSU, (int)MonsNo.WANRIKII,
        (int)MonsNo.GOORIKII,   (int)MonsNo.KAIRIKII,   (int)MonsNo.KODAKKU,    (int)MonsNo.GORUDAKKU,  (int)MonsNo.MINOMUTTI,
        (int)MonsNo.MINOMADAMU, (int)MonsNo.GAAMEIRU,   (int)MonsNo.KEMUSSO,    (int)MonsNo.KARASARISU, (int)MonsNo.AGEHANTO,
        (int)MonsNo.MAYURUDO,   (int)MonsNo.DOKUKEIRU,  (int)MonsNo.MITUHANII,  (int)MonsNo.BIIKUIN,    (int)MonsNo.PATIRISU,
        (int)MonsNo.BUIZERU,    (int)MonsNo.HUROOZERU,  (int)MonsNo.THERINBO,   (int)MonsNo.THERIMU,    (int)MonsNo.KARANAKUSI,
        (int)MonsNo.TORITODON,  (int)MonsNo.HERAKUROSU, (int)MonsNo.EIPAMU,     (int)MonsNo.ETEBOOSU,   (int)MonsNo.HUWANTE,
        (int)MonsNo.HUWARAIDO,  (int)MonsNo.MIMIRORU,   (int)MonsNo.MIMIROPPU,  (int)MonsNo.GOOSU,      (int)MonsNo.GOOSUTO,
        (int)MonsNo.GENGAA,     (int)MonsNo.MUUMA,      (int)MonsNo.MUUMAAZI,   (int)MonsNo.YAMIKARASU, (int)MonsNo.DONKARASU,
        (int)MonsNo.NYARUMAA,   (int)MonsNo.BUNYATTO,   (int)MonsNo.TOSAKINTO,  (int)MonsNo.AZUMAOU,    (int)MonsNo.DOZYOTTI,
        (int)MonsNo.NAMAZUN,    (int)MonsNo.RIISYAN,    (int)MonsNo.TIRIIN,     (int)MonsNo.SUKANPUU,   (int)MonsNo.SUKATANKU,
        (int)MonsNo.ASANAN,     (int)MonsNo.TYAAREMU,   (int)MonsNo.DOOMIRAA,   (int)MonsNo.DOOTAKUN,   (int)MonsNo.PONIITA,
        (int)MonsNo.GYAROPPU,   (int)MonsNo.USOHATI,    (int)MonsNo.USOKKII,    (int)MonsNo.MANENE,     (int)MonsNo.BARIYAADO,
        (int)MonsNo.PINPUKU,    (int)MonsNo.RAKKII,     (int)MonsNo.HAPINASU,   (int)MonsNo.PHI,        (int)MonsNo.PIPPI,
        (int)MonsNo.PIKUSII,    (int)MonsNo.PERAPPU,    (int)MonsNo.PITYUU,     (int)MonsNo.PIKATYUU,   (int)MonsNo.RAITYUU,
        (int)MonsNo.HOOHOO,     (int)MonsNo.YORUNOZUKU, (int)MonsNo.MIKARUGE,   (int)MonsNo.HUKAMARU,   (int)MonsNo.GABAITO,
        (int)MonsNo.GABURIASU,  (int)MonsNo.GONBE,      (int)MonsNo.KABIGON,    (int)MonsNo.ANNOON,     (int)MonsNo.RIORU,
        (int)MonsNo.RUKARIO,    (int)MonsNo.UPAA,       (int)MonsNo.NUOO,       (int)MonsNo.KYAMOME,    (int)MonsNo.PERIPPAA,
        (int)MonsNo.KIRINRIKI,  (int)MonsNo.HIPOPOTASU, (int)MonsNo.KABARUDON,  (int)MonsNo.RURIRI,     (int)MonsNo.MARIRU,
        (int)MonsNo.MARIRURI,   (int)MonsNo.SUKORUPI,   (int)MonsNo.DORAPION,   (int)MonsNo.GUREGGURU,  (int)MonsNo.DOKUROGGU,
        (int)MonsNo.MASUKIPPA,  (int)MonsNo.TEPPOUO,    (int)MonsNo.OKUTAN,     (int)MonsNo.KEIKOUO,    (int)MonsNo.NEORANTO,
        (int)MonsNo.MENOKURAGE, (int)MonsNo.DOKUKURAGE, (int)MonsNo.HINBASU,    (int)MonsNo.MIROKAROSU, (int)MonsNo.TAMANTA,
        (int)MonsNo.MANTAIN,    (int)MonsNo.YUKIKABURI, (int)MonsNo.YUKINOOO,   (int)MonsNo.NYUURA,     (int)MonsNo.MANYUURA,
        (int)MonsNo.YUKUSII,    (int)MonsNo.EMURITTO,   (int)MonsNo.AGUNOMU,    (int)MonsNo.DHIARUGA,   (int)MonsNo.PARUKIA,
        (int)MonsNo.MANAFI,
    };
    private static int[] ShinouZukanCompSeeExcludeNos = new int[1] { (int)MonsNo.MANAFI };
    private static int[] ZenkokuZukanCompGetExcludeNos = new int[11]
    {
        (int)MonsNo.MYUU,      (int)MonsNo.RUGIA, (int)MonsNo.HOUOU,  (int)MonsNo.SEREBHI,  (int)MonsNo.ZIRAATI,
        (int)MonsNo.DEOKISISU, (int)MonsNo.FIONE, (int)MonsNo.MANAFI, (int)MonsNo.DAAKURAI, (int)MonsNo.SHEIMI,
        (int)MonsNo.ARUSEUSU,
    };
    private static int[] ZukanRatingExcludeNos = new int[9]
    {
        (int)MonsNo.MYUU,   (int)MonsNo.SEREBHI,  (int)MonsNo.ZIRAATI, (int)MonsNo.DEOKISISU, (int)MonsNo.FIONE,
        (int)MonsNo.MANAFI, (int)MonsNo.DAAKURAI, (int)MonsNo.SHEIMI,  (int)MonsNo.ARUSEUSU,
    };
    private const uint No_Unknown = 201;
    private const uint No_Powarun = 351;
    private const uint No_Deokisisu = 386;
    private const uint No_Mino = 412;
    private const uint No_MinoManadam = 413;
    private const uint No_Gaameiru = 414;
    private const uint No_Therimu = 421;
    private const uint No_Karanakusi = 422;
    private const uint No_Toritodon = 423;
    private const uint No_Rotom = 479;
    private const uint No_Girathina = 487;
    private const uint No_Sheimi = 492;
    private const uint No_Aruseusu = 493;
    private static ZUKAN_SORT_TYPE zukanSortType = 0;
    private static int[] viewModelUniqueIDs = new int[(int)MonsNo.END];
    public static int ListIndex = 0;
    public static float ListScrollPosition = 0.0f;
    public static int SelectLanguageIndex = 0;
    public static bool IsShowFootPrintBoth = false;
    public static bool IsShowDescription = false;
    public static bool IsShowShinouZukan = false;

    // TODO
    public static void Reset() { }

    // TODO
    public static void ZukanON() { }

    // TODO
    public static void ZenkokuON() { }

    // TODO
    public static void ZenkokuReset() { }

    // TODO
    public static bool GetZenkokuFlag() { return false; }

    // TODO
    public static int GetCount(bool isRating = false) { return 0; }

    // TODO
    public static int GetSinouCount(bool isRating = false) { return 0; }

    // TODO
    public static int SeeCount(bool isRating = false) { return 0; }

    // TODO
    public static int SeeSinouCount(bool isRating = false) { return 0; }

    // TODO
    public static void SetPoke(uint monsno, GET_STATUS get, Sex sex, int form, bool color) { }

    // TODO
    public static void SetPoke(PokemonParam mons, GET_STATUS get) { }

    // TODO
    public static bool IsGet(uint monsno) { return false; }

    // TODO
    public static bool IsSee(uint monsno) { return false; }

    // TODO
    public static bool IsUwasa(uint monsno) { return false; }

    // TODO
    public static GET_STATUS GetStatus(uint monsno) { return GET_STATUS.NONE; }

    // TODO
    public static bool IsGet(uint monsno, Sex sex, int form, bool color) { return false; }

    // TODO
    public static ZUKAN_SORT_TYPE GetSortType() { return ZUKAN_SORT_TYPE.NUMBER; }

    // TODO
    public static void SetSortType(ZUKAN_SORT_TYPE sortType) { }

    // TODO
    public static int GetViewModelUniqueID(uint monsno) { return 0; }

    // TODO
    public static void SetViewModelUniqueID(uint monsno, int uniqueID) { }

    // TODO
    public static void IncrementBattleCount(uint no, bool isCaptured) { }

    // TODO
    public static bool CheckShinouZukanCompSee() { return false; }

    // TODO
    public static bool CheckZenkokuZukanCompGet() { return false; }

    public static ZUKAN_WORK work { get => PlayerWork.zukan; }

    // TODO
    public static bool IsLangFlag(uint monsno, MessageEnumData.MsgLangId msglang) { return false; }

    // TODO
    public static void AddLangFlag(uint monsno, MessageEnumData.MsgLangId msglang) { }

    // TODO
    public static uint GetPersonalRnd(MonsNo monsNo, Sex sex, ushort formNo, bool isRare) { return 0; }

    // TODO
    public static void CheckLangFlags() { }

    // TODO
    private static void UpdatePersonalRnd(PokemonParam pokemonParam, GET_STATUS get) { }

    // TODO
    private static int GetPersonalRndIndex(Sex sex, ushort formNo, bool isRare) { return 0; }

    // TODO
    private static bool[] GetFormFlags(uint monsno, Sex sex, bool color) { return null; }

    // TODO
    public static void DebugSet(uint monsno, GET_STATUS get, Sex sex, int form, bool color, bool isGet) { }

    // TODO
    public static void DebugSetLangFlag(uint monsno, MessageEnumData.MsgLangId msglang, bool flag) { }

    // TODO
    public static int GetZukanNo(PokemonParam pokemonParam) { return 0; }
}