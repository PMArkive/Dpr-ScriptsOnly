using Effect;
using FieldCommon;
using GameData;
using System;
using UnityEngine;
using XLSXContent;

[RequireComponent(typeof(Animator))]
public class FieldCharacterEntity : FieldObjectEntity
{
    public override string entityType { get => "FieldCharacter"; }

    protected static readonly Vector2[] FaceUVs = new Vector2[5]
    {
        new Vector2(0.5f, 0.0f),
        new Vector2(0.5f, -0.25f),
        new Vector2(0.5f, -0.5f),
        new Vector2(0.5f, 0.25f),
        new Vector2(0.0f, 0.25f),
    };
    public static float ViewerHandScale = 0.0f;
    public float HandScale = 0.85f;
    [SerializeField]
    protected AnimationPlayer _animationPlayer = new AnimationPlayer();

    public override AnimationPlayer GetAnimationPlayer()
    {
        return _animationPlayer;
    }

    [SerializeField]
    protected CurvePatterns _blinkPatterns;
    [SerializeField]
    protected FieldCharacterVariation[] _variations;
    [SerializeField]
    [Range(0.0f, 5.0f)]
    protected int _eyePatternIndex;
    [SerializeField]
    [Range(0.0f, 3.0f)]
    protected int _mouthPatternIndex;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    protected int _currentVariation;
    [SerializeField]
    protected Renderer _watchRenderer;

    public Renderer watchRender { get => _watchRenderer; set => _watchRenderer = value; }
    public bool watchVisibility
    {
        get
        {
            if (_watchRenderer == null)
                return true;

            return _watchRenderer.enabled;
        }
        set
        {
            if (_watchRenderer != null)
                _watchRenderer.enabled = value;
        }
    }
    public FieldCharacterVariation[] variations { get => _variations; set => _variations = value; }
    public CurvePatterns blinkPattern { get => _blinkPatterns; set => _blinkPatterns = value; }

    private void OnValidate()
    {
        // Empty
    }

    public int eyePatternIndex { get => _eyePatternIndex; }
    public int mouthPatternIndex { get => _mouthPatternIndex; }
    public int currentVariation { get => _currentVariation; }

    private int _blinkCurveIndex;
    private float _blinkTime;
    private int _UVOffsetID;
    protected MaterialPropertyBlock _propertyBlock;

    protected const float _MaxCoolTime = 0.43333334f;

    protected float[] _effectCoolTime = new float[2];
    public Vector3 NeckAngle;
    public Vector3 _updateNeckAngle;
    public Vector3 _updateNeckAngle2;
    private Transform _subductionNode;
    private Transform _hipNode;

    public Transform hipNode { get => _hipNode; }

    public float SubductionDepth;
    private EffectInstance SwimEffect;
    private bool isPlayingSwimEffect;
    private EffectInstance _swimWalkEffect;
    private bool _isPlayingSwimWalkEffect;

    public bool IsForceBlink { set; get; }

    private bool _reqestStopFootEffect;
    private bool _isStopFootEffect;
    private float _stopFootEffectRetrunTime;
    private int _oldAnimEventIndex;
    private int _oldAnimClipIndex;
    private CharcterAnimeEvent.SheetanimeEvent[][] _animEvents;
    private Func<AnimationPlayer, bool> animeEndCallBack;

    public bool IsStopFootEffect
    {
        set
        {
            if (!value && _reqestStopFootEffect)
                _stopFootEffectRetrunTime = 0.1f;

            _reqestStopFootEffect = value;
        }
        get => _isStopFootEffect;
    }

    private void Start()
    {
        // Empty
    }

    protected virtual void OnFootSE()
    {
        FieldManager.Instance.FootEventSE(this, false, false, FieldManager.AttributeEventCallType.NPC);
    }

