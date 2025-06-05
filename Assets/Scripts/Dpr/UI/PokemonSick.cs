using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Dpr.Battle.Logic;
using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class PokemonSick : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private Image _image;
        private TweenerCore<float, float, FloatOptions> _fadeTw;
        private const int _sickPoizon = 6;
        private const int _sickDying = 7;
        private static string[] _spriteNames = new string[8] // Index 0 is never set?
        {
            null,                     "cmn_ico_txt_sick_01_01", "cmn_ico_txt_sick_01_02", "cmn_ico_txt_sick_01_03",
            "cmn_ico_txt_sick_01_04", "cmn_ico_txt_sick_01_05", "cmn_ico_txt_sick_01_06", "cmn_ico_txt_sick_01_07",
        };
        private int _sick;

        public int sick { get => _sick; }

        // TODO
        public void Setup(PokemonParam pokemonParam) { }

        // TODO
        public void Setup(BTL_POKEPARAM btlParam) { }

        // TODO
        public void Setup(int sick) { }
    }
}