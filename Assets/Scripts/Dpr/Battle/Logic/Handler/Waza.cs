using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic.Handler
{
	public static class Waza
	{
        private const int FALSE = 0;
		private const int TRUE = 1;

		public const byte EVENT_WAZA_STICK_MAX = 8;
		private const int WORKIDX_STICK = 6;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
		{
            new GET_FUNC_TABLE_ELEM(WazaNo.TEKUSUTYAA, ADD_Texture),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUROIKIRI, ADD_KuroiKiri),
			new GET_FUNC_TABLE_ELEM(WazaNo.YUMEKUI, ADD_Yumekui),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORAIATAKKU, ADD_TriAttack),
			new GET_FUNC_TABLE_ELEM(WazaNo.IKARINOMAEBA, ADD_IkariNoMaeba),
			new GET_FUNC_TABLE_ELEM(WazaNo.TIKYUUNAGE, ADD_TikyuuNage),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAITOHEDDO, ADD_TikyuuNage),
			new GET_FUNC_TABLE_ELEM(WazaNo.IBIKI, ADD_Ibiki),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOTTEOKI, ADD_Totteoki),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZITABATA, ADD_Jitabata),
			new GET_FUNC_TABLE_ELEM(WazaNo.KISIKAISEI, ADD_Jitabata),
			new GET_FUNC_TABLE_ELEM(WazaNo.MINEUTI, ADD_Mineuti),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUROIMANAZASI, ADD_KumoNoSu),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOOSENBOU, ADD_KumoNoSu),
			new GET_FUNC_TABLE_ELEM(WazaNo.KORAERU, ADD_Koraeru),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEKODAMASI, ADD_Nekodamasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.GAMUSYARA, ADD_Gamusyara),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUNKA, ADD_Funka),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIOHUKI, ADD_Funka),
			new GET_FUNC_TABLE_ELEM(WazaNo.ASANOHIZASI, ADD_AsaNoHizasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.TUKINOHIKARI, ADD_AsaNoHizasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOUGOUSEI, ADD_AsaNoHizasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.NIGIRITUBUSU, ADD_Siboritoru),
			new GET_FUNC_TABLE_ELEM(WazaNo.WHEZAABOORU, ADD_WeatherBall),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAMORU, ADD_Mamoru),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIKIRI, ADD_Mamoru),
			new GET_FUNC_TABLE_ELEM(WazaNo.HANERU, ADD_Haneru),
			new GET_FUNC_TABLE_ELEM(WazaNo.NOROI, ADD_Noroi),
			new GET_FUNC_TABLE_ELEM(WazaNo.ABARERU, ADD_Abareru),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAWAGU, ADD_Sawagu),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOROGARU, ADD_Korogaru),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORIPURUKIKKU, ADD_TripleKick),
			new GET_FUNC_TABLE_ELEM(WazaNo.HANABIRANOMAI, ADD_Abareru),
			new GET_FUNC_TABLE_ELEM(WazaNo.GEKIRIN, ADD_Abareru),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIOMIZU, ADD_Siomizu),
			new GET_FUNC_TABLE_ELEM(WazaNo.TUBOWOTUKU, ADD_TuboWoTuku),
			new GET_FUNC_TABLE_ELEM(WazaNo.SORAWOTOBU, ADD_SoraWoTobu),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOBIHANERU, ADD_Tobihaneru),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAIBINGU, ADD_Diving),
			new GET_FUNC_TABLE_ELEM(WazaNo.ANAWOHORU, ADD_AnaWoHoru),
			new GET_FUNC_TABLE_ELEM(WazaNo.SOORAABIIMU, ADD_SolarBeam),
			new GET_FUNC_TABLE_ELEM(WazaNo.SOORAABUREEDO, ADD_SolarBeam),
			new GET_FUNC_TABLE_ELEM(WazaNo.GODDOBAADO, ADD_GodBird),
			new GET_FUNC_TABLE_ELEM(WazaNo.ROKETTOZUTUKI, ADD_RocketZutuki),
			new GET_FUNC_TABLE_ELEM(WazaNo.ANKOORU, ADD_Encore),
			new GET_FUNC_TABLE_ELEM(WazaNo.TATUMAKI, ADD_Tatumaki),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAZEOKOSI, ADD_Tatumaki),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZISIN, ADD_Jisin),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAMINORI, ADD_Naminori),
			new GET_FUNC_TABLE_ELEM(WazaNo.FEINTO, ADD_Feint),
			new GET_FUNC_TABLE_ELEM(WazaNo.SYADOODAIBU, ADD_ShadowDive),
			new GET_FUNC_TABLE_ELEM(WazaNo.WARUAGAKI, ADD_Waruagaki),
			new GET_FUNC_TABLE_ELEM(WazaNo.TYOUHATU, ADD_Chouhatu),
			new GET_FUNC_TABLE_ELEM(WazaNo.HARADAIKO, ADD_Haradaiko),
			new GET_FUNC_TABLE_ELEM(WazaNo.MITIDURE, ADD_Michidure),
			new GET_FUNC_TABLE_ELEM(WazaNo.KARAGENKI, ADD_Karagenki),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIPPEGAESI, ADD_Sippegaesi),
			new GET_FUNC_TABLE_ELEM(WazaNo.MEZAMERUPAWAA, ADD_MezameruPower),
			new GET_FUNC_TABLE_ELEM(WazaNo.TIISAKUNARU, ADD_Tiisakunaru),
			new GET_FUNC_TABLE_ELEM(WazaNo.MARUKUNARU, ADD_Marukunaru),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUMITUKE, ADD_Fumituke),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAIMAKKUSUHOU, ADD_DaiMaxHou),
			new GET_FUNC_TABLE_ELEM(WazaNo.KYOZYUUZAN, ADD_DaiMaxHou),
			new GET_FUNC_TABLE_ELEM(WazaNo.KYOZYUUDAN, ADD_DaiMaxHou),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUIUTI, ADD_Fuiuti),
			new GET_FUNC_TABLE_ELEM(WazaNo.AROMASERAPII, ADD_Alomatherapy),
			new GET_FUNC_TABLE_ELEM(WazaNo.IYASINOSUZU, ADD_IyasiNoSuzu),
			new GET_FUNC_TABLE_ELEM(WazaNo.OKIMIYAGE, ADD_Okimiyage),
			new GET_FUNC_TABLE_ELEM(WazaNo.URAMI, ADD_Urami),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEMURU, ADD_Nemuru),
			new GET_FUNC_TABLE_ELEM(WazaNo.ROKKUON, ADD_LockON),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOKORONOME, ADD_LockON),
			new GET_FUNC_TABLE_ELEM(WazaNo.RIHUREKUTAA, ADD_Reflector),
			new GET_FUNC_TABLE_ELEM(WazaNo.HIKARINOKABE, ADD_HikariNoKabe),
			new GET_FUNC_TABLE_ELEM(WazaNo.SINPINOMAMORI, ADD_SinpiNoMamori),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIROIKIRI, ADD_SiroiKiri),
			new GET_FUNC_TABLE_ELEM(WazaNo.OIKAZE, ADD_Oikaze),
			new GET_FUNC_TABLE_ELEM(WazaNo.PUREZENTO, ADD_Present),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUUIN, ADD_Fuuin),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZYUURYOKU, ADD_Juryoku),
			new GET_FUNC_TABLE_ELEM(WazaNo.ONNEN, ADD_Onnen),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEDASUKE, ADD_Tedasuke),
			new GET_FUNC_TABLE_ELEM(WazaNo.IEKI, ADD_Ieki),
			new GET_FUNC_TABLE_ELEM(WazaNo.NARIKIRI, ADD_Narikiri),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAKIBISI, ADD_Makibisi),
			new GET_FUNC_TABLE_ELEM(WazaNo.DOKUBISI, ADD_Dokubisi),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUTERUSUROKKU, ADD_StealthRock),
			new GET_FUNC_TABLE_ELEM(WazaNo.HANEYASUME, ADD_Haneyasume),
			new GET_FUNC_TABLE_ELEM(WazaNo.DENZIHUYUU, ADD_DenjiFuyuu),
			new GET_FUNC_TABLE_ELEM(WazaNo.RENZOKUGIRI, ADD_RenzokuGiri),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIKOSIHUTO, ADD_PsycoShift),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAMEOSI, ADD_Dameosi),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEKUSUTYAA2, ADD_Texture2),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAUNTAA, ADD_Counter),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIRAAKOOTO, ADD_MilerCoat),
			new GET_FUNC_TABLE_ELEM(WazaNo.METARUBAASUTO, ADD_MetalBurst),
			new GET_FUNC_TABLE_ELEM(WazaNo.RIBENZI, ADD_Revenge),
			new GET_FUNC_TABLE_ELEM(WazaNo.YUKINADARE, ADD_Revenge),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZYAIROBOORU, ADD_GyroBall),
			new GET_FUNC_TABLE_ELEM(WazaNo.ITAMIWAKE, ADD_Itamiwake),
			new GET_FUNC_TABLE_ELEM(WazaNo.KONOYUBITOMARE, ADD_KonoyubiTomare),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAYAMINOTANE, ADD_NayamiNoTane),
			new GET_FUNC_TABLE_ELEM(WazaNo.DENZIHA, ADD_Denjiha),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZIKOANZI, ADD_JikoAnji),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAATOSUWAPPU, ADD_HeartSwap),
			new GET_FUNC_TABLE_ELEM(WazaNo.PAWAASUWAPPU, ADD_PowerSwap),
			new GET_FUNC_TABLE_ELEM(WazaNo.GAADOSUWAPPU, ADD_GuardSwap),
			new GET_FUNC_TABLE_ELEM(WazaNo.MEROMERO, ADD_Meromero),
			new GET_FUNC_TABLE_ELEM(WazaNo.SABAKINOTUBUTE, ADD_SabakiNoTubute),
			new GET_FUNC_TABLE_ELEM(WazaNo.HATAKIOTOSU, ADD_Hatakiotosu),
			new GET_FUNC_TABLE_ELEM(WazaNo.KANASIBARI, ADD_Kanasibari),
			new GET_FUNC_TABLE_ELEM(WazaNo.DOROBOU, ADD_Dorobou),
			new GET_FUNC_TABLE_ELEM(WazaNo.HOSIGARU, ADD_Dorobou),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORIKKU, ADD_Trick),
			new GET_FUNC_TABLE_ELEM(WazaNo.SURIKAE, ADD_Trick),
			new GET_FUNC_TABLE_ELEM(WazaNo.MONOMANE, ADD_Monomane),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUKETTI, ADD_Sketch),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOBIHIZAGERI, ADD_Tobigeri),
			new GET_FUNC_TABLE_ELEM(WazaNo.KIRIBARAI, ADD_Kiribarai),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAWARAWARI, ADD_Kawarawari),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORIKKURUUMU, ADD_TrickRoom),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZYUUDEN, ADD_Juden),
			new GET_FUNC_TABLE_ELEM(WazaNo.HOROBINOUTA, ADD_HorobiNoUta),
			new GET_FUNC_TABLE_ELEM(WazaNo.YADORIGINOTANE, ADD_YadorigiNoTane),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUKURODATAKI, ADD_FukuroDataki),
			new GET_FUNC_TABLE_ELEM(WazaNo.AKUARINGU, ADD_AquaRing),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIKADUKINOMAI, ADD_MikadukiNoMai),
			new GET_FUNC_TABLE_ELEM(WazaNo.IYASINONEGAI, ADD_IyasiNoNegai),
			new GET_FUNC_TABLE_ELEM(WazaNo.YUBIWOHURU, ADD_YubiWoFuru),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIZENNOTIKARA, ADD_SizenNoTikara),
			new GET_FUNC_TABLE_ELEM(WazaNo.MANEKKO, ADD_Manekko),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEGOTO, ADD_Negoto),
			new GET_FUNC_TABLE_ELEM(WazaNo.KETAGURI, ADD_Ketaguri),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUSAMUSUBI, ADD_Ketaguri),
			new GET_FUNC_TABLE_ELEM(WazaNo.KIAIPANTI, ADD_KiaiPunch),
			new GET_FUNC_TABLE_ELEM(WazaNo.TAKUWAERU, ADD_Takuwaeru),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAKIDASU, ADD_Hakidasu),
			new GET_FUNC_TABLE_ELEM(WazaNo.NOMIKOMU, ADD_Nomikomu),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIRAIYOTI, ADD_Miraiyoti),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAMETUNONEGAI, ADD_HametuNoNegai),
			new GET_FUNC_TABLE_ELEM(WazaNo.RISAIKURU, ADD_Recycle),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEKONIKOBAN, ADD_NekoNiKoban),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAZIKKUKOOTO, ADD_MagicCoat),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEREPOOTO, ADD_Teleport),
			new GET_FUNC_TABLE_ELEM(WazaNo.TONBOGAERI, ADD_TonboGaeri),
			new GET_FUNC_TABLE_ELEM(WazaNo.BATONTATTI, ADD_BatonTouch),
			new GET_FUNC_TABLE_ELEM(WazaNo.TUIBAMU, ADD_Tuibamu),
			new GET_FUNC_TABLE_ELEM(WazaNo.MUSIKUI, ADD_Tuibamu),
			new GET_FUNC_TABLE_ELEM(WazaNo.HOOBARU, ADD_Hoobaru),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAGETUKERU, ADD_Nagetukeru),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAKITUKU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIMETUKERU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.HONOONOUZU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUNAZIGOKU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAGUMASUTOOMU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORABASAMI, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.UZUSIO, ADD_Uzusio),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOUSOKUSUPIN, ADD_KousokuSpin),
			new GET_FUNC_TABLE_ELEM(WazaNo.PAWAATORIKKU, ADD_PowerTrick),
			new GET_FUNC_TABLE_ELEM(WazaNo.HENSIN, ADD_Hensin),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAIBAKUHATU, ADD_Daibakuhatsu),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZIBAKU, ADD_Daibakuhatsu),
			new GET_FUNC_TABLE_ELEM(WazaNo.KIAIDAME, ADD_Kiaidame),
			new GET_FUNC_TABLE_ELEM(WazaNo.GENSINOTIKARA, ADD_GensiNoTikara),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAMINARI, ADD_Kaminari),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUBUKI, ADD_Fubuki),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZETTAIREIDO, ADD_ZettaiReido),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEGAIGOTO, ADD_Negaigoto),
			new GET_FUNC_TABLE_ELEM(WazaNo.SEITYOU, ADD_Seityou),
			new GET_FUNC_TABLE_ELEM(WazaNo.DOKUDOKU, ADD_Dokudoku),
			new GET_FUNC_TABLE_ELEM(WazaNo.BENOMUSYOKKU, ADD_BenomShock),
			new GET_FUNC_TABLE_ELEM(WazaNo.IKARINOKONA, ADD_Ikarinokona),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIZUBITASI, ADD_Mizubitasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.SINPURUBIIMU, ADD_SimpleBeem),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAKAMADUKURI, ADD_NakamaDukuri),
			new GET_FUNC_TABLE_ELEM(WazaNo.KURIASUMOGGU, ADD_ClearSmog),
			new GET_FUNC_TABLE_ELEM(WazaNo.ASISUTOPAWAA, ADD_AsistPower),
			new GET_FUNC_TABLE_ELEM(WazaNo.TUKEAGARU, ADD_AsistPower),
			new GET_FUNC_TABLE_ELEM(WazaNo.KARAWOYABURU, ADD_KarawoYaburu),
			new GET_FUNC_TABLE_ELEM(WazaNo.TATARIME, ADD_Tatarime),
			new GET_FUNC_TABLE_ELEM(WazaNo.AKUROBATTO, ADD_Acrobat),
			new GET_FUNC_TABLE_ELEM(WazaNo.BORUTOTHENZI, ADD_TonboGaeri),
			new GET_FUNC_TABLE_ELEM(WazaNo.WAIDOGAADO, ADD_WideGuard),
			new GET_FUNC_TABLE_ELEM(WazaNo.TATAMIGAESI, ADD_TatamiGaeshi),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIRAATAIPU, ADD_MirrorType),
			new GET_FUNC_TABLE_ELEM(WazaNo.PAWAASHEA, ADD_PowerShare),
			new GET_FUNC_TABLE_ELEM(WazaNo.GAADOSHEA, ADD_GuardShare),
			new GET_FUNC_TABLE_ELEM(WazaNo.BODHIPAAZI, ADD_BodyPurge),
			new GET_FUNC_TABLE_ELEM(WazaNo.HEBIIBONBAA, ADD_HeavyBomber),
			new GET_FUNC_TABLE_ELEM(WazaNo.HIITOSUTANPU, ADD_HeatStamp),
			new GET_FUNC_TABLE_ELEM(WazaNo.WANDAARUUMU, ADD_WonderRoom),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAZIKKURUUMU, ADD_MagicRoom),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIKOSYOKKU, ADD_PsycoShock),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIKOBUREIKU, ADD_PsycoShock),
			new GET_FUNC_TABLE_ELEM(WazaNo.EREKIBOORU, ADD_ElectBall),
			new GET_FUNC_TABLE_ELEM(WazaNo.SEINARUTURUGI, ADD_NasiKuzusi),
			new GET_FUNC_TABLE_ELEM(WazaNo.ddRARIATTO, ADD_NasiKuzusi),
			new GET_FUNC_TABLE_ELEM(WazaNo.EKOOBOISU, ADD_EchoVoice),
			new GET_FUNC_TABLE_ELEM(WazaNo.YAKITUKUSU, ADD_Yakitukusu),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOMOENAGE, ADD_TomoeNage),
			new GET_FUNC_TABLE_ELEM(WazaNo.DORAGONTEERU, ADD_TomoeNage),
			new GET_FUNC_TABLE_ELEM(WazaNo.KATAKIUTI, ADD_Katakiuti),
			new GET_FUNC_TABLE_ELEM(WazaNo.IKASAMA, ADD_Ikasama),
			new GET_FUNC_TABLE_ELEM(WazaNo.BODHIPURESU, ADD_BodyPress),
			new GET_FUNC_TABLE_ELEM(WazaNo.UTIOTOSU, ADD_Utiotosu),
			new GET_FUNC_TABLE_ELEM(WazaNo.INOTIGAKE, ADD_Inotigake),
			new GET_FUNC_TABLE_ELEM(WazaNo.OSAKINIDOUZO, ADD_OsakiniDouzo),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAKIOKURI, ADD_Sakiokuri),
			new GET_FUNC_TABLE_ELEM(WazaNo.RINSYOU, ADD_Rinsyou),
			new GET_FUNC_TABLE_ELEM(WazaNo.FASUTOGAADO, ADD_FastGuard),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIDOTHENZI, ADD_SideChange),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOOTOTHENZI, ADD_CourtChange),
			new GET_FUNC_TABLE_ELEM(WazaNo.BOUHUU, ADD_Kaminari),
			new GET_FUNC_TABLE_ELEM(WazaNo.SINPINOTURUGI, ADD_PsycoShock),
			new GET_FUNC_TABLE_ELEM(WazaNo.INISIENOUTA, ADD_InisieNoUta),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEKUNOBASUTAA, ADD_TechnoBaster),
			new GET_FUNC_TABLE_ELEM(WazaNo.HURIIZUBORUTO, ADD_FreezeBolt),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOORUDOHUREA, ADD_FreezeBolt),
			new GET_FUNC_TABLE_ELEM(WazaNo.MIZUNOTIKAI, ADD_CombiWazaCommon),
			new GET_FUNC_TABLE_ELEM(WazaNo.HONOONOTIKAI, ADD_CombiWazaCommon),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUSANOTIKAI, ADD_CombiWazaCommon),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUROSUHUREIMU, ADD_FlameSoul),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUROSUSANDAA, ADD_FlameSoul),
			new GET_FUNC_TABLE_ELEM(WazaNo.NETTOU, ADD_Nettou),
			new GET_FUNC_TABLE_ELEM(WazaNo.UTAKATANOARIA, ADD_UtakatanoAria),
			new GET_FUNC_TABLE_ELEM(WazaNo.DORAGONDAIBU, ADD_Fumituke),
			new GET_FUNC_TABLE_ELEM(WazaNo.NOSIKAKARI, ADD_Fumituke),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAROWHIN, ADD_Halloween),
			new GET_FUNC_TABLE_ELEM(WazaNo.MORINONOROI, ADD_Morinonoroi),
			new GET_FUNC_TABLE_ELEM(WazaNo.HIKKURIKAESU, ADD_Hikkurikaesu),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUTEZERIHU, ADD_SuteZerifu),
			new GET_FUNC_TABLE_ELEM(WazaNo.HURAWAAGAADO, ADD_FlowerGuard),
			new GET_FUNC_TABLE_ELEM(WazaNo.TODOMEBARI, ADD_TodomeBari),
			new GET_FUNC_TABLE_ELEM(WazaNo.NEBANEBANETTO, ADD_NebaNebaNet),
			new GET_FUNC_TABLE_ELEM(WazaNo.GURASUFIIRUDO, ADD_GrassField),
			new GET_FUNC_TABLE_ELEM(WazaNo.MISUTOFIIRUDO, ADD_MistField),
			new GET_FUNC_TABLE_ELEM(WazaNo.HURAINGUPURESU, ADD_FlyingPress),
			new GET_FUNC_TABLE_ELEM(WazaNo.GOOSUTODAIBU, ADD_ShadowDive),
			new GET_FUNC_TABLE_ELEM(WazaNo.HURIIZUDORAI, ADD_FreezDry),
			new GET_FUNC_TABLE_ELEM(WazaNo.SOUDEN, ADD_Souden),
			new GET_FUNC_TABLE_ELEM(WazaNo.KINGUSIIRUDO, ADD_KingShield),
			new GET_FUNC_TABLE_ELEM(WazaNo.BUROKKINGU, ADD_Blocking),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAUZANWHEEBU, ADD_SouthernWave),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAUZANAROO, ADD_ThousanArrow),
			new GET_FUNC_TABLE_ELEM(WazaNo.EREKIFIIRUDO, ADD_ElecField),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAPPIITAIMU, ADD_HappyTime),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZIBASOUSA, ADD_ZibaSousa),
			new GET_FUNC_TABLE_ELEM(WazaNo.ASISUTOGIA, ADD_ZibaSousa),
			new GET_FUNC_TABLE_ELEM(WazaNo.BENOMUTORAPPU, ADD_BenomTrap),
			new GET_FUNC_TABLE_ELEM(WazaNo.IZIGENHOORU, ADD_IjigenHall),
			new GET_FUNC_TABLE_ELEM(WazaNo.FEARIIROKKU, ADD_FairyLock),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUNZIN, ADD_Funjin),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZIOKONTOROORU, ADD_GeoControl),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORIKKUGAADO, ADD_TrickGuard),
			new GET_FUNC_TABLE_ELEM(WazaNo.NIIDORUGAADO, ADD_NeedleGuard),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEKAGEN, ADD_Mineuti),
			new GET_FUNC_TABLE_ELEM(WazaNo.MATOWARITUKU, ADD_Makituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUTIIMUBAASUTO, ADD_Nettou),
			new GET_FUNC_TABLE_ELEM(WazaNo.OIWAI, ADD_Oiwai),
			new GET_FUNC_TABLE_ELEM(WazaNo.TEWOTUNAGU, ADD_TeWoTunagu),
			new GET_FUNC_TABLE_ELEM(WazaNo.HOERU, ADD_Hoeru),
			new GET_FUNC_TABLE_ELEM(WazaNo.HUKITOBASI, ADD_Hoeru),
			new GET_FUNC_TABLE_ELEM(WazaNo.IZIGENRASSYU, ADD_IjigenRush),
			new GET_FUNC_TABLE_ELEM(WazaNo.OORAGURUMA, ADD_AuraGuruma),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUNAATUME, ADD_Sunaatume),
			new GET_FUNC_TABLE_ELEM(WazaNo.HURAWAAHIIRU, ADD_FlowerHeal),
			new GET_FUNC_TABLE_ELEM(WazaNo.DEAIGASIRA, ADD_Deaigasira),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOOTIKA, ADD_Tootika),
			new GET_FUNC_TABLE_ELEM(WazaNo.MEZAMERUDANSU, ADD_MezameruDance),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAHUNDANGO, ADD_Kahundango),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOAPANISSYAA, ADD_CorePunisher),
			new GET_FUNC_TABLE_ELEM(WazaNo.KAGENUI, ADD_Kagenui),
			new GET_FUNC_TABLE_ELEM(WazaNo.ANKAASYOTTO, ADD_Kagenui),
			new GET_FUNC_TABLE_ELEM(WazaNo.KURAITUKU, ADD_Kuraituku),
			new GET_FUNC_TABLE_ELEM(WazaNo.TAKOGATAME, ADD_TakoGatame),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZYOUKA, ADD_Zyouka),
			new GET_FUNC_TABLE_ELEM(WazaNo.TIKARAWOSUITORU, ADD_Tikarawosuitoru),
			new GET_FUNC_TABLE_ELEM(WazaNo.TOGISUMASU, ADD_Togisumasu),
			new GET_FUNC_TABLE_ELEM(WazaNo.SUPIIDOSUWAPPU, ADD_SpeedSwap),
			new GET_FUNC_TABLE_ELEM(WazaNo.MOETUKIRU, ADD_Moetukiru),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIKOFIIRUDO, ADD_PhychoField),
			new GET_FUNC_TABLE_ELEM(WazaNo.KUTIBASIKYANON, ADD_KutibasiCanon),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIKOFANGU, ADD_Kawarawari),
			new GET_FUNC_TABLE_ELEM(WazaNo.TORAPPUSHERU, ADD_TrapShell),
			new GET_FUNC_TABLE_ELEM(WazaNo.ZIDANDA, ADD_Zidanda),
			new GET_FUNC_TABLE_ELEM(WazaNo.OORORABEERU, ADD_AuroraVeil),
			new GET_FUNC_TABLE_ELEM(WazaNo.SAIHAI, ADD_Saihai),
			new GET_FUNC_TABLE_ELEM(WazaNo.NAINEBORUBUUSUTO, ADD_GensiNoTikara),
			new GET_FUNC_TABLE_ELEM(WazaNo.METEODORAIBU, ADD_MeteorDrive),
			new GET_FUNC_TABLE_ELEM(WazaNo.SYADOOREI, ADD_MeteorDrive),
			new GET_FUNC_TABLE_ELEM(WazaNo.SIZENNOIKARI, ADD_IkariNoMaeba),
			new GET_FUNC_TABLE_ELEM(WazaNo.MARUTIATAKKU, ADD_MultiAttack),
			new GET_FUNC_TABLE_ELEM(WazaNo.SYADOOSUTIIRU, ADD_ShadowSteal),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAAKUHOORU, ADD_DarkHole),
			new GET_FUNC_TABLE_ELEM(WazaNo.PURAZUMAFISUTO, ADD_PlasmaFist),
			new GET_FUNC_TABLE_ELEM(WazaNo.FOTONGEIZAA, ADD_PhotonGeyser),
			new GET_FUNC_TABLE_ELEM(WazaNo.BIKKURIHEDDO, ADD_Hanabisenyou),
			new GET_FUNC_TABLE_ELEM(WazaNo.KOROKOROWAZA, ADD_Hanabisenyou),
			new GET_FUNC_TABLE_ELEM(WazaNo.DAIWHOORU, ADD_DaiWall),
			new GET_FUNC_TABLE_ELEM(WazaNo.NERAIUTI, ADD_NeraiUti),
			new GET_FUNC_TABLE_ELEM(WazaNo.HAISUINOZIN, ADD_HaisuiNoJin),
			new GET_FUNC_TABLE_ELEM(WazaNo.SOURUBIITO, ADD_SoulBeat),
			new GET_FUNC_TABLE_ELEM(WazaNo.MAHOUNOKONA, ADD_MahouNoKona),
			new GET_FUNC_TABLE_ELEM(WazaNo.OTYAKAI, ADD_Ochakai),
			new GET_FUNC_TABLE_ELEM(WazaNo.DENGEKIKUTIBASI, ADD_DengekiKutibasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.ERAGAMI, ADD_DengekiKutibasi),
			new GET_FUNC_TABLE_ELEM(WazaNo.TAARUSYOTTO, ADD_TarShot),
			new GET_FUNC_TABLE_ELEM(WazaNo.DORAGONAROO, ADD_DragonArrow),
			new GET_FUNC_TABLE_ELEM(WazaNo.INOTINOSIZUKU, ADD_InotiNoSizuku),
			new GET_FUNC_TABLE_ELEM(WazaNo.NYUUTON, ADD_Newton),
        };

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Texture = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Texture),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickRoom = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_TrickRoom),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juryoku = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_Juryoku),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kiribarai = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Kiribarai),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kawarawari = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_Kawarawari_DmgProc1),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_END, handler_Kawarawari_DmgProcEnd),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_Kawarawari_DmgDetermine),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tobigeri = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_NO_EFFECT, handler_Tobigeri_NoEffect),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Monomane = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Monomane),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sketch = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Sketch),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KonoyubiTomare = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_KonoyubiTomare_ExeCheck),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KonoyubiTomare_Exe),
			new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_KonoyubiTomare_TemptTarget),
			new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_KonoyubiTomare_TurnCheck),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikarinokona = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_KonoyubiTomare_ExeCheck),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KonoyubiTomare_Exe),
			new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_Ikarinokona_TemptTarget),
			new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_KonoyubiTomare_TurnCheck),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KumoNoSu = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
			new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_KumoNoSu_NoEffCheck),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KumoNoSu),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuroiKiri = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_KuroiKiri),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haneru = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Haneru_CheckFail),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Haneru),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oiwai = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Oiwai),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TeWoTunagu = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_TeWoTunagu),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Noroi = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_Noroi_WazaParam),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Noroi),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Noroi_ExeCheck3rd_FailToGWall),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Denjiha = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ENABLE, handler_Denjiha),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NayamiNoTane = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
			new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_NayamiNoTane_NoEff),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_NayamiNoTane),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yumekui = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_Yumekui),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TriAttack = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_TriAttack),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nettou = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Nettou),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UtakatanoAria = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_UtakatanoAria),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Osyaberi = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_Osyaberi),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makituku = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_Makituku),
			new EventFactor.EventHandlerTable(EventID.WAZASICK_STR, handler_Makituku_Str),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Uzusio = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_Makituku),
			new EventFactor.EventHandlerTable(EventID.WAZASICK_STR, handler_Makituku_Str),
			new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Uzusio_CheckHide),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Uzusio_Dmg),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IkariNoMaeba = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_IkariNoMaeba),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gamusyara = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_Gamusyara_CheckNoEffect),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_Gamusyara),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TikyuuNage = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_TikyuuNage),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Takuwaeru = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Takuwaeru_CheckExe),
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Takuwaeru),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hakidasu = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Hakidasu_CheckExe),
			new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Hakidasu_Pow),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_Hakidasu_Done),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nomikomu = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Hakidasu_CheckExe),
			new EventFactor.EventHandlerTable(EventID.RECOVER_HP_RATIO, handler_Nomikomu_Ratio),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_Hakidasu_Done),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Counter = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Counter_CheckExe),
			new EventFactor.EventHandlerTable(EventID.DECIDE_TARGET, handler_Counter_Target),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_Counter_CalcDamage),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MilerCoat = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_MilerCoat_CheckExe),
			new EventFactor.EventHandlerTable(EventID.DECIDE_TARGET, handler_MilerCoat_Target),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_MilerCoat_CalcDamage),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MetalBurst = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_MetalBurst_CheckExe),
			new EventFactor.EventHandlerTable(EventID.DECIDE_TARGET, handler_MetalBurst_Target),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_MetalBurst_CalcDamage),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Totteoki = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Totteoki),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ibiki = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_FAIL_THREW, handler_Ibiki_CheckFail_1),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Ibiki_CheckFail_2),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuiuti = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Fuiuti_NoEff),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Daibakuhatsu = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Daibakuhatsu_ExeStart),
			new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_Daibakuhatsu_DmgDetermine),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_Daibakuhatsu_ExeFix),
			new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kiaidame = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Kiaidame),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juden = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Juden_Exe),
			new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Juden_WazaStart),
			new EventFactor.EventHandlerTable(EventID.CHECK_REMOVEALL_CANCEL, handler_Juden_RemoveAllTarget),
			new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Juden_Pow),
			new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Juden_WazaEnd),
		};

        private const int JUDEN_STAT_NONE = 0;
		private const int JUDEN_STAT_START = 1;
		private const int JUDEN_STAT_WAZA = 2;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HorobiNoUta = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidPlayerSide),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_HorobiNoUta_Exe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YadorigiNoTane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASICK_PARAM, handler_YadorigiNoTane_Param),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NekoNiKoban = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_NekoNiKoban),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AquaRing = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_AquaRing),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Abareru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Abareru),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Abareru_SeqEnd),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Abareru_turnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sawagu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_Sawagu),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Sawagu_SeqEnd),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Sawagu_turnCheck),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Sawagu_CheckSickFail),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_Sawagu_CheckInemuri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Korogaru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Korogaru_ExeFix),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Korogaru_NoEffect),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_NO_EFFECT, handler_Korogaru_NoEffect),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Korogaru_SeqEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Korogaru_Pow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TripleKick = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_TripleKick),
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_COUNT, handler_TripleKick_HitCount),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GyroBall = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_GyroBall),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Revenge = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Revenge),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jitabata = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Jitabata),
        };

		private static readonly handler_JitabataTableElem[] handler_JitabataTable = new handler_JitabataTableElem[]
		{
			new handler_JitabataTableElem(1,  200),
			new handler_JitabataTableElem(4,  150),
			new handler_JitabataTableElem(9,  100),
			new handler_JitabataTableElem(16, 80),
			new handler_JitabataTableElem(32, 40),
			new handler_JitabataTableElem(48, 20),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Karagenki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Karagenki_AtkPow),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Karagenki_WazaPow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sippegaesi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Sippegaesi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Funka = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Funka),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Siboritoru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Siboritoru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Siomizu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Siomizu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RenzokuGiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_RenzokuGiri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dameosi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Dameosi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ketaguri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToG),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Ketaguri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_WeatherBall = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_WeatherBall_Type),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_WeatherBall_Pow),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_WeatherBall_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tatumaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Tatumaki_checkHide),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Tatumaki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kaminari = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Kaminari_checkHide),
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Kaminari_excuseHitCalc),
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Kaminari_hitRatio),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fubuki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Fubuki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZettaiReido = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO_ICHIGEKI, handler_ZettaiReido_hitRatio),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jisin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Jisin_checkHide),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Jisin_damage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SabakiNoTubute = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_SabakiNoTubute),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MultiAttack = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_MultiAttack),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_MultiAttack_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TechnoBaster = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_TechnoBaster),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_TechnoBaster_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MezameruPower = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_MezameruPower_Type),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hatakiotosu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Hatakiotosu_WazaPow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Hatakiotosu_EndHit),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicCoat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_MagicCoat_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_MagicCoat),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_MagicCoat_Wait),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_REFRECT, handler_MagicCoat_Reflect),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_MagicCoat_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dorobou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_Dorobou_Start),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Dorobou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Trick = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Trick),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Naminori = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Naminori_checkHide),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Naminori),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fumituke = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Fumituke_HitCheckSkip),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Fumituke_DamegeProc),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DaiMaxHou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_DaiMaxHou_DamegeProc),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mineuti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.KORAERU_CHECK, handler_Mineuti),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Koraeru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Koraeru),
            new EventFactor.EventHandlerTable(EventID.KORAERU_CHECK, handler_Koraeru_Check),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Koraeru_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mamoru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Mamoru),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G, handler_Mamoru_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL, handler_Mamoru_MsgAfterCritical),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };

		private static readonly ushort[] WazaTable_Mamoru = new ushort[]
		{
            (ushort)WazaNo.MAMORU,      (ushort)WazaNo.MIKIRI,       (ushort)WazaNo.KORAERU,      (ushort)WazaNo.WAIDOGAADO,
            (ushort)WazaNo.FASUTOGAADO, (ushort)WazaNo.NIIDORUGAADO, (ushort)WazaNo.KINGUSIIRUDO, (ushort)WazaNo.TATAMIGAESI,
            (ushort)WazaNo.TOOTIKA,     (ushort)WazaNo.DAIWHOORU,    (ushort)WazaNo.BUROKKINGU,
        };

		private static readonly ushort[] RandRangeTable_Mamoru = new ushort[]
		{
            1, 3, 9, 27, 81, 243, 729
        };

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Recycle = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Recycle),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PsycoShift = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_PsycoShift),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Itamiwake = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Itamiwake),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haradaiko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Haradaiko),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Feint = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_MAMORU_BREAK, handler_Feint_MamoruBreak),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_BEGIN, handler_Feint_NoEffCheckBegin),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_END, handler_Feint_NoEffCheckEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_Feint_AfterDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IjigenHall = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_MAMORU_BREAK, handler_Feint_MamoruBreak),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_BEGIN, handler_Feint_NoEffCheckBegin),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_END, handler_Feint_NoEffCheckEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_IjigenHall_AfterDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TuboWoTuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_TuboWoTuku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nemuru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Nemuru_exeCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Nemuru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Meromero = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_Meromero_CheckNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Texture2 = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Texture2),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Encore = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Encore),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Chouhatu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Chouhatu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kanasibari = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Kanasibari),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Present = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DMG_TO_RECOVER_CHECK, handler_Present_Check),
            new EventFactor.EventHandlerTable(EventID.DMG_TO_RECOVER_FIX, handler_Present_Fix),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Present_Pow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuuin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Fuuin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Alomatherapy = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_DECIDE, handler_Alomatherapy_Exe),
            new EventFactor.EventHandlerTable(EventID.CHECK_REMOVEALL_CANCEL, handler_IyasiNoSuzu_RemoveAllTarget),
            new EventFactor.EventHandlerTable(EventID.SKIP_AVOID_CHECK, handler_Tedasuke_SkipAvoid),
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Tedasuke_CheckHide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Alomatherapy),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoSuzu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_DECIDE, handler_IyasiNoSuzu_Exe),
            new EventFactor.EventHandlerTable(EventID.CHECK_REMOVEALL_CANCEL, handler_IyasiNoSuzu_RemoveAllTarget),
            new EventFactor.EventHandlerTable(EventID.SKIP_AVOID_CHECK, handler_Tedasuke_SkipAvoid),
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Tedasuke_CheckHide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_IyasiNoSuzu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Okimiyage = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Okimiyage),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Urami = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Urami),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JikoAnji = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_JikoAnji),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeartSwap = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_HeartSwap),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerSwap = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_PowerSwap),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GuardSwap = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_GuardSwap),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerTrick = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_PowerTrick),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerShare = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_PowerShare),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GuardShare = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_GuardShare),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_LockON = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_LockON),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokudoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Dokudoku),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_Dokudoku_Done),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Reflector = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_Reflector),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikariNoKabe = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_HikariNoKabe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinpiNoMamori = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_SinpiNoMamori),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SiroiKiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_SiroiKiri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oikaze = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_Oikaze),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makibisi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_Makibisi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubisi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_Dokubisi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_StealthRock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NebaNebaNet = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_NebaNebaNet),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_WideGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_WideGuard_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_WideGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TatamiGaeshi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_TatamiGaeshi_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_TatamiGaeshi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hensin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Hensin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MikadukiNoMai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_MikadukiNoMai),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoNegai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_IyasiNoNegai),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Negaigoto = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Negaigoto),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Miraiyoti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_DELAY_WAZA, handler_Miraiyoti),
            new EventFactor.EventHandlerTable(EventID.DECIDE_DELAY_WAZA, handler_Miraiyoti_Decide),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HametuNoNegai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_DELAY_WAZA, handler_HametuNoNegai),
            new EventFactor.EventHandlerTable(EventID.DECIDE_DELAY_WAZA, handler_HametuNoNegai_Decide),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ieki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Ieki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Narikiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Narikiri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TonboGaeri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L4, handler_TonboGaeri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KousokuSpin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZADMG_SIDE_AFTER, handler_KousokuSpin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BatonTouch = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_BatonTouch),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Teleport = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Teleport),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Teleport_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.NIGERU_EXMSG, handler_Teleport_ExMsg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nagetukeru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Nagetukeru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Nagetukeru_WazaPower),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_Nagetukeru_DmgProcStart),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Nagetukeru_DmgAfter),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_DONE, handler_Nagetukeru_Done),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenjiFuyuu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_DenjiFuyuu_CheckFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_DenjiFuyuu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tedasuke = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SKIP_AVOID_CHECK, handler_Tedasuke_SkipAvoid),
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Tedasuke_CheckHide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Tedasuke_Ready),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Tedasuke_WazaPow),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Tedasuke_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FukuroDataki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_COUNT, handler_FukuroDataki),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_FukuroDataki_Pow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nekodamasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Nekodamasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Deaigasira = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Deaigasira),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AsaNoHizasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RECOVER_HP_RATIO, handler_AsaNoHizasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunaatume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RECOVER_HP_RATIO, handler_Sunaatume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerHeal = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RECOVER_HP_RATIO, handler_FlowerHeal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoraWoTobu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_SoraWoTobu_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ShadowDive = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_ShadowDive_TameStart),
            new EventFactor.EventHandlerTable(EventID.CHECK_MAMORU_BREAK, handler_Feint_MamoruBreak),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_BEGIN, handler_Feint_NoEffCheckBegin),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_END, handler_Feint_NoEffCheckEnd),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L1, handler_ShadowDive_AfterDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tobihaneru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_Tobihaneru_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Diving = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_Diving_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AnaWoHoru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_AnaWoHoru_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SolarBeam = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_TAMETURN_SKIP, handler_SolarBeam_TameSkip),
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_SolarBeam_TameStart),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SolarBeam_Power),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GodBird = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_GodBird_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_RocketZutuki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START_FIXED, handler_RocketZutuki_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tuibamu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Tuibamu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hoobaru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Hoobaru),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_Hoobaru_Decide),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Waruagaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_CALL_DECIDE, handler_Waruagaki_SeqStart),
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_Waruagaki_WazaParam),
            new EventFactor.EventHandlerTable(EventID.CALC_KICKBACK, handler_Waruagaki_KickBack),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Michidure = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidPlayerSide),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Michidure_CheckFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Michidure_Ready),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_START, handler_Michidure_ActStart),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_Michidure_WazaDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Onnen = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Onnen_Ready),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Onnen_WazaDamage),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_START, handler_Onnen_ActStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tiisakunaru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Tiisakunaru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Marukunaru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Marukunaru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haneyasume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_Haneyasume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KiaiPunch = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.BEFORE_FIGHT, handler_KiaiPunch),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_YubiWoFuru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.REQWAZA_PARAM, handler_YubiWoFuru),
            new EventFactor.EventHandlerTable(EventID.REQWAZA_MSG, handler_YubiWoFuru_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SizenNoTikara = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.REQWAZA_PARAM, handler_SizenNoTikara),
            new EventFactor.EventHandlerTable(EventID.REQWAZA_MSG, handler_SizenNoTikara_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Negoto = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_FAIL_THREW, handler_Ibiki_CheckFail_1),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Ibiki_CheckFail_2),
            new EventFactor.EventHandlerTable(EventID.REQWAZA_PARAM, handler_Negoto),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Manekko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.REQWAZA_PARAM, handler_Manekko_CheckParam),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GensiNoTikara = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_GensiNoTikara),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BenomShock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_BenomShock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tatarime = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Tatarime),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Acrobat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Acrobat),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AsistPower = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_AsistPower),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeavyBomber = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToG),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidBoss),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_HeavyBomber),
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Fumituke_HitCheckSkip),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Fumituke_DamegeProc),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeatStamp = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToG),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidBoss),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_HeavyBomber),
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Fumituke_HitCheckSkip),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Fumituke_DamegeProc),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElectBall = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_ElectBall),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_EchoVoice = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_EchoVoice),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katakiuti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Katakiuti),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikasama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER_PREV, handler_Ikasama),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BodyPress = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER_VID, handler_BodyPress),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mizubitasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Mizubitasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MahouNoKona = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_MahouNoKona),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SimpleBeem = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_SimpleBeem),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NakamaDukuri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_NakamaDukuri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ClearSmog = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_ClearSmog),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yakitukusu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_Yakitukusu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TomoeNage = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_TomoeNage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hoeru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.PUSHOUT_EFFECT_NO, handler_Hoeru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Utiotosu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Utiotosu),
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Kaminari_checkHide),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KarawoYaburu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KarawoYaburu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MirrorType = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_MirrorType),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BodyPurge = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_RANKEFF_FIXED, handler_BodyPurge),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PsycoShock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD_PREV, handler_PsycoShock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NasiKuzusi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD_PREV, handler_NasiKuzusi_CalcDmg),
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RANK, handler_NasiKuzusi_HitCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_WonderRoom = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_WonderRoom),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicRoom = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_MagicRoom),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Inotigake = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC1, handler_Inotigake_CalcDamage),
            new EventFactor.EventHandlerTable(EventID.CHECK_ATTACKER_DEAD, handler_Inotigake_CheckDead),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OsakiniDouzo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_OsakiniDouzo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sakiokuri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Sakiokuri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rinsyou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Rinsyou),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Rinsyou_Pow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FastGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_WideGuard_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_FastGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SideChange = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidPlayerSide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_SideChange),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_CourtChange = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_CourtChange),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_InisieNoUta = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L2, handler_InisieNoUta),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seityou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_Seityou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezeBolt = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_FreezeBolt_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlameSoul = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_FlameSoul_Pow),
        };

		private static readonly GetCombiWazaTypeTableElem[] CombiTbl = new GetCombiWazaTypeTableElem[]
		{
			new GetCombiWazaTypeTableElem(WazaNo.MIZUNOTIKAI, WazaNo.HONOONOTIKAI, CombiEffectType.COMBI_EFFECT_RAINBOW),
			new GetCombiWazaTypeTableElem(WazaNo.KUSANOTIKAI, WazaNo.HONOONOTIKAI, CombiEffectType.COMBI_EFFECT_BURNING),
			new GetCombiWazaTypeTableElem(WazaNo.MIZUNOTIKAI, WazaNo.KUSANOTIKAI,  CombiEffectType.COMBI_EFFECT_MOOR),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_CombiWazaCommon = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.COMBIWAZA_CHECK, handler_CombiWaza_CheckExe),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_DECIDE, handler_CombiWaza_Decide),
            new EventFactor.EventHandlerTable(EventID.TYPEMATCH_CHECK, handler_CombiWaza_TypeMatch),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_CombiWaza_Pow),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_CombiWaza_ChangeEff),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L2, handler_CombiWaza_AfterDmg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Halloween = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Halloween),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Morinonoroi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Morinonoroi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Tagayasu_CheckHide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_FlowerGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TodomeBari = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_TodomeBari),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KogoeruHadou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_KogoeruHadou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hikkurikaesu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Hikkurikaesu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeraiPunch = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_NeraiPunch),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SuteZerifu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNDAMAGEPROC_END, handler_TonboGaeri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlyingPress = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY, handler_FlyingPress),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_FlyingPress),
            new EventFactor.EventHandlerTable(EventID.CALC_HIT_CANCEL, handler_Fumituke_HitCheckSkip),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Fumituke_DamegeProc),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezDry = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY, handler_FreezDry),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_FreezDry),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Souden = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaidPlayerSide),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Souden),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GrassField = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_GrassField),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MistField = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_MistField),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecField = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_ElecField),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhychoField = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_PhychoField),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KingShield = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KingShield),
            new EventFactor.EventHandlerTable(EventID.MAMORU_SUCCESS, handler_KingShield_Success),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G, handler_Mamoru_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL, handler_KingShield_MsgAfterCritical),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_KingShield_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Blocking = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_KingShield),
            new EventFactor.EventHandlerTable(EventID.MAMORU_SUCCESS, handler_Blocking_Success),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G, handler_Mamoru_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL, handler_KingShield_MsgAfterCritical),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_Blocking_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ThousanArrow = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.AFFINE_FLOATING_CANCEL, handler_ThousanArrow_CancelFloat),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ENABLE, handler_ThousanArrow_AffEnable),
            new EventFactor.EventHandlerTable(EventID.REWRITE_AFFINITY, handler_ThousanArrow_CheckAffine),
            new EventFactor.EventHandlerTable(EventID.CHECK_POKE_HIDE, handler_Kaminari_checkHide),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_ThousanArrow),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HappyTime = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_HappyTime),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZibaSousa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_ZibaSousa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BenomTrap = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_BenomTrap),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PlasmaFist = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L1, handler_PlasmaFist),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairyLock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FIELD_EFFECT_CALL, handler_FairyLock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Funjin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Funjin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GeoControl = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TAME_START, handler_GeoControl_TameStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_WideGuard_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_TrickGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeedleGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Mamoru),
            new EventFactor.EventHandlerTable(EventID.MAMORU_SUCCESS, handler_NeedleGuard_Success),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G, handler_Mamoru_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL, handler_KingShield_MsgAfterCritical),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_NeedleGuard_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SouthernWave = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_southernWave),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IjigenRush = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_IjigenRush),
            new EventFactor.EventHandlerTable(EventID.CHECK_MAMORU_BREAK, handler_Feint_MamoruBreak),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_BEGIN, handler_Feint_NoEffCheckBegin),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_SIDEEFF_GUARD_END, handler_Feint_NoEffCheckEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_IjigenRush_AfterDamage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuraGuruma = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_AuraGuruma),
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_AuraGuruma_Waza),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_AuraGuruma_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DarkHole = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_DarkHole),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tootika = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Mamoru),
            new EventFactor.EventHandlerTable(EventID.MAMORU_SUCCESS, handler_Tootika_Success),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC_G, handler_Mamoru_Dmg),
            new EventFactor.EventHandlerTable(EventID.AFTER_CRITICAL, handler_KingShield_MsgAfterCritical),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_L2, handler_Tootika_DmgReaction),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MezameruDance = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_MezameruDance_WazaParam),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kahundango = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_Kahundango_ExecuteCheck),
            new EventFactor.EventHandlerTable(EventID.DMG_TO_RECOVER_CHECK, handler_Kahundango_RecoverCheck),
            new EventFactor.EventHandlerTable(EventID.DMG_TO_RECOVER_FIX, handler_Kahundango_RecoverFix),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_Kahundango_Check_Affinity),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_CorePunisher = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_PREV, handler_CorePunisher_HitReal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kagenui = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Kagenui_HitReal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kuraituku = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Kuraituku),
		};
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TakoGatame = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_TakoGatame_NoEffCheck),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_takoGatame),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zyouka = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Zyouka),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikarawosuitoru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Tikarawosuitoru),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Togisumasu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Togisumasu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SpeedSwap = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_SpeedSwap),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moetukiru = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.FAIL_WAZAMELT_CHECK, handler_Moetukiru_WazaMeltCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_Moetukiru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Moetukiru_DamageProcEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KutibasiCanon = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.BEFORE_FIGHT, handler_KutibasiCanon_BeforeFight),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_KutibasiCanon_DamageReaction),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_KutibasiCanon_WazaSeqEnd),
            new EventFactor.EventHandlerTable(EventID.REPLACE_ACT_WAZA, handler_KutibasiCanon_ReplaceWaza),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_CANCELED, handler_KutibasiCanon_Canceled),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_KutibasiCanon_ExeCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrapShell = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.BEFORE_FIGHT, handler_TrapShell_BeforeFight),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L5, handler_TrapShell_DamageProcEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_TrapShell_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_TrapShell_WazaEnd),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_CANCELED, handler_KutibasiCanon_Canceled),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zidanda = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_Zidanda_Dmg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuroraVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_AuroraVeil_CheckExe),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA_NO_TARGET, handler_AuroraVeil),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Saihai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_common_ExeCheck3rd_FailToGWall),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Saihai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MeteorDrive = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_MeteorDrive_WazaSeqStart),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_MeteorDrive_WazaSeqEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ShadowSteal = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_ShadowSteal_DamageProcStart),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhotonGeyser = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_PhotonGeyser_WazaParam),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_MeteorDrive_WazaSeqStart),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_MeteorDrive_WazaSeqEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hanabisenyou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_DETERMINE, handler_Hanabisenyou_dmg_determine),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_NO_EFFECT, handler_Hanabisenyou_no_effect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DaiWall = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Mamoru_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Mamoru_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Mamoru_ExeFail),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_DaiWall),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_OTHERS, handler_DaiWall_NoEffectCheck),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Mamoru_Off),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeraiUti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_TEMPT_TARGET_ENABLE, handler_NeraiUti_Tempt),
            new EventFactor.EventHandlerTable(EventID.CHECK_AIM_TARGET_ENABLE, handler_NeraiUti_Aim),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HaisuiNoJin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_HaisuiNoJin_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_GensiNoTikara),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_HaisuiNoJin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoulBeat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_RANKEFF_VALUE, handler_GensiNoTikara),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_SoulBeat_CheckExe),
            new EventFactor.EventHandlerTable(EventID.WAZA_RANKEFF_FIXED, handler_SoulBeat_Damage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ochakai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_2ND, handler_common_ExeCheck2nd_FailOnRaid),
            new EventFactor.EventHandlerTable(EventID.UNCATEGORIZE_WAZA, handler_Ochakai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DengekiKutibasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_DengekiKutibasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TarShot = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASICK_STR, handler_TarShot_Str),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DragonArrow = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_DragonArrow_Param),
            new EventFactor.EventHandlerTable(EventID.CHECK_WAZA_TARGET_INCREASE, handler_DragonArrow_Inc),
            new EventFactor.EventHandlerTable(EventID.CHECK_HITCOUNT_MESSAGE, handler_DragonArrow_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_InotiNoSizuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_RECOVER_MSG_CUSTOM, handler_InotiNoSizuku_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Newton = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Newton),
        };

        // TODO
        public static HandlerGetFunc getHandlerGetFunc(WazaNo waza) { return default; }
		
		// TODO
		public static bool Add(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza, uint subPri) { return default; }
		
		// TODO
		public static bool canRegister(EventSystem pEventSystem, byte pokeID, WazaNo waza) { return default; }
		
		// TODO
		public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza) { }
		
		// TODO
		public static void RemoveForce(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza) { }
		
		// TODO
		public static void removeHandlerForce(EventSystem pEventSystem, byte pokeID, WazaNo waza) { }
		
		// TODO
		public static void RemoveForceAll(EventSystem eventSystem, BTL_POKEPARAM poke) { }
		
		// TODO
		public static bool common_checkActStart_isMyWaza(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool common_IsMyEvent(in EventFactor.EventHandlerArgs args, EventVar.Label pokeIDLabel, byte pokeID) { return default; }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaidPlayerSide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaidBoss(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck3rd_FailToG(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck3rd_FailToGWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static byte getEventVarTarget(in EventFactor.EventHandlerArgs args, int n) { return default; }
		
		// TODO
		public static void common_SetWazaEffectIndex(in EventFactor.EventHandlerArgs args, byte effectIndex) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Texture() { return default; }
		
		// TODO
		public static void handler_Texture(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrickRoom() { return default; }
		
		// TODO
		public static void handler_TrickRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juryoku() { return default; }
		
		// TODO
		public static void handler_Juryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kiribarai() { return default; }
		
		// TODO
		public static void handler_Kiribarai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kawarawari() { return default; }
		
		// TODO
		public static void handler_Kawarawari_DmgProc1(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kawarawari_DmgProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kawarawari_DmgDetermine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Kawarawari_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tobigeri() { return default; }
		
		// TODO
		public static void handler_Tobigeri_NoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Monomane() { return default; }
		
		// TODO
		public static void handler_Monomane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sketch() { return default; }
		
		// TODO
		public static void handler_Sketch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo sketch_GetTargetWaza(BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KonoyubiTomare() { return default; }
		
		// TODO
		public static void handler_KonoyubiTomare_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_TemptTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikarinokona() { return default; }
		
		// TODO
		public static void handler_Ikarinokona_TemptTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KumoNoSu() { return default; }
		
		// TODO
		public static void handler_KumoNoSu_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KumoNoSu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KuroiKiri() { return default; }
		
		// TODO
		public static void handler_KuroiKiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haneru() { return default; }
		
		// TODO
		public static void handler_Haneru_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Haneru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Oiwai() { return default; }
		
		// TODO
		public static void handler_Oiwai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TeWoTunagu() { return default; }
		
		// TODO
		public static void handler_TeWoTunagu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Noroi() { return default; }
		
		// TODO
		public static void handler_Noroi_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Noroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Noroi_ExeCheck3rd_FailToGWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Denjiha() { return default; }
		
		// TODO
		public static void handler_Denjiha(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NayamiNoTane() { return default; }
		
		// TODO
		public static void handler_NayamiNoTane_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NayamiNoTane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yumekui() { return default; }
		
		// TODO
		public static void handler_Yumekui(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TriAttack() { return default; }
		
		// TODO
		public static void handler_TriAttack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nettou() { return default; }
		
		// TODO
		public static void handler_Nettou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UtakatanoAria() { return default; }
		
		// TODO
		public static void handler_UtakatanoAria(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Osyaberi() { return default; }
		
		// TODO
		public static void handler_Osyaberi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makituku() { return default; }
		
		// TODO
		public static void handler_Makituku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Makituku_Str(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool makituku_GetStr(out ushort pStrID, WazaNo wazano)
		{
			pStrID = default;
			return default;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Uzusio() { return default; }
		
		// TODO
		public static void handler_Uzusio_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Uzusio_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IkariNoMaeba() { return default; }
		
		// TODO
		public static void handler_IkariNoMaeba(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static ushort common_CalcFixDamageByDefenderHp(BTL_POKEPARAM target, byte numerator, byte denominator) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gamusyara() { return default; }
		
		// TODO
		public static void handler_Gamusyara_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gamusyara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TikyuuNage() { return default; }
		
		// TODO
		public static void handler_TikyuuNage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Takuwaeru() { return default; }
		
		// TODO
		public static void handler_Takuwaeru_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Takuwaeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hakidasu() { return default; }
		
		// TODO
		public static void handler_Hakidasu_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hakidasu_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hakidasu_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nomikomu() { return default; }
		
		// TODO
		public static void handler_Nomikomu_Ratio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Counter() { return default; }
		
		// TODO
		public static void handler_Counter_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Counter_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Counter_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MilerCoat() { return default; }
		
		// TODO
		public static void handler_MilerCoat_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MilerCoat_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MilerCoat_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MetalBurst() { return default; }
		
		// TODO
		public static void handler_MetalBurst_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MetalBurst_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MetalBurst_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Counter_ExeCheck(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in byte pokeID) { }
		
		// TODO
		public static void common_Counter_SetTarget(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in byte pokeID) { }
		
		// TODO
		public static void common_Counter_CalcDamage(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in int ratio, in byte pokeID) { }
		
		// TODO
		public static bool common_Counter_GetRec(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, BTL_POKEPARAM.WAZADMG_REC rec, in byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Totteoki() { return default; }
		
		// TODO
		public static void handler_Totteoki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ibiki() { return default; }
		
		// TODO
		public static void handler_Ibiki_CheckFail_1(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ibiki_CheckFail_2(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuiuti() { return default; }
		
		// TODO
		public static void handler_Fuiuti_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Fuiuti_CheckSuccess(in EventFactor.EventHandlerArgs args, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Daibakuhatsu() { return default; }
		
		// TODO
		public static void handler_Daibakuhatsu_ExeStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Daibakuhatsu_DmgDetermine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Daibakuhatsu_ExeFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kiaidame() { return default; }
		
		// TODO
		public static void handler_Kiaidame(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juden() { return default; }
		
		// TODO
		public static void handler_Juden_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_RemoveAllTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_WazaStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_WazaEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HorobiNoUta() { return default; }
		
		// TODO
		public static void handler_HorobiNoUta_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_YadorigiNoTane() { return default; }
		
		// TODO
		public static void handler_YadorigiNoTane_Param(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NekoNiKoban() { return default; }
		
		// TODO
		public static void handler_NekoNiKoban(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AquaRing() { return default; }
		
		// TODO
		public static void handler_AquaRing(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Abareru() { return default; }
		
		// TODO
		public static void handler_Abareru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void abareru_Unlock(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Abareru_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Abareru_turnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sawagu() { return default; }
		
		// TODO
		public static void handler_Sawagu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void Sawagu_CureLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_turnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_CheckSickFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_CheckInemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Korogaru() { return default; }
		
		// TODO
		public static void handler_Korogaru_ExeFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korugaru_Avoid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_NoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Korogaru_Unlock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TripleKick() { return default; }
		
		// TODO
		public static void handler_TripleKick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TripleKick_HitCount(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GyroBall() { return default; }
		
		// TODO
		public static void handler_GyroBall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static ushort common_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Revenge() { return default; }
		
		// TODO
		public static void handler_Revenge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jitabata() { return default; }
		
		// TODO
		public static void handler_Jitabata(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Karagenki() { return default; }
		
		// TODO
		public static void handler_Karagenki_AtkPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Karagenki_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sippegaesi() { return default; }
		
		// TODO
		public static void handler_Sippegaesi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Funka() { return default; }
		
		// TODO
		public static void handler_Funka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Siboritoru() { return default; }
		
		// TODO
		public static void handler_Siboritoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Siomizu() { return default; }
		
		// TODO
		public static void handler_Siomizu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_RenzokuGiri() { return default; }
		
		// TODO
		public static void handler_RenzokuGiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dameosi() { return default; }
		
		// TODO
		public static void handler_Dameosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ketaguri() { return default; }
		
		// TODO
		public static void handler_Ketaguri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WeatherBall() { return default; }
		
		// TODO
		public static void handler_WeatherBall_Type(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WeatherBall_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WeatherBall_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tatumaki() { return default; }
		
		// TODO
		public static void handler_Tatumaki_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tatumaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kaminari() { return default; }
		
		// TODO
		public static void handler_Kaminari_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kaminari_excuseHitCalc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kaminari_hitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fubuki() { return default; }
		
		// TODO
		public static void handler_Fubuki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZettaiReido() { return default; }
		
		// TODO
		public static void handler_ZettaiReido_hitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jisin() { return default; }
		
		// TODO
		public static void handler_Jisin_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Jisin_damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SabakiNoTubute() { return default; }
		
		// TODO
		public static void handler_SabakiNoTubute(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MultiAttack() { return default; }
		
		// TODO
		public static PokeType multiAttack_GetType(ItemNo item) { return default; }
		
		// TODO
		public static void handler_MultiAttack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MultiAttack_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TechnoBaster() { return default; }
		
		// TODO
		public static void technoBaster_GetParam(ref PokeType pType, ref byte pEffectIdx, ItemNo item) { }
		
		// TODO
		public static void handler_TechnoBaster(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TechnoBaster_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MezameruPower() { return default; }
		
		// TODO
		public static void handler_MezameruPower_Type(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hatakiotosu() { return default; }
		
		// TODO
		public static void handler_Hatakiotosu_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hatakiotosu_EndHit(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicCoat() { return default; }
		
		// TODO
		public static void handler_MagicCoat_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_Wait(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dorobou() { return default; }
		
		// TODO
		public static void handler_Dorobou_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Dorobou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Trick() { return default; }
		
		// TODO
		public static void handler_Trick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Naminori() { return default; }
		
		// TODO
		public static void handler_Naminori_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Naminori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fumituke() { return default; }
		
		// TODO
		public static void handler_Fumituke_DamegeProc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumituke_HitCheckSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DaiMaxHou() { return default; }
		
		// TODO
		public static void handler_DaiMaxHou_DamegeProc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mineuti() { return default; }
		
		// TODO
		public static void handler_Mineuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Koraeru() { return default; }
		
		// TODO
		public static void handler_Koraeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Koraeru_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Koraeru_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mamoru() { return default; }
		
		// TODO
		public static void handler_Mamoru_StartSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_ExeFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Mamoru_Core(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static void IncrementMamoruCounter(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool mamoru_MsgAfterCritical(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static void handler_Mamoru_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_Off(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Recycle() { return default; }
		
		// TODO
		public static void handler_Recycle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PsycoShift() { return default; }
		
		// TODO
		public static void handler_PsycoShift(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Itamiwake() { return default; }
		
		// TODO
		public static void handler_Itamiwake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void itamiwake_CalcShiftHP(out int pAttackerHP, out int pDefenderHP, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pDefender)
		{
            pAttackerHP = default;
            pDefenderHP = default;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haradaiko() { return default; }
		
		// TODO
		public static void handler_Haradaiko(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Feint() { return default; }
		
		// TODO
		public static void handler_Feint_MamoruBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Feint_NoEffCheckBegin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Feint_NoEffCheckEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void SleepGuardSideEffects(in EventFactor.EventHandlerArgs args, byte pokeID, bool wakeFlag) { }
		
		// TODO
		public static void SleepGuardSideEffect(in EventFactor.EventHandlerArgs args, byte attackPokeId, byte targetPokeId, bool wakeFlag) { }
		
		// TODO
		public static void handler_Feint_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_feint_proc(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static void common_mamoruBreakAfter(in EventFactor.EventHandlerArgs args, byte attackPokeID, BTL_POKEPARAM target, ushort strID) { }
		
		// TODO
		public static void common_mamoruBreak_RemoveSideEff(in EventFactor.EventHandlerArgs args, byte pokeID, BTL_POKEPARAM target) { }
		
		// TODO
		public static bool common_IsExistGuardTypeSideEffect(in EventFactor.EventHandlerArgs args, byte targetPokeID, bool bIncludeNotCountupType) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IjigenHall() { return default; }
		
		// TODO
		public static void handler_IjigenHall_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TuboWoTuku() { return default; }
		
		// TODO
		public static void handler_TuboWoTuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nemuru() { return default; }
		
		// TODO
		public static void handler_Nemuru_exeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nemuru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Meromero() { return default; }
		
		// TODO
		public static void handler_Meromero_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Texture2() { return default; }
		
		// TODO
		public static void handler_Texture2(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Encore() { return default; }
		
		// TODO
		public static void handler_Encore(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Chouhatu() { return default; }
		
		// TODO
		public static void handler_Chouhatu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kanasibari() { return default; }
		
		// TODO
		public static void handler_Kanasibari(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo kanashibari_GetTargetWaza(BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Present() { return default; }
		
		// TODO
		public static void handler_Present_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Present_Fix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Present_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuuin() { return default; }
		
		// TODO
		public static void handler_Fuuin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Alomatherapy() { return default; }
		
		// TODO
		public static void handler_Alomatherapy_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Alomatherapy(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoSuzu() { return default; }
		
		// TODO
		public static void handler_IyasiNoSuzu_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IyasiNoSuzu_RemoveAllTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IyasiNoSuzu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_CureFriendPokeSick(in EventFactor.EventHandlerArgs args, byte attackerID, bool excludeOutOfWazaTarget, bool canWriteGenFlag) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Okimiyage() { return default; }
		
		// TODO
		public static void handler_Okimiyage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Urami() { return default; }
		
		// TODO
		public static void handler_Urami(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JikoAnji() { return default; }
		
		// TODO
		public static void handler_JikoAnji(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeartSwap() { return default; }
		
		// TODO
		public static void handler_HeartSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerSwap() { return default; }
		
		// TODO
		public static void handler_PowerSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GuardSwap() { return default; }
		
		// TODO
		public static void handler_GuardSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerTrick() { return default; }
		
		// TODO
		public static void handler_PowerTrick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerShare() { return default; }
		
		// TODO
		public static void handler_PowerShare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GuardShare() { return default; }
		
		// TODO
		public static void handler_GuardShare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LockON() { return default; }
		
		// TODO
		public static void handler_LockON(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokudoku() { return default; }
		
		// TODO
		public static void handler_Dokudoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Dokudoku_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Reflector() { return default; }
		
		// TODO
		public static void handler_Reflector(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HikariNoKabe() { return default; }
		
		// TODO
		public static void handler_HikariNoKabe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SinpiNoMamori() { return default; }
		
		// TODO
		public static void handler_SinpiNoMamori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SiroiKiri() { return default; }
		
		// TODO
		public static void handler_SiroiKiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Oikaze() { return default; }
		
		// TODO
		public static void handler_Oikaze(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makibisi() { return default; }
		
		// TODO
		public static void handler_Makibisi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokubisi() { return default; }
		
		// TODO
		public static void handler_Dokubisi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_StealthRock() { return default; }
		
		// TODO
		public static void handler_StealthRock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NebaNebaNet() { return default; }
		
		// TODO
		public static void handler_NebaNebaNet(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WideGuard() { return default; }
		
		// TODO
		public static void handler_WideGuard_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WideGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TatamiGaeshi() { return default; }
		
		// TODO
		public static void handler_TatamiGaeshi_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TatamiGaeshi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_SideEffectStdMsg(in EventFactor.EventHandlerArgs args, in byte pokeID, BtlSide side, BtlSideEffect effect, in BTL_SICKCONT cont, ushort strID) { return default; }
		
		// TODO
		public static bool common_SideEffectCore(in EventFactor.EventHandlerArgs args, byte pokeID, BtlSide side, BtlSideEffect effect, in BTL_SICKCONT cont, BtlStrType strType, uint strID, int strArg, bool replaceStrArg0ByExpandSide) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hensin() { return default; }
		
		// TODO
		public static void handler_Hensin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MikadukiNoMai() { return default; }
		
		// TODO
		public static void handler_MikadukiNoMai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoNegai() { return default; }
		
		// TODO
		public static void handler_IyasiNoNegai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Negaigoto() { return default; }
		
		// TODO
		public static void handler_Negaigoto(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Miraiyoti() { return default; }
		
		// TODO
		public static void handler_Miraiyoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Miraiyoti_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_delayAttack(in EventFactor.EventHandlerArgs args, byte pokeID, BtlPokePos targetPos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HametuNoNegai() { return default; }
		
		// TODO
		public static void handler_HametuNoNegai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HametuNoNegai_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ieki() { return default; }
		
		// TODO
		public static void handler_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Narikiri() { return default; }
		
		// TODO
		public static void handler_Narikiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TonboGaeri() { return default; }
		
		// TODO
		public static void handler_TonboGaeri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KousokuSpin() { return default; }
		
		// TODO
		public static void handler_KousokuSpin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BatonTouch() { return default; }
		
		// TODO
		public static void handler_BatonTouch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Teleport() { return default; }
		
		// TODO
		public static bool teleport_isQuitBattle(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool teleport_canQuitBattle(in EventFactor.EventHandlerArgs args, ref WazaFailCause pFailCause, in byte pokeID) { return default; }
		
		// TODO
		public static void handler_Teleport_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExeCheck_QuitBattle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExeCheck_ChangePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_QuitBattle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ChangePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExMsg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nagetukeru() { return default; }
		
		// TODO
		public static void handler_Nagetukeru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_WazaPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_DmgProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_DmgAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DenjiFuyuu() { return default; }
		
		// TODO
		public static void handler_DenjiFuyuu_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DenjiFuyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tedasuke() { return default; }
		
		// TODO
		public static void handler_Tedasuke_SkipAvoid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool tedasuke_IsSuccess(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Tedasuke_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FukuroDataki() { return default; }
		
		// TODO
		public static void handler_FukuroDataki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FukuroDataki_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static BTL_POKEPARAM common_FukuroDataki_GetParam(in EventFactor.EventHandlerArgs args, byte myPokeID, byte idx) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nekodamasi() { return default; }
		
		// TODO
		public static void handler_Nekodamasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Deaigasira() { return default; }
		
		// TODO
		public static void handler_Deaigasira(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AsaNoHizasi() { return default; }
		
		// TODO
		public static void handler_AsaNoHizasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunaatume() { return default; }
		
		// TODO
		public static void handler_Sunaatume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerHeal() { return default; }
		
		// TODO
		public static void handler_FlowerHeal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoraWoTobu() { return default; }
		
		// TODO
		public static void handler_SoraWoTobu_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ShadowDive() { return default; }
		
		// TODO
		public static void handler_ShadowDive_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ShadowDive_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tobihaneru() { return default; }
		
		// TODO
		public static void handler_Tobihaneru_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Diving() { return default; }
		
		// TODO
		public static void handler_Diving_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AnaWoHoru() { return default; }
		
		// TODO
		public static void handler_AnaWoHoru_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SolarBeam() { return default; }
		
		// TODO
		public static void handler_SolarBeam_TameSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SolarBeam_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SolarBeam_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GodBird() { return default; }
		
		// TODO
		public static void handler_GodBird_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_RocketZutuki() { return default; }
		
		// TODO
		public static void handler_RocketZutuki_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tuibamu() { return default; }
		
		// TODO
		public static void handler_Tuibamu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hoobaru() { return default; }
		
		// TODO
		public static void handler_Hoobaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hoobaru_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Waruagaki() { return default; }
		
		// TODO
		public static void handler_Waruagaki_KickBack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Waruagaki_SeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Waruagaki_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Michidure() { return default; }
		
		// TODO
		public static void handler_Michidure_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void stickMitidureFactor(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void removeMitidureFactor(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_ActStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_WazaDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Onnen() { return default; }
		
		// TODO
		public static void stickOnnenFactor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void removeOnnenFactor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_WazaDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_ActStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tiisakunaru() { return default; }
		
		// TODO
		public static void handler_Tiisakunaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Marukunaru() { return default; }
		
		// TODO
		public static void handler_Marukunaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haneyasume() { return default; }
		
		// TODO
		public static void handler_Haneyasume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KiaiPunch() { return default; }
		
		// TODO
		public static void handler_KiaiPunch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_YubiWoFuru() { return default; }
		
		// TODO
		public static void handler_YubiWoFuru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_YubiWoFuru_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SizenNoTikara() { return default; }
		
		// TODO
		public static void handler_SizenNoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SizenNoTikara_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Negoto() { return default; }
		
		// TODO
		public static void handler_Negoto(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Manekko() { return default; }
		
		// TODO
		public static void handler_Manekko_CheckParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo manekko_GetTargetWaza(BattleEnv pBattleEnv) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GensiNoTikara() { return default; }
		
		// TODO
		public static void handler_GensiNoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BenomShock() { return default; }
		
		// TODO
		public static void handler_BenomShock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tatarime() { return default; }
		
		// TODO
		public static void handler_Tatarime(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Acrobat() { return default; }
		
		// TODO
		public static void handler_Acrobat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AsistPower() { return default; }
		
		// TODO
		public static void handler_AsistPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeavyBomber() { return default; }
		
		// TODO
		public static void handler_HeavyBomber(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeatStamp() { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElectBall() { return default; }
		
		// TODO
		public static void handler_ElectBall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_EchoVoice() { return default; }
		
		// TODO
		public static void handler_EchoVoice(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katakiuti() { return default; }
		
		// TODO
		public static void handler_Katakiuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikasama() { return default; }
		
		// TODO
		public static void handler_Ikasama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BodyPress() { return default; }
		
		// TODO
		public static void handler_BodyPress(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mizubitasi() { return default; }
		
		// TODO
		public static void handler_Mizubitasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MahouNoKona() { return default; }
		
		// TODO
		public static void handler_MahouNoKona(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SimpleBeem() { return default; }
		
		// TODO
		public static void handler_SimpleBeem(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NakamaDukuri() { return default; }
		
		// TODO
		public static void handler_NakamaDukuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ClearSmog() { return default; }
		
		// TODO
		public static void handler_ClearSmog(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yakitukusu() { return default; }
		
		// TODO
		public static void handler_Yakitukusu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TomoeNage() { return default; }
		
		// TODO
		public static void handler_TomoeNage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hoeru() { return default; }
		
		// TODO
		public static void handler_Hoeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Utiotosu() { return default; }
		
		// TODO
		public static void handler_Utiotosu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_UtiotosuEffect(in EventFactor.EventHandlerArgs args, byte atkPokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static bool common_UtiotosuEffect_falldown(in EventFactor.EventHandlerArgs args, byte atkPokeID, byte targetPokeID, BTL_POKEPARAM bppTarget) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KarawoYaburu() { return default; }
		
		// TODO
		public static void handler_KarawoYaburu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MirrorType() { return default; }
		
		// TODO
		public static void handler_MirrorType(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BodyPurge() { return default; }
		
		// TODO
		public static void handler_BodyPurge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PsycoShock() { return default; }
		
		// TODO
		public static void handler_PsycoShock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NasiKuzusi() { return default; }
		
		// TODO
		public static void handler_NasiKuzusi_CalcDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NasiKuzusi_HitCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WonderRoom() { return default; }
		
		// TODO
		public static void handler_WonderRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicRoom() { return default; }
		
		// TODO
		public static void handler_MagicRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Inotigake() { return default; }
		
		// TODO
		public static void handler_Inotigake_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Inotigake_CheckDead(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_OsakiniDouzo() { return default; }
		
		// TODO
		public static void handler_OsakiniDouzo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sakiokuri() { return default; }
		
		// TODO
		public static void handler_Sakiokuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Rinsyou() { return default; }
		
		// TODO
		public static void handler_Rinsyou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinsyou_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FastGuard() { return default; }
		
		// TODO
		public static void handler_FastGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SideChange() { return default; }
		
		// TODO
		public static void handler_SideChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CourtChange() { return default; }
		
		// TODO
		public static void handler_CourtChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_InisieNoUta() { return default; }
		
		// TODO
		public static void handler_InisieNoUta(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seityou() { return default; }
		
		// TODO
		public static void handler_Seityou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezeBolt() { return default; }
		
		// TODO
		public static void handler_FreezeBolt_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlameSoul() { return default; }
		
		// TODO
		public static void handler_FlameSoul_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static Waza.CombiEffectType GetCombiWazaType(WazaNo waza1, WazaNo waza2) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CombiWazaCommon() { return default; }
		
		// TODO
		public static void handler_CombiWaza_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_TypeMatch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_ChangeEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_AfterDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Halloween() { return default; }
		
		// TODO
		public static void handler_Halloween(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Morinonoroi() { return default; }
		
		// TODO
		public static void handler_Morinonoroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerGuard() { return default; }
		
		// TODO
		public static void handler_Tagayasu_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_GuardUpByPokeType(in EventFactor.EventHandlerArgs args, byte pokeID, byte pokeType) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TodomeBari() { return default; }
		
		// TODO
		public static void handler_TodomeBari(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KogoeruHadou() { return default; }
		
		// TODO
		public static void handler_KogoeruHadou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hikkurikaesu() { return default; }
		
		// TODO
		public static void handler_Hikkurikaesu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeraiPunch() { return default; }
		
		// TODO
		public static void handler_NeraiPunch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SuteZerifu() { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlyingPress() { return default; }
		
		// TODO
		public static void handler_FlyingPress(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezDry() { return default; }
		
		// TODO
		public static void handler_FreezDry(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Souden() { return default; }
		
		// TODO
		public static void handler_Souden(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GrassField() { return default; }
		
		// TODO
		public static void handler_GrassField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MistField() { return default; }
		
		// TODO
		public static void handler_MistField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecField() { return default; }
		
		// TODO
		public static void handler_ElecField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhychoField() { return default; }
		
		// TODO
		public static void handler_PhychoField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_GroundSet(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KingShield() { return default; }
		
		// TODO
		public static void handler_KingShield(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void kingShield_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Blocking() { return default; }
		
		// TODO
		public static void Blocking_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Blocking_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Blocking_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ThousanArrow() { return default; }
		
		// TODO
		public static void handler_ThousanArrow_CancelFloat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow_AffEnable(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow_CheckAffine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HappyTime() { return default; }
		
		// TODO
		public static void handler_HappyTime(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZibaSousa() { return default; }
		
		// TODO
		public static void handler_ZibaSousa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BenomTrap() { return default; }
		
		// TODO
		public static void handler_BenomTrap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PlasmaFist() { return default; }
		
		// TODO
		public static void handler_PlasmaFist(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairyLock() { return default; }
		
		// TODO
		public static void handler_FairyLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Funjin() { return default; }
		
		// TODO
		public static void handler_Funjin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GeoControl() { return default; }
		
		// TODO
		public static void handler_GeoControl_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrickGuard() { return default; }
		
		// TODO
		public static void handler_TrickGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeedleGuard() { return default; }
		
		// TODO
		public static void needleGuard_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_NeedleGuard_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NeedleGuard_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SouthernWave() { return default; }
		
		// TODO
		public static void handler_southernWave(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IjigenRush() { return default; }
		
		// TODO
		public static void handler_IjigenRush(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IjigenRush_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuraGuruma() { return default; }
		
		// TODO
		public static void handler_AuraGuruma(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraGuruma_Waza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraGuruma_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DarkHole() { return default; }
		
		// TODO
		public static void handler_DarkHole(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tootika() { return default; }
		
		// TODO
		public static void tootika_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Tootika_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tootika_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MezameruDance() { return default; }
		
		// TODO
		public static void handler_MezameruDance_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kahundango() { return default; }
		
		// TODO
		public static void handler_Kahundango_ExecuteCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_RecoverCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_RecoverFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_Check_Affinity(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CorePunisher() { return default; }
		
		// TODO
		public static void handler_CorePunisher_HitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kagenui() { return default; }
		
		// TODO
		public static void handler_Kagenui_HitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kuraituku() { return default; }
		
		// TODO
		public static bool kuraitukuCheck(in EventFactor.EventHandlerArgs args, BTL_POKEPARAM attack, BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static void kuraitukuSet(in EventFactor.EventHandlerArgs args, byte attackPokeID, byte targetPokeID) { }
		
		// TODO
		public static void handler_Kuraituku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TakoGatame() { return default; }
		
		// TODO
		public static void handler_TakoGatame_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_takoGatame(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zyouka() { return default; }
		
		// TODO
		public static void handler_Zyouka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikarawosuitoru() { return default; }
		
		// TODO
		public static void handler_Tikarawosuitoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Togisumasu() { return default; }
		
		// TODO
		public static void handler_Togisumasu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SpeedSwap() { return default; }
		
		// TODO
		public static void handler_SpeedSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Moetukiru() { return default; }
		
		// TODO
		public static void handler_Moetukiru_WazaMeltCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moetukiru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moetukiru_DamageProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KutibasiCanon() { return default; }
		
		// TODO
		public static void handler_KutibasiCanon_BeforeFight(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_DamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_ReplaceWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_Canceled(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrapShell() { return default; }
		
		// TODO
		public static void handler_TrapShell_BeforeFight(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_DamageProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_WazaEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zidanda() { return default; }
		
		// TODO
		public static void handler_Zidanda_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuroraVeil() { return default; }
		
		// TODO
		public static void handler_AuroraVeil_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuroraVeil(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Saihai() { return default; }
		
		// TODO
		public static void handler_Saihai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MeteorDrive() { return default; }
		
		// TODO
		public static void handler_MeteorDrive_WazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MeteorDrive_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ShadowSteal() { return default; }
		
		// TODO
		public static void handler_ShadowSteal_DamageProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhotonGeyser() { return default; }
		
		// TODO
		public static void handler_PhotonGeyser_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hanabisenyou() { return default; }
		
		// TODO
		public static void handler_Hanabisenyou_dmg_determine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hanabisenyou_no_effect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_HanabisenyouReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DaiWall() { return default; }
		
		// TODO
		public static void handler_DaiWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DaiWall_NoEffectCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeraiUti() { return default; }
		
		// TODO
		public static void handler_NeraiUti_Tempt(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NeraiUti_Aim(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HaisuiNoJin() { return default; }
		
		// TODO
		public static void handler_HaisuiNoJin_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HaisuiNoJin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoulBeat() { return default; }
		
		// TODO
		public static void handler_SoulBeat_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SoulBeat_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ochakai() { return default; }
		
		// TODO
		public static bool ochakai_EatNuts(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Ochakai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DengekiKutibasi() { return default; }
		
		// TODO
		public static void handler_DengekiKutibasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TarShot() { return default; }
		
		// TODO
		public static void handler_TarShot_Str(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DragonArrow() { return default; }
		
		// TODO
		public static void handler_DragonArrow_Param(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DragonArrow_Inc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DragonArrow_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_InotiNoSizuku() { return default; }
		
		// TODO
		public static void handler_InotiNoSizuku_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Newton() { return default; }
		
		// TODO
		public static void handler_Newton(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public enum CombiEffectType : int
		{
			COMBI_EFFECT_NULL = 0,
			COMBI_EFFECT_RAINBOW = 1,
			COMBI_EFFECT_BURNING = 2,
			COMBI_EFFECT_MOOR = 3,
		}

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

		private struct GET_FUNC_TABLE_ELEM
		{
			public WazaNo waza;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(WazaNo waza, HandlerGetFunc func)
			{
				this.waza = waza;
				this.func = func;
			}
		}

		private struct handler_JitabataTableElem
		{
			public ushort dot_ratio;
			public ushort pow;
			
			public handler_JitabataTableElem(ushort dot_ratio, ushort pow)
			{
				this.dot_ratio = dot_ratio;
				this.pow = pow;
			}
		}

		private struct WeatherBallParam
		{
			public PokeType type;
			public byte effIndex;
		}

		private struct GetCombiWazaTypeTableElem
		{
			public WazaNo waza1;
			public WazaNo waza2;
			public CombiEffectType effect;
			
			public GetCombiWazaTypeTableElem(WazaNo waza1, WazaNo waza2, CombiEffectType effect)
			{
				this.waza1 = waza1;
				this.waza2 = waza2;
				this.effect = effect;
			}
		}
	}
}