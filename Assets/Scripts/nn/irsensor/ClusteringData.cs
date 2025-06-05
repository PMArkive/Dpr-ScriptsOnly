using nn.util;
using System;

namespace nn.irsensor
{
	public struct ClusteringData : IEquatable<ClusteringData>
	{
		public float averageIntensity;
		public Float2 centroid;
		public int pixelCount;
		public Rect bound;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(ClusteringData lhs, ClusteringData rhs) { return default; }
		
		// TODO
		public static bool operator !=(ClusteringData lhs, ClusteringData rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(ClusteringData other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}