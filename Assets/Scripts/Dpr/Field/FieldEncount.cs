﻿using Pml.PokePara;
using Pml;
using UnityEngine;
using XLSXContent;
using Dpr.Trainer;
using Dpr.Battle.Logic;

namespace Dpr.Field
{
    public class FieldEncount
    {
        public const int GENE_ENC_1 = 0;
        public const int GENE_ENC_2 = 1;
        public const int TIME_ENC_1 = 2;
        public const int TIME_ENC_2 = 3;
        public const int SWAY_ENC_1 = 4;
        public const int SWAY_ENC_2 = 5;
        public const int SP_ENC_1 = 6;
        public const int SP_ENC_2 = 7;
        public const int AGB_ENC_1 = 8;
        public const int AGB_ENC_2 = 9;
        public const int SWAY_ENC_3 = 10;
        public const int SWAY_ENC_4 = 11;
        public const int ENC_MONS_NUM_NORMAL = 12;
        public const int ENC_MONS_NUM_GENERATE = 2;
        public const int ENC_MONS_NUM_NOON = 2;
        public const int ENC_MONS_NUM_NIGHT = 2;
        public const int ENC_MONS_NUM_SWAY_GRASS = 4;
        public const int ENC_FORM_PROB_NUM = 5;
        public const int ENC_MONS_NUM_AGB = 2;
        public const int ENC_MONS_NUM_SEA = 5;
        public const int ENC_MONS_NUM_ROCK = 5;
        public const int ENC_MONS_NUM_FISH = 5;
        public const int GROUND_ENCOUNT = 0;
        public const int WATER_ENCOUNT = 1;
        public const int FISHING_ENCOUNT = 2;
        private const int ENC_MONS_NUM_MAX = 12;
        private const int ROD_TYPE_NONE = 255;
        private const int WEATHER_NONE = 255;
        private const int CALC_SHIFT = 8;
        private const int DEBUG_MONITOR_TIME = 20;

        // TODO
        public static EncountResult FieldEncount_Check(FieldObjectEntity entity, bool inGridmove) { return null; }

        // TODO
        private static void EncountAttributeCheck(int attribute, FieldEncountTable.Sheettable data, out int enc_location, out uint prob)
        {
            enc_location = 0;
            prob = 0;
        }

        // TODO
        private static void GetEncountProbFishing(FishingRod inRodType, FieldEncountTable.Sheettable data, out uint prob)
        {
            prob = 0;
        }

        // TODO
        public static EncountResult SetFishingEncount(FishingRod inRodType, Vector2Int position) { return null; }

        // TODO
        public static EncountResult SetSweetEncount() { return null; }

        // TODO
        private static void ApplyDayTime(ref MonsLv[] enc_data, FieldEncountTable.Sheettable data) { }

        // TODO
        private static void ApplyAgbSlot(ref MonsLv[] enc_data, FieldEncountTable.Sheettable data) { }

        // TODO
        private static int GetMaxLvMonsTblNo(MonsLv[] inEncCommonData, ENC_FLD_SPA inFldSpa, int inTblNo) { return 0; }

        // TODO
        private static void SetSpaStruct(PokemonParam inPokeParam, FieldEncountTable.Sheettable inData, ref ENC_FLD_SPA outSpa) { }

        // TODO
        private static uint ChangeEncProb(bool inIsFishing, uint inProb, ENC_FLD_SPA inFldSpa, SYS_WEATHER inWeatherCode, PokemonParam inPokeParam) { return 0; }

        // TODO
        private static bool CheckEcntCancelByLv(ENC_FLD_SPA inFldSpa, PokemonParam inMyPokeParam, int inEneLv) { return false; }

        // TODO
        private static bool CheckSpray(int inEneLv, ref ENC_FLD_SPA inSpa) { return false; }

        // TODO
        private static uint ChangeEncProbByEquipItem(PokemonParam inMyPokeParam, uint ioPer) { return 0; }

        // TODO
        private static bool WildEncSingle(PokemonParam poke_param, ref EncountResult param, FieldEncountTable.Sheettable data, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa, SWAY_ENC_INFO inSwayEncInfo) { return false; }

