using nn.util;
using System;

namespace nn.irsensor
{
	public struct Finger : IEquatable<Finger>
	{
		public bool isValid;
		public Float2 tip;
		public float tipDepthFactor;
		public Float2 root;
		public int protrusionIndex;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Finger lhs, Finger rhs) { return default; }
		
		// TODO
		public static bool operator !=(Finger lhs, Finger rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Finger other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}