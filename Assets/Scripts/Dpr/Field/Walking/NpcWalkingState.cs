using Dpr.SubContents;
using SmartPoint.Components;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class NpcWalkingState : WalkingState
	{
		public NpcWalkingState(AIModel model) : base(model)
		{
			model.charaModel.collisionModel = new NpcCollitionModel(model.charaModel.walkData);
		}
		
		protected override void StateUpdate()
		{
			walkModel.bodySize = 0.05f;
			walkModel.awayDistanceOffset = 0.15f;
			walkModel.farDistanceOffset = 0.15f;
			walkModel.walkSpeed = 5.0f;
			walkModel.runSpeed = 5.0f;

			if (!walkModel.isNeedWalk || Fader.isBusy)
			{
                walkModel.nowSpeed = 0.0f;
            }
			else
			{
				walkModel.NPCMove(deltaTime, 3000.0f);

				if (Utils.isEnterbleAttribute(walkModel.entity.transform.position + walkModel.entity.moveVector, MoveType.FLY) != Utils.MoveTypeResult.OK)
					walkModel.entity.moveVector = Vector3.zero;
			}

			// Result ignored
			_ = AICommon.GetTarget(model);

			walkModel.LookAtTarget(EntityManager.activeFieldPlayer.transform.position, deltaTime, 60.0f);
		}
	}
}