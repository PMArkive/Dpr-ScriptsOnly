using SmartPoint.AssetAssistant;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public class FureaiDebugViewManager : SequenceMonoBehaviour
    {
        [SerializeField]
        private Font font;
        [SerializeField]
        private PokeWalkManager pokeWalkMng;
        private bool isVisible;
        private List<FureaiDebugView> debugViewList = new List<FureaiDebugView>();

        private List<FureaiPokeModel> models { get => pokeWalkMng.GetPokeWalkers(); }

        private void Awake()
        {
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition += Vector2.left * 200.0f;
        }

        public void AddDebugView(FureaiPokeModel model)
        {
            // Empty
        }

        protected override void OnUpdate(float deltaTime)
        {
            // Empty
        }
    }
}