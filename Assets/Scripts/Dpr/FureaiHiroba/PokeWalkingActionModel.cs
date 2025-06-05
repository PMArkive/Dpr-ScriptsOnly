using UnityEngine;
using XLSXContent;

namespace Dpr.FureaiHiroba
{
    public sealed class PokeWalkingActionModel : PokeFureaiActionModel
    {
        private float coolTime = 25.0f;
        public bool isNoneActionMember;
        public bool isNoneStrayMember;

        public int StopThreshold { get; set; }
        public int KyoroThreshold { get; set; }

        public PokeWalkingActionModel(PokeWalkingActionNakayoshi.SheetSheet1 nakayoshi, PokeWalkingActionSeikaku.SheetSheet1 seikaku)
        {
            Init();

            StopThreshold = Mathf.Clamp(seikaku.StopKakurituHosei + nakayoshi.StopKakurituHosei, 0, 100);
            KyoroThreshold = StopThreshold + Mathf.Clamp(seikaku.KyoroKakurituHosei + nakayoshi.KyoroKakurituHosei, 0, 100);
        }

        // TODO
        public PokeAction LotteryAction(float deltaTime) { return PokeAction.Kyoro; }

        // TODO
        public PokeAction LotteryPokeAction() { return PokeAction.Kyoro; }

        public enum PokeAction : int
        {
            Kyoro = 0,
            Stop = 1,
            Look = 2,
            ToWalking = 3,
            _None = 4,
        }
    }
}