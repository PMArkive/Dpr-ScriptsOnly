using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[Serializable]
public class AnimationPlayer
{
    private PlayableGraph _graph;
    private Playable _mixer;
    private AnimationPlayableOutput _output;
    private Animator _animator;
    private AnimationClipPlayable[] _playables;
    private float _increase;
    private float _weight;
    private int _activePort;
    private RuntimeAnimatorController _savedAnimatorController;
    [SerializeField]
    private AnimationClip[] _clips;
    [SerializeField]
    private AvatarMask _avatarMask;
    [SerializeField]
    private AnimationClip _layerClip;
    [SerializeField]
    private AvatarMask _additiveAvatarMask;
    [SerializeField]
    private AnimationClip _additiveLayerClip;

    public AnimationClip[] clips { get => _clips; set => _clips = value; }
    public AvatarMask avatarMask { get => _avatarMask; set => _avatarMask = value; }
    public AnimationClip layerClip { get => _layerClip; set => _layerClip = value; }
    public AvatarMask additiveAvatarMask { get => _additiveAvatarMask; set => _additiveAvatarMask = value; }
    public AnimationClip additiveLayerClip { get => _additiveLayerClip; set => _additiveLayerClip = value; }
    public int currentIndex { get; set; }
    public bool forceLoop { get; set; }
    public bool forcePlay { get; set; }

    private int _additiveLayerIndex = -1;
    private AnimationClipPlayable _layerClipPlayable;
    private AnimationClipPlayable _additiveClipPlayable;
    
    public AnimationClipPlayable currentPlayable
    {
        get
        {
            if (!_mixer.IsValid())
                return default(AnimationClipPlayable);

            return (AnimationClipPlayable)_mixer.GetInput(_activePort);
        }
    }
    public float currentPlayingTime
    {
        get
        {
            if (!IsValidCurrentPlayable)
                return 0.0f;

            return (float)currentPlayable.GetTime();
        }
    }
    public float currentRemaingTime { get => currentPlayable.GetAnimationClip().length - (float)currentPlayingTime; }
    public float layerWeight
    {
        get
        {
            if (!IsValidCurrentPlayable)
                return 0.0f;

            return (float)currentPlayable.GetInputWeight(2);
        }
        set
        {
            if (!_mixer.IsValid())
                return;

            if (_avatarMask != null)
                _mixer.SetInputWeight(2, value);
        }
    }
    public bool IsValidCurrentPlayable { get => currentPlayable.IsValid(); }
    public bool IsPlayingEnd { get => currentPlayable.GetAnimationClip().length <= (float)currentPlayable.GetTime(); }
    public bool IsPlaying { get => _graph.IsValid() && _graph.IsPlaying(); }
    public AnimationClipPlayable layerClipPlayable { get => _layerClipPlayable; }
    public AnimatorCullingMode cullingMode
    {
        get => _animator == null ? AnimatorCullingMode.AlwaysAnimate : _animator.cullingMode;
        set
        {
            if (_animator != null)
                _animator.cullingMode = value;
        }
    }

    public void InitializePlayables(Animator animator)
    {
        Destroy();

        if (animator == null)
            return;

        _graph = PlayableGraph.Create();
        if (!_graph.IsValid())
            return;

        _graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        _animator = animator;
        _increase = 0.0f;
        _weight = 0.0f;
        _activePort = 0;

        if (_avatarMask != null || _additiveAvatarMask != null)
        {
            int maskIndex = _avatarMask == null ? 2 : 3;
            int additiveMaskIndex = _additiveAvatarMask == null ? 0 : 1;
            var mixer = AnimationLayerMixerPlayable.Create(_graph, maskIndex + additiveMaskIndex);

            if (_avatarMask != null)
            {
                _layerClipPlayable = AnimationClipPlayable.Create(_graph, _layerClip);
                mixer.ConnectInput(2, _layerClipPlayable, 0, 1.0f);
                mixer.SetLayerMaskFromAvatarMask(2, _avatarMask);
            }

            if (_additiveAvatarMask != null)
            {
                _additiveClipPlayable = AnimationClipPlayable.Create(_graph, _additiveLayerClip);
                _additiveClipPlayable.SetSpeed(0.0f);
                mixer.ConnectInput(maskIndex, _additiveClipPlayable, 0, 0.0f);
                mixer.SetLayerMaskFromAvatarMask((uint)maskIndex, _additiveAvatarMask);
                mixer.SetLayerAdditive((uint)maskIndex, true);
                _additiveLayerIndex = maskIndex;
            }

            _mixer = mixer;
        }
        else
        {
            _mixer = AnimationMixerPlayable.Create(_graph, 2, false);
        }

        _output = AnimationPlayableOutput.Create(_graph, "output", animator);
        _output.SetSourcePlayable(_mixer);

        if (_clips == null || _clips.Length == 0)
            _clips = animator.GetCurrentAnimatorClipInfo(0).Select(x => x.clip).ToArray();

        for (int i=0; i<_clips.Length; i++)
        {
            var clip = _clips[i];
            if (clip != null && !clip.empty)
            {
                _ = clip.length;
            } 
        }

        _savedAnimatorController = animator.runtimeAnimatorController;
        animator.runtimeAnimatorController = null;
        _graph.Play();

        _playables = _clips.Select(x =>
        {
            if (x == null)
                return default(AnimationClipPlayable);

            return AnimationClipPlayable.Create(_graph, x);
        }).ToArray();

        Play(0);
        _graph.Evaluate();
    }

