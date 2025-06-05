using Dpr.Trainer;
using Pml;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public class BSP_TRAINER_DATA
    {
        public const int USE_ITEM_MAX = 4;
        private CORE_DATA mCore = new CORE_DATA();

        // TODO
        public TrainerID GetTrainerID() { return TrainerID.INVALID; }

        // TODO
        public uint GetAIBit() { return 0; }

        // TODO
        public BattleSetupEffectId GetBattleEffectID() { return BattleSetupEffectId.NONE; }

        // TODO
        public TrainerType GetTrainerType() { return TrainerType.INVALID; }

        // TODO
        public TrainerTypeGroup GetTrainerGroup() { return TrainerTypeGroup.NORA; }

        // TODO
        public Sex GetTrainerSex() { return Sex.MALE; }

        // TODO
        public byte GetGoldParam() { return 0; }

        // TODO
        public string GetModelID() { return null; }

        // TODO
        public int GetColorID() { return 0; }

        // TODO
        public ushort GetUseItem(int index) { return 0; }

        // TODO
        public string GetNameLabel() { return null; }

        // TODO
        public string GetTrTypeNameLabel() { return null; }

        // TODO
        public void SetTrainerID(TrainerID id) { }

        // TODO
        public void SetAIBit(uint bit) { }

        // TODO
        public void SetGoldParam(byte gold) { }

        // TODO
        public void SetModelID(string modelID) { }

        // TODO
        public void SetColorID(int color_id) { }

        // TODO
        public void Dispose() { }

        // TODO
        public void LoadTrTypeData(TrainerType trainerType) { }

        // TODO
        public void SetupTrainerData(TrainerTable.SheetTrainerData trainerData) { }

        // TODO
        public void SetupTrainerData(TowerTrainerTable.SheetTrainerData trainerData) { }

        // TODO
        public void ReloadTrTypeData() { }

        // TODO
        public TrainerTable.SheetTrainerType GetTrTypeData() { return null; }

        // TODO
        public TrainerTable.SheetTrainerData GetTrainerData() { return null; }

        // TODO
        public TowerTrainerTable.SheetTrainerData GetInstTrainerData() { return null; }

        // TODO
        public void SetUseItem(ushort[] items) { }

        // TODO
        public void SetNameLabel(string name_label) { }

        // TODO
        public void SetTrTypeNameLabel(string trtype_name_label) { }

        private class CORE_DATA
        {
            public TrainerID tr_id;
            public TrainerType tr_type;
            public TrainerTable.SheetTrainerType tr_type_data;
            public TrainerTable.SheetTrainerData trainer_data;
            public TowerTrainerTable.SheetTrainerData inst_trainer_data;
            public BattleSetupEffectId btl_eff_id;
            public TrainerTypeGroup tr_group;
            public Sex tr_sex;
            public string model_id;
            public int color_id;
            public uint ai_bit;
            public byte gold;
            public ushort[] use_item = new ushort[USE_ITEM_MAX];
            public string trtype_name_label;
            public string name_label;
        }
    }
}