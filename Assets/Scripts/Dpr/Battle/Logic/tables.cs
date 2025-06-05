using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class tables
    {
        private static readonly ushort[] IsMatchEncoreFailTable = new ushort[]
        {
            // 0,                                    Encore,                              Mirror Move,                             Transform,
            (ushort)WazaNo.NULL,                     (ushort)WazaNo.ANKOORU,              (ushort)WazaNo.OUMUGAESI,                (ushort)WazaNo.HENSIN,
            // Mimic,                                Sketch,                              Breakneck Blitz (Physical),              Breakneck Blitz (Special),
            (ushort)WazaNo.MONOMANE,                 (ushort)WazaNo.SUKETTI,              (ushort)WazaNo.URUTORADASSYUATAKKU,      (ushort)WazaNo.NOOMARUZENRYOKU,
            // All-Out Pummeling (Physical),         All-Out Pummeling (Special),         Supersonic Skystrike (Physical),         Supersonic Skystrike (Special),
            (ushort)WazaNo.ZENRYOKUMUSOUGEKIRETUKEN, (ushort)WazaNo.KAKUTOUZENRYOKU,      (ushort)WazaNo.FAINARUDAIBUKURASSYU,     (ushort)WazaNo.HIKOUZENRYOKU,
            // Acid Downpour (Physical),             Acid Downpour (Special),             Tectonic Rage (Physical),                Tectonic Rage (Special),
            (ushort)WazaNo.ASIDDOPOIZUNDERIITO,      (ushort)WazaNo.DOKUZENRYOKU,         (ushort)WazaNo.RAIZINGURANDOOOBAA,       (ushort)WazaNo.ZIMENZENRYOKU,
            // Continental Crush (Physical),         Continental Crush (Special),         Savage Spin-Out (Physical),              Savage Spin-Out (Special),
            (ushort)WazaNo.WAARUZUENDOFOORU,         (ushort)WazaNo.IWAZENRYOKU,          (ushort)WazaNo.ZETTAIHOSYOKUKAITENZAN,   (ushort)WazaNo.MUSIZENRYOKU,
            // Never-Ending Nightmare (Physical),    Never-Ending Nightmare (Special),    Corkscrew Crash (Physical),              Corkscrew Crash (Special),
            (ushort)WazaNo.MUGENANYAHENOIZANAI,      (ushort)WazaNo.GOOSUTOZENRYOKU,      (ushort)WazaNo.TYOUZETURASENRENGEKI,     (ushort)WazaNo.HAGANEZENRYOKU,
            // Inferno Overdrive (Physical),         Inferno Overdrive (Special),         Hydro Vortex (Physical),                 Hydro Vortex (Special),
            (ushort)WazaNo.DAINAMIKKUHURUHUREIMU,    (ushort)WazaNo.HONOOZENRYOKU,        (ushort)WazaNo.SUUPAAAKUATORUNEEDO,      (ushort)WazaNo.MIZUZENRYOKU,
            // Bloom Doom (Physical),                Bloom Doom (Special),                Gigavolt Havoc (Physical),               Gigavolt Havoc (Special),
            (ushort)WazaNo.BURUUMUSYAINEKUSUTORA,    (ushort)WazaNo.KUSAZENRYOKU,         (ushort)WazaNo.SUPAAKINGUGIGABORUTO,     (ushort)WazaNo.DENKIZENRYOKU,
            // Shattered Psyche (Physical),          Shattered Psyche (Special),          Subzero Slammer (Physical),              Subzero Slammer (Special),
            (ushort)WazaNo.MAKISIMAMUSAIBUREIKAA,    (ushort)WazaNo.ESUPAAZENRYOKU,       (ushort)WazaNo.REIZINGUZIOHURIIZU,       (ushort)WazaNo.KOORIZENRYOKU,
            // Devastating Drake (Physical),         Devastating Drake (Special),         Black Hole Eclipse (Physical),           Black Hole Eclipse (Special),
            (ushort)WazaNo.ARUTHIMETTODORAGONBAAN,   (ushort)WazaNo.DORAGONZENRYOKU,      (ushort)WazaNo.BURAKKUHOORUIKURIPUSU,    (ushort)WazaNo.AKUZENRYOKU,
            // Twinkle Tackle (Physical),            Twinkle Tackle (Special),            Catastropika,                            Sinister Arrow Raid,
            (ushort)WazaNo.RABURIISUTAAINPAKUTO,     (ushort)WazaNo.FEARIIZENRYOKU,       (ushort)WazaNo.HISSATUNOPIKATYUUTO,      (ushort)WazaNo.SYADOOAROOZUSUTORAIKU,
            // Malicious Moonsault,                  Oceanic Operetta,                    Guardian of Alola,                       Soul-Stealing 7-Star Strike,
            (ushort)WazaNo.HAIPAADAAKUKURASSYAA,     (ushort)WazaNo.WADATUMINOSINFONIA,   (ushort)WazaNo.GAADHIANDEAROORA,         (ushort)WazaNo.SITISEIDAKKONTAI,
            // Stoked Sparksurfer,                   Pulverizing Pancake,                 Extreme Evoboost,                        Genesis Supernova,
            (ushort)WazaNo.RAITONINGUSAAHURAIDO,     (ushort)WazaNo.HONKIWODASUKOUGEKI,   (ushort)WazaNo.NAINEBORUBUUSUTO,         (ushort)WazaNo.ORIZINZUSUUPAANOVHA,
            // 10,000,000 Volt Thunderbolt,          Splintered Stormshards,              Light That Burns the Sky,                Searing Sunraze Smash,
            (ushort)WazaNo._1000MANBORUTO,           (ushort)WazaNo.RAZIARUEZZISUTOOMU,   (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI, (ushort)WazaNo.SANSYAINSUMASSYAA,
            // Menacing Moonraze Maelstrom,          Let's Snuggle Forever,               Clangorous Soulblaze,                    Metronome,
            (ushort)WazaNo.MUUNRAITOBURASUTAA,       (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.BUREIZINGUSOURUBIITO,     (ushort)WazaNo.YUBIWOHURU,
            // Nature Power,                         Assist,                              Sleep Talk,                              Mirror Move,
            (ushort)WazaNo.SIZENNOTIKARA,            (ushort)WazaNo.NEKONOTE,             (ushort)WazaNo.NEGOTO,                   (ushort)WazaNo.OUMUGAESI,
            // Me First,                             Copycat,                             Max Guard,                               Dynamax Cannon,
            (ushort)WazaNo.SAKIDORI,                 (ushort)WazaNo.MANEKKO,              (ushort)WazaNo.DAIWHOORU,                (ushort)WazaNo.DAIMAKKUSUHOU,
            // Max Flare,                            Max Flutterby,                       Max Lightning,                           Max Strike,
            (ushort)WazaNo.DAIBAAN,                  (ushort)WazaNo.DAIWAAMU,             (ushort)WazaNo.DAISANDAA,                (ushort)WazaNo.DAIATAKKU,
            // Max Knuckle,                          Max Phantasm,                        Max Hailstorm,                           Max Ooze,
            (ushort)WazaNo.DAINAKKURU,               (ushort)WazaNo.DAIHOROU,             (ushort)WazaNo.DAIAISU,                  (ushort)WazaNo.DAIASIDDO,
            // Max Geyser,                           Max Airstream,                       Max Starfall,                            Max Wyrmwind,
            (ushort)WazaNo.DAISUTORIIMU,             (ushort)WazaNo.DAIJETTO,             (ushort)WazaNo.DAIFEARII,                (ushort)WazaNo.DAIDORAGUUN,
            // Max Mindstorm,                        Max Rockfall,                        Max Quake,                               Max Darkness,
            (ushort)WazaNo.DAISAIKO,                 (ushort)WazaNo.DAIROKKU,             (ushort)WazaNo.DAIAASU,                  (ushort)WazaNo.DAIAAKU,
            // Max Overgrowth,                       Max Steelspike,
            (ushort)WazaNo.DAISOUGEN,                (ushort)WazaNo.DAISUTIRU,
        };
        private static readonly ushort[] IsSakidoriFailWazaTable = new ushort[]
        {
            // 0,                              Mirror Coat,                        Counter,                              Metal Burst,
            (ushort)WazaNo.NULL,               (ushort)WazaNo.MIRAAKOOTO,          (ushort)WazaNo.KAUNTAA,               (ushort)WazaNo.METARUBAASUTO,
            // Focus Punch,                    Me First,                           Thief,                                Covet,
            (ushort)WazaNo.KIAIPANTI,          (ushort)WazaNo.SAKIDORI,            (ushort)WazaNo.DOROBOU,               (ushort)WazaNo.HOSIGARU,
            // Chatter,                        Struggle,                           Belch,                                Shell Trap,
            (ushort)WazaNo.OSYABERI,           (ushort)WazaNo.WARUAGAKI,           (ushort)WazaNo.GEPPU,                 (ushort)WazaNo.TORAPPUSHERU,
            // Beak Blast,                     Catastropika,                       Sinister Arrow Raid,                  Malicious Moonsault,
            (ushort)WazaNo.KUTIBASIKYANON,     (ushort)WazaNo.HISSATUNOPIKATYUUTO, (ushort)WazaNo.SYADOOAROOZUSUTORAIKU, (ushort)WazaNo.HAIPAADAAKUKURASSYAA,
            // Oceanic Operetta,               Guardian of Alola,                  Soul-Stealing 7-Star Strike,          Stoked Sparksurfer,
            (ushort)WazaNo.WADATUMINOSINFONIA, (ushort)WazaNo.GAADHIANDEAROORA,    (ushort)WazaNo.SITISEIDAKKONTAI,      (ushort)WazaNo.RAITONINGUSAAHURAIDO,
            // Pulverizing Pancake,            Extreme Evoboost,                   Genesis Supernova,                    10,000,000 Volt Thunderbolt,
            (ushort)WazaNo.HONKIWODASUKOUGEKI, (ushort)WazaNo.NAINEBORUBUUSUTO,    (ushort)WazaNo.ORIZINZUSUUPAANOVHA,   (ushort)WazaNo._1000MANBORUTO,
            // Splintered Stormshards,
            (ushort)WazaNo.RAZIARUEZZISUTOOMU,
        };
        private static readonly ushort[] IsDelayAttackWazaTbl = new ushort[]
        {
            // 0,                Future Sight,             Doom Desire,
            (ushort)WazaNo.NULL, (ushort)WazaNo.MIRAIYOTI, (ushort)WazaNo.HAMETUNONEGAI,
        };
        private static readonly ushort[] IsZWaza_GeneralTable = new ushort[]
        {
            // Breakneck Blitz (Physical),         Breakneck Blitz (Special),      All-Out Pummeling (Physical),            All-Out Pummeling (Special),
            (ushort)WazaNo.URUTORADASSYUATAKKU,    (ushort)WazaNo.NOOMARUZENRYOKU, (ushort)WazaNo.ZENRYOKUMUSOUGEKIRETUKEN, (ushort)WazaNo.KAKUTOUZENRYOKU,
            // Supersonic Skystrike (Physical),    Supersonic Skystrike (Special), Acid Downpour (Physical),                Acid Downpour (Special),
            (ushort)WazaNo.FAINARUDAIBUKURASSYU,   (ushort)WazaNo.HIKOUZENRYOKU,   (ushort)WazaNo.ASIDDOPOIZUNDERIITO,      (ushort)WazaNo.DOKUZENRYOKU,
            // Tectonic Rage (Physical),           Tectonic Rage (Special),        Continental Crush (Physical),            Continental Crush (Special),
            (ushort)WazaNo.RAIZINGURANDOOOBAA,     (ushort)WazaNo.ZIMENZENRYOKU,   (ushort)WazaNo.WAARUZUENDOFOORU,         (ushort)WazaNo.IWAZENRYOKU,
            // Savage Spin-Out (Physical),         Savage Spin-Out (Special),      Never-Ending Nightmare (Physical),       Never-Ending Nightmare (Special),
            (ushort)WazaNo.ZETTAIHOSYOKUKAITENZAN, (ushort)WazaNo.MUSIZENRYOKU,    (ushort)WazaNo.MUGENANYAHENOIZANAI,      (ushort)WazaNo.GOOSUTOZENRYOKU,
            // Corkscrew Crash (Physical),         Corkscrew Crash (Special),      Inferno Overdrive (Physical),            Inferno Overdrive (Special),
            (ushort)WazaNo.TYOUZETURASENRENGEKI,   (ushort)WazaNo.HAGANEZENRYOKU,  (ushort)WazaNo.DAINAMIKKUHURUHUREIMU,    (ushort)WazaNo.HONOOZENRYOKU,
            // Hydro Vortex (Physical),            Hydro Vortex (Special),         Bloom Doom (Physical),                   Bloom Doom (Special),
            (ushort)WazaNo.SUUPAAAKUATORUNEEDO,    (ushort)WazaNo.MIZUZENRYOKU,    (ushort)WazaNo.BURUUMUSYAINEKUSUTORA,    (ushort)WazaNo.KUSAZENRYOKU,
            // Gigavolt Havoc (Physical),          Gigavolt Havoc (Special),       Shattered Psyche (Physical),             Shattered Psyche (Special),
            (ushort)WazaNo.SUPAAKINGUGIGABORUTO,   (ushort)WazaNo.DENKIZENRYOKU,   (ushort)WazaNo.MAKISIMAMUSAIBUREIKAA,    (ushort)WazaNo.ESUPAAZENRYOKU,
            // Subzero Slammer (Physical),         Subzero Slammer (Special),      Devastating Drake (Physical),            Devastating Drake (Special),
            (ushort)WazaNo.REIZINGUZIOHURIIZU,     (ushort)WazaNo.KOORIZENRYOKU,   (ushort)WazaNo.ARUTHIMETTODORAGONBAAN,   (ushort)WazaNo.DORAGONZENRYOKU,
            // Black Hole Eclipse (Physical),      Black Hole Eclipse (Special),   Twinkle Tackle (Physical),               Twinkle Tackle (Special),
            (ushort)WazaNo.BURAKKUHOORUIKURIPUSU,  (ushort)WazaNo.AKUZENRYOKU,     (ushort)WazaNo.RABURIISUTAAINPAKUTO,     (ushort)WazaNo.FEARIIZENRYOKU,
        };
        private static readonly ushort[] IsZWaza_SpecialTable = new ushort[]
        {
            // Catastropika,                     Sinister Arrow Raid,                  Malicious Moonsault,                 Oceanic Operetta,
            (ushort)WazaNo.HISSATUNOPIKATYUUTO,  (ushort)WazaNo.SYADOOAROOZUSUTORAIKU, (ushort)WazaNo.HAIPAADAAKUKURASSYAA, (ushort)WazaNo.WADATUMINOSINFONIA,
            // Guardian of Alola,                Soul-Stealing 7-Star Strike,          Stoked Sparksurfer,                  Pulverizing Pancake,
            (ushort)WazaNo.GAADHIANDEAROORA,     (ushort)WazaNo.SITISEIDAKKONTAI,      (ushort)WazaNo.RAITONINGUSAAHURAIDO, (ushort)WazaNo.HONKIWODASUKOUGEKI,
            // Extreme Evoboost,                 Genesis Supernova,                    10,000,000 Volt Thunderbolt,         Light That Burns the Sky,
            (ushort)WazaNo.NAINEBORUBUUSUTO,     (ushort)WazaNo.ORIZINZUSUUPAANOVHA,   (ushort)WazaNo._1000MANBORUTO,       (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI,
            // Searing Sunraze Smash,            Menacing Moonraze Maelstrom,          Let's Snuggle Forever,               Splintered Stormshards,
            (ushort)WazaNo.SANSYAINSUMASSYAA,    (ushort)WazaNo.MUUNRAITOBURASUTAA,    (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.RAZIARUEZZISUTOOMU,
            // Clangorous Soulblaze,
            (ushort)WazaNo.BUREIZINGUSOURUBIITO,
        };
        private static readonly ushort[] IsGWazaTable = new ushort[]
        {
            // Max Guard
            (ushort)WazaNo.DAIWHOORU,
        };
        private static readonly ushort[] IsGWaza_GeneralTable = new ushort[]
        {
            // Max Strike,            Max Knuckle,               Max Airstream,               Max Ooze,
            (ushort)WazaNo.DAIATAKKU, (ushort)WazaNo.DAINAKKURU, (ushort)WazaNo.DAIJETTO,     (ushort)WazaNo.DAIASIDDO,
            // Max Quake,             Max Rockfall,              Max Flutterby,               Max Phantasm,
            (ushort)WazaNo.DAIAASU,   (ushort)WazaNo.DAIROKKU,   (ushort)WazaNo.DAIWAAMU,     (ushort)WazaNo.DAIHOROU,
            // Max Steelspike,        Max Flare,                 Max Geyser,                  Max Overgrowth,
            (ushort)WazaNo.DAISUTIRU, (ushort)WazaNo.DAIBAAN,    (ushort)WazaNo.DAISUTORIIMU, (ushort)WazaNo.DAISOUGEN,
            // Max Lightning,         Max Mindstorm,             Max Hailstorm,               Max Wyrmwind,
            (ushort)WazaNo.DAISANDAA, (ushort)WazaNo.DAISAIKO,   (ushort)WazaNo.DAIAISU,      (ushort)WazaNo.DAIDORAGUUN,
            // Max Darkness,          Max Starfall
            (ushort)WazaNo.DAIAAKU,   (ushort)WazaNo.DAIFEARII,
        };
        private static readonly ushort[] IsPressureEffectiveWazaTable = new ushort[]
        {
            // Snatch,                    Imprison,             Spikes,                  Toxic Spikes,
            (ushort)WazaNo.YOKODORI,      (ushort)WazaNo.HUUIN, (ushort)WazaNo.MAKIBISI, (ushort)WazaNo.DOKUBISI,
            // Stealth Rock,
            (ushort)WazaNo.SUTERUSUROKKU,
        };
        private static readonly ushort[] IsGuardTypeSideEffectTable = new ushort[]
        {
            // Wide Guard Side Effect,                      Quick Guard Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_WIDEGUARD,    (ushort)BtlSideEffect.BTL_SIDEEFF_FASTGUARD,
            // Mat Block Side Effect,                       Crafty Shield Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_TATAMIGAESHI, (ushort)BtlSideEffect.BTL_SIDEEFF_TRICKGUARD,
        };
        private static readonly ushort[] IsCombiWazaTable = new ushort[]
        {
            // Fire Pledge,              Grass Pledge,               Water Pledge,
            (ushort)WazaNo.HONOONOTIKAI, (ushort)WazaNo.KUSANOTIKAI, (ushort)WazaNo.MIZUNOTIKAI,
        };
        private static readonly ushort[] Pri_6 = new ushort[]
        {
            // Full Restore,                0,
            (ushort)ItemNo.KAIHUKUNOKUSURI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[] Pri_5 = new ushort[]
        {
            // Awakening,                Ice Heal,                  0,
            (ushort)ItemNo.NEMUKEZAMASI, (ushort)ItemNo.KOORINAOSI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[] Pri_4 = new ushort[]
        {
            // Potion,                 Hyper Potion,                   Max Potion,                    0,
            (ushort)ItemNo.KIZUGUSURI, (ushort)ItemNo.SUGOIKIZUGUSURI, (ushort)ItemNo.MANTANNOKUSURI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[] Pri_3 = new ushort[]
        {
            // Full Heal,                0,
            (ushort)ItemNo.NANDEMONAOSI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[] Pri_2 = new ushort[]
        {
            // Paralyze Heal,         0,
            (ushort)ItemNo.MAHINAOSI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[] Pri_1 = new ushort[]
        {
            // Antidote,             Burn Heal,                  0,
            (ushort)ItemNo.DOKUKESI, (ushort)ItemNo.YAKEDONAOSI, (ushort)ItemNo.DUMMY_DATA,
        };
        private static readonly ushort[][] GetAIItemPriorityTable = new ushort[][] { Pri_1, Pri_2, Pri_3, Pri_4, Pri_5, Pri_6, };
        private static readonly ushort[] CheckItemCallNoEffectTable = new ushort[]
        {
            // Focus Band,                 Power Herb,                   Eject Button,                 Jaboca Berry,
            (ushort)ItemNo.KIAINOHATIMAKI, (ushort)ItemNo.PAWAHURUHAABU, (ushort)ItemNo.DASSYUTUBOTAN, (ushort)ItemNo.ZYAPONOMI,
            // Rowap Berry,                Custap Berry,                 Quick Claw,                   Absorb Bulb,
            (ushort)ItemNo.RENBUNOMI,      (ushort)ItemNo.IBANNOMI,      (ushort)ItemNo.SENSEINOTUME,  (ushort)ItemNo.KYUUKON,
            // Cell Battery,
            (ushort)ItemNo.ZYUUDENTI,
        };
        private static readonly ushort[] IsNoTargetItemTable = new ushort[]
        {
            // Fluffy Tail,              Poké Doll,                   Poké Toy,
            (ushort)ItemNo.ENEKONOSIPPO, (ushort)ItemNo.PIPPININGYOU, (ushort)ItemNo.POKEZYARASI,
        };
        private static readonly ushort[] IsRotoponItemTable = new ushort[]
        {
            // Roto HP Restore,        Roto PP Restore,          Roto Boost,              Roto Catch,
            (ushort)ItemNo.KAIHUKUPON, (ushort)ItemNo.PIIPIIPON, (ushort)ItemNo.HOZYOPON, (ushort)ItemNo.TUKAMAEPON,
        };
        private static readonly ushort[] IsKodawariItemTable = new ushort[]
        {
            // Choice Band,                  Choice Specs,                  Choice Scarf,
            (ushort)ItemNo.KODAWARIHATIMAKI, (ushort)ItemNo.KODAWARIMEGANE, (ushort)ItemNo.KODAWARISUKAAHU,
        };
        private static readonly ushort[] CheckNakamaDukuriFailTokuseiTable = new ushort[]
        {
            // Trace,                          Forecast,                         Multitype,                        Flower Gift,
            (ushort)TokuseiNo.TOREESU,         (ushort)TokuseiNo.TENKIYA,        (ushort)TokuseiNo.MARUTITAIPU,    (ushort)TokuseiNo.HURAWAAGIHUTO,
            // Zen Mode,                       Illusion,                         Imposter,                         Wonder Guard,
            (ushort)TokuseiNo.DARUMAMOODO,     (ushort)TokuseiNo.IRYUUZYON,      (ushort)TokuseiNo.KAWARIMONO,     (ushort)TokuseiNo.HUSIGINAMAMORI,
            // Stance Change,                  Zen Mode,                         RKS System,                       Disguise,
            (ushort)TokuseiNo.BATORUSUITTI,    (ushort)TokuseiNo.DARUMAMOODO,    (ushort)TokuseiNo.arSISUTEMU,     (ushort)TokuseiNo.BAKENOKAWA,
            // Schooling,                      Battle Bond,                      Power Construct,                  Comatose,
            (ushort)TokuseiNo.GYOGUN,          (ushort)TokuseiNo.KIZUNAHENGE,    (ushort)TokuseiNo.SUWAAMUTHENZI,  (ushort)TokuseiNo.ZETTAINEMURI,
            // Shields Down,                   Receiver,                         Power of Alchemy,                 Ice Face,
            (ushort)TokuseiNo.RIMITTOSIIRUDO,  (ushort)TokuseiNo.RESIIBAA,       (ushort)TokuseiNo.KAGAKUNOTIKARA, (ushort)TokuseiNo.AISUFEISU,
            // Neutralizing Gas,               Hunger Switch,
            (ushort)TokuseiNo.KAGAKUHENKAGASU, (ushort)TokuseiNo.HARAPEKOSUITTI,
        };
        private static readonly ushort[] CheckSkillSwapFailTokuseiTable = new ushort[]
        {
            // Wonder Guard,                  Multitype,                         Illusion,                         Stance Change,
            (ushort)TokuseiNo.HUSIGINAMAMORI, (ushort)TokuseiNo.MARUTITAIPU,     (ushort)TokuseiNo.IRYUUZYON,      (ushort)TokuseiNo.BATORUSUITTI,
            // Zen Mode,                      RKS System,                        Disguise,                         Schooling,
            (ushort)TokuseiNo.DARUMAMOODO,    (ushort)TokuseiNo.arSISUTEMU,      (ushort)TokuseiNo.BAKENOKAWA,     (ushort)TokuseiNo.GYOGUN,
            // Battle Bond,                   Power Construct,                   Comatose,                         Shields Down,
            (ushort)TokuseiNo.KIZUNAHENGE,    (ushort)TokuseiNo.SUWAAMUTHENZI,   (ushort)TokuseiNo.ZETTAINEMURI,   (ushort)TokuseiNo.RIMITTOSIIRUDO,
            // Ice Face,                      Neutralizing Gas,                  Hunger Switch,
            (ushort)TokuseiNo.AISUFEISU,      (ushort)TokuseiNo.KAGAKUHENKAGASU, (ushort)TokuseiNo.HARAPEKOSUITTI,
        };
        private static readonly ushort[] IsNeverChangeTokuseiTable = new ushort[]
        {
            // Multitype,                   Stance Change,                    Zen Mode,                      RKS System,
            (ushort)TokuseiNo.MARUTITAIPU,  (ushort)TokuseiNo.BATORUSUITTI,   (ushort)TokuseiNo.DARUMAMOODO, (ushort)TokuseiNo.arSISUTEMU,
            // Disguise,                    Schooling,                        Battle Bond,                   Power Construct,
            (ushort)TokuseiNo.BAKENOKAWA,   (ushort)TokuseiNo.GYOGUN,         (ushort)TokuseiNo.KIZUNAHENGE, (ushort)TokuseiNo.SUWAAMUTHENZI,
            // Comatose,                    Shields Down,                     Ice Face,                      Gulp Missile,
            (ushort)TokuseiNo.ZETTAINEMURI, (ushort)TokuseiNo.RIMITTOSIIRUDO, (ushort)TokuseiNo.AISUFEISU,   (ushort)TokuseiNo.UNOMISAIRU,
        };
        private static readonly ushort[] IsMatchAruseusPlateTable = new ushort[]
        {
            // Flame Plate,                 Splash Plate,                   Zap Plate,                      Meadow Plate,
            (ushort)ItemNo.HINOTAMAPUREETO, (ushort)ItemNo.SIZUKUPUREETO,   (ushort)ItemNo.IKAZUTIPUREETO,  (ushort)ItemNo.MIDORINOPUREETO,
            // Icicle Plate,                Fist Plate,                     Toxic Plate,                    Earth Plate,
            (ushort)ItemNo.TURARANOPUREETO, (ushort)ItemNo.KOBUSINOPUREETO, (ushort)ItemNo.MOUDOKUPUREETO,  (ushort)ItemNo.DAITINOPUREETO,
            // Sky Plate,                   Mind Plate,                     Insect Plate,                   Stone Plate,
            (ushort)ItemNo.AOZORAPUREETO,   (ushort)ItemNo.HUSIGINOPUREETO, (ushort)ItemNo.TAMAMUSIPUREETO, (ushort)ItemNo.GANSEKIPUREETO,
            // Spooky Plate,                Draco Plate,                    Dread Plate,                    Iron Plate,
            (ushort)ItemNo.MONONOKEPUREETO, (ushort)ItemNo.RYUUNOPUREETO,   (ushort)ItemNo.KOWAMOTEPUREETO, (ushort)ItemNo.KOUTETUPUREETO,
            // Pixie Plate,
            (ushort)ItemNo.SEIREIPUREETO,
        };
        private static readonly ushort[] IsMatchGuripusu2ChipTable = new ushort[]
        {
            // Fighting Memory,            Flying Memory,                 Poison Memory,                Ground Memory,
            (ushort)ItemNo.FAITOMEMORI,    (ushort)ItemNo.HURAINGUMEMORI, (ushort)ItemNo.POIZUNMEMORI,  (ushort)ItemNo.GURAUNDOMEMORI,
            // Rock Memory,                Bug Memory,                    Ghost Memory,                 Steel Memory,
            (ushort)ItemNo.ROKKUMEMORI,    (ushort)ItemNo.BAGUMEMORI,     (ushort)ItemNo.GOOSUTOMEMORI, (ushort)ItemNo.SUTIIRUMEMORI,
            // Fire Memory,                Water Memory,                  Grass Memory,                 Electric Memory,
            (ushort)ItemNo.FAIYAAMEMORI,   (ushort)ItemNo.UOOTAAMEMORI,   (ushort)ItemNo.GURASUMEMORI,  (ushort)ItemNo.EREKUTOROMEMORI,
            // Psychic Memory,             Ice Memory,                    Dragon Memory,                Dark Memory,
            (ushort)ItemNo.SAIKIKKUMEMORI, (ushort)ItemNo.AISUMEMORI,     (ushort)ItemNo.DORAGONMEMORI, (ushort)ItemNo.DAAKUMEMORI,
            // Fairy Memory,
            (ushort)ItemNo.FEARIIMEMORI,
        };
        private static readonly ushort[] IsMatchInsectaCasetteTable = new ushort[]
        {
            // Douse Drive,             Shock Drive,                   Burn Drive,                    Chill Drive,
            (ushort)ItemNo.AKUAKASETTO, (ushort)ItemNo.INAZUMAKASETTO, (ushort)ItemNo.BUREIZUKASETTO, (ushort)ItemNo.HURIIZUKASETTO,
        };
        private static readonly ushort[] IsMatchKatayaburiTargetTable = new ushort[]
        {
            // Wonder Guard,                  Soundproof,                      Levitate,                        Sand Veil,
            (ushort)TokuseiNo.HUSIGINAMAMORI, (ushort)TokuseiNo.BOUON,         (ushort)TokuseiNo.HUYUU,         (ushort)TokuseiNo.SUNAGAKURE,
            // Snow Cloak,                    Water Absorb,                    Battle Armor,                    Lightning Rod,
            (ushort)TokuseiNo.YUKIGAKURE,     (ushort)TokuseiNo.TYOSUI,        (ushort)TokuseiNo.KABUTOAAMAA,   (ushort)TokuseiNo.HIRAISIN,
            // Storm Drain,                   Shell Armor,                     Unaware,                         Suction Cups,
            (ushort)TokuseiNo.YOBIMIZU,       (ushort)TokuseiNo.SHERUAAMAA,    (ushort)TokuseiNo.TENNEN,        (ushort)TokuseiNo.KYUUBAN,
            // Simple,                        Tangled Feet,                    Solid Rock,                      Filter,
            (ushort)TokuseiNo.TANZYUN,        (ushort)TokuseiNo.TIDORIASI,     (ushort)TokuseiNo.HAADOROKKU,    (ushort)TokuseiNo.FIRUTAA,
            // Flash Fire,                    Motor Drive,                     Sticky Hold,                     Marvel Scale,
            (ushort)TokuseiNo.MORAIBI,        (ushort)TokuseiNo.DENKIENZIN,    (ushort)TokuseiNo.NENTYAKU,      (ushort)TokuseiNo.HUSIGINAUROKO,
            // Thick Fat,                     Heatproof,                       White Smoke,                     Clear Body,
            (ushort)TokuseiNo.ATUISIBOU,      (ushort)TokuseiNo.TAINETU,       (ushort)TokuseiNo.SIROIKEMURI,   (ushort)TokuseiNo.KURIABODHI,
            // Keen Eye,                      Hyper Cutter,                    Inner Focus,                     Shield Dust,
            (ushort)TokuseiNo.SURUDOIME,      (ushort)TokuseiNo.KAIRIKIBASAMI, (ushort)TokuseiNo.SEISINRYOKU,   (ushort)TokuseiNo.RINPUN,
            // Sturdy,                        Damp,                            Oblivious,                       Limber,
            (ushort)TokuseiNo.GANZYOU,        (ushort)TokuseiNo.SIMERIKE,      (ushort)TokuseiNo.DONKAN,        (ushort)TokuseiNo.ZYUUNAN,
            // Own Tempo,                     Water Veil,                      Leaf Guard,                      Insomnia,
            (ushort)TokuseiNo.MAIPEESU,       (ushort)TokuseiNo.MIZUNOBEERU,   (ushort)TokuseiNo.RIIHUGAADO,    (ushort)TokuseiNo.HUMIN,
            // Big Pecks,                     Vital Spirit,                    Immunity,                        Magma Armor,
            (ushort)TokuseiNo.HATOMUNE,       (ushort)TokuseiNo.YARUKI,        (ushort)TokuseiNo.MENEKI,        (ushort)TokuseiNo.MAGUMANOYOROI,
            // Contrary,                      Friend Guard,                    Multiscale,                      Telepathy,
            (ushort)TokuseiNo.AMANOZYAKU,     (ushort)TokuseiNo.HURENDOGAADO,  (ushort)TokuseiNo.MARUTISUKEIRU, (ushort)TokuseiNo.TEREPASII,
            // Wonder Skin,                   Magic Bounce,                    Sap Sipper,                      Volt Absorb,
            (ushort)TokuseiNo.MIRAKURUSUKIN,  (ushort)TokuseiNo.MAZIKKUMIRAA,  (ushort)TokuseiNo.SOUSYOKU,      (ushort)TokuseiNo.TIKUDEN,
            // Dry Skin,                      Flower Gift,                     Heavy Metal,                     Light Metal,
            (ushort)TokuseiNo.KANSOUHADA,     (ushort)TokuseiNo.HURAWAAGIHUTO, (ushort)TokuseiNo.HEVHIMETARU,   (ushort)TokuseiNo.RAITOMETARU,
            // Aroma Veil,                    Flower Veil,                     Fur Coat,                        Bulletproof,
            (ushort)TokuseiNo.AROMABEERU,     (ushort)TokuseiNo.HURAWAABEERU,  (ushort)TokuseiNo.FAAKOOTO,      (ushort)TokuseiNo.BOUDAN,
            // Sweet Veil,                    Grass Pelt,                      Aura Break,                      Overcoat,
            (ushort)TokuseiNo.SUIITOBEERU,    (ushort)TokuseiNo.KUSANOKEGAWA,  (ushort)TokuseiNo.OORABUREIKU,   (ushort)TokuseiNo.BOUZIN,
            // Fluffy,                        Disguise,                        Water Bubble,                    Queenly Majesty,
            (ushort)TokuseiNo.MOHUMOHU,       (ushort)TokuseiNo.BAKENOKAWA,    (ushort)TokuseiNo.SUIHOU,        (ushort)TokuseiNo.ZYOOUNOIGEN,
            // Dazzling,                      Mirror Armor,                    Punk Rock,                       Ice Scales,
            (ushort)TokuseiNo.BIBIDDOBODHI,   (ushort)TokuseiNo.MIRAAAAMAA,    (ushort)TokuseiNo.PANKUROKKU,    (ushort)TokuseiNo.KOORINORINPUN,
            // Ice Face,                      Pastel Veil,
            (ushort)TokuseiNo.AISUFEISU,      (ushort)TokuseiNo.PASUTERUBEERU,
        };
        private static readonly ushort[] CheckOmmitAfterHensinTable = new ushort[]
        {
            // Disguise,                      Gulp Missile,                 Ice Face,                    Neutralizing Gas,
            (ushort)TokuseiNo.BAKENOKAWA,     (ushort)TokuseiNo.UNOMISAIRU, (ushort)TokuseiNo.AISUFEISU, (ushort)TokuseiNo.KAGAKUHENKAGASU,
            // Hunger Switch,
            (ushort)TokuseiNo.HARAPEKOSUITTI,
        };
        private static readonly ushort[] CheckOmmitOnGTable = new ushort[]
        {
            // Gulp Missile,
            (ushort)TokuseiNo.UNOMISAIRU,
        };
        private static readonly ushort[] IsTypeChangeForbidPokeTable = new ushort[]
        {
            // Arceus,
            (ushort)MonsNo.ARUSEUSU,
        };
        private static readonly ushort[] IsEffectDisableTypeTable = new ushort[]
        {
            (ushort)BtlEff.BTLEFF_NEMURI,         (ushort)BtlEff.BTLEFF_MAHI,                       (ushort)BtlEff.BTLEFF_DOKU,                  (ushort)BtlEff.BTLEFF_YAKEDO,
            (ushort)BtlEff.BTLEFF_KONRAN,         (ushort)BtlEff.BTLEFF_MEROMERO,                   (ushort)BtlEff.BTLEFF_NOROI,                 (ushort)BtlEff.BTLEFF_AKUMU,
            (ushort)BtlEff.BTLEFF_SHOOTER_EFFECT, (ushort)BtlEff.BTLEFF_USE_ITEM,                   (ushort)BtlEff.BTLEFF_HP_RECOVER,            (ushort)BtlEff.BTLEFF_SIMETUKERU,
            (ushort)BtlEff.BTLEFF_YADORIGI,       (ushort)BtlEff.BTLEFF_MAKITUKU,                   (ushort)BtlEff.BTLEFF_KOORI,                 (ushort)BtlEff.BTLEFF_HONOONOUZU,
            (ushort)BtlEff.BTLEFF_MAGUMASUTOOMU,  (ushort)BtlEff.BTLEFF_KARADEHASAMU,               (ushort)BtlEff.BTLEFF_UZUSIO,                (ushort)BtlEff.BTLEFF_SUNAZIGOKU,
            (ushort)BtlEff.BTLEFF_RAINBOW,        (ushort)BtlEff.BTLEFF_MOOR,                       (ushort)BtlEff.BTLEFF_BURNING,               (ushort)BtlEff.BTLEFF_GUARD,
            (ushort)BtlEff.BTLEFF_MATOWARITUKU,   (ushort)BtlEff.BTLEFF_ROTOM_POWER,                (ushort)BtlEff.BTLEFF_Z_ROTOM_POWER,         (ushort)BtlEff.BTLEFF_STATUS_UP_G,
            (ushort)BtlEff.BTLEFF_STATUS_DOWN_G,  (ushort)BtlEff.BTLEFF_SIMPLE_HIT_G,               (ushort)BtlEff.BTLEFF_NEMURI_G,              (ushort)BtlEff.BTLEFF_DOKU_G,
            (ushort)BtlEff.BTLEFF_YAKEDO_G,       (ushort)BtlEff.BTLEFF_KOORI_G,                    (ushort)BtlEff.BTLEFF_MAHI_G,                (ushort)BtlEff.BTLEFF_KONRAN_G,
            (ushort)BtlEff.BTLEFF_MEROMERO_G,     (ushort)BtlEff.BTLEFF_HP_RECOVER_G,               (ushort)BtlEff.BTLEFF_PP_RECOVER_G,          (ushort)BtlEff.BTLEFF_GUARD_G,
            (ushort)BtlEff.BTLEFF_TORABASAMI,     (ushort)BtlEff.BTLEFF_EG_TURN_INHALE_AT_G_DF_NML, (ushort)BtlEff.BTLEFF_EG_TURN_INHALE_BOTH_G, (ushort)BtlEff.BTLEFF_EG_TURN_INHALE_AT_NML_DF_G,
        };
        private static readonly ushort[] IsCourtChangeSwapSideEffectTable = new ushort[]
        {
            // Reflect Side Effect,                               Light Screen Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_REFLECTOR,          (ushort)BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE,
            // Safeguard Side Effect,                             Mist Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI,      (ushort)BtlSideEffect.BTL_SIDEEFF_SIROIKIRI,
            // Tailwind Side Effect,                              Lucky Chant Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_OIKAZE,             (ushort)BtlSideEffect.BTL_SIDEEFF_OMAJINAI,
            // Spikes Side Effect,                                Toxic Spikes Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_MAKIBISI,           (ushort)BtlSideEffect.BTL_SIDEEFF_DOKUBISI,
            // Stealth Rock Side Effect,                          Rainbow Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK,        (ushort)BtlSideEffect.BTL_SIDEEFF_RAINBOW,
            // Sea of Fire Side Effect,                           Swamp Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_BURNING,            (ushort)BtlSideEffect.BTL_SIDEEFF_MOOR,
            // Sticky Web Side Effect,                            Aurora Veil Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_NEBANEBANET,        (ushort)BtlSideEffect.BTL_SIDEEFF_AURORAVEIL,
            // G-Max Steelsurge Side Effect,                      G-Max Wildfire Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE, (ushort)BtlSideEffect.BTL_SIDEEFF_GSHOCK_HONOO,
            // G-Max Volcalith Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_GSHOCK_IWA,
        };
        private static readonly WazaSick[] MentalSickTbl = new WazaSick[]
        {
            // Infatuation,             Torment,                     Move Disabled,                Heal Block,
            WazaSick.WAZASICK_MEROMERO, WazaSick.WAZASICK_ICHAMON,   WazaSick.WAZASICK_KANASIBARI, WazaSick.WAZASICK_KAIHUKUHUUJI,
            // Encore,                  Taunt,
            WazaSick.WAZASICK_ENCORE,   WazaSick.WAZASICK_TYOUHATSU,
        };
        private static readonly WazaSick[] GetTurnCheckWazaSickByOrderTable = new WazaSick[]
        {
            // Aqua Ring,                     Ingrain,                       Leech Seed,                       Poison,
            WazaSick.WAZASICK_AQUARING,       WazaSick.WAZASICK_NEWOHARU,    WazaSick.WAZASICK_YADORIGI,       WazaSick.WAZASICK_DOKU,
            // Burn,                          Nightmare,                     Curse,                            Bound,
            WazaSick.WAZASICK_YAKEDO,         WazaSick.WAZASICK_AKUMU,       WazaSick.WAZASICK_NOROI,          WazaSick.WAZASICK_BIND,
            // Octolock,                      Taunt,                         Torment,                          Encore,
            WazaSick.WAZASICK_TAKOGATAME,     WazaSick.WAZASICK_TYOUHATSU,   WazaSick.WAZASICK_ICHAMON,        WazaSick.WAZASICK_ENCORE,
            // Move Disabled,                 Magnet Rise,                   Telekinesis,                      Heal Block,
            WazaSick.WAZASICK_KANASIBARI,     WazaSick.WAZASICK_FLYING,      WazaSick.WAZASICK_TELEKINESIS,    WazaSick.WAZASICK_KAIHUKUHUUJI,
            // Embargo,                       Lock-On,                       Locked-On,                        Powder,
            WazaSick.WAZASICK_SASIOSAE,       WazaSick.WAZASICK_MUSTHIT,     WazaSick.WAZASICK_MUSTHIT_TARGET, WazaSick.WAZASICK_FUNJIN,
            // Future Attack,                 Uproar,                        Rampaging,                        Laser Focus,
            WazaSick.WAZASICK_FORCE_WAZATYPE, WazaSick.WAZASICK_SAWAGU,      WazaSick.WAZASICK_ABARERU,        WazaSick.WAZASICK_TOGISUMASU,
            // Throat Chop,                   Drowsy,                        Counting Down,                    Paralysis,
            WazaSick.WAZASICK_ZIGOKUDUKI,     WazaSick.WAZASICK_AKUBI,       WazaSick.WAZASICK_HOROBINOUTA,    WazaSick.WAZASICK_MAHI,
            // Sleep,                         Freeze,                        Infatuation,                      Confusion,
            WazaSick.WAZASICK_NEMURI,         WazaSick.WAZASICK_KOORI,       WazaSick.WAZASICK_MEROMERO,       WazaSick.WAZASICK_KONRAN,
            // No Ability,                    Identified,                    Can't Escape,                     Roost,
            WazaSick.WAZASICK_IEKI,           WazaSick.WAZASICK_MIYABURU,    WazaSick.WAZASICK_TOOSENBOU,      WazaSick.WAZASICK_HANEYASUME,
            // ???,                           ???,                           Choice Item,                      Smack Down,
            WazaSick.WAZASICK_WAZALOCK,       WazaSick.WAZASICK_TAMELOCK,    WazaSick.WAZASICK_KODAWARI,       WazaSick.WAZASICK_FLYING_CANCEL,
            // Free Fall,                     Critical Hit Boost,
            WazaSick.WAZASICK_FREEFALL,       WazaSick.WAZASICK_HITRATIO_UP,
        };
        private static readonly ushort[] checkHaseiOmmitCommonTable = new ushort[]
        {
            // Metronome,                        Sleep Talk,                          Assist,                                  Copycat,
            (ushort)WazaNo.YUBIWOHURU,           (ushort)WazaNo.NEGOTO,               (ushort)WazaNo.NEKONOTE,                 (ushort)WazaNo.MANEKKO,
            // Me First,                         Mirror Move,                         Nature Power,                            Chatter,
            (ushort)WazaNo.SAKIDORI,             (ushort)WazaNo.OUMUGAESI,            (ushort)WazaNo.SIZENNOTIKARA,            (ushort)WazaNo.OSYABERI,
            // Struggle,                         Sketch,                              Mimic,                                   Belch,
            (ushort)WazaNo.WARUAGAKI,            (ushort)WazaNo.SUKETTI,              (ushort)WazaNo.MONOMANE,                 (ushort)WazaNo.GEPPU,
            // Celebrate,                        Hold Hands,                          Catastropika,                            Sinister Arrow Raid,
            (ushort)WazaNo.OIWAI,                (ushort)WazaNo.TEWOTUNAGU,           (ushort)WazaNo.HISSATUNOPIKATYUUTO,      (ushort)WazaNo.SYADOOAROOZUSUTORAIKU,
            // Malicious Moonsault,              Oceanic Operetta,                    Guardian of Alola,                       Soul-Stealing 7-Star Strike,
            (ushort)WazaNo.HAIPAADAAKUKURASSYAA, (ushort)WazaNo.WADATUMINOSINFONIA,   (ushort)WazaNo.GAADHIANDEAROORA,         (ushort)WazaNo.SITISEIDAKKONTAI,
            // Stoked Sparksurfer,               Pulverizing Pancake,                 Extreme Evoboost,                        Genesis Supernova,
            (ushort)WazaNo.RAITONINGUSAAHURAIDO, (ushort)WazaNo.HONKIWODASUKOUGEKI,   (ushort)WazaNo.NAINEBORUBUUSUTO,         (ushort)WazaNo.ORIZINZUSUUPAANOVHA,
            // 10,000,000 Volt Thunderbolt,      Splintered Stormshards,              Light That Burns the Sky,                Searing Sunraze Smash,
            (ushort)WazaNo._1000MANBORUTO,       (ushort)WazaNo.RAZIARUEZZISUTOOMU,   (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI, (ushort)WazaNo.SANSYAINSUMASSYAA,
            // Menacing Moonraze Maelstrom,      Let's Snuggle Forever,               Clangorous Soulblaze,
            (ushort)WazaNo.MUUNRAITOBURASUTAA,   (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.BUREIZINGUSOURUBIITO,
        };
        private static readonly ushort[] IsNegotoOmmitTable = new ushort[]
        {
            // Uproar,                    Skull Bash,                    Sky Attack,                   Solar Beam,
            (ushort)WazaNo.SAWAGU,        (ushort)WazaNo.ROKETTOZUTUKI,  (ushort)WazaNo.GODDOBAADO,    (ushort)WazaNo.SOORAABIIMU,
            // Bide,                      Razor Wind,                    Fly,                          Bounce,
            (ushort)WazaNo.GAMAN,         (ushort)WazaNo.KAMAITATI,      (ushort)WazaNo.SORAWOTOBU,    (ushort)WazaNo.TOBIHANERU,
            // Shadow Force,              Focus Punch,                   Sky Drop,                     Phantom Force,
            (ushort)WazaNo.SYADOODAIBU,   (ushort)WazaNo.KIAIPANTI,      (ushort)WazaNo.HURIIFOORU,    (ushort)WazaNo.GOOSUTODAIBU,
            // Shell Trap,                Beak Blast,                    Dig,                          Dive,
            (ushort)WazaNo.TORAPPUSHERU,  (ushort)WazaNo.KUTIBASIKYANON, (ushort)WazaNo.ANAWOHORU,     (ushort)WazaNo.DAIBINGU,
            // Freeze Shock,              Ice Burn,                      Geomancy,                     Solar Blade,
            (ushort)WazaNo.HURIIZUBORUTO, (ushort)WazaNo.KOORUDOHUREA,   (ushort)WazaNo.ZIOKONTOROORU, (ushort)WazaNo.SOORAABUREEDO,
            // Max Guard,                 Dynamax Cannon,                Max Flare,                    Max Flutterby,
            (ushort)WazaNo.DAIWHOORU,     (ushort)WazaNo.DAIMAKKUSUHOU,  (ushort)WazaNo.DAIBAAN,       (ushort)WazaNo.DAIWAAMU,
            // Max Lightning,             Max Strike,                    Max Knuckle,                  Max Phantasm,
            (ushort)WazaNo.DAISANDAA,     (ushort)WazaNo.DAIATAKKU,      (ushort)WazaNo.DAINAKKURU,    (ushort)WazaNo.DAIHOROU,
            // Max Hailstorm,             Max Ooze,                      Max Geyser,                   Max Airstream,
            (ushort)WazaNo.DAIAISU,       (ushort)WazaNo.DAIASIDDO,      (ushort)WazaNo.DAISUTORIIMU,  (ushort)WazaNo.DAIJETTO,
            // Max Starfall,              Max Wyrmwind,                  Max Mindstorm,                Max Rockfall,
            (ushort)WazaNo.DAIFEARII,     (ushort)WazaNo.DAIDORAGUUN,    (ushort)WazaNo.DAISAIKO,      (ushort)WazaNo.DAIROKKU,
            // Max Quake,                 Max Darkness,                  Max Overgrowth,               Max Steelspike,
            (ushort)WazaNo.DAIAASU,       (ushort)WazaNo.DAIAAKU,        (ushort)WazaNo.DAISOUGEN,     (ushort)WazaNo.DAISUTIRU,
        };
        private static readonly ushort[] IsNekoNoteOmmitTable = new ushort[]
        {
            // Counter,                  Mirror Coat,                 Protect,                       Detect,
            (ushort)WazaNo.KAUNTAA,      (ushort)WazaNo.MIRAAKOOTO,   (ushort)WazaNo.MAMORU,         (ushort)WazaNo.MIKIRI,
            // Endure,                   Destiny Bond,                Follow Me,                     Rage Powder,
            (ushort)WazaNo.KORAERU,      (ushort)WazaNo.MITIDURE,     (ushort)WazaNo.KONOYUBITOMARE, (ushort)WazaNo.IKARINOKONA,
            // Snatch,                   Helping Hand,                Thief,                         Covet,
            (ushort)WazaNo.YOKODORI,     (ushort)WazaNo.TEDASUKE,     (ushort)WazaNo.DOROBOU,        (ushort)WazaNo.HOSIGARU,
            // Trick,                    Switcheroo,                  Feint,                         Focus Punch,
            (ushort)WazaNo.TORIKKU,      (ushort)WazaNo.SURIKAE,      (ushort)WazaNo.FEINTO,         (ushort)WazaNo.KIAIPANTI,
            // Transform,                Bestow,                      Dragon Tail,                   Circle Throw,
            (ushort)WazaNo.HENSIN,       (ushort)WazaNo.GIHUTOPASU,   (ushort)WazaNo.DORAGONTEERU,   (ushort)WazaNo.TOMOENAGE,
            // Roar,                     Whirlwind,                   Spiky Shield,                  King's Shield,
            (ushort)WazaNo.HOERU,        (ushort)WazaNo.HUKITOBASI,   (ushort)WazaNo.NIIDORUGAADO,   (ushort)WazaNo.KINGUSIIRUDO,
            // Mat Block,                Fly,                         Sky Drop,                      Dig,
            (ushort)WazaNo.TATAMIGAESI,  (ushort)WazaNo.SORAWOTOBU,   (ushort)WazaNo.HURIIFOORU,     (ushort)WazaNo.ANAWOHORU,
            // Dive,                     Bounce,                      Shadow Force,                  Phantom Force,
            (ushort)WazaNo.DAIBINGU,     (ushort)WazaNo.TOBIHANERU,   (ushort)WazaNo.SYADOODAIBU,    (ushort)WazaNo.GOOSUTODAIBU,
            // Spotlight,                Shell Trap,                  Beak Blast,                    Baneful Bunker,
            (ushort)WazaNo.SUPOTTORAITO, (ushort)WazaNo.TORAPPUSHERU, (ushort)WazaNo.KUTIBASIKYANON, (ushort)WazaNo.TOOTIKA,
        };
        private static readonly ushort[] IsManekkoOmmitTable = new ushort[]
        {
            // Counter,                 Mirror Coat,                 Protect,                       Detect,
            (ushort)WazaNo.KAUNTAA,     (ushort)WazaNo.MIRAAKOOTO,   (ushort)WazaNo.MAMORU,         (ushort)WazaNo.MIKIRI,
            // Endure,                  Destiny Bond,                Follow Me,                     Rage Powder,
            (ushort)WazaNo.KORAERU,     (ushort)WazaNo.MITIDURE,     (ushort)WazaNo.KONOYUBITOMARE, (ushort)WazaNo.IKARINOKONA,
            // Snatch,                  Helping Hand,                Thief,                         Covet,
            (ushort)WazaNo.YOKODORI,    (ushort)WazaNo.TEDASUKE,     (ushort)WazaNo.DOROBOU,        (ushort)WazaNo.HOSIGARU,
            // Trick,                   Switcheroo,                  Feint,                         Focus Punch,
            (ushort)WazaNo.TORIKKU,     (ushort)WazaNo.SURIKAE,      (ushort)WazaNo.FEINTO,         (ushort)WazaNo.KIAIPANTI,
            // Transform,               Bestow,                      Dragon Tail,                   Circle Throw,
            (ushort)WazaNo.HENSIN,      (ushort)WazaNo.GIHUTOPASU,   (ushort)WazaNo.DORAGONTEERU,   (ushort)WazaNo.TOMOENAGE,
            // Roar,                    Whirlwind,                   Spiky Shield,                  King's Shield,
            (ushort)WazaNo.HOERU,       (ushort)WazaNo.HUKITOBASI,   (ushort)WazaNo.NIIDORUGAADO,   (ushort)WazaNo.KINGUSIIRUDO,
            // Mat Block,               Spotlight,                   Shell Trap,                    Beak Blast,
            (ushort)WazaNo.TATAMIGAESI, (ushort)WazaNo.SUPOTTORAITO, (ushort)WazaNo.TORAPPUSHERU,   (ushort)WazaNo.KUTIBASIKYANON,
            // Baneful Bunker,          Max Guard,                   Dynamax Cannon,                Max Flare,
            (ushort)WazaNo.TOOTIKA,     (ushort)WazaNo.DAIWHOORU,    (ushort)WazaNo.DAIMAKKUSUHOU,  (ushort)WazaNo.DAIBAAN,
            // Max Flutterby,           Max Lightning,               Max Strike,                    Max Knuckle,
            (ushort)WazaNo.DAIWAAMU,    (ushort)WazaNo.DAISANDAA,    (ushort)WazaNo.DAIATAKKU,      (ushort)WazaNo.DAINAKKURU,
            // Max Phantasm,            Max Hailstorm,               Max Ooze,                      Max Geyser,
            (ushort)WazaNo.DAIHOROU,    (ushort)WazaNo.DAIAISU,      (ushort)WazaNo.DAIASIDDO,      (ushort)WazaNo.DAISUTORIIMU,
            // Max Airstream,           Max Starfall,                Max Wyrmwind,                  Max Mindstorm,
            (ushort)WazaNo.DAIJETTO,    (ushort)WazaNo.DAIFEARII,    (ushort)WazaNo.DAIDORAGUUN,    (ushort)WazaNo.DAISAIKO,
            // Max Rockfall,            Max Quake,                   Max Darkness,                  Max Overgrowth,
            (ushort)WazaNo.DAIROKKU,    (ushort)WazaNo.DAIAASU,      (ushort)WazaNo.DAIAAKU,        (ushort)WazaNo.DAISOUGEN,
            // Max Steelspike,          Behemoth Blade,              Behemoth Bash,
            (ushort)WazaNo.DAISUTIRU,   (ushort)WazaNo.KYOZYUUZAN,   (ushort)WazaNo.KYOZYUUDAN,
        };
        private static readonly ushort[] IsMatchMonomaneFailTable = new ushort[]
        {
            // 0,                                    Sketch,                              Mimic,                                   Transform,
            (ushort)WazaNo.NULL,                     (ushort)WazaNo.SUKETTI,              (ushort)WazaNo.MONOMANE,                 (ushort)WazaNo.HENSIN,
            // Struggle,                             Chatter,                             Breakneck Blitz (Physical),              Breakneck Blitz (Special),
            (ushort)WazaNo.WARUAGAKI,                (ushort)WazaNo.OSYABERI,             (ushort)WazaNo.URUTORADASSYUATAKKU,      (ushort)WazaNo.NOOMARUZENRYOKU,
            // All-Out Pummeling (Physical),         All-Out Pummeling (Special),         Supersonic Skystrike (Physical),         Supersonic Skystrike (Special),
            (ushort)WazaNo.ZENRYOKUMUSOUGEKIRETUKEN, (ushort)WazaNo.KAKUTOUZENRYOKU,      (ushort)WazaNo.FAINARUDAIBUKURASSYU,     (ushort)WazaNo.HIKOUZENRYOKU,
            // Acid Downpour (Physical),             Acid Downpour (Special),             Tectonic Rage (Physical),                Tectonic Rage (Special),
            (ushort)WazaNo.ASIDDOPOIZUNDERIITO,      (ushort)WazaNo.DOKUZENRYOKU,         (ushort)WazaNo.RAIZINGURANDOOOBAA,       (ushort)WazaNo.ZIMENZENRYOKU,
            // Continental Crush (Physical),         Continental Crush (Special),         Savage Spin-Out (Physical),              Savage Spin-Out (Special),
            (ushort)WazaNo.WAARUZUENDOFOORU,         (ushort)WazaNo.IWAZENRYOKU,          (ushort)WazaNo.ZETTAIHOSYOKUKAITENZAN,   (ushort)WazaNo.MUSIZENRYOKU,
            // Never-Ending Nightmare (Physical),    Never-Ending Nightmare (Special),    Corkscrew Crash (Physical),              Corkscrew Crash (Special),
            (ushort)WazaNo.MUGENANYAHENOIZANAI,      (ushort)WazaNo.GOOSUTOZENRYOKU,      (ushort)WazaNo.TYOUZETURASENRENGEKI,     (ushort)WazaNo.HAGANEZENRYOKU,
            // Inferno Overdrive (Physical),         Inferno Overdrive (Special),         Hydro Vortex (Physical),                 Hydro Vortex (Special),
            (ushort)WazaNo.DAINAMIKKUHURUHUREIMU,    (ushort)WazaNo.HONOOZENRYOKU,        (ushort)WazaNo.SUUPAAAKUATORUNEEDO,      (ushort)WazaNo.MIZUZENRYOKU,
            // Bloom Doom (Physical),                Bloom Doom (Special),                Gigavolt Havoc (Physical),               Gigavolt Havoc (Special),
            (ushort)WazaNo.BURUUMUSYAINEKUSUTORA,    (ushort)WazaNo.KUSAZENRYOKU,         (ushort)WazaNo.SUPAAKINGUGIGABORUTO,     (ushort)WazaNo.DENKIZENRYOKU,
            // Shattered Psyche (Physical),          Shattered Psyche (Special),          Subzero Slammer (Physical),              Subzero Slammer (Special),
            (ushort)WazaNo.MAKISIMAMUSAIBUREIKAA,    (ushort)WazaNo.ESUPAAZENRYOKU,       (ushort)WazaNo.REIZINGUZIOHURIIZU,       (ushort)WazaNo.KOORIZENRYOKU,
            // Devastating Drake (Physical),         Devastating Drake (Special),         Black Hole Eclipse (Physical),           Black Hole Eclipse (Special),
            (ushort)WazaNo.ARUTHIMETTODORAGONBAAN,   (ushort)WazaNo.DORAGONZENRYOKU,      (ushort)WazaNo.BURAKKUHOORUIKURIPUSU,    (ushort)WazaNo.AKUZENRYOKU,
            // Twinkle Tackle (Physical),            Twinkle Tackle (Special),            Catastropika,                            Sinister Arrow Raid,
            (ushort)WazaNo.RABURIISUTAAINPAKUTO,     (ushort)WazaNo.FEARIIZENRYOKU,       (ushort)WazaNo.HISSATUNOPIKATYUUTO,      (ushort)WazaNo.SYADOOAROOZUSUTORAIKU,
            // Malicious Moonsault,                  Oceanic Operetta,                    Guardian of Alola,                       Soul-Stealing 7-Star Strike,
            (ushort)WazaNo.HAIPAADAAKUKURASSYAA,     (ushort)WazaNo.WADATUMINOSINFONIA,   (ushort)WazaNo.GAADHIANDEAROORA,         (ushort)WazaNo.SITISEIDAKKONTAI,
            // Stoked Sparksurfer,                   Pulverizing Pancake,                 Extreme Evoboost,                        Genesis Supernova,
            (ushort)WazaNo.RAITONINGUSAAHURAIDO,     (ushort)WazaNo.HONKIWODASUKOUGEKI,   (ushort)WazaNo.NAINEBORUBUUSUTO,         (ushort)WazaNo.ORIZINZUSUUPAANOVHA,
            // 10,000,000 Volt Thunderbolt,          Splintered Stormshards,              Light That Burns the Sky,                Searing Sunraze Smash,
            (ushort)WazaNo._1000MANBORUTO,           (ushort)WazaNo.RAZIARUEZZISUTOOMU,   (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI, (ushort)WazaNo.SANSYAINSUMASSYAA,
            // Menacing Moonraze Maelstrom,          Let's Snuggle Forever,               Clangorous Soulblaze,                    Max Guard,
            (ushort)WazaNo.MUUNRAITOBURASUTAA,       (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.BUREIZINGUSOURUBIITO,     (ushort)WazaNo.DAIWHOORU,
            // Dynamax Cannon,                       Max Flare,                           Max Flutterby,                           Max Lightning,
            (ushort)WazaNo.DAIMAKKUSUHOU,            (ushort)WazaNo.DAIBAAN,              (ushort)WazaNo.DAIWAAMU,                 (ushort)WazaNo.DAISANDAA,
            // Max Strike,                           Max Knuckle,                         Max Phantasm,                            Max Hailstorm,
            (ushort)WazaNo.DAIATAKKU,                (ushort)WazaNo.DAINAKKURU,           (ushort)WazaNo.DAIHOROU,                 (ushort)WazaNo.DAIAISU,
            // Max Ooze,                             Max Geyser,                          Max Airstream,                           Max Starfall,
            (ushort)WazaNo.DAIASIDDO,                (ushort)WazaNo.DAISUTORIIMU,         (ushort)WazaNo.DAIJETTO,                 (ushort)WazaNo.DAIFEARII,
            // Max Wyrmwind,                         Max Mindstorm,                       Max Rockfall,                            Max Quake,
            (ushort)WazaNo.DAIDORAGUUN,              (ushort)WazaNo.DAISAIKO,             (ushort)WazaNo.DAIROKKU,                 (ushort)WazaNo.DAIAASU,
            // Max Darkness,                         Max Overgrowth,                      Max Steelspike,                          Behemoth Blade,
            (ushort)WazaNo.DAIAAKU,                  (ushort)WazaNo.DAISOUGEN,            (ushort)WazaNo.DAISUTIRU,                (ushort)WazaNo.KYOZYUUZAN,
            // Behemoth Bash,
            (ushort)WazaNo.KYOZYUUDAN,
        };
        private static readonly ushort[] IsSaihaiOmmitTable = new ushort[]
        {
            // Instruct,                         Bide,                                    Razor Wind,                           Fly,
            (ushort)WazaNo.SAIHAI,               (ushort)WazaNo.GAMAN,                    (ushort)WazaNo.KAMAITATI,             (ushort)WazaNo.SORAWOTOBU,
            // Solar Beam,                       Dig,                                     Skull Bash,                           Sky Attack,
            (ushort)WazaNo.SOORAABIIMU,          (ushort)WazaNo.ANAWOHORU,                (ushort)WazaNo.ROKETTOZUTUKI,         (ushort)WazaNo.GODDOBAADO,
            // Dive,                             Bounce,                                  Shadow Force,                         Sky Drop,
            (ushort)WazaNo.DAIBINGU,             (ushort)WazaNo.TOBIHANERU,               (ushort)WazaNo.SYADOODAIBU,           (ushort)WazaNo.HURIIFOORU,
            // Freeze Shock,                     Ice Burn,                                Phantom Force,                        Geomancy,
            (ushort)WazaNo.HURIIZUBORUTO,        (ushort)WazaNo.KOORUDOHUREA,             (ushort)WazaNo.GOOSUTODAIBU,          (ushort)WazaNo.ZIOKONTOROORU,
            // Solar Blade,                      Shell Trap,                              Beak Blast,                           King's Shield,
            (ushort)WazaNo.SOORAABUREEDO,        (ushort)WazaNo.TORAPPUSHERU,             (ushort)WazaNo.KUTIBASIKYANON,        (ushort)WazaNo.KINGUSIIRUDO,
            // Transform,                        Thrash,                                  Outrage,                              Petal Dance,
            (ushort)WazaNo.HENSIN,               (ushort)WazaNo.ABARERU,                  (ushort)WazaNo.GEKIRIN,               (ushort)WazaNo.HANABIRANOMAI,
            // Uproar,                           Rollout,                                 Ice Ball,                             Bide,
            (ushort)WazaNo.SAWAGU,               (ushort)WazaNo.KOROGARU,                 (ushort)WazaNo.AISUBOORU,             (ushort)WazaNo.GAMAN,
            // Focus Punch,                      Breakneck Blitz (Physical),              Breakneck Blitz (Special),            All-Out Pummeling (Physical),
            (ushort)WazaNo.KIAIPANTI,            (ushort)WazaNo.URUTORADASSYUATAKKU,      (ushort)WazaNo.NOOMARUZENRYOKU,       (ushort)WazaNo.ZENRYOKUMUSOUGEKIRETUKEN,
            // All-Out Pummeling (Special),      Supersonic Skystrike (Physical),         Supersonic Skystrike (Special),       Acid Downpour (Physical),
            (ushort)WazaNo.KAKUTOUZENRYOKU,      (ushort)WazaNo.FAINARUDAIBUKURASSYU,     (ushort)WazaNo.HIKOUZENRYOKU,         (ushort)WazaNo.ASIDDOPOIZUNDERIITO,
            // Acid Downpour (Special),          Tectonic Rage (Physical),                Tectonic Rage (Special),              Continental Crush (Physical),
            (ushort)WazaNo.DOKUZENRYOKU,         (ushort)WazaNo.RAIZINGURANDOOOBAA,       (ushort)WazaNo.ZIMENZENRYOKU,         (ushort)WazaNo.WAARUZUENDOFOORU,
            // Continental Crush (Special),      Savage Spin-Out (Physical),              Savage Spin-Out (Special),            Never-Ending Nightmare (Physical),
            (ushort)WazaNo.IWAZENRYOKU,          (ushort)WazaNo.ZETTAIHOSYOKUKAITENZAN,   (ushort)WazaNo.MUSIZENRYOKU,          (ushort)WazaNo.MUGENANYAHENOIZANAI,
            // Never-Ending Nightmare (Special), Corkscrew Crash (Physical),              Corkscrew Crash (Special),            Inferno Overdrive (Physical),
            (ushort)WazaNo.GOOSUTOZENRYOKU,      (ushort)WazaNo.TYOUZETURASENRENGEKI,     (ushort)WazaNo.HAGANEZENRYOKU,        (ushort)WazaNo.DAINAMIKKUHURUHUREIMU,
            // Inferno Overdrive (Special),      Hydro Vortex (Physical),                 Hydro Vortex (Special),               Bloom Doom (Physical),
            (ushort)WazaNo.HONOOZENRYOKU,        (ushort)WazaNo.SUUPAAAKUATORUNEEDO,      (ushort)WazaNo.MIZUZENRYOKU,          (ushort)WazaNo.BURUUMUSYAINEKUSUTORA,
            // Bloom Doom (Special),             Gigavolt Havoc (Physical),               Gigavolt Havoc (Special),             Shattered Psyche (Physical),
            (ushort)WazaNo.KUSAZENRYOKU,         (ushort)WazaNo.SUPAAKINGUGIGABORUTO,     (ushort)WazaNo.DENKIZENRYOKU,         (ushort)WazaNo.MAKISIMAMUSAIBUREIKAA,
            // Shattered Psyche (Special),       Subzero Slammer (Physical),              Subzero Slammer (Special),            Devastating Drake (Physical),
            (ushort)WazaNo.ESUPAAZENRYOKU,       (ushort)WazaNo.REIZINGUZIOHURIIZU,       (ushort)WazaNo.KOORIZENRYOKU,         (ushort)WazaNo.ARUTHIMETTODORAGONBAAN,
            // Devastating Drake (Special),      Black Hole Eclipse (Physical),           Black Hole Eclipse (Special),         Twinkle Tackle (Physical),
            (ushort)WazaNo.DORAGONZENRYOKU,      (ushort)WazaNo.BURAKKUHOORUIKURIPUSU,    (ushort)WazaNo.AKUZENRYOKU,           (ushort)WazaNo.RABURIISUTAAINPAKUTO,
            // Twinkle Tackle (Special),         Catastropika,                            Sinister Arrow Raid,                  Malicious Moonsault,
            (ushort)WazaNo.FEARIIZENRYOKU,       (ushort)WazaNo.HISSATUNOPIKATYUUTO,      (ushort)WazaNo.SYADOOAROOZUSUTORAIKU, (ushort)WazaNo.HAIPAADAAKUKURASSYAA,
            // Oceanic Operetta,                 Guardian of Alola,                       Soul-Stealing 7-Star Strike,          Stoked Sparksurfer,
            (ushort)WazaNo.WADATUMINOSINFONIA,   (ushort)WazaNo.GAADHIANDEAROORA,         (ushort)WazaNo.SITISEIDAKKONTAI,      (ushort)WazaNo.RAITONINGUSAAHURAIDO,
            // Pulverizing Pancake,              Extreme Evoboost,                        Genesis Supernova,                    10,000,000 Volt Thunderbolt,
            (ushort)WazaNo.HONKIWODASUKOUGEKI,   (ushort)WazaNo.NAINEBORUBUUSUTO,         (ushort)WazaNo.ORIZINZUSUUPAANOVHA,   (ushort)WazaNo._1000MANBORUTO,
            // Splintered Stormshards,           Light That Burns the Sky,                Searing Sunraze Smash,                Menacing Moonraze Maelstrom,
            (ushort)WazaNo.RAZIARUEZZISUTOOMU,   (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI, (ushort)WazaNo.SANSYAINSUMASSYAA,     (ushort)WazaNo.MUUNRAITOBURASUTAA,
            // Let's Snuggle Forever,            Clangorous Soulblaze,                    Obstruct,                             Meteor Assault,
            (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.BUREIZINGUSOURUBIITO,     (ushort)WazaNo.BUROKKINGU,            (ushort)WazaNo.SUTAAASARUTO,
            // Eternabeam,                       Max Guard,                               Dynamax Cannon,                       Max Flare,
            (ushort)WazaNo.MUGENDAIBIIMU,        (ushort)WazaNo.DAIWHOORU,                (ushort)WazaNo.DAIMAKKUSUHOU,         (ushort)WazaNo.DAIBAAN,
            // Max Flutterby,                    Max Lightning,                           Max Strike,                           Max Knuckle,
            (ushort)WazaNo.DAIWAAMU,             (ushort)WazaNo.DAISANDAA,                (ushort)WazaNo.DAIATAKKU,             (ushort)WazaNo.DAINAKKURU,
            // Max Phantasm,                     Max Hailstorm,                           Max Ooze,                             Max Geyser,
            (ushort)WazaNo.DAIHOROU,             (ushort)WazaNo.DAIAISU,                  (ushort)WazaNo.DAIASIDDO,             (ushort)WazaNo.DAISUTORIIMU,
            // Max Airstream,                    Max Starfall,                            Max Wyrmwind,                         Max Mindstorm,
            (ushort)WazaNo.DAIJETTO,             (ushort)WazaNo.DAIFEARII,                (ushort)WazaNo.DAIDORAGUUN,           (ushort)WazaNo.DAISAIKO,
            // Max Rockfall,                     Max Quake,                               Max Darkness,                         Max Overgrowth,
            (ushort)WazaNo.DAIROKKU,             (ushort)WazaNo.DAIAASU,                  (ushort)WazaNo.DAIAAKU,               (ushort)WazaNo.DAISOUGEN,
            // Max Steelspike,
            (ushort)WazaNo.DAISUTIRU,
        };
        private static readonly ushort[] IsBoujinGuardWazaTable = new ushort[]
        {
            // Stun Spore,             Sleep Powder,              Poison Powder,              Spore,
            (ushort)WazaNo.SIBIREGONA, (ushort)WazaNo.NEMURIGONA, (ushort)WazaNo.DOKUNOKONA,  (ushort)WazaNo.KINOKONOHOUSI,
            // Powder,                 Cotton Spore,              Magic Powder,
            (ushort)WazaNo.HUNZIN,     (ushort)WazaNo.WATAHOUSI,  (ushort)WazaNo.MAHOUNOKONA,
        };
        private static readonly ushort[] IsAgoBoostWazaTable = new ushort[]
        {
            // Bite,                    Crunch,                     Poison Fang,                   Thunder Fang,
            (ushort)WazaNo.KAMITUKU,    (ushort)WazaNo.KAMIKUDAKU,  (ushort)WazaNo.DOKUDOKUNOKIBA, (ushort)WazaNo.KAMINARINOKIBA,
            // Ice Fang,                Fire Fang,                  Hyper Fang,                    Psychic Fangs,
            (ushort)WazaNo.KOORINOKIBA, (ushort)WazaNo.HONOONOKIBA, (ushort)WazaNo.HISSATUMAEBA,   (ushort)WazaNo.SAIKOFANGU,
            // Jaw Lock,                Fishious Rend,
            (ushort)WazaNo.KURAITUKU,   (ushort)WazaNo.ERAGAMI,
        };
        private static readonly ushort[] IsBoudanWazaTable = new ushort[]
        {
            // Barrage,                   Focus Blast,                  Shadow Ball,                   Ice Ball,
            (ushort)WazaNo.TAMANAGE,      (ushort)WazaNo.KIAIDAMA,      (ushort)WazaNo.SYADOOBOORU,    (ushort)WazaNo.AISUBOORU,
            // Weather Ball,              Gyro Ball,                    Energy Ball,                   Electro Ball,
            (ushort)WazaNo.WHEZAABOORU,   (ushort)WazaNo.ZYAIROBOORU,   (ushort)WazaNo.ENAZIIBOORU,    (ushort)WazaNo.EREKIBOORU,
            // Egg Bomb,                  Sludge Bomb,                  Aura Sphere,                   Seed Bomb,
            (ushort)WazaNo.TAMAGOBAKUDAN, (ushort)WazaNo.HEDOROBAKUDAN, (ushort)WazaNo.HADOUDAN,       (ushort)WazaNo.TANEBAKUDAN,
            // Mud Bomb,                  Searing Shot,                 Mist Ball,                     Bullet Seed,
            (ushort)WazaNo.DOROBAKUDAN,   (ushort)WazaNo.KAENDAN,       (ushort)WazaNo.MISUTOBOORU,    (ushort)WazaNo.TANEMASINGAN,
            // Magnet Bomb,               Acid Spray,                   Octazooka,                     Zap Cannon,
            (ushort)WazaNo.MAGUNETTOBOMU, (ushort)WazaNo.ASIDDOBOMU,    (ushort)WazaNo.OKUTANHOU,      (ushort)WazaNo.DENZIHOU,
            // Rock Wrecker,              Rock Blast,                   Beak Blast,                    Pollen Puff,
            (ushort)WazaNo.GANSEKIHOU,    (ushort)WazaNo.ROKKUBURASUTO, (ushort)WazaNo.KUTIBASIKYANON, (ushort)WazaNo.KAHUNDANGO,
            // Pyro Ball,
            (ushort)WazaNo.KAENBOORU,
        };
        private static readonly ushort[] IsDaiWallGuardDisableTable = new ushort[]
        {
            // Roar,                     Curse,                       Perish Song,                Mean Look,
            (ushort)WazaNo.HOERU,        (ushort)WazaNo.NOROI,        (ushort)WazaNo.HOROBINOUTA, (ushort)WazaNo.KUROIMANAZASI,
            // Heal Bell,                Future Sight,                Role Play,                  Aromatherapy,
            (ushort)WazaNo.IYASINOSUZU,  (ushort)WazaNo.MIRAIYOTI,    (ushort)WazaNo.NARIKIRI,    (ushort)WazaNo.AROMASERAPII,
            // Howl,                     Feint,                       Acupressure,                Power Trick,
            (ushort)WazaNo.TOOBOE,       (ushort)WazaNo.FEINTO,       (ushort)WazaNo.TUBOWOTUKU,  (ushort)WazaNo.PAWAATORIKKU,
            // Copycat,                  After You,                   Ally Switch,                Play Nice,
            (ushort)WazaNo.MANEKKO,      (ushort)WazaNo.OSAKINIDOUZO, (ushort)WazaNo.SAIDOTHENZI, (ushort)WazaNo.NAKAYOKUSURU,
            // Confide,                  Aromatic Mist,               Hold Hands,                 Tearful Look,
            (ushort)WazaNo.NAISYOBANASI, (ushort)WazaNo.AROMAMISUTO,  (ushort)WazaNo.TEWOTUNAGU,  (ushort)WazaNo.NAMIDAME,
            // Decorate,                 Life Dew,
            (ushort)WazaNo.DEKOREESYON,  (ushort)WazaNo.INOTINOSIZUKU,
        };
        private static readonly ushort[] IsOyakoaiOmitWazaTable = new ushort[]
        {
            // Endeavor,                          Fling,                                   Rollout,                             Ice Ball,
            (ushort)WazaNo.GAMUSYARA,             (ushort)WazaNo.NAGETUKERU,               (ushort)WazaNo.KOROGARU,             (ushort)WazaNo.AISUBOORU,
            // Final Gambit,                      Explosion,                               Self-Destruct,                       Breakneck Blitz (Physical),
            (ushort)WazaNo.INOTIGAKE,             (ushort)WazaNo.DAIBAKUHATU,              (ushort)WazaNo.ZIBAKU,               (ushort)WazaNo.URUTORADASSYUATAKKU,
            // Breakneck Blitz (Special),         All-Out Pummeling (Physical),            All-Out Pummeling (Special),         Supersonic Skystrike (Physical),
            (ushort)WazaNo.NOOMARUZENRYOKU,       (ushort)WazaNo.ZENRYOKUMUSOUGEKIRETUKEN, (ushort)WazaNo.KAKUTOUZENRYOKU,      (ushort)WazaNo.FAINARUDAIBUKURASSYU,
            // Supersonic Skystrike (Special),    Acid Downpour (Physical),                Acid Downpour (Special),             Tectonic Rage (Physical),
            (ushort)WazaNo.HIKOUZENRYOKU,         (ushort)WazaNo.ASIDDOPOIZUNDERIITO,      (ushort)WazaNo.DOKUZENRYOKU,         (ushort)WazaNo.RAIZINGURANDOOOBAA,
            // Tectonic Rage (Special),           Continental Crush (Physical),            Continental Crush (Special),         Savage Spin-Out (Physical),
            (ushort)WazaNo.ZIMENZENRYOKU,         (ushort)WazaNo.WAARUZUENDOFOORU,         (ushort)WazaNo.IWAZENRYOKU,          (ushort)WazaNo.ZETTAIHOSYOKUKAITENZAN,
            // Savage Spin-Out (Special),         Never-Ending Nightmare (Physical),       Never-Ending Nightmare (Special),    Corkscrew Crash (Physical),
            (ushort)WazaNo.MUSIZENRYOKU,          (ushort)WazaNo.MUGENANYAHENOIZANAI,      (ushort)WazaNo.GOOSUTOZENRYOKU,      (ushort)WazaNo.TYOUZETURASENRENGEKI,
            // Corkscrew Crash (Special),         Inferno Overdrive (Physical),            Inferno Overdrive (Special),         Hydro Vortex (Physical),
            (ushort)WazaNo.HAGANEZENRYOKU,        (ushort)WazaNo.DAINAMIKKUHURUHUREIMU,    (ushort)WazaNo.HONOOZENRYOKU,        (ushort)WazaNo.SUUPAAAKUATORUNEEDO,
            // Hydro Vortex (Special),            Bloom Doom (Physical),                   Bloom Doom (Special),                Gigavolt Havoc (Physical),
            (ushort)WazaNo.MIZUZENRYOKU,          (ushort)WazaNo.BURUUMUSYAINEKUSUTORA,    (ushort)WazaNo.KUSAZENRYOKU,         (ushort)WazaNo.SUPAAKINGUGIGABORUTO,
            // Gigavolt Havoc (Special),          Shattered Psyche (Physical),             Shattered Psyche (Special),          Subzero Slammer (Physical),
            (ushort)WazaNo.DENKIZENRYOKU,         (ushort)WazaNo.MAKISIMAMUSAIBUREIKAA,    (ushort)WazaNo.ESUPAAZENRYOKU,       (ushort)WazaNo.REIZINGUZIOHURIIZU,
            // Subzero Slammer (Special),         Devastating Drake (Physical),            Devastating Drake (Special),         Black Hole Eclipse (Physical),
            (ushort)WazaNo.KOORIZENRYOKU,         (ushort)WazaNo.ARUTHIMETTODORAGONBAAN,   (ushort)WazaNo.DORAGONZENRYOKU,      (ushort)WazaNo.BURAKKUHOORUIKURIPUSU,
            // Black Hole Eclipse (Special),      Twinkle Tackle (Physical),               Twinkle Tackle (Special),            Catastropika,
            (ushort)WazaNo.AKUZENRYOKU,           (ushort)WazaNo.RABURIISUTAAINPAKUTO,     (ushort)WazaNo.FEARIIZENRYOKU,       (ushort)WazaNo.HISSATUNOPIKATYUUTO,
            // Sinister Arrow Raid,               Malicious Moonsault,                     Oceanic Operetta,                    Guardian of Alola,
            (ushort)WazaNo.SYADOOAROOZUSUTORAIKU, (ushort)WazaNo.HAIPAADAAKUKURASSYAA,     (ushort)WazaNo.WADATUMINOSINFONIA,   (ushort)WazaNo.GAADHIANDEAROORA,
            // Soul-Stealing 7-Star Strike,       Stoked Sparksurfer,                      Pulverizing Pancake,                 Extreme Evoboost,
            (ushort)WazaNo.SITISEIDAKKONTAI,      (ushort)WazaNo.RAITONINGUSAAHURAIDO,     (ushort)WazaNo.HONKIWODASUKOUGEKI,   (ushort)WazaNo.NAINEBORUBUUSUTO,
            // Genesis Supernova,                 10,000,000 Volt Thunderbolt,             Splintered Stormshards,              Light That Burns the Sky,
            (ushort)WazaNo.ORIZINZUSUUPAANOVHA,   (ushort)WazaNo._1000MANBORUTO,           (ushort)WazaNo.RAZIARUEZZISUTOOMU,   (ushort)WazaNo.TENKOGASUMETUBOUNOHIKARI,
            // Searing Sunraze Smash,             Menacing Moonraze Maelstrom,             Let's Snuggle Forever,               Clangorous Soulblaze,
            (ushort)WazaNo.SANSYAINSUMASSYAA,     (ushort)WazaNo.MUUNRAITOBURASUTAA,       (ushort)WazaNo.POKABOKAHURENDOTAIMU, (ushort)WazaNo.BUREIZINGUSOURUBIITO,
            // Stuff Cheeks,                      No Retreat,                              Tar Shot,                            Magic Powder,
            (ushort)WazaNo.HOOBARU,               (ushort)WazaNo.HAISUINOZIN,              (ushort)WazaNo.TAARUSYOTTO,          (ushort)WazaNo.MAHOUNOKONA,
            // Dragon Darts,                      Teatime,                                 Octolock,                            Court Change,
            (ushort)WazaNo.DORAGONAROO,           (ushort)WazaNo.OTYAKAI,                  (ushort)WazaNo.TAKOGATAME,           (ushort)WazaNo.KOOTOTHENZI,
            // Clangorous Soul,                   Decorate,                                Life Dew,                            Obstruct,
            (ushort)WazaNo.SOURUBIITO,            (ushort)WazaNo.DEKOREESYON,              (ushort)WazaNo.INOTINOSIZUKU,        (ushort)WazaNo.BUROKKINGU,
            // Max Guard,                         Dynamax Cannon,                          Max Flare,                           Max Flutterby,
            (ushort)WazaNo.DAIWHOORU,             (ushort)WazaNo.DAIMAKKUSUHOU,            (ushort)WazaNo.DAIBAAN,              (ushort)WazaNo.DAIWAAMU,
            // Max Lightning,                     Max Strike,                              Max Knuckle,                         Max Phantasm,
            (ushort)WazaNo.DAISANDAA,             (ushort)WazaNo.DAIATAKKU,                (ushort)WazaNo.DAINAKKURU,           (ushort)WazaNo.DAIHOROU,
            // Max Hailstorm,                     Max Ooze,                                Max Geyser,                          Max Airstream,
            (ushort)WazaNo.DAIAISU,               (ushort)WazaNo.DAIASIDDO,                (ushort)WazaNo.DAISUTORIIMU,         (ushort)WazaNo.DAIJETTO,
            // Max Starfall,                      Max Wyrmwind,                            Max Mindstorm,                       Max Rockfall,
            (ushort)WazaNo.DAIFEARII,             (ushort)WazaNo.DAIDORAGUUN,              (ushort)WazaNo.DAISAIKO,             (ushort)WazaNo.DAIROKKU,
            // Max Quake,                         Max Darkness,                            Max Overgrowth,                      Max Steelspike,
            (ushort)WazaNo.DAIAASU,               (ushort)WazaNo.DAIAAKU,                  (ushort)WazaNo.DAISOUGEN,            (ushort)WazaNo.DAISUTIRU,
        };
        private static readonly ushort[] IsNotDisplayUiAffinityTable = new ushort[]
        {
            // Guillotine,                Horn Drill,                      Sonic Boom,                   Counter,
            (ushort)WazaNo.HASAMIGIROTIN, (ushort)WazaNo.TUNODORIRU,       (ushort)WazaNo.SONIKKUBUUMU,  (ushort)WazaNo.KAUNTAA,
            // Seismic Toss,              Dragon Rage,                     Fissure,                      Night Shade,
            (ushort)WazaNo.TIKYUUNAGE,    (ushort)WazaNo.RYUUNOIKARI,      (ushort)WazaNo.ZIWARE,        (ushort)WazaNo.NAITOHEDDO,
            // Bide,                      Psywave,                         Super Fang,                   Mirror Coat,
            (ushort)WazaNo.GAMAN,         (ushort)WazaNo.SAIKOWHEEBU,      (ushort)WazaNo.IKARINOMAEBA,  (ushort)WazaNo.MIRAAKOOTO,
            // Endeavor,                  Sheer Cold,                      Metal Burst,                  Final Gambit,
            (ushort)WazaNo.GAMUSYARA,     (ushort)WazaNo.ZETTAIREIDO,      (ushort)WazaNo.METARUBAASUTO, (ushort)WazaNo.INOTIGAKE,
            // Nature's Madness,          Guardian of Alola,               Stuff Cheeks,                 No Retreat,
            (ushort)WazaNo.SIZENNOIKARI,  (ushort)WazaNo.GAADHIANDEAROORA, (ushort)WazaNo.HOOBARU,       (ushort)WazaNo.HAISUINOZIN,
            // Tar Shot,                  Magic Powder,                    Teatime,                      Octolock,
            (ushort)WazaNo.TAARUSYOTTO,   (ushort)WazaNo.MAHOUNOKONA,      (ushort)WazaNo.OTYAKAI,       (ushort)WazaNo.TAKOGATAME,
            // Court Change,              Clangorous Soul,                 Decorate,                     Life Dew,
            (ushort)WazaNo.KOOTOTHENZI,   (ushort)WazaNo.SOURUBIITO,       (ushort)WazaNo.DEKOREESYON,   (ushort)WazaNo.INOTINOSIZUKU,
            // Obstruct,
            (ushort)WazaNo.BUROKKINGU,
        };
        private static readonly ushort[] IsTikarazukuEffeciveWazaTable = new ushort[]
        {
            // Secret Power,                    Sparkling Aria,               Spirit Shackle,               Anchor Shot,
            (ushort)WazaNo.HIMITUNOTIKARA,      (ushort)WazaNo.UTAKATANOARIA, (ushort)WazaNo.KAGENUI,       (ushort)WazaNo.ANKAASYOTTO,
            // Genesis Supernova,               Drum Beating,                 Pyro Ball,                    Breaking Swipe,
            (ushort)WazaNo.ORIZINZUSUUPAANOVHA, (ushort)WazaNo.DORAMUATAKKU,  (ushort)WazaNo.KAENBOORU,     (ushort)WazaNo.WAIDOBUREIKAA,
            // Apple Acid,                      Grav Apple,                   Spirit Break,                 Strange Steam,
            (ushort)WazaNo.RINGOSAN,            (ushort)WazaNo.NYUUTON,       (ushort)WazaNo.SOURUKURASSYU, (ushort)WazaNo.WANDAASUTIIMU,
        };
        private static readonly ushort[] IsKiriBaraiEnable_AttackerSideTable = new ushort[]
        {
            // Spikes Side Effect,                         Toxic Spikes Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_MAKIBISI,    (ushort)BtlSideEffect.BTL_SIDEEFF_DOKUBISI,
            // Stealth Rock Side Effect,                   G-Max Steelsurge Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK, (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE,
            // Sticky Web Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_NEBANEBANET,
        };
        private static readonly ushort[] IsKiriBaraiEnable_DefenderSideTable = new ushort[]
        {
            // Reflect Side Effect,                        Light Screen Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_REFLECTOR,   (ushort)BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE,
            // Mist Side Effect,                           Safeguard Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_SIROIKIRI,   (ushort)BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI,
            // Spikes Side Effect,                         Toxic Spikes Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_MAKIBISI,    (ushort)BtlSideEffect.BTL_SIDEEFF_DOKUBISI,
            // Stealth Rock Side Effect,                   G-Max Steelsurge Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK, (ushort)BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE,
            // Sticky Web Side Effect,                     Aurora Veil Side Effect,
            (ushort)BtlSideEffect.BTL_SIDEEFF_NEBANEBANET, (ushort)BtlSideEffect.BTL_SIDEEFF_AURORAVEIL,
        };

        public static bool IsInclude(ServerCommand value, ServerCommand[] table)
        {
            for (int i=0; i<table.Length; i++)
            {
                if (table[i] == value)
                    return true;
            }

            return false;
        }

        public static bool checkTableElems(ushort value, ushort[] table)
        {
            for (int i=0; i<table.Length; i++)
            {
                if (table[i] == value)
                    return true;
            }

            return false;
        }

        public static bool IsMatchEncoreFail(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsMatchEncoreFailTable);
        }

        public static bool IsSakidoriFailWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsSakidoriFailWazaTable);
        }

        public static bool IsDelayAttackWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsDelayAttackWazaTbl);
        }

        public static bool IsZWaza(WazaNo waza)
        {
            return IsZWaza_General(waza) || IsZWaza_Special(waza);
        }

        public static bool IsZWaza_General(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsZWaza_GeneralTable);
        }

        public static bool IsZWaza_Special(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsZWaza_SpecialTable);
        }

        public static bool IsGWaza(WazaNo waza)
        {
            return IsGWaza_General(waza) || checkTableElems((ushort)waza, IsGWazaTable);
        }

        public static bool IsGWaza_General(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsGWaza_GeneralTable);
        }

        public static bool IsPressureEffectiveWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsPressureEffectiveWazaTable);
        }

        public static bool IsGuardTypeSideEffect(BtlSideEffect eff)
        {
            return checkTableElems((ushort)eff, IsGuardTypeSideEffectTable);
        }

        public static bool IsCombiWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsCombiWazaTable);
        }

        public static uint GetAIItemPriority(ushort itemID)
        {
            var arr = GetAIItemPriorityTable;
            for (uint i=0; i<arr.Length; i++)
            {
                var prio = arr[i];
                int j = 0;
                while (true)
                {
                    if (prio[j] == (ushort)ItemNo.DUMMY_DATA)
                        break;

                    if (prio[j] == itemID)
                        return i + 1;

                    j++;
                }
            }

            return 0;
        }

        public static bool CheckItemCallNoEffect(ushort itemID)
        {
            return checkTableElems(itemID, CheckItemCallNoEffectTable);
        }

        public static bool IsNoTargetItem(ushort itemID)
        {
            return checkTableElems(itemID, CheckItemCallNoEffectTable);
        }

        public static bool IsRotoponItem(ushort itemID)
        {
            return checkTableElems(itemID, IsRotoponItemTable);
        }

        public static bool IsKodawariItem(ushort itemID)
        {
            return checkTableElems(itemID, IsKodawariItemTable);
        }

        public static bool CheckNarikiriFailTokusei(TokuseiNo tokuseiID)
        {
            return IsNeverChangeTokusei(tokuseiID) || checkTableElems((ushort)tokuseiID, CheckNakamaDukuriFailTokuseiTable);
        }

        public static bool CheckReceiverFailTokusei(TokuseiNo tokuseiID)
        {
            return CheckNarikiriFailTokusei(tokuseiID);
        }

        public static bool CheckNakamaDukuriFailTokusei(TokuseiNo tokuseiID)
        {
            // Wonder Guard
            return tokuseiID != TokuseiNo.HUSIGINAMAMORI && CheckNarikiriFailTokusei(tokuseiID);
        }

        public static bool CheckTraceFailTokusei(TokuseiNo tokuseiID)
        {
            // Wonder Guard
            return tokuseiID != TokuseiNo.HUSIGINAMAMORI && CheckNarikiriFailTokusei(tokuseiID);
        }

        public static bool CheckSkillSwapFailTokusei(TokuseiNo tokuseiID)
        {
            return IsNeverChangeTokusei(tokuseiID) || checkTableElems((ushort)tokuseiID, CheckSkillSwapFailTokuseiTable);
        }

        public static bool IsNeverChangeTokusei(TokuseiNo tokuseiID)
        {
            return checkTableElems((ushort)tokuseiID, IsNeverChangeTokuseiTable);
        }

        public static bool IsMatchAruseusPlate(ushort itemID)
        {
            return checkTableElems(itemID, IsMatchAruseusPlateTable);
        }

        public static bool IsMatchGuripusu2Chip(ushort itemID)
        {
            return checkTableElems(itemID, IsMatchGuripusu2ChipTable);
        }

        public static bool IsMatchInsectaCasette(ushort itemID)
        {
            return checkTableElems(itemID, IsMatchInsectaCasetteTable);
        }

        public static bool IsMatchKatayaburiTarget(TokuseiNo tokuseiID)
        {
            return checkTableElems((ushort)tokuseiID, IsMatchKatayaburiTargetTable);
        }

        public static bool CheckOmmitAfterHensin(TokuseiNo tokuseiID)
        {
            return checkTableElems((ushort)tokuseiID, CheckOmmitAfterHensinTable);
        }

        public static bool CheckOmmitOnG(TokuseiNo tokuseiID)
        {
            return checkTableElems((ushort)tokuseiID, CheckOmmitOnGTable);
        }

        public static bool IsTypeChangeForbidPoke(ushort monsno)
        {
            return checkTableElems(monsno, IsTypeChangeForbidPokeTable);
        }

        public static bool IsEffectDisableType(ushort effectNo)
        {
            return checkTableElems(effectNo, IsEffectDisableTypeTable);
        }

        public static bool IsCourtChangeSwapSideEffect(BtlSideEffect effectNo)
        {
            return checkTableElems((ushort)effectNo, IsCourtChangeSwapSideEffectTable);
        }

        public static WazaSick GetMentalSickID(uint idx)
        {
            if (idx < MentalSickTbl.Length)
                return MentalSickTbl[idx];
            else
                return WazaSick.WAZASICK_NONE;
        }

        public static bool IsMentalSickID(WazaSick sickID)
        {
            for (int i=0; i<MentalSickTbl.Length; i++)
            {
                if (MentalSickTbl[i] == sickID)
                    return true;
            }

            return false;
        }

        public static WazaSick GetTurnCheckWazaSickByOrder(uint idx)
        {
            if (idx < GetTurnCheckWazaSickByOrderTable.Length)
                return MentalSickTbl[idx];
            else
                return WazaSick.WAZASICK_NONE;
        }

        public static bool checkHaseiOmmitCommon(WazaNo waza)
        {
            return checkTableElems((ushort)waza, checkHaseiOmmitCommonTable);
        }

        public static bool IsNegotoOmmit(WazaNo waza)
        {
            return checkHaseiOmmitCommon(waza) || checkTableElems((ushort)waza, IsNegotoOmmitTable);
        }

        public static bool IsNekoNoteOmmit(WazaNo waza)
        {
            return checkHaseiOmmitCommon(waza) || checkTableElems((ushort)waza, IsNekoNoteOmmitTable);
        }

        public static bool IsManekkoOmmit(WazaNo waza)
        {
            return checkHaseiOmmitCommon(waza) || checkTableElems((ushort)waza, IsManekkoOmmitTable);
        }

        public static bool IsMatchMonomaneFail(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsMatchMonomaneFailTable);
        }

        public static bool IsSaihaiOmmit(WazaNo waza)
        {
            return checkHaseiOmmitCommon(waza) || checkTableElems((ushort)waza, IsSaihaiOmmitTable);
        }

        public static ushort[] GetYubiFuruPermitTable()
        {
            return WazaDataSystem.GetYubiWoHuruPermitWazaTable();
        }

        public static bool IsYubiFuruPermit(WazaNo waza)
        {
            return checkTableElems((ushort)waza, GetYubiFuruPermitTable());
        }

        public static bool IsBoujinGuardWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsBoujinGuardWazaTable);
        }

        public static bool IsAgoBoostWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsAgoBoostWazaTable);
        }

        public static bool IsBoudanWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsBoudanWazaTable);
        }

        public static bool IsDaiWallGuardDisable(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsDaiWallGuardDisableTable);
        }

        public static bool IsOyakoaiOmitWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsOyakoaiOmitWazaTable);
        }

        public static bool IsNotDisplayUiAffinity(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsNotDisplayUiAffinityTable);
        }

        public static bool IsTikarazukuEffeciveWaza(WazaNo waza)
        {
            return checkTableElems((ushort)waza, IsTikarazukuEffeciveWazaTable);
        }

        public static bool IsKiriBaraiEnable_AttackerSide(BtlSideEffect effect)
        {
            return checkTableElems((ushort)effect, IsKiriBaraiEnable_AttackerSideTable);
        }

        public static bool IsKiriBaraiEnable_DefenderSide(BtlSideEffect effect)
        {
            return checkTableElems((ushort)effect, IsKiriBaraiEnable_DefenderSideTable);
        }
    }
}