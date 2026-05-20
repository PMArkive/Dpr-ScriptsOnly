using SmartPoint.AssetAssistant;
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

        public override IEnumerator DoAction(AIModel model)
        {
            var time = 0.0f;

            if (!model.route.IsNullOrEmpty())
            {
                yield return model.Loop(() => time < duration, () =>
                {
                    var deltaTime = Sequencer.elapsedTime;
                    model.walkData.LookAtTarget(model.route[0], deltaTime, speed);
                    time += deltaTime;
                });
            }
        }
    }
}