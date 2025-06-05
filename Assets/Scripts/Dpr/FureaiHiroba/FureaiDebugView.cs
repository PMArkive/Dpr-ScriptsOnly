using UnityEngine;
using UnityEngine.UI;

namespace Dpr.FureaiHiroba
{
    public class FureaiDebugView : MonoBehaviour
    {
        private Text Text;

        private void Awake()
        {
            Text = gameObject.AddComponent<Text>();
        }

        public void Init(Font font)
        {
            Text.font = font;
            Text.rectTransform.sizeDelta = new Vector2(600.0f, 100.0f);
            Text.fontSize = 18;
        }

        // TODO
        public void MyUpdate(FureaiPokeModel model) { }
    }
}