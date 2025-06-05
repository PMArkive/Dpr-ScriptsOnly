using Audio;
using Dpr.EvScript;
using Dpr.Field;
using System;
using UnityEngine;

public class EvEntityCommand
{
    public EntityType entityType;
    private FieldObjectEntity _entity;
    private EvData.Script _moveData;
    private int _moveIndex;
    private float _moveUpdateTime;
    private int _moveLoopCount;
    private float _moveGrid;
    private float _moveEndTime;
    private Vector3 _moveOffset;
    private Vector3 _moveStartPos;
    private float _moveStartRot;
    private bool _moveStop;
    private Balloon _moveBallon;
    private float _moveRotateStart;
    private float _moveRotateEnd;
    private Vector3 _moveVector3;
    private bool _isMoveRotateClockWise = true;
    private float _moveStartFrame;
    private bool _dirPause;
    private bool _anmPause;
    private Vector3 _neckRotate;
    private bool _isResetIdleAnimEnable = true;
    private bool _isNeckUpdate;
    private bool _isNeckRotate = true;
    private Transform _neckTarget;
    private float _neckAngle;
    private float _neckAngleDiff;
    private FieldCharacterEntity _charEntity;
    private FieldPlayerEntity _playerEntity;
    private bool _isStopWalkAnime;
    private float _forceDuration = -1.0f;

    public EvEntityCommand(FieldObjectEntity entity)
    {
        entityType = EntityType.Obj;

        switch (entity.entityType)
        {
            case "FieldPlayer":
                entityType = EntityType.Chara;
                _playerEntity = entity as FieldPlayerEntity;
                _charEntity = entity as FieldCharacterEntity;
                break;

            case "FieldCharacter":
                entityType = EntityType.Chara;
                _charEntity = entity as FieldCharacterEntity;
                break;

            case "FieldPokemon":
                entityType = EntityType.Poke;
                break;
        }

        _entity = entity;
    }

