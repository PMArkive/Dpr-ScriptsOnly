using Pml;
using Pml.WazaData;
using Dpr.Battle.Logic;
using System;
using UnityEngine.EventSystems;

namespace Dpr.Battle.Logic.Handler
{
	public static class Tokusei
	{
        private const int TRUE = 1;
		private const int FALSE = 0;

		private const int WIDX0 = 0;
		private const int WIDX1 = 1;
		private const int WIDX2 = 2;
		private const int WIDX3 = 3;

		private const int WIDX_REMOVE_GUARD = 4;
		private const int NUM_WIDX = 5;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE = new GET_FUNC_TABLE_ELEM[]
		{
            new GET_FUNC_TABLE_ELEM(TokuseiNo.IKAKU, ADD_Ikaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KURIABODHI, ADD_ClearBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SIROIKEMURI, ADD_ClearBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SEISINRYOKU, ADD_Seisinryoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUKUTUNOKOKORO, ADD_Fukutsuno),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ATUISIBOU, ADD_AtuiSibou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAIRIKIBASAMI, ADD_KairikiBasami),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TIKARAMOTI, ADD_Tikaramoti),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YOGAPAWAA, ADD_Tikaramoti),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.IROMEGANE, ADD_Iromegane),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KASOKU, ADD_Kasoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MOUKA, ADD_Mouka),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GEKIRYUU, ADD_Gekiryu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SINRYOKU, ADD_Sinryoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MUSINOSIRASE, ADD_MusinoSirase),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KONZYOU, ADD_Konjou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUKIRURINKU, ADD_SkillLink),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SURUDOIME, ADD_Surudoime),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TANZYUN, ADD_Tanjun),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAADOROKKU, ADD_HardRock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.FIRUTAA, ADD_HardRock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUSIGINAUROKO, ADD_FusiginaUroko),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TOUSOUSIN, ADD_Tousousin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.RIIHUGAADO, ADD_LeafGuard),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PASUTERUBEERU, ADD_PastelVeil),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AMEHURASI, ADD_Amefurasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HIDERI, ADD_Hideri),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNAOKOSI, ADD_Sunaokosi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNAHAKI, ADD_Sunahaki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YUKIHURASI, ADD_Yukifurasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.EAROKKU, ADD_AirLock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NOOTENKI, ADD_AirLock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TEKUNISYAN, ADD_Technician),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DONKAN, ADD_Donkan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.URUOIBODHI, ADD_UruoiBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.POIZUNHIIRU, ADD_PoisonHeal),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AISUBODHI, ADD_IcoBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AMEUKEZARA, ADD_AmeukeZara),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.RINPUN, ADD_Rinpun),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TEKIOURYOKU, ADD_Tekiouryoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TENNOMEGUMI, ADD_TennoMegumi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SANPAWAA, ADD_SunPower),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUISUI, ADD_Suisui),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YOURYOKUSO, ADD_Youryokuso),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DAPPI, ADD_Dappi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TIDORIASI, ADD_Tidoriasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAYAASI, ADD_Hayaasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HARIKIRI, ADD_Harikiri),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KABUTOAAMAA, ADD_KabutoArmor),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SHERUAAMAA, ADD_KabutoArmor),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KYOUUN, ADD_Kyouun),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.IKARINOTUBO, ADD_IkarinoTubo),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNAIPAA, ADD_Sniper),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TETUNOKOBUSI, ADD_TetunoKobusi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUKUGAN, ADD_Fukugan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ISIATAMA, ADD_Isiatama),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUTEMI, ADD_Sutemi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SEIDENKI, ADD_Seidenki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DOKUNOTOGE, ADD_DokunoToge),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HONOONOKARADA, ADD_HonoNoKarada),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HOUSI, ADD_Housi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PURASU, ADD_Plus),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAINASU, ADD_Plus),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MEROMEROBODHI, ADD_MeromeroBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNAGAKURE, ADD_Sunagakure),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YUKIGAKURE, ADD_Yukigakure),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TOREESU, ADD_Trace),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NOOMARUSUKIN, ADD_NormalSkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SAMEHADA, ADD_Samehada),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SIZENKAIHUKU, ADD_SizenKaifuku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SINKURO, ADD_Syncro),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DAUNROODO, ADD_DownLoad),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GANZYOU, ADD_Ganjou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TAINETU, ADD_Tainetu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TENNEN, ADD_Tennen),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KANSOUHADA, ADD_Kansouhada),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PANKUROKKU, ADD_PunkRock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TIKUDEN, ADD_Tikuden),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TYOSUI, ADD_Tyosui),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DENKIENZIN, ADD_DenkiEngine),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZYUUNAN, ADD_Juunan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUMIN, ADD_Fumin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YARUKI, ADD_Fumin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAIPEESU, ADD_MyPace),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAGUMANOYOROI, ADD_MagumaNoYoroi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MIZUNOBEERU, ADD_MizuNoBale),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MENEKI, ADD_Meneki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KIMOTTAMA, ADD_Kimottama),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BOUON, ADD_Bouon),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUYUU, ADD_Fuyuu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HURAWAAGIHUTO, ADD_FlowerGift),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MORAIBI, ADD_Moraibi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YOTIMU, ADD_Yotimu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KIKENYOTI, ADD_KikenYoti),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.OMITOOSI, ADD_Omitoosi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YUUBAKU, ADD_Yuubaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HOROBINOBODHI, ADD_HorobiNoSango),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NIGEASI, ADD_Nigeasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HENSYOKU, ADD_Hensyoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KATAYABURI, ADD_Katayaburi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NAMAKE, ADD_Namake),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HIRAISIN, ADD_Hiraisin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YOBIMIZU, ADD_Yobimizu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUROOSUTAATO, ADD_SlowStart),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SIMERIKE, ADD_Simerike),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUSIGINAMAMORI, ADD_FusiginaMamori),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ATODASI, ADD_Atodasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TENKIYA, ADD_Tenkiya),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KYUUBAN, ADD_Kyuuban),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HEDOROEKI, ADD_HedoroEki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BUKIYOU, ADD_Bukiyou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NENTYAKU, ADD_Nenchaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PURESSYAA, ADD_Pressure),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAZIKKUGAADO, ADD_MagicGuard),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NAITOMEA, ADD_Nightmare),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MONOHIROI, ADD_Monohiroi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TAMAHIROI, ADD_TamaHiroi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KARUWAZA, ADD_Karuwaza),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AKUSYUU, ADD_Akusyuu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAGEHUMI, ADD_Kagefumi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ARIZIGOKU, ADD_Arijigoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZIRYOKU, ADD_Jiryoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.WARUITEGUSE, ADD_WaruiTeguse),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TIKARAZUKU, ADD_Tikarazuku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAKENKI, ADD_Makenki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YOWAKI, ADD_Yowaki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MARUTISUKEIRU, ADD_MultiScale),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HEVHIMETARU, ADD_HeavyMetal),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.RAITOMETARU, ADD_LightMetal),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AMANOZYAKU, ADD_Amanojaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KINTYOUKAN, ADD_Kinchoukan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAGAKUHENKAGASU, ADD_KagakuHenkaGas),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZYUKUSEI, ADD_Jukusei),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NOROWAREBODHI, ADD_NorowareBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.IYASINOKOKORO, ADD_IyasiNoKokoro),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HURENDOGAADO, ADD_FriendGuard),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KUDAKERUYOROI, ADD_KudakeruYoroi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DOKUBOUSOU, ADD_Dokubousou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NETUBOUSOU, ADD_Netubousou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SYUUKAKU, ADD_Syuukaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TEREPASII, ADD_Telepassy),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MURAKKE, ADD_Murakke),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BOUZIN, ADD_Boujin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DOKUSYU, ADD_Dokusyu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SAISEIRYOKU, ADD_SaiseiRyoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HATOMUNE, ADD_Hatomune),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNAKAKI, ADD_Sunakaki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MIRAKURUSUKIN, ADD_MilacreSkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ANARAIZU, ADD_Analyze),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.IRYUUZYON, ADD_Illusion),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAWARIMONO, ADD_Kawarimono),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SURINUKE, ADD_Surinuke),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BARIAHURII, ADD_BarrierFree),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MIIRA, ADD_Miira),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SAMAYOUTAMASII, ADD_SamayouTamasii),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZISINKAZYOU, ADD_JisinKajou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SEIGINOKOKORO, ADD_SeiginoKokoro),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BIBIRI, ADD_Bibiri),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZYOUKIKIKAN, ADD_JyoukiKikan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.WATAGE, ADD_Watage),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAZIKKUMIRAA, ADD_MagicMirror),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SOUSYOKU, ADD_Sousyoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ITAZURAGOKORO, ADD_ItazuraGokoro),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUNANOTIKARA, ADD_SunanoTikara),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TETUNOTOGE, ADD_Samehada),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SYOURINOHOSI, ADD_GoodLuck),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TAABOBUREIZU, ADD_Katayaburi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TERABORUTEEZI, ADD_Katayaburi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.AROMABEERU, ADD_MentalVeil),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HURAWAABEERU, ADD_FlowerVeil),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HOOBUKURO, ADD_HooBukuro),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HENGENZIZAI, ADD_HengenZizai),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.OORABUREIKU, ADD_AuraBreak),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DAAKUOORA, ADD_DarkAura),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.FEARIIOORA, ADD_FairyAura),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GANZYOUAGO, ADD_GanjouAgo),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GORIMUTYUU, ADD_Gorimuchu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.FAAKOOTO, ADD_FurCoat),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KUSANOKEGAWA, ADD_KusaNoKegawa),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NUMENUME, ADD_NumeNume),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KATAITUME, ADD_KataiTume),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUKAISUKIN, ADD_SkySkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.FEARIISUKIN, ADD_FairySkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HURIIZUSUKIN, ADD_FreezSkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MEGARANTYAA, ADD_MegaLauncher),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAYATENOTUBASA, ADD_HayateNoTsubasa),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUIITOBEERU, ADD_SweetVeil),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MIRAAAAMAA, ADD_MirrorArmor),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KATIKI, ADD_Katiki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BOUDAN, ADD_Boudan),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.OYAKOAI, ADD_OyakoAi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MAZISYAN, ADD_Magician),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KYOUSEI, ADD_Kyousei),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAZIMARINOUMI, ADD_Hajimarinoumi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.OWARINODAITI, ADD_Owarinodaiti),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.DERUTASUTORIIMU, ADD_DeltaStream),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZIKYUURYOKU, ADD_Zikyuuryoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MIZUGATAME, ADD_Mizugatame),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUIHOU, ADD_Suihou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.YUKIKAKI, ADD_Yukikaki),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAGANETUKAI, ADD_Haganetukai),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HAGANENOSEISIN, ADD_HaganeNoSeisin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.URUOIBOISU, ADD_UruoiVoice),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HIIRINGUSIHUTO, ADD_HealingShift),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.EREKISUKIN, ADD_ElecSkin),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SAAHUTEERU, ADD_SurfTail),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HITODENASI, ADD_Hitodenasi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ENKAKU, ADD_Enkaku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZYOOUNOIGEN, ADD_Zyoounoigen),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BIBIDDOBODHI, ADD_Zyoounoigen),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MOHUMOHU, ADD_MohuMohu),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KOORINORINPUN, ADD_KooriNoRinpun),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAARIIHEAA, ADD_NumeNume),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BATTERII, ADD_Battery),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PAWAASUPOTTO, ADD_PowerSpot),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.RESIIBAA, ADD_Receiver),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KAGAKUNOTIKARA, ADD_Receiver),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.RIBERO, ADD_HengenZizai),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.TOBIDASUNAKAMI, ADD_TobidasuNakami),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GYAKUZYOU, ADD_Gyakuzyou),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SOURUHAATO, ADD_SoulHeart),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ODORIKO, ADD_Odoriko),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUSYOKU, ADD_Husyoku),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.EREKIMEIKAA, ADD_ElecMaker),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SAIKOMEIKAA, ADD_PhychoMaker),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.MISUTOMEIKAA, ADD_MistMaker),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GURASUMEIKAA, ADD_GrassMaker),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.GITAI, ADD_Gitai),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.NIGEGOSI, ADD_Nigegosi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.KIKIKAIHI, ADD_Nigegosi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BIISUTOBUUSUTO, ADD_UltraForce),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HARIKOMI, ADD_Harikomi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.ZETTAINEMURI, ADD_ZettaiNemuri),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.METARUPUROTEKUTO, ADD_ClearBody),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.FANTOMUGAADO, ADD_MultiScale),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.PURIZUMUAAMAA, ADD_HardRock),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.BUREINFOOSU, ADD_BrainPrism),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUTOUNOTURUGI, ADD_HutouNoTurugi),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.HUKUTUNOTATE, ADD_HukutuNoTate),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUKURYUUOBIRE, ADD_ScrewObire),
			new GET_FUNC_TABLE_ELEM(TokuseiNo.SUZIGANEIRI, ADD_ScrewObire),
        };

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikaku = new EventFactor.EventHandlerTable[]
		{
			new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Ikaku_MemberIn),
			new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Ikaku_MemberIn),
		};
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seisinryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SHRINK_CHECK, handler_Seisinryoku),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Seisinryoku_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Seisinryoku_RankEffectFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fukutsuno = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_FukutsunoKokoro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AtuiSibou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_AtuiSibou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikaramoti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Tikaramoti),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Suisui = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Suisui),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Youryokuso = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Youryokuso),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hayaasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Hayaasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tidoriasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Tidoriasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Harikiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Harikiri_HitRatio),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Harikiri_AtkPower),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Atodasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_SP_PRIORITY, handler_Atodasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SlowStart = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_SlowStart_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_SlowStart_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_SlowStart_Agility),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_SlowStart_AtkPower),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_SlowStart_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fukugan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Fukugan),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunagakure = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Sunagakure),
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Sunagakure_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukigakure = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_Yukigakure),
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Yukigakure_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Iromegane = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Iromegane),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HardRock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_HardRock),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sniper = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_Sniper),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kasoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Kasoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tekiouryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TYPEMATCH_RATIO, handler_Tekiouryoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mouka = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Mouka),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gekiryu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Gekiryu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sinryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Sinryoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MusinoSirase = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_MusinoSirase),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Konjou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Konjou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Plus = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_PlusMinus),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerGift = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_COMP, handler_FlowerGift_MemberInComp),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_FlowerGift_GotTok),
            new EventFactor.EventHandlerTable(EventID.WEATHER_CHANGE_AFTER, handler_FlowerGift_Weather),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_FlowerGift_TokOff),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_AIRLOCK, handler_FlowerGift_AirLock),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_FlowerGift_Weather),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_DONE, handler_FlowerGift_Weather),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_FlowerGift_TokChange),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_FlowerGift_Power),
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_FlowerGift_Guard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tousousin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Tousousin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Technician = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Technician),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TetunoKobusi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_TetunoKobusi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Stemi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Sutemi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FusiginaUroko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_FusiginaUroko),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SkillLink = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_COUNT, handler_SkillLink),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KairikiBasami = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_KairikiBasami_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_KairikiBasami_Guard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Surudoime = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Surudoime_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Surudoime_Guard),
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RANK, handler_Surudoime_HitRank),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ClearBody = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_ClearBody_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_ClearBody_Guard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tanjun = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKVALUE_CHANGE, handler_Tanjun),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_LeafGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_LeafGuard),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_LeafGuard_InemuriCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juunan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Juunan_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Juunan_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Juunan_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Juunan_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fumin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Fumin_PokeSick),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_Fumin_InemuriCheck),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Fumin_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Fumin_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Fumin_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagumaNoYoroi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_MagumaNoYoroi_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_MagumaNoYoroi_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MagumaNoYoroi_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MagumaNoYoroi_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Meneki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Meneki_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Meneki_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Meneki_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Meneki_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MizuNoBale = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_MizuNoBale_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_MizuNoBale_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MizuNoBale_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MizuNoBale_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MyPace = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_MyPace_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_MyPace_AddSickFailed),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_MyPace_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MyPace_ActEnd),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_MyPace_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_MyPace_RankEffectFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Donkan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Donkan),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Donkan_Wake),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Donkan_NoEffCheck),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Donkan_ActEnd),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Donkan_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Donkan_RankEffectFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PastelVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_Pastelveil_SickFail),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_Pastelveil_SickFailed),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_PastelVeil_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PastelVeil_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_PastelVeil_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Amefurasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Amefurasi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Amefurasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hideri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Hideri),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Hideri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunaokosi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Sunaokosi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Sunaokosi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunahaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Sunahaki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukifurasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Yukifurasi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Yukifurasi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hajimarinoumi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Hajimarinoumi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Hajimarinoumi),
            new EventFactor.EventHandlerTable(EventID.MEMBER_OUT_FIXED, handler_Hajimarinoumi_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Hajimarinoumi_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_POKE_BEFORE, handler_Hajimarinoumi_stop),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_DEAD, handler_Hajimarinoumi_stop),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Hajimarinoumi_stop),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Owarinodaiti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Owarinodaichi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Owarinodaichi),
            new EventFactor.EventHandlerTable(EventID.MEMBER_OUT_FIXED, handler_Owarinodaichi_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Owarinodaichi_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_POKE_BEFORE, handler_Owarinodaichi_stop),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_DEAD, handler_Owarinodaichi_stop),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Owarinodaichi_stop),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DeltaStream = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_DeltaStream),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_DeltaStream),
            new EventFactor.EventHandlerTable(EventID.MEMBER_OUT_FIXED, handler_DeltaStream_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_DeltaStream_stop),
            new EventFactor.EventHandlerTable(EventID.CHANGE_POKE_BEFORE, handler_DeltaStream_stop),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_DEAD, handler_DeltaStream_stop),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_DeltaStream_stop),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AirLock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_AirLock_MemberIn),
            new EventFactor.EventHandlerTable(EventID.WEATHER_CHECK, handler_AirLock_ChangeWeather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IcoBody = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_IceBody),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AmeukeZara = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_AmeukeZara),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SunPower = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_SunPower_Weather),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_SunPower_AtkPower),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rinpun = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_Rinpun_Sick),
            new EventFactor.EventHandlerTable(EventID.ADD_RANK_TARGET, handler_Rinpun_Rank),
            new EventFactor.EventHandlerTable(EventID.SHRINK_CHECK, handler_Rinpun_Shrink),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION_PREV, handler_Rinpun_Guard),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_PREV, handler_Rinpun_GuardHitEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TennoMegumi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_TennoMegumi),
            new EventFactor.EventHandlerTable(EventID.ADD_RANK_TARGET, handler_TennoMegumi),
            new EventFactor.EventHandlerTable(EventID.SP_ADDITIONAL_PER, handler_TennoMegumi),
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_TennoMegumi_Shrink),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UruoiBody = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_UruoiBody),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dappi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Dappi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PoisonHeal = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SICK_DAMAGE, handler_PoisonHeal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KabutoArmor = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_KabutoArmor),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyouun = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_Kyouun),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IkarinoTubo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_IkarinoTubo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DokunoToge = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_DokunoToge),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seidenki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Seidenki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HonoNoKarada = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_HonoNoKarada),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MeromeroBody = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_MeromeroBody),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Housi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Housi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Samehada = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Samehada),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yuubaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Yuubaku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HorobiNoSango = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_HorobiNoSango),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hensyoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Hensyoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Syncro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.POKESICK_FIXED, handler_Syncro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Isiatama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_KICKBACK, handler_Isiatama),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NormalSkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_NormalSkin),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_NormalSkin_Pow),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_NormalSkin_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Trace = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Trace),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Trace),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SizenKaifuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_OUT_FIXED, handler_SizenKaifuku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DownLoad = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Download),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Download),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yotimu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Yotimu),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Yotimu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KikenYoti = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_KikenYoti),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_KikenYoti),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Omitoosi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Omitoosi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Omitoosi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ganjou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ICHIGEKI_CHECK, handler_Ganjou_Ichigeki),
            new EventFactor.EventHandlerTable(EventID.KORAERU_CHECK, handler_Ganjou_KoraeCheck),
            new EventFactor.EventHandlerTable(EventID.KORAERU_EXE, handler_Ganjou_KoraeExe),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tennen = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RANK, handler_Tennen_hitRank),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER_PREV, handler_Tennen_AtkRank),
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD_PREV, handler_Tennen_DefRank),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tainetu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Tainetsu_WazaPow),
            new EventFactor.EventHandlerTable(EventID.SICK_DAMAGE, handler_Tainetsu_SickDmg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kansouhada = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Kansouhada_Weather),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Kansouhada_WazaPow),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Kansouhada_Check),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PunkRock = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_PunkRock_power),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_PunkRock_damage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tyosui = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Tyosui_Check),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikuden = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Tikuden_CheckEx),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenkiEngine = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_DenkiEngine_CheckEx),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kimottama = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY, handler_Kimottama),
            new EventFactor.EventHandlerTable(EventID.CHECK_AFFINITY_ONLY_ATTACKER, handler_Kimottama),
            new EventFactor.EventHandlerTable(EventID.KILL_HANDLER, handler_Kimottama_kill),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Kimottama_check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Kimottama_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Kimottama_RankEffectFailed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bouon = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Bouon),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuyuu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_FLYING, handler_Fuyuu),
            new EventFactor.EventHandlerTable(EventID.WAZA_NOEFF_BY_FLYING, handler_Fuyuu_Disp),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_Fuyuu_TurnCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FusiginaMamori = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_FusiginaMamori),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Namake = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_1ST, handler_Namake),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Namake_Get),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Nameke_Failed),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Nameke_EndAct),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Nameke_Reset),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Simerike = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Simerike),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Simerike_Effective),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Simerike_StartSeq),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Simerike_EndSeq),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Simerike_Ieki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moraibi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Moraibi_CheckNoEffect),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Moraibi_AtkPower),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Moraibi_Remove),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nightmare = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Nightmare),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nigeasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SKIP_NIGERU_CALC, handler_Nigeasi),
            new EventFactor.EventHandlerTable(EventID.NIGERU_EXMSG, handler_Nigeasi_Msg),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katayaburi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Katayaburi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Katayaburi_MemberIn),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Katayaburi_Start),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Katayaburi_End),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Katayaburi_Ieki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tenkiya = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_COMP, handler_Tenkiya_MemberInComp),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Tenkiya_GetTok),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Tenkiya_ChangeTok),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Tenkiya_TokOff),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_AIRLOCK, handler_Tenkiya_AirLock),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_Tenkiya_Weather),
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_DONE, handler_Tenkiya_Weather),
            new EventFactor.EventHandlerTable(EventID.WEATHER_CHANGE_AFTER, handler_Tenkiya_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yobimizu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_Yobimizu),
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET_END, handler_Yobimizu_TemptTargetEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Hiraisin_WazaExeStart),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Yobimizu_CheckNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hiraisin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET, handler_Hiraisin),
            new EventFactor.EventHandlerTable(EventID.TEMPT_TARGET_END, handler_Hiraisin_TemptTargetEnd),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_START, handler_Hiraisin_WazaExeStart),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Hiraisin_CheckNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyuuban = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_PUSHOUT, handler_Kyuuban),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HedoroEki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_DRAIN_END, handler_HedoroEki),
            new EventFactor.EventHandlerTable(EventID.NOTIFY_DEAD, handler_HedoroEki_Dead),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bukiyou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_PREV2, handler_Bukiyou_MemberInPrev),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Bukiyou_MemberInPrev),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Bukiyou_PreChange),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Bukiyou_IekiFixed),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Bukiyou_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_FAIL, handler_Bukiyou_ExeFail),
        };

		private static readonly ushort[] IgnoreItems_Bukiyou = new ushort[]
		{
            (ushort)ItemNo.KYOUSEIGIPUSU, (ushort)ItemNo.GAKUSYUUSOUTI, (ushort)ItemNo.OMAMORIKOBAN,
            (ushort)ItemNo.KOUUNNOOKOU,   (ushort)ItemNo.KIYOMENOOHUDA, (ushort)ItemNo.KAWARAZUNOISI,
            (ushort)ItemNo.SIAWASETAMAGO, (ushort)ItemNo.PAWAARISUTO,   (ushort)ItemNo.PAWAABERUTO,
            (ushort)ItemNo.PAWAARENZU,    (ushort)ItemNo.PAWAABANDO,    (ushort)ItemNo.PAWAAANKURU,
            (ushort)ItemNo.PAWAAUEITO,
        };

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nenchaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Nenchaku_NoEff),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_CHECK, handler_Nenchaku),
            new EventFactor.EventHandlerTable(EventID.ITEMSET_FAILED, handler_Nenchaku_Reaction),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Pressure = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Pressure_MemberIN),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Pressure_MemberIN),
            new EventFactor.EventHandlerTable(EventID.DECREMENT_PP, handler_Pressure),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_ENABLE, handler_MagicGuard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Akusyuu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_Akusyuu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kagefumi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NIGERU_FORBID, handler_Kagefumi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Arijigoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NIGERU_FORBID, handler_Arijigoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jiryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NIGERU_FORBID, handler_Jiryoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Karuwaza = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ITEMSET_DECIDE, handler_Karuwaza_BeforeItemSet),
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Karuwaza_Agility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Monohiroi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Monohiroi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TamaHiroi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_TamaHiroi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_WaruiTeguse = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L5, handler_WaruiTeguse),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NorowareBody = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_NorowareBody),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KudakeruYoroi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_KudakeruYoroi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikarazuku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Tikarazuku_WazaPow),
            new EventFactor.EventHandlerTable(EventID.ADD_SICK, handler_Tikarazuku_CheckFail),
            new EventFactor.EventHandlerTable(EventID.ADD_RANK_TARGET, handler_Tikarazuku_CheckFail),
            new EventFactor.EventHandlerTable(EventID.WAZA_SHRINK_PER, handler_Tikarazuku_ShrinkCheck),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_PREV, handler_Tikarazuku_HitChk),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makenki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FIXED, handler_Makenki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katiki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FIXED, handler_Katiki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yowaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Yowaki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MultiScale = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_MultiScale),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FriendGuard = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_NakamaIsiki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoKokoro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_BEGIN, handler_IyasiNoKokoro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubousou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Dokubousou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Netubousou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Netubousou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Telepassy = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_AunNoIki),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Murakke = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Murakke),
        };

        private const int MURAKKE_RANK_MAX = 5;
		private const int MURAKKE_PATTERN_MAX = 20;

		private static readonly WazaRankEffect[] handler_MurakkeTable = new WazaRankEffect[]
		{
			WazaRankEffect.ATTACK,     WazaRankEffect.DEFENCE, WazaRankEffect.SP_ATTACK,
			WazaRankEffect.SP_DEFENCE, WazaRankEffect.AGILITY,
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Boujin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Boujin_CalcDamage),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Boujin_WazaNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokusyu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Dokusyu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SaiseiRyoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_OUT_FIXED, handler_SaiseiRyoku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hatomune = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Hatomune_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_Hatomune_Guard),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunakaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Sunakaki),
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Sunagakure_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MilacreSkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_MilacreSkin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Analyze = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Sinuti),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SunanoTikara = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SunanoTikara),
            new EventFactor.EventHandlerTable(EventID.WEATHER_REACTION, handler_Sunagakure_Weather),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Surinuke = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Surinuke_Start),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Surinuke_End),
            new EventFactor.EventHandlerTable(EventID.MIGAWARI_THREW, handler_Surinuke_MigawariThrew),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BarrierFree = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_BarrierFree),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_BarrierFree),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JisinKajou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_JisinKajou),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UltraForce = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_UltraForce),
        };

		private static readonly ultraForce_GetEffectRankTypeTableElem[] RANK_VALUE_TABLE = new ultraForce_GetEffectRankTypeTableElem[]
		{
			new ultraForce_GetEffectRankTypeTableElem(WazaRankEffect.ATTACK,     BTL_POKEPARAM.ValueID.BPP_ATTACK),
			new ultraForce_GetEffectRankTypeTableElem(WazaRankEffect.DEFENCE,    BTL_POKEPARAM.ValueID.BPP_DEFENCE),
			new ultraForce_GetEffectRankTypeTableElem(WazaRankEffect.SP_ATTACK,  BTL_POKEPARAM.ValueID.BPP_SP_ATTACK),
			new ultraForce_GetEffectRankTypeTableElem(WazaRankEffect.SP_DEFENCE, BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE),
			new ultraForce_GetEffectRankTypeTableElem(WazaRankEffect.AGILITY,    BTL_POKEPARAM.ValueID.BPP_AGILITY),
		};

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SeiginoKokoro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_SeiginoKokoro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bibiri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Bibiri),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_Bibiri_RankEffectLastCheck),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FIXED, handler_Bibiri_RankEffectFixed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_JyoukiKikan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_JyoukiKikan),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Watage = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Watage),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Miira = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Miira),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SamayouTamasii = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_SamayouTamasii),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sousyoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_Sousyoku_CheckNoEffect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ItazuraGokoro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_WAZA_PRI, handler_ItazuraGokoro),
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_ItazuraGokoro_WazaParam),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_ItazuraGokoro_Reset),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicMirror = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_MagicMirror_ExeCheck),
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_TOKUSEI, handler_MagicMirror_Wait),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_REFRECT, handler_MagicMirror_Reflect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Syuukaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.TURNCHECK_END, handler_Syuukaku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeavyMetal = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEIGHT_RATIO, handler_HeavyMetal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_LightMetal = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WEIGHT_RATIO, handler_LightMetal),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Amanojaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKVALUE_CHANGE, handler_Amanojaku),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kinchoukan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_PREV2, handler_Kinchoukan_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Kinchoukan_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KagakuHenkaGas = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_PREV1, handler_KagakuHenkaGas_Start),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_KagakuHenkaGas_End),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE_FORCE, handler_KagakuHenkaGas_End),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jukusei = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_KINOMI_EFFECT_UP, handler_Jukusei_KinomiCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kawarimono = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_Hensin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Illusion = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Illusion_Damage),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Illusion_Ieki),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Illusion_ChangeTok),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GoodLuck = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_RATIO, handler_GoodLuck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MentalVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_MentalVeil_Check),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_MentalVeil_Failed),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_LAST_CHECK, handler_FlowerVeil_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_FAILED, handler_FlowerVeil_Guard),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_FlowerVeil_SickCheck),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_FlowerVeil_SickFailed),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_FlowerVeil_CheckInemuri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SweetVeil = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_SweetVeil_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_SweetVeil_PokeSickFailed),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_SweetVeil_Inemuri),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MirrorArmor = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.RANKEFF_REFLECT_CHECK, handler_MirroArmor_Check),
            new EventFactor.EventHandlerTable(EventID.RANKEFF_REFLECT_FIXED, handler_MirroArmor_Reflect),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HooBukuro = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.AFTER_ITEMEQUIP, handler_Hoobukuro),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HengenZizai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXE_DECIDE, handler_HengenZizai),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_DarkAura = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_DarkAura_MemberIN),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_DarkAura_MemberIN),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_DarkAura),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairyAura = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_FairyAura_MemberIN),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_FairyAura_MemberIN),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_FairyAura),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuraBreak = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_AuraBreak_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_AuraBreak_MemberIn),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER_BASE, handler_AuraBreak),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GanjouAgo = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_GanjouAgo),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gorimuchu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_CALL_DECIDE, handler_Gorimuchu_Waza),
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Gorimuchu_Power),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_BEFORE, handler_Gorimuchu_Change),
            new EventFactor.EventHandlerTable(EventID.CHECK_KODAWARI_FACTOR, handler_Gorimuchu_Check),
            new EventFactor.EventHandlerTable(EventID.TOKUSEI_DISABLE, handler_Gorimuchu_Change),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FurCoat = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_FurCoat),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KusaNoKegawa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEFENDER_GUARD, handler_KusaNoKegawa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_NumeNume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_NumeNume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KataiTume = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_KataiTume),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SkySkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_SkySkin),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_SkySkin_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_SkinEndCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_SkySkin_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairySkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_FairySkin),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_FairySkin_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_SkinEndCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_Fairykin_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezSkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_FreezSkin),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_FreezSkin_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_SkinEndCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_FreezSkin_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MegaLauncher = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_MegaLauncher_Pow),
            new EventFactor.EventHandlerTable(EventID.RECOVER_HP_RATIO, handler_MegaLauncher_Recover),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HayateNoTsubasa = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_WAZA_PRI, handler_HayateNoTsubasa),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Boudan = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.NOEFFECT_CHECK_L2, handler_Boudan),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_OyakoAi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_HIT_COUNT, handler_OyakoAi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Magician = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_magician_Start),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_magician),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyousei = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_kyousei_wazaSeqStart),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_kyousei_wazaSeqEnd),
            new EventFactor.EventHandlerTable(EventID.AFTER_ITEMEQUIP, handler_kyousei),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zikyuuryoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Zikyuuryoku_WazaDamageReaction),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mizugatame = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_Mizugatame_WazaDamageReaction),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Suihou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Suihou_AttackerPower),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_MizuNoBale_PokeSick),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_MizuNoBale_Wake),
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MizuNoBale_Wake),
            new EventFactor.EventHandlerTable(EventID.ACTPROC_END, handler_MizuNoBale_ActEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukikaki = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_Yukikaki_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haganetukai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Haganetukai_AttackerPower),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HaganeNoSeisin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_HaganeNoSeisin),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_UruoiVoice = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_UruoiVoice_WazaParam),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HealingShift = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.GET_WAZA_PRI, handler_HealingShift_GetWazaPriority),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecSkin = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_ElecSkinWazaParam),
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_ElecSkin_Pow),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_SkinEndCommon),
            new EventFactor.EventHandlerTable(EventID.CHANGE_G_WAZA, handler_ElecSkin_ChangeGWaza),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SurfTail = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CALC_AGILITY, handler_SurfTail_CalcAgility),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hitodenasi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CRITICAL_CHECK, handler_Hitodenasi_CriticalCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Enkaku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_PARAM, handler_Enkaku_WazaParam),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zyoounoigen = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_CHECK_3RD, handler_Zyoounoigen_WazaExeCheck),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MohuMohu = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_MohuMohu),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_KooriNoRinpun = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_KooriNoRinpun),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Battery = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_Battery_WazaPower),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerSpot = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_POWER, handler_PowerSpot),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Receiver = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEAD_ACTION_AFTER, handler_Receiver_DeadAfter),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_TobidasuNakami = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_TobidasuNakami_DamageProcStart),
            new EventFactor.EventHandlerTable(EventID.ICHIGEKI_GUARD, handler_TobidasuNakami_IchigekiGuard),
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_REACTION, handler_TobidasuNakami_WazaDamageReaction),
            new EventFactor.EventHandlerTable(EventID.ICHIGEKI_SUCCEED, handler_TobidasuNakami_WazaDamageReaction),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gyakuzyou = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_Gyakuzyou_DamegeProcStart),
            new EventFactor.EventHandlerTable(EventID.ICHIGEKI_CHECK, handler_Gyakuzyou_IchigekiCheck),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_REAL, handler_Gyakuzyou_EndHitReal),
        };

        private const int WIDX_NIGEGOSI_FULFILL_ENOUGH_HP = 0;
		private const int WIDX_NIGEGOSI_ATTACKER_DMG_STATUS = 1;

		private const int NIGEGOSI_ATTACKER_DMG_STATUS_NONE = 0;
		private const int NIGEGOSI_ATTACKER_DMG_STATUS_MYATTACK = 1;
		private const int NIGEGOSI_ATTACKER_DMG_STATUS_FULFILL_ITEM_EFFECT = 2;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nigegosi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_START, handler_Nigegosi_DamegeProcStart),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END, handler_Nigegosi_DamegeProcEnd),
            new EventFactor.EventHandlerTable(EventID.DAMAGEPROC_END_HIT_L3, handler_Nigegosi_EndHit),
            new EventFactor.EventHandlerTable(EventID.ICHIGEKI_GUARD, handler_Nigegosi_BeforeIchigeki),
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_BEFORE, handler_Nigegosi_SimpleDamageBefore),
            new EventFactor.EventHandlerTable(EventID.SIMPLE_DAMAGE_AFTER, handler_Nigegosi_SimpleDamageAfter),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoulHeart = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.DEAD_AFTER, handler_SoulHeart_DeadAfter),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Odoriko = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_START, handler_Odoriko_WazaSeqStart),
            new EventFactor.EventHandlerTable(EventID.WAZA_EXECUTE_EFFECTIVE, handler_Odoriko_ExecuteEffective),
            new EventFactor.EventHandlerTable(EventID.WAZASEQ_END, handler_Odoriko_WazaSeqEnd),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Husyoku = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_ADDSICK_FAIL_STD_SKIP, handler_Husyoku_CheckAddSickFailStdSkip),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecMaker = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_ElecMaker_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_ElecMaker_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhychoMaker = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_PhychoMaker_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_PhychoMaker_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_MistMaker = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_MistMaker_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_MistMaker_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_GrassMaker = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_GrassMaker_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_GrassMaker_MemberIn),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gitai = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN_EVO, handler_Gitai_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_Gitai_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_GROUND_AFTER, handler_Gitai_Change),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_Harikomi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.ATTACKER_POWER, handler_Harikomi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZettaiNemuri = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_ZettaiNemuri_MemberIn),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_ZettaiNemuri_MemberIn),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_CHECKFAIL, handler_ZettaiNemuri_AddSickCheckFail),
            new EventFactor.EventHandlerTable(EventID.CHECK_INEMURI, handler_Fumin_InemuriCheck),
            new EventFactor.EventHandlerTable(EventID.ADDSICK_FAILED, handler_AddSickFailCommon),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_BrainPrism = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.WAZA_DMG_PROC3, handler_BrainPrism),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HutouNoTurugi = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_HutouNoTurugi),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_HutouNoTurugi),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_HukutuNoTate = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.MEMBER_IN, handler_HukutuNoTate),
            new EventFactor.EventHandlerTable(EventID.CHANGE_TOKUSEI_AFTER, handler_HukutuNoTate),
        };
        private static readonly EventFactor.EventHandlerTable[] HandlerTable_ScrewObire = new EventFactor.EventHandlerTable[]
        {
            new EventFactor.EventHandlerTable(EventID.CHECK_TEMPT_TARGET_ENABLE, handler_ScrewObire_Tempt),
            new EventFactor.EventHandlerTable(EventID.CHECK_AIM_TARGET_ENABLE, handler_ScrewObire_Aim),
        };

        // TODO
        public static uint numHandlersWithHandlerPri(ushort pri, ushort numHandlers) { return default; }
		
		// TODO
		public static ushort calcTokHandlerSubPriority(BTL_POKEPARAM bpp) { return default; }
		
		// TODO
		public static bool isOccurPer(EventFactor.EventHandlerArgs args, byte per) { return default; }
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(TokuseiNo tokusei) { return default; }
		
		// TODO
		public static void Add(EventSystem pEventSystem, BTL_POKEPARAM bpp) { }
		
		// TODO
		public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM bpp) { }
		
		// TODO
		public static void Swap(EventSystem pEventSystem, BTL_POKEPARAM pp1, BTL_POKEPARAM pp2) { }
		
		// TODO
		public static bool common_IsShineLocalWeather(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void common_IkakuNoEffect_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID, byte workIdx) { }
		
		// TODO
		public static void common_IkakuNoEffect_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID, byte workIdx) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Ikaku_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seisinryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Seisinryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Seisinryoku_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Seisinryoku_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fukutsuno(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FukutsunoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AtuiSibou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AtuiSibou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikaramoti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikaramoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Suisui(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Suisui(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Youryokuso(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Youryokuso(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hayaasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hayaasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tidoriasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tidoriasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Harikiri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Harikiri_HitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Harikiri_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Atodasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Atodasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SlowStart(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SlowStart_Agility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_SlowStart_Declare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fukugan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fukugan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunagakure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunagakure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sunagakure_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukigakure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukigakure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yukigakure_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_guard(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Iromegane(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Iromegane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HardRock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HardRock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sniper(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sniper(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kasoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kasoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tekiouryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tekiouryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mouka(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Mouka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gekiryu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gekiryu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sinryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sinryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MusinoSirase(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MusinoSirase(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_hpborder_powerup(in EventFactor.EventHandlerArgs args, in byte pokeID, in byte wazaType) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Konjou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Konjou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Plus(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PlusMinus(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool checkExistTokuseiFriend(in EventFactor.EventHandlerArgs args, byte pokeID, TokuseiNo tokuseiID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerGift(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FlowerGift_MemberInComp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_GotTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_TokOff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_AirLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_TokChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool checkFlowerGiftEnablePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void common_FlowerGift_FormChange(in EventFactor.EventHandlerArgs args, byte pokeID, byte nextForm, byte fTokWin) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tousousin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tousousin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Technician(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Technician(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TetunoKobusi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TetunoKobusi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sutemi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sutemi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FusiginaUroko(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FusiginaUroko(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SkillLink(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SkillLink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KairikiBasami(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KairikiBasami_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KairikiBasami_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Surudoime(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Surudoime_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surudoime_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surudoime_HitRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ClearBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ClearBody_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ClearBody_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_RankDownGuard_Check(in EventFactor.EventHandlerArgs args, in byte pokeID, in WazaRankEffect rankType) { }
		
		// TODO
		public static void common_RankDownGuard_Fixed(in EventFactor.EventHandlerArgs args, in byte pokeID, in byte tokwin_pokeID, in ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tanjun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tanjun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LeafGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_LeafGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_LeafGuard_InemuriCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juunan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Juunan_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juunan_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juunan_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fumin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fumin_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_InemuriCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagumaNoYoroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MagumaNoYoroi_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagumaNoYoroi_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagumaNoYoroi_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Meneki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Meneki_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Meneki_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Meneki_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MizuNoBale(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MizuNoBale_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MizuNoBale_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MizuNoBale_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MyPace(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MyPace_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_AddSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Donkan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Donkan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_AddSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static void handler_AddSickFailCommon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_TokuseiWake_CureSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick) { }
		
		// TODO
		public static void common_TokuseiWake_CureSickCore(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick) { }
		
		// TODO
		public static void handler_Donkan_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PastelVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Pastelveil_SickFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Pastelveil_SickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PastelVeil_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PastelVeil_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_FriendCureSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick cureSick) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Amefurasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Amefurasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hideri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hideri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunaokosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunaokosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunahaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunahaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukifurasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukifurasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hajimarinoumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hajimarinoumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hajimarinoumi_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Owarinodaiti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Owarinodaichi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Owarinodaichi_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DeltaStream(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DeltaStream(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DeltaStream_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_change(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather, ushort boostItem, bool isPermanent) { }
		
		// TODO
		public static void common_weather_stop(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static bool common_check_tokusei(in EventFactor.EventHandlerArgs args, byte selfPokeId, ushort tokusei) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AirLock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AirLock_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AirLock_ChangeWeather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IcoBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IceBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AmeukeZara(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AmeukeZara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_recover(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SunPower(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SunPower_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SunPower_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Rinpun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Rinpun_Sick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Rank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Shrink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_GuardHitEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TennoMegumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TennoMegumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TennoMegumi_Shrink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UruoiBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UruoiBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dappi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dappi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PoisonHeal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PoisonHeal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KabutoArmor(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KabutoArmor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyouun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kyouun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IkarinoTubo(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IkarinoTubo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DokunoToge(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DokunoToge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seidenki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Seidenki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HonoNoKarada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HonoNoKarada(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MeromeroBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MeromeroBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Housi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Housi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_touchAddSick(EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick, in BTL_SICKCONT sickCont, byte per) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Samehada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Samehada(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yuubaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yuubaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HorobiNoSango(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool common_Horobinouta(in EventFactor.EventHandlerArgs args, in byte pokeID, BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static void handler_HorobiNoSango(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hensyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hensyoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Syncro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Syncro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Isiatama(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Isiatama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NormalSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NormalSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NormalSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NormalSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Trace(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Trace(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SizenKaifuku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SizenKaifuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DownLoad(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Download(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yotimu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yotimu(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public static byte get_yotimu_wazapri(WazaNo waza)
		{
			if (WAZADATA.GetDamageType(waza) == WazaDamageType.NONE)
				return 1;

			byte power = (byte)WAZADATA.GetPower(waza);
			if (power == 1)
			{
				if (WAZADATA.GetCategory(waza) == WazaCategory.ICHIGEKI)
					return 150;

				switch (waza)
				{
					case WazaNo.KAUNTAA:
					case WazaNo.MIRAAKOOTO:
					case WazaNo.METARUBAASUTO:
						return 120;
					default:
						return 80;
				}
			}

			return power;
		}

		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KikenYoti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KikenYoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool check_kikenyoti_enemys(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool check_kikenyoti_poke(in EventFactor.EventHandlerArgs args, BTL_POKEPARAM bppUser, BTL_POKEPARAM bppEnemy) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Omitoosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Omitoosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ganjou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Ganjou_Ichigeki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ganjou_KoraeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ganjou_KoraeExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tennen(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tennen_hitRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tennen_AtkRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tennen_DefRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tainetu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tainetsu_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tainetsu_SickDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_TypeNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID, byte wazaType) { return default; }
		
		// TODO
		public static void common_TypeRecoverHP(in EventFactor.EventHandlerArgs args, byte pokeID, byte denomHP) { }
		
		// TODO
		public static void common_TypeNoEffect_Rankup(in EventFactor.EventHandlerArgs args, byte pokeID, WazaRankEffect rankType, byte volume) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kansouhada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kansouhada_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kansouhada_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kansouhada_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PunkRock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PunkRock_power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PunkRock_damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tyosui(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tyosui_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikuden(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikuden_CheckEx(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DenkiEngine(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DenkiEngine_CheckEx(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kimottama(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kimottama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_kill(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bouon(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Bouon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuyuu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fuyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fuyuu_Disp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fuyuu_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FusiginaMamori(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FusiginaMamori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Namake(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Namake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Namake_Get(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_Failed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_EndAct(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_Reset(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Simerike(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Simerike(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_Effective(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_StartSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_EndSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Simerike_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Moraibi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Moraibi_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moraibi_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moraibi_Remove(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nightmare(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nightmare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nigeasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nigeasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigeasi_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katayaburi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Katayaburi_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tenkiya(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tenkiya_MemberInComp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_GetTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_AirLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_ChangeTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_TokOff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Tenkiya_Off(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_TenkiFormChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yobimizu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yobimizu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yobimizu_TemptTargetEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yobimizu_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hiraisin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hiraisin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_TemptTargetEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_WazaExeStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_WazaTargetChangeToMe(in EventFactor.EventHandlerArgs args, byte pokeID, byte wazaType, TemptTargetPriority temptPriority, TemptTargetCause temptCause) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyuuban(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kyuuban(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HedoroEki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HedoroEki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HedoroEki_Dead(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bukiyou(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool handler_Bukiyou_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static void handler_Bukiyou_MemberInPrev(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_PreChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_IekiFixed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_ExeFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nenchaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nenchaku_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nenchaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nenchaku_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Pressure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Pressure_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Pressure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_MemberInTokMessage(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MagicGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Akusyuu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Akusyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kagefumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kagefumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Arijigoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Arijigoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jiryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Jiryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Karuwaza(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Karuwaza_BeforeItemSet(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Karuwaza_Agility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Monohiroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Monohiroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool monohiroi_search(in EventFactor.EventHandlerArgs args, byte pokeID, out byte targetPokeID)
		{
			targetPokeID = default;
			return default;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TamaHiroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TamaHiroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WaruiTeguse(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_WaruiTeguse(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NorowareBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NorowareBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KudakeruYoroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KudakeruYoroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikarazuku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikarazuku_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_ShrinkCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_HitChk(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool IsTikarazukuEffecive(WazaNo waza) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makenki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Makenki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katiki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Katiki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yowaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yowaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MultiScale(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MultiScale(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FriendGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NakamaIsiki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoKokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IyasiNoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokubousou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dokubousou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Netubousou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Netubousou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Telepassy(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AunNoIki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Murakke(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Murakke(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Boujin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Boujin_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Boujin_WazaNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokusyu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dokusyu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SaiseiRyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SaiseiRyoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hatomune(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hatomune_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hatomune_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunakaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunakaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MilacreSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MilacreSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Analyze(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sinuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SunanoTikara(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SunanoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Surinuke(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool handler_Surinuke_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static void handler_Surinuke_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surinuke_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surinuke_MigawariThrew(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BarrierFree(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_BarrierFree(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JisinKajou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_JisinKajou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UltraForce(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UltraForce(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaRankEffect ultraForce_GetEffectRankType(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SeiginoKokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SeiginoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bibiri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Bibiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bibiri_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bibiri_RankEffectFixed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JyoukiKikan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_JyoukiKikan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Watage(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Watage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Miira(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Miira(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SamayouTamasii(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SamayouTamasii(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sousyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sousyoku_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ItazuraGokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ItazuraGokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ItazuraGokoro_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ItazuraGokoro_Reset(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_Wait(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicMirror(ref EventPriority prio) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Syuukaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Syuukaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeavyMetal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HeavyMetal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LightMetal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_LightMetal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Amanojaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Amanojaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kinchoukan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kinchoukan_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Kinchoukan_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KagakuHenkaGas(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KagakuHenkaGas_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KagakuHenkaGas_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jukusei(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Jukusei_KinomiCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kawarimono(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hensin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Illusion(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Illusion_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Illusion_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Illusion_ChangeTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_IllusionBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GoodLuck(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GoodLuck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MentalVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MentalVeil_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MentalVeil_Failed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_FriendSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FlowerVeil_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_SickCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_SickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_CheckInemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_IsFlowerVeilTarget(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SweetVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SweetVeil_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SweetVeil_PokeSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SweetVeil_Inemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MirrorArmor(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool checkMirrorArmorCause(RankEffectCause cause) { return default; }
		
		// TODO
		public static void handler_MirroArmor_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MirroArmor_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HooBukuro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hoobukuro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HengenZizai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HengenZizai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DarkAura(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DarkAura_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DarkAura(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairyAura(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FairyAura_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FairyAura(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuraBreak(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AuraBreak_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GanjouAgo(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GanjouAgo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gorimuchu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gorimuchu_Waza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Change(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FurCoat(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FurCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KusaNoKegawa(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KusaNoKegawa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NumeNume(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NumeNume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KataiTume(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KataiTume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Skin_ChangeType(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }
		
		// TODO
		public static void common_Skin_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }
		
		// TODO
		public static void common_Skin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID, WazaNo waza) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SkySkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SkySkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkySkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkySkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairySkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FairySkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FairySkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fairykin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FreezSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FreezSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FreezSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkinEndCommon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MegaLauncher(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MegaLauncher_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MegaLauncher_Recover(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HayateNoTsubasa(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HayateNoTsubasa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Boudan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Boudan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_OyakoAi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_OyakoAi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Magician(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_magician_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_magician(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool magician_swapitem(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyousei(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_kyousei_wazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_kyousei_wazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_kyousei(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void kyousei_commonProc(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zikyuuryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Zikyuuryoku_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mizugatame(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Mizugatame_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Suihou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Suihou_AttackerPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukikaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukikaki_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haganetukai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Haganetukai_AttackerPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HaganeNoSeisin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HaganeNoSeisin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UruoiVoice(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UruoiVoice_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HealingShift(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HealingShift_GetWazaPriority(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ElecSkinWazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ElecSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ElecSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SurfTail(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SurfTail_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hitodenasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hitodenasi_CriticalCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Enkaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Enkaku_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zyoounoigen(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Zyoounoigen_WazaExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MohuMohu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MohuMohu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KooriNoRinpun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KooriNoRinpun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Battery(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Battery_WazaPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerSpot(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PowerSpot(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Receiver(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Receiver_DeadAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TobidasuNakami(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TobidasuNakami_DamageProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TobidasuNakami_IchigekiGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void tobidasuNakami_RegisterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TobidasuNakami_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gyakuzyou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gyakuzyou_DamegeProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gyakuzyou_IchigekiCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool gyakuzyou_isEnoughHP(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Gyakuzyou_EndHitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_CheckTarget(in EventFactor.EventHandlerArgs args, byte checkPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nigegosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nigegosi_DamegeProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_BeforeIchigeki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_DamegeProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_EndHit(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_SimpleDamageBefore(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_SimpleDamageAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void nigegosi_CheckBeforeDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void nigegosi_AfterDamage_Full(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool nigegosi_AfterDamage_shouldEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void nigegosi_AfterDamage_Effect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool nigegosi_isQuitBattle(in EventFactor.EventHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoulHeart(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SoulHeart_DeadAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Odoriko(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Odoriko_WazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Odoriko_ExecuteEffective(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Odoriko_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static BtlPokePos odoriko_GetTargetPos(in EventFactor.EventHandlerArgs args, byte odorikoPokeID, byte attackPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Husyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Husyoku_CheckAddSickFailStdSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ElecMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhychoMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PhychoMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MistMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MistMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GrassMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GrassMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_GroundMaker(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gitai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gitai_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gitai_Change(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Harikomi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Harikomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZettaiNemuri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ZettaiNemuri_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ZettaiNemuri_AddSickCheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BrainPrism(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_BrainPrism(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HutouNoTurugi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HutouNoTurugi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HukutuNoTate(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HukutuNoTate(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ScrewObire(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ScrewObire_Tempt(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ScrewObire_Aim(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc(ref EventPriority prio);

		private struct GET_FUNC_TABLE_ELEM
		{
			public TokuseiNo tokusei;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(TokuseiNo tokusei, HandlerGetFunc func)
			{
				this.tokusei = tokusei;
				this.func = func;
			}
		}

		private class MAX_PRIORITY_PARAM
		{
			public byte pokeID;
			public WazaNo wazaID;
		}

		private struct ultraForce_GetEffectRankTypeTableElem
		{
			public WazaRankEffect rankType;
			public BTL_POKEPARAM.ValueID pokeValueID;
			
			public ultraForce_GetEffectRankTypeTableElem(WazaRankEffect rankType, BTL_POKEPARAM.ValueID pokeValueID)
			{
				this.rankType = rankType;
				this.pokeValueID = pokeValueID;
			}
		}

	}
}