namespace Pml.WazaData
{
    public struct SickContParam
    {
        private const int sz0 = 4;
        private const int loc0 = 0;
        private const int mask0 = 15;
        private const int sz1 = 6;
        private const int loc1 = 4;
        private const int mask1 = 1008;
        private const int sz2 = 6;
        private const int loc2 = 10;
        private const int mask2 = 64512;
        public ushort raw;

        // TODO
        public byte type { get; set; }
        public byte turnMin { get; set; }
        public byte turnMax { get; set; }
    }
}