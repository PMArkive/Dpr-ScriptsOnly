using AttributeData;
using Audio;
using Dpr;
using Dpr.EvScript;
using Dpr.UI;
using Effect;
using FieldCommon;
using GameData;
using SmartPoint.Components;
using SmartPoint.Mathematics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

public class FieldPlayerEntity : FieldCharacterEntity
{
    private static readonly int _StencilRefID = Shader.PropertyToID("_StencilRef");

    public override string entityType { get => "FieldPlayer"; }

    [SerializeField]
    protected Renderer[] _hatRenderers;
    [SerializeField]
    protected Renderer[] _shoesRenderers;
    [SerializeField]
    protected GameObject _meshGroup;
    [SerializeField]
    protected GameObject _bicycleObject;
    [SerializeField]
    protected Renderer[] _rodRenderers;
    [SerializeField]
    protected Renderer _podRenderer;
    [SerializeField]
    protected Renderer _beadaruRenderer;
    [SerializeField]
    protected Renderer _mukuhawkRenderer;
    [SerializeField]
    protected Color[] _bicycleColors;
    [SerializeField]
    protected Renderer _bicycleRenderer;
    [SerializeField]
    protected int _bicycleMaterialIndex;

    public Renderer[] rodRenderers { set => _rodRenderers = value; }
    public Renderer podRenderer { get => _podRenderer; set => _podRenderer = value; }
    public GameObject meshGroup { set => _meshGroup = value; }
    public GameObject bicycleObject { get => _bicycleObject; set => _bicycleObject = value; }
    public Renderer beadaruRenderer { set => _beadaruRenderer = value; }
    public Renderer mukuhawkRenderer { set => _mukuhawkRenderer = value; }
    public Color[] bicycleColors { get => _bicycleColors; set => _bicycleColors = value; }
    public Renderer bicycleRenderer { get => _bicycleRenderer; set => _bicycleRenderer = value; }
    public int bicycleMaterialIndex { get => _bicycleMaterialIndex; set => _bicycleMaterialIndex = value; }
    public int bicycleColorIndex { get; set; }

    public void ChangeVariation(int index)
    {
        var variationIndex = Mathf.Clamp(index, 0, _variations.Length); // BUG: index equal to the length of the array is allowed
        if (variationIndex == _currentVariation)
            return;

        if (_variations[_currentVariation].root == null)
            _meshGroup.SetActive(false);
        else
            _variations[_currentVariation].root.SetActive(false);

        if (_variations[variationIndex].root == null)
            _meshGroup.SetActive(true);
        else
            _variations[variationIndex].root.SetActive(true);

        _currentVariation = variationIndex;
    }

    public int hatVariation
    {
        get
        {
            for (int i=0; i<_hatRenderers.Length; i++)
            {
                var renderer = _hatRenderers[i];
                if (renderer != null && renderer.enabled)
                    return i;
            }

            return -1;
        }
        set
        {
            for (int i=0; i<_hatRenderers.Length; i++)
            {
                var renderer = _hatRenderers[i];
                if (renderer != null)
                    renderer.enabled = value == i;
            }
        }
    }
    public int shoesVariation
    {
        get
        {
            for (int i=0; i<_shoesRenderers.Length; i++)
            {
                var renderer = _shoesRenderers[i];
                if (renderer != null && renderer.enabled)
                    return i;
            }

            return -1;
        }
        set
        {
            for (int i=0; i<_shoesRenderers.Length; i++)
            {
                var renderer = _shoesRenderers[i];
                if (renderer != null)
                    renderer.enabled = value == i;
            }
        }
    }
    public int rodVariation
    {
        get
        {
            for (int i=0; i<_rodRenderers.Length; i++)
            {
                var renderer = _rodRenderers[i];
                if (renderer != null && renderer.enabled)
                    return i;
            }

            return -1;
        }
        set
        {
            for (int i=0; i<_rodRenderers.Length; i++)
            {
                var renderer = _rodRenderers[i];
                if (renderer != null)
                    renderer.enabled = value == i;
            }
        }
    }
    public bool podVisibility
    {
        get => _podRenderer == null || _podRenderer.enabled;
        set
        {
            if (_podRenderer != null)
                _podRenderer.enabled = value;
        }
    }
    public bool beadaruVisibility
    {
        get => _beadaruRenderer == null || _beadaruRenderer.enabled;
        set
        {
            if (_beadaruRenderer != null)
                _beadaruRenderer.enabled = value;
        }
    }
    public bool mukuhawkVisibility
    {
        get => _mukuhawkRenderer == null || _mukuhawkRenderer.enabled;
        set
        {
            if (_mukuhawkRenderer != null)
                _mukuhawkRenderer.enabled = value;
        }
    }

    [NonSerialized]
    public bool isExtrudable;

    public bool DashFlag { set; get; }

    private JumpCalculator _path = new JumpCalculator();
    private bool _setupMaterials;
    [NonSerialized]
    private bool _hit_se_request;
    [NonSerialized]
    private float _hit_se_wait;
    public Vector3 InputMoveVector;

    public Func<FieldPlayerEntity, bool> LateUpdateEvent { get; set; }
    public float MoveSpeed { set; get; }

    private float _beforeAngle;
    public int FormType = -1;
    private MapAttributeTable.SheetData nowAttribute;
    private bool isAttributeStop;

    public int FashionTableID { set; get; } = -1;

    private bool FootSeWalkStartEvent = true;
    private CheckGridCollisionFunc CheckGridCollision = new CheckGridCollisionFunc();
    private int _sandFallSeq;
    private float _sandFallWait;
    private float _sandFallPosZ;
    private bool UpdateInputAngleDisable;
    private int KairikiPushObjectIndex = -1;
    private float KairikiPushTime;
    private float debugInputTime;
    private float debugInputVectolX = 1.0f;
    private bool _isCrossUpdate;
    private Vector2 _crossInputVectol;
    private Vector2 _crossStopPosition;
    private DIR _crossInputDir;
    private float _crossKey_pushTime;
    private Vector3 _eventMoveTargetPosition;
    private float _eventMoveTargetAngle;
    private bool _eventMoveEnd;
    private bool _eventRotateEnd;
    private int currentForm;
    private int nextForm;
    private Action formFinish;
    private bool changeFormRetInput;
    private BicycleJump _bicJump = new BicycleJump();
    private bool _isCycDownHillMode;
    private float _bicOldAcceleration;
    private float _bicAccelerationTime;
    private float _bicDecelerateTime;
    private bool _isBicMaxSpeed;
    private IceFloorStateType IceFloorState;
    private Vector3 IceFloorDirection;
    private int IceSlidingLevel = 1;
    private float IceSlidingSpeed;
    private bool IsIceSlope;
    private float IceFloorStopTime;
    private Vector3 IceFloorStartGridCenterPos;
    private FieldObjectMove IceSlopeDownMove = new FieldObjectMove();
    private FieldObjectRotateYaw IceSlidingRotate = new FieldObjectRotateYaw();
    private DIR IceFloorDirtyNextDir = DIR.DIR_NOT;
    private MoveFloorType CurrentMoveFloor;
    private MoveFloorType NextMoveFloor;
    private float MoveFloorTime;
    private float PrevRotateOffset;
    private FieldObjectRotateYaw MoveFloorRotate = new FieldObjectRotateYaw();
    private const float RotateAnimeOneCycleTime = 0.5f;
    private const float NaminoriCheckDistance = 0.7f;
    public const float NaminoriWaterSurfaceOfs = 0.5f;
    public bool ForcePlayNaminoriEffect;
    private EffectInstance NaminoriEffect;
    private AudioInstance NaminoriAudio;
    private bool IsPlayNaminoriEffect;
    private const float NaminoriSeWaitTime = 0.6f;
    private float NaminoriSeWait;
    private NaminoriEventRequestType NaminoriEventRequest;
    private CheckGridCollisionCheckSwimFunc CheckGridCollisionCheckSwim = new CheckGridCollisionCheckSwimFunc();
    private CheckGridCollisionCalcSwimFunc CheckGridCollisionCalcSwim = new CheckGridCollisionCalcSwimFunc();
    private CheckGridCollisionEndSwimFunc CheckGridCollisionEndSwim = new CheckGridCollisionEndSwimFunc();
    private CheckGridCollisionCalcSwimEndFunc CheckGridCollisionCalcSwimEnd = new CheckGridCollisionCalcSwimEndFunc();

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (_setupMaterials)
            return;

        var renderers = GetComponentsInChildren<Renderer>();
        var stencil = EntityManager.activeFieldPlayer == this ? 2 : 1;

        var dict = new Dictionary<Material, Material>();
        for (int i=0; i<renderers.Length; i++)
        {
            var renderer = renderers[i];
            var mats = renderer.sharedMaterials;

            var matList = new List<Material>();
            for (int j=0; j<mats.Length; j++)
            {
                var mat = mats[j];
                if (!dict.TryGetValue(mat, out Material subMat))
                {
                    subMat = new Material(mat);
                    subMat.SetInt(_StencilRefID, stencil);
                    dict.Add(mat, subMat);
                }

                matList.Add(subMat);
            }

            renderer.sharedMaterials = matList.ToArray();
        }

