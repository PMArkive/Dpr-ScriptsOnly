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
		
		// TODO
		protected override void StateUpdate() { }
		
		// TODO
		protected void Move(float speed, float otherDist = 0.0f) { }
		
		// TODO
		public bool LookPlayerIfNear(WalkData walkModel) { return default; }
		
		// TODO
		protected bool CheckArrive() { return default; }
		
		// TODO
		protected void LookAtTarget(Vector3 pos, float rotSpeed) { }
		
		// TODO
		protected bool isDontEnterArea(Vector3 NextPos, float addRange = 0.0f) { return default; }
		
		// TODO
		protected Vector3 GetRandomPoint(MoveType moveType) { return default; }
		
		// TODO
		protected bool InSearchArea(Vector3 pos) { return default; }
	}
}