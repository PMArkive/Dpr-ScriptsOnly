using Audio;
using Dpr.Battle.Logic;
using Pml;
using UnityEngine;

namespace Dpr.Field
{
    public static class SwayGrass
    {
        public const uint MAX_RENSA_COUNT = 99999999;
        private const int SWAY_GRASS_MAX = 4;
        private const int SWAY_GRASS_SEARCH_SIZE = 9;
        private static bool is_swaygrass_flag = false;
        private static ZoneID swayZone;
        private static GrassData[] grass_data = new GrassData[SWAY_GRASS_MAX];
        private static AudioInstance[] _grassAudio = new AudioInstance[SWAY_GRASS_MAX];
        public static GrassData work_data = new GrassData();
        public static uint rensa_count = 0;
        public static MonsNo rensa_mons;
        public static uint rensa_lv;
        public static bool BattleEndRensaStart = false;
        public static GameObject RootGrass = null;
        public const int POKETORE_CHARGE_MAX = 50;
        public static bool _callSwayBGM = false;
        public static bool _callStopSwayBGM = false;
        public const int LOT_NO_GRASS = 0;
        public const int LOT_FAIL = 1;
        public const int LOT_OK = 2;

        // TODO
        public static void SwayGrass_InitSwayGrass() { }

        // TODO
        public static void StopSE() { }

        // TODO
        public static bool SwayGrass_CheckSpEncount(ref FieldEncount.SWAY_ENC_INFO info, ref Vector3 pos, float size) { return false; }

        public static bool SwayGrass_CheckValid()
        {
            return is_swaygrass_flag;
        }

        // TODO
        public static int CheckSwayGrass(ref Vector3 pos, float size) { return 0; }

        // TODO
        private static bool GetChainFlg(int inRound, BtlResult inBattleResult) { return false; }

        // TODO
        public static void SwayGrass_ChargePokeSearcher(byte diff) { }

        // TODO
        public static int LotSwayGrass(ref Vector2Int grid, float height) { return 0; }

        // TODO
        private static void OnAudioInstanceFinished(AudioInstance instance) { }

        // TODO
        public static bool SwayZone() { return false; }

        // TODO
        public static void Update(float deltatime) { }

        // TODO
        private static void PlayEffect(float deltatime, int i) { }

        // TODO
        public static int RensaNum(uint rensa, bool omamori = false) { return 0; }

        // TODO
        public static void BtlResultRensa(BtlResult result) { }

        // TODO
        public static byte RensaTalent() { return 0; }

        public class GrassData
        {
            public bool enable;
            public float effectTime;
            public bool rensaMons;
            public int rank;
            public int random_iro;
            public int random_kakure;
            public Vector3 position;
            public int attricode = -1;
            public GameObject transObject;
        }
    }
}