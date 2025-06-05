using System;

namespace nn.hid
{
	public struct GesturePoint : IEquatable<GesturePoint>
	{
		public int x;
		public int y;
		
		// TODO
		public override string ToString() { return default; }
		
		public static bool operator ==(GesturePoint lhs, GesturePoint rhs) => lhs.x == rhs.x && lhs.y == rhs.y;

		public static bool operator !=(GesturePoint lhs, GesturePoint rhs) => lhs.x != rhs.x || lhs.y != rhs.y;

        // TODO
        public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(GesturePoint other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}