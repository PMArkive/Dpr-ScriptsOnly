using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Dpr.Playables
{
    [Serializable]
    public class BattleAnimationPlayer
    {
        private const int LAYER_NUM = 2;

        [SerializeField]
        protected AnimationLayer _baseLayer = new AnimationLayer();
        [SerializeField]
        protected AnimationLayer _eyeLayer = new AnimationLayer();
        protected List<AnimationLayer> _animationLayers = new List<AnimationLayer>();
        protected Animator _animator;
        protected PlayableGraph _graph;
        protected AnimationPlayableOutput _output;
        protected AnimationLayerMixerPlayable _layerMixer;
        [SerializeField]
        [Range(0.0f, 5.0f)]
        protected float _animationMasterSpeed = 1.0f;

        public void Initialize(Animator animator)
        {
            _animator = animator;
            _graph = PlayableGraph.Create();
            _graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
            _output = AnimationPlayableOutput.Create(_graph, "Animation", _animator);
            _layerMixer = AnimationLayerMixerPlayable.Create(_graph, LAYER_NUM);
            _animationLayers = new List<AnimationLayer>() { _baseLayer, _eyeLayer };

            int layerIndex = 0;
            foreach (var layer in _animationLayers)
            {
                layer.Initialzie(_animator, _graph, layerIndex);
                _layerMixer.ConnectInput(layer.LayerIndex, layer.AnimationMixer, 0);

                if (layer.LayerIndex != 0 && layer.AvatarMask != null)
                {
                    _layerMixer.SetLayerMaskFromAvatarMask((uint)layer.LayerIndex, layer.AvatarMask);
                    _layerMixer.SetLayerAdditive((uint)layer.LayerIndex, layer.Blending == AnimationLayerBlending.Additive);
                }

                _layerMixer.SetInputWeight(layer.LayerIndex, layer.Weight);
                layerIndex++;
            }

            _output.SetSourcePlayable(_layerMixer);
            _graph.Play();
        }

        public void Destroy()
        {
            if (_graph.IsValid())
            {
                _layerMixer.Destroy();
                _graph.Destroy();
            }

            _animator = null;
        }

        public void AdvanaceTime(float deltaTime)
        {
            if (_animator == null)
                return;

            _layerMixer.SetSpeed(_animationMasterSpeed);

            foreach (var layer in _animationLayers)
            {
                if (layer != null)
                {
                    _layerMixer.SetInputWeight(layer.LayerIndex, layer.Weight);
                    layer.OnUpdate(deltaTime);
                }
            }
        }

        public AnimationLayer GetAnimationLayer(LayerIndex layers)
        {
            switch (layers)
            {
                case LayerIndex.BaseLayer:
                    return _baseLayer;

                case LayerIndex.EyeLayer:
                    return _eyeLayer;

                default:
                    return null;
            }
        }

        public void SetAnimSpeed(float animSpeed)
        {
            _animationMasterSpeed = animSpeed;
        }

        public float GetAnimSpeed()
        {
            return _animationMasterSpeed;
        }

        public enum LayerIndex : int
        {
            BaseLayer = 0,
            EyeLayer = 1,
        }
    }
}