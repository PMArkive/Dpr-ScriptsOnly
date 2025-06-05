using Pml.Battle;
using Pml.PokePara;
using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic.Handler
{
    public static class Item
    {
        private const int FALSE = 0;
        private const int TRUE = 1;
        public const int WORKIDX_TMP_FLAG = 6;
        private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
        {
            new GET_FUNC_TABLE_ELEM(ItemNo.KURABONOMI, ADD_KuraboNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KAGONOMI, ADD_KagoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.TIIGONOMI, ADD_ChigoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.NANASINOMI, ADD_NanasiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.MOMONNOMI, ADD_MomonNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KIINOMI, ADD_KiiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.RAMUNOMI, ADD_RamNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.HIMERINOMI, ADD_HimeriNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.ORENNOMI, ADD_OrenNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KINOMIZYUUSU, ADD_KinomiJuice),
            new GET_FUNC_TABLE_ELEM(ItemNo.OBONNOMI, ADD_ObonNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.FIRANOMI, ADD_FiraNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.UINOMI, ADD_UiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.MAGONOMI, ADD_MagoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.BANZINOMI, ADD_BanziNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.IANOMI, ADD_IaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.TIIRANOMI, ADD_TiiraNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.RYUGANOMI, ADD_RyugaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KAMURANOMI, ADD_KamuraNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.YATAPINOMI, ADD_YatapiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZUANOMI, ADD_ZuaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SANNOMI, ADD_SanNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SUTAANOMI, ADD_SutaaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.NAZONOMI, ADD_NazoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.OKKANOMI, ADD_OkkaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.ITOKENOMI, ADD_ItokeNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SOKUNONOMI, ADD_SokunoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.RINDONOMI, ADD_RindoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.YATHENOMI, ADD_YacheNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.YOPUNOMI, ADD_YopuNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.BIAANOMI, ADD_BiarNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SYUKANOMI, ADD_SyukaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.BAKOUNOMI, ADD_BakouNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.UTANNOMI, ADD_UtanNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.TANGANOMI, ADD_TangaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.YOROGINOMI, ADD_YorogiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KASIBUNOMI, ADD_KasibuNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.HABANNOMI, ADD_HabanNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.NAMONOMI, ADD_NamoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.RIRIBANOMI, ADD_RiribaNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.HOZUNOMI, ADD_HozuNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.IBANNOMI, ADD_IbanNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.MIKURUNOMI, ADD_MikuruNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZYAPONOMI, ADD_JapoNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.RENBUNOMI, ADD_RenbuNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIROIHAABU, ADD_SiroiHerb),
            new GET_FUNC_TABLE_ELEM(ItemNo.MENTARUHAABU, ADD_MentalHerb),
            new GET_FUNC_TABLE_ELEM(ItemNo.KARABURIHOKEN, ADD_KaraburiHoken),
            new GET_FUNC_TABLE_ELEM(ItemNo.HIKARINOKONA, ADD_HikarinoKona),
            new GET_FUNC_TABLE_ELEM(ItemNo.KYOUSEIGIPUSU, ADD_KyouseiGipusu),
            new GET_FUNC_TABLE_ELEM(ItemNo.SENSEINOTUME, ADD_SenseiNoTume),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOUKOUNOSIPPO, ADD_KoukouNoSippo),
            new GET_FUNC_TABLE_ELEM(ItemNo.MANPUKUOKOU, ADD_KoukouNoSippo),
            new GET_FUNC_TABLE_ELEM(ItemNo.OUZYANOSIRUSI, ADD_OujaNoSirusi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SURUDOITUME, ADD_PintLens),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOUKAKURENZU, ADD_KoukakuLens),
            new GET_FUNC_TABLE_ELEM(ItemNo.PINTORENZU, ADD_PintLens),
            new GET_FUNC_TABLE_ELEM(ItemNo.FOOKASURENZU, ADD_FocusLens),
            new GET_FUNC_TABLE_ELEM(ItemNo.NONKINOOKOU, ADD_NonkiNoOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.TIKARANOHATIMAKI, ADD_ChikaraNoHachimaki),
            new GET_FUNC_TABLE_ELEM(ItemNo.MONOSIRIMEGANE, ADD_MonosiriMegane),
            new GET_FUNC_TABLE_ELEM(ItemNo.SINKAINOKIBA, ADD_SinkaiNoKiba),
            new GET_FUNC_TABLE_ELEM(ItemNo.SINKAINOUROKO, ADD_SinkaiNoUroko),
            new GET_FUNC_TABLE_ELEM(ItemNo.METARUPAUDAA, ADD_MetalPowder),
            new GET_FUNC_TABLE_ELEM(ItemNo.SUPIIDOPAUDAA, ADD_SpeedPowder),
            new GET_FUNC_TABLE_ELEM(ItemNo.DENKIDAMA, ADD_DenkiDama),
            new GET_FUNC_TABLE_ELEM(ItemNo.RAKKIIPANTI, ADD_LuckyPunch),
            new GET_FUNC_TABLE_ELEM(ItemNo.NAGANEGI, ADD_Naganegi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOKORONOSIZUKU, ADD_KokoroNoSizuku),
            new GET_FUNC_TABLE_ELEM(ItemNo.HUTOIHONE, ADD_FutoiHone),
            new GET_FUNC_TABLE_ELEM(ItemNo.KODAWARIHATIMAKI, ADD_KodawariHachimaki),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUROIHEDORO, ADD_KuroiHedoro),
            new GET_FUNC_TABLE_ELEM(ItemNo.KODAWARIMEGANE, ADD_KodawariMegane),
            new GET_FUNC_TABLE_ELEM(ItemNo.KODAWARISUKAAHU, ADD_KodawariScarf),
            new GET_FUNC_TABLE_ELEM(ItemNo.GINNOKONA, ADD_GinNoKona),
            new GET_FUNC_TABLE_ELEM(ItemNo.YAWARAKAISUNA, ADD_YawarakaiSuna),
            new GET_FUNC_TABLE_ELEM(ItemNo.KATAIISI, ADD_KataiIsi),
            new GET_FUNC_TABLE_ELEM(ItemNo.KISEKINOTANE, ADD_KisekiNoTane),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUROIMEGANE, ADD_KuroiMegane),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUROOBI, ADD_Kuroobi),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZISYAKU, ADD_Zisyaku),
            new GET_FUNC_TABLE_ELEM(ItemNo.METARUKOOTO, ADD_MetalCoat),
            new GET_FUNC_TABLE_ELEM(ItemNo.SINPINOSIZUKU, ADD_SinpiNoSizuku),
            new GET_FUNC_TABLE_ELEM(ItemNo.SURUDOIKUTIBASI, ADD_SurudoiKutibasi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SURUDOIKIBA, ADD_SurudoiKiba),
            new GET_FUNC_TABLE_ELEM(ItemNo.DOKUBARI, ADD_Dokubari),
            new GET_FUNC_TABLE_ELEM(ItemNo.TOKENAIKOORI, ADD_TokenaiKoori),
            new GET_FUNC_TABLE_ELEM(ItemNo.NOROINOOHUDA, ADD_NoroiNoOfuda),
            new GET_FUNC_TABLE_ELEM(ItemNo.MAGATTASUPUUN, ADD_MagattaSupuun),
            new GET_FUNC_TABLE_ELEM(ItemNo.MOKUTAN, ADD_Mokutan),
            new GET_FUNC_TABLE_ELEM(ItemNo.RYUUNOKIBA, ADD_RyuunoKiba),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIRUKUNOSUKAAHU, ADD_SirukuNoSukaafu),
            new GET_FUNC_TABLE_ELEM(ItemNo.AYASIIOKOU, ADD_AyasiiOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.GANSEKIOKOU, ADD_GansekiOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.SAZANAMINOOKOU, ADD_SazanamiNoOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.USIONOOKOU, ADD_UsioNoOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.OHANANOOKOU, ADD_OhanaNoOkou),
            new GET_FUNC_TABLE_ELEM(ItemNo.KIAINOTASUKI, ADD_KiaiNoTasuki),
            new GET_FUNC_TABLE_ELEM(ItemNo.KIAINOHATIMAKI, ADD_KiaiNoHachimaki),
            new GET_FUNC_TABLE_ELEM(ItemNo.TATUZINNOOBI, ADD_TatsujinNoObi),
            new GET_FUNC_TABLE_ELEM(ItemNo.INOTINOTAMA, ADD_InochiNoTama),
            new GET_FUNC_TABLE_ELEM(ItemNo.METORONOOMU, ADD_MetroNome),
            new GET_FUNC_TABLE_ELEM(ItemNo.NEBARINOKAGIDUME, ADD_NebariNoKagidume),
            new GET_FUNC_TABLE_ELEM(ItemNo.KAIGARANOSUZU, ADD_KaigaraNoSuzu),
            new GET_FUNC_TABLE_ELEM(ItemNo.HIKARINONENDO, ADD_HikariNoNendo),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAHURUHAABU, ADD_PowefulHarb),
            new GET_FUNC_TABLE_ELEM(ItemNo.TABENOKOSI, ADD_Tabenokosi),
            new GET_FUNC_TABLE_ELEM(ItemNo.DOKUDOKUDAMA, ADD_DokudokuDama),
            new GET_FUNC_TABLE_ELEM(ItemNo.KAENDAMA, ADD_KaenDama),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIRATAMA, ADD_Siratama),
            new GET_FUNC_TABLE_ELEM(ItemNo.KONGOUDAMA, ADD_Kongoudama),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUROITEKKYUU, ADD_KuroiTekkyuu),
            new GET_FUNC_TABLE_ELEM(ItemNo.AKAIITO, ADD_AkaiIto),
            new GET_FUNC_TABLE_ELEM(ItemNo.TUMETAIIWA, ADD_TumetaiIwa),
            new GET_FUNC_TABLE_ELEM(ItemNo.SARASARAIWA, ADD_SarasaraIwa),
            new GET_FUNC_TABLE_ELEM(ItemNo.ATUIIWA, ADD_AtuiIwa),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIMETTAIWA, ADD_SimettaIwa),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUTTUKIBARI, ADD_KuttukiBari),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAARISUTO, ADD_PowerWrist),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAABERUTO, ADD_PowerBelt),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAARENZU, ADD_PowerLens),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAABANDO, ADD_PowerBand),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAAANKURU, ADD_PowerAnkle),
            new GET_FUNC_TABLE_ELEM(ItemNo.PAWAAUEITO, ADD_PowerWeight),
            new GET_FUNC_TABLE_ELEM(ItemNo.HINOTAMAPUREETO, ADD_HinotamaPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIZUKUPUREETO, ADD_SizukuPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.IKAZUTIPUREETO, ADD_IkazutiPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.MIDORINOPUREETO, ADD_MirodinoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.TURARANOPUREETO, ADD_TuraranoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOBUSINOPUREETO, ADD_KobusinoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.MOUDOKUPUREETO, ADD_MoudokuPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.DAITINOPUREETO, ADD_DaitinoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.AOZORAPUREETO, ADD_AozoraPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.HUSIGINOPUREETO, ADD_HusiginoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.TAMAMUSIPUREETO, ADD_TamamusiPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.GANSEKIPUREETO, ADD_GansekiPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.MONONOKEPUREETO, ADD_MononokePlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.RYUUNOPUREETO, ADD_RyuunoPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOWAMOTEPUREETO, ADD_KowamotePlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOUTETUPUREETO, ADD_KoutetsuPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.SEIREIPUREETO, ADD_SeireiPlate),
            new GET_FUNC_TABLE_ELEM(ItemNo.OOKINANEKKO, ADD_OokinaNekko),
            new GET_FUNC_TABLE_ELEM(ItemNo.KEMURIDAMA, ADD_Kemuridama),
            new GET_FUNC_TABLE_ELEM(ItemNo.OMAMORIKOBAN, ADD_OmamoriKoban),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOUUNNOOKOU, ADD_OmamoriKoban),
            new GET_FUNC_TABLE_ELEM(ItemNo.HAKKINDAMA, ADD_HakkinDama),
            new GET_FUNC_TABLE_ELEM(ItemNo.KARUISI, ADD_Karuisi),
            new GET_FUNC_TABLE_ELEM(ItemNo.SINKANOKISEKI, ADD_SinkanoKiseki),
            new GET_FUNC_TABLE_ELEM(ItemNo.GOTUGOTUMETTO, ADD_GotugotuMet),
            new GET_FUNC_TABLE_ELEM(ItemNo.HUUSEN, ADD_Huusen),
            new GET_FUNC_TABLE_ELEM(ItemNo.REDDOKAADO, ADD_RedCard),
            new GET_FUNC_TABLE_ELEM(ItemNo.NERAINOMATO, ADD_NerainoMato),
            new GET_FUNC_TABLE_ELEM(ItemNo.SIMETUKEBANDO, ADD_SimetukeBand),
            new GET_FUNC_TABLE_ELEM(ItemNo.KYUUKON, ADD_Kyuukon),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZYUUDENTI, ADD_Juudenti),
            new GET_FUNC_TABLE_ELEM(ItemNo.NODOAME, ADD_NodoAme),
            new GET_FUNC_TABLE_ELEM(ItemNo.DASSYUTUBOTAN, ADD_DassyutuButton),
            new GET_FUNC_TABLE_ELEM(ItemNo.DASSYUTUPAKKU, ADD_DassyutuPack),
            new GET_FUNC_TABLE_ELEM(ItemNo.HONOONOZYUERU, ADD_HonooNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.MIZUNOZYUERU, ADD_MizuNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.DENKINOZYUERU, ADD_DenkiNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.KUSANOZYUERU, ADD_KusaNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.KOORINOZYUERU, ADD_KooriNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.KAKUTOUZYUERU, ADD_KakutouJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.DOKUNOZYUERU, ADD_DokuNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZIMENNOZYUERU, ADD_JimenNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.HIKOUNOZYUERU, ADD_HikouNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.ESUPAAZYUERU, ADD_EsperJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.MUSINOZYUERU, ADD_MusiNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.IWANOZYUERU, ADD_IwaNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.GOOSUTOZYUERU, ADD_GhostJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.DORAGONZYUERU, ADD_DragonJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.AKUNOZYUERU, ADD_AkuNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.HAGANENOZYUERU, ADD_HaganeNoJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.NOOMARUZYUERU, ADD_NormalJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.TOTUGEKITYOKKI, ADD_TotugekiChokki),
            new GET_FUNC_TABLE_ELEM(ItemNo.ZYAKUTENHOKEN, ADD_JyakutenHoken),
            new GET_FUNC_TABLE_ELEM(ItemNo.HIKARIGOKE, ADD_HikariGoke),
            new GET_FUNC_TABLE_ELEM(ItemNo.ROZERUNOMI, ADD_RozeruNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.TARAPUNOMI, ADD_TarapuNoMi),
            new GET_FUNC_TABLE_ELEM(ItemNo.AKKINOMI, ADD_AkkiNomi),
            new GET_FUNC_TABLE_ELEM(ItemNo.BOUZINGOOGURU, ADD_BoujinGoggle),
            new GET_FUNC_TABLE_ELEM(ItemNo.BANNOUGASA, ADD_BannouGasa),
            new GET_FUNC_TABLE_ELEM(ItemNo.YUKIDAMA, ADD_Yukidama),
            new GET_FUNC_TABLE_ELEM(ItemNo.YOUSEIZYUERU, ADD_YouseiJuel),
            new GET_FUNC_TABLE_ELEM(ItemNo.AIIRONOTAMA, ADD_Aiironotama),
            new GET_FUNC_TABLE_ELEM(ItemNo.BENIIRONOTAMA, ADD_Beniironotama),
            new GET_FUNC_TABLE_ELEM(ItemNo.GURANDOKOOTO, ADD_GroundCoat),
            new GET_FUNC_TABLE_ELEM(ItemNo.BIBIRIDAMA, ADD_Bibiridama),
            new GET_FUNC_TABLE_ELEM(ItemNo.EREKISIIDO, ADD_ElecSeed),
            new GET_FUNC_TABLE_ELEM(ItemNo.SAIKOSIIDO, ADD_PhychoSeed),
            new GET_FUNC_TABLE_ELEM(ItemNo.MISUTOSIIDO, ADD_MistSeed),
            new GET_FUNC_TABLE_ELEM(ItemNo.GURASUSIIDO, ADD_GrassSeed),
            new GET_FUNC_TABLE_ELEM(ItemNo.RUUMUSAABISU, ADD_RoomService),
            new GET_FUNC_TABLE_ELEM(ItemNo.BOUGOPATTO, ADD_BougoPad),
            new GET_FUNC_TABLE_ELEM(ItemNo.ATUZOKOBUUTU, ADD_AtuzokoBoots),
            new GET_FUNC_TABLE_ELEM(ItemNo.DUMMY_DATA, null),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuraboNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_KuraboNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_KuraboNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_KuraboNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KuraboNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_KuraboNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KagoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_KagoNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_KagoNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_KagoNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KagoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_KagoNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ChigoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_ChigoNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_ChigoNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_ChigoNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_ChigoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_ChigoNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NanasiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_NanasiNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_NanasiNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_NanasiNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_NanasiNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_NanasiNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MomonNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MomonNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_MomonNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MomonNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_MomonNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_MomonNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KiiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_KiiNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_KiiNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_KiiNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KiiNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_KiiNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RamNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_RamNomi),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_RamNomi),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_RamNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_RamNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_RamNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HimeriNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_HimeriNomi_wazaEnd),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_HimeriNomi_reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_HimeriNomi_get),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_FIXED, handler_HimeriNomi_get),
            new EventFactor.EventHandlerTable(EventID.DECREMENT_PP_DONE, handler_HimeriNomi_ppDec),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_HimeriNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_HimeriNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OrenNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_OrenNomi_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_OrenNomi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_OrenNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_OrenNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KinomiJuice = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_OrenNomi_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_OrenNomi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KinomiJuce_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ObonNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_OrenNomi_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_OrenNomi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_ObonNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_ObonNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TarapuNoMi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_TarapuNoMi_Reaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_TarapuNoMi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_TarapuNoMi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FiraNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_common_KaifukuKonran_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_common_KaifukuKonran_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_FiraNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_FiraNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_common_KaifukuKonran_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_common_KaifukuKonran_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_UiNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_UiNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_common_KaifukuKonran_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_common_KaifukuKonran_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_MagoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_MagoNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BanziNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_common_KaifukuKonran_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_common_KaifukuKonran_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_BanjiNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_BanjiNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_common_KaifukuKonran_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_common_KaifukuKonran_MemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_IaNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_IaNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TiiraNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_TiiraNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_TiiraNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RyugaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_RyugaNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_RyugaNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KamuraNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KamuraNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_KamuraNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YatapiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_YatapiNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_YatapiNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZuaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_ZuaNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_ZuaNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SanNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_SanNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_SanNomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SutaaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PinchReactCommon),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PinchReactMemberIn),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_SutaaNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_SutaaNomi),
        };
        private static readonly WazaRankEffect[] rankTypeTbl = new WazaRankEffect[]
        {
            WazaRankEffect.ATTACK,
            WazaRankEffect.DEFENCE,
            WazaRankEffect.SP_ATTACK,
            WazaRankEffect.SP_DEFENCE,
            WazaRankEffect.AGILITY,
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NazoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_NazoNomi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_NazoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_NazoNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OkkaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_OkkaNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ItokeNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_ItokeNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SokunoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_SokunoNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RindoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_RindoNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YacheNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_YacheNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YopuNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_YopuNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BiarNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_BiarNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SyukaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_SyukaNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BakouNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_BakouNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UtanNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_UtanNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TangaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_TangaNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YorogiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_YorogiNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KasibuNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_KasibuNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HabanNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_HabanNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NamoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_NamoNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RiribaNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_RiribaNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HozuNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_HozuNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RozeruNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_RozeruNomi),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_common_WeakAff_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IbanNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_SP_PRIORITY, handler_IbanNomi_SpPriorityCheck),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_IbanNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MikuruNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_MikuruNomi_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MikuruNomi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MikuruNomi_ActProcEnd),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_MikuruNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_MikuruNomi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JapoNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_JapoNomi_Damage),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_JapoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RenbuNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_RenbuNomi_Damage),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_JapoNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_common_Kinomi_UseTmp_OnlyConsume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TotugekiChokki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_totugekiChokki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JyakutenHoken = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_JyakutenHoken_Damage),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_JyakutenHoken_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SiroiHerb = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_SiroiHerb_Reaction),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_COMP, handler_SiroiHerb_MemberInComp),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_SiroiHerb_ActEnd),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_SiroiHerb_TurnCheck),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_SiroiHerb_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_SiroiHerb_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MentalHerb = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_MentalHerb_React),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MentalHerb_React),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_MentalHerb_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_MentalHerb_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KaraburiHoken = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_AVOID, handler_KaraburiHoken_Avoid),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_KaraburiHoken_Done),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KaraburiHoken_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikarinoKona = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_HikarinoKona),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KyouseiGipusu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_KyouseiGipusu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SenseiNoTume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_SP_PRIORITY, handler_SenseiNoTume_SpPriorityCheck),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_SenseiNoTume_Use),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_DONE, handler_SenseiNoTume_TurnCheckDone),
        };
        private const int WIDX_SENSEINOTUME_RAND_CHECK_DONE = 0;
        private const int WIDX_SENSEINOTUME_RAND_CHECK_CLEAR = 1;
        private const int WIDX_SENSEINOTUME_USE_DONE = 2;
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KoukouNoSippo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_SP_PRIORITY, handler_KoukouNoSippo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OujaNoSirusi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_OujaNoSirusi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_OujaNoSirusi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SurudoiKiba = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_OujaNoSirusi),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_OujaNoSirusi_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KoukakuLens = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_KoukakuLens),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PintLens = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_PintLens),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_LuckyPunch = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_LuckyPunch),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Naganegi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_Naganegi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FocusLens = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_FocusLens),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NonkiNoOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_NonkiNoOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ChikaraNoHachimaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_ChikaraNoHachimaki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MonosiriMegane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MonosiriMegane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinkaiNoKiba = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_SinkaiNoKiba),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinkaiNoUroko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_SinkaiNoUroko),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MetalPowder = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_MetalPowder),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SpeedPowder = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_SpeedPowder),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FutoiHone = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_FutoiHone),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KodawariHachimaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_CALL_DECIDE, handler_Kodawari_Common_WazaExe),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_DECIDE, handler_Kodawari_Common_ItemChange),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_KodawariHachimaki_Pow),
            new EventFactor.EventHandlerTable(EventID.CHECK_KODAWARI_FACTOR, handler_Kodawari_Common_Check),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KodawariMegane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_CALL_DECIDE, handler_Kodawari_Common_WazaExe),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_DECIDE, handler_Kodawari_Common_ItemChange),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_KodawariMegane_Pow),
            new EventFactor.EventHandlerTable(EventID.CHECK_KODAWARI_FACTOR, handler_Kodawari_Common_Check),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KodawariScarf = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_CALL_DECIDE, handler_Kodawari_Common_WazaExe),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_DECIDE, handler_Kodawari_Common_ItemChange),
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_KodawariScarf),
            new EventFactor.EventHandlerTable(EventID.CHECK_KODAWARI_FACTOR, handler_Kodawari_Common_Check),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KiaiNoTasuki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.KORAERU_CHECK, handler_KiaiNoTasuki_Check),
            new EventFactor.EventHandlerTable(EventID.KORAERU_EXE, handler_KiaiNoTasuki_Exe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KiaiNoHachimaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.KORAERU_CHECK, handler_KiaiNoHachimaki_Check),
            new EventFactor.EventHandlerTable(EventID.KORAERU_EXE, handler_KiaiNoHachimaki_Exe),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_KiaiNoHachimaki_UseItem),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TatsujinNoObi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_TatsujinNoObi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_InochiNoTama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L2, handler_InochiNoTama_Reaction),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_InochiNoTama_Damage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MetroNome = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_MetroNome),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NebariNoKagidume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASICK_PARAM, handler_NebariNoKagidume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KaigaraNoSuzu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L2, handler_KaigaraNoSuzu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikariNoNendo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_SIDEEFF_PARAM, handler_HikariNoNendo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowefulHarb = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_TAMETURN_SKIP, handler_PowefulHarb_CheckTameSkip),
            new EventFactor.EventHandlerTable(EventID.TAME_SKIP, handler_PowefulHarb_FixTameSkip),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_PowefulHarb_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tabenokosi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Tabenokosi_Reaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_Tabenokosi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuroiHedoro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_KuroiHedoro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AkaiIto = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASICK_FIXED, handler_AkaiIto),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuttukiBari = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_KuttukiBari_DamageReaction),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_KuttukiBari_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerWrist = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerBelt = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerLens = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerBand = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerAnkle = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerWeight = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_PowerXXX_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HinotamaPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Mokutan),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SizukuPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SinpiNoSizuku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IkazutiPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Zisyaku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MirodinoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KisekiNoTane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TuraranoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_TokenaiKoori),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KobusinoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Kuroobi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MoudokuPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Dokubari),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DaitinoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_YawarakaiSuna),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AozoraPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SurudoiKutibasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HusiginoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MagattaSupuun),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TamamusiPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_GinNoKona),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GansekiPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KataiIsi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MononokePlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_NoroiNoOfuda),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RyuunoPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_RyuunoKiba),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KowamotePlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KuroiMegane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KoutetsuPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MetalCoat),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SeireiPlate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SeireiPlate),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OokinaNekko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_DRAIN, handler_OokinaNekko),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kemuridama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SKIP_NIGERU_CALC, handler_Kemuridama),
            new EventFactor.EventHandlerTable(EventID.NIGERU_EXMSG, handler_Kemuridama_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OmamoriKoban = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_OmamoriKoban),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HakkinDama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_HakkinDama),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TumetaiIwa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_WEATHER_TURNCNT, handler_TumetaiIwa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SarasaraIwa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_WEATHER_TURNCNT, handler_SarasaraIwa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AtuiIwa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_WEATHER_TURNCNT, handler_AtuiIwa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SimettaIwa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_WEATHER_TURNCNT, handler_SimettaIwa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenkiDama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_DenkiDama),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_DenkiDama_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DokudokuDama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_DokudokuDama),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_DokudokuDama_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KaenDama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_KaenDama),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_KaenDama_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GinNoKona = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_GinNoKona),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YawarakaiSuna = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_YawarakaiSuna),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KataiIsi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KataiIsi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KisekiNoTane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KisekiNoTane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuroiMegane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KuroiMegane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kuroobi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Kuroobi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zisyaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Zisyaku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MetalCoat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MetalCoat),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinpiNoSizuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SinpiNoSizuku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SurudoiKutibasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SurudoiKutibasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubari = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Dokubari),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_Dokubari_UseTmp),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TokenaiKoori = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_TokenaiKoori),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NoroiNoOfuda = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_NoroiNoOfuda),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagattaSupuun = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MagattaSupuun),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mokutan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Mokutan),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RyuunoKiba = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_RyuunoKiba),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SirukuNoSukaafu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SirukuNoSukaafu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AyasiiOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_AyasiiOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GansekiOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_GansekiOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SazanamiNoOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SazanamiNoOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UsioNoOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_UsioNoOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OhanaNoOkou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_OhanaNoOkou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KokoroNoSizuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KokoroNoSizuku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Siratama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Siratama),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kongoudama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Kongoudama),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuroiTekkyuu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_KuroiTekkyuu_Agility),
            new EventFactor.EventHandlerTable(EventID.CHECK_FLYING, handler_KuroiTekkyuu_CheckFly),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Karuisi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEIGHT_RATIO, handler_Karuisi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinkanoKiseki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_SinkanoKiseki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GotugotuMet = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_GotugotuMet),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Huusen = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Huusen_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHECK_FLYING, handler_Huusen_CheckFlying),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Huusen_DamageReaction),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RedCard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_RedCard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NerainoMato = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY, handler_NerainoMato),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SimetukeBand = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASICK_PARAM, handler_SimetukeBand),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyuukon = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Kyuukon_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_Kyuukon_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AkkiNomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_AkkiNomi_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_AkkiNomi_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_AkkiNomi_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikariGoke = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_HikariGoke_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_HikariGoke_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukidama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Yukidama_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_Juudenti_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juudenti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Juudenti_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_Juudenti_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NodoAme = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_NodoAme_Waza),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_NodoAme_Use),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM_TMP, handler_NodoAme_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DassyutuButton = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_DassyutuButton_Reaction),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_DassyutuButton_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DassyutuPack = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FIXED, handler_DassyutuPack_Reaction),
            new EventFactor.EventHandlerTable(EventID.DASSYUTUPACK_LAUNCH, handler_DassyutuPack_Launch),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_DassyutuPack_Launch),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_DONE, handler_DassyutuPack_TurnCheckDone),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_DassyutuPack_Use),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BoujinGoggle = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_BoujinGoggle_CalcDamage),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_BoujinGoggle_WazaNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BannouGasa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_LOCAL_CHECK, handler_BannouGasa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HonooNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_HonooNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_HonooNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MizuNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_MizuNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MizuNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenkiNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_DenkiNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_DenkiNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KusaNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_KusaNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KusaNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KooriNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_KooriNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KooriNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KakutouJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_KakutouJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KakutouJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DokuNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_DokuNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_DokuNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JimenNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_JimenNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_JimenNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikouNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_HikouNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_HikouNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_EsperJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_EsperJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_EsperJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MusiNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_MusiNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MusiNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IwaNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_IwaNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_IwaNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GhostJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_GhostJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_GhostJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DragonJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_DragonNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_DragonNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AkuNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_AkuNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_AkuNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HaganeNoJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_HaganeNoJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_HaganeNoJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NormalJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_NormalJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_NormalJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YouseiJuel = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_YouseiJuel_Decide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_YouseiJuel_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Juel_EndDmgSeq),
        };
        private const int JUEL_SEQ_NULL = 0;
        private const int JUEL_SEQ_STANDBY = 1;
        private const int JUEL_SEQ_END = 2;
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Aiironotama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_Aiironotama_Shinka),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Beniironotama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_Beniironotama_Shinka),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GroundCoat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_BEFORE, handler_GroundCoat),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bibiridama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Bibiridama_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Bibiridama_RankEffectFailed),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FIXED, handler_Bibiridama_RankEffectFailed),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_Bibiridama_Use),
        };
        private const int BIBIRIDAMA_STAT_NONE = 0;
        private const int BIBIRIDAMA_STAT_READY = 1;
        private const int BIBIRIDAMA_STAT_DONE = 2;
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecSeed = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_ElecSeed_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_AFTER, handler_ElecSeed_ChangeGroundAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_ElecSeed_Use),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_ElecSeed_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhychoSeed = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_PhychoSeed_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_AFTER, handler_PhychoSeed_ChangeGroundAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_PhychoSeed_Use),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_PhychoSeed_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MistSeed = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_MistSeed_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_AFTER, handler_MistSeed_ChangeGroundAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_MistSeed_Use),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_MistSeed_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GrassSeed = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_GrassSeed_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_AFTER, handler_GrassSeed_ChangeGroundAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_GrassSeed_Use),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_GrassSeed_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RoomService = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_RoomService_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_FIELD_AFTER, handler_RoomService_ChangeFieldAfter),
            new EventFactor.EventHandlerTable(EventID.USE_ITEM, handler_RoomService_Use),
            new EventFactor.EventHandlerTable(EventID.CHECK_ITEM_REACTION, handler_RoomService_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BougoPad = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_ENABLE, handler_BougoPad_SimpleDamageEnable),
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_FAILED, handler_BougoPad_SimpleDamageFailed),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_BougoPad_AddSick_CheckFail),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_BougoPad_RankEffect_LastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_BougoPad_RankEffect_Failed),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_CHANGE_CHECKFAIL, handler_BougoPad_TokuseiChangeCheckFail),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_CHANGE_FAILED, handler_BougoPad_TokuseiChangeFailed),
        };
        private static readonly GuardTargetElem[] handler_BougoPad_SimpleDamageEnable_GUARD_TARGETS = new GuardTargetElem[]
        {
            new GuardTargetElem(DamageCause.SAMEHADA, true),
            new GuardTargetElem(DamageCause.TETUNOTOGE, true),
            new GuardTargetElem(DamageCause.YUUBAKU, true),
            new GuardTargetElem(DamageCause.NEEDLEGUARD, false),
            new GuardTargetElem(DamageCause.GOTUGOTUMETTO, false),
        };
        private static readonly GuardTargetRankElem[] handler_BougoPad_RankEffect_LastCheck_GUARD_TARGETS = new GuardTargetRankElem[]
        {
            new GuardTargetRankElem(RankEffectCause.NUMENUME, true),
            new GuardTargetRankElem(RankEffectCause.KINGSHIELD, false),
        };
        private const int BOUGOPAD_WORK_INDEX_GUARD = 0;
        private const int BOUGOPAD_WORK_INDEX_MESSAGE = 1;
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AtuzokoBoots = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_ENABLE, handler_AtuzokoBoots_SimpleDamageEnable),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_AtuzokoBoots_AddSickCheckFail),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_AtuzokoBoots_RankEffectLastCheck),
        };

        public static HandlerGetFunc getHandlerGetFunc(ItemNo itemNo)
        {
            for (int i=0; i<GET_FUNC_TABLE.Length; i++)
            {
                if (GET_FUNC_TABLE[i].itemno == itemNo)
                    return GET_FUNC_TABLE[i].func;
            }

            return null;
        }

        public static EventFactor addHandler(EventSystem pEventSystem, BTL_POKEPARAM bpp, ushort itemNo)
        {
            var handlerFunc = getHandlerGetFunc((ItemNo)itemNo);
            if (handlerFunc == null)
                return null;

            var table = handlerFunc.Invoke();
            if (table == null)
                return null;

            return pEventSystem.AddFactor(EventFactorType.ITEM, itemNo, EventPriority.ITEM, (ushort)bpp.GetValue_Base(BTL_POKEPARAM.ValueID.BPP_AGILITY), bpp.GetID(), table, (byte)table.Length);
        }

        public static void Add(EventSystem pEventSystem, BTL_POKEPARAM bpp)
        {
            addHandler(pEventSystem, bpp, bpp.GetItem());
        }

        public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM bpp)
        {
            for (var factor = pEventSystem.GetFactorContainer().SeekFactor(EventFactorType.ITEM, bpp.GetID()); factor != null; factor = factor.GetNext())
            {
                if (factor.GetWorkValue(WORKIDX_TMP_FLAG) == FALSE)
                    pEventSystem.RemoveFactor(factor);
            }
        }

        public static EventFactor TMP_Add(EventSystem pEventSystem, BTL_POKEPARAM bpp, ushort itemNo)
        {
            if ((ItemNo)itemNo == ItemNo.DUMMY_DATA)
                return null;

            var factor = addHandler(pEventSystem, bpp, itemNo);
            if (factor != null)
            {
                factor.SetTmpItemFlag();
                factor.SetWorkValue(WORKIDX_TMP_FLAG, TRUE);
            }

            return factor;
        }

        public static void TMP_Remove(EventSystem pEventSystem, EventFactor factor)
        {
            pEventSystem.RemoveFactor(factor);
        }

        public static bool isOccurPer(in EventFactor.EventHandlerArgs args, byte per)
        {
            return calc.IsOccurPer(per);
        }

        public static int common_GetItemParam(EventFactor factor, Pml.Item.ItemData.PrmID paramID)
        {
            return calc.ITEM_GetParam(factor.GetSubID(), paramID);
        }

        // TODO
        public static int item_AttackValue_to_Ratio(EventFactor factor) { return 0; }

        // TODO
        public static void itemPushRun(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static bool isPOKEID(in EventFactor.EventHandlerArgs args, byte pokeID)
        {
            return Common.GetEventVar(args, EventVar.Label.POKEID) == pokeID;
        }

        public static bool isPOKEID_ATK(in EventFactor.EventHandlerArgs args, byte pokeID)
        {
            return Common.GetEventVar(args, EventVar.Label.POKEID_ATK) == pokeID;
        }

        public static bool isPOKEID_DEF(in EventFactor.EventHandlerArgs args, byte pokeID)
        {
            return Common.GetEventVar(args, EventVar.Label.POKEID_DEF) == pokeID;
        }

        public static byte getPOKEID_ATK(in EventFactor.EventHandlerArgs args)
        {
            return (byte)Common.GetEventVar(args, EventVar.Label.POKEID_ATK);
        }

        public static byte getWAZA_TYPE(in EventFactor.EventHandlerArgs args)
        {
            return (byte)Common.GetEventVar(args, EventVar.Label.WAZA_TYPE);
        }

        public static bool getMIGAWARI_FLAG(in EventFactor.EventHandlerArgs args)
        {
            return Common.GetEventVar(args, EventVar.Label.MIGAWARI_FLAG) != FALSE;
        }

        public static TypeAffinity.AffinityID getTYPEAFF(in EventFactor.EventHandlerArgs args)
        {
            return (TypeAffinity.AffinityID)Common.GetEventVar(args, EventVar.Label.TYPEAFF);
        }

        public static BTL_SICKCONTOBJ getSickContAddress(in EventFactor.EventHandlerArgs args)
        {
            return Common.GetEventVarAddress(args, EventVar.Label.SICK_CONT_ADRS) as BTL_SICKCONTOBJ;
        }

        public static bool isMonsNo(in EventFactor.EventHandlerArgs args, byte pokeID, ushort MonsNo)
        {
            return Common.GetPokeParam(args, pokeID).GetMonsNo() == MonsNo;
        }

        public static EventFactor.EventHandlerTable[] ADD_KuraboNomi()
        {
            return HandlerTable_KuraboNomi;
        }

        // TODO
        public static void handler_KuraboNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KuraboNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KagoNomi()
        {
            return HandlerTable_KagoNomi;
        }

        // TODO
        public static void handler_KagoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KagoNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ChigoNomi()
        {
            return HandlerTable_ChigoNomi;
        }

        // TODO
        public static void handler_ChigoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_ChigoNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NanasiNomi()
        {
            return HandlerTable_NanasiNomi;
        }

        // TODO
        public static void handler_NanasiNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_NanasiNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MomonNomi()
        {
            return HandlerTable_MomonNomi;
        }

        // TODO
        public static void handler_MomonNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MomonNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KiiNomi()
        {
            return HandlerTable_KiiNomi;
        }

        // TODO
        public static void handler_KiiNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KiiNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RamNomi()
        {
            return HandlerTable_RamNomi;
        }

        // TODO
        public static void handler_RamNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_RamNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_sickReaction(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSickEx sickCode) { }

        // TODO
        public static bool common_useForSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSickEx sickCode, ushort itemID) { return false; }

        // TODO
        public static bool common_sickcode_match(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSickEx sickCode) { return false; }

        public static EventFactor.EventHandlerTable[] ADD_HimeriNomi()
        {
            return HandlerTable_HimeriNomi;
        }

        // TODO
        public static void handler_HimeriNomi_wazaEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HimeriNomi_reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HimeriNomi_get(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HimeriNomi_ppDec(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HimeriNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HimeriNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static byte common_Himeri_LastWazaIdx(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static byte common_Himeri_EnableWazaIdx(in EventFactor.EventHandlerArgs args, byte pokeID) { return 0; }

        // TODO
        public static bool handler_HimeriNomi_common(in EventFactor.EventHandlerArgs args, byte pokeID, bool fDouble, bool fUseTmp) { return false; }

        // TODO
        public static byte handler_HimeriNomi_GetTargetWazaIndex(in EventFactor.EventHandlerArgs args, byte pokeID, bool fUseTmp) { return 0; }

        public static EventFactor.EventHandlerTable[] ADD_OrenNomi()
        {
            return HandlerTable_OrenNomi;
        }

        // TODO
        public static void handler_OrenNomi_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_OrenNomi_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_OrenNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_common_OrenUse(in EventFactor.EventHandlerArgs args, byte pokeID, bool fDuble) { }

        public static EventFactor.EventHandlerTable[] ADD_KinomiJuice()
        {
            return HandlerTable_KinomiJuice;
        }

        // TODO
        public static void handler_KinomiJuce_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ObonNomi()
        {
            return HandlerTable_ObonNomi;
        }

        // TODO
        public static void handler_ObonNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TarapuNoMi()
        {
            return HandlerTable_TarapuNoMi;
        }

        // TODO
        public static void handler_TarapuNoMi_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_TarapuNoMi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_FiraNomi()
        {
            return HandlerTable_FiraNomi;
        }

        // TODO
        public static void handler_FiraNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_FiraNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_UiNomi()
        {
            return HandlerTable_UiNomi;
        }

        // TODO
        public static void handler_UiNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_UiNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MagoNomi()
        {
            return HandlerTable_MagoNomi;
        }

        // TODO
        public static void handler_MagoNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MagoNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BanziNomi()
        {
            return HandlerTable_BanziNomi;
        }

        // TODO
        public static void handler_BanjiNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BanjiNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_IaNomi()
        {
            return HandlerTable_IaNomi;
        }

        // TODO
        public static void handler_IaNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_IaNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_common_KaifukuKonran_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_common_KaifukuKonran_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_KaifukuKonran(in EventFactor.EventHandlerArgs args, byte pokeID, Taste taste, ushort itemID) { }

        public static EventFactor.EventHandlerTable[] ADD_TiiraNomi()
        {
            return HandlerTable_TiiraNomi;
        }

        // TODO
        public static void handler_TiiraNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_TiiraNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RyugaNomi()
        {
            return HandlerTable_RyugaNomi;
        }

        // TODO
        public static void handler_RyugaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_RyugaNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KamuraNomi()
        {
            return HandlerTable_KamuraNomi;
        }

        // TODO
        public static void handler_KamuraNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KamuraNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YatapiNomi()
        {
            return HandlerTable_YatapiNomi;
        }

        // TODO
        public static void handler_YatapiNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_YatapiNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ZuaNomi()
        {
            return HandlerTable_ZuaNomi;
        }

        // TODO
        public static void handler_ZuaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_ZuaNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SanNomi()
        {
            return HandlerTable_SanNomi;
        }

        // TODO
        public static void handler_SanNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SanNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SutaaNomi()
        {
            return HandlerTable_SutaaNomi;
        }

        // TODO
        public static void handler_SutaaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SutaaNomi_Tmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_PinchRankup(in EventFactor.EventHandlerArgs args, byte pokeID, WazaRankEffect rankType, byte volume, ushort itemID) { }

        public static EventFactor.EventHandlerTable[] ADD_NazoNomi()
        {
            return HandlerTable_NazoNomi;
        }

        // TODO
        public static void handler_NazoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_NazoNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_OkkaNomi()
        {
            return HandlerTable_OkkaNomi;
        }

        // TODO
        public static void handler_OkkaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ItokeNomi()
        {
            return HandlerTable_ItokeNomi;
        }

        // TODO
        public static void handler_ItokeNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SokunoNomi()
        {
            return HandlerTable_SokunoNomi;
        }

        // TODO
        public static void handler_SokunoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RindoNomi()
        {
            return HandlerTable_RindoNomi;
        }

        // TODO
        public static void handler_RindoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YacheNomi()
        {
            return HandlerTable_YacheNomi;
        }

        // TODO
        public static void handler_YacheNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YopuNomi()
        {
            return HandlerTable_YopuNomi;
        }

        // TODO
        public static void handler_YopuNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BiarNomi()
        {
            return HandlerTable_BiarNomi;
        }

        // TODO
        public static void handler_BiarNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SyukaNomi()
        {
            return HandlerTable_SyukaNomi;
        }

        // TODO
        public static void handler_SyukaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BakouNomi()
        {
            return HandlerTable_BakouNomi;
        }

        // TODO
        public static void handler_BakouNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_UtanNomi()
        {
            return HandlerTable_UtanNomi;
        }

        // TODO
        public static void handler_UtanNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TangaNomi()
        {
            return HandlerTable_TangaNomi;
        }

        // TODO
        public static void handler_TangaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YorogiNomi()
        {
            return HandlerTable_YorogiNomi;
        }

        // TODO
        public static void handler_YorogiNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KasibuNomi()
        {
            return HandlerTable_KasibuNomi;
        }

        // TODO
        public static void handler_KasibuNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HabanNomi()
        {
            return HandlerTable_HabanNomi;
        }

        // TODO
        public static void handler_HabanNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NamoNomi()
        {
            return HandlerTable_NamoNomi;
        }

        // TODO
        public static void handler_NamoNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RiribaNomi()
        {
            return HandlerTable_RiribaNomi;
        }

        // TODO
        public static void handler_RiribaNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HozuNomi()
        {
            return HandlerTable_HozuNomi;
        }

        // TODO
        public static void handler_HozuNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RozeruNomi()
        {
            return HandlerTable_RozeruNomi;
        }

        // TODO
        public static void handler_RozeruNomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static bool common_WeakAff_Relieve(in EventFactor.EventHandlerArgs args, byte pokeID, byte type, bool fIgnoreAffine) { return false; }

        // TODO
        public static void handler_common_WeakAff_DmgAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PinchReactCommon(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PinchReactMemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_DamageReact(in EventFactor.EventHandlerArgs args, byte pokeID, uint n, bool fCheckReactionType) { }

        // TODO
        public static bool common_DamageReactCheck(in EventFactor.EventHandlerArgs args, byte pokeID, uint n) { return false; }

        // TODO
        public static bool common_DamageReactCheckCore(in EventFactor.EventHandlerArgs args, byte pokeID, uint n) { return false; }

        public static EventFactor.EventHandlerTable[] ADD_IbanNomi()
        {
            return HandlerTable_IbanNomi;
        }

        // TODO
        public static void handler_IbanNomi_SpPriorityCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_IbanNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_common_Kinomi_UseTmp_OnlyConsume(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MikuruNomi()
        {
            return HandlerTable_MikuruNomi;
        }

        // TODO
        public static void handler_MikuruNomi_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MikuruNomi_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MikuruNomi_ActProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MikuruNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MikuruNomi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_JapoNomi()
        {
            return HandlerTable_JapoNomi;
        }

        // TODO
        public static void handler_JapoNomi_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_JapoNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_JapoRenbu_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID, WazaDamageType dmgType) { }

        public static EventFactor.EventHandlerTable[] ADD_RenbuNomi()
        {
            return HandlerTable_RenbuNomi;
        }

        // TODO
        public static void handler_RenbuNomi_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TotugekiChokki()
        {
            return HandlerTable_TotugekiChokki;
        }

        // TODO
        public static void handler_totugekiChokki(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_JyakutenHoken()
        {
            return HandlerTable_JyakutenHoken;
        }

        // TODO
        public static void handler_JyakutenHoken_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_JyakutenHoken_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SiroiHerb()
        {
            return HandlerTable_SiroiHerb;
        }

        // TODO
        public static void handler_SiroiHerb_ActCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_MemberInComp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SiroiHerb_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MentalHerb()
        {
            return HandlerTable_MentalHerb;
        }

        // TODO
        public static void handler_MentalHerb_React(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MentalHerb_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MentalHerb_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KaraburiHoken()
        {
            return HandlerTable_KuraboNomi;
        }

        // TODO
        public static void handler_KaraburiHoken_Avoid(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KaraburiHoken_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KaraburiHoken_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HikarinoKona()
        {
            return HandlerTable_HikarinoKona;
        }

        // TODO
        public static void handler_HikarinoKona(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KyouseiGipusu()
        {
            return HandlerTable_KyouseiGipusu;
        }

        // TODO
        public static void handler_KyouseiGipusu(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SenseiNoTume()
        {
            return HandlerTable_SenseiNoTume;
        }

        // TODO
        public static void handler_SenseiNoTume_SpPriorityCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SenseiNoTume_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_SenseiNoTume_TurnCheckDone(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KoukouNoSippo()
        {
            return HandlerTable_KoukouNoSippo;
        }

        // TODO
        public static void handler_KoukouNoSippo(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_OujaNoSirusi()
        {
            return HandlerTable_OujaNoSirusi;
        }

        // TODO
        public static void handler_OujaNoSirusi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_OujaNoSirusi_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SurudoiKiba()
        {
            return HandlerTable_SurudoiKiba;
        }

        public static EventFactor.EventHandlerTable[] ADD_KoukakuLens()
        {
            return HandlerTable_KoukakuLens;
        }

        // TODO
        public static void handler_KoukakuLens(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_PintLens()
        {
            return HandlerTable_PintLens;
        }

        // TODO
        public static void handler_PintLens(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_LuckyPunch()
        {
            return HandlerTable_LuckyPunch;
        }

        // TODO
        public static void handler_LuckyPunch(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Naganegi()
        {
            return HandlerTable_Naganegi;
        }

        // TODO
        public static void handler_Naganegi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_FocusLens()
        {
            return HandlerTable_FocusLens;
        }

        // TODO
        public static void handler_FocusLens(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NonkiNoOkou()
        {
            return HandlerTable_NonkiNoOkou;
        }

        // TODO
        public static void handler_NonkiNoOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ChikaraNoHachimaki()
        {
            return HandlerTable_ChikaraNoHachimaki;
        }

        // TODO
        public static void handler_ChikaraNoHachimaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MonosiriMegane()
        {
            return HandlerTable_MonosiriMegane;
        }

        // TODO
        public static void handler_MonosiriMegane(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SinkaiNoKiba()
        {
            return HandlerTable_SinkaiNoKiba;
        }

        // TODO
        public static void handler_SinkaiNoKiba(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SinkaiNoUroko()
        {
            return HandlerTable_SinkaiNoUroko;
        }

        // TODO
        public static void handler_SinkaiNoUroko(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MetalPowder()
        {
            return HandlerTable_MetalPowder;
        }

        // TODO
        public static void handler_MetalPowder(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SpeedPowder()
        {
            return HandlerTable_SpeedPowder;
        }

        // TODO
        public static void handler_SpeedPowder(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_FutoiHone()
        {
            return HandlerTable_FutoiHone;
        }

        // TODO
        public static void handler_FutoiHone(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KodawariHachimaki()
        {
            return HandlerTable_KodawariHachimaki;
        }

        // TODO
        public static void handler_KodawariHachimaki_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KodawariMegane()
        {
            return HandlerTable_KodawariMegane;
        }

        // TODO
        public static void handler_KodawariMegane_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KodawariScarf()
        {
            return HandlerTable_KodawariScarf;
        }

        // TODO
        public static void handler_KodawariScarf(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Kodawari_Common_WazaExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Kodawari_Common_ItemChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Kodawari_Common_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KiaiNoTasuki()
        {
            return HandlerTable_KiaiNoTasuki;
        }

        // TODO
        public static void handler_KiaiNoTasuki_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KiaiNoTasuki_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KiaiNoHachimaki()
        {
            return HandlerTable_KiaiNoHachimaki;
        }

        // TODO
        public static void handler_KiaiNoHachimaki_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KiaiNoHachimaki_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KiaiNoHachimaki_UseItem(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TatsujinNoObi()
        {
            return HandlerTable_TatsujinNoObi;
        }

        // TODO
        public static void handler_TatsujinNoObi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_InochiNoTama()
        {
            return HandlerTable_InochiNoTama;
        }

        // TODO
        public static void handler_InochiNoTama_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_InochiNoTama_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MetroNome()
        {
            return HandlerTable_MetroNome;
        }

        // TODO
        public static void handler_MetroNome(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NebariNoKagidume()
        {
            return HandlerTable_NebariNoKagidume;
        }

        // TODO
        public static void handler_NebariNoKagidume(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KaigaraNoSuzu()
        {
            return HandlerTable_KaigaraNoSuzu;
        }

        // TODO
        public static void handler_KaigaraNoSuzu(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HikariNoNendo()
        {
            return HandlerTable_HikariNoNendo;
        }

        // TODO
        public static void handler_HikariNoNendo(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_PowefulHarb()
        {
            return HandlerTable_PowefulHarb;
        }

        // TODO
        public static void handler_PowefulHarb_CheckTameSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PowefulHarb_FixTameSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PowefulHarb_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Tabenokosi()
        {
            return HandlerTable_Tabenokosi;
        }

        // TODO
        public static void handler_Tabenokosi_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Tabenokosi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KuroiHedoro()
        {
            return HandlerTable_KuroiHedoro;
        }

        // TODO
        public static void handler_KuroiHedoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AkaiIto()
        {
            return HandlerTable_AkaiIto;
        }

        // TODO
        public static void handler_AkaiIto(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KuttukiBari()
        {
            return HandlerTable_KuttukiBari;
        }

        // TODO
        public static void handler_KuttukiBari_DamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KuttukiBari_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_PowerWrist()
        {
            return HandlerTable_PowerWrist;
        }

        public static EventFactor.EventHandlerTable[] ADD_PowerBelt()
        {
            return HandlerTable_PowerBelt;
        }

        public static EventFactor.EventHandlerTable[] ADD_PowerLens()
        {
            return HandlerTable_PowerLens;
        }

        public static EventFactor.EventHandlerTable[] ADD_PowerBand()
        {
            return HandlerTable_PowerBand;
        }

        public static EventFactor.EventHandlerTable[] ADD_PowerAnkle()
        {
            return HandlerTable_PowerAnkle;
        }

        public static EventFactor.EventHandlerTable[] ADD_PowerWeight()
        {
            return HandlerTable_PowerWeight;
        }

        // TODO
        public static void handler_PowerXXX_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HinotamaPlate()
        {
            return HandlerTable_HinotamaPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_SizukuPlate()
        {
            return HandlerTable_SizukuPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_IkazutiPlate()
        {
            return HandlerTable_IkazutiPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_MirodinoPlate()
        {
            return HandlerTable_MirodinoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_TuraranoPlate()
        {
            return HandlerTable_TuraranoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_KobusinoPlate()
        {
            return HandlerTable_KobusinoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_MoudokuPlate()
        {
            return HandlerTable_MoudokuPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_DaitinoPlate()
        {
            return HandlerTable_DaitinoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_AozoraPlate()
        {
            return HandlerTable_AozoraPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_HusiginoPlate()
        {
            return HandlerTable_HusiginoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_TamamusiPlate()
        {
            return HandlerTable_TamamusiPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_GansekiPlate()
        {
            return HandlerTable_GansekiOkou;
        }

        public static EventFactor.EventHandlerTable[] ADD_MononokePlate()
        {
            return HandlerTable_MononokePlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_RyuunoPlate()
        {
            return HandlerTable_RyuunoPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_KowamotePlate()
        {
            return HandlerTable_KowamotePlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_KoutetsuPlate()
        {
            return HandlerTable_KoutetsuPlate;
        }

        public static EventFactor.EventHandlerTable[] ADD_SeireiPlate()
        {
            return HandlerTable_SeireiPlate;
        }

        // TODO
        public static void handler_SeireiPlate(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_OokinaNekko()
        {
            return HandlerTable_OokinaNekko;
        }

        // TODO
        public static void handler_OokinaNekko(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Kemuridama()
        {
            return HandlerTable_Kemuridama;
        }

        // TODO
        public static void handler_Kemuridama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Kemuridama_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_OmamoriKoban()
        {
            return HandlerTable_OmamoriKoban;
        }

        // TODO
        public static void handler_OmamoriKoban(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HakkinDama()
        {
            return HandlerTable_HakkinDama;
        }

        // TODO
        public static void handler_HakkinDama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TumetaiIwa()
        {
            return HandlerTable_TumetaiIwa;
        }

        // TODO
        public static void handler_TumetaiIwa(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SarasaraIwa()
        {
            return HandlerTable_SarasaraIwa;
        }

        // TODO
        public static void handler_SarasaraIwa(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AtuiIwa()
        {
            return HandlerTable_AtuiIwa;
        }

        // TODO
        public static void handler_AtuiIwa(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SimettaIwa()
        {
            return HandlerTable_SimettaIwa;
        }

        // TODO
        public static void handler_SimettaIwa(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_WazaWeatherTurnUp(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }

        public static EventFactor.EventHandlerTable[] ADD_DenkiDama()
        {
            return HandlerTable_DenkiDama;
        }

        // TODO
        public static void handler_DenkiDama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DenkiDama_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DokudokuDama()
        {
            return HandlerTable_DokudokuDama;
        }

        // TODO
        public static void handler_DokudokuDama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DokudokuDama_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KaenDama()
        {
            return HandlerTable_KaenDama;
        }

        // TODO
        public static void handler_KaenDama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KaenDama_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GinNoKona()
        {
            return HandlerTable_GinNoKona;
        }

        // TODO
        public static void handler_GinNoKona(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YawarakaiSuna()
        {
            return HandlerTable_YawarakaiSuna;
        }

        // TODO
        public static void handler_YawarakaiSuna(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KataiIsi()
        {
            return HandlerTable_KataiIsi;
        }

        // TODO
        public static void handler_KataiIsi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KisekiNoTane()
        {
            return HandlerTable_KisekiNoTane;
        }

        // TODO
        public static void handler_KisekiNoTane(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KuroiMegane()
        {
            return HandlerTable_KuroiMegane;
        }

        // TODO
        public static void handler_KuroiMegane(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Kuroobi()
        {
            return HandlerTable_Kuroobi;
        }

        // TODO
        public static void handler_Kuroobi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Zisyaku()
        {
            return HandlerTable_Zisyaku;
        }

        // TODO
        public static void handler_Zisyaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MetalCoat()
        {
            return HandlerTable_MetalCoat;
        }

        // TODO
        public static void handler_MetalCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SinpiNoSizuku()
        {
            return HandlerTable_SinpiNoSizuku;
        }

        // TODO
        public static void handler_SinpiNoSizuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SurudoiKutibasi()
        {
            return HandlerTable_SurudoiKutibasi;
        }

        // TODO
        public static void handler_SurudoiKutibasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Dokubari()
        {
            return HandlerTable_Dokubari;
        }

        // TODO
        public static void handler_Dokubari(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Dokubari_UseTmp(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_TokenaiKoori()
        {
            return HandlerTable_TokenaiKoori;
        }

        // TODO
        public static void handler_TokenaiKoori(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NoroiNoOfuda()
        {
            return HandlerTable_NoroiNoOfuda;
        }

        // TODO
        public static void handler_NoroiNoOfuda(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MagattaSupuun()
        {
            return HandlerTable_MagattaSupuun;
        }

        // TODO
        public static void handler_MagattaSupuun(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Mokutan()
        {
            return HandlerTable_Mokutan;
        }

        // TODO
        public static void handler_Mokutan(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RyuunoKiba()
        {
            return HandlerTable_RyuunoKiba;
        }

        // TODO
        public static void handler_RyuunoKiba(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SirukuNoSukaafu()
        {
            return HandlerTable_SirukuNoSukaafu;
        }

        // TODO
        public static void handler_SirukuNoSukaafu(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AyasiiOkou()
        {
            return HandlerTable_AyasiiOkou;
        }

        // TODO
        public static void handler_AyasiiOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GansekiOkou()
        {
            return HandlerTable_GansekiOkou;
        }

        // TODO
        public static void handler_GansekiOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SazanamiNoOkou()
        {
            return HandlerTable_SazanamiNoOkou;
        }

        // TODO
        public static void handler_SazanamiNoOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_UsioNoOkou()
        {
            return HandlerTable_UsioNoOkou;
        }

        // TODO
        public static void handler_UsioNoOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_OhanaNoOkou()
        {
            return HandlerTable_OhanaNoOkou;
        }

        // TODO
        public static void handler_OhanaNoOkou(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_PowerUpSpecificType(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }

        public static EventFactor.EventHandlerTable[] ADD_KokoroNoSizuku()
        {
            return HandlerTable_KokoroNoSizuku;
        }

        // TODO
        public static void handler_KokoroNoSizuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Siratama()
        {
            return HandlerTable_Siratama;
        }

        // TODO
        public static void handler_Siratama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Kongoudama()
        {
            return HandlerTable_Kongoudama;
        }

        // TODO
        public static void handler_Kongoudama(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KuroiTekkyuu()
        {
            return HandlerTable_KuroiTekkyuu;
        }

        // TODO
        public static void handler_KuroiTekkyuu_Agility(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KuroiTekkyuu_CheckFly(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Karuisi()
        {
            return HandlerTable_Karuisi;
        }

        // TODO
        public static void handler_Karuisi(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SinkanoKiseki()
        {
            return HandlerTable_SinkanoKiseki;
        }

        // TODO
        public static void handler_SinkanoKiseki(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GotugotuMet()
        {
            return HandlerTable_GotugotuMet;
        }

        // TODO
        public static void handler_GotugotuMet(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Huusen()
        {
            return HandlerTable_Huusen;
        }

        // TODO
        public static void handler_Huusen_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Huusen_CheckFlying(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Huusen_DamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Huusen_ItemSetFixed(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_RedCard()
        {
            return HandlerTable_RedCard;
        }

        // TODO
        public static void handler_RedCard(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NerainoMato()
        {
            return HandlerTable_NerainoMato;
        }

        // TODO
        public static void handler_NerainoMato(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_SimetukeBand()
        {
            return HandlerTable_SimetukeBand;
        }

        // TODO
        public static void handler_SimetukeBand(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Kyuukon()
        {
            return HandlerTable_Kyuukon;
        }

        // TODO
        public static void handler_Kyuukon_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Kyuukon_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AkkiNomi()
        {
            return HandlerTable_AkkiNomi;
        }

        // TODO
        public static void handler_AkkiNomi_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_AkkiNomi_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HikariGoke()
        {
            return HandlerTable_HikariGoke;
        }

        // TODO
        public static void handler_HikariGoke_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HikariGoke_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Yukidama()
        {
            return HandlerTable_Yukidama;
        }

        // TODO
        public static void handler_Yukidama_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Juudenti()
        {
            return HandlerTable_Juudenti;
        }

        // TODO
        public static void handler_Juudenti_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void hand_common_TypeDamageRankUp_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID, byte wazaType, BTL_POKEPARAM.ValueID rankValue) { }

        // TODO
        public static void handler_Juudenti_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NodoAme()
        {
            return HandlerTable_NodoAme;
        }

        // TODO
        public static void handler_NodoAme_Waza(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_NodoAme_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DassyutuButton()
        {
            return HandlerTable_DassyutuButton;
        }

        // TODO
        public static void handler_DassyutuButton_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DassyutuButton_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DassyutuPack()
        {
            return HandlerTable_DassyutuPack;
        }

        // TODO
        public static void handler_DassyutuPack_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DassyutuPack_Launch(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DassyutuPack_TurnCheckDone(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DassyutuPack_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BoujinGoggle()
        {
            return HandlerTable_BoujinGoggle;
        }

        // TODO
        public static void handler_BoujinGoggle_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BoujinGoggle_WazaNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BannouGasa()
        {
            return HandlerTable_BannouGasa;
        }

        // TODO
        public static void handler_BannouGasa(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HonooNoJuel()
        {
            return HandlerTable_HonooNoJuel;
        }

        // TODO
        public static void handler_HonooNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HonooNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MizuNoJuel()
        {
            return HandlerTable_MizuNoJuel;
        }

        // TODO
        public static void handler_MizuNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MizuNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DenkiNoJuel()
        {
            return HandlerTable_DenkiNoJuel;
        }

        // TODO
        public static void handler_DenkiNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DenkiNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KusaNoJuel()
        {
            return HandlerTable_KusaNoJuel;
        }

        // TODO
        public static void handler_KusaNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KusaNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KooriNoJuel()
        {
            return HandlerTable_KooriNoJuel;
        }

        // TODO
        public static void handler_KooriNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KooriNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_KakutouJuel()
        {
            return HandlerTable_KakutouJuel;
        }

        // TODO
        public static void handler_KakutouJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_KakutouJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DokuNoJuel()
        {
            return HandlerTable_DokuNoJuel;
        }

        // TODO
        public static void handler_DokuNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DokuNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_JimenNoJuel()
        {
            return HandlerTable_JimenNoJuel;
        }

        // TODO
        public static void handler_JimenNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_JimenNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HikouNoJuel()
        {
            return HandlerTable_HikouNoJuel;
        }

        // TODO
        public static void handler_HikouNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HikouNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_EsperJuel()
        {
            return HandlerTable_EsperJuel;
        }

        // TODO
        public static void handler_EsperJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_EsperJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MusiNoJuel()
        {
            return HandlerTable_MusiNoJuel;
        }

        // TODO
        public static void handler_MusiNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MusiNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_IwaNoJuel()
        {
            return HandlerTable_IwaNoJuel;
        }

        // TODO
        public static void handler_IwaNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_IwaNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GhostJuel()
        {
            return HandlerTable_GhostJuel;
        }

        // TODO
        public static void handler_GhostJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_GhostJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_DragonJuel()
        {
            return HandlerTable_DragonJuel;
        }

        // TODO
        public static void handler_DragonNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_DragonNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AkuNoJuel()
        {
            return HandlerTable_AkuNoJuel;
        }

        // TODO
        public static void handler_AkuNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_AkuNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_HaganeNoJuel()
        {
            return HandlerTable_HaganeNoJuel;
        }

        // TODO
        public static void handler_HaganeNoJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_HaganeNoJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_NormalJuel()
        {
            return HandlerTable_NormalJuel;
        }

        // TODO
        public static void handler_NormalJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_NormalJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_YouseiJuel()
        {
            return HandlerTable_YouseiJuel;
        }

        // TODO
        public static void handler_YouseiJuel_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_YouseiJuel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_Juel_Decide(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }

        // TODO
        public static void common_Juel_Power(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }

        // TODO
        public static void handler_Juel_EndDmgSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Aiironotama()
        {
            return HandlerTable_Aiironotama;
        }

        // TODO
        public static void handler_Aiironotama_Shinka(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Beniironotama()
        {
            return HandlerTable_Beniironotama;
        }

        // TODO
        public static void handler_Beniironotama_Shinka(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GroundCoat()
        {
            return HandlerTable_GroundCoat;
        }

        // TODO
        public static void handler_GroundCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_Bibiridama()
        {
            return HandlerTable_Bibiridama;
        }

        // TODO
        public static void handler_Bibiridama_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Bibiridama_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_Bibiridama_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_ElecSeed()
        {
            return HandlerTable_ElecSeed;
        }

        // TODO
        public static void handler_ElecSeed_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_ElecSeed_ChangeGroundAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_ElecSeed_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_PhychoSeed()
        {
            return HandlerTable_PhychoSeed;
        }

        // TODO
        public static void handler_PhychoSeed_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PhychoSeed_ChangeGroundAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_PhychoSeed_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_MistSeed()
        {
            return HandlerTable_MistSeed;
        }

        // TODO
        public static void handler_MistSeed_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MistSeed_ChangeGroundAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_MistSeed_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_GrassSeed()
        {
            return HandlerTable_GrassSeed;
        }

        // TODO
        public static void handler_GrassSeed_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_GrassSeed_ChangeGroundAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_GrassSeed_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void common_Seed_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }

        // TODO
        public static void common_Seed_ChangeGroundAfter(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }

        // TODO
        public static void common_Seed_Use(in EventFactor.EventHandlerArgs args, byte pokeID, WazaRankEffect rankType) { }

        public static EventFactor.EventHandlerTable[] ADD_RoomService()
        {
            return HandlerTable_RoomService;
        }

        // TODO
        public static void handler_RoomService_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_RoomService_ChangeFieldAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_RoomService_Use(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_BougoPad()
        {
            return HandlerTable_BougoPad;
        }

        // TODO
        public static void handler_BougoPad_SimpleDamageEnable(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_SimpleDamageFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_AddSick_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_RankEffect_LastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_RankEffect_Failed(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_TokuseiChangeCheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_BougoPad_TokuseiChangeFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void BougoPad_Guard(in EventFactor.EventHandlerArgs args, bool isGuardMessageEnable) { }

        // TODO
        public static void BougoPad_GuardMessage(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public static EventFactor.EventHandlerTable[] ADD_AtuzokoBoots()
        {
            return HandlerTable_AtuzokoBoots;
        }

        // TODO
        public static void handler_AtuzokoBoots_SimpleDamageEnable(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_AtuzokoBoots_AddSickCheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        // TODO
        public static void handler_AtuzokoBoots_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }

        public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

        private struct GET_FUNC_TABLE_ELEM
        {
            public ItemNo itemno;
            public HandlerGetFunc func;

            public GET_FUNC_TABLE_ELEM(ItemNo itemno, HandlerGetFunc func)
            {
                this.itemno = itemno;
                this.func = func;
            }
        }

        private struct GuardTargetElem
        {
            public DamageCause damageCause;
            public bool messageEnable;

            public GuardTargetElem(DamageCause damageCause, bool messageEnable)
            {
                this.damageCause = damageCause;
                this.messageEnable = messageEnable;
            }
        }

        private struct GuardTargetRankElem
        {
            public RankEffectCause effectCause;
            public bool messageEnable;

            public GuardTargetRankElem(RankEffectCause effectCause, bool messageEnable)
            {
                this.effectCause = effectCause;
                this.messageEnable = messageEnable;
            }
        }
    }
}