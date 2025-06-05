namespace Dpr.Field.Walking
{
	public class NpcCollitionModel : WalkingCollisionModelBase
	{
		public NpcCollitionModel(WalkData walkData) : base(walkData)
		{
			entity.IsIgnorePlayerCollision = true;
		}
		
		// TODO
		public override void CollisionUpdate(float deltaTime) { }
		
		// TODO
		public override bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false) { return default; }
		
		// TODO
		public override void LateUpdate(float deltaTime) { }
	}
}