    protected virtual void OnFootEffect(int index)
    {
        if (_isStopFootEffect)
            return;

        if (index >= _effectCoolTime.Length)
            return;

        if (_effectCoolTime[index] > 0.0f)
            return;

        _effectCoolTime[index] = _MaxCoolTime;
        OnFootSE();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        var animator = GetComponent<Animator>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>(true);

        if (animator != null)
            _animationPlayer.InitializePlayables(animator);

        _propertyBlock = new MaterialPropertyBlock();
        _UVOffsetID = Shader.PropertyToID("_UVOffset");
        _blinkTime = 0.0f;

        var subNode = transform.FindDeep("Origin");
        if (subNode != null)
            _subductionNode = subNode.transform;

        var hipNode = transform.FindDeep("Hips");
        if (hipNode != null)
            _hipNode = hipNode.transform;

        _oldAnimEventIndex = -1;
        _oldAnimClipIndex = -1;
    }

    protected override void OnDisable()
    {
        _animationPlayer.Destroy();
        _propertyBlock = null;

        if (SwimEffect != null)
        {
            SwimEffect.Stop();
            SwimEffect = null;
        }

        isPlayingSwimEffect = false;

        _swimWalkEffect?.Stop();
        _swimWalkEffect = null;

        base.OnDisable();
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        for (int i = 0; i < _effectCoolTime.Length; i++)
        {
            _effectCoolTime[i] -= deltaTime;
            if (_effectCoolTime[i] <= 0.0f)
                _effectCoolTime[i] = 0.0f;
        }

        if (!enabled)
            return;

        if (animeEndCallBack != null && _animationPlayer.IsPlayingEnd && animeEndCallBack.Invoke(_animationPlayer))
            animeEndCallBack = null;

        _animationPlayer.AdvanaceTime(deltaTime);

        var variation = _variations[_currentVariation];
        if (variation.faceRenderer == null)
            return;

        bool isBlinking = true;
        if (_blinkPatterns != null && _blinkPatterns.Count > 0)
        {
            if (_blinkCurveIndex == -1)
            {
                _blinkCurveIndex = UnityEngine.Random.Range(0, _blinkPatterns.Count);
                _blinkTime = 0.0f;
            }
            else
            {
                if (_blinkPatterns.times[_blinkCurveIndex] < _blinkTime)
                {
                    _blinkCurveIndex = -1;
                    _blinkCurveIndex = UnityEngine.Random.Range(0, _blinkPatterns.Count);
                    _blinkTime = 0.0f;
                }
            }

            if (_eyePatternIndex != 0)
            {
                _blinkTime = 0.0f;
                isBlinking = false;
            }
        }
        else
        {
            isBlinking = false;
        }

        if (_propertyBlock != null)
        {
            variation.faceRenderer.GetPropertyBlock(_propertyBlock, variation.eyeMaterialIndex);
            if (isBlinking)
            {
                float uvY = _blinkPatterns[_blinkCurveIndex].Evaluate(_blinkTime);
                if (IsForceBlink)
                    uvY = 0.5f;

                _propertyBlock.SetVector(_UVOffsetID, new Vector2(0.0f, uvY));
            }
            else
            {
                if (_UVOffsetID == 0)
                    _propertyBlock.SetVector(_UVOffsetID, Vector2.zero);
                else
                    _propertyBlock.SetVector(_UVOffsetID, FaceUVs[_eyePatternIndex - 1]);
            }
            variation.faceRenderer.SetPropertyBlock(_propertyBlock, variation.eyeMaterialIndex);

            variation.faceRenderer.GetPropertyBlock(_propertyBlock, variation.mouthMaterialIndex);
            if (_mouthPatternIndex == 0)
            {
                if (_eyePatternIndex == 0)
                    _propertyBlock.SetVector(_UVOffsetID, new Vector2(0.0f, 0.0f));
                else
                    _propertyBlock.SetVector(_UVOffsetID, FaceUVs[_eyePatternIndex - 1]);
            }
            else
            {
                float uvY = (_mouthPatternIndex - 1) * -0.25f + 1.0f;
                _propertyBlock.SetVector(_UVOffsetID, new Vector2(0.0f, uvY));
            }
            variation.faceRenderer.SetPropertyBlock(_propertyBlock, variation.mouthMaterialIndex);
        }

        if (isBlinking)
            _blinkTime += deltaTime;

        if (_isStopFootEffect != _reqestStopFootEffect)
        {
            if (_reqestStopFootEffect)
            {
                _isStopFootEffect = true;
            }
            else
            {
                _stopFootEffectRetrunTime -= deltaTime;
                if (_stopFootEffectRetrunTime > 0.0f)
                {
                    _isStopFootEffect = false;
                    if (_stopFootEffectRetrunTime <= 0.0f)
                        _stopFootEffectRetrunTime = 0.0f;
                }
            }
        }
    }

