using Dpr.Battle.View;
using Dpr.Battle.View.Systems;
using Dpr.Playables;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class BattleCharacterEntity : BattleObjectEntity
{
    private const float LOSE_LOOP_START_TIME = 2.0f;

    [SerializeField]
    protected BattleAnimationPlayer _animationPlayer = new BattleAnimationPlayer();
    [SerializeField]
    protected ColorVariation _colorVariation;
    [SerializeField]
    protected float _motionBlendTime = 0.15f;
    protected bool _isEnableAnimationPlayer; 
    private float _speakStartTime;

    public override string entityType { get => "BattleCharacter"; }
    public TrainerSimpleParam TrainerSimpleParam { get; set; }

    protected override void Awake()
    {
        base.Awake();
        InitializeRendererInfos();
    }

    protected override void OnDestroy()
    {
        _animationPlayer = null;
        _locators = null;
        _animator = null;

        base.OnDestroy();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _animationPlayer.Initialize(this.GetComponentThis(ref _animator));
        _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)AnimationState.Wait_B);
        nextSequence = SequenceID.None;
    }

    protected override void OnDisable()
    {
        _animationPlayer.Destroy();
        base.OnDisable();
    }

    public virtual void Initialize(TrainerSimpleParam param, bool isContest = false)
    {
        TrainerSimpleParam = param;
        CreateShadowCastSystem();
        SetSkinColor(TrainerSimpleParam.colorID);
    }

    protected void SetSkinColor(int colorId)
    {
        if (_colorVariation == null)
            _colorVariation = GetComponent<ColorVariation>();

        if (_colorVariation != null)
            _colorVariation.ColorIndex = colorId;
    }

    public int GetSkinColor()
    {
        if (_colorVariation)
            return _colorVariation.ColorIndex;

        return -1;
    }

    private void CreateShadowCastSystem()
    {
        if (_shadowCastSystem != null)
            return;

        _shadowCastSystem = new BattleShadowCastSystem();
        _shadowCastSystem.Register(ShadowCastObject.Factory(transform, _renderers));
    }

    public virtual void SetCaputureDemo()
    {
        // Empty
    }

    protected override void OnUpdate(float deltaTime)
    {
        if (currentSequence != nextSequence && SwitchToNext())
        {
            currentSequence = nextSequence;
            sequenceTime = 0.0f;
        }

        ProcessSequence(deltaTime);
        sequenceTime += deltaTime;

        if (!enabled)
            return;

        if (_blinkProcess != null && _blinkProcess.trainerAge != Dpr.Trainer.TrainerAge.NONE)
            base.OnUpdate(deltaTime);

        _animationPlayer.AdvanaceTime(deltaTime);
    }

    protected override void ProcessSequence(float deltaTime)
    {
        if (!isActiveAndEnabled)
            return;

        switch (currentSequence)
        {
            case SequenceID.Initialize:
                _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)AnimationState.Advent02_B);
                nextSequence = SequenceID.None;
                break;

            case SequenceID.Advent:
                if (_animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).CurrentRemaingTime <= 0.015f)
                {
                    _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)AnimationState.Wait_B);
                    _blinkProcess?.SetBlinkEnabled(true);
                    RequestSequence(SequenceID.None);
                }
                break;

            case SequenceID.ToWait:
                if (_animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).CurrentRemaingTime < 0.0f)
                {
                    _blinkProcess?.SetBlinkEnabled(true);
                    _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)AnimationState.Wait_B);
                    nextSequence = SequenceID.None;
                }
                break;

            case SequenceID.ToLose:
                if (_animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).CurrentRemaingTime < 0.0f)
                    _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).CurrentPlayable.SetTime(TrainerSimpleParam.loseLoopTime);
                break;

            case SequenceID.ToSpeak:
                var layer = _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer);
                float currentTime = layer.CurrentRemaingTime;
                float length = layer.CurrentPlayable.GetAnimationClip().length;
                if (currentTime - length > _speakStartTime)
                {
                    _blinkProcess?.SetBlinkEnabled(true);
                    _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)AnimationState.Wait_B, 0.0f, currentTime - length);
                    nextSequence = SequenceID.None;
                }
                break;
        }
    }

    public virtual void RequestSequence(int sequenceID)
    {
        nextSequence = sequenceID;
        SwitchToNext();
    }

    public void RequestAnimationState(AnimationState state, float duration = 0.15f, float startTime = 0.0f, bool isLoop = false)
    {
        if (state == AnimationState.Speak01_B)
        {
            var layer = _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer);
            var length = layer.CurrentPlayable.GetAnimationClip().length;
            startTime = layer.CurrentPlayingTime;

            if (startTime >= length)
                startTime %= length;

            duration = 0.0f;
            _speakStartTime = startTime;
        }

        _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play((int)state, duration, startTime);
        _animationPlayer.GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).IsForceLoop = isLoop;

        switch (state)
        {
            case AnimationState.Advent02_B:
                _blinkProcess?.SetBlinkEnabled(false);
                RequestSequence(SequenceID.None);
                break;

            case AnimationState.Advent_B:
                _blinkProcess?.SetBlinkEnabled(false);
                RequestSequence(SequenceID.Advent);
                break;

            case AnimationState.Wait02_B:
            case AnimationState.Order_B:
            case AnimationState.Win01_B:
            case AnimationState.Speak02_B:
            case AnimationState.Advent03_B:
            case AnimationState.Advent04_B:
            case AnimationState.Advent05_B:
                _blinkProcess?.SetBlinkEnabled(false);
                RequestSequence(SequenceID.ToWait);
                break;

            case AnimationState.Lose01_B:
                _blinkProcess?.SetBlinkEnabled(false);
                RequestSequence(SequenceID.ToLose);
                break;

            case AnimationState.Speak01_B:
                _blinkProcess?.SetBlinkEnabled(true);
                RequestSequence(SequenceID.ToSpeak);
                break;

            default:
                _blinkProcess?.SetBlinkEnabled(true);
                RequestSequence(SequenceID.ToWait);
                break;
        }
    }

    public BattleAnimationPlayer GetAnimationPlayer()
    {
        return _animationPlayer;
    }

    public void SetAnimationSpeed(float animationSpeed)
    {
        _animationPlayer.SetAnimSpeed(animationSpeed);
    }

    public virtual void SetRenderActive(bool isActive)
    {
        for (int i=0; i<_renderers.Length; i++)
            _renderers[i].SetActive(isActive);
    }

    public class SequenceID : BaseEntity.SequenceID
    {
	    public const int Active = 4096;
        protected const int User = 8192;
        public const int None = 12288;
        public const int Advent = 16384;
        public const int Order = 20480;
        public const int Animation = 24576;
        public const int ToWait = 28672;
        public const int ToLose = 32768;
        public const int ToSpeak = 36864;
    }

    public enum AnimationState : int
    {
        Advent02_B = 0,
        Advent_B = 1,
        Wait_B = 2,
        Wait02_B = 3,
        Order_B = 4,
        Lose01_B = 5,
        Speak01_B = 6,
        Win01_B = 7,
        Speak02_B = 8,
        Walk_B = 9,
        Run_B = 10,
        Advent03_B = 11,
        Advent04_B = 12,
        Advent05_B = 13,
    }

    public enum AnimationStateEye : int
    {
        Eye01_B = 0,
    }
}