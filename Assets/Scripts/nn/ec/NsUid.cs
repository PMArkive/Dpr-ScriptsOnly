using System;

namespace nn.ec
{
	public struct NsUid : IEquatable<NsUid>
	{
		public ulong value;
		
		public NsUid(ulong _value)
		{
			value = _value;
		}
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static NsUid GetInvalidId() { return default; }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public bool Equals(NsUid other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }

		public static bool operator ==(NsUid lhs, NsUid rhs) => lhs.value == rhs.value;
		
		public static bool operator !=(NsUid lhs, NsUid rhs) => lhs.value != rhs.value;
    }
}