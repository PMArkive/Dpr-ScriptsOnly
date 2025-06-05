using UnityEngine;

namespace Dpr.Field
{
    public static class FieldCalc
    {
        public static float Cross(ref Vector2 a, ref Vector2 b)
        {
            return a.x * b.y - b.x * a.y;
        }

        public static float SubtendedAngle(ref Vector2 lhs, ref Vector2 rhs)
        {
            return Mathf.Acos(Vector2.Dot(lhs.normalized, rhs.normalized)) * 180.0f / Mathf.PI;
        }

        public static float DiffAngle(float angleA, float angleB)
        {
            var angleDelta = angleA - angleB;
            angleDelta = angleDelta >= 0.0f ? angleDelta : angleDelta + 360.0f;
            angleDelta %= 360.0f;

            var reverseAngleDelta = angleDelta - 360.0f;

            if (angleDelta <= 180.0f)
                return angleDelta;
            else
                return reverseAngleDelta;
        }

        public static int LineCross(ref Vector2 start1, ref Vector2 vectol1, ref Vector2 start2, ref Vector2 vectol2, out Vector2 hitPosition)
        {
            hitPosition = Vector2.zero;

            var cross = Cross(ref vectol1, ref vectol2);
            if (cross == 0.0f)
                return 1;

            var startDelta = start2 - start1;
            var cross1 = Cross(ref startDelta, ref vectol1) / cross;
            var cross2 = Cross(ref startDelta, ref vectol2) / cross;

            if (cross1 <= 1.0f && cross1 >= 0.0f && cross2 <= 1.0f && cross2 >= 0.0f)
            {
                hitPosition = start1 + (vectol1 * cross2);
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}