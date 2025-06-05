using UnityEngine;

namespace SmartPoint.Mathematics
{
    public static class Matrix4x4Ext
    {
        public static ref Matrix4x4 FastTranslate(this ref Matrix4x4 self, in Vector3 V)
        {
            self.m03 += V.x;
            self.m13 += V.y;
            self.m23 += V.z;

            return ref self;
        }

        public static ref Matrix4x4 FastTranslateLocal(this ref Matrix4x4 self, in Vector3 V)
        {
            self.m03 += V.x * self.m00 + V.y * self.m01 + V.z * self.m02;
            self.m13 += V.x * self.m10 + V.y * self.m11 + V.z * self.m12;
            self.m23 += V.x * self.m20 + V.y * self.m21 + V.z * self.m22;

            return ref self;
        }

        public static ref Matrix4x4 FastScale(this ref Matrix4x4 self, in Vector3 V)
        {
            self.m00 *= V.x;
            self.m10 *= V.y;
            self.m20 *= V.z;

            self.m01 *= V.x;
            self.m11 *= V.y;
            self.m21 *= V.z;

            self.m02 *= V.x;
            self.m12 *= V.y;
            self.m22 *= V.z;

            self.m03 *= V.x;
            self.m13 *= V.y;
            self.m23 *= V.z;

            return ref self;
        }

        public static ref Matrix4x4 FastScaleLocal(this ref Matrix4x4 self, in Vector3 V)
        {
            self.m00 *= V.x;
            self.m01 *= V.y;
            self.m02 *= V.z;

            self.m10 *= V.x;
            self.m11 *= V.y;
            self.m12 *= V.z;

            self.m20 *= V.x;
            self.m21 *= V.y;
            self.m22 *= V.z;

            self.m30 *= V.x;
            self.m31 *= V.y;
            self.m32 *= V.z;

            return ref self;
        }
    }
}