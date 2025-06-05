using System;

namespace nn.irsensor
{
	public struct MomentProcessorConfig : IEquatable<MomentProcessorConfig>
	{
		public IrCameraConfig irCameraConfig;
		public Rect windowOfInterest;
		public MomentProcessorPreprocess preprocess;
		public int preprocessIntensityThreshold;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(MomentProcessorConfig lhs, MomentProcessorConfig rhs) { return default; }
		
		// TODO
		public static bool operator !=(MomentProcessorConfig lhs, MomentProcessorConfig rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(MomentProcessorConfig other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}