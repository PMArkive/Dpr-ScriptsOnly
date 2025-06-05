namespace Pml.PokePara
{
    public sealed class PokemonParam : CoreParam
    {
        public const int DATASIZE = 344;
        private static byte[] sParamSerializeBuffer = new byte[DATASIZE];

        public PokemonParam()
        {
            CreateAndAttachCalcData();
        }

        public PokemonParam(MonsNo monsno, ushort level, ulong id) : base(monsno, level, id)
        {
            CreateAndAttachCalcData();
            InitCalcData();
        }

        public PokemonParam(InitialSpec spec) : base(spec)
        {
            CreateAndAttachCalcData();
            InitCalcData();
        }

        public PokemonParam(PokemonParam src)
        {
            CreateAndAttachCalcData();
            CopyFrom(src);
        }

        public PokemonParam(CoreParam src)
        {
            CreateAndAttachCalcData();
            CopyFrom(src);
            InitCalcData();
        }

        public void Setup(InitialSpec spec)
        {
            Factory.SetupCoreData(m_coreData, spec);
            InitCoreData();
            InitCalcData();
        }

        public void Serialize_Full(byte[] buffer)
        {
            m_accessor.Serialize_FullData(buffer);
        }

        public override void Serialize_Core(byte[] buffer)
        {
            m_accessor.Serialize_CoreData(buffer);
        }

        public void Deserialize_Full(byte[] serializedData)
        {
            m_accessor.Deserialize_FullData(serializedData);
        }

        public override void Deserialize_Core(byte[] serializedData)
        {
            m_accessor.Deserialize_CoreData(serializedData);
            InitCalcData();
        }

        public void CopyFrom(PokemonParam pSrcParam)
        {
            pSrcParam.Serialize_Full(sParamSerializeBuffer);
            Deserialize_Full(sParamSerializeBuffer);
        }

        public string GetNoparseNickName()
        {
            return "<noparse>" + GetNickName() + "</noparse>";
        }

        public void Dump()
        {
            GFL.ASSERT(false);
        }

        private void CreateAndAttachCalcData()
        {
            m_calcData = Factory.CreateCalcData(GetPersonalRnd());
            m_accessor.AttachEncodedData(m_coreData, m_calcData);
        }

        private void InitCalcData()
        {
            bool validFlag = StartFastMode();

            m_accessor.ClearCalcData();
            UpdateCalcDatas();
            RecoverAll();

            EndFastMode(validFlag);
        }
    }
}