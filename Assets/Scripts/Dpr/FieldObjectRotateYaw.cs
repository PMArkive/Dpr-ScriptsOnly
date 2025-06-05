using System;
using UnityEngine;

namespace Dpr
{
    public class FieldObjectRotateYaw
    {
        private WeakReference<FieldObjectEntity> _Entity;
        public FieldFloatMove FloatMove = new FieldFloatMove();
        private float BaseYawAngle;
        private float TargetYawAngle;

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
        }

        public void Update(float deltaTime)
        {
            if (!IsBusy)
                return;

            FloatMove.Update(deltaTime);

            if (Entity != null)
                Entity.yawAngle = Mathf.Lerp(BaseYawAngle, TargetYawAngle, FloatMove.CurrentValue);
        }

        public void Stop()
        {
            FloatMove.Stop();
        }

        public void SetYawAngle(float yawAngle)
        {
            Entity.yawAngle = yawAngle;
        }

        public void MoveTime(float targetYawAngle, float moveTime)
        {
            if (moveTime <= 0.0f)
            {
                Stop();
                SetYawAngle(targetYawAngle);
            }
            else
            {
                TargetYawAngle = targetYawAngle;
                BaseYawAngle = Mathf.DeltaAngle(Entity.yawAngle, targetYawAngle);
                FloatMove.SetValue(0.0f);
                FloatMove.MoveTime(1.0f, moveTime);
            }
        }

        public void MoveSpeed(float targetYawAngle, float moveSpeed)
        {
            MoveTime(targetYawAngle, Mathf.Abs(Mathf.DeltaAngle(Entity.yawAngle, targetYawAngle)) / moveSpeed);
        }
    }
}