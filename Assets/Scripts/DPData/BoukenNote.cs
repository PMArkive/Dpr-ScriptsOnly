using System;

namespace DPData
{
    [Serializable]
    public struct BoukenNote
    {
        public byte[] VanishNew;

        public BoukenNote(int a)
        {
            VanishNew = new byte[(int)AdventureNoteID.MAX];
        }
    }
}