using Dpr.SubContents;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class WalkingAIManager
    {
        private List<WalkingCharacterController> walkingCharacters = new List<WalkingCharacterController>();
        public bool isAllStop;
        [SerializeField]
        private FieldObjectEntity testEntity;
        [Button("TestAdd", "TestAdd", new object[0])]
        public int Button01;
        [Button("TestSub", "TestSub", new object[0])]
        public int Button02;

        // TODO
        public WalkingCharacterController ToWalkingCharacter(FieldObjectEntity entity) { return null; }

        // TODO
        public virtual void Destroy(bool isDestroyGameObject = false) { }

        // TODO
        public void StopAll(bool isStop) { }

        // TODO
        private WalkingCharacterModel CreateFieldWalkModel(FieldObjectEntity entity) { return null; }

        // TODO
        private WalkingCharacterController CommonSetUp(FieldObjectEntity entity) { return null; }

        protected virtual WalkingCharacterController AddController(GameObject go)
        {
            return go.AddComponent<WalkingCharacterController>();
        }

        // TODO
        public void SubWalkingCharacter(FieldObjectEntity entity, bool isDestroy = false) { }

        // TODO
        public void TestAdd() { }

        public void TestSub()
        {
            if (testEntity != null)
                SubWalkingCharacter(testEntity);
        }

        // TODO
        public static List<Vector2Int> GetNearEmptyPosition(Vector2Int grid, bool ignoreNaname = false, bool isFureai = false) { return null; }
    }
}