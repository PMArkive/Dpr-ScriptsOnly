using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Dpr.Playables
{
    [Serializable]
    public class AnimationLayer
    {
        [SerializeField]
        protected int _layerIndex;
        [SerializeField]
        protected AnimationClip[] _clips;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        protected float _weight = 1.0f;
        [SerializeField]
        protected AvatarMask _avatarMask;
        [SerializeField]
        [Tooltip("LayerIndexが1の時は無効")]
        protected AnimationLayerBlending _blending;
        [SerializeField]
        protected float _animationSpeed = 1.0f;
        [SerializeField]
        protected bool _isForceLoop;
        protected int _currentIndex;
        protected int _activePort;
        protected float _increase;
        protected float _blendWeight;
        protected Animator _animator;
        protected AnimationMixerPlayable _animationMixer;
        protected AnimationClipPlayable[] _clipPlayables;

        public int LayerIndex { get => _layerIndex; set => _layerIndex = value; }
        public AnimationClip[] Clips { get => _clips; set => _clips = value; }
        public float Weight { get => _weight; set => Mathf.Clamp01(value); }
        public AvatarMask AvatarMask { get => _avatarMask; set => _avatarMask = value; }
        public AnimationLayerBlending Blending { get => _blending; set => _blending = value; }
        public float AnimationSpeed { get => _animationSpeed; set => _animationSpeed = value; }
        public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }
        public bool IsForceLoop { get => _isForceLoop; set => _isForceLoop = value; }
        public AnimationMixerPlayable AnimationMixer { get => _animationMixer; }
        public AnimationClipPlayable CurrentPlayable { get => (AnimationClipPlayable)_animationMixer.GetInput(_activePort); }
        public float CurrentPlayingTime { get => CurrentPlayable.IsValid() ? (float)CurrentPlayable.GetTime() : 0.0f; }
        public float CurrentRemaingTime { get => CurrentPlayable.IsValid() ? CurrentPlayable.GetAnimationClip().length - (float)CurrentPlayable.GetTime() : 0.0f; }
        public bool IsPlayingEnd { get => CurrentPlayable.IsValid() && CurrentPlayable.GetAnimationClip().length <= (float)CurrentPlayable.GetTime(); }

        public AnimationLayer Initialzie(Animator animator, PlayableGraph graph, int layerIndex = 0)
        {
            _animator = animator;
            _clipPlayables = _clips.Select(x => AnimationClipPlayable.Create(graph, x)).ToArray();
            _blendWeight = 0.0f;
            _animationMixer = AnimationMixerPlayable.Create(graph, 2);
            _activePort = 0;
            _increase = 0.0f;

            if (_layerIndex != layerIndex)
                _layerIndex = layerIndex;

            return this;
        }

        public void Destroy()
        {
            if (_clipPlayables != null)
            {
                for (int i=0; i<_clipPlayables.Length; i++)
                    _clipPlayables[i].Destroy();

                _clipPlayables = null;
            }

            if (_animationMixer.IsValid())
                _animationMixer.Destroy();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_animator == null)
                return;

            _animationMixer.SetSpeed(_animationSpeed);

            if (_increase != 0.0f)
            {
                _blendWeight = _increase * deltaTime + _blendWeight;

                if (_weight >= 1.0f)
                {
                    _animationMixer.SetInputWeight(_activePort, 1.0f);
                    _animationMixer.SetInputWeight(_activePort ^ 1, 0.0f);
                    _animationMixer.DisconnectInput(_activePort ^ 1);
                    _increase = 0.0f;
                }
                else
                {
                    _animationMixer.SetInputWeight(_activePort, _blendWeight);
                    _animationMixer.SetInputWeight(_activePort ^ 1, 1.0f - _blendWeight);
                }
            }

            if (_isForceLoop && IsPlayingEnd)
                CurrentPlayable.SetTime(CurrentPlayable.GetTime() - CurrentPlayable.GetAnimationClip().length);
        }

        public void Play(int index, float duration = 0.0f, float startTime = 0.0f)
        {
            if (!_animationMixer.IsValid() || _clipPlayables.IsNullOrEmpty())
                return;

            if (_clips[index] == null)
                return;

            if (CurrentPlayable.IsValid() &&
                CurrentPlayable.GetAnimationClip() == _clips[index] &&
                (duration != 0.0f || startTime != 0.0f))
                return;

            _currentIndex = index;

            if (duration == 0.0f)
            {
                _animationMixer.DisconnectInput(_activePort);
                _animationMixer.DisconnectInput(_activePort ^ 1);

                _clipPlayables[index].SetTime(startTime);
                _animationMixer.ConnectInput(_activePort, _clipPlayables[_currentIndex], 0, 1.0f);
                _animationMixer.SetInputWeight(_activePort ^ 1, 0.0f);
                _animationMixer.SetInputWeight(_activePort, 1.0f);
            }
            else
            {
                _activePort ^= 1;

                if (_animationMixer.GetInput(_activePort).IsValid())
                {
                    float currentWeight = _animationMixer.GetInputWeight(_activePort);
                    if (currentWeight <= 0.95f &&
                        CurrentPlayable.IsValid() &&
                        CurrentPlayable.GetAnimationClip() == _clips[index])
                    {
                        _increase = 1.0f / duration;
                        _blendWeight = 1.0f - currentWeight;
                        return;
                    }

                    _animationMixer.DisconnectInput(_activePort);
                }

                _clipPlayables[index].SetTime(startTime);
                _animationMixer.ConnectInput(_activePort, _clipPlayables[index], 0, 0.0f);
                _animationMixer.SetInputWeight(_activePort ^ 1, 1.0f);

                _increase = 1.0f / duration;
                _blendWeight = 0.0f;
            }
        }
    }
}