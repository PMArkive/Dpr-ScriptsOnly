using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
	public static class TransformExtensions
	{
		// TODO
		public static Bounds TransformBounds(this Matrix4x4 self, Bounds bounds) { return default; }
		
		// TODO
		public static Bounds InverseTransformBounds(this Transform self, Bounds bounds) { return default; }
		
		// TODO
		public static List<Vector3> GetCorners(this Bounds obj, bool includePosition = true) { return default; }
		
		// TODO
		public static Vector3 Multiply(this Vector3 self, Vector3 other) { return default; }
	}
}