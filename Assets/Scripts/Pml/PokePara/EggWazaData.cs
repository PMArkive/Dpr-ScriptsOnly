using Pml.Personal;
using XLSXContent;

namespace Pml.PokePara
{
    public sealed class EggWazaData
    {
        public const uint MAX_EGG_WAZA_NUM = 31;
        private bool m_isLoaded;
        private TamagoWazaTable.SheetData m_buffer;

        public EggWazaData()
        {
            m_buffer = null;
            m_isLoaded = false;
        }

        public void Load(MonsNo monsno, ushort formno)
        {
            var dataID = GetDataID(monsno, formno);
            m_buffer = PmlUse.Instance.TamagoWazaTable.Data[dataID];
            m_isLoaded = true;
        }

        public uint GetEggWazaNum()
        {
            if (m_isLoaded)
                return (uint)m_buffer.wazaNo.Length;
            else
                return 0;
        }

        public WazaNo GetEggWazaNo(uint eggWazaIndex)
        {
            if (m_isLoaded)
            {
                if (eggWazaIndex < MAX_EGG_WAZA_NUM && eggWazaIndex < GetEggWazaNum())
                    return (WazaNo)m_buffer.wazaNo[eggWazaIndex];

                GFL.ASSERT(false);
            }

            return WazaNo.NULL;
        }

        // There was A LOT of simplification done here because all of the called methods were inlined
        public bool IsContain(WazaNo wazano)
        {
            for (uint i=0; i<GetEggWazaNum(); i++)
            {
                if (GetEggWazaNo(i) == wazano)
                    return true;
            }

            return false;
        }

        private static uint GetDataID(MonsNo monsno, ushort formno)
        {
            if (PersonalSystem.GetMonsLabel(monsno) == 0)
                return 0;

            if (formno == 0)
                return (uint)monsno;

            var table = PmlUse.Instance.TamagoWazaTable.Data;
            if (table.Length <= (int)MonsNo.END + 1)
                return 0;

            for (uint i=(uint)MonsNo.END + 1; i<table.Length; i++)
            {
                var data = table[i];
                if (data.no == (ushort)monsno && data.formNo == formno)
                    return i;
            }

            return 0;
        }
    }
}