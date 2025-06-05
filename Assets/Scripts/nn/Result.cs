using System;

namespace nn
{
	public struct Result : IEquatable<Result>
	{
		public const int ModuleBitsOffset = 0;
		public const int ModuleBitsCount = 9;
		public const int ModuleBitsMask = 511;
		public const int DescriptionBitsOffset = 9;
		public const int DescriptionBitsCount = 13;
		public const int DescriptionBitsMask = 8191;
		public uint innerValue;
		
		public Result(int module, int description)
		{
			innerValue = (uint)(module | (description << DescriptionBitsOffset));
        }
		
		// TODO
		public bool IsSuccess() { return default; }
		
		// TODO
		public void abortUnlessSuccess() { }
		
		// TODO
		public int GetModule() { return default; }
		
		// TODO
		public int GetDescription() { return default; }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public bool Equals(Result other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
		
		// TODO
		public static bool operator ==(Result lhs, Result rhs) { return default; }
		
		// TODO
		public static bool operator !=(Result lhs, Result rhs) { return default; }
	}
}