    protected override void OnLateUpdate(float deltaTime)
    {
        UpdateAnimEvent();
        UpdateSubductionDepth();
        UpdateSwim();
        LateUpdateNeckAngle(deltaTime);

        var handVector = new Vector3(HandScale, HandScale, HandScale);

        if (ViewerHandScale > 0.1f)
        {
            handVector.x = ViewerHandScale;
            handVector.y = ViewerHandScale;
            handVector.z = ViewerHandScale;
        }

        var variation = _variations[_currentVariation];

        if (variation.lhand != null)
            variation.lhand.localScale = handVector;

        if (variation.rhand != null)
            variation.rhand.localScale = handVector;

        base.OnLateUpdate(deltaTime);
    }

    protected override bool SwitchToNext()
    {
        return base.SwitchToNext();
    }

    protected override void ProcessSequence(float deltaTime)
    {
        switch (currentSequence)
        {
            case SequenceID.Initialize:
                nextSequence = SequenceID.Active;
                GetIdleAnimationIndex(out int index, out float duration);
                _animationPlayer.Play(index, duration);
                break;
        }

        base.ProcessSequence(deltaTime);
    }

    private void LateUpdateNeckAngle(float deltaTime)
    {
        var variation = _variations[_currentVariation];
        _updateNeckAngle2 = variation.neck.eulerAngles;

        var neck = (NeckAngle - _updateNeckAngle) * deltaTime * 5.0f;
        if (neck.sqrMagnitude >= 0.001f)
            _updateNeckAngle += neck;
        else
            _updateNeckAngle = NeckAngle;

        variation.neck.localEulerAngles += _updateNeckAngle;
    }

    public virtual void GetIdleAnimationIndex(out int index, out float duration)
    {
        if (EventParams.Sit)
        {
            index = 10;
            duration = 0.0f;
        }
        else
        {
            duration = 0.2f;
            index = EventParams.IdleAnimOverride < 0 ? 0 : EventParams.IdleAnimOverride;
        }
    }

    public int GetWalkAnimationIndex()
    {
        return EventParams.WalkAnimOverride < 0 ? 1 : EventParams.WalkAnimOverride;
    }

    public void SetEyePattern(int index)
    {
        _eyePatternIndex = Mathf.Clamp(index, 0, FaceUVs.Length);
    }

    public void SetMouthPattern(int index)
    {
        _mouthPatternIndex = Mathf.Clamp(index, 0, 3);
    }

    public void SetAnimationEvents(CharcterAnimeTable tbl)
    {
        if (tbl == null)
            return;

        _animEvents = new CharcterAnimeEvent.SheetanimeEvent[_animationPlayer.clips.Length][];

        for (int i=0; i<tbl.cliplist.Length; i++)
        {
            if (tbl.cliplist[i].data == null)
                continue;

            int clipIndex = tbl.cliplist[i].clipindex;
            if (clipIndex < 0 || clipIndex >= _animationPlayer.clips.Length)
                return;

            var clip = _animationPlayer.clips[clipIndex];

            if (clip == null)
                continue;

            _animEvents[i] = tbl.cliplist[i].data.animeEvent;
        }
    }

