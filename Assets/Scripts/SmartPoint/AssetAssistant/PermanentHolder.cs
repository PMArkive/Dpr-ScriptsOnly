using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class PermanentHolder : MonoBehaviour
    {
        private static PermanentHolder _instance;
        public Object[] _objects;

        private void Awake()
        {
            _instance = this;
        }

        public static Object[] objects { get => _instance._objects; set => _instance._objects = value; }
    }
}