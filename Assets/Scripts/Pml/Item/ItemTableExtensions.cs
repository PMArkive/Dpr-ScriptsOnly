using XLSXContent;

namespace Pml.Item
{
    public static class ItemTableExtensions
    {
        public static int GetParam(this ItemTable.SheetItem prm, ItemData.PrmID prmID)
        {
            switch (prmID)
            {
                case ItemData.PrmID.ITEMNUMBER:
                    return prm.no;

                case ItemData.PrmID.PRICE:
                    return prm.price;

                case ItemData.PrmID.WAT_PRICE:
                    return 0;

                case ItemData.PrmID.BP_PRICE:
                    return prm.bp_price;

                case ItemData.PrmID.ICONID:
                    return prm.iconid;

                case ItemData.PrmID.EQUIP:
                    return prm.eqp;

                case ItemData.PrmID.ATTACK:
                    return prm.atc;

                case ItemData.PrmID.TUIBAMU_EFF:
                    return prm.tuibamu_eff;

                case ItemData.PrmID.NAGE_EFF:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_NAGE_EFF) != 0 ? 1 : 0;

                case ItemData.PrmID.NAGE_ATC:
                    return prm.nage_atc;

                case ItemData.PrmID.SIZEN_ATC:
                    return prm.sizen_atc;

                case ItemData.PrmID.SIZEN_TYPE:
                    return prm.sizen_type;

                case ItemData.PrmID.IMP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_IMP) != 0 ? 1 : 0;

                case ItemData.PrmID.CNV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_CNV_BTN) != 0 ? 1 : 0;

                case ItemData.PrmID.F_POCKET:
                    return prm.fld_pocket;

                case ItemData.PrmID.F_FUNC:
                    return prm.field_func;

                case ItemData.PrmID.B_FUNC:
                    return prm.battle_func;

