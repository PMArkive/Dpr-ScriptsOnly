using XLSXContent;

namespace Pml.Item
{
    public class UgItemManager
    {
        public static UgItemManager Instance { get; } = new UgItemManager();

        private UgItemTable m_ugItemTable;
        private TamaTable m_tamaTable;
        private PedestalTable m_pedestalTable;
        private StoneStatuEeffect m_stoneStatuEeffect;

        public int UgItemTotal { get => m_ugItemTable.table.Length; }

        public void Initialize(UgItemTable ugItemTable, TamaTable tamaTable, PedestalTable pedestalTable, StoneStatuEeffect stoneStatuEeffect)
        {
            m_ugItemTable = ugItemTable;
            m_tamaTable = tamaTable;
            m_pedestalTable = pedestalTable;
            m_stoneStatuEeffect = stoneStatuEeffect;
        }

        // TODO
        public bool IsExclusiveUseUG(int ugItemId) { return false; }

        // TODO
        public int GetItemId(int ugItemId) { return 0; }

        // TODO
        public UgItemTable.Sheettable GetUgItemData(int ugItemId) { return null; }

        // TODO
        public TamaTable.Sheettable GetTamaData(int ugItemId) { return null; }

        // TODO
        public PedestalTable.SheetInfo GetPedestalData(int ugItemId) { return null; }

        // TODO
        public StoneStatuEeffect.Sheettable GetStoneStatuEeffectData(int ugItemId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataFromPedestalId(int pedestalId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataFromTamaId(int tamaId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataStatueId(int statueId) { return null; }

        // TODO
        private UgItemTable.Sheettable GetUgItemDataRaw(int ugItemId) { return null; }

        // TODO
        public int GetNumStatueKInd() { return 0; }

        // TODO
        public bool IsTama(int ugItemId) { return false; }

        // TODO
        public bool IsPedestal(int ugItemId) { return false; }

        // TODO
        public bool IsStatue(int ugItemId) { return false; }
    }
}