    public void ScriptMove(float deltatime)
    {
        UpdateEventNeck(deltatime);

        if (_moveData == null)
            return;

        if (_moveUpdateTime == 0.0f)
        {
            _moveIndex++;
            SetMoveData();
            if (_moveData == null)
                return;
        }

        if (_moveStop)
            return;

        _moveUpdateTime += deltatime;
        _moveStartPos.y = _entity.Height;

        var command = (EvCmdID.NAME)_moveData.Commands[_moveIndex].Arg[0].data;
        float currentTime = Math.Min(_moveUpdateTime / _moveEndTime, 1.0f);
        Vector3 deltaVector = Vector3.zero;

        switch (command)
        {
            case EvCmdID.NAME.AC_UP:
                deltaVector.z = -currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_DOWN:
                deltaVector.z = currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_LEFT:
                deltaVector.x = currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_RIGHT:
                deltaVector.x = -currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_DIR_U:
            case EvCmdID.NAME.AC_DIR_R:
            case EvCmdID.NAME.AC_DIR_D:
            case EvCmdID.NAME.AC_DIR_L:
            case EvCmdID.NAME.AC_DIR_VAL:
            case EvCmdID.NAME.AC_DIR_UP_CENTER:
            case EvCmdID.NAME.AC_DIR_DOWN_CENTER:
            case EvCmdID.NAME.AC_DIR_LEFT_CENTER:
            case EvCmdID.NAME.AC_DIR_RIGHT_CENTER:
                float angleDelta = FieldCalc.DiffAngle(_moveRotateEnd, _moveRotateStart);
                if (!_dirPause)
                {
                    if (_isMoveRotateClockWise)
                        _entity.yawAngle = _moveRotateStart + currentTime * angleDelta;
                    else
                        _entity.yawAngle = _moveRotateStart + currentTime * (angleDelta - 360.0f);
                }
                break;

            case EvCmdID.NAME.AC_MARK_GYOE:
                if (!GameManager.fieldCamera.IsMoveStop())
                {
                    _moveUpdateTime = deltatime;
                }
                else if (_moveBallon == null)
                {
                    _moveBallon = FieldCanvas.SetBalloon(0, _entity.transform);
                    AudioManager.Instance.CreateSe(AK.EVENTS.S_FI004).Play(null);
                }
                break;

            case EvCmdID.NAME.AC_WORLD_X:
            case EvCmdID.NAME.AC_HERO_MATCH_X:
                deltaVector.x = currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_WORLD_Z:
            case EvCmdID.NAME.AC_HERO_MATCH_Z:
                deltaVector.z = currentTime * _moveGrid;
                _entity.worldPosition = _moveStartPos + deltaVector;
                if (_moveGrid == 0.0f)
                    _moveUpdateTime = _moveEndTime;
                break;

            case EvCmdID.NAME.AC_UP_CENTER:
            case EvCmdID.NAME.AC_DOWN_CENTER:
            case EvCmdID.NAME.AC_LEFT_CENTER:
            case EvCmdID.NAME.AC_RIGHT_CENTER:
                deltaVector.x = currentTime * _moveVector3.x;
                deltaVector.z = currentTime * _moveVector3.z;
                _entity.worldPosition = _moveStartPos + deltaVector;
                break;

            case EvCmdID.NAME.AC_INDEX_ANIME_WAIT:
                if (_entity.GetAnimationPlayer().currentRemaingTime <= 0.0f)
                {
                    _moveEndTime = 0.0f;
                }
                else
                {
                    _moveEndTime = 999.0f;
                    _moveUpdateTime = deltatime;
                }
                break;

            case EvCmdID.NAME.AC_MARK_EMO:
                if (!GameManager.fieldCamera.IsMoveStop())
                    _moveUpdateTime = deltatime;
                else if (_moveBallon == null)
                    _moveBallon = FieldCanvas.SetBalloon(_moveData.Commands[_moveIndex].Arg[1].data, _entity.transform);
                break;

            case EvCmdID.NAME.AC_NECK_ROTATE:
                var charaEntity = _entity as FieldCharacterEntity;
                if (charaEntity != null)
                    charaEntity.NeckAngle = _neckRotate * currentTime;
                break;
        }

        if (_moveUpdateTime < _moveEndTime)
            return;

        _moveUpdateTime = 0.0f;
        if (_moveBallon != null)
            FieldCanvas.DeleteBalloon(_moveBallon);

        _moveBallon = null;
    }

    public void SetScriptMoveData(EvData.Script evmove, float startFrame = 0.0f)
    {
        ScriptMovePause(false);

        _moveData = evmove;
        _moveBallon = null;
        _moveIndex = -1;
        _moveLoopCount = 0;
        _moveUpdateTime = 0.0f;
        _moveStartFrame = startFrame;

        ForceScriptMove();
    }

    public void ForceScriptMove()
    {
        if (!_entity.gameObject.activeInHierarchy)
            _entity.gameObject.SetActive(true);

        _entity.nextSequence = FieldObjectEntity.SequenceID.ScriptMove;
    }

    public bool IsScriptMoveEnd()
    {
        return _moveData == null;
    }

    public void ScriptMovePause(bool flag)
    {
        _moveStop = flag;
    }

