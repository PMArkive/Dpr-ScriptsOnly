using Audio;
using Pml.PokePara;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class ZukanMovingWindow : UIWindow
    {
        [SerializeField]
        private PokemonModelView _modelView;
        [SerializeField]
        private ZukanMovingEqualizer _equalizer;
        [SerializeField]
        private ZukanMovingSoundWave _soundWave;
        [SerializeField]
        private ZukanMovingPan _pan;
        [SerializeField]
        private ZukanMovingChorus _chorus;
        [SerializeField]
        private ZukanMovingFilter _filter;
        [SerializeField]
        private RepeatParam _repeat;
        private AudioInstance _voiceInstance;
        private bool _animPaused;
        private Param _param;
        private UIDatabase.SheetPokemonVoice _voiceData;
        public AudioEffectParam _saveAudioEffectParam = new AudioEffectParam();

        // TODO
        public override void OnCreate() { }

        // TODO
        public void Open(Param param, UIWindowID prevWindowId) { }

        // TODO
        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return null; }

        // TODO
        private void SetupKeyguide() { }

        // TODO
        private void SaveAudioEffectParam() { }

        // TODO
        private void RestoreAudioEffectParam() { }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void UpdateVoice(float deltaTime, bool isRepeatChecked = true) { }

        // TODO
        private void PlayVoice() { }

        [Serializable]
        private class RepeatParam
        {
            public Image image;
            public Sprite[] sprites;
            [NonSerialized]
            public float delayTime = float.NegativeInfinity;

            // TODO
            public void Setup() { }

            // TODO
            public void SetRepeat(bool enabled) { }

            // TODO
            public bool isRepeat { get; }
        }

        public class Param
        {
            public PokemonParam pokemonParam;
        }

        public class AudioEffectParam
        {
            public float chorus;
            public float pan;
            public float filter;
            public float reverb;
        }
    }
}