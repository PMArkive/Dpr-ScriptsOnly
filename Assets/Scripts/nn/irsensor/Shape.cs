using nn.util;
using System;

namespace nn.irsensor
{
	public struct Shape : IEquatable<Shape>
	{
		public int firstPointIndex;
		public int pointCount;
		public float intensityAverage;
		public Float2 intensityCentroid;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(Shape lhs, Shape rhs) { return default; }
		
		// TODO
		public static bool operator !=(Shape lhs, Shape rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Shape other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}