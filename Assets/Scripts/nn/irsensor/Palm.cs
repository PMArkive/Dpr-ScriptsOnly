using nn.util;
using System;

namespace nn.irsensor
{
	public struct Palm : IEquatable<Palm>
	{
		public Float2 center;
		public float area;
		public float depthFactor;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Palm lhs, Palm rhs) { return default; }
		
		// TODO
		public static bool operator !=(Palm lhs, Palm rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Palm other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}