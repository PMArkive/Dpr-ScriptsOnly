using DG.Tweening;
using System;
using UnityEngine;

namespace Dpr.Battle.View
{
    public static class Mathe
    {
        public static int Rewind(in int value, in int min, in int max)
        {
            if (value < min)
                return max;
            else if (value > max)
                return min;
            else
                return value;
        }
        
        public static float FrameToSecond(in int frame)
        {
            return FrameToSecond(frame, Application.targetFrameRate);
        }
        
        public static float FrameToSecond(in int frame, in int fps = 30)
        {
            return 1.0f / fps * frame;
        }
        
        public static int SecondToFrame(in float time)
        {
            return SecondToFrame(time, Application.targetFrameRate);
        }
        
        public static int SecondToFrame(in float time, in int fps = 30)
        {
            return (int)Math.Round(time / ((float)1.0f / fps));
        }
        
        public static bool Limit(in int value, in int limit)
        {
            return limit < value;
        }
        
        public static float Inverse(float val)
        {
            return -val;
        }
        
        public static int Inverse(int val)
        {
            return -val;
        }
        
        public static Vector3 Inverse(Vector3 vec)
        {
            vec.x = -vec.x;
            vec.y = -vec.y;
            vec.z = -vec.z;
            return vec;
        }
        
        public static void SinCosRad(ref float sin, ref float cos, in float radian)
        {
            sin = (float)Math.Sin(radian);
            cos = (float)Math.Cos(radian);
        }
        
        public static void SinCosDeg(ref float sin, ref float cos, in float degree)
        {
            sin = (float)Math.Sin(DegreeToRadian(degree));
            cos = (float)Math.Cos(DegreeToRadian(degree));
        }
        
        public static float SinDeg(in float degree)
        {
            return (float)Math.Sin(DegreeToRadian(degree));
        }
        
        public static float DegreeToRadian(in float degree)
        {
            return degree * 0.01745329f;
        }
        
        public static float Atan2(in float y, in float x)
        {
            return (float)Math.Atan2(y, x);
        }
        
        public static float Atan2Deg(in float y, in float x)
        {
            return (float)Math.Atan2(y, x) * 57.29578f;
        }
        
        public static float Length(in float x, in float y)
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        
        public static float Rate(in int value)
        {
            return value * 0.01f;
        }
        
        public static Vector3 Offset(in Vector3 from, in Vector3 to)
        {
            return new Vector3(from.x - to.x, from.y - to.y, from.z - to.z);
        }
        
        public static Vector3 VectorMulPerElem(in Vector3 vec1, in Vector3 vec2)
        {
            return new Vector3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
        }
        
        public static Vector4 VectorMulPerElem(in Vector4 vec1, in Vector4 vec2)
        {
            return new Vector4(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z, vec1.w * vec2.w);
        }
        
        public static float CM2M(in float val)
        {
            return val * 0.01f;
        }
        
        public static Vector3 CM2M(in Vector3 vec)
        {
            return new Vector3(CM2M(vec.x), CM2M(vec.y), CM2M(vec.z));
        }
        
        public static Vector3 M2CM(in Vector3 vec)
        {
            return new Vector3(vec.x * 100.0f, vec.y * 100.0f, vec.z * 100.0f);
        }
        
        public static Vector3 CoordinateAdjust(Vector3 vec, bool toSWSH = false)
        {
            var mult = toSWSH ? 100.0f : 0.01f;
            return new Vector3(vec.x * -mult, vec.y * mult, vec.z * mult);
        }
        
        public static Vector3 RotationAdjust(Vector3 vec)
        {
            vec.y = -vec.y;
            return vec;
        }
        
        public static void RotationAdjust360(ref float value)
        {
            var min = value <= 180.0f ? value : value - 360.0f;

            if (value > 180.0f || min < -180.0f)
                value = min > -180.0f ? min : min + 360.0f;
        }
        
        public static int Bool2Int(bool value)
        {
            return value ? 1 : 0;
        }
        
