using System;
using System.Linq;

namespace DPData
{
    [Serializable]
    public struct PoffinData : IComparable<PoffinData>
    {
        public byte MstID;
        public byte Level;
        public byte Taste;
        public bool IsNew;
        public byte[] Flavor;

        public PoffinData(byte id, byte lv, byte taste, byte[] flavor)
        {
            MstID = id;
            Level = lv;
            Taste = taste;
            IsNew = true;
            Flavor = new byte[5];
            flavor.CopyTo(Flavor, 0);
        }

        public void ToNull()
        {
            MstID = byte.MaxValue;
        }

        public int GetMostFlavorIndex()
        {
            var val = Flavor.Max();
            return Array.FindIndex(Flavor, x => val == x);
        }

        public float GetBONUS()
        {
            return MstID == 29 ? 1.15f : 1.0f;
        }

        public bool IsNull
        {
            get { return MstID == byte.MaxValue || Flavor == null || Flavor.Length == 0; }
        }

        // TODO
        public InterviewWork.PoffineTaste GetPoffineType() { return InterviewWork.PoffineTaste.Kotteri; }

        // TODO
        public int CompareTo(PoffinData other)
        {
            return 0;
        }
    }
}