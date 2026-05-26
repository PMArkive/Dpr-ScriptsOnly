using SmartPoint.AssetAssistant;
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

        public override IEnumerator DoAction(AIModel model)
        {
            var player = EntityManager.activeFieldPlayer.transform;

            yield return model.Loop(() => duration > 0.0f, () =>
            {
                duration -= Sequencer.elapsedTime;
                model.walkData.LookAtTarget(player.position, Sequencer.elapsedTime, speed);
            });
        }
    }
}