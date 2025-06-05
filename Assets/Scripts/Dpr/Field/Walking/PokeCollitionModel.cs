using Dpr.FureaiHiroba;
using System.Collections.Generic;

namespace Dpr.Field.Walking
{
    public class PokeCollitionModel : WalkingCollisionModelBase
    {
        public PokeCollitionModel(WalkData walkData) : base(walkData)
        {
            // Empty
        }

        public override void CollisionUpdate(float deltaTime)
        {
            // No extra code
            base.CollisionUpdate(deltaTime);
        }

        public override void ExCollisionUpdate(float deltaTime, List<FureaiPokeModel> characters)
        {
            if (characters == null)
                return;

            foreach (var chara in characters)
            {
                if ((!walkData.isNeedWalk && chara.walkData.isNeedWalk) || walkData.priority < chara.walkData.priority)
                    CheckCollision(chara.entity, bodySize + 0.5f, 1.0f, false, false, chara.walkData.priority);
            }
        }
    }
}