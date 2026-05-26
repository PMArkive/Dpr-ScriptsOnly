namespace Dpr.Field.Walking
{
	public class NpcCollitionModel : WalkingCollisionModelBase
	{
		public NpcCollitionModel(WalkData walkData) : base(walkData)
		{
			entity.IsIgnorePlayerCollision = true;
		}
		
		public override void CollisionUpdate(float deltaTime)
		{
			if (CheckCollision(EntityManager.activeFieldPlayer, 1.0f, 1.0f, isCheckOnly: true))
			{
				CollidedCount++;

				if (CollidedCount > 0)
				{
					FieldManager.fwMng.ChangePositionNPC();
					CollidedCount = 0;
				}
			}
			else
			{
                CollidedCount = 0;

				var charas = EntityManager.fieldCharacters;
				for (int i=0; i<charas.Length; i++)
					CheckCollision(charas[i], 1.0f, 1.0f);

                var pokes = EntityManager.fieldPokemons;
                for (int i=0; i<pokes.Length; i++)
                    CheckCollision(pokes[i], 1.0f, 1.0f);

                var objs = EntityManager.fieldObjects;
                for (int i=0; i<objs.Length; i++)
                    CheckCollision(objs[i], 1.0f, 1.0f);
            }
		}
		
		public override bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false)
		{
			return ObjectCollisionUpdate(deltaTime, isIgnoreJump);
		}
		
		public override void LateUpdate(float deltaTime)
		{
			// Empty
		}
	}
}