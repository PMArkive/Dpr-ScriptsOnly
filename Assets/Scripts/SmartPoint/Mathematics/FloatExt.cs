namespace SmartPoint.Mathematics
{
    public static class FloatExt
    {
        public static ref float NormalizeRadians(this ref float self)
        {
            var round = self >= 0.0f ? 0.5f : -0.5f;
            self += ((int)(self * 0.1591549f + round)) * -6.283185f;
            return ref self;
        }

        public static ref float NormalizeDegrees(this ref float self)
        {
            var round = self >= 0.0f ? 0.5f : -0.5f;
            self += ((int)(self * 0.002777778f + round)) * -360.0f;
            return ref self;
        }

        public static float LerpDegrees(float a1, float a2, float s)
        {
            float diff = a2 - a1;
            return diff.NormalizeDegrees() * s + a1;
        }
    }
}