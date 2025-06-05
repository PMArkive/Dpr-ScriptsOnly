using System;

namespace nn.irsensor
{
	public struct IrCameraConfig : IEquatable<IrCameraConfig>
	{
		public long exposureTimeNanoSeconds;
		public IrCameraLightTarget lightTarget;
		public int gain;
		public bool isNegativeImageUsed;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public static bool operator ==(IrCameraConfig lhs, IrCameraConfig rhs) { return default; }
		
		// TODO
		public static bool operator !=(IrCameraConfig lhs, IrCameraConfig rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(IrCameraConfig other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}