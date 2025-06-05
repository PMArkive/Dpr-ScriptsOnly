using System;
using Dpr.Battle.View;
using Dpr.Battle.View.Systems;
using Dpr.Trainer;
using SmartPoint.AssetAssistant;
using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BattleObjectEntity : BaseEntity
{
    [SerializeField]
    protected CharaAutomaticBlinkProcess _blinkProcess = new CharaAutomaticBlinkProcess();
    [SerializeField]
    protected Renderer[] _renderers;
    [SerializeField]
    protected Transform[] _locators;
    [SerializeField]
    protected ModelEntityType _modelEntityType = ModelEntityType.Unknown;
    protected float _animationSpeed = 1.0f;
    protected BattleShadowCastSystem _shadowCastSystem;
    protected Animator _animator;
    protected RendererInfo[] _rendererInfos;

    public Animator Animator { get => this.GetComponentThis(ref _animator); }
    public Renderer[] Renderers { get => _renderers; }
    public BattleShadowCastSystem ShadowCastSystem { get => _shadowCastSystem; }

    protected override void Awake()
    {
        base.Awake();
        _blinkProcess?.CreateBlinkProcess(this);
    }

    protected override void OnDestroy()
    {
        _blinkProcess = null;
        _renderers = null;
        _locators = null;
        Mem.DelIDisposable(ref _shadowCastSystem);
        _animator = null;
        _rendererInfos = null;

        base.OnDestroy();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Sequencer.earlyLateUpdate += OnEarlyLateUpdate;
        Sequencer.postLateUpdate += OnPostLateUpdate;
    }

    protected override void OnDisable()
    {
        Sequencer.earlyLateUpdate -= OnEarlyLateUpdate;
        Sequencer.postLateUpdate -= OnPostLateUpdate;

        base.OnDisable();
    }

    protected virtual void OnEarlyLateUpdate(float deltatime)
    {
        // Empty
    }

    protected virtual void OnPostLateUpdate(float deltaTime)
    {
        _shadowCastSystem?.OnLateUpdate(deltaTime);
    }

    public Transform GetJoint(JointName jointName)
    {
        if (!_locators.IsNullOrEmpty() && _locators.IsBounds((int)jointName))
            return _locators[(int)jointName];

        return transform;
    }

    public Transform GetJointByName(string name)
    {
        if (!_locators.IsNullOrEmpty())
            return Array.Find(_locators, x => x != null && x.name == name);

        return transform;
    }

    public CharaAutomaticBlinkProcess GetAutomaticBlinkProcess()
    {
        return _blinkProcess;
    }

    protected void InitializeRendererInfos()
    {
        if (_renderers.IsNullOrEmpty())
            return;

        _rendererInfos = new RendererInfo[_renderers.Length];

        for (int i=0; i<_rendererInfos.Length; i++)
            _rendererInfos[i] = new RendererInfo(_renderers[i]);
    }

    public enum ModelEntityType : int
    {
        Unknown = -1,
        Battle = 0,
        Contest = 1,
    }

    [Serializable]
    public class CharaAutomaticBlinkProcess
    {
	    public const EyeType EYE_TYPE_NEUTRAL = EyeType.Normal;
        public const float BLINKING_TIME_MAX = 2.0f;
        private static readonly EyeType[] EYE_BLINK_TABLE = new EyeType[]
        {
            EyeType.HalfClosed, EyeType.Closed, EyeType.HalfClosed, EyeType.Normal
        };
        [SerializeField]
        private BlinkType _blinkType = BlinkType.Unknown;
        [SerializeField]
        private bool _isBlinkEnabled = true;
        [SerializeField]
        private bool[] _eye01 = ArrayHelper.Empty<bool>();
        [SerializeField]
        private BlinkValue[] _blinkValues = ArrayHelper.Empty<BlinkValue>();
        [SerializeField]
        private EyeType _currentEyeType;
        private int _currentState;
        public TrainerAge trainerAge = TrainerAge.ADULT;
        public int blinkIntervalTimeMin = 3;
        public int blinkIntervalTimeMax = 12;
        public int blinkTwiceRate = 50;
        private bool _isConstantBlink = true;
        private BlinkPhase _prevExecuteBlinkPhase;
        private BlinkPhase _blinkPhase;
        private BlinkIntParameter _prevParameter;
        private BlinkIntParameter _requestParameter;
        private BattleObjectEntity _entity;
        private float _blinkIntervalTime;
        private float _blinkingTime;
        private int _blinkStep;

        public bool IsConstantBlink { get => _isConstantBlink; set => _isConstantBlink = value; }

        public void CreateBlinkProcess(BattleObjectEntity entity)
        {
            _entity = entity;

            if (entity != null)
            {
                if (entity is BattleCharacterEntity)
                    _blinkType = BlinkType.Trainer;
                else if (entity is BattlePokemonEntity)
                    _blinkType = BlinkType.Pokemon;
            }
        }

        public void SetConstantBlink(bool isEnable)
        {
            _isConstantBlink = isEnable;
        }

        public void SetBlinkEnabled(bool value)
        {
            _isBlinkEnabled = value;
        }

        public bool IsBlinkEnabled()
        {
            return _isBlinkEnabled;
        }

        public bool IsBlinking()
        {
            return _blinkPhase != BlinkPhase.NONE;
        }

        public void SetBlinkTriggerParam(BlinkIntParameter param)
        {
            _requestParameter = param;
        }

        private void SetBlinkState(EyeType type)
        {
            if (_eye01.IsNullOrEmpty())
                return;

            if (!_eye01[(int)type])
                return;

            for (int i=0; i<_blinkValues.Length; i++)
            {
                if (_blinkValues[i].TargetNode == null)
                    continue;

                var blinkValue = _blinkValues[i];
                var v = blinkValue.Values[(int)type];

                switch (blinkValue.CurveValueType)
                {
                    case CurveValueType.LocalRotation:
                        blinkValue.TargetNode.transform.localRotation = new Quaternion(v.x, v.y, v.z, v.w);
                        break;

                    case CurveValueType.LocalPosition:
                        blinkValue.TargetNode.transform.localPosition = v;
                        break;

                    case CurveValueType.LocalScale:
                        blinkValue.TargetNode.transform.localScale = v;
                        break;
                }
            }
        }

        public bool IsDefaultEyeTypeAnimState()
        {
            return _currentEyeType == EyeType.Normal;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_blinkType == BlinkType.Pokemon)
            {
                if (_requestParameter == BlinkIntParameter.Sleep)
                {
                    ResetBlinkPhace();
                    SetBlinkState(EyeType.Closed);
                }

                if (_blinkValues.IsNullOrEmpty())
                    return;
            }

            if (_isConstantBlink && (_isBlinkEnabled || IsBlinking()))
                OnUpdateBlink(deltaTime);
        }

        private void OnUpdateBlink(float deltaTime)
        {
            switch (_blinkPhase)
            {
                case BlinkPhase.NONE:
                    var next = DecideNextBlinkPhase();
                    if (next != BlinkPhase.NONE)
                    {
                        StartBlink();
                        ChangeBlinkPhase(next);
                    }
                    break;

                case BlinkPhase.ONCE:
                    if (!UpdateBlink(deltaTime))
                        DoSettingOnEndBlink();
                    break;

                case BlinkPhase.TWICE:
                    if (_blinkStep == 0)
                    {
                        if (!UpdateBlink(deltaTime))
                        {
                            StartBlink();
                            _blinkingTime = 0.0f;
                            _blinkStep++;
                        } 
                    }
                    else
                    {
                        if (!UpdateBlink(deltaTime))
                            DoSettingOnEndBlink();
                    }
                    break;
            }

            _prevParameter = _requestParameter;
        }

        private bool UpdateBlink(float deltaTime)
        {
            switch (_blinkType)
            {
                case BlinkType.Pokemon:
                    SetBlinkState(EYE_BLINK_TABLE[_currentState]);
                    _currentState = (int)(_blinkingTime * 10.0f);

                    if (_currentState < EYE_BLINK_TABLE.Length)
                    {
                        _blinkingTime += deltaTime;
                        return true;
                    }
                    else
                    {
                        _blinkingTime = 0.0f;
                        return false;
                    }

                case BlinkType.Trainer:
                    var entity = _entity as BattleCharacterEntity;
                    return !entity.GetAnimationPlayer().GetAnimationLayer(Dpr.Playables.BattleAnimationPlayer.LayerIndex.EyeLayer).IsPlayingEnd;

                default:
                    return false;
            }
        }

        private void StartBlink()
        {
            switch (_blinkType)
            {
                case BlinkType.Pokemon:
                    _currentState = 0;
                    break;

                case BlinkType.Trainer:
                    var entity = _entity as BattleCharacterEntity;
                    var layer = entity.GetAnimationPlayer().GetAnimationLayer(Dpr.Playables.BattleAnimationPlayer.LayerIndex.EyeLayer);
                    layer.Weight = 1.0f;
                    layer.Play(0);
                    break;
            }
        }

        private void DoSettingOnEndBlink()
        {
            _prevExecuteBlinkPhase = _blinkPhase;
            ChangeBlinkPhase(BlinkPhase.NONE);

            if (_blinkType != BlinkType.Trainer)
                return;

            var entity = _entity as BattleCharacterEntity;
            entity.GetAnimationPlayer().GetAnimationLayer(Dpr.Playables.BattleAnimationPlayer.LayerIndex.EyeLayer).Weight = 0.0f;
        }

        private void ChangeBlinkPhase(BlinkPhase phase)
        {
            if (_blinkPhase != phase)
            {
                _blinkPhase = phase;
                _blinkStep = 0;
                _blinkIntervalTime = 0.0f;
                _blinkingTime = 0.0f;
            }
        }

        private void ResetBlinkPhace()
        {
            _prevExecuteBlinkPhase = BlinkPhase.NONE;
            _blinkPhase = BlinkPhase.NONE;
            _blinkStep = 0;
            _blinkIntervalTime = 0.0f;
        }

        private BlinkPhase DecideNextBlinkPhase()
        {
            if (_blinkIntervalTime < blinkIntervalTimeMax)
            {
                if (_blinkIntervalTime < blinkIntervalTimeMin)
                    return BlinkPhase.NONE;

                if (RandomGroupWork.RandomRange(0, Application.targetFrameRate * (blinkIntervalTimeMax - blinkIntervalTimeMin)) != 0)
                    return BlinkPhase.NONE;
            }

            if (_prevExecuteBlinkPhase != BlinkPhase.ONCE)
                return BlinkPhase.ONCE;

            if (RandomGroupWork.RandomRange(0, 100) <= blinkTwiceRate + 1)
                return BlinkPhase.TWICE;
            else
                return BlinkPhase.ONCE;
        }

        private bool CanFirstBlinkStart()
        {
            return true;
        }

        private bool CanSecondBlinkStart()
        {
            return true;
        }

        public enum BlinkType : int
        {
            Unknown = -1,
            Pokemon = 0,
            Trainer = 1,
        }

        public enum EyeType : int
        {
            Normal = 0,
            HalfClosed = 1,
            Closed = 2,
            Damage = 3,
            Angry = 4,
            Happy = 5,
            Sad = 6,
            Reserve = 7,
        }

        public enum BlinkIntParameter : int
        {
            Default = 0,
            Sleep = 3,
        }

        public enum CurveValueType : int
        {
            LocalRotation = 0,
            LocalPosition = 1,
            LocalScale = 2,
        }

        public enum BlinkPhase : int
        {
            NONE = 0,
            ONCE = 1,
            TWICE = 2,
        }

        [Serializable]
        public class BlinkValue
        {
            [SerializeField]
            private Transform _targetNode;
            [SerializeField]
            private CurveValueType _curveValueType;
            [SerializeField]
            private Vector4[] _values;

            public Transform TargetNode { get => _targetNode; set => _targetNode = value; }
            public CurveValueType CurveValueType { get => _curveValueType; set => _curveValueType = value; }
            public Vector4[] Values { get => _values; set => _values = value; }
        }
    }
}