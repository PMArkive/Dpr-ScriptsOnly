namespace Pml.PokePara
{
    public static class Encoder
    {
        public static unsafe ushort CalcChecksum(void* pData, uint dataSize)
        {
            var size = dataSize / 2;
            if (size == 0)
                return 0;

            ushort checksum = 0;
            var shorts = (ushort*)pData;

            for (uint i=0; i<size-1; i+=2)
                checksum += (ushort)(shorts[i] + shorts[i+1]);

            if (size % 2 == 1)
                checksum += shorts[size-1];

            return checksum;
        }

        public static unsafe void Encode(void* pData, uint dataSize, uint key)
        {
            var size = dataSize / 2;
            var shorts = (ushort*)pData;

            for (uint i=0; i<size; i++)
                shorts[i] = CalcNextRandCode(&key);
        }

        public static unsafe void Decode(void* pData, uint dataSize, uint key)
        {
            var size = dataSize / 2;
            var shorts = (ushort*)pData;

            for (uint i = 0; i < size; i++)
                shorts[i] = CalcNextRandCode(&key);
        }

        private static unsafe ushort CalcNextRandCode(uint* code)
        {
            *code = *code * 0x41c64e6d + 0x6073;
            return (ushort)(*code >> 0x10);
        }
    }
}