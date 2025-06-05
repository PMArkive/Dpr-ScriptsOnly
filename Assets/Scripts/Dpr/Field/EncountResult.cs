using Dpr.Trainer;
using Pml.PokePara;
using Pml;

namespace Dpr.Field
{
    public class EncountResult
    {
        public BtlType Type;
        public MonsNo[] Enemy = new MonsNo[2];
        public int[] Level = new int[2];
        public Sex[] FixSex = new Sex[2] { Sex.UNKNOWN, Sex.UNKNOWN };
        public Seikaku[] FixSeikaku = new Seikaku[2] { Seikaku.NUM, Seikaku.NUM };
        public bool IsRare;
        public TrainerID Partner;
        public TokuseiNo HatudouTokusei;
        public ArenaID BattleBG;
        public int MP_SaveIndex = -1;
        public bool IsKakure;
        public int karanaForm;
        public int annoForm;

        public enum BtlType : int
        {
            Single = 0,
            Double = 1,
            Safari = 2,
            MovePoke = 3,
        }
    }
}