    private void UpdateSubductionDepth()
    {
        float depth;
        if (CheckSubductionEnableAttribute(gridPosition, 0.0f))
            depth = CalcSubductionDepth(worldPosition);
        else
            depth = 0.0f;

        if (EventParams.CharacterGraphicsIndex == CharGraphicsID.SKIER_M ||
            EventParams.CharacterGraphicsIndex == CharGraphicsID.SKIER_W)
        {
            depth = Mathf.Min(depth, 0.2f);
        }

        if (depth == SubductionDepth)
            return;

        SubductionDepth = depth;

        if (_subductionNode == null)
            return;

        var pos = _subductionNode.localPosition;
        _subductionNode.localPosition = new Vector3(pos.x, -depth, pos.z);
    }

    private static float CalcSubductionDepth(Vector3 worldPotision)
    {
        var pos = Vec2ToVec3Position(GridToPosition(PositionToGrid(worldPotision)), worldPotision.y);
        pos.x = pos.x <= worldPotision.x ? pos.x : pos.x - 1.0f;
        pos.z = pos.z <= worldPotision.z ? pos.z : pos.z - 1.0f;

        var subFrom = CalcSubductionDepthX(pos, worldPotision.x);
        var subTo = CalcSubductionDepthX(new Vector3(pos.x, pos.y, pos.z + 1.0f), worldPotision.x);

        return Mathf.Lerp(subFrom, subTo, Mathf.InverseLerp(pos.z, pos.z + 1.0f, worldPotision.z));
    }

    private static float CalcSubductionDepthX(Vector3 gridPos, float worldPosX)
    {
        float xFrom = gridPos.x;
        float subFrom = GetSubductionDepth(PositionToGrid(gridPos), xFrom);

        float xTo = gridPos.x + 1.0f;
        float subTo = GetSubductionDepth(PositionToGrid(new Vector3(xTo, gridPos.y, gridPos.z)), xTo);

        return Mathf.Lerp(subFrom, subTo, Mathf.InverseLerp(xFrom, xTo, worldPosX));
    }

    private static float GetSubductionDepth(Vector3 worldPosition)
    {
        return GetSubductionDepth(PositionToGrid(worldPosition), worldPosition.y);
    }

