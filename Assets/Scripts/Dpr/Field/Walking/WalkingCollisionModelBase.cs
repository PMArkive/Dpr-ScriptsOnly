using Dpr.FureaiHiroba;
using SmartPoint.Mathematics;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public abstract class WalkingCollisionModelBase
    {
        protected WalkData walkData;
        public bool isIgnoreCollision;
        public bool isCollidedAdd;

        protected WalkingCollisionModelBase(WalkData walkData)
        {
            this.walkData = walkData;
            entity.IsIgnorePlayerCollision = true;
        }

        protected float bodySize { get => walkData.bodySize; set => walkData.bodySize = value; }
        protected FieldObjectEntity entity { get => walkData.entity; }
        protected int CollidedCount { get => walkData.CollidedCount; set => walkData.CollidedCount = value; }
        protected Transform transform { get => walkData.transform; }

        public virtual void CollisionUpdate(float deltaTime)
        {
            if (isIgnoreCollision)
                return;

            var player = EntityManager.activeFieldPlayer;
            _ = CheckCollision(EntityManager.activeFieldPlayer, bodySize + 0.5f, 1.0f, isCheckHeight: true);

            var charas = EntityManager.fieldCharacters;
			for (int i=0; i<charas.Length; i++)
            {
                var chara = charas[i];

                if (chara == player)
                    continue;

                CheckCollision(chara, bodySize + 0.5f, 1.0f);
            }

            var pokes = EntityManager.fieldPokemons;
            for (int i=0; i<pokes.Length; i++)
                CheckCollision(pokes[i], bodySize + 0.5f, 1.0f);

            var objs = EntityManager.fieldObjects;
            for (int i=0; i<objs.Length; i++)
            {
                var obj = objs[i];

                if (obj.GetType() == typeof(FieldObjectEntity))
                    CheckCollision(obj, bodySize + 0.5f, 1.0f);
            }
        }

        public virtual void ExCollisionUpdate(float deltaTime, List<FureaiPokeModel> characters)
        {
            // Empty
        }

        public virtual bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false)
        {
            var dist = entity.moveVector.FastNormalize();
            var mask = isIgnoreJump ? Layer.Obstacle : (Layer.Jump | Layer.Obstacle);
            entity.moveVector = CollisionUtility.CollideObstacle(transform.position, 0.4f, entity.moveVector, dist, out _, out bool isCollided, out _, mask);

            return isCollided;
        }

        public void UpdateCollisionCount()
        {
            if (isCollidedAdd)
                CollidedCount++;
            else
                CollidedCount = 0;
        }

        // TODO: Clarify variables
        public bool CheckCollision(FieldObjectEntity target, float radius, float speed, bool CheckWeight = false, bool isCheckOnly = false, int targetPriority = 999, bool isCheckHeight = false)
        {
            if (target == entity)
                return false;

            if (target == null)
                return false;

            if (!target.gameObject.activeInHierarchy)
                return false;

            var player = EntityManager.activeFieldPlayer;
            var isPlayer = target == player;

            if (isCheckHeight && Mathf.Abs(target.worldPosition.y - transform.position.y) > 1.99f)
                return false;

            var diffVec = transform.position - target.worldPosition;
            diffVec.y = 0.0f;

            var dist = diffVec.FastNormalize();

            if (dist > radius + 0.01f)
                return false;

            var direction = walkData.moveVec + (diffVec * Mathf.Clamp(radius - dist, 0.02f, 100.0f));
            var finalDist = direction.FastNormalize();

            var correctedVec = CollisionUtility.CollideObstacle(transform.position, 0.4f, direction, finalDist * speed, out _, out bool isCollided, out _, Layer.Jump | Layer.Obstacle);

            if (!isCheckOnly)
                walkData.moveVec = correctedVec;

            if (correctedVec != Vector3.zero)
                isCollided = true;

            var thisGrid = new Vector2(transform.position.x, transform.position.z);
            var targetGrid = new Vector2(target.transform.position.x, target.transform.position.z);
            var moveGrid = new Vector2(target.moveVector.x, target.moveVector.z);

            var distGrid = Vector2.Distance(thisGrid, targetGrid);
            var moveDistGrid = Vector2.Distance(thisGrid + moveGrid, targetGrid);
            var distPlanned = distGrid + target.moveVector.magnitude * 0.8f;
            var isPlannedDistTooSmall = distPlanned < moveDistGrid;

            if (isPlayer)
            {
                walkData.priority += 10;

                if (distPlanned < moveDistGrid)
                {
                    if (walkData.moveVec.magnitude >= 0.01f)
                        player.moveVector *= WalkData.HeavyPushSpeed[walkData.WeightRank];
                    else
                        player.moveVector = Vector3.zero;
                }

                if (moveDistGrid <= distGrid)
                    return isPlannedDistTooSmall;

                if (walkData.moveVec.magnitude >= 0.01f)
                    return isPlannedDistTooSmall;
            }
            else if (!isCollided)
            {
                return isPlannedDistTooSmall;
            }

            isCollidedAdd = true;
            return isPlannedDistTooSmall;
        }

        public virtual void LateUpdate(float deltaTime)
        {
            // Empty
        }
    }
}