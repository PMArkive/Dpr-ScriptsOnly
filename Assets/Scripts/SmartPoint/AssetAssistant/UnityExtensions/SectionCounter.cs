using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class SectionCounter
    {
        public float startTime { get; set; }
        public float lastTime { get; set; }
        public int count { get; set; }
        public float minTime { get; set; }
        public float maxTime { get; set; }
        public float averageTime { get; set; }
        private float nestedCount { get; set; }

        private static Dictionary<object, SectionCounter> _sections = new Dictionary<object, SectionCounter>();

        [AssetAssistantInitializeMethod]
        private static void Initialize()
        {
            // Empty
        }

        public static void Start(object key)
        {
            if (!_sections.TryGetValue(key, out SectionCounter section))
            {
                section = new SectionCounter();
                section.nestedCount = 0.0f;
                _sections.Add(key, section);
            }

            section.nestedCount += 1.0f;

            if (section.nestedCount == 1.0f)
                section.startTime = Time.realtimeSinceStartup;
        }

        public static SectionCounter End(object key)
        {
            if (!_sections.TryGetValue(key, out SectionCounter section))
                return null;

            section.nestedCount -= 1.0f;

            if (section.nestedCount > 0.0f)
                return null;

            var time = Time.realtimeSinceStartup;

            if (!float.IsNaN(section.startTime))
            {
                float lastTime = time - section.startTime;

                section.startTime = float.NaN;
                section.lastTime = lastTime;

                section.minTime = Mathf.Min(section.minTime, lastTime);
                section.maxTime = Mathf.Max(section.maxTime, lastTime);

                section.count++;

                section.averageTime = (lastTime + section.averageTime * section.count) / section.count;
            }

            return section;
        }
    }
}