        // TODO
        private static bool WildEncDouble(PokemonParam poke_param, ref EncountResult param, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa) { return false; }

        // TODO
        private static bool WildWaterEncSingle(PokemonParam poke_param, ref EncountResult param, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa) { return false; }

        // TODO
        private static bool FishingEncSingle(PokemonParam poke_param, ref EncountResult battle_param, MonsLv[] inData, ENC_FLD_SPA inFldSpa, FishingRod inRodType) { return false; }

        // TODO
        private static bool MapEncountCheck(uint per, int attr, bool inGridmove) { return false; }

        // TODO
        private static bool EncountWalkCheck(float walkcnt, uint per) { return false; }

        // TODO
        private static bool EncountCheckMain(uint per) { return false; }

        // TODO
        private static int RandomPokeSet() { return 0; }

        // TODO
        private static int RandomPokeSetNoGround() { return 0; }

        // TODO
        private static int RandomPokeSetFishing(FishingRod inFishingRod) { return 0; }

        // TODO
        private static bool SetEncountData(PokemonParam param, FishingRod inRodType, ENC_FLD_SPA inFldSpa, MonsLv[] inData, int location, BTL_CLIENT_ID inTarget, ref EncountResult outBattleParam) { return false; }

        // TODO
        private static bool SetEncountDataDecideMons(MonsNo inMonsNo, uint inLv, BTL_CLIENT_ID inTarget, bool inRare, ENC_FLD_SPA inFldSpa, PokemonParam param, ref EncountResult outBattleParam) { return false; }

        // TODO
        private static bool SetSwayEncountData(PokemonParam param, ENC_FLD_SPA inFldSpa, MonsLv[] inData, BTL_CLIENT_ID inTarget, ref EncountResult outBattleParam, MonsNo inMonsNo, uint inLv) { return false; }

        // TODO
        private static bool CheckFixTypeEcnt(ENC_FLD_SPA inFldSpa, MonsLv[] inData, int inListNum, PokeType type, TokuseiNo tokusei, ref int outNo) { return false; }

        // TODO
        private static bool FixPokeSet(MonsLv[] inData, int inListNum, PokeType type, ref int outNo) { return false; }

        // TODO
        private static int SetEncountPokeLv(MonsLv inData, ENC_FLD_SPA inFldSpa) { return 0; }

        // TODO
        private static void EncountParamSetRare(MonsNo poke, int lv, BTL_CLIENT_ID inTarget, ENC_FLD_SPA inFldSpa, PokemonParam inPokeParam, ref EncountResult outBattleParam) { }

        // TODO
        private static void EncountParamSet(MonsNo poke, int lv, BTL_CLIENT_ID inTarget, ENC_FLD_SPA inFldSpa, PokemonParam inPokeParam, ref EncountResult outBattleParam) { }

        // TODO
        private static void LastTokuseiCheck(ref EncountResult result, ref ENC_FLD_SPA spa) { }

        // TODO
        private static void LastProc(ref EncountResult result, ref ENC_FLD_SPA spa) { }

        // TODO
        private static void SetSfariMonster(bool inSafariFlg, bool inBookGet, ref MonsLv[] enc_data) { }

        // TODO
        public static MonsNo GetSafariScopeMonster(ZoneID zoneId) { return MonsNo.NULL; }

        // TODO
        private static void SafariEnc_SetSafariEnc(int inRandomSeed, bool inBookGet, ZoneID inZoneID, ref MonsLv[] outenc_data) { }

        // TODO
        private static int CheckMovePokeEnc() { return 0; }

        // TODO
        public static bool IsTairyouHassei() { return false; }

        // TODO
        public static int SafariRandomSeed() { return 0; }

        public struct ENC_FLD_SPA
        {
            public TrainerID TrainerID;
            public bool SprayCheck;
            public bool EncCancelSpInvalid;
            public int SpMyLv;
            public bool Egg;
            public TokuseiNo Spa;
            public int[] FormProb;
            public int AnnoonTblType;
        }

        public struct SWAY_ENC_INFO
        {
            public int Table;
            public bool Decide;
            public bool Enc;
        }
    }
}