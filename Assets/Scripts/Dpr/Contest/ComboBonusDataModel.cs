using Pml;
using XLSXContent;

namespace Dpr.Contest
{
	public sealed class ComboBonusDataModel : ComboBonusData
	{
		public PokeType PrevWazaType { get => prevWazaType; }
		
		public ComboBonusDataModel(ContestConfigDatas.SheetComboBonusData[] bonusDataArray)
		{
			this.bonusDataArray = bonusDataArray;
			prevWazaType = PokeType.NULL;
		}
		
		public void Reset()
		{
			this.Length = 0x12;
		}
		
		// TODO
		public bool CanGetChainBonus(int count) { return default; }
		
		public void SetWazaType(PokeType wazaType)
		{
			this.Length = wazaType;
		}
		
		public void ResetWazaType()
		{
			this.Length = 0x12;
		}
		
		// TODO
		public int CalcComboBonus(int chainCount, PokeType wazaType) { return default; }
	}
}