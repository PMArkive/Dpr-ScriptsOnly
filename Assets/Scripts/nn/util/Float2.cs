using System;

namespace nn.util
{
	public struct Float2 : IEquatable<Float2>
	{
		public float x;
		public float y;
		
		public Float2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		
		// TODO
		public void Set(float x, float y) { }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Float2 lhs, Float2 rhs) { return default; }
		
		// TODO
		public static bool operator !=(Float2 lhs, Float2 rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Float2 other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}