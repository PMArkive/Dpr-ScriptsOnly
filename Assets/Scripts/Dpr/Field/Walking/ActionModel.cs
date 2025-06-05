using Dpr.SubContents;
using System.Collections;

namespace Dpr.Field.Walking
{
    public abstract class ActionModel : IHaveWeight
    {
        public event EventHandler<int> OnNeedEffect;
        public event Usable usables;

        public float lotteryWeight { get; set; }

        public float priority = 1.0f;
        public float coolTime;
        public float downTime;
        public float elapsedTime;
        public int lotteryType;
        public const int Lottery_Normal = 0;
        public const int Lottery_Force = 1;

        public virtual IEnumerator DoAction(AIModel model)
        {
            yield return null;
        }

        public ActionModel()
        {
            usables = () => true;
            lotteryWeight = 50.0f;
        }

        public bool IsUsable()
        {
            return usables.Invoke();
        }

        public delegate bool Usable();
    }
}