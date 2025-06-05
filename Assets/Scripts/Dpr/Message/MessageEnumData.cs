﻿namespace Dpr.Message
{
    public static class MessageEnumData
    {
        public enum MsgLangId : int
        {
            JPN = 1,
            USA = 2,
            FRA = 3,
            ITA = 4,
            DEU = 5,
            ESP = 7,
            KOR = 8,
            SCH = 9,
            TCH = 10,
            Num = 11,
        }

        public enum NXLangId : int
        {
            Japanese = 0,
            English = 1,
            French = 2,
            German = 3,
            Italian = 4,
            Spanish = 5,
            Korean = 7,
            NetherLands = 8,
            Portuguese = 9,
            Russian = 10,
            SimpChinese = 15,
            TradChinese = 16,
        }

        public enum TagPatternID : int
        {
            Word = 0,
            Digit = 1,
            Conversion = 2,
            RichText = 3,
            Grammar = 4,
            GrammarWord = 5,
            ControlDesign = 6,
            ControlMessage = 7,
            SpriteFont = 8,
        }

        public enum InitialSoundID : int
        {
            Vowel = 0,
            VowelA = 1,
            VowelE = 2,
            Vowel2 = 3,
            Vowel3 = 4,
            Consonant2 = 5,
            Consonant = 6,
        }


        public enum AttributeID : int
        {
            EnglishInitialSound = 3,
            EnglishCountability = 4,
            EnglishArticlePresence = 5,
            FrenchGender = 7,
            FrenchInitialSound = 8,
            FrenchCountability = 9,
            FrenchExtraAttribute = 10,
            FrenchArticlePresence = 11,
            ItalianGender = 12,
            ItalianInitialSound = 13,
            ItalianCountability = 14,
            ItalianArticlePresence = 16,
            GermanGender = 17,
            GermanCountability = 18,
            GermanExtraAttribute = 19,
            GermanArticlePresence = 20,
            SpanishGender = 21,
            SpanishInitialSound = 22,
            SpanishCountability = 23,
            SpanishExtraAttribute = 24,
            SpanishArticlePresence = 25,
            LabelIndex = 65,
            Version = 67,
        }

        public enum AttriCountabilityID : int
        {
            Countable = 0,
            Uncontable = 1,
            AlwaysPlural = 2,
        }

        public enum AttriArticleID : int
        {
            Article = 0,
            NoArticle = 1,
        }

        public enum ENInitialSoundID : int
        {
            AutoDetected = 0,
            Consonant = 1,
            Vowel = 2,
        }

        public enum FRInitialSoundID : int
        {
            AutoDetected = 0,
            NoElision = 1,
            YesElision = 2,
        }

        public enum ITInitialSoundID : int
        {
            AutoDetected = 0,
            ConsonantOthers = 1,
            S_Consonant = 2,
            Vowel = 3,
        }

        public enum ESInitialSoundID : int
        {
            AutoDetected = 0,
            Consonant = 1,
            Cacophony_y = 2,
            TonicaA = 3,
            Cacophony_o = 4,
        }

        public enum StyleID : int
        {
            keywait_text_18_big = 0,
            keywait_text_23_big = 1,
            keywait_text_28_big = 2,
            std_1_N_big = 3,
            std_4_N_big = 4,
            std_6_N_big = 5,
            std_7_N_big = 6,
            std_8_N_big = 7,
            std_10_N_big = 8,
            std_10_N2_big = 9,
            std_11_N_big = 10,
            std_11_N2_big = 11,
            std_12_N_big = 12,
            std_12_N2_big = 13,
            std_14_N_big = 14,
            std_15_N_big = 15,
            std_15_N4_big = 16,
            std_16_N_big = 17,
            std_17_N_big = 18,
            std_18_N_big = 19,
            std_18_N2_big = 20,
            std_18_N3_big = 21,
            std_18_N4_big = 22,
            std_18_N5_big = 23,
            std_18_N6_big = 24,
            std_18_N7_big = 25,
            std_18_N10_big = 26,
            std_20_N4_big = 27,
            std_23_N_big = 28,
            std_23_N2_big = 29,
            keywait_text_18 = 30,
            keywait_text_23 = 31,
            std_01_N = 32,
            std_02_N = 33,
            std_03_N = 34,
            std_04_N = 35,
            std_05_N = 36,
            std_06_N = 37,
            std_07_N = 38,
            std_08_N = 39,
            std_08_N2 = 40,
            std_09_N = 41,
            std_10_N = 42,
            std_10_N2 = 43,
            std_11_N = 44,
            std_11_N2 = 45,
            std_12_N = 46,
            std_13_N = 47,
            std_14_N = 48,
            std_15_N = 49,
            std_16_N = 50,
            std_16_N2 = 51,
            std_16_N4 = 52,
            std_16_N5 = 53,
            std_16_N7 = 54,
            std_17_N = 55,
            std_18_N = 56,
            std_18_N2 = 57,
            std_18_N3 = 58,
            std_18_N4 = 59,
            std_18_N5 = 60,
            std_18_N6 = 61,
            std_18_N7 = 62,
            std_18_N8 = 63,
            std_18_N10 = 64,
            std_20_N = 65,
            std_20_N6 = 66,
            std_20_N12 = 67,
            std_21_N = 68,
            std_21_N3 = 69,
            std_22_N2 = 70,
            std_23_N = 71,
            std_23_N2 = 72,
            std_24_N = 73,
            std_30_N = 74,
            std_43_N = 75,
            std_01_N_small = 76,
            std_02_N_small = 77,
            std_03_N_small = 78,
            std_04_N_small = 79,
            std_05_N_small = 80,
            std_06_N_small = 81,
            std_07_N_small = 82,
            std_08_N_small = 83,
            std_08_N2_small = 84,
            std_08_N3_small = 85,
            std_09_N_small = 86,
            std_10_N_small = 87,
            std_10_N2_small = 88,
            std_10_N3_small = 89,
            std_11_N_small = 90,
            std_12_N_small = 91,
            std_13_N_small = 92,
            std_14_N_small = 93,
            std_15_N_small = 94,
            std_16_N_small = 95,
            std_16_N2_small = 96,
            std_16_N4_small = 97,
            std_16_N5_small = 98,
            std_16_N7_small = 99,
            std_16_N8_small = 100,
            std_16_N14_small = 101,
            std_18_N_small = 102,
            std_18_N2_small = 103,
            std_18_N3_small = 104,
            std_18_N5_small = 105,
            std_20_N2_small = 106,
            std_20_N3_small = 107,
            std_21_N_small = 108,
            std_21_N3_small = 109,
            std_22_N_small = 110,
            std_22_N3_small = 111,
            std_23_N_small = 112,
            std_23_N2_small = 113,
            std_23_N5_small = 114,
            std_32_N_small = 115,
            std_46_N_small = 116,
            std_10_G_big = 117,
            std_14_G_big = 118,
            std_05_G = 119,
            std_06_G = 120,
            std_08_G = 121,
            std_08_G_P = 122,
            std_08_G_C = 123,
            std_09_G = 124,
            std_10_G = 125,
            std_10_G_P = 126,
            std_10_G_C = 127,
            std_12_G = 128,
            std_12_G_P = 129,
            std_12_G_C = 130,
            std_14_G = 131,
            std_15_G = 132,
            std_16_G = 133,
            std_05_G_small = 134,
            std_06_G_small = 135,
            std_08_G_P_small = 136,
            std_08_G_small = 137,
            std_10_G_small = 138,
            std_14_G_small = 139,
            std_01_S_big = 140,
            std_02_S_big = 141,
            std_03_S_big = 142,
            std_04_S_big = 143,
            std_05_S_big = 144,
            std_06_S_big = 145,
            std_01_S = 146,
            std_02_S = 147,
            std_03_S = 148,
            std_04_S = 149,
            std_05_S = 150,
            std_06_S = 151,
            std_07_S = 152,
            std_08_S = 153,
            std_09_S = 154,
            std_10_S = 155,
            std_11_S = 156,
            std_12_S = 157,
            std_14_S = 158,
            std_16_S = 159,
            std_17_S = 160,
            std_18_S = 161,
            std_19_S = 162,
            std_24_S = 163,
            std_01_S_small = 164,
            std_02_S_small = 165,
            std_03_S_small = 166,
            std_04_S_small = 167,
            std_05_S_small = 168,
            std_06_S_small = 169,
            std_07_S_small = 170,
            std_08_S_small = 171,
            std_09_S_small = 172,
            std_10_S_small = 173,
            std_11_S_small = 174,
            std_12_S_small = 175,
            std_14_S_small = 176,
            std_16_S_small = 177,
            std_17_S_small = 178,
            std_19_S_small = 179,
            std_24_S_small = 180,
            std_6_N_huge = 181,
            std_10_N_huge = 182,
            keywait_text_18_big_white = 183,
            keywait_text_18_big_1 = 184,
            keywait_text_18_big_2 = 185,
            keywait_text_18_big_3 = 186,
            keywait_text_14_big_white = 187,
            Max = 188,
        }

        public enum FontID : int
        {
            Switch_Std = 1,
            Switch_Small = 2,
            Switch_Big = 3,
            Switch_Std_efigs = 4,
            Switch_Small_efigs = 5,
            Switch_Big_efigs = 6,
            Switch_Std_kor = 7,
            Switch_Small_kor = 8,
            Switch_Big_kor = 9,
            Switch_Std_simp = 10,
            Switch_Small_simp = 11,
            Switch_Big_simp = 12,
            Switch_Std_trad = 13,
            Switch_Small_trad = 14,
            Switch_Big_trad = 15,
            Switch_Huge = 16,
            Switch_Huge_efigs = 17,
            Switch_Huge_kor = 18,
            Switch_Huge_simp = 19,
            Switch_Huge_trad = 20,
        }

        public enum FontSizeID : int
        {
            Small = 0,
            Std = 1,
            Big = 2,
            Huge = 3,
        }

        public enum GroupTagID : int
        {
            System = 0,
            Name = 1,
            Digit = 2,
            Grm = 16,
            EN = 19,
            FR = 20,
            IT = 21,
            DE = 22,
            ES = 23,
            Kor = 25,
            SC = 26,
            Character1 = 50,
            Character2 = 51,
            Ctrl1 = 189,
            Ctrl2 = 190,
        }

        public enum SystemID : int
        {
            Font = 1,
            Size = 2,
            Color = 3,
        }

        public enum NameID : int
        {
            TrainerName = 0,
            PokemonName = 1,
            PokemonNickname = 2,
            Type = 3,
            PokedexType = 4,
            Place = 5,
            Ability = 6,
            Move = 7,
            Nature = 8,
            Item = 9,
            ItemClassified = 10,
            ItemAcc = 11,
            PokemonNicknameTwo = 12,
            Status = 13,
            TrainerType = 14,
            Poffin = 15,
            ItemAccClassified = 16,
            GoodsName = 17,
            Pocket = 18,
            ItemText = 19,
            TrainerNameField = 20,
            Poketch = 21,
            UgItem = 22,
            BagPocketIcon = 23,
            PocketIcon = 24,
            Word = 25,
            Question = 26,
            Answer = 27,
            Accessory = 28,
            Gym = 29,
            TimeZone = 30,
            Contest = 31,
            ContestRank = 32,
            PokeGender = 33,
            PokeLevel = 34,
            GroupName = 35,
            Location = 36,
            Area = 37,
            Ribbon = 38,
            UndergroundItemDefArt = 39,
            UndergroundItemIndefArt = 40,
            Taste = 41,
            SerialNumber = 42,
            FreeWord = 43,
            Undefined = 44,
            PlayerNickname = 45,
            PlayerNicknamePrefix = 46,
            TrimmianFormName = 47,
            TrainerTypeAndName = 48,
            HairStyle_Name = 49,
            Bangs_Name = 50,
            HairColor_Name = 51,
            TournamentName = 52,
            FullPowerMove = 53,
            BattleState = 54,
            FlySpotName = 55,
            Record_Name = 56,
            BattleTeam = 57,
            BoxName = 58,
            KisekaeItem = 59,
            KisekaeItemColor = 60,
            BGM = 61,
            Uniformnumber = 62,
            BirthdayM = 63,
            BirthdayD = 64,
            TrainerNameUpperCase = 65,
            PokemonNicknameUpperCase = 66,
            CookName = 67,
            Classname = 68,
            AnotherName = 69,
            CompanyName = 70,
            PlaceIndirect = 71,
            FormName = 72,
            RegurationName = 73,
            Memory_Place = 74,
            Memory_Feeling = 75,
            Memory_Rank = 76,
            Sticker = 77,
            ParkItem = 78,
            Kinomi = 79,
            UgItemAcc = 80,
            UgItemClassified = 81,
            UgItemAccClassified = 82,
            PoffinAcc = 83,
            StyleName = 84,
            BattleRule = 85,
        }

        public enum DigitID : int
        {
            OneDigit = 0,
            TwoDigits = 1,
            ThreeDigits = 2,
            FourDigits = 3,
            FiveDigits = 4,
            SixDigits = 5,
            SevenDigits = 6,
            EightDigits = 7,
            NineDigits = 8,
            TenDigits = 9,
        }

        public enum GrmID : int
        {
            ForceSingular = 0,
            ForcePlural = 1,
            ForceMasculine = 2,
            ForceInitialCap = 3,
        }

        public enum ENID : int
        {
            Gen = 0,
            Qty = 1,
            GenQty = 2,
            DefArt = 3,
            DefArtCap = 4,
            IndArt = 5,
            IndArtCap = 6,
            ForceSingular = 7,
            ForcePlural = 8,
            ForceInitialCap = 9,
            QtyZero = 10,
        }

        public enum FRID : int
        {
            Gen = 0,
            Qty = 1,
            GenQty = 2,
            DefArt = 3,
            DefArtCap = 4,
            IndArt = 5,
            IndArtCap = 6,
            A_DefArt = 7,
            A_DefArtCap = 8,
            De_DefArt = 9,
            De_DefArtCap = 10,
            De = 11,
            DeCap = 12,
            ForceSingular = 13,
            ForcePlural = 14,
            Que = 15,
            QueCap = 16,
            Elision = 17,
            ForceInitialCap = 18,
            QtyZero = 19,
        }

        public enum ITID : int
        {
            Gen = 0,
            Qty = 1,
            GenQty = 2,
            DefArt = 3,
            DefArtCap = 4,
            IndArt = 5,
            IndArtCap = 6,
            Di_DefArt = 7,
            Di_DefArtCap = 8,
            Su_DefArt = 9,
            Su_DefArtCap = 10,
            A_DefArt = 11,
            A_DefArtCap = 12,
            ForceSingular = 13,
            ForcePlural = 14,
            ForceMasculine = 15,
            In_DefArt = 16,
            In_DefArtCap = 17,
            Ed = 18,
            EdCap = 19,
            Ad = 20,
            AdCap = 21,
            ForceInitialCap = 22,
            QtyZero = 23,
            DateIT = 24,
        }

        public enum DEID : int
        {
            Gen = 0,
            Qty = 1,
            GenQty = 2,
            DefArtNom = 3,
            DefArtNomCap = 4,
            IndArtNom = 5,
            IndArtNomCap = 6,
            DefArtAcc = 7,
            DefArtAccCap = 8,
            IndArtAcc = 9,
            IndArtAccCap = 10,
            ForceSingular = 11,
            ForcePlural = 12,
            ForceInitialCap = 13,
            QtyZero = 14,
            ItemAcc = 15,
            ItemAccClassified = 16,
        }

        public enum ESID : int
        {
            Gen = 0,
            Qty = 1,
            GenQty = 2,
            DefArt = 3,
            DefArtCap = 4,
            IndArt = 5,
            IndArtCap = 6,
            De_DefArt = 7,
            De_DefArtCap = 8,
            A_DefArt = 9,
            A_DefArtCap = 10,
            DefArt_TrTypeAndName = 11,
            DefArtCap_TrTypeAndName = 12,
            A_DefArt_TrTypeAndName = 13,
            De_DefArt_TrTypeAndName = 14,
            ForceSingular = 15,
            ForcePlural = 16,
            ForceInitialCap = 17,
            QtyZero = 18,
            y_e = 19,
            Y_E = 20,
            o_u = 21,
            O_U = 22,
        }

        public enum KorID : int
        {
            Particle = 0,
            Gen = 1,
            Qty = 2,
            GenQty = 3,
            QtyZero = 4,
        }

        public enum SCID : int
        {
            Gen = 0,
        }

        public enum Character1ID : int
        {
            heart = 0,
            music = 1,
            male = 2,
            female = 3,
            PokeDollar = 4,
            Left = 5,
            Up = 6,
            Right = 7,
            Down = 8,
            PocketIcon = 9,
            Item = 10,
            KeyItem = 11,
            Machine = 12,
            Seal = 13,
            Medicine = 14,
            Nut = 15,
            Ball = 16,
            Battle = 17,
            Staff = 18,
            LeftDirection = 19,
            UpDirection = 20,
            RightDirection = 21,
            DownDirection = 22,
            Sparkles = 23,
        }

        public enum Character2ID : int
        {
            L_SingleQuot_ = 0,
            R_SingleQuot_ = 1,
            L_DoubleQuot_ = 2,
            R_DoubleQuot_ = 3,
            DE_L_DoubleQuot_ = 4,
            DE_R_DoubleQuot_ = 5,
            StraightSingleQuot_ = 6,
            StraightDoubleQuot_ = 7,
            HalfSpace = 8,
            QuarterSpace = 9,
            Upper_er = 10,
            Upper_re = 11,
            Upper_r = 12,
            Upper_e = 13,
            Upper_a = 14,
            Abbrev_ = 15,
            Center_dot = 16,
            PKMN = 17,
            NULL = 18,
            ModifierLetterCapitalO = 19,
            SixPerEmSpace = 20,
        }

        public enum Ctrl1ID : int
        {
            xright = 3,
            xadd = 4,
            xset = 5,
            battle_oneline = 6,
            unknown_message = 7,
        }

        public enum Ctrl2ID : int
        {
            LineFeed = 0,
            PageClear = 1,
            WaitOne = 2,
            CallBackOne = 5,
            GuidIcon = 10,
        }

        public enum DigitTagParamID : int
        {
            None = 0,
            Default = 1,
            Comma = 2,
            Period = 3,
            HalfSpace = 4,
            QuaterSpace = 5,
            Max = 6,
        }

        public enum QtyID : int
        {
            Singular = 0,
            Plural = 1,
            Zero = 2,
        }

        public enum GenderQtyID : int
        {
            MasculineSingular = 0,
            FeminineSingular = 1,
            MasculinePlural = 2,
            FemininePlural = 3,
        }

        public enum DEGenderQtyID : int
        {
            MasculineSingular = 0,
            FeminineSingular = 1,
            NeuterSingular = 2,
            Plural = 3,
        }

        public enum ForceGrmID : int
        {
            None = 0,
            Singular = 1,
            Plural = 2,
            Masculine = 3,
            InitialCap = 4,
        }

        public enum MsgEventID : int
        {
            None = 0,
            NewLine = 1,
            Wait = 2,
            ScrollPage = 3,
            ScrollLine = 4,
            CallBack = 5,
            GuidIcon = 6,
            End = 7,
        }

        public enum WordDataPatternID : int
        {
            Str = 0,
            FontTag = 1,
            ColorTag = 2,
            SizeTag = 3,
            CtrlTag = 4,
            WordTag = 5,
            SpriteFont = 6,
            Event = 7,
        }

        public enum MsgControlID : int
        {
            None = 0,
            BattleOneline = 1,
            UnknownMessage = 2,
        }

        public enum UIFontSizeID : int
        {
            SSS = 0,
            SS = 1,
            S = 2,
            M = 3,
            L = 4,
            LL = 5,
            LLL = 6,
            XL = 7,
            WazaKouka = 10,
        }

        public enum GenderID : int
        {
            Masculine = 0,
            Feminine = 1,
            Neuter = 2,
        }
    }
}