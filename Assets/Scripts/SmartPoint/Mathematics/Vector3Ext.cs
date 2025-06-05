using System;
using UnityEngine;

namespace SmartPoint.Mathematics
{
    public static class Vector3Ext
    {
        public static ref Vector3 FastClear(this ref Vector3 self)
        {
            self.x = 0.0f;
            self.y = 0.0f;
            self.z = 0.0f;

            return ref self;
        }

        public static ref Vector3 FastNegate(this ref Vector3 self)
        {
            self.x = -self.x;
            self.y = -self.y;
            self.z = -self.z;

            return ref self;
        }

        public static ref Vector3 FastReciprocal(this ref Vector3 self)
        {
            self.x = 1.0f / self.x;
            self.y = 1.0f / self.y;
            self.z = 1.0f / self.z;

            return ref self;
        }

        public static ref Vector3 FastSet(this ref Vector3 self, float s)
        {
            self.x = s;
            self.y = s;
            self.z = s;

            return ref self;
        }

        public static ref Vector3 FastSet(this ref Vector3 self, float x, float y, float z)
        {
            self.x = x;
            self.y = y;
            self.z = z;

            return ref self;
        }

        public static ref Vector3 FastAdd(this ref Vector3 self, in Vector3 V)
        {
            self.x += V.x;
            self.y += V.y;
            self.z += V.z;

            return ref self;
        }

        public static ref Vector3 FastScale(this ref Vector3 self, float s)
        {
            self.x *= s;
            self.y *= s;
            self.z *= s;

            return ref self;
        }

        public static ref Vector3 FastMul(this ref Vector3 self, in Vector3 V)
        {
            self.x *= V.x;
            self.y *= V.y;
            self.z *= V.z;

            return ref self;
        }

        public static ref Vector3 FastScaleAdd(this ref Vector3 self, in Vector3 V, float s)
        {
            self.x += V.x * s;
            self.y += V.y * s;
            self.z += V.z * s;

            return ref self;
        }

        public static ref Vector3 FastLerp(this ref Vector3 self, in Vector3 V, float s)
        {
            self.x += (V.x - self.x) * s;
            self.y += (V.y - self.y) * s;
            self.z += (V.z - self.z) * s;

            return ref self;
        }

        public static float FastLengthSq(this in Vector3 self)
        {
            return self.x * self.x + self.y * self.y + self.z * self.z;
        }

        public static float FastDistanceSq(this in Vector3 self, in Vector3 V)
        {
            var vec = new Vector3(self.x - V.x, self.y - V.y, self.z - V.z);
            return vec.FastLengthSq();
        }

        public static float FastLength(this in Vector3 self)
        {
            return (float)Math.Sqrt(self.FastLengthSq());
        }

        public static float FastDot(this in Vector3 self, in Vector3 V)
        {
            return self.x * V.x + self.y * V.y + self.z * V.z;
        }

        public static ref Vector3 FastCross(this ref Vector3 self, in Vector3 V)
        {
            var ax = self.x;
            var ay = self.y;
            var az = self.z;
            var bx = V.x;
            var by = V.y;
            var bz = V.z;

            self.x = ay * bz - az * by;
            self.y = az * bx - bz * ax;
            self.z = by * ax - ay * bx;

            return ref self;
        }

        public static ref Vector3 FastCrossNormalize(this ref Vector3 self, in Vector3 V)
        {
            var crossed = self.FastCross(V);
            return ref self.FastScale(1.0f / crossed.FastLength());
        }

        public static float FastNormalize(this ref Vector3 self)
        {
            var sqmag = self.FastLengthSq();
            if (sqmag < Vector3.kEpsilon)
            {
                self.FastClear();
                return sqmag;
            }
            else
            {
                var mag = (float)Math.Sqrt(sqmag);
                self.FastScale(1.0f / mag);
                return mag;
            }
        }

        public static ref Vector3 FastRotateX(this ref Vector3 self, float angle)
        {
            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);
            var y = self.y;
            var z = self.z;
            self.y = y * cos - z * sin;
            self.z = y * sin + z * cos;

            return ref self;
        }

        public static ref Vector3 FastRotateY(this ref Vector3 self, float angle)
        {
            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);
            var x = self.x;
            var z = self.z;
            self.x = x * cos + z * sin;
            self.z = z * cos - x * sin;

            return ref self;
        }

        public static ref Vector3 FastRotateZ(this ref Vector3 self, float angle)
        {
            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);
            var x = self.x;
            var y = self.y;
            self.x = y * sin + x * cos;
            self.y = y * cos - x * sin;

            return ref self;
        }
    }
}