using nn.util;
using System;

namespace nn.irsensor
{
	public struct Arm : IEquatable<Arm>
	{
		public bool isValid;
		public Float2 wristPosition;
		public Float2 armDirection;
		public int protrusionIndex;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Arm lhs, Arm rhs) { return default; }
		
		// TODO
		public static bool operator !=(Arm lhs, Arm rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Arm other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}