                case ItemData.PrmID.WORK_TYPE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_WORK_TYPE) != 0 ? 1 : 0;

                case ItemData.PrmID.ITEM_TYPE:
                    return prm.type;

                case ItemData.PrmID.SPEND:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SPEND) != 0 ? 1 : 0;

                case ItemData.PrmID.USE_SPEND:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_USE_NO_SPEND) != 0 ? 1 : 0;

                case ItemData.PrmID.SORT:
                    return prm.sort;

                case ItemData.PrmID.GROUP:
                    return prm.group;

                case ItemData.PrmID.GROUPID:
                    return prm.group_id;

                case ItemData.PrmID.SET_TO_POKE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SET_TO_POKE) != 0 ? 1 : 0;

                case ItemData.PrmID.B_SELECTABLE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_BATTLE_SELECTABLE) != 0 ? 1 : 0;

                case ItemData.PrmID.INACTIVE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_INACTIVE) != 0 ? 1 : 0;

                default:
                    if (prm.GetParam(ItemData.PrmID.WORK_TYPE) == 0)
                        return prm.wk_cmn;
                    else
                        return prm.GetWorkRecoverItem(prmID);
            }
        }

        public static int GetWorkRecoverItem(this ItemTable.SheetItem prm, ItemData.PrmID prmID)
        {
            switch (prmID)
            {
                case ItemData.PrmID.SLEEP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SLEEP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.POISON_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_POISON_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.BURN_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_BURN_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ICE_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ICE_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.PARALYZE_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PARALAYZE_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.PANIC_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PANIC_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.MEROMERO_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_MEROMERO_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ABILITY_GUARD:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ABILITY_GUARD) != 0 ? 1 : 0;

                case ItemData.PrmID.DEATH_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_DEATH_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ALL_DEATH_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ALLDEATH_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.LV_UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_LV_UP) != 0 ? 1 : 0;

                case ItemData.PrmID.EVOLUTION:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_EVOLUTION) != 0 ? 1 : 0;

                case ItemData.PrmID.ATTACK_UP:
                    return prm.wk_atc_up;

                case ItemData.PrmID.DEFENCE_UP:
                    return prm.wk_def_up;

                case ItemData.PrmID.SP_ATTACK_UP:
                    return prm.wk_spa_up;

                case ItemData.PrmID.SP_DEFENCE_UP:
                    return prm.wk_spd_up;

                case ItemData.PrmID.AGILITY_UP:
                    return prm.wk_agi_up;

                case ItemData.PrmID.HIT_UP:
                    return prm.wk_hit_up;

                case ItemData.PrmID.CRITICAL_UP:
                    return prm.wk_critical_up;

                case ItemData.PrmID.PP_UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_UP) != 0 ? 1 : 0;

                case ItemData.PrmID.PP_3UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_3UP) != 0 ? 1 : 0;

                case ItemData.PrmID.PP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ALL_PP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ALLPP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.HP_RCV:
                    if (prm.GetWorkRecoverItem(ItemData.PrmID.DEATH_RCV) != 1 || prm.GetWorkRecoverItem(ItemData.PrmID.ALL_DEATH_RCV) != 1)
                        return 0;
                    return prm.wk_prm_hp_rcv != 0 ? 1 : 0;

                case ItemData.PrmID.HP_EXP:
                    return prm.wk_prm_hp_exp != 0 ? 1 : 0;

                case ItemData.PrmID.POWER_EXP:
                    return prm.wk_prm_pow_exp != 0 ? 1 : 0;

                case ItemData.PrmID.DEFENCE_EXP:
                    return prm.wk_prm_def_exp != 0 ? 1 : 0;

                case ItemData.PrmID.AGILITY_EXP:
                    return prm.wk_prm_agi_exp != 0 ? 1 : 0;

                case ItemData.PrmID.SP_ATTACK_EXP:
                    return prm.wk_prm_spa_exp != 0 ? 1 : 0;

                case ItemData.PrmID.SP_DEFENCE_EXP:
                    return prm.wk_prm_spd_exp != 0 ? 1 : 0;

                case ItemData.PrmID.EXP_LIMIT_FLAG:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_EXP_LIMIT) != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND1:
                    return prm.wk_friend1 != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND2:
                    return prm.wk_friend2 != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND3:
                    return prm.wk_friend3 != 0 ? 1 : 0;

                case ItemData.PrmID.HP_EXP_POINT:
                    return prm.wk_prm_hp_exp;

                case ItemData.PrmID.POWER_EXP_POINT:
                    return prm.wk_prm_pow_exp;

                case ItemData.PrmID.DEFENCE_EXP_POINT:
                    return prm.wk_prm_def_exp;

                case ItemData.PrmID.AGILITY_EXP_POINT:
                    return prm.wk_prm_agi_exp;

                case ItemData.PrmID.SP_ATTACK_EXP_POINT:
                    return prm.wk_prm_spa_exp;

                case ItemData.PrmID.SP_DEFENCE_EXP_POINT:
                    return prm.wk_prm_spd_exp;

                case ItemData.PrmID.HP_RCV_POINT:
                    return prm.wk_prm_hp_rcv;

                case ItemData.PrmID.PP_RCV_POINT:
                    return prm.wk_prm_pp_rcv;

                case ItemData.PrmID.FRIEND1_POINT:
                    return prm.wk_friend1;

                case ItemData.PrmID.FRIEND2_POINT:
                    return prm.wk_friend2;

                case ItemData.PrmID.FRIEND3_POINT:
                    return prm.wk_friend3;

                default:
                    GFL.ASSERT(false, "Invalid ItemData::PrmID");
                    return 0;
            }
        }

        // TODO
        public static uint GetHealingItemType(this ItemTable.SheetItem item) { return 0; }

        // TODO
        public static bool IsNeedSelectSkill(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsDeathRecoverAllItem(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsSale(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsEventItem(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static int GetGroupId(this ItemTable.SheetItem item) { return 0; }

        // TODO
        public static BallId GetBallID(this ItemTable.SheetItem item) { return BallId.NULL; }

        // TODO
        public static bool IsWazaMachine(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static uint GetWazaMashineNo(this ItemTable.SheetItem item) { return 0; }

        // TODO
        public static bool IsWazaRecord(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsNuts(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static byte GetNutsNo(this ItemTable.SheetItem item) { return 0; }

        // TODO
        public static bool IsGroupOf(this ItemTable.SheetItem item, byte itemgroup) { return false; }

        // TODO
        public static bool IsMegaStone(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsJewel(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsPiece(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsBeads(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool IsHeart(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static bool CanPokeHave(this ItemTable.SheetItem item) { return false; }

        // TODO
        public static uint GetTypeSortNumber(this ItemTable.SheetItem item) { return 0; }
    }
}