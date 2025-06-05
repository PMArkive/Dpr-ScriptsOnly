using UnityEngine;

namespace Dpr.Message
{
    public class MessageStyleColorData
    {
        private const float MAX_VALUE = 255.0f;
        private float r;
        private float g;
        private float b;
        private float a;

        public MessageStyleColorData(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color GetColor()
        {
            return new Color(CalcColorValue(r), CalcColorValue(g), CalcColorValue(b), CalcColorValue(a));
        }

        private float CalcColorValue(float value)
        {
            return value / MAX_VALUE;
        }
    }
}
