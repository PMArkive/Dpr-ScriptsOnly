using UnityEngine;

namespace SmartPoint.Components
{
	public static class TransformExtensions
	{
		// TODO
		public static void Track(this Transform transform, float x, float y) { }
		
		// TODO
		public static void Dolly(this Transform transform, float delta) { }
		
		// TODO
		public static void Pan(this Transform transform, float yaw, float pitch) { }
		
		// TODO
		public static void Thumble(this Transform transform, Transform target, float yaw, float pitch) { }
		
		// TODO
		public static void Thumble(this Transform transform, float focalDistance, float yaw, float pitch) { }
		
		// TODO
		private static void Multiply(ref Quaternion inoutQ, ref Quaternion Q) { }
		
		// TODO
		private static void RotationAxis(out Quaternion outQ, ref Vector3 V, float Angle)
		{
			outQ = default;
		}
		
		// TODO
		private static void RotateY(ref Quaternion inoutQ, float Angle) { }
	}
}