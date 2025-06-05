using System.Collections;

namespace Dpr.Field.Walking
{
    public class LookAtNextRoute : ActionModel
    {
        private float speed;
        private float duration;

        public LookAtNextRoute(float speed, float duration)
        {
            this.speed = speed;
            this.duration = duration;
        }

        // TODO
        public override IEnumerator DoAction(AIModel model) { return null; }
    }
}