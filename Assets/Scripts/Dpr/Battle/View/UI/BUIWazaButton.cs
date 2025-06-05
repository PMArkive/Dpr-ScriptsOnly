using Dpr.UI;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    public sealed class BUIWazaButton : BUIButtonBase<BUIWazaButton>
    {
        [SerializeField]
        private UIText _ppText;
        [SerializeField]
        private UIText _maxPpText;
        [SerializeField]
        private GameObject _effectiveObj;
        [SerializeField]
        private Image _effectiveBG;
        [SerializeField]
        private Image _effectiveImage;
        [SerializeField]
        private UIText _effectiveText;

	    public BTLV_WAZA_INFO? Info { get; set; }
        public float AnchorY { get => _ppText.transform.position.y; }

        // TODO
        public void Initialize(int index, BTLV_WAZA_INFO? info, [Optional] Sprite typeSprite, [Optional] Sprite effBgSprite, [Optional] Sprite effSprite, [Optional] string affinityString, [Optional] Color[] ppColors) { }

        // TODO
        public void SetTextColor(Color color) { }
    }
}