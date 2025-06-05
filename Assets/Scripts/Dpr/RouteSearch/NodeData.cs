using UnityEngine;

namespace Dpr.RouteSearch
{
    public class NodeData
    {
        public Node[] Nodes { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int[] AttributeCache;
        public Vector2Int[] AddCantEntryObjectsPositions;
        
        public Vector2Int GridOrigin { get; set; }
        public float PosY { get; set; }
        public ObjectType CharacterType { get; set; }

        // TODO
        public void Initialize(int width, int height) { }

        // TODO
        public Node GetNode(Vector2Int id) { return null; }

        // TODO
        public Node GetNode(int x, int y) { return null; }

        // TODO
        public bool CheckValidId(Vector2Int id) { return false; }

        // TODO
        public bool CheckValidId(int x, int y) { return false; }

        // TODO
        public void SetupNodesAndSetGoal(in Vector2Int goal) { }
    }
}