        _setupMaterials = true;
    }

    // TODO
    protected override void OnFootSE() { base.OnFootSE(); }

    // TODO
    protected override void OnFootEffect(int index) { base.OnFootEffect(index); }

    protected override void OnUpdate(float deltaTime)
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);
        nowAttribute = GameManager.GetAttributeTable(code);
        isAttributeStop = stop == 128;

        UpdateParts(deltaTime);
        base.OnUpdate(deltaTime);

        if (PlayerWork.isPlayerInputActive)
        {
            Vector2 hitPos = Vector2.zero;
            if (EvDataManager.Instanse.TrainerEyeCheck(ref moveVector, ref hitPos))
            {
                moveVector = Vector3.zero;
                worldPosition.x = hitPos.x;
                worldPosition.z = hitPos.y;
            }
        }

        if (PlayerWork.isPlayerInputActive)
        {
            switch (NaminoriEventRequest)
            {
                case NaminoriEventRequestType.StartSwim:
                    StartSwimEvent();
                    break;

                case NaminoriEventRequestType.EndSwim:
                    EndSwimEvent();
                    break;
            }
        }

        NaminoriEventRequest = NaminoriEventRequestType.None;

        _ = enabled;
    }

    // TODO
    protected override void OnLateUpdate(float deltaTime)
    {
        if (_bicycleRenderer != null && _propertyBlock != null && _bicycleColors.Length != 0)
        {
            _propertyBlock.Clear();
            _bicycleMaterialIndex = Mathf.Clamp(_bicycleMaterialIndex, 0, _bicycleColors.Length);
            _bicycleRenderer.GetPropertyBlock(_propertyBlock, _bicycleMaterialIndex);
            _propertyBlock.SetColor(ColorVariation._SkinColorID, _bicycleColors[bicycleColorIndex]);
            _bicycleRenderer.SetPropertyBlock(_propertyBlock, _bicycleMaterialIndex);
        }

        if (LateUpdateEvent?.Invoke(this) ?? false)
            LateUpdateEvent = null;

        LateUpdateParts(deltaTime);

        if (this == EntityManager.activeFieldPlayer && isExtrudable)
        {
            bool collided = false;

            for (int i=0; i<EntityManager.fieldCharacters.Length; i++)
            {
                var entity = EntityManager.fieldCharacters[i];
                if (entity == this)
                    continue;

                if (entity == null)
                    continue;

                if (entity.gameObject.activeInHierarchy &&
                    !entity.IsIgnorePlayerCollision &&
                    !entity.EventParams.Sit &&
                    !entity.EventParams.isNoPlayerHit)
                {
                    var entityDelta = worldPosition + moveVector - entity.worldPosition;
                    if (entityDelta.y < -1.0f || entityDelta.y > 1.0f)
                        continue;

                    entityDelta.y = 0.0f;
                    var mag = entityDelta.FastNormalize();
                    if (mag >= 1.0f)
                        continue;

                    if (CheckMapCollision_AfterCharacterHit(moveVector + (entityDelta * (1.0f - mag)), out Vector3 _, out Vector3 normal))
                    {
                        entityDelta = worldPosition + moveVector - entity.worldPosition;
                        mag = entityDelta.magnitude;

                        if (1.0 - mag > 0.0f)
                        {
                            entityDelta -= normal * Vector3.Dot(entityDelta, normal);
                            entityDelta.FastNormalize();
                            moveVector += entityDelta * (1.0f * mag);

                            if (CheckMapCollision_AfterCharacterHit(moveVector, out _, out _))
                            {
                                isExtruded = true;
                                StopCrossUpdate();
                                moveVector = Vector3.zero;

                                if (!collided)
                                    collided = true;

                                // TODO: We should go through fieldPokemonEntites too after if there was no collision
                                if (EvDataManager.Instanse.CheckPosEvent(out Vector3 worldEventPos, this))
                                    moveVector = worldEventPos - worldPosition;

                                break;
                            }
                        }
                    }

                    if (!IsOverlapObstacle(moveVector))
                        continue;

                    isExtruded = true;
                    StopCrossUpdate();
                    _bicOldAcceleration = default;
                }
            }
        }

        if (CheckIceFloor(deltaTime))
            StartIceFloor();

        if (currentSequence == SequenceID.Active && PlayerWork.isPlayerInputActive)
        {
            NextMoveFloor = CheckMoveFloorGrid(gridPosition, 0.0f);
            if (NextMoveFloor != MoveFloorType.None)
                StartMoveFloor();
        }

        if (CheckSwampDeep(deltaTime))
            StartSwampDeep();

        LateUpdateCrossInput();
        LimitHeight();
        KairikiPushObject(deltaTime);
        base.OnLateUpdate(deltaTime);
        UpdateWalkCount();
        LaetPlayHitSE(deltaTime);
    }

    private bool CheckMapCollision_AfterCharacterHit(Vector3 moveVelocity, out Vector3 afterMoveVector, out Vector3 hitNormal)
    {
        Vector3 direction = moveVelocity;
        var mag = direction.FastNormalize();

        afterMoveVector = CollisionUtility.CollideObstacle(worldPosition, 0.4f, direction, mag, out bool _, out bool isCollided,
            out float _, out hitNormal, Layer.Jump | Layer.Obstacle, worldPosition.y);

        if (!isCollided)
        {
            var collisionType = FieldGridCollision.CheckGriCollisionMoveEntity(out afterMoveVector, out hitNormal, out float _, worldPosition,
                moveVelocity, 0.4f, CheckGridCollision, FieldGridCollision.GridCollisionIgnoreDir.None);

            if (collisionType == FieldGridCollision.GridCollisionType.None)
                return false;
        }

        return true;
    }

    private bool IsOverlapObstacle(Vector3 moveVelocity)
    {
        var pos = worldPosition + new Vector3(0.0f, 0.4f, 0.0f) + moveVelocity;
        return Physics.CheckSphere(pos, 0.4f, Layer.Jump | Layer.Obstacle);
    }

    protected override bool SwitchToNext()
    {
        switch (nextSequence)
        {
            case SequenceID.Active:
                isExtrudable = true;
                break;

            case SequenceID.Jump:
                StopCrossUpdate();
                PlayerWork.isPlayerInputActive = false;
                isExtrudable = false;
                isLanding = false;
                _path.Startup(transform, DataManager.GetFieldCommonParam(ParamIndx.JumpDistance), DataManager.GetFieldCommonParam(ParamIndx.JumpHight), 0.0f);
                break;

            case SequenceID.HoleJump:
                StopCrossInputAndBicycle();
                PlayerWork.isPlayerInputActive = false;
                isExtrudable = false;
                isLanding = false;
                _path.Startup(transform, 0.0f, DataManager.GetFieldCommonParam(ParamIndx.JumpHight), 0.0f, 0.7f);
                PlayJumpStart();
                break;

            case SequenceID.Fishing:
                StopCrossInputAndBicycle();
                PlayerWork.isPlayerInputActive = false;
                break;

            case SequenceID.BicycleJump:
                StopCrossInputAndBicycle();
                PlayerWork.isPlayerInputActive = false;
                isExtrudable = false;
                isLanding = false;
                break;

            case SequenceID.SandClimbFail:
                StopCrossInputAndBicycle();
                PlayerWork.isPlayerInputActive = false;
                _sandFallSeq = 0;
                _sandFallWait = 0.0f;
                _sandFallPosZ = GridToPosition(gridPosition).y;

                if (PlayerWork.IsFormBicycle())
                {
                    AudioManager.Instance.PlaySe(AK.EVENTS.S_FI011, null);
                }
                else
                {
                    if (IsRun())
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL_R, null);
                    else
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL, null);
                }
                break;

            case SequenceID.SandClimbSucsess:
                PlayerWork.isPlayerInputActive = false;
                StopCrossUpdate();

                if (PlayerWork.IsFormBicycle())
                {
                    AudioManager.Instance.PlaySe(AK.EVENTS.S_FI010, null);
                }
                else
                {
                    if (IsRun())
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL_R, null);
                    else
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL, null);
                }
                break;

            case SequenceID.SandFall:
                PlayerWork.isPlayerInputActive = false;
                StopCrossUpdate();

                if (PlayerWork.IsFormBicycle())
                {
                    AudioManager.Instance.PlaySe(AK.EVENTS.S_FI011, null);
                }
                else
                {
                    if (IsRun())
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL_R, null);
                    else
                        AudioManager.Instance.PlaySe(AK.EVENTS.FOOTSTEPS_SOIL, null);
                }
                break;

            case SequenceID.EventMove:
                StopCrossInputAndBicycle();
                _eventMoveEnd = false;
                _eventRotateEnd = false;
                break;

            case SequenceID.FormChange:
            case SequenceID.IceFloor:
            case SequenceID.MoveFloor:
                StopCrossInputAndBicycle();
                break;

            case SequenceID.HoleOutJump:
                StopCrossInputAndBicycle();
                PlayerWork.isPlayerInputActive = false;
                _path.Startup(transform, 0.0f, 3.0f, 2.0f, 1.0f);
                break;

            default:
                isExtrudable = false;
                break;
        }

        return base.SwitchToNext();
    }

    protected override void ProcessSequence(float deltaTime)
    {
        HitSEReset();

        switch (currentSequence)
        {
            case SequenceID.Active:
                SettingAttributeFlags();
                UpdateInputOperation(deltaTime);
                break;

            case SequenceID.Jump:
                {
                    var oldPos = transform.position;

                    transform.position = _path.Process(deltaTime, out bool isFinished);
                    if (_animationPlayer.currentIndex == Animation.JumpStart && transform.position.y < oldPos.y)
                        PlayJumpLoop();

                    if (isFinished)
                    {
                        FieldManager.Instance.RequestAttributeEffect(this, FieldManager.AttributeEventType.Jump);
                        if (IsRideBicycle())
                            AudioManager.Instance.PlaySe(AK.EVENTS.S_FI038, null);

                        PlayJumpEnd();
                        nextSequence = SequenceID.Landing;
                    }
                }
                break;

            case SequenceID.Landing:
                {
                    if (IsRideBicycle() || _animationPlayer.currentPlayingTime < 0.8f)
                    {
                        if (!IsStickInput())
                            StopBicycleDecelerate();

                        isLanding = true;
                        PlayerWork.isPlayerInputActive = true;
                        nextSequence = SequenceID.Active;
                    }
                }
                break;

            case SequenceID.HoleJump:
                {
                    var oldPos = transform.position;

                    transform.position = _path.Process(deltaTime, out _);
                    if (_animationPlayer.currentIndex == Animation.JumpStart && transform.position.y < oldPos.y)
                        PlayJumpLoop();
                }
                break;

            case SequenceID.BicycleJump:
                {
                    PlayRun();

                    var jumpPos = _bicJump.Update(deltaTime, out BicycleJump.Seq jumpSeq, ref worldPosition);
                    worldPosition.x += jumpPos.x;
                    worldPosition.y = jumpPos.y;
                    worldPosition.z = jumpPos.z;

                    if (jumpSeq == BicycleJump.Seq.End)
                    {
                        PlayerWork.isPlayerInputActive = true;
                        isLanding = true;
                        nextSequence = SequenceID.Active;
                    }
                }
                break;

            case SequenceID.SandClimbFail:
                {
                    if (AttributeID.MATR_IsShiftingSand((int)nowAttribute.Attribute))
                    {
                        if (_sandFallSeq == 0)
                        {
                            if (_sandFallPosZ < worldPosition.z)
                                moveVector = new Vector3(0.0f, 0.0f, -1.0f) * DataManager.GetFieldCommonParam(ParamIndx.WalkSpd) * deltaTime;
                            else
                                _sandFallSeq = 1;
                        }

                        if (_sandFallSeq == 1)
                            moveVector = new Vector3(0.0f, 0.0f, 1.0f) * DataManager.GetFieldCommonParam(ParamIndx.WalkSpd) * deltaTime;

                        _sandFallWait = 0.0f;
                    }
                    else
                    {
                        moveVector = Vector3.zero;
                        if (_sandFallWait > 0.3333333f)
                        {
                            moveVector = Vector3.zero;
                            PlayerWork.isPlayerInputActive = true;
                            nextSequence = SequenceID.Active;
                        }

                        _sandFallWait += deltaTime;
                    }
                }
                break;

            case SequenceID.SandClimbSucsess:
                {
                    if (AttributeID.MATR_IsShiftingSand((int)nowAttribute.Attribute))
                    {
                        moveVector = new Vector3(0.0f, 0.0f, -1.0f) * GetMoveSpeed(DashFlag, deltaTime, GetBicycleGear(), false, false) * deltaTime;
                    }
                    else
                    {
                        nextSequence = SequenceID.Active;
                        PlayerWork.isPlayerInputActive = true;
                    }
                }
                break;

            case SequenceID.SandFall:
                {
                    if (AttributeID.MATR_IsShiftingSand((int)nowAttribute.Attribute))
                    {
                        moveVector = new Vector3(0.0f, 0.0f, 1.0f) * GetMoveSpeed(DashFlag, deltaTime, GetBicycleGear(), false, false) * deltaTime;
                    }
                    else
                    {
                        nextSequence = SequenceID.Active;
                        PlayerWork.isPlayerInputActive = true;
                    }
                }
                break;

            case SequenceID.EventMove:
                {
                    _eventMoveEnd = CorrectionMove(_eventMoveTargetPosition, deltaTime);
                    _eventRotateEnd = CorrectionRotate(_eventMoveTargetAngle);
                }
                break;

            case SequenceID.IceFloor:
                {
                    UpdateIceFloor(deltaTime);
                }
                break;

            case SequenceID.MoveFloor:
                {
                    UpdateMoveFloor(deltaTime);
                }
                break;

            case SequenceID.SwampDeep:
                {
                    UpdateSwampDeep(deltaTime);
                }
                break;

            case SequenceID.HoleOutJump:
                {
                    var oldPos = transform.position;

                    transform.position = _path.Process(deltaTime, out _);
                    if (_animationPlayer.currentIndex == Animation.JumpStart && transform.position.y < oldPos.y)
                        PlayJumpLoop();
                }
                break;
        }

        base.ProcessSequence(deltaTime);
    }

    public void GetInputVectorIgnoreUpdateInputAngle(out Vector2 stickL, out float stickPowerSq, float deltatime, out bool analogstick)
    {
        UpdateInputAngleDisable = true;
        GetInputVector(out stickL, out stickPowerSq, deltatime, out analogstick);
        UpdateInputAngleDisable = false;
    }

    public void GetInputVector(out Vector2 stickL, out float stickPowerSq, float deltatime, out bool analogstick)
    {
        if (PlayerWork.IsEasyInput())
        {
            stickL.x = GameController.analogStickL.x;
            stickL.y = GameController.analogStickL.y;
        }
        else
        {
            var stick = GameController.analogStickL + GameController.analogStickR;
            stickL.x = stick.x;
            stickL.y = stick.y;
            stickL.x = Mathf.Clamp(stickL.x, -1.0f, 1.0f);
            stickL.y = Mathf.Clamp(stickL.y, -1.0f, 1.0f);
        }

        stickL = InputCorrection.FieldMoveCorrection(stickL);
        stickPowerSq = stickL.sqrMagnitude;

        if (PlayerWork.IsEasyInput())
            analogstick = !GetCrossKeyVector(ref stickL, ref stickPowerSq, deltatime);
        else
            analogstick = true;
    }

    private bool IsStickInput()
    {
        return GameController.analogStickL.x != 0.0f || GameController.analogStickL.y != 0.0f ||
            GameController.digitalPad.x != 0.0f || GameController.digitalPad.y != 0.0f;
    }

    private bool GetCrossKeyVector(ref Vector2 stickL, ref float stickPowerSq, float deltatime)
    {
        if (stickPowerSq > 0.01f)
        {
            StopCrossUpdate();
            return false;
        }

        if (_isCrossUpdate)
        {
            UpdateCrossInputMove(ref stickL, ref stickPowerSq, deltatime);
            return true;
        }

        float param = DataManager.FieldCommonParam[(int)ParamIndx.CrossInputMinTime].param;
        if (GameController.digitalPad.x != 0.0f || GameController.digitalPad.y != 0.0f)
        {
            Vector2 dpadVec = new Vector2(GameController.digitalPad.x, GameController.digitalPad.y);
            LimitedCrossInput(ref dpadVec);

            if (_crossKey_pushTime == 0.0f)
            {
                switch (GetDir())
                {
                    case DIR.DIR_UP:
                        if (dpadVec.y == 1.0f)
                            _crossKey_pushTime = param + 1.0f;
                        break;

                    case DIR.DIR_DOWN:
                        if (dpadVec.y == -1.0f)
                            _crossKey_pushTime = param + 1.0f;
                        break;

                    case DIR.DIR_LEFT:
                        if (dpadVec.x == -1.0f)
                            _crossKey_pushTime = param + 1.0f;
                        break;

                    case DIR.DIR_RIGHT:
                        if (dpadVec.x == 1.0f)
                            _crossKey_pushTime = param + 1.0f;
                        break;
                }
            }

            if (dpadVec.y == 1.0f)
                _crossInputDir = DIR.DIR_UP;
            else if (dpadVec.y == -1.0f)
                _crossInputDir = DIR.DIR_DOWN;
            else if (dpadVec.x == -1.0f)
                _crossInputDir = DIR.DIR_LEFT;
            else if (dpadVec.x == 1.0f)
                _crossInputDir = DIR.DIR_RIGHT;

            if (_crossKey_pushTime <= param)
            {
                UpdateInputAngle(ref dpadVec);
                stickL = Vector2.zero;
                stickPowerSq = 0.0f;
                _crossInputVectol = Vector2.zero;
            }
            else
            {
                _crossInputVectol = dpadVec;
                stickL = dpadVec;
                stickPowerSq = dpadVec.sqrMagnitude;
                _crossKey_pushTime = param + 1.0f;
            }

            _crossKey_pushTime += deltatime;
            return true;
        }

        if (_crossKey_pushTime <= param)
        {
            StopCrossUpdate();
            _crossKey_pushTime = 0.0f;
            return false;
        }

        stickL = _crossInputVectol;
        float moveSpeed = IsRideBicycle() && GetBicycleGear() ? 2.0f : 1.0f;
        _crossStopPosition = GridToPosition(gridPosition);

        switch (_crossInputDir)
        {
            case DIR.DIR_UP:
                if (worldPosition.z < _crossStopPosition.y)
                    _crossStopPosition.y -= moveSpeed;
                break;

            case DIR.DIR_DOWN:
                if (worldPosition.z > _crossStopPosition.y)
                    _crossStopPosition.y += moveSpeed;
                break;

            case DIR.DIR_LEFT:
                if (worldPosition.x > _crossStopPosition.x)
                    _crossStopPosition.x += moveSpeed;
                break;

            case DIR.DIR_RIGHT:
                if (worldPosition.x < _crossStopPosition.x)
                    _crossStopPosition.x -= moveSpeed;
                break;
        }

        _isCrossUpdate = true;
        _crossKey_pushTime = 0.0f;
        return true;
    }

    public void StopCrossUpdate()
    {
        _crossInputDir = DIR.DIR_NOT;
        _isCrossUpdate = false;
        _crossInputVectol = default;
    }

    private void UpdateCrossInputMove(ref Vector2 stickL, ref float stickPowerSq, float deltatime)
    {
        if (!_isCrossUpdate)
            return;

        stickL = _crossInputVectol;
        stickPowerSq = _crossInputVectol.sqrMagnitude;
    }

    private void LateUpdateCrossInput()
    {
        if (!_isCrossUpdate)
            return;

        if (!IsInputStop() && moveVector != Vector3.zero)
        {
            var movedPos = worldPosition + moveVector;
            switch (_crossInputDir)
            {
                case DIR.DIR_UP:
                    if (_crossStopPosition.y < movedPos.z)
                        return;
                    moveVector.x = 0.0f;
                    moveVector.z = _crossStopPosition.y - worldPosition.z;
                    break;

                case DIR.DIR_DOWN:
                    if (_crossStopPosition.y > movedPos.z)
                        return;
                    moveVector.x = 0.0f;
                    moveVector.z = _crossStopPosition.y - worldPosition.z;
                    break;

                case DIR.DIR_LEFT:
                    if (_crossStopPosition.x > movedPos.x)
                        return;
                    moveVector.x = _crossStopPosition.x - worldPosition.x;
                    moveVector.z = 0.0f;
                    break;

                case DIR.DIR_RIGHT:
                    if (_crossStopPosition.x < movedPos.x)
                        return;
                    moveVector.x = _crossStopPosition.x - worldPosition.x;
                    moveVector.z = 0.0f;
                    break;

                default:
                    return;
            }
        }

        StopCrossInputAndBicycle();
    }

    private void LimitedCrossInput(ref Vector2 stick)
    {
        if (Math.Abs(stick.x) >= Math.Abs(stick.y))
            stick = new Vector2(stick.x >= 0.0f ? 1.0f : -1.0f, 0.0f);
        else
            stick = new Vector2(0.0f, stick.y >= 0.0f ? 1.0f : -1.0f);
    }

    public float InputAtanAngle(ref Vector2 stickL)
    {
        return (float)Math.Atan2(-stickL.x, -stickL.y);
    }

    public float InputYawAngle(float angle)
    {
        return angle * (180.0f / (float)Math.PI);
    }

    private float UpdateInputAngle(ref Vector2 stickL)
    {
        var radians = InputAtanAngle(ref stickL);

        if (UpdateInputAngleDisable)
            return radians;

        yawAngle = InputYawAngle(radians);
        float change = Math.Abs(yawAngle - _beforeAngle);

        if (170.0f <= change && change <= 190.0f)
            StopBicycleDecelerate();

        _beforeAngle = yawAngle;

        return radians;
    }

    public bool IsInputStop()
    {
        return Fader.isBusy ||
            FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF) ||
            !enabled ||
            this != EntityManager.activeFieldPlayer ||
            !PlayerWork.isPlayerInputActive ||
            Fader.fillPower > 0.1f ||
            PlayerWork.isEvolveDemo ||
            PlayerWork.isHatchDemo ||
            FieldManager.IsResume ||
            FieldConnector.IsSetupOperationRunning ||
            UIManager.IsFieldOpenMenu();
    }

    private void UpdateInputOperation(float deltaTime)
    {
        InputMoveVector = Vector3.zero;
        if (IsInputStop())
        {
            moveVector = Vector3.zero;
            return;
        }

        if (IsSwim())
        {
            if (UpdateSwim(deltaTime))
            {
                moveVector = Vector3.zero;
                return;
            }
        }
        else
        {
            if (FieldInput.PushA() && CheckSwim())
            {
                RequestStartSwimEvent();
                moveVector = Vector3.zero;
                return;
            }
        }

        if (FieldInput.PushB())
        {
            if (IsRideBicycle())
                ChangeBicycleGear(!GetBicycleGear());
        }

        GetInputVector(out Vector2 stickL, out float stickPowerSq, deltaTime, out bool stick);
        switch (PlayerWork.FieldInputMode)
        {
            case PlayerWork.InputLR:
                stickL.y = 0.0f;
                break;

            case PlayerWork.InputUD:
                stickL.x = 0.0f;
                break;

            case PlayerWork.InputCross:
                if (stickL.y * stickL.y >= stickL.x * stickL.x)
                    stickL.x = 0.0f;
                else
                    stickL.y = 0.0f;
                break;
        }

        if (_isCycDownHillMode && stickL == Vector2.zero)
        {
            StopCrossUpdate();
            stickL.y = -1.0f;
        }

        if (stickL.sqrMagnitude <= 0.01f)
        {
            if (_bicOldAcceleration <= 0.0f)
                _beforeAngle = 0.0f;

            MoveSpeed = 0.0f;
            BicycleDecelerate(deltaTime);

            if (moveVector == Vector3.zero)
                UpdateIdle();

            return;
        }

        float angle = UpdateInputAngle(ref stickL);
        DashFlag = DashJudgment(angle / Math.Sqrt(angle));

        if (!stick && !IsRideBicycle())
            DashFlag = FieldInput.OnB();

        if (!FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_SHOES_GET))
            DashFlag = false;

        MoveSpeed = CalcMoveSpeed(DashFlag, false);
        var direction = new Vector3((float)Math.Sin(angle), 0.0f, (float)Math.Cos(angle));
        InputMoveVector = direction * MoveSpeed * deltaTime;

        if (CollisionUtility.IsCollideObstacle(worldPosition, 0.4f, direction, MoveSpeed * deltaTime, Layer.Jump | Layer.Obstacle))
        {
            MoveSpeed = CalcMoveSpeed(false, true);
            InputMoveVector = direction * MoveSpeed * deltaTime;
        }

        moveVector = CollisionUtility.CollideObstacle(worldPosition, 0.4f, direction, MoveSpeed * deltaTime, out bool jump, out isExtruded, out float dotAngle, out Vector3 colNormal, Layer.Jump | Layer.Obstacle);

        FieldGridCollision.GridCollisionIgnoreDir ignoreDir = FieldGridCollision.GridCollisionIgnoreDir.None;
        if (!isExtruded)
        {
            moveVector = CollisionUtility.CollideObstacle(worldPosition - (direction * 0.4f), 0.4f, direction, MoveSpeed * deltaTime + 0.4f, out jump, out isExtruded, out dotAngle, out colNormal, Layer.Jump | Layer.Obstacle);
            moveVector -= direction * 0.4f;
        }

        if (isExtruded)
        {
            var collidedVector = CollisionUtility.CollideObstacle(worldPosition, 0.4f, direction, MoveSpeed * deltaTime, out bool exJump, out bool exIsCollided, out float exDotAngle, out Vector3 exColNormal, Layer.Jump | Layer.Obstacle);
            if (exIsCollided || isExtruded)
            {
                moveVector = collidedVector;
                jump = exJump;
                isExtruded = true;
                dotAngle = exDotAngle;
                colNormal = exColNormal;

                if (colNormal.x * colNormal.x < 0.000000009999999f)
                    ignoreDir = FieldGridCollision.GridCollisionIgnoreDir.Vert;
                else if (colNormal.z * colNormal.z < 0.000000009999999f)
                    ignoreDir = FieldGridCollision.GridCollisionIgnoreDir.Side;
                else
                    ignoreDir = FieldGridCollision.GridCollisionIgnoreDir.None;

                StopCrossUpdate();
            }
        }

        if (jump)
        {
            var landGrid = PositionToGrid(worldPosition + InputMoveVector.normalized);
            GameManager.GetAttribute(landGrid, out int code, out int stop);

            if (AttributeID.MATR_IsJumpUp(code) || AttributeID.MATR_IsJumpDown(code) ||
                AttributeID.MATR_IsJumpLeft(code) || AttributeID.MATR_IsJumpRight(code))
            {
                if (!EvDataManager.Instanse.IsRunningEvent())
                {
                    PlayerWork.isPlayerInputActive = false;
                    nextSequence = SequenceID.Jump;
                    FieldManager.Instance.RequestAttributeSE(this, FieldManager.AttributeEventType.Jump);
                    PlayJumpStart();
                    StopCrossUpdate();
                }

                return;
            }
        }

        if (IsRideBicycle())
        {
            var landGrid = PositionToGrid(worldPosition + InputMoveVector.normalized);
            GameManager.GetAttribute(landGrid, out int code, out int stop);

            if (CanEntryAttributeBycJump(code, stop, InputMoveVector.normalized, out Vector3 jumpvector) &&
                IsBicJumpObjectEntity(ref landGrid, jumpvector.x))
            {
                if (!EvDataManager.Instanse.IsRunningEvent())
                {
                    if (jumpvector.x == -1.0f)
                        yawAngle = 270.0f;

                    if (jumpvector.x == 1.0f)
                        yawAngle = 90.0f;

                    float gearBoost = GetBicycleGear() ? 3.0f : 1.0f;

                    var pos = GridToPosition(landGrid);
                    var endPos = new Vector3(pos.x, Height, pos.y) + (jumpvector * gearBoost);
                    _bicJump.SetUp(transform.position, endPos, GetBicycleGear());
                    PlayRun();

                    _bicOldAcceleration = DataManager.GetFieldCommonParam(ParamIndx.Gear4Accel);
                    _bicAccelerationTime = 10.0f;

                    PlayerWork.isPlayerInputActive = false;
                    nextSequence = SequenceID.BicycleJump;
                }

                return;
            }
        }

        if (FieldGridCollision.CheckGriCollisionMoveEntity(out Vector3 outVelocity, out Vector3 outHitNormal, out float outHitAngle,
            worldPosition, moveVector, 0.4f, CheckGridCollision, ignoreDir) == FieldGridCollision.GridCollisionType.None)
        {
            if (!isExtruded)
            {
                if (DashFlag)
                    PlayRun();
                else
                    PlayWalk();

                return;
            }
        }
        else
        {
            MoveSpeed = CalcMoveSpeed(false, true);

            if (!isExtruded)
            {
                dotAngle = outHitAngle;
                moveVector = moveVector.normalized * MoveSpeed * deltaTime;
            }

            if (FieldGridCollision.CheckGriCollisionMoveEntity(out outVelocity, worldPosition, moveVector,
                0.4f, CheckGridCollision, ignoreDir) == FieldGridCollision.GridCollisionType.None)
            {
                if (!isExtruded)
                {
                    if (DashFlag)
                        PlayRun();
                    else
                        PlayWalk();

                    return;
                }
            }
            else
            {
                moveVector = outVelocity;
                isExtruded = true;
            }
        }

        float mult = 1.0f - dotAngle;
        if (mult > 0.0f)
            mult /= 0.5f;

        if (dotAngle <= 0.5f)
        {
            if (DashFlag)
                PlayRun();
            else
                PlayWalk();
        }
        else
        {
            PlayWallWalk();
            moveVector *= mult;

            if (dotAngle > 0.8660254f && !EvDataManager.Instanse.IsContactDoor())
                HitSeRequest();
        }

        StopCrossUpdate();

        float CalcMoveSpeed(bool dashFlag, bool colHit)
        {
            if (_isCycDownHillMode)
            {
                float speed;
                if (stickL.y <= 0.0f)
                {
                    if (stickL.y >= 0.0f || stickL.x != 0.0f)
                        speed = GetMoveSpeed(dashFlag, deltaTime, GetBicycleGear(), false, false);
                    else
                        speed = GetMoveSpeed(dashFlag, deltaTime, true, false, false);
                }
                else
                {
                    speed = GetMoveSpeed(dashFlag, deltaTime, false, false, false);
                }

                if (stickL == Vector2.zero)
                    return GetMoveSpeed(dashFlag, deltaTime, false, false, false);
                else
                    return speed;
            }
            else
            {
                return GetMoveSpeed(dashFlag, deltaTime, GetBicycleGear(), colHit, false);
            }
        }
    }

    private FieldGridCollision.GridCollisionType CheckGridCollisionCore(Vector2Int grid)
    {
        if (!CanEntryAttribute(grid, worldPosition.y))
            return FieldGridCollision.GridCollisionType.NoEntry;

        if (!CanEntryNomoseGymWaterGrid(grid, worldPosition.y))
            return FieldGridCollision.GridCollisionType.NoEntry;

        return FieldGridCollision.GridCollisionType.None;
    }

    private float GetMoveSpeed(bool isDash, float deltatime, bool gear, bool colHit, bool isdebug)
    {
        _bicDecelerateTime = 0.0f;

        float baseSpeed;
        if (!IsRideBicycle() || colHit)
        {
            if (isDash)
                baseSpeed = DataManager.FieldCommonParam[(int)ParamIndx.DashSpd].param;
            else
                baseSpeed = DataManager.FieldCommonParam[(int)ParamIndx.WalkSpd].param;
        }
        else
        {
            float speed;
            float accel;
            if (gear)
            {
                speed = DataManager.FieldCommonParam[(int)ParamIndx.Gear4].param;
                accel = DataManager.FieldCommonParam[(int)ParamIndx.Gear4Accel].param;
            }
            else
            {
                speed = DataManager.FieldCommonParam[(int)ParamIndx.Gear3].param;
                accel = DataManager.FieldCommonParam[(int)ParamIndx.Gear3Accel].param;
            }

            float newSpeed = _bicOldAcceleration + accel * _bicAccelerationTime * 30.0f;
            if (speed / 0.3f <= newSpeed)
            {
                _isBicMaxSpeed = true;
                _bicAccelerationTime = Math.Min(_bicAccelerationTime + deltatime, 10.0f);
                _bicOldAcceleration = speed / 0.3f;
            }
            else
            {
                _bicAccelerationTime = Math.Min(_bicAccelerationTime + deltatime, 10.0f);
                _bicOldAcceleration = newSpeed;
            }

            baseSpeed = _bicOldAcceleration * 0.3f;
        }

        GameManager.GetAttribute(gridPosition, out int code, out int stop);

        if (AttributeID.MATR_IsShallowSnow(code))
            return baseSpeed * DataManager.FieldCommonParam[(int)ParamIndx.SnowLv1_MoveSpdRate].param;
        else if (AttributeID.MATR_IsSnowDeep(code))
            return baseSpeed * DataManager.FieldCommonParam[(int)ParamIndx.SnowLv2_MoveSpdRate].param;
        else if (AttributeID.MATR_IsSnowDeepMost(code))
            return baseSpeed * DataManager.FieldCommonParam[(int)ParamIndx.SnowLv3_MoveSpdRate].param;
        else if (AttributeID.MATR_IsSwamp(code) || AttributeID.MATR_IsSwampGrass(code))
            return baseSpeed * DataManager.FieldCommonParam[(int)ParamIndx.Swamp_MoveSpdRate].param;
        else if (AttributeID.MATR_IsLongGrass(code))
            return baseSpeed * DataManager.FieldCommonParam[(int)ParamIndx.LongGrass_MoveSpdRate].param;
        else if (code == AttributeID.MATTER_TENKAI)
            return baseSpeed * 1.0f;

        float kaidanSpd = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanSpd);
        float kaidanHeightSpdL = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanHeightSpd_L);
        float kaidanHeightSpdH = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanHeightSpd_H);
        float kaidanHeightH = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanHeight_H);

        float speedRate;
        if (kaidanHeightH * 0.5f <= Height)
            speedRate = 1.0f / kaidanHeightSpdH * (kaidanHeightH - Height);
        else
            speedRate = 1.0f / kaidanHeightSpdL * Height;

        // Bound speedRate between 0.0f and 1.0f
        speedRate = speedRate <= 1.0f ? speedRate : 1.0f;
        speedRate = speedRate < 0.0f ? 0.0f : speedRate;

        speedRate = 1.0f - (1.0f - kaidanSpd) * speedRate;
        TenkaiWwise();

        return baseSpeed * speedRate;
    }

    private bool CanEntryAttribute(Vector2Int grid, float height)
    {
        return CanEntryAttribute(grid, height, IsRideBicycle(), IsSwim());
    }

    // There's probably ways to simplify this, there's a lot of gotos in the decompiled code.
    private static bool CanEntryAttribute(Vector2Int grid, float height, bool isRideBicyclelse, bool isSwim)
    {
        GameManager.GetAttribute(grid, out int code, out int stop);
        var table = GameManager.GetAttributeTable(code);

        if (!CanEntryAttributeCommon(code, stop))
            return false;

        if (!AttributeID.MATR_IsBridge(code))
        {
            if (isRideBicyclelse)
            {
                if (AttributeID.IsBicycleNoEntory(table))
                    return false;
                else
                    return isSwim == table.Water;
            }
            else
            {
                if (AttributeID.MATR_IsTakeOffLeft(code) || AttributeID.MATR_IsTakeOffRight(code))
                    return false;
                else
                    return isSwim == table.Water;
            }
        }
        else
        {
            if (GameManager.IsHighAttribute(GameManager.GetAttributeExCodeRaw(grid), height))
            {
                if (table.Water)
                {
                    if (!isSwim)
                        return true;

                    if (isRideBicyclelse)
                    {
                        if (AttributeID.IsBicycleNoEntory(table))
                            return false;
                        else
                            return isSwim == table.Water;
                    }
                    else
                    {
                        if (AttributeID.MATR_IsTakeOffLeft(code) || AttributeID.MATR_IsTakeOffRight(code))
                            return false;
                        else
                            return isSwim == table.Water;
                    }
                }

                if (!isRideBicyclelse)
                {
                    if (AttributeID.MATR_IsBridgeV(code) || AttributeID.MATR_IsBridgeH(code))
                        return false;
                    else if (AttributeID.MATR_IsTakeOffLeft(code) || AttributeID.MATR_IsTakeOffRight(code))
                        return false;
                    else
                        return isSwim == table.Water;
                }

                if (AttributeID.IsBicycleNoEntory(table))
                    return false;
                else
                    return isSwim == table.Water;
            }
            else
            {
                if (table.Water && isSwim)
                    return true;

                if (isRideBicyclelse)
                {
                    if (AttributeID.IsBicycleNoEntory(table))
                        return false;
                    else
                        return isSwim == table.Water;
                }
                else
                {
                    if (AttributeID.MATR_IsTakeOffLeft(code) || AttributeID.MATR_IsTakeOffRight(code))
                        return false;
                    else
                        return isSwim == table.Water;
                }
            }
        }
    }

    private static bool CanEntryAttributeCommon(int code, int stop)
    {
        var table = GameManager.GetAttributeTable(code);
        if (stop == 128 || table == null || !table.Entry)
            return false;

        return true;
    }

    private static bool CanEntryAttributeBycJump(int code, int stop, Vector3 forward, out Vector3 jumpvector)
    {
        jumpvector = Vector3.zero;
        var table = GameManager.GetAttributeTable(code);

        if (table == null || stop != 128)
            return false;

        if (AttributeID.MATR_IsTakeOffLeft(code))
            jumpvector.x = -1.0f;
        else if (AttributeID.MATR_IsTakeOffRight(code))
            jumpvector.x = 1.0f;
        else
            return false;

        float angle = Vector3.SignedAngle(jumpvector, forward, Vector3.up);
        if (-30.0f < angle && angle < 30.0f)
            return true;

        return false;
    }

    private bool IsBicJumpObjectEntity(ref Vector2Int grid, float vectolx)
    {
        for (int i=0; i<EntityManager.fieldEventObjects.Length; i++)
        {
            var fieldEvent = EntityManager.fieldEventObjects[i];

            if (fieldEvent != null && fieldEvent.isActiveAndEnabled)
            {
                if (grid.x + vectolx == fieldEvent.gridPosition.x && grid.y == fieldEvent.gridPosition.y)
                    return false;
            }
        }

        return true;
    }

    private bool CanEntryNomoseGymWaterGrid(Vector2Int grid, float height)
    {
        if (EntityManager.fieldNomoseGymWater.Length == 0)
            return true;

        int level = EntityManager.fieldNomoseGymWater[0].WaterLevel;
        float waterHeight = EntityManager.fieldNomoseGymWater[0].WaterHeightLevel[level];
        var pos = Vec2ToVec3Position(GridToPosition(grid), height);

        if (waterHeight <= pos.y + CollisionUtility.CollideGround(new Vector3(pos.x, pos.y, pos.z + 0.2f), 3.0f, Layer.Ground))
        {
            if (waterHeight <= pos.y + CollisionUtility.CollideGround(new Vector3(pos.x, pos.y, pos.z - 0.2f), 3.0f, Layer.Ground))
            {
                return true;
            }
        }

        return false;
    }

    public void OnEventEnter(float deltaTime, FieldEventEntity eventEntity)
    {
        EvDataManager.Instanse?.OnEventEnter(deltaTime, eventEntity);
    }

    public void OnEventStay(float deltaTime, FieldEventEntity eventEntity)
    {
        EvDataManager.Instanse?.OnEventStay(deltaTime, eventEntity);
    }

    public void OnEventLeave(float deltaTime, FieldEventEntity eventEntity)
    {
        EvDataManager.Instanse?.OnEventLeave(deltaTime, eventEntity);
    }

    private void OnGroundTrigger()
    {
        // Empty
    }

    public void SetNormalForm([Optional] Action onfinish)
    {
        PlayerWork.SetFormNormal();
        ChangeForm(0, onfinish);
    }

    private void SettingAttributeFlags()
    {
        if (PlayerWork.zoneID == ZoneID.UNKNOWN)
            return;

        GameManager.GetAttribute(gridPosition, out int code, out int stop);
        var table = GameManager.GetAttributeTable(code);

        PlayerWork.FieldInputMode = 0;
        _isCycDownHillMode = false;

        int excode = GameManager.GetAttributeExCodeRaw(gridPosition);
        if (GameManager.IsHighAttribute(excode, Height))
        {
            if (table.Attribute == MapAttribute.MATTR_BRIDGEV_GROUND ||
                table.Attribute == MapAttribute.MATTR_BRIDGEV_GROUND_E ||
                table.Attribute == MapAttribute.MATTR_BRIDGEV_WATER ||
                table.Attribute == MapAttribute.MATTR_BRIDGEV_SAND)
            {
                PlayerWork.FieldInputMode = 2;
            }
            else if (table.Attribute == MapAttribute.MATTR_BRIDGEH_GROUND ||
                table.Attribute == MapAttribute.MATTR_BRIDGEH_GROUND_E ||
                table.Attribute == MapAttribute.MATTR_BRIDGEH_WATER ||
                table.Attribute == MapAttribute.MATTR_BRIDGEH_SAND)
            {
                PlayerWork.FieldInputMode = 1;
            }
            else if (table.Attribute == MapAttribute.MATTR_BRIDGE_GROUND &&
                FlagWork.GetSysFlag(Dpr.EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD))
            {
                _isCycDownHillMode = true;
            }
        }

        if (table.Attribute == MapAttribute.MATTR_SLOPE_02 && currentSequence == SequenceID.Active)
        {
            if (IsRideBicycle() && GetBicycleGear())
            {
                nextSequence = SequenceID.SandClimbSucsess;
                return;
            }

            StopBicycleDecelerate();
            nextSequence = SequenceID.SandClimbFail;
            PlayerWork.isPlayerInputActive = false;
        }
        else if (table.Attribute == MapAttribute.MATTR_SLOPE_01 && currentSequence == SequenceID.Active)
        {
            PlayerWork.isPlayerInputActive = false;
            nextSequence = SequenceID.SandFall;
        }
    }

    private void HitSeRequest()
    {
        _hit_se_request = true;
    }

    private void HitSEReset()
    {
        _hit_se_request = false;
    }

    private void LaetPlayHitSE(float time)
    {
        if (!_hit_se_request)
        {
            _hit_se_wait = DataManager.GetFieldCommonParam(ParamIndx.Hit_se_wait);
        }
        else
        {
            _hit_se_wait -= time;
            if (_hit_se_wait > 0.0f)
                return;

            AudioManager.Instance.PlaySe(AK.EVENTS.S_FI002, null);
            _hit_se_wait = DataManager.GetFieldCommonParam(ParamIndx.Hit_se_wait_loop);
        }
    }

    private bool DashJudgment(double inputforce)
    {
        switch (_animationPlayer.currentIndex)
        {
            case Animation.Walk:
            case Animation.BikeWalk:
            case Animation.GrassWalk:
                return DataManager.GetFieldCommonParam(ParamIndx.InputRange_WalkToRun) <= inputforce;

            case Animation.Run:
            case Animation.BikeRun:
            case Animation.GrassRun:
                return DataManager.GetFieldCommonParam(ParamIndx.InputRange_RunToWalk) <= inputforce;

            default:
                return DataManager.GetFieldCommonParam(ParamIndx.InputRange_Wait) <= inputforce;
        }
    }

    public void SetEventCorrectionMove(Vector3 position, float angle)
    {
        _eventMoveTargetPosition = position;
        _eventMoveTargetAngle = angle;
    }

    public void StartEventCorrectionMove()
    {
        nextSequence = SequenceID.EventMove;
    }

    public bool IsEventCorrectionMoveEnd()
    {
        return _eventMoveEnd && _eventRotateEnd;
    }

    private bool CorrectionMove(Vector3 position, float deltaTime)
    {
        float mult = GetMoveSpeed(false, deltaTime, GetBicycleGear(), false, false) * deltaTime * 0.8f;
        Vector3 fullVector = (position - worldPosition);
        moveVector = fullVector.normalized * mult;

        if (moveVector != Vector3.zero)
        {
            if (mult * mult <= fullVector.sqrMagnitude)
            {
                PlayWalk();
                return false;
            }

            moveVector = Vector3.zero;
            worldPosition.x = position.x;
            worldPosition.z = position.z;
        }

        PlayIdle();
        return true;
    }

    private bool CorrectionRotate(float angle)
    {
        float delta = angle - yawAngle;
        delta = delta >= 0.0f ? delta : delta + 360.0f;
        delta = delta <= 180.0f ? delta : delta - 360.0f;
        delta %= 360.0f;
        delta *= 0.4f;

        if (delta * delta >= 0.01f)
            yawAngle += delta;
        else
            yawAngle = angle;

        return yawAngle == angle;
    }

    private bool IsIgnoreWalkCountZone(ZoneID zoneId)
    {
        switch (zoneId)
        {
            case ZoneID.UNION01:
            case ZoneID.UNION02:
            case ZoneID.UNION03:
                return true;

            default:
                return false;
        }
    }

    private bool IsIgnoreEggHatchCountZone(ZoneID zoneId)
    {
        switch (zoneId)
        {
            case ZoneID.D11R0101:
            case ZoneID.UGSECRETBASE01:
            case ZoneID.UGSECRETBASE02:
            case ZoneID.UGSECRETBASE03:
            case ZoneID.UGSECRETBASE04:
            case ZoneID.UGAASECRETBASE01:
            case ZoneID.UGAASECRETBASE02:
            case ZoneID.UGAASECRETBASE03:
            case ZoneID.UGABSECRETBASE01:
            case ZoneID.UGABSECRETBASE02:
            case ZoneID.UGABSECRETBASE03:
            case ZoneID.UGBASECRETBASE01:
            case ZoneID.UGBASECRETBASE02:
            case ZoneID.UGBASECRETBASE03:
            case ZoneID.UGCASECRETBASE01:
            case ZoneID.UGCASECRETBASE02:
            case ZoneID.UGCASECRETBASE03:
            case ZoneID.UGDASECRETBASE01:
            case ZoneID.UGDASECRETBASE02:
            case ZoneID.UGDASECRETBASE03:
            case ZoneID.UGEASECRETBASE01:
            case ZoneID.UGEASECRETBASE02:
            case ZoneID.UGEASECRETBASE03:
            case ZoneID.UGFASECRETBASE01:
            case ZoneID.UGFASECRETBASE02:
            case ZoneID.UGFASECRETBASE03:
                return true;

            default:
                return false;
        }
    }

    // TODO
    private void UpdateWalkCount() { }

    private bool NoWalkUpdateAttribute()
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);
        
        if (GameManager.GetAttributeTable(code).Attribute == MapAttribute.MATTR_SLOPE_02 &&
            currentSequence == SequenceID.Active)
        {
            if (IsRideBicycle() && GetBicycleGear())
                return false;
            else
                return true;
        }

        return false;
    }

    private bool IsEncount()
    {
        GameManager.GetAttribute(gridPosition, out int code, out int stop);
        var table = GameManager.GetAttributeTable(code);
        int attex = GameManager.GetAttributeExCodeRaw(gridPosition);
        switch (table.Attribute)
        {
            case MapAttribute.MATTR_BRIDGE_GROUND_E:
            case MapAttribute.MATTR_BRIDGEV_GROUND_E:
            case MapAttribute.MATTR_BRIDGEH_GROUND_E:
                return !GameManager.IsHighAttribute(attex, Height);

            default:
                return table.Encount;
        }
    }

    public void ChangeForm(int form, Action onFinish)
    {
        if (currentForm != form)
        {
            changeFormRetInput = PlayerWork.isPlayerInputActive;
            PlayerWork.isPlayerInputActive = false;
            nextForm = form;
            formFinish = onFinish;
            ChangeAnime(0.0f);
        }
        else
        {
            onFinish?.Invoke();
        }
    }

    private void ChangeAnime(float time)
    {
        currentForm = nextForm;

        switch (currentForm)
        {
            case 0:
            case 2:
                _meshGroup.SetActive(true);
                _bicycleObject.SetActive(false);
                break;

            case 1:
                _meshGroup.SetActive(false);
                _bicycleObject.SetActive(true);
                break;
        }

        GetIdleAnimationIndex(out int index, out float duration);
        _animationPlayer.Play(index);

        PlayerWork.isPlayerInputActive = changeFormRetInput;
        formFinish?.Invoke();
    }

    public void JumpPlayerActionEvent(string label)
    {
        EvDataManager.Instanse.JumpLabel(label, null);
    }

    // TODO
    private void KairikiPushObject(float deltaTime) { }

    private void LimitHeight()
    {
        if (FieldManager.Instance == null)
            return;

        if (IsSwim() || !isLanding)
            return;

        if (FieldManager.Instance.IsNoEntry(gridPosition, worldPosition))
            return;

        if (!GameManager.IsHighAttribute(GameManager.GetAttributeExCodeRaw(gridPosition), worldPosition.y))
            return;

        if (CollisionUtility.IsOverCollideGround(worldPosition, 0.5f, Layer.Ground))
        {
            moveVector.y = CollisionUtility.OverCollideGround(worldPosition, 0.0f, Layer.Ground, true);
        }
        else
        {
            var colliders = CollisionUtility.OverrapSphere(transform, new Vector3(0.0f, 0.5f, 0.0f), 0.0f, out int count, Layer.Ground);
            if (count > 0)
            {
                for (int i=0; i<colliders.Length; i++)
                {
                    var collider = colliders[i] as BoxCollider;
                    if (collider)
                    {
                        float height = collider.size.y * 0.5f + collider.center.y + collider.transform.position.y;
                        if (moveVector.y < height)
                            moveVector.y = height;
                    }
                }
            }
        }
    }

    public void WorkApplyVisibility()
    {
        watchVisibility = FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_POKETCH_GET);
        hatVariation = FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_GET_CAP) ? 0 : 1;
        shoesVariation = FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_SHOES_GET) ? 0 : 1;
        bicycleColorIndex = PlayerWork.bicycleColor;
    }

    public void StopCrossInputAndBicycle()
    {
        StopCrossUpdate();
        StopBicycleDecelerate();
    }

    public void TenkaiWwise()
    {
        var attex = GameManager.GetAttributeEx(gridPosition, Height);
        float rtpc = 0.0f;

        if (attex.Code == (int)MapAttributeEx.MATTREX_TENKAI_KAIDAN ||
            attex.Code == (int)MapAttributeEx.MATTREX_TENKAI_YUKA)
        {
            var heightL = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanHeight_L);
            var heightH = DataManager.GetFieldCommonParam(ParamIndx.Tenkai_KaidanHeight_H);

            var height = (Height - heightL) / (heightH - heightL) * 100.0f;
            if (height >= 0.3f)
                rtpc = height > 100.0f ? 100.0f : height;
        }

        AudioManager.Instance.SetRTPCValue(AK.GAME_PARAMETERS.ARC_STAIRS, rtpc);
    }

    private void UpdateIdle()
    {
        if (_animationPlayer.currentIndex == Animation.Gesture0 ||
            _animationPlayer.currentIndex == Animation.Gesture1 ||
            _animationPlayer.currentIndex == Animation.Gesture2)
        {
            if (_animationPlayer.currentRemaingTime > 0.2f)
                return;

            _animationPlayer.Play(GetNextGesture(), Math.Max(_animationPlayer.currentRemaingTime, 0.0f));
        }
        else if (_animationPlayer.currentIndex != Animation.Idle)
        {
            PlayIdle();
        }
        else if (_animationPlayer.currentPlayingTime > 5.0f)
        {
            _animationPlayer.Play(GetNextGesture(), 0.2f);
        }
    }

    private int GetNextGesture()
    {
        var rand = UnityEngine.Random.Range(0, 3);

        switch (_animationPlayer.currentIndex)
        {
            case Animation.Idle:
                switch (rand)
                {
                    case 0: return Animation.Gesture0;
                    case 1: return Animation.Gesture1;
                    default: return Animation.Gesture2;
                }

            case Animation.Gesture0:
                switch (rand)
                {
                    case 0: return Animation.Gesture1;
                    case 1: return Animation.Gesture2;
                    default: return Animation.Idle;
                }

            case Animation.Gesture1:
                switch (rand)
                {
                    case 0: return Animation.Gesture0;
                    case 1: return Animation.Gesture2;
                    default: return Animation.Idle;
                }

            case Animation.Gesture2:
                switch (rand)
                {
                    case 0: return Animation.Gesture0;
                    case 1: return Animation.Gesture1;
                    default: return Animation.Idle;
                }

            default:
                return Animation.Idle;
        }
    }

    public void PlayIdle(float duration)
    {
        GetIdleAnimationIndex(out int index, out _);
        _animationPlayer.Play(index, duration);

        if (!FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = true;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_END, null);
        }
    }

    public void PlayIdle()
    {
        if (IsRideBicycle())
        {
            switch (PlayerWork.FieldInputMode)
            {
                case PlayerWork.InputLR:
                case PlayerWork.InputUD:
                    if (_animationPlayer.IsPlaying)
                        _animationPlayer.Stop();
                    return;
            }
        }

        GetIdleAnimationIndex(out int index, out float duration);
        _animationPlayer.Play(index, duration);

        if (!FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = true;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_END, null);
        }
    }

    public override void GetIdleAnimationIndex(out int index, out float duration)
    {
        if (IsRideBicycle())
        {
            index = Animation.BikeIdle;
            duration = 0.2f;
        }
        else if (IsSwim())
        {
            index = Animation.NaminoriLoop;
            duration = 0.2f;
        }
        else
        {
            base.GetIdleAnimationIndex(out index, out duration);
        }
    }

    public bool IsIdle()
    {
        return _animationPlayer.currentIndex == Animation.Idle ||
               _animationPlayer.currentIndex == Animation.BikeIdle;
    }

    public void GetWalkAnimationIndex(out int index, out float duration)
    {
        duration = 0.2f;

        if (IsRideBicycle())
            index = Animation.BikeWalk;
        else if (IsSwim())
            index = Animation.NaminoriLoop;
        else if (AttributeID.MATR_IsGrass(nowAttribute.Code))
            index = Animation.GrassWalk;
        else if (AttributeID.MATR_IsLongGrass(nowAttribute.Code))
            index = Animation.GrassWalk;
        else
            index = Animation.Walk;
    }

    public void PlayWalk()
    {
        GetWalkAnimationIndex(out int index, out float duration);
        _animationPlayer.Play(index, duration);

        if (FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_START, null);
        }
    }

    public bool IsWalk()
    {
        return _animationPlayer.currentIndex == Animation.Walk ||
               _animationPlayer.currentIndex == Animation.BikeWalk ||
               _animationPlayer.currentIndex == Animation.GrassWalk;
    }

    public void PlayRun()
    {
        int index;

        if (IsRideBicycle())
            index = Animation.BikeRun;
        else if (IsSwim())
            index = Animation.NaminoriLoop;
        else if (AttributeID.MATR_IsGrass(nowAttribute.Code))
            index = Animation.GrassRun;
        else if (AttributeID.MATR_IsLongGrass(nowAttribute.Code))
            index = Animation.GrassRun;
        else
            index = Animation.Run;

        _animationPlayer.Play(index, 0.2f);

        if (FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_START, null);
        }
    }

    public bool IsRun()
    {
        return _animationPlayer.currentIndex == Animation.Run ||
               _animationPlayer.currentIndex == Animation.BikeRun ||
               _animationPlayer.currentIndex == Animation.GrassRun;
    }

    public void PlayWallWalk()
    {
        int index;
        if (IsRideBicycle())
            index = Animation.BikeWalk;
        else if (IsSwim())
            index = Animation.NaminoriLoop;
        else if (AttributeID.MATR_IsGrass(nowAttribute.Code))
            index = Animation.GrassWalk;
        else if (AttributeID.MATR_IsLongGrass(nowAttribute.Code))
            index = Animation.GrassWalk;
        else
            index = Animation.WallWalk;

        _animationPlayer.Play(index, 0.2f);

        if (FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_START, null);
        }
    }

    public void PlayNaminoriStart()
    {
        _animationPlayer.Play(Animation.NaminoriStart, 0.1f);

        if (FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_START, null);
        }
    }

    public void PlayNaminoriEnd()
    {
        _animationPlayer.Play(Animation.NaminoriEnd, 0.1f);

        if (!FootSeWalkStartEvent)
        {
            FootSeWalkStartEvent = true;
            AudioManager.Instance.PlaySe(AK.EVENTS.WALK_END, null);
        }
    }

    public void PlayNaminoriLoop()
    {
        _animationPlayer.Play(Animation.NaminoriLoop, 0.2f);
    }

    public void PlayJumpStart()
    {
        if (IsRideBicycle())
            _animationPlayer.Play(Animation.BikeWalk, 0.2f);
        else if (IsSwim())
            _animationPlayer.Play(Animation.JumpStart, 0.2f);
        else
            _animationPlayer.Play(Animation.JumpStart, 0.2f, 0.1333333f);
    }

    public void PlayJumpLoop()
    {
        if (IsRideBicycle())
        {
            _animationPlayer.Play(Animation.BikeWalk, 0.2f);
        }
        else
        {
            _ = IsSwim(); // Result ignored
            _animationPlayer.Play(Animation.JumpLoop, 0.2f);
        }
    }

    public void PlayJumpEnd()
    {
        if (IsRideBicycle())
            return;

        _ = IsSwim(); // Result ignored
        _animationPlayer.Play(Animation.JumpEnd, 0.2f);
    }

    public void PlayHandOver()
    {
        _animationPlayer.Play(Animation.HandOver, 0.2f);
    }

    public void PlaySit()
    {
        _animationPlayer.Play(Animation.Sit, 0.2f);
    }

    public void PlaySquat()
    {
        _animationPlayer.Play(Animation.Squat, 0.2f);
    }

    public void PlayGetPause()
    {
        _animationPlayer.Play(Animation.GetPause, 0.2f);
    }

    public void PlayPoketchStart()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriOperationStart, 0.2f);
        else
            _animationPlayer.Play(Animation.Poketch, 0.2f);
    }

    public void PlayPoketchLoop()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriOperationLoop, 0.2f);
        else
            _animationPlayer.Play(Animation.OperationLoop, 0.2f);
    }

    public void PlayPoketchEnd()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriOperationEnd, 0.2f);
        else
            _animationPlayer.Play(Animation.OperationEnd, 0.2f);
    }

    public bool IsPlayPoketchLoop()
    {
        if (IsSwim())
            return GetAnimationPlayer().currentIndex == Animation.NaminoriOperationLoop;
        else
            return GetAnimationPlayer().currentIndex == Animation.OperationLoop;
    }

    public void PlaySwampStart()
    {
        _animationPlayer.Play(Animation.SwampStart, 0.2f);
    }

    public void PlaySwampLoop()
    {
        _animationPlayer.Play(Animation.SwampLoop, 0.2f);
    }

    public void PlaySwampEnd()
    {
        _animationPlayer.Play(Animation.SwampEnd, 0.2f);
    }

    public void PlaySpin(bool restart = false)
    {
        if (restart)
        {
            PlayIdle();
            _animationPlayer.Play(Animation.Spin);
        }
        else
        {
            _animationPlayer.Play(Animation.Spin, 0.2f);
        }
    }

    public void PlayWatering()
    {
        _animationPlayer.Play(Animation.Waterning, 0.2f);
        VisiblePodMove.SetValue(0.0f);
        VisiblePodMove.MoveTime(1.0f, 0.4f);
    }

    public void PlayWateringLoop()
    {
        _animationPlayer.Play(Animation.WateringLoop, 0.2f);
    }

    public void PlayWateringEnd()
    {
        _animationPlayer.Play(Animation.WateringEnd, 0.2f);
        VisiblePodMove.SetValue(1.0f);
        VisiblePodMove.MoveTime(0.0f, 0.4f);
    }

    public void PlayFlyStart()
    {
        _animationPlayer.Play(Animation.FlyStart);
    }

    public void PlayFlyEnd()
    {
        _animationPlayer.Play(Animation.FlyEnd);
    }

    public void PlayRockClimbUp()
    {
        _animationPlayer.Play(Animation.RockClimbUp, 0.1f);
    }

    public void PlayRockClimbDown()
    {
        _animationPlayer.Play(Animation.RockClimbDown, 0.1f);
    }

    public bool IsFishingStart()
    {
        return _animationPlayer.currentIndex == Animation.NaminoriFishingStart ||
               _animationPlayer.currentIndex == Animation.FinishingStart;
    }

    public void PlayFishingStart()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingStart);
        else
            _animationPlayer.Play(Animation.FinishingStart);
    }

    public void PlayFishingLoop()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingLoop);
        else
            _animationPlayer.Play(Animation.FinishingLoop);
    }

    public void PlayFishingHit()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingHit);
        else
            _animationPlayer.Play(Animation.FinishingHit);
    }

    public void PlayFishingHitLoop()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingHitLoop, 0.2f);
        else
            _animationPlayer.Play(Animation.FishingHitLoop, 0.2f);
    }

    public void PlayFishingEnd()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingEnd);
        else
            _animationPlayer.Play(Animation.FinishingEnd);
    }

    public void PlayFishingSuccess()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingSuccess);
        else
            _animationPlayer.Play(Animation.FishingFinishSuccsess);
    }

    public void PlayFishingSuccessLoop()
    {
        if (IsSwim())
            _animationPlayer.Play(Animation.NaminoriFishingSuccessLoop, 0.2f);
        else
            _animationPlayer.Play(Animation.FishingFinishSuccsessLoop, 0.2f);
    }

    // TODO
    private void BicycleDecelerate(float deltatime)
    {
        _bicAccelerationTime = 0.0f;
        if (_bicOldAcceleration <= 0.0f)
            return;

        if (IsRideBicycle())
        {
            var speed = DataManager.GetFieldCommonParam(GetBicycleGear() ? ParamIndx.BicStopSpd_High : ParamIndx.BicStopSpd_Low);
            var newAccel = _bicOldAcceleration + speed * _bicDecelerateTime * 30.0f;
            _bicOldAcceleration = newAccel > 0.0f ? newAccel : 0.0f;
            _bicDecelerateTime = Mathf.Min(_bicDecelerateTime + deltatime, 10.0f);


        }

        _bicOldAcceleration = 0.0f;
    }

    // TODO
    public void SetRideBicycle([Optional] Action onfinish) { }

    public bool IsRideBicycle()
    {
        return PlayerWork.IsFormBicycle();
    }

    private void ChangeBicycleGear(bool gear)
    {
        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            return;

        PlayerWork.bicycleGear = gear;
        _isBicMaxSpeed = false;

        if (gear)
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.S_FI007, null);
            FieldManager.Instance.CallEffect(EffectFieldID.EF_F_CYCLE_GEAR_04, transform, null, null);
        }
        else
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.S_FI008, null);
        }
    }

    private bool GetBicycleGear()
    {
        return PlayerWork.bicycleGear;
    }

    public void StopBicycleDecelerate()
    {
        _bicOldAcceleration = 0.0f;
        _bicAccelerationTime = 0.0f;
    }

    // TODO
    public void MaxBicycleDecelerate() { }

    // TODO
    public void SetIceFloorDirty() { }

    // TODO
    private bool CheckIceFloor(float deltaTime) { return false; }

    // TODO
    private Vector3 CalcIceMoveDirection(Vector3 inputVector) { return Vector3.zero; }

    // TODO
    private void StartIceFloor() { }

    // TODO
    private void EndIceFloor() { }

    // TODO
    private void UpdateIceFloor(float deltaTime) { }

    // TODO
    private Vector3 CalcAdjustIceFloorMoveDirection() { return Vector3.zero; }

    // TODO
    private void CheckColSnowBall(Vector3 direction, float speed) { }

    // TODO
    private void CrashSnowBall(FieldObjectEntity entity) { }

    // TODO
    private bool CheckColIceFloor(Vector3 direction, float speed, out Vector3 outVelocity)
    {
        outVelocity = Vector3.zero;
        return false;
    }

    // TODO
    private bool CheckColNpcIceFloor(Vector3 direction, float speed) { return false; }

    // TODO
    private float UpdateIceSpeed(float deltaTime) { return 0.0f; }

    // TODO
    private void CheckIceSlope() { }

    // TODO
    private Vector2Int CheckIceSlopeFloor() { return Vector2Int.zero; }

    // TODO
    private bool IsIceGrid(Vector2Int grid, float height) { return false; }

    // TODO
    private bool CheckMoveFloor(float deltaTime) { return false; }

    // TODO
    private MoveFloorType CheckMoveFloorGrid(Vector2Int grid, float height) { return MoveFloorType.None; }

    // TODO
    private void StartMoveFloor() { }

    // TODO
    private void EndMoveFloor() { }

    // TODO
    private void UpdateMoveFloor(float deltaTime) { }

    // TODO
    private Vector3 GetMoveFloorDirection() { return Vector3.zero; }

    // TODO
    private bool CheckColMoveFloor(Vector3 direction, float speed, out Vector3 outVelocity)
    {
        outVelocity = Vector3.zero;
        return false;
    }

    // TODO
    public void ChangeSwim(bool swim) { }

    public bool IsSwim()
    {
        return PlayerWork.IsFormSwim();
    }

    private Vector3 CalcCheckFrontGridDirection()
    {
        var forward = transform.forward;
        forward.y = 0.0f;
        return forward.normalized;
    }

    // TODO
    public bool CheckSwim() { return false; }

    // TODO
    private FieldGridCollision.GridCollisionType CheckGridCollisionCheckSwimCore(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }

    // TODO
    public Vector3 CalcSwimTargetPosition() { return Vector3.zero; }

    // TODO
    private FieldGridCollision.GridCollisionType CheckGridCollisionCalcSwimCore(Vector2Int grid, float waterPositionY) { return FieldGridCollision.GridCollisionType.None; }

    // TODO
    private bool UpdateSwim(float deltaTime) { return false; }

    // TODO
    private bool CheckEndSwim(Vector2 inputDir) { return false; }

    // TODO
    private FieldGridCollision.GridCollisionType CheckGridCollisionEndSwimCore(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }

    // TODO
    public Vector3 CalcSwimEndTargetPosition() { return Vector3.zero; }

    // TODO
    private FieldGridCollision.GridCollisionType CheckGridCollisionCalcSwimEndCore(Vector2Int grid, float landPositionY) { return FieldGridCollision.GridCollisionType.None; }

    public void RequestStartSwimEvent()
    {
        if (PlayerWork.transitionZoneID == ZoneID.UNKNOWN)
            NaminoriEventRequest = NaminoriEventRequestType.StartSwim;
    }

    private void RequestEndSwimEvent()
    {
        NaminoriEventRequest = NaminoriEventRequestType.EndSwim;
    }

    public void StartSwimEvent()
    {
        if (PlayerWork.transitionZoneID == ZoneID.UNKNOWN)
            JumpPlayerActionEvent("ev_hiden_naminori");
    }

    private void EndSwimEvent()
    {
        JumpPlayerActionEvent("ev_hiden_naminori_end");
    }

    // TODO
    public void AppearSwimBiidaru(float ofs, float time) { }

    // TODO
    public void DisappearSwimBiidaru(float ofs, float time) { }

    // TODO
    public void UpdateSwimEffect(float time) { }

    // TODO
    public void PlaySwimEffect() { }

    private void PlayNaminoriLoopSE(float time)
    {
        NaminoriSeWait += time;

        if (NaminoriSeWait >= 0.6f)
        {
            NaminoriAudio = AudioManager.Instance.PlaySe(AK.EVENTS.S_FI033, instance =>
            {
                if (NaminoriAudio == instance)
                    NaminoriAudio = null;
            });
            NaminoriSeWait = 0.0f;
        }
    }

    // TODO
    public void PlayWaterFallUpEffect() { }

    // TODO
    public void PlayWaterFallDownEffect() { }

    private void PlayWaterFallEffectCommon(float yawAngle)
    {
        StopSwimEffect();

        IsPlayNaminoriEffect = true;
        FieldManager.Instance.CallEffect(EffectFieldID.EF_F_WAZA_WATERFALL,
            BiidaruTransform,
            new Vector3(0.0f, 0.5f, 0.0f),
            new Vector3(0.0f, yawAngle, 0.0f),
            instance => NaminoriEffect = instance,
            null);
    }

    public void StopSwimEffect()
    {
        IsPlayNaminoriEffect = false;

        if (NaminoriEffect != null)
        {
            NaminoriEffect.Stop();
            NaminoriEffect = null;
        }

        if (NaminoriAudio != null)
        {
            NaminoriAudio.Stop();
            NaminoriAudio = null;
        }

        NaminoriSeWait = 0.0f;
    }

    public bool IsBusySwimEffect()
    {
        return IsPlayNaminoriEffect;
    }

    private void UpdateParts(float deltaTime)
    {
        UpdateBiidaru(deltaTime);
    }

    private void LateUpdateParts(float deltaTime)
    {
        UpdateVisiblePod(deltaTime);
        UpdateBiidaruNode();
        UpdateSwimEffect(deltaTime);
    }

    public Transform BiidaruTransform { get; set; }

    private Vector3 BiidaruPosOriginal;
    private Vector3 BiidaruMoveStartPos;
    private Vector3 BiidaruMoveEndPos;
    private FieldFloatMove BiidaruMoveTime = new FieldFloatMove();

    public void ResetBiidaruOffset()
    {
        BiidaruMoveStartPos = Vector3.zero;
        BiidaruMoveEndPos = Vector3.zero;

        BiidaruMoveTime.SetValue(0.0f);
    }

    private void MoveBiidaruOffset(Vector3 start, Vector3 end, float time)
    {
        BiidaruMoveStartPos = start;
        BiidaruMoveEndPos = end;

        BiidaruMoveTime.SetValue(0.0f);
        BiidaruMoveTime.MoveTime(1.0f, time);
    }

    private void UpdateBiidaru(float deltaTime)
    {
        BiidaruMoveTime.Update(deltaTime);
    }

    private void UpdateBiidaruNode()
    {
        if (BiidaruTransform == null)
        {
            var mcl = transform.FindDeep("mcl_00");
            if (mcl != null)
            {
                BiidaruTransform = mcl.transform;
                BiidaruPosOriginal = BiidaruTransform.localPosition;
            }
        }

        if (BiidaruTransform != null)
            BiidaruTransform.localPosition = BiidaruPosOriginal + Vector3.Lerp(BiidaruMoveStartPos, BiidaruMoveEndPos, BiidaruMoveTime.CurrentValue);
    }

    public FieldFloatMove VisiblePodMove { get; set; } = new FieldFloatMove();

    public void VisiblePod(bool visible)
    {
        VisiblePodMove.SetValue(visible ? 0.0f : 1.0f);
        VisiblePodMove.MoveTime(visible ? 1.0f : 0.0f, 0.4f);
    }

    private void UpdateVisiblePod(float deltaTime)
    {
        if (!VisiblePodMove.IsBusy)
            return;

        VisiblePodMove.Update(deltaTime);

        var renderer = _podRenderer as SkinnedMeshRenderer;
        if (renderer != null)
            renderer.rootBone.localScale = Vector3.one * Mathf.Lerp(0.2f, 1.0f, VisiblePodMove.CurrentValue);

        _podRenderer.enabled = VisiblePodMove.IsBusy || VisiblePodMove.CurrentValue != 0.0f;
    }

    public Transform GetPodEffectAttachTransform()
    {
        var renderer = _podRenderer as SkinnedMeshRenderer;

        if (renderer != null)
            return renderer.rootBone.Find("Eff_attach");
        else
            return null;
    }

    private EffectInstance RockClimbEffect;

    // TODO
    public bool CheckRockClimbing(FieldObjectEntity eventObject) { return false; }

    // TODO
    public void CalcRockClimbingTargetPosition(FieldObjectEntity eventObject, out Vector3 climbStart, out Vector3 climbEnd, out Vector3 standPos)
    {
        climbStart = Vector3.zero;
        climbEnd = Vector3.zero;
        standPos = Vector3.zero;
    }

    // TODO
    public Vector3 CalcRockClimbingAnotherTalkPosition(FieldObjectEntity eventObject) { return Vector3.zero; }

    // TODO
    private Vector3 CalcRockClimbingDirection(FieldObjectEntity eventObject) { return Vector3.zero; }

    // TODO
    public void PlayRockClimbEffect() { }

    // TODO
    public void StopRockClimbEffect() { }

    private DIR SwampDeepInputDir;
    private int SwampDeepInputCount;
    private SwampPhaseType SwampPhase;
    private FieldObjectMove SwampMove = new FieldObjectMove();
    private FieldFloatMove SwampWait = new FieldFloatMove();
    private bool isPlayedSwampStartEffect;
    private bool isSwampLoopEffect;

    // TODO
    private bool CheckSwampDeep(float deltaTime) { return false; }

    // TODO
    private void StartSwampDeep() { }

    // TODO
    private void EndSwampDeep() { }

    // TODO
    private void UpdateSwampDeep(float deltaTime) { }

    // TODO
    private bool IsSwampDeepGrid(Vector2Int grid, float height) { return false; }

    private const float WaterFallUpCheckDistance = 0.7f;
    private const float WaterFallDownCheckDistance = 0.7f;

    // TODO
    private bool CheckWaterfallDown(Vector2 inputDir) { return false; }

    // TODO
    public Vector3 CalcWaterfallDownTargetPosition() { return Vector3.zero; }

    // TODO
    public bool CheckWaterfallUp() { return false; }

    // TODO
    public Vector3 CalcWaterfallUpTargetPosition() { return Vector3.zero; }

    // TODO
    public void WaterfallUpEvent() { }

    // TODO
    private void WaterfallDownEvent() { }

    public class SequenceID : FieldCharacterEntity.SequenceID
    {
        public const int Jump = 16385;
        public const int Landing = 16386;
        public const int HoleJump = 16387;
        public const int Fishing = 16388;
        public const int BicycleJump = 16389;
        public const int SandClimbFail = 16390;
        public const int SandClimbSucsess = 16391;
        public const int SandFall = 16392;
        public const int EventMove = 16393;
        public const int FormChange = 16400;
        public const int IceFloor = 16401;
        public const int MoveFloor = 16402;
        public const int SwampDeep = 16403;
        public const int HoleOutJump = 16404;
        protected const int User = 16384;
    }

    public class CheckGridCollisionFunc : FieldGridCollision.ICheckGridFunc
    {
        public FieldGridCollision.GridCollisionType Check(Vector2Int grid)
        {
            var player = EntityManager.activeFieldPlayer;
            if (player != null && player.CanEntryAttribute(grid, player.worldPosition.y))
            {
                return player.CanEntryNomoseGymWaterGrid(grid, player.worldPosition.y) ?
                    FieldGridCollision.GridCollisionType.None :
                    FieldGridCollision.GridCollisionType.NoEntry;
            }
            else
            {
                return FieldGridCollision.GridCollisionType.NoEntry;
            } 
        }
    }

    private enum IceFloorStateType : int
    {
        None = 0,
        Slip = 1,
        SlopeDown = 2,
    }

    private enum MoveFloorType : int
    {
        None = 0,
        Left = 1,
        Right = 2,
        Back = 3,
        Front = 4,
    }

    private enum NaminoriEventRequestType : int
    {
        None = 0,
        StartSwim = 1,
        EndSwim = 2,
    }

    public class CheckGridCollisionCheckSwimFunc : FieldGridCollision.ICheckGridFunc
    {
        // TODO
        public FieldGridCollision.GridCollisionType Check(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }
    }

    public class CheckGridCollisionCalcSwimFunc : FieldGridCollision.ICheckGridFunc
    {
        public float waterPositionY;

        // TODO
        public FieldGridCollision.GridCollisionType Check(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }
    }

    public class CheckGridCollisionEndSwimFunc : FieldGridCollision.ICheckGridFunc
    {
        // TODO
        public FieldGridCollision.GridCollisionType Check(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }
    }

    public class CheckGridCollisionCalcSwimEndFunc : FieldGridCollision.ICheckGridFunc
    {
        public float landPositionY;

        // TODO
        public FieldGridCollision.GridCollisionType Check(Vector2Int grid) { return FieldGridCollision.GridCollisionType.None; }
    }

    private enum SwampPhaseType : int
    {
        Start = 0,
        Start_Move = 1,
        Loop = 2,
        End = 3,
    }
}