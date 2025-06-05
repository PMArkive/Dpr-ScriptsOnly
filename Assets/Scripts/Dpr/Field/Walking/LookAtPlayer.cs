using System.Collections;

namespace Dpr.Field.Walking
{
    public class LookAtPlayer : ActionModel
    {
        private float duration;
        private float speed;

        public LookAtPlayer(float duration, float speed = 5.0f)
        {
            this.duration = duration;
            this.speed = speed;
        }

        // TODO
        public override IEnumerator DoAction(AIModel model) { return null; }
    }
}