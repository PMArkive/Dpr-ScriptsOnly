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
		
		public override bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false)
		{
			Walking_WalkingCollisionModelBase.ObjectCollisionUpdate(deltaTime,isIgnoreJump & 1);
		}
		
		// TODO
		public override void LateUpdate(float deltaTime) { }
	}
}