    private static float GetSubductionDepth(Vector2Int gridPosition, float height)
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);

        if (GameManager.GetAttributeTable(code) == null)
            return 0.0f;

        if (AttributeID.MATR_IsMostShallowSnow(code))
            return DataManager.GetFieldCommonParam(ParamIndx.SnowLv0_Depth);
        if (AttributeID.MATR_IsShallowSnow(code))
            return DataManager.GetFieldCommonParam(ParamIndx.SnowLv1_Depth);
        if (AttributeID.MATR_IsSnowDeep(code))
            return DataManager.GetFieldCommonParam(ParamIndx.SnowLv2_Depth);
        if (AttributeID.MATR_IsSnowDeepMost(code))
            return DataManager.GetFieldCommonParam(ParamIndx.SnowLv3_Depth);

        return 0.0f;
    }

    private static bool CheckSubductionEnableAttribute(Vector2Int gridPosition, float height)
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);

        if (GameManager.GetAttributeTable(code) == null)
            return false;

        return AttributeID.MATR_IsSnow(code);
    }

    public bool IsSwimCharacter()
    {
        if (EventParams.CharacterGraphicsIndex != CharGraphicsID.SWIMMER_W &&
            EventParams.CharacterGraphicsIndex != CharGraphicsID.SWIMMER_M)
            return false;

        return CheckSwimEnableAttribute(gridPosition, 0.0f);
    }

    private void UpdateSwim()
    {
        if (!IsSwimCharacter())
            return;

        if (GetAnimationPlayer().currentIndex != 1 || _isPlayingSwimWalkEffect)
            return;

        _isPlayingSwimWalkEffect = true;
        _swimWalkEffect?.Stop();

        FieldManager.Instance.CallEffect(EffectFieldID.EF_F_WAZA_SURF, transform,
            eff => _swimWalkEffect = eff,
            eff => _isPlayingSwimWalkEffect = false);
    }

    private static bool CheckSwimEnableAttribute(Vector2Int gridPosition, float height)
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);

        if (GameManager.GetAttributeTable(code) == null)
            return false;

        return AttributeID.MATR_IsWater(code);
    }

    private void UpdateAnimEvent()
    {
        if (_animEvents == null)
            return;

        if (_animationPlayer.currentIndex >= _animEvents­.Length)
            return;

        var animEvent = _animEvents[_animationPlayer.currentIndex];
        if (animEvent == null)
            return;

        var clip = _animationPlayer.clips[_animationPlayer.currentIndex];
        float animCurrentTime = _animationPlayer.currentPlayingTime % _animationPlayer.clips[_animationPlayer.currentIndex].length;

        int lastEventIndex = animEvent.Length == 0 ? -1 : animEvent.Length - 1;
        for (int i=0; i<animEvent.Length; i++)
        {
            int frame = animEvent[i].frame;
            float frameRate = clip.frameRate;
            if (animCurrentTime < frame / frameRate)
            {
                lastEventIndex = i - 1;
                break;
            }
        }

        if (((_oldAnimClipIndex == -1 || _oldAnimClipIndex != _animationPlayer.currentIndex) &&
              _animationPlayer.currentPlayingTime <= 0.0f && lastEventIndex != -1) ||
            _oldAnimEventIndex != lastEventIndex)
        {
            for (int i=0; i<animEvent.Length; i++)
            {
                for (int j=0; j<animEvent[i].method.Length; j++)
                {
                    var method = animEvent[i].method[j];
                    switch (method)
                    {
                        case CharacterAnimEventMethod.OnFootSE:
                            OnFootSE();
                            break;

                        case CharacterAnimEventMethod.OnFootEffect:
                            OnFootEffect(animEvent[i].intparam);
                            break;
                    }
                }

                if (i == lastEventIndex)
                    break;
            }
        }

        _oldAnimClipIndex = _animationPlayer.currentIndex;
        _oldAnimEventIndex = lastEventIndex;
    }

    public void SetAnimeEndCallBack(Func<AnimationPlayer, bool> callback)
    {
        animeEndCallBack = callback;
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
        public const int Gesture0 = 3;
        public const int Gesture1 = 4;
        public const int FinishingStart = 5;
        public const int FinishingLoop = 6;
        public const int FinishingHit = 7;
        public const int FinishingEnd = 8;
        public const int HandOver = 9;
        public const int Sit = 10;
        public const int Waterning = 11;
        public const int Squat = 12;
        public const int GetPause = 13;
        public const int Poketch = 14;
        public const int Spin = 15;
        public const int BikeIdle = 16;
        public const int BikeWalk = 17;
        public const int BikeRun = 18;
        public const int JumpStart = 20;
        public const int JumpLoop = 21;
        public const int JumpEnd = 22;
        public const int Gesture2 = 23;
        public const int WallWalk = 24;
        public const int FishingFinishSuccsess = 25;
        public const int Suprised = 26;
        public const int SuprisedLoop = 27;
        public const int FishingHitLoop = 28;
        public const int FishingFinishSuccsessLoop = 29;
        public const int GrassWalk = 30;
        public const int GrassRun = 31;
        public const int WateringLoop = 32;
        public const int WateringEnd = 33;
        public const int OperationLoop = 36;
        public const int OperationEnd = 37;
        public const int SwampStart = 38;
        public const int SwampLoop = 39;
        public const int SwampEnd = 40;
        public const int NaminoriStart = 65;
        public const int NaminoriLoop = 12;
        public const int NaminoriEnd = 66;
        public const int NaminoriFishingStart = 67;
        public const int NaminoriFishingLoop = 68;
        public const int NaminoriFishingHit = 69;
        public const int NaminoriFishingHitLoop = 70;
        public const int NaminoriFishingEnd = 71;
        public const int NaminoriFishingSuccess = 72;
        public const int NaminoriFishingSuccessLoop = 73;
        public const int RockClimbUp = 74;
        public const int RockClimbDown = 75;
        public const int FlyStart = 76;
        public const int FlyEnd = 77;
        public const int NaminoriOperationStart = 78;
        public const int NaminoriOperationLoop = 79;
        public const int NaminoriOperationEnd = 80;
        public const int MaxLength = 78;
    }
}