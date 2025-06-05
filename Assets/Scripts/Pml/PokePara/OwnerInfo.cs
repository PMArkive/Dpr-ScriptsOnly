using DPData;

namespace Pml.PokePara
{
    public class OwnerInfo
    {
        public uint trainerId;
        public byte sex;
        public byte langID;
        public string name;

        public OwnerInfo()
        {
            trainerId = 0;
            sex = 0;
            langID = 0;
            name = "";
        }

        public OwnerInfo(in MYSTATUS ownerStatus)
        {
            trainerId = ownerStatus.id;
            sex = ownerStatus.sex ? (byte)0 : (byte)1;
            langID = ownerStatus.region_code;
            name = ownerStatus.name;
        }

        public void CopyFrom(OwnerInfo src)
        {
            trainerId = src.trainerId;
            sex = src.sex;
            langID = src.langID;
            name = src.name;
        }
    }
}