    private void SetAnimation(int anime, float duration = 0.0f, bool restart = false)
    {
        if (!_entity.gameObject.activeInHierarchy)
            return;

        if (entityType == EntityType.Obj)
            return;

        int animIndex = anime;
        float animDuration = duration;
        switch (anime)
        {
            case 0:
                if (!_isResetIdleAnimEnable)
                    return;

                if (_playerEntity != null)
                    _playerEntity.GetIdleAnimationIndex(out animIndex, out animDuration);
                else if (_charEntity != null)
                    _charEntity.GetIdleAnimationIndex(out animIndex, out animDuration);
                else
                {
                    var pokeEntity = _entity as FieldPokemonEntity;
                    if (pokeEntity != null)
                        animIndex = pokeEntity.GetIdleAnimationIndex();
                }
                break;

            case 1:
                if (_isStopWalkAnime)
                    return;

                if (_playerEntity != null)
                    _playerEntity.GetWalkAnimationIndex(out animIndex, out animDuration);
                else if (_charEntity != null)
                    animIndex = _charEntity.GetWalkAnimationIndex();
                else
                {
                    var pokeEntity = _entity as FieldPokemonEntity;
                    if (pokeEntity != null)
                        animIndex = pokeEntity.GetWalkAnimationIndex();
                }
                break;
        }

        if (_forceDuration >= 0.0f)
            animDuration = _forceDuration;

        if (_entity.GetAnimationPlayer().currentIndex == animIndex && restart)
        {
            _entity.GetAnimationPlayer().RePlay(_moveStartFrame);
        }
        else
        {
            if (_moveStartFrame == 0.0f)
            {
                _entity.GetAnimationPlayer().Play(animIndex, animDuration);
            }
            else
            {
                _entity.GetAnimationPlayer().PlayFrame(animIndex, animDuration, _moveStartFrame, true);
                _moveStartFrame = 0.0f;
            }
        }

        ApplyAnimSpeed();
    }

