using System;

namespace nn.util
{
	public struct Float4 : IEquatable<Float4>
	{
		public float x;
		public float y;
		public float z;
		public float w;
		
		public Float4(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		
		// TODO
		public void Set(float x, float y, float z, float w) { }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Float4 lhs, Float4 rhs) { return default; }
		
		// TODO
		public static bool operator !=(Float4 lhs, Float4 rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Float4 other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}