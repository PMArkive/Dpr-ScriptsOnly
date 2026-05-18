using UnityEngine;

namespace Dpr.Field.Walking
{
	public static class AICommon
	{
		public static Vector3 GetAroundPosition(bool isFureai = false)
		{
			var positions = WalkingAIManager.GetNearEmptyPosition(EntityManager.activeFieldPlayer.gridPosition, false, isFureai);

			if (positions.Count == 0)
				return Vector3.zero;

			var randomEmptyPos = positions.GetRandom();
			var playerPos = EntityManager.activeFieldPlayer.transform.position;

			return playerPos + new Vector3(-randomEmptyPos.x, 5.0f, randomEmptyPos.y);
		}
		
		public static void Warp(AIModel model, bool ignoreSE)
		{
			model.charaModel.walkData.CollidedCount = 0;

            var newPos = GetAroundPosition(model.charaModel.controller.isFureai);

			if (newPos == Vector3.zero)
				return;

			model.charaModel.Warp(newPos);
		}

		public static void WarpImmidiate(AIModel model, bool ignoreSE)
		{
			var playerPos = EntityManager.activeFieldPlayer.gridPosition;
			var positions = WalkingAIManager.GetNearEmptyPosition(EntityManager.activeFieldPlayer.gridPosition, false, false);
			var randomEmptyPos = positions.GetRandom();

			if (randomEmptyPos != null)
				model.charaModel.Enter(EntityManager.activeFieldPlayer.transform.position + new Vector3(-randomEmptyPos.x, 0.0f, randomEmptyPos.y));
			else
				model.charaModel.walkData.CollidedCount = 0;
		}
		
		public static Transform GetTarget(AIModel model)
		{
			if (model.charaModel.LookTarget != null && model.charaModel.walkData.moveVec.magnitude != 0.0f)
				return model.charaModel.LookTarget;
			else
                return EntityManager.activeFieldPlayer.transform;
		}
	}
}