    private void SetMoveData()
    {
        if (_moveData == null)
            return;

        _moveStartPos = _entity.worldPosition;
        _isMoveRotateClockWise = true;
        _moveUpdateTime = 0.0f;
        _moveGrid = 0.0f;
        _moveEndTime = 0.0f;
        _moveStartRot = _entity.yawAngle;

        while (true)
        {
            var command = _moveData.Commands[_moveIndex].Arg;

            switch ((EvCmdID.NAME)command[0].data)
            {
                case EvCmdID.NAME.AC_UP:
                    _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _moveGrid += _moveOffset.z + Mathf.Abs(_moveStartPos.z) - _entity.gridPosition.y;
                    _moveEndTime = _moveGrid * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;

                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                    SetAnimation(command.Count < 4 ? 1 : 0);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_DOWN:
                    _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _moveGrid += _moveOffset.z + _entity.gridPosition.y - Mathf.Abs(_moveStartPos.z);
                    _moveEndTime = _moveGrid * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;

                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                    SetAnimation(command.Count < 4 ? 1 : 0);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_LEFT:
                    _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _moveGrid += _moveOffset.x - (_entity.gridPosition.x - Mathf.Abs(_moveStartPos.x));
                    _moveEndTime = _moveGrid * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;

                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                    SetAnimation(command.Count < 4 ? 1 : 0);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_RIGHT:
                    _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _moveGrid += _moveOffset.x - (Mathf.Abs(_moveStartPos.x) - _entity.gridPosition.x);
                    _moveEndTime = _moveGrid * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;

                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                    SetAnimation(command.Count < 4 ? 1 : 0);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_LOOP: // BUG: This whole command is weird and loops infinitely
                    {
                        float loopCount = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                        int startCommand = (int)BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0);

                        if (loopCount < 0.0f)
                            _moveIndex = startCommand;

                        if (loopCount <= _moveLoopCount)
                        {
                            _moveLoopCount = 0; // BUG: Adding _moveIndex++; here might fix it idk
                        }
                        else
                        {
                            _moveLoopCount++;
                            _moveIndex = startCommand;
                        }
                    }
                    break; 

                case EvCmdID.NAME.AC_DIR_U:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetDirMoveTime();

                    _moveRotateStart = _entity.transform.localEulerAngles.y;
                    _moveRotateEnd = 180.0f;
                    _isMoveRotateClockWise = command.Count == 2;

                    if (GetIsDirPlayWalking())
                        SetAnimation(1);

                    StopFootEffect(true);
                    return;

                case EvCmdID.NAME.AC_DIR_R:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetDirMoveTime();

                    _moveRotateStart = _entity.transform.localEulerAngles.y;
                    _moveRotateEnd = 270.0f;
                    _isMoveRotateClockWise = command.Count == 2;

                    if (GetIsDirPlayWalking())
                        SetAnimation(1);

                    StopFootEffect(true);
                    return;

                case EvCmdID.NAME.AC_DIR_D:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetDirMoveTime();

                    _moveRotateStart = _entity.transform.localEulerAngles.y;
                    _moveRotateEnd = 0.0f;
                    _isMoveRotateClockWise = command.Count == 2;

                    if (GetIsDirPlayWalking())
                        SetAnimation(1);

                    StopFootEffect(true);
                    return;

                case EvCmdID.NAME.AC_DIR_L:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetDirMoveTime();

                    _moveRotateStart = _entity.transform.localEulerAngles.y;
                    _moveRotateEnd = 90.0f;
                    _isMoveRotateClockWise = command.Count == 2;

                    if (GetIsDirPlayWalking())
                        SetAnimation(1);

                    StopFootEffect(true);
                    return;

                case EvCmdID.NAME.ACMD_END:
                default:
                    _moveOffset = Vector3.zero;
                    _moveData = null;
                    SetAnimation(0);
                    StopFootEffect(false);
                    ScritpStopState();
                    _forceDuration = -1.0f;
                    return;

                case EvCmdID.NAME.AC_DIR_VAL:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    if (_moveEndTime < 0.0f)
                        _moveEndTime = GetDirMoveTime();

                    _moveRotateStart = _entity.transform.localEulerAngles.y;
                    _moveRotateEnd = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0);
                    _isMoveRotateClockWise = command.Count == 3;

                    if (GetIsDirPlayWalking())
                        SetAnimation(1);

                    StopFootEffect(true);
                    return;

                case EvCmdID.NAME.AC_WAIT:
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    SetAnimation(0);
                    return;

                case EvCmdID.NAME.AC_MARK_GYOE:
                case EvCmdID.NAME.AC_MARK_EMO:
                    _moveEndTime = 1.5f;
                    return;

                case EvCmdID.NAME.AC_WORLD_X:
                    _moveGrid = -BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) - _entity.worldPosition.x + _moveOffset.x;
                    _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    SetAnimation(1);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_WORLD_Z:
                    _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) - _entity.worldPosition.z + _moveOffset.z;
                    _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    SetAnimation(1);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_HERO_MATCH_X:
                    _moveGrid = EntityManager.activeFieldPlayer.worldPosition.x - _entity.worldPosition.x + _moveOffset.x;
                    _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    SetAnimation(1);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_HERO_MATCH_Z:
                    _moveGrid = EntityManager.activeFieldPlayer.worldPosition.z - _entity.worldPosition.z + _moveOffset.z;
                    _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) / 30.0f;
                    SetAnimation(1);
                    StopFootEffect(false);
                    return;

                case EvCmdID.NAME.AC_UP_CENTER:
                    {
                        _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);

                        _ = Vector3.zero;

                        _moveVector3.x = -_entity.gridPosition.x - _entity.worldPosition.x;
                        _moveVector3.z = _entity.gridPosition.y - (int)_moveGrid - _entity.worldPosition.z;

                        _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                        SetAnimation(1);
                        StopFootEffect(false);
                    }
                    return;

                case EvCmdID.NAME.AC_DOWN_CENTER:
                    {
                        _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);

                        _ = Vector3.zero;

                        _moveVector3.x = -_entity.gridPosition.x - _entity.worldPosition.x;
                        _moveVector3.z = _entity.gridPosition.y + (int)_moveGrid - _entity.worldPosition.z;

                        _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                        SetAnimation(1);
                        StopFootEffect(false);
                    }
                    return;

                case EvCmdID.NAME.AC_LEFT_CENTER:
                    {
                        _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);

                        _ = Vector3.zero;

                        _moveVector3.x = -(_entity.gridPosition.x - (int)_moveGrid) - _entity.worldPosition.x;
                        _moveVector3.z = _entity.gridPosition.y - _entity.worldPosition.z;

                        _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                        SetAnimation(1);
                        StopFootEffect(false);
                    }
                    return;

                case EvCmdID.NAME.AC_RIGHT_CENTER:
                    {
                        _moveGrid = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);

                        _ = Vector3.zero;

                        _moveVector3.x = -(_entity.gridPosition.x + (int)_moveGrid) - _entity.worldPosition.x;
                        _moveVector3.z = _entity.gridPosition.y - _entity.worldPosition.z;

                        _moveEndTime = Math.Abs(_moveGrid) * BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetWalkTime() * _moveGrid / 30.0f;

                        SetAnimation(1);
                        StopFootEffect(false);
                    }
                    return;

                case EvCmdID.NAME.AC_DIR_UP_CENTER:
                    {
                        _ = Vector3.zero;

                        _moveRotateStart = _entity.transform.localEulerAngles.y;

                        var rotation = new Vector3(-_entity.gridPosition.x, _entity.worldPosition.y, _entity.gridPosition.y - BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0));
                        _moveRotateEnd = Quaternion.LookRotation(rotation - _entity.worldPosition).eulerAngles.y;

                        _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetDirMoveTime();

                        if (GetIsDirPlayWalking())
                            SetAnimation(1);

                        StopFootEffect(true);
                    }
                    return;

                case EvCmdID.NAME.AC_DIR_DOWN_CENTER:
                    {
                        _ = Vector3.zero;

                        _moveRotateStart = _entity.transform.localEulerAngles.y;

                        var rotation = new Vector3(-_entity.gridPosition.x, _entity.worldPosition.y, _entity.gridPosition.y + BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0));
                        _moveRotateEnd = Quaternion.LookRotation(rotation - _entity.worldPosition).eulerAngles.y;

                        _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetDirMoveTime();

                        if (GetIsDirPlayWalking())
                            SetAnimation(1);

                        StopFootEffect(true);
                    }
                    return;

                case EvCmdID.NAME.AC_DIR_LEFT_CENTER:
                    {
                        _ = Vector3.zero;

                        _moveRotateStart = _entity.transform.localEulerAngles.y;

                        var rotation = new Vector3(-_entity.gridPosition.x + BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0), _entity.worldPosition.y, _entity.gridPosition.y);
                        _moveRotateEnd = Quaternion.LookRotation(rotation - _entity.worldPosition).eulerAngles.y;

                        _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetDirMoveTime();

                        if (GetIsDirPlayWalking())
                            SetAnimation(1);

                        StopFootEffect(true);
                    }
                    return;

                case EvCmdID.NAME.AC_DIR_RIGHT_CENTER:
                    {
                        _ = Vector3.zero;

                        _moveRotateStart = _entity.transform.localEulerAngles.y;

                        var rotation = new Vector3(-_entity.gridPosition.x - BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0), _entity.worldPosition.y, _entity.gridPosition.y);
                        _moveRotateEnd = Quaternion.LookRotation(rotation - _entity.worldPosition).eulerAngles.y;

                        _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0) / 30.0f;
                        if (_moveEndTime < 0.0f)
                            _moveEndTime = GetDirMoveTime();

                        if (GetIsDirPlayWalking())
                            SetAnimation(1);

                        StopFootEffect(true);
                    }
                    return;

                case EvCmdID.NAME.AC_VANISH_ON:
                    if (_entity.EventParams.VanishFlagIndex > 0)
                    {
                        EvDataManager.Instanse.SetFlag(_entity.EventParams.VanishFlagIndex, true);
                        _entity.gameObject.SetActive(false);
                    }
                    break;

                case EvCmdID.NAME.AC_VANISH_OFF:
                    if (_entity.EventParams.VanishFlagIndex > 0)
                    {
                        EvDataManager.Instanse.SetFlag(_entity.EventParams.VanishFlagIndex, false);
                        _entity.gameObject.SetActive(true);
                    }
                    break;

                case EvCmdID.NAME.AC_DIR_PAUSE_ON:
                    SetDirPause(true);
                    break;

                case EvCmdID.NAME.AC_DIR_PAUSE_OFF:
                    SetDirPause(false);
                    break;

                case EvCmdID.NAME.AC_ANM_PAUSE_ON:
                    SetAnimPause(true);
                    break;

                case EvCmdID.NAME.AC_ANM_PAUSE_OFF:
                    SetAnimPause(false);
                    break;

                case EvCmdID.NAME.AC_PC_BOW:
                case EvCmdID.NAME.AC_HIDE_PULLOFF:
                case EvCmdID.NAME.AC_HERO_BANZAI:
                case EvCmdID.NAME.AC_MARK_SAISEN:
                case EvCmdID.NAME.AC_HERO_BANZAI_UKE:
                case EvCmdID.NAME.ACMD_NOT:
                    break;

                case EvCmdID.NAME.AC_INDEX_ANIME:
                    SetAnimation((int)BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0),
                        command.Count < 3 ? 0.0f : BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0),
                        true);
                    break;

                case EvCmdID.NAME.AC_INDEX_ANIME_WAIT:
                    _moveEndTime = 999.0f;
                    return;

                case EvCmdID.NAME.AC_NECK_ROTATE:
                    _neckRotate.x = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _neckRotate.y = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0);
                    _neckRotate.z = BitConverter.ToSingle(BitConverter.GetBytes(command[3].data), 0);
                    _moveEndTime = BitConverter.ToSingle(BitConverter.GetBytes(command[4].data), 0) / 30.0f;
                    return;

                case EvCmdID.NAME.AC_OFFSET:
                    _moveOffset.x = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    _moveOffset.y = BitConverter.ToSingle(BitConverter.GetBytes(command[2].data), 0);
                    _moveOffset.z = BitConverter.ToSingle(BitConverter.GetBytes(command[3].data), 0);
                    break;

                case EvCmdID.NAME.AC_INVISIBLE_ON:
                    _entity.gameObject.SetActive(false);
                    break;

                case EvCmdID.NAME.AC_INVISIBLE_OFF:
                    _entity.gameObject.SetActive(true);
                    break;

                case EvCmdID.NAME.AC_FACE_INDEX:
                    {
                        var charaEntity = _entity as FieldCharacterEntity;
                        if (charaEntity != null)
                            charaEntity.SetEyePattern((int)BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0));
                    }
                    break;

                case EvCmdID.NAME.AC_STOP_WALK_ANIME:
                    _isStopWalkAnime = (int)BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0) == 1;
                    return;

                case EvCmdID.NAME.AC_ANIME_DURATION:
                    _forceDuration = BitConverter.ToSingle(BitConverter.GetBytes(command[1].data), 0);
                    return;
            }

            _moveIndex++;
        }
    }

    public void ScritpStopState()
    {
        _entity.nextSequence = FieldObjectEntity.SequenceID.ScriptStop;
    }

    public void ScritpStopStateEnd()
    {
        if (_entity.currentSequence == FieldObjectEntity.SequenceID.ScriptMove ||
            _entity.currentSequence == FieldObjectEntity.SequenceID.ScriptStop ||
            _entity.nextSequence == FieldObjectEntity.SequenceID.ScriptMove ||
            _entity.nextSequence == FieldObjectEntity.SequenceID.ScriptStop)
            _entity.nextSequence = FieldObjectEntity.SequenceID.Active;
    }

    public void ReleaseMoveData()
    {
        _moveData = null;
    }

    public void SetResetIdleAnimEnable(bool enable)
    {
        _isResetIdleAnimEnable = enable;
    }

    private void SetDirPause(bool pause)
    {
        _dirPause = pause;
    }

    private void SetAnimPause(bool pause)
    {
        _anmPause = pause;
        ApplyAnimSpeed();
    }

    private void ApplyAnimSpeed()
    {
        _entity.GetAnimationPlayer().SetAnimSpeed(_anmPause ? 0.0f : 1.0f);
    }

    public void SetEventNeckRotate(Transform target)
    {
        if (entityType != EntityType.Chara)
            return;

        if (target == null)
            return;

        _isNeckUpdate = true;
        _neckTarget = target;
        _isNeckRotate = true;

        CalcNeckRotate();
        _entity.nextSequence = FieldObjectEntity.SequenceID.ScriptMove;
    }

    private bool UpdateEventNeck(float deltatime)
    {
        if (entityType != EntityType.Chara)
            return false;

        if (!_isNeckUpdate)
            return false;

        if (_isNeckRotate)
        {
            _charEntity.NeckAngle.x = _neckAngle;
            CalcNeckRotate();
        }
        else
        {
            _charEntity.NeckAngle.x = 0.0f;
            if (Math.Abs(_neckAngleDiff) <= Math.Abs(_neckAngle))
            {
                var animPlayer = _entity.GetAnimationPlayer();
                animPlayer.Play(_charEntity != null ? _charEntity.GetWalkAnimationIndex() : 1);
                _charEntity.yawAngle += _neckAngleDiff;
                _neckAngle -= _neckAngleDiff;
            }
            else
            {
                _isNeckRotate = true;
                var animPlayer = _entity.GetAnimationPlayer();

                if (_charEntity != null)
                {
                    _charEntity.GetIdleAnimationIndex(out int index, out float _);
                    animPlayer.Play(index);
                }
                else
                {
                    animPlayer.Play(0);
                }
                
                _charEntity.yawAngle += _neckAngle;
            }
        }

        return true;
    }

    private void CalcNeckRotate()
    {
        var delta = _neckTarget.position - _charEntity.worldPosition;
        var rotatedAngle = Quaternion.LookRotation(delta.normalized).eulerAngles;
        _neckAngle = FieldCalc.DiffAngle(_charEntity.yawAngle, rotatedAngle.y);
        _isNeckRotate = Math.Abs(_neckAngle) < 45.0f;

        if (_isNeckRotate)
            return;

        var cross = Vector3.Cross(_charEntity.transform.forward, delta);
        var angle = Vector3.Angle(_charEntity.transform.forward, delta);
        var sign = cross.y >= 0.0f ? 1.0f : -1.0f;

        _neckAngle = sign * angle;
        _neckAngleDiff = _neckAngle >= 0.0f ? 10.0f : -10.0f;
    }

    public void ReleaseEventNeck()
    {
        _neckTarget = null;
        _isNeckUpdate = false;
        _isNeckRotate = true;
        _charEntity.NeckAngle.x = 0.0f;
        ScritpStopState();
    }

    private void StopFootEffect(bool stop)
    {
        if (_charEntity != null)
            _charEntity.IsStopFootEffect = stop;
    }

    private bool GetIsDirPlayWalking()
    {
        var angleDelta = FieldCalc.DiffAngle(_moveRotateEnd, _moveRotateStart);

        if (_isMoveRotateClockWise)
            return Mathf.Abs(angleDelta) >= 30.0f;
        else
            return Mathf.Abs(angleDelta - 360.0f) >= 30.0f;
    }

    private float GetDirMoveTime()
    {
        var angleDelta = FieldCalc.DiffAngle(_moveRotateEnd, _moveRotateStart);

        if (_isMoveRotateClockWise)
            return Mathf.Abs(angleDelta) / 180.0f;
        else
            return Mathf.Abs(angleDelta - 360.0f) / 180.0f;
    }

    private float GetWalkTime()
    {
        if (EntityManager.activeFieldPlayer.DashFlag)
            return 8.0f;
        else
            return 16.0f;
    }

    public enum EntityType : int
    {
        Chara = 0,
        Poke = 1,
        Obj = 2,
    }
}