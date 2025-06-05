using System;

namespace nn.util
{
	public struct Float3 : IEquatable<Float3>
	{
		public float x;
		public float y;
		public float z;
		
		public Float3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		
		// TODO
		public void Set(float x, float y, float z) { }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Float3 lhs, Float3 rhs) { return default; }
		
		// TODO
		public static bool operator !=(Float3 lhs, Float3 rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Float3 other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}