using nn.util;

namespace nn.hid
{
	public struct SixAxisSensorState
	{
		public const float AccelerometerMax = 7.0f;
		public const float AngularVelocityMax = 5.0f;

		public long deltaTimeNanoSeconds;
		public long samplingNumber;
		public Float3 acceleration;
		public Float3 angularVelocity;
		public Float3 angle;
		public DirectionState direction;
		public SixAxisSensorAttribute attributes;
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public void GetQuaternion(ref float x, ref float y, ref float z, ref float w) { }
		
		// TODO
		public void GetQuaternion(ref Float4 quaternion) { }

		private static extern void GetQuaternion(ref SixAxisSensorState state, ref float pOutX, ref float pOutY, ref float pOutZ, ref float pOutW);
	}
}