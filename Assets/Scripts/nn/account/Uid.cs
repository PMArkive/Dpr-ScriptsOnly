using System;

namespace nn.account
{
	public struct Uid : IEquatable<Uid>
	{
		public ulong _data0;
		public ulong _data1;
		
		public static Uid Invalid => new Uid() { _data0 = 0, _data1 = 0 };
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public bool Equals(Uid other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
		
		public static bool operator ==(Uid lhs, Uid rhs) => lhs._data0 == rhs._data0 && lhs._data1 == rhs._data1;
		
		public static bool operator !=(Uid lhs, Uid rhs) => lhs._data0 != rhs._data0 || lhs._data1 != rhs._data1;
    }
}