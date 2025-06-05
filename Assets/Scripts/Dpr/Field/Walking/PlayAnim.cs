using System.Collections;

namespace Dpr.Field.Walking
{
    public class PlayAnim : ActionModel
    {
        private int anim;
        private float duration;
        private float startTime;

        public PlayAnim(int anim, float duration = 0.2f, float startTime = 0.0f)
        {
            this.anim = anim;
            this.duration = duration;
            this.startTime = startTime;
        }

        public override IEnumerator DoAction(AIModel model)
        {
            var sub = model.view.AnimPlayForce(anim, model.AI.GetNowState().corSys, model.charaModel, duration, startTime);
            yield return sub.Play(model.charaModel.WaitforAnimationFinish(() => sub.isPlaying));
        }
    }
}