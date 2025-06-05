using System;

namespace nn.account
{
	public struct NetworkServiceAccountId : IEquatable<NetworkServiceAccountId>
	{
		public ulong id;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public bool Equals(NetworkServiceAccountId other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
		
		public static bool operator ==(NetworkServiceAccountId lhs, NetworkServiceAccountId rhs) => lhs.id == rhs.id;
		
		public static bool operator !=(NetworkServiceAccountId lhs, NetworkServiceAccountId rhs) => lhs.id != rhs.id;
    }
}