namespace SmartPoint.AssetAssistant.UnityExtensions
{
	public struct FloatBits
	{
		private const float FP_EPSILON = 0.00001f;
		private const int FP_SIGN_SHIFT = 31;
		private const int FP_SIGN_BITS = -2147483648;

		private float fp;
		private int bits;
		private uint ubits;
		
		public FloatBits(float value)
		{
			fp = value;
			bits = 0;
			ubits = 0;
		}
		
		public FloatBits(int value)
		{
			fp = value;
            bits = 0;
            ubits = 0;
        }
		
		public FloatBits(uint value)
		{
            fp = value;
            bits = 0;
            ubits = 0;
        }
		
		// TODO
		public static implicit operator float(FloatBits fpBits) { return default; }

        // TODO
        public static implicit operator FloatBits(float fp) { return default; }

        // TODO
        public static implicit operator FloatBits(int bits) { return default; }

        // TODO
        public static implicit operator FloatBits(uint ubits) { return default; }
		
		// TODO
		public static float ToFloat(int bits) { return default; }
		
		// TODO
		public static float ToFloat(uint bits) { return default; }
		
		// TODO
		public static int ToInt(float value) { return default; }
		
		// TODO
		public static uint ToUInt(float value) { return default; }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public FloatBits Absolute() { return default; }
		
		// TODO
		public bool IsInRange(float low, float high) { return default; }
	}
}