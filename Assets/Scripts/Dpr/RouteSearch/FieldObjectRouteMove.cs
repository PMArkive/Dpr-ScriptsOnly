using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.RouteSearch
{
    public class FieldObjectRouteMove
    {
        private readonly FieldObjectEntity Entity;
        private readonly RouteMove RouteMove;

        public ObjectType ObjectType { get; set; }
        public float MoveSpeed { get => RouteMove.MoveSpeed; set => RouteMove.MoveSpeed = value; }
        public float RotateSpeed { get; set; } = 720.0f;
        public bool IsBusy { get; set; }

        private AnimationType CurrentAnimType;
        private Action<RouteMoveResult> OnCompletedEvent;
        private Vector3 LastPos;
        private float StopTime;
        private bool IsRotating;
        private float RotateTarget;
        private static readonly float MovingMinimumRate = 0.2f;
        private static readonly float FailedStopTime = 1.0f;

        public FieldObjectRouteMove(FieldObjectEntity entity)
        {
            Entity = entity;
            RouteMove = new RouteMove();
        }

        // TODO
        public void StartRoute(Vector3 goalPos, [Optional] Action<RouteMoveResult> completedEvent) { }

        // TODO
        public void Stop() { }

        // TODO
        public void Update(float deltaTime) { }

        // TODO
        private void StopCore(RouteMoveResult result) { }

        // TODO
        private void StartRotate(float targetAngle) { }

        // TODO
        private void UpdateRotate(float deltaTime) { }

        // TODO
        private void UpdateAnimation() { }

        // TODO
        private void UpdatePokemonAnimation(AnimationType animType) { }

        // TODO
        private void UpdateCharacterAnimation(AnimationType animType) { }

        // TODO
        private void Complete(RouteMoveResult result) { }

        // TODO
        private static float CalcYawAngle(float x, float z) { return 0.0f; }

        // TODO
        private static float MoveAngle(float baseAngle, float targetAngle, float moveAngle, out bool complete)
        {
            complete = false;
            return 0.0f;
        }

        private enum AnimationType : int
        {
            Invalid = 0,
            Idle = 1,
            Walk = 2,
        }
    }
}