        public static bool Int2Bool(int value)
        {
            return value == 1;
        }
        
        public static int Max(in int a, in int b)
        {
            if (a <= b)
                return b;
            else
                return a;
        }
        
        public static float Min(in float a, in float b)
        {
            if (b <= a)
                return b;
            else
                return a;
        }
        
        public static int Min(in int a, in int b)
        {
            if (b <= a)
                return b;
            else
                return a;
        }
        
        public static float Raito(in int a, in int b)
        {
            return (float)a / b;
        }
        
        public static float Raito(in float mn, in float mx, in float nw)
        {
            return (nw - mn) / (mx - mn);
        }
        
        public static int ClampMin(in int val, in int min = 0)
        {
            if (min <= val)
                return val;
            else
                return min;
        }
        
        public static float ClampMin(in float val, in float min = 0.0f)
        {
            if (min <= val)
                return val;
            else
                return min;
        }
        
        public static void SetVectorSelectElem(ref Vector3 retVec, ref Vector3 vec, in bool[] enableFlags)
        {
            if (enableFlags[0])
                retVec.x = vec.x;

            if (enableFlags[1])
                retVec.y = vec.y;

            if (enableFlags[2])
                retVec.z = vec.z;
        }
        
        public static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static class Easing
        {
            public static Vector4 EasedValue(Vector4 from, Vector4 to, float raito, Ease easingType)
            {
                return new Vector4(EasedValue(from.x, to.x, raito, easingType),
                                   EasedValue(from.y, to.y, raito, easingType),
                                   EasedValue(from.z, to.z, raito, easingType),
                                   EasedValue(from.w, to.w, raito, easingType));
            }
            
            public static float EasedValue(float from, float to, float raito, Ease easingType)
            {
                return DOVirtual.EasedValue(from, to, raito, easingType);
            }
        }

        public static class Btlv
        {
            public static void RotRad(ref float x, ref float z, in float rad)
            {
                var inX = x;
                var inZ = z;

                float sin = (float)Math.Sin(rad);
                float cos = (float)Math.Cos(rad);

                x = inX * cos - inZ * sin;
                z = inX * sin + inZ * cos;
            }
            
            public static void RotDeg(ref float x, ref float z, in float deg)
            {
                var inX = x;
                var inZ = z;

                float sin = (float)Math.Sin(DegreeToRadian(deg));
                float cos = (float)Math.Cos(DegreeToRadian(deg));

                x = inX * cos - inZ * sin;
                z = inX * sin + inZ * cos;
            }
            
            public static void RotDegXZ(ref Vector3 vec, in float deg)
            {
                var inX = vec.x;
                var inZ = vec.z;

                float sin = (float)Math.Sin(DegreeToRadian(deg));
                float cos = (float)Math.Cos(DegreeToRadian(deg));

                vec.x = inX * cos - inZ * sin;
                vec.z = inX * sin + inZ * cos;
            }
            
            public static Vector3 Rotate(in Vector3 origin, in Quaternion rotation)
            {
                // Ignored
                _ = Vector3.zero;

                var rotX = rotation.x;
                var rotY = rotation.y;
                var rotZ = rotation.z;
                var rotW = rotation.w;

                var origX = origin.x;
                var origY = origin.y;
                var origZ = origin.z;

                var a =   origX * rotW - origY * rotZ + origZ * rotY;
                var b =   origX * rotZ + origY * rotW - origZ * rotX;
                var c =   origX * rotX + origY * rotY + origZ * rotZ;
                var d = - origX * rotY + origY * rotX + origZ * rotW;

                var finalX =   rotX * c + rotY * d - rotZ * b + rotW * a;
                var finalY = - rotX * d + rotY * c + rotZ * a + rotW * b;
                var finalZ =   rotX * b - rotY * a + rotZ * c + rotW * d;

                return new Vector3(finalX, finalY, finalZ);
            }
        }
    }
}