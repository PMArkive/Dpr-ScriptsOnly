using DPData;
using System.Collections.Generic;

namespace Dpr.SecretBase
{
    public static class SecretBaseSaveDataWork
    {
        public static int RoomGrade { get; set; }
        public static UgStoneStatue[] statues { get; }
        public static bool ViewMode { get; set; } = true;

        public static List<PlacementData> placementData = new List<PlacementData>();

        // TODO
        public static void Clear() { }

        // TODO
        public static void Save() { }

        // TODO
        public static void Replacement(int grade) { }
    }
}