using System;
using UnityEngine;

namespace SmartPoint.Mathematics
{
    public class FastMath
    {
        public static Quaternion RotationAxis(ref Vector3 V, float angle)
        {
            float dist = 1.0f / V.FastLength();

            var vec = new Vector3(V.x * dist, V.y * dist, V.z * dist);
            float sin = Mathf.Sin(0.5f * angle);

            return new Quaternion(vec.x * sin, vec.y * sin, vec.z * sin, Mathf.Cos(0.5f * angle));
        }

        public static Quaternion RotateZLocal(ref Quaternion Q, float Angle)
        {
            var sin = (float)Math.Sin(Angle);
            var cos = (float)Math.Cos(Angle);

            float x = Q.x * cos + Q.y * sin;
            float y = Q.y * cos - Q.x * sin;
            float z = Q.w * sin + Q.z * cos;
            float w = Q.w * cos - Q.z * sin;

            return new Quaternion(x, y, z, w);
        }

        // TODO
        public static Vector3 GetForwardVector(in Quaternion Q) { return Vector3.zero; }

        // TODO
        public static Vector3 GetUpVector(in Quaternion Q) { return Vector3.zero; }

        // TODO
        public static Vector3 GetRightVector(in Quaternion Q) { return Vector3.zero; }

        // TODO
        public static Quaternion LookRotation(in Vector3 forward) { return Quaternion.identity; }

        // TODO
        public static Quaternion LookRotation(in Vector3 forward, in Vector3 up) { return Quaternion.identity; }

        // TODO
        public static float Dot(in Vector2 V1, in Vector2 V2) { return 0.0f; }

        // TODO
        public static float IntersectLine(in Vector2 P1, in Vector2 V1, in Vector2 P2, in Vector2 V2) { return 0.0f; }

        // TODO
        public static float Dot(in Vector3 V1, in Vector3 V2) { return 0.0f; }

        // TODO
        public static Vector3 Cross(in Vector3 V1, in Vector3 V2) { return Vector3.zero; }

        // TODO
        public static Vector3 Normalize(in Vector3 V) { return Vector3.zero; }

        // TODO
        public static Vector3 CrossNormalize(in Vector3 V1, in Vector3 V2) { return Vector3.zero; }

        // TODO
        public static Vector3 CalculateFaceNormal(in Vector3 V1, in Vector3 V2, in Vector3 V3) { return Vector3.zero; }

        // TODO
        public static Vector3 CalculateCentroid(in Vector3 V1, in Vector3 V2, in Vector3 V3) { return Vector3.zero; }

        // TODO
        public static Matrix4x4 Reflection(float a, float b, float c, float d) { return Matrix4x4.zero; }
    }
}
