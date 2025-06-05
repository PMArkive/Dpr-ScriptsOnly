using Dpr.Trainer;
using Pml;
using XLSXContent;

namespace Dpr.Battle.Logic
{
	public class TRAINER_DATA
	{
		public MyStatus playerStatus;
		public TrainerTable.SheetTrainerData trainerData;
		public TowerTrainerTable.SheetTrainerData instTrainerData;
		public string name;
		public string name_label;
		public string trtype_name_label;
		public TrainerID trainerID;
		public TrainerType trainerType;
		public TrainerTypeGroup trainerGroup;
		public Sex trainerSex;
		public byte trainerGold;
		public uint ai_bit;
		public ushort[] useItem = new ushort[BSP_TRAINER_DATA.USE_ITEM_MAX];
		public string modelID;
		public int colorID;
		
		// TODO
		public void Clear() { }
	}
}