    public void Destroy()
    {
        if (_animator == null)
            return;

        if (_graph.IsValid())
        {
            if (_playables != null)
            {
                for (int i=0; i<_playables.Length; i++)
                {
                    if (_playables[i].IsValid())
                        _playables[i].Destroy();
                }

                _playables = null;
            }

            if (_layerClipPlayable.IsValid())
                _layerClipPlayable.Destroy();

            if (_additiveClipPlayable.IsValid())
                _additiveClipPlayable.Destroy();

            _mixer.Destroy();
            _graph.Destroy();
        }

        _animator.runtimeAnimatorController = _savedAnimatorController;
        _animator = null;
    }

    public void AdvanaceTime(float deltaTime)
    {
        if (_animator == null)
            return;

        if (_increase != 0.0f)
        {
            _weight += deltaTime * _increase;

            if (_weight >= 1.0f)
            {
                _mixer.SetInputWeight(_activePort, 1.0f);
                _mixer.SetInputWeight(_activePort ^ 1, 0.0f);
                _mixer.DisconnectInput(_activePort ^ 1);
                _increase = 0.0f;
            }
            else
            {
                _mixer.SetInputWeight(_activePort, _weight);
                _mixer.SetInputWeight(_activePort ^ 1, 1.0f - _weight);
            }
        }

        if (!forceLoop)
            return;

        if (!IsValidCurrentPlayable)
            return;

        if (IsPlayingEnd)
            currentPlayable.SetTime(currentPlayingTime - currentPlayable.GetAnimationClip().length);
    }

    public void Play(int index, float duration = 0.0f, float startTime = 0.0f)
    {
        if (!_mixer.IsValid() || _playables == null)
            return;

        if (_playables.Length == 0 || forcePlay)
            return;

        if (_clips[index] == null)
            return;

        if (IsValidCurrentPlayable)
        {
            if (currentPlayable.GetAnimationClip() == _clips[index])
            {
                if (!_graph.IsPlaying())
                    _graph.Play();
            }
        }
        else
        {
            if (!_graph.IsPlaying())
                _graph.Play();

            if (duration == 0.0f)
            {
                _mixer.DisconnectInput(_activePort);
                _mixer.DisconnectInput(_activePort ^ 1);
                _playables[index].SetTime(startTime);
                _mixer.ConnectInput(_activePort, _playables[index], 0, 1.0f);
                _mixer.SetInputWeight(_activePort ^ 1, 0.0f);
                _mixer.SetInputWeight(_activePort, 1.0f);
                _increase = 0.0f;
            }
            else
            {
                _activePort ^= 1;
                if (_mixer.GetInput(_activePort).IsValid())
                {
                    float inputWeight = _mixer.GetInputWeight(_activePort);
                    if (inputWeight <= 0.95f && IsValidCurrentPlayable && currentPlayable.GetAnimationClip() == _clips[index])
                    {
                        _increase = 1.0f / duration;
                        _weight = 1.0f - inputWeight;
                        return;
                    }
                    else
                    {
                        _mixer.DisconnectInput(_activePort);
                    }
                }

                _playables[index].SetTime(startTime);
                _mixer.ConnectInput(_activePort, _playables[index], 0, 0.0f);
                _mixer.SetInputWeight(_activePort ^ 1, 1.0f);
                _increase = 1.0f / duration;
                _weight = 0.0f;
            }
        }
    }

    public void Stop()
    {
        _graph.Stop();
    }

    public void Resume()
    {
        _graph.Play();
    }

    public void SetSpeed(float speed)
    {
        _mixer.SetSpeed(speed);
    }

    public void SetTimeUpdateMode(DirectorUpdateMode mode)
    {
        _graph.SetTimeUpdateMode(mode);
    }

    public void SetAdditiveLayerTime(float time)
    {
        if (_additiveLayerIndex == -1)
            return;

        float weight = time >= 0.0f ? 1.0f : 0.0f;
        _mixer.SetInputWeight(_additiveLayerIndex, weight);
        _additiveClipPlayable.SetTime(time);
    }

    public void Evalute()
    {
        if (_graph.IsValid())
            _graph.Evaluate(0.0f);
    }

    public void PlayFrame(int index, float duration = 0.0f, float startFrame = 0.0f, bool forceplay = false)
    {
        float startTime = 0.0f;

        if (index < _playables.Length && _playables[index].IsValid())
            startTime = startFrame / _playables[index].GetAnimationClip().frameRate;

        Play(index, duration, startTime);
    }

    public void SetAnimSpeed(float speed)
    {
        currentPlayable.SetSpeed(speed);
    }

    public void ResetAnimSpeed()
    {
        for (int i=0; i<_clips.Length; i++)
        {
            if (_clips[i] != null)
                _playables[i].SetSpeed(1.0f);
        }
    }

    public void RePlay(float startFrame = 0.0f)
    {
        if (!_graph.IsPlaying())
            return;

        var clip = _playables[currentIndex].GetAnimationClip();
        _playables[currentIndex].SetTime(startFrame / clip.frameRate);
    }
}