namespace Pml.PokePara
{
    public struct CoreDataHeader
    {
        public const int SIZE = 8;
        public uint personalRnd;
        public ushort _bitsA;
        public ushort checksum;
        private const int bitsA0_sz = 1;
        private const int bitsA0_loc = 0;
        private const int bitsA1_sz = 1;
        private const int bitsA1_loc = 1;
        private const int bitsA2_sz = 1;
        private const int bitsA2_loc = 2;
        private const int bitsA0_mask = 1;
        private const int bitsA1_mask = 2;
        private const int bitsA2_mask = 4;

        public bool ppFastMode
        {
            get => (_bitsA >> bitsA0_loc & bitsA0_sz) != 0;
            set => _bitsA = (ushort)((_bitsA & ~bitsA0_mask) | (value ? bitsA0_mask : 0));
        }

        public bool pppFastMode
        {
            get => (_bitsA >> bitsA1_loc & bitsA1_sz) != 0;
            set => _bitsA = (ushort)((_bitsA & ~bitsA1_mask) | (value ? bitsA1_mask : 0));
        }

        public bool fuseiTamagoFlag
        {
            get => (_bitsA >> bitsA2_loc & bitsA2_sz) != 0;
            set => _bitsA = (ushort)((_bitsA & ~bitsA2_mask) | (value ? bitsA2_mask : 0));
        }
    }
}