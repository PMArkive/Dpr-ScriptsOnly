using Dpr;
using SmartPoint.Components;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FieldPokemonEntity : FieldObjectEntity
{
    public override string entityType { get => "FieldPokemon"; }

    [SerializeField]
    private float scale = 1.0f;
    [SerializeField]
    protected AnimationPlayer _animationPlayer = new AnimationPlayer();

    public override AnimationPlayer GetAnimationPlayer()
    {
        return _animationPlayer;
    }

    [SerializeField]
    protected SkinnedMeshRendererCluster[] _rendererClusters;
    [SerializeField]
    protected PokeAnimSound _pokeAnimSound = new PokeAnimSound();

    public PokeAnimSound GetPokeAnimSound()
    {
        return _pokeAnimSound;
    }

    [SerializeField]
    protected bool[] _blinkEnables;

    public bool[] blinkEnables { set => _blinkEnables = value; }

    [SerializeField]
    public bool hasLandingSequence;
    [SerializeField]
    public int eyeIndex = -1;
    [SerializeField]
    public bool autoBlinkEnable = true;

    [NonSerialized]
    public bool updateEnable = true;
    private MaterialPropertyBlock _propertyBlock;
    private Transform _originBone;

    public PokemonPrefabInfo PrefabInfo { set; get; }

    private readonly int[] _blinkPatterns = new int[3] { 1, 2, 1 };
    private const float BlinkIntervalMax = 12.0f;
    private const float BlinkIntervalMin = 3.0f;
    private float _blinkIntervalTime;
    private float _blinkTime;
    private int _blinkIndex = 1;
    private bool _enablePlayInitialIdleAnimation = true;
    private Animator _animator;
    private bool reOnEnable;
    private int wait;

    protected override void Awake()
    {
        base.Awake();
        PokemonMaskController.Register(this);
    }

    protected override void OnDestroy()
    {
        PokemonMaskController.Unregister(this);
        base.OnDestroy();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        RenderPriorityController.Register(transform, _rendererClusters);
        _animator = GetComponent<Animator>();
        _animationPlayer.InitializePlayables(_animator);
        _propertyBlock = new MaterialPropertyBlock();
        _pokeAnimSound.Init(_animationPlayer);

        if (_originBone == null)
            _originBone = transform.Find("Origin");

        PrefabInfo = GetComponent<PokemonPrefabInfo>();
    }

    protected override void OnDisable()
    {
        RenderPriorityController.Unregister(transform);
        _animationPlayer.Destroy();
        _propertyBlock = null;
        base.OnDisable();
    }

    public SkinnedMeshRendererCluster[] rendererCluster { get => _rendererClusters; }

    protected override void OnUpdate(float deltaTime)
    {
        if (!updateEnable)
            return;

        base.OnUpdate(deltaTime);

        if (!isActiveAndEnabled)
            return;

        ReOnEnable();
        _animationPlayer.AdvanaceTime(deltaTime);

        if (_blinkEnables.Length == 0)
        {
            _pokeAnimSound.Update(transform);
            return;
        }

        if (autoBlinkEnable)
        {
            if (_blinkEnables[_animationPlayer.currentIndex] && _blinkIntervalTime > 0.0f)
            {
                _blinkTime += deltaTime;
                if (_blinkIntervalTime <= _blinkTime)
                {
                    int oldBlinkIndex = _blinkIndex;
                    _blinkIntervalTime = 0.1f;
                    _blinkTime = 0.0f;
                    _blinkIndex++;
                    _animationPlayer.SetAdditiveLayerTime(_blinkPatterns[oldBlinkIndex] / 3.0f);

                    if (_blinkIndex == _blinkPatterns.Length)
                        _blinkIntervalTime = 0.0f;
                }

                _pokeAnimSound.Update(transform);
                return;
            }
        }

        _blinkIntervalTime = UnityEngine.Random.Range(BlinkIntervalMin, BlinkIntervalMax);
        _blinkTime = 0.0f;
        _blinkIndex = 0;
        _animationPlayer.SetAdditiveLayerTime(-1.0f);
    }

    protected override void OnLateUpdate(float deltaTime)
    {
        if (!updateEnable)
            return;

        base.OnLateUpdate(deltaTime);

        if (_originBone == null)
            return;

        // TODO: What the fuck is going on here??????????????
        var pos = _originBone.localPosition;
        _originBone.localPosition = new Vector3(0.0f, 0.0f, pos.y);

        _originBone.localScale = new Vector3(scale, scale, scale);
    }

    protected override bool SwitchToNext()
    {
        return base.SwitchToNext();
    }

    public int GetIdleAnimationIndex()
    {
        return EventParams.IdleAnimOverride < 0 ? Animation.Idle : EventParams.IdleAnimOverride;
    }

    public int GetWalkAnimationIndex()
    {
        return EventParams.WalkAnimOverride < 0 ? Animation.Walk : EventParams.WalkAnimOverride;
    }

    public void EnablePlayInitialIdleAnimation(bool enabled)
    {
        _enablePlayInitialIdleAnimation = enabled;
    }

    protected override void ProcessSequence(float deltaTime)
    {
        if (!updateEnable)
            return;

        if (currentSequence == SequenceID.Initialize &&
            nextSequence == SequenceID.Active &&
            _enablePlayInitialIdleAnimation)
        {
            _animationPlayer.Play(GetIdleAnimationIndex(), 0.2f);
        }

        base.ProcessSequence(deltaTime);
    }

    private void AK_EffectStart00(int value)
    {
        // Empty
    }

    private void AK_EffectStart01(int value)
    {
        // Empty
    }

    private void AK_ButuriStart01(int value)
    {
        // Empty
    }

    private void AK_SEStart01(int value)
    {
        // Empty
    }

    private void AK_SEStart02(int value)
    {
        // Empty
    }

    private void AK_SEStart03(int value)
    {
        // Empty
    }

    private void AK_SEStart04(int value)
    {
        // Empty
    }

    private void AK_PartsMaterial01(int value)
    {
        // Empty
    }

    private void AK_PartsSkel01(int value)
    {
        _animationPlayer.layerWeight = value;
    }

    public void SetAlwaysAnimateCullingMode()
    {
        reOnEnable = true;
        wait = 0;
    }

    private void ReOnEnable()
    {
        if (!reOnEnable)
            return;

        if (_animator == null)
            return;

        wait++;
        _animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

        switch (wait)
        {
            case 2:
                _animator.enabled = false;
                OnEnable();
                break;

            case 3:
                _animator.enabled = true;
                reOnEnable = false;
                break;
        }
    }

    public class SequenceID : FieldObjectEntity.SequenceID
    {
	    protected const int User = 12288;
    }

    public class Animation
    {
        public const int Idle = 0;
        public const int Walk = 1;
        public const int Run = 2;
        public const int JumpOut = 3;
        public const int Fall = 4;
        public const int Landing = 5;
        public const int Buturi01 = 6;
        public const int Tokusyu01 = 7;
        public const int Roar01 = 9;
        public const int Damage = 15;
        public const int BaWaitToFiWait = 17;
        public const int BaWaitToKwWait = 18;
        public const int FiWaitToBaWait = 19;
        public const int FiWaitToKwWait = 20;
        public const int KwWaitToBaWait = 21;
        public const int KwWaitToFiWait = 22;
        public const int FieldWait1 = 24;
        public const int FieldWait2 = 25;
        public const int WaitToWalk = 26;
        public const int WalkToWait = 27;
        public const int RunToWait = 28;
        public const int WaitToRun = 29;
        public const int RunToWalk = 30;
        public const int WalkToRun = 31;
        public const int Kw_Wait = 32;
        public const int Kw_Turn = 34;
        public const int Kw_DrowseA = 36;
        public const int Kw_DrowseB = 37;
        public const int Kw_DrowseC = 38;
        public const int Hate = 41;
        public const int Happy01 = 43;
        public const int Happy02 = 44;
        public const int Happy03 = 45;
        public const int MoveA = 46;
        public const int MoveB = 47;
        public const int MoveC = 48;
        public const int MoveD = 49;
        public const int Lonely = 50;
        public const int EatA = 54;
        public const int EatB = 55;
        public const int EatC = 56;
        public const int CloseEye = 57;
    }
}