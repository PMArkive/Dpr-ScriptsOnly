using Dpr.FureaiHiroba;
using System;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field.Walking
{
    [Serializable]
    public class WalkData
    {
        public Transform TrackTarget;
        public Vector3 Offset;
        public Vector3 RotOffset;
        public bool isStopUpdate;
        public float targetDistanceOffset;
        public float awayDistanceOffset;
        public float farDistanceOffset;
        public bool isLinePosition;
        public float offsetScale = 1.0f;
        public float moveSpeed = 1.0f;
        public float MaxSpeed = 1.8f;

        public Transform transform { get => entity.transform; }
        public float targetDistance { get => bodyDistance + 0.5f; }
        public float awayDistance { get => awayDistanceOffset + targetDistance; }
        public float farDistance { get => farDistanceOffset + targetDistance; }
        public float minDistance { get => targetDistance; }
        public Vector3 TargetPosition { get; set; }

        public float distance;
        public float bodySize;
        public float bodyDistance;
        public float TrackTargetBodySize;
        public int order;
        public int priority;
        public int yoyakuPriority;
        public float PositionHosei;
        public float walkHosei;
        public float runHosei;
        public float walkSpeed = 0.4f;
        public float runSpeed = 0.6f;
        public float baseSpeed = 2.5f;
        public float nowSpeed;
        public bool isNeedWalk;
        public bool isNeedRun;
        public bool isNeedRotate;
        public FieldObjectEntity entity;
        public float totalMoveDistance;
        public Vector3 prevMoveVec;

        public float SpeedHosei { get => isNeedRun ? 3.0f : 1.5f; }
        public Vector3 moveVec { get => entity.moveVector; set => entity.moveVector = value; }
        public PokeWalkingActionModel actionModel { get; set; }

        public int CollidedCount;
        public static readonly float[] HeavyPushSpeed = new float[4] { 1.0f, 0.6f, 0.4f, 0.25f, };
        public int WeightRank;
        private float prevAngle;
        private float angleRate;
        private float NearCount;

        public WalkData(FieldObjectEntity entity)
        {
            this.entity = entity;

            if (entity is FieldPokemonEntity)
                (entity as FieldPokemonEntity).EnablePlayInitialIdleAnimation(false);

            WeightRank = 0;
        }

        public void CreateActionModel(PokeWalkingActionNakayoshi.SheetSheet1 nakayoshi, PokeWalkingActionSeikaku.SheetSheet1 seikaku)
        {
            PositionHosei = Mathf.Clamp(nakayoshi.PositionHosei + seikaku.PositionHosei, 0.3f, 3.0f);
            walkHosei = nakayoshi.WalkStartDistanceHosei + seikaku.WalkStartDistanceHosei;
            runHosei = nakayoshi.RunStartDistanceHosei + seikaku.RunStartDistanceHosei;
            actionModel = new PokeWalkingActionModel(nakayoshi, seikaku);
        }

        public void Move(float deltaTime, float Accelarate, float BaseSpeed = 2.5f, float otherDistance = 0.0f)
        {
            var dist = otherDistance != 0.0f ? otherDistance : distance - minDistance;
            baseSpeed = BaseSpeed;

            var speed = isNeedRun ? runSpeed : walkSpeed;
            nowSpeed = Mathf.Clamp(deltaTime * Accelarate + nowSpeed, 0.0f, Mathf.Min(dist, speed * BaseSpeed * deltaTime));
            moveVec = transform.TransformDirection(Vector3.forward) * nowSpeed;
        }

        public void NPCMove(float deltaTime, float Accelarate, float BaseSpeed = 1.5f)
        {
            var max = Mathf.Clamp(runSpeed * BaseSpeed, 0.0f, Mathf.Clamp(distance - minDistance, 0.0f, 1.0f) * (distance - minDistance) * 30.0f);
            nowSpeed = Mathf.Clamp(deltaTime * Accelarate + nowSpeed, 0.0f, max);
            moveVec = transform.TransformDirection(Vector3.forward) * (nowSpeed * deltaTime);
        }

        public Vector3 MoveSimple(float deltaTime, float speed)
        {
            moveVec = transform.TransformDirection(Vector3.forward) * deltaTime * speed;
            moveVec = Vector3.ClampMagnitude(moveVec, prevMoveVec.magnitude + deltaTime);
            return moveVec;
        }

        public void MoveSimple2(float deltaTime, float speed)
        {
            moveVec = transform.TransformDirection(Vector3.forward) * deltaTime * speed;
        }

        public void MoveSimple3(float deltaTime, float speed)
        {
            _ = Mathf.Clamp(distance - minDistance, 0.3f, 1.0f);

            moveVec = transform.TransformDirection(Vector3.forward) * deltaTime * speed;
            moveVec = Vector3.ClampMagnitude(moveVec, Mathf.Clamp(prevMoveVec.magnitude + deltaTime, 0.0f, 7.0f));
        }

        public void LookAtTarget(Vector3 target, float deltaTime, float speed)
        {
            var lookRot = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, deltaTime * speed + 0.01f);

            var angle = (lookRot * Quaternion.Inverse(transform.rotation)).eulerAngles.y;
            angle = angle <= 180.0f ? angle : Mathf.Abs(angle - 360.0f);

            isNeedRotate = deltaTime * speed * angle > 0.2f && moveVec.magnitude == 0.0f;
            transform.localEulerAngles = new Vector3(0.0f, transform.localEulerAngles.y, 0.0f);
        }

        public float GetAngle(Vector3 target)
        {
            var angle = (Quaternion.LookRotation(target - transform.position) * Quaternion.Inverse(transform.rotation)).eulerAngles.y;
            return angle <= 180.0f ? angle : angle - 360.0f;
        }

        public Vector3 AngleToVector3(float Angle)
        {
            return new Vector3(Mathf.Sin(Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(Angle * Mathf.Deg2Rad));
        }

        public void Update(float deltaTime)
        {
            bodyDistance = bodySize + TrackTargetBodySize;

            UpdateFormation(deltaTime);
            UpdateDistance();
            NeedWalkCheck();
            NeedRunCheck(deltaTime);
        }

        public void UpdateDistance()
        {
            distance = Vector3.Distance(new Vector3(transform.position.x, 0.0f, transform.position.z), new Vector3(TargetPosition.x, 0.0f, TargetPosition.z));
        }

        public void UpdateFormation(float deltaTime)
        {
            if (TrackTarget == null)
                return;

            if (!isLinePosition)
                TargetPosition = TrackTarget.position;
            else
                TargetPosition = TrackTarget.position + (GetRotateOffset(TrackTarget.eulerAngles.y, deltaTime) * offsetScale);
        }

        public Vector3 GetRotateOffset(float angle, float deltaTime)
        {
            prevAngle = Mathf.LerpAngle(prevAngle, angle, deltaTime);
            RotOffset = Quaternion.Euler(0.0f, prevAngle, 0.0f) * Offset * bodySize;
            return RotOffset;
        }

        public bool IsNear()
        {
            return distance - minDistance <= 0.01f;
        }

        public bool IsAwayTargetPos()
        {
            return distance > GetAwayDistance();
        }

        public bool IsAwayTrackTarget()
        {
            if (TrackTarget == null || transform == null)
                return false;

            return Vector3.Distance(TrackTarget.position + RotOffset * offsetScale, transform.position) > GetAwayDistance();
        }

        public bool IsFar()
        {
            return distance > GetFarDistance();
        }

        public bool IsFarTrackTarget()
        {
            return Vector3.Distance(TrackTarget.position, transform.position) > GetFarDistance();
        }

        public void NeedWalkCheck()
        {
            if (!isNeedWalk)
            {
                if (IsAwayTrackTarget())
                    isNeedWalk = true;
            }
            else
            {
                if (IsNear())
                    isNeedWalk = false;
            }
        }

        public void NeedRunCheck(float deltaTime)
        {
            if (IsFar())
            {
                isNeedRun = true;
                NearCount = 0.0f;
            }
            else if (IsNear())
            {
                NearCount += deltaTime;
                if (NearCount > 0.3f && EntityManager.activeFieldPlayer.moveVector == Vector3.zero)
                    isNeedRun = false;
            }
        }

        public void SetTargetPos(Vector3 pos)
        {
            TargetPosition = pos;
        }

        public float GetAwayDistance()
        {
            return offsetScale * awayDistance;
        }

        public float GetFarDistance()
        {
            return offsetScale * farDistance;
        }
    }
}