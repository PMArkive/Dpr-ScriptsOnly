using Dpr.SubContents;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class UGBaseState : AIStateBase
	{
		protected const int DOOR_DONT_MOVE_RANGE = 5;
		protected const int MOVE_AREA_RANGE = 8;

		protected Vector3 NextMovePoint;
		protected float rotSpeed;
		protected float waitTime;
		protected float changeTargetTime;
		protected int colideStopCount;
		public float searchWait;
		
		protected AIUgModel model { get => base.model as AIUgModel; }
		
		public UGBaseState(AIModel model) : base(model)
		{
            rotSpeed = Random.Range(0.5f, 1.0f);
        }
		
		protected override void StateUpdate()
		{
			if (!model.transform.gameObject.activeInHierarchy)
				return;

			var walkData = model.walkData;
			var collisionCount = model.charaModel.CollidedCount;

			waitTime -= deltaTime;
			changeTargetTime += deltaTime;
            searchWait -= deltaTime;

			var oldChangeTargetTime = changeTargetTime;

			if (searchWait < 0.0f && InSearchArea(EntityManager.activeFieldPlayer.worldPosition))
			{
				model.charaModel.controller.emoticon.Delete();
				model.AI.ChangeState(typeof(UG_FoundState));
			}

			if (NextMovePoint == Vector3.zero)
				NextMovePoint = GetRandomPoint(model.moveType);

			if (CheckArrive())
			{
				changeTargetTime = 0.0f;

                waitTime = Random.Range(1.0f, 8.0f);
				colideStopCount++;

                if (collisionCount < 2)
				{
					NextMovePoint = GetRandomPoint(model.moveType);

                    if (waitTime < 0.0f)
                    {
                        walkData.isNeedRun = false;
                        Move(2.0f);
                    }
					else
					{
                        walkData.nowSpeed = 0.0f;
                    }
                }
                else
				{
					NextMovePoint = model.transform.position - model.transform.forward;
                    walkData.nowSpeed = 0.0f;
                }
            }
            else
			{
				if (oldChangeTargetTime > 10.0f || collisionCount > 1)
				{
					if (oldChangeTargetTime > 10.0f || (collisionCount < 2 && Random.Range(0, 2) != 0))
					{
						if (waitTime < 0.0f)
						{
							rotSpeed = Random.Range(1.0f, 2.0f);
							colideStopCount = 0;
							waitTime = -1.0f;
							changeTargetTime = 0.0f;
							NextMovePoint = GetRandomPoint(model.moveType);
						}

                        if (collisionCount < 2 && waitTime < 0.0f)
                        {
                            walkData.isNeedRun = false;
                            Move(2.0f);
                        }
                        else
                        {
                            walkData.nowSpeed = 0.0f;
                        }
                    }
					else
					{
						waitTime = Random.Range(1.0f, 8.0f);
						colideStopCount++;

                        if (collisionCount < 2)
						{
							NextMovePoint = GetRandomPoint(model.moveType);
							if (waitTime < 0.0f)
							{
                                walkData.isNeedRun = false;
                                Move(2.0f);
                            }
							else
							{
                                walkData.nowSpeed = 0.0f;
                            }
                        }
						else
						{
							NextMovePoint = model.transform.position - model.transform.forward;
                            walkData.nowSpeed = 0.0f;
                        }
                    }
                }
				else
				{
                    if (collisionCount < 2 && waitTime < 0.0f)
                    {
                        walkData.isNeedRun = false;
                        Move(2.0f);                        
                    }
					else
					{
                        walkData.nowSpeed = 0.0f;
                    }
                }
			}

            if (waitTime < 4.0f)
                LookAtTarget(NextMovePoint, rotSpeed);
        }
		
		protected void Move(float speed, float otherDist = 0.0f)
		{
			var walkData = model.walkData;

            walkData.Move(deltaTime, 10.0f, speed, otherDist);

			var finalPos = walkData.entity.transform.position + walkData.entity.moveVector;

            if (isDontEnterArea(finalPos) && !isDontEnterArea(walkData.entity.transform.position))
				walkData.entity.moveVector = Vector3.zero;

			if (Utils.isEnterbleAttribute(finalPos, model.moveType) != Utils.MoveTypeResult.OK)
                walkData.entity.moveVector = Vector3.zero;

            if (!Utils.isNotExistsCollision(finalPos))
                walkData.entity.moveVector = Vector3.zero;
        }
		
		public bool LookPlayerIfNear(WalkData walkModel)
		{
			if (playerDistance >= 4.0f)
				return false;

			if (!model.charaModel.isForceAnimation)
			{
                corSys.Cancel();
                walkModel.LookAtTarget(player.position, deltaTime, rotSpeed);
            }

			return true;
		}
		
		protected bool CheckArrive()
		{
			if (NextMovePoint == Vector3.zero)
				return true;

			return Utils.IsInDistance(model.transform.position, NextMovePoint, 0.4f);
		}
		
		protected void LookAtTarget(Vector3 pos, float rotSpeed)
		{
			model.walkData.LookAtTarget(pos, deltaTime, rotSpeed);
		}
		
		protected bool isDontEnterArea(Vector3 NextPos, float addRange = 0.0f)
		{
			for (int i=0; i<model.entrancePosition.Count; i++)
			{
				if (model.entrancePosition[i] == Vector3.zero)
					continue;

				if (Utils.IsInDistance(model.entrancePosition[i], NextPos, DOOR_DONT_MOVE_RANGE))
					return true;
			}

			if (Utils.IsInDistance(model.InitPos, NextPos, addRange + MOVE_AREA_RANGE))
            {
				var enterable = Utils.isEnterbleAttribute(NextPos, model.moveType);
				return enterable == Utils.MoveTypeResult.CantMoveType || enterable == Utils.MoveTypeResult.CantEnter;
			}

			return true;
		}
		
		protected Vector3 GetRandomPoint(MoveType moveType)
		{
			var amplitude = Random.Range(1, 8);
			var angle = Random.Range(0, 360);

			var vec = Quaternion.Euler(0.0f, angle, 0.0f) * new Vector3(amplitude, 0.0f, 0.0f);
			var targetPos = model.InitPos + vec;

			if (Utils.isEnterbleAttribute(targetPos, moveType) == Utils.MoveTypeResult.OK && Utils.isNotExistsCollision(targetPos))
				return targetPos;
			else
				return Vector3.zero;
		}
		
		protected bool InSearchArea(Vector3 pos)
		{
			if (isDontEnterArea(pos))
				return false;

			if (!Utils.IsInDistance(model.transform.position, pos, 5.0f))
				return false;

			var vec = pos - model.transform.position;

			// Result ignored
			_ = Vector3.Cross(model.transform.forward, vec);

			return Vector3.Angle(model.transform.forward, vec) < 30.0f;
		}
	}
}