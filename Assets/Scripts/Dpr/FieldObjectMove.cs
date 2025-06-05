using System;
using UnityEngine;

namespace Dpr
{
    public class FieldObjectMove
    {
        public bool IgnoreY;
        public float JumpHeight;
        private WeakReference<FieldObjectEntity> _Entity;
        public FieldFloatMove FloatMove = new FieldFloatMove();
        private Vector3 BaseWldPos;
        private Vector3 TargetWldPos;

        public bool IsBusy { get => FloatMove.TargetTime > 0.0f; }
        private FieldObjectEntity Entity
        {
            set => _Entity = new WeakReference<FieldObjectEntity>(value);
            get
            {
                if (!_Entity.TryGetTarget(out FieldObjectEntity entity))
                    return null;

                return entity;
            }
        }

        public void SetObjectEntity(FieldObjectEntity entity)
        {
            Entity = entity;
        }

        public void Reset()
        {
            Stop();
            Entity = null;
            IgnoreY = false;
            JumpHeight = 0.0f;
        }

        public void Update(float deltaTime)
        {
            if (!IsBusy)
                return;

            FloatMove.Update(deltaTime);

            if (Entity != null)
            {
                Vector3 pos = Vector3.Lerp(BaseWldPos, TargetWldPos, FloatMove.CurrentValue);
                float newY = pos.y;
                if (IgnoreY)
                    newY = Entity.worldPosition.y;

                if (JumpHeight > 0.0f)
                    newY += Mathf.Sin(FloatMove.CurrentValue * Mathf.PI) * JumpHeight;

                Entity.worldPosition = pos;
                Entity.worldPosition.y = newY;
            }
        }

        public void Stop()
        {
            FloatMove.Stop();
        }

        public void SetWorldPos(Vector3 wldPos)
        {
            Entity.worldPosition = wldPos;
        }

        public void MoveTime(Vector3 targetWldPos, float moveTime)
        {
            if (moveTime <= 0.0f)
            {
                Stop();
                SetWorldPos(targetWldPos);
            }
            else
            {
                BaseWldPos = Entity.worldPosition;
                TargetWldPos = targetWldPos;
                FloatMove.SetValue(0.0f);
                FloatMove.MoveTime(1.0f, moveTime);
            }
        }

        public void MoveSpeed(Vector3 targetWldPos, float moveSpeed)
        {
            var vec = targetWldPos - Entity.worldPosition;
            if (Entity.isLanding)
                vec.y = 0.0f;

            MoveTime(targetWldPos, vec.magnitude / moveSpeed);
        }
    }
}