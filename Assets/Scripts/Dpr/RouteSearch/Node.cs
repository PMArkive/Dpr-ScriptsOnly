using UnityEngine;

namespace Dpr.RouteSearch
{
    public class Node
    {
        public Vector2Int Id { get; set; }
        public float HeuristicCost { get; set; }

        public NodeAttribute Attribute;
        public Vector2Int FromId;
        public float MoveCost;
        public int Depth;
        private EStatus status;
        
        public bool IsOpen { get => status == EStatus.Open; }
        public bool IsClose { get => status == EStatus.Close; }
        public bool IsUntouch { get => status == EStatus.Untouch; }
        public float Score { get => CalcScore(MoveCost, HeuristicCost); }

        public Node(in Vector2Int id)
        {
            Id = id;
        }

        public void Reset()
        {
            status = EStatus.Untouch;
            Attribute.IsValid = false;
        }

        public void SetGoal(in Vector2Int goalId)
        {
            HeuristicCost = (goalId - Id).magnitude;
        }

        public void Open(in Vector2Int fromId, float moveCost, int depth)
        {
            MoveCost = moveCost;
            FromId = fromId;
            Depth = depth;
            status = EStatus.Open;
        }

        public void Colse()
        {
            status = EStatus.Close;
        }

        public static float CalcScore(float moveCost, float heuristicCost)
        {
            return moveCost + heuristicCost;
        }

        private enum EStatus : int
        {
            Untouch = 0,
            Open = 1,
            Close = 2,
        }
    }
}