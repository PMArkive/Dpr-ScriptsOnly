using nn.util;
using System;

namespace nn.irsensor
{
	public struct MomentStatistic : IEquatable<MomentStatistic>
	{
		public float averageIntensity;
		public Float2 centroid;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(MomentStatistic lhs, MomentStatistic rhs) { return default; }
		
		// TODO
		public static bool operator !=(MomentStatistic lhs, MomentStatistic rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(MomentStatistic other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}