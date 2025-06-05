using System;

namespace nn.hid
{
	public struct TouchState : IEquatable<TouchState>
	{
		public long deltaTimeNanoSeconds;
		public TouchAttribute attributes;
		public int fingerId;
		public int x;
		public int y;
		public int diameterX;
		public int diameterY;
		public int rotationAngle;
		private int _reserved;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(TouchState lhs, TouchState rhs) { return default; }
		
		// TODO
		public static bool operator !=(TouchState lhs, TouchState rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(TouchState other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}