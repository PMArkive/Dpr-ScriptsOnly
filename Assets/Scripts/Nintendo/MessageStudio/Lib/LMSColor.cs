namespace Nintendo.MessageStudio.Lib
{
    public struct LMSColor
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public LMSColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}