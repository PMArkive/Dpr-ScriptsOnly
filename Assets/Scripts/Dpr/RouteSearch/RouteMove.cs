using UnityEngine;

namespace Dpr.RouteSearch
{
    public class RouteMove
    {
        private Vector3[] Route;
        private int CurrentRouteIndex;

	    public bool IsBusy { get; set; }
        public float MoveSpeed { get; set; } = 5.0f;

        // TODO
        public void StartRoute(Vector3[] route) { }

        // TODO
        public void SetRoute(Vector3[] route) { }

        // TODO
        public void StartMove() { }

        // TODO
        public void StopMove() { }

        // TODO
        public void Update(float deltaTime, in Vector3 inputPos, out Vector3 outputPos)
        {
            outputPos = Vector3.zero;
        }
    }
}