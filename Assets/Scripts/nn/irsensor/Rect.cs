using System;

namespace nn.irsensor
{
	public struct Rect : IEquatable<Rect>
	{
		public short x;
		public short y;
		public short width;
		public short height;
		
		public Rect(short x, short y, short width, short height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Rect lhs, Rect rhs) { return default; }
		
		// TODO
		public static bool operator !=(Rect lhs, Rect rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Rect other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}