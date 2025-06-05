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
		
		// TODO
		public void Reset() { }
		
		// TODO
		public bool CanGetChainBonus(int count) { return default; }
		
		// TODO
		public void SetWazaType(PokeType wazaType) { }
		
		// TODO
		public void ResetWazaType() { }
		
		// TODO
		public int CalcComboBonus(int chainCount, PokeType wazaType) { return default; }
	}
}