using Dpr.EvScript;
using Dpr.RouteSearch;
using System;
using UnityEngine;

public class FieldObjectEntity : BaseEntity
{
    public override string entityType { get => "FieldObject"; }

    [NonSerialized]
    public Vector3 moveVector = Vector3.zero;
    [NonSerialized]
    public bool isExtruded;
    [NonSerialized]
    public bool isLanding = true;

    public Vector3 oldMoveVector { set; get; }
    public Vector4 locatorDirect
    {
        set
        {
            if (value.x >= 0.0f)
                SetPositionDirect(new Vector3(-value.x, value.w, value.y));
            else
                SetPositionDirect(new Vector3(value.x, value.w, value.y));

            moveVector = Vector3.zero;
            oldGridPosition = gridPosition;
            SetYawAngleDirect(value.z * 90.0f);
        }
    }

    private FieldObjectRouteMove _routeMove;

    public FieldObjectRouteMove RouteMove
    {
        get
        {
            if (_routeMove == null)
                _routeMove = new FieldObjectRouteMove(this);

            return _routeMove;
        }
    }
    public bool IsBusyRouteMove { get => _routeMove != null && _routeMove.IsBusy; }
    public Vector2Int gridPosition
    {
        get => PositionToGrid(worldPosition);
        set
        {
            worldPosition.x = -value.x;
            worldPosition.z = value.y;
        }
    }
    public Vector2Int gridPositionDirect
    {
        get => PositionToGrid(transform.position);
        set
        {
            var pos = transform.position;
            SetPositionDirect(new Vector3(-value.x, pos.y, value.y));
        }
    }

    public bool IsIgnorePlayerCollision;
    private EvEntityCommand _evEntityCmd;

    public EvEntityCommand EvEntityCmd
    {
        get
        {
            if (_evEntityCmd == null)
                _evEntityCmd = new EvEntityCommand(this);

            return _evEntityCmd;
        }
    }

    public Vector2Int oldGridPosition { set; get; }
    public float Height
    {
        get => transform.position.y;
        set
        {
            var pos = transform.position;
            transform.position = new Vector3(pos.x, value, pos.y);
        }
    }

    [NonSerialized]
    public Vector3[] logPosition = new Vector3[3];
    [NonSerialized]
    public byte logcount;
    private bool _scaleChangeFlag;
    private float _scaleStart;
    private float _scaleEnd;
    private float _scaleTime;
    private float _scaleProgressTime;
    [NonSerialized]
    public EvDataManager.EntityParam EventParams = new EvDataManager.EntityParam();

    public static Vector2 GridToPosition(Vector2Int grid)
    {
        return new Vector2(-grid.x, grid.y);
    }

    public static Vector2Int PositionToGrid(Vector3 position)
    {
        return new Vector2Int((int)(0.5f - position.x), (int)(0.5f + position.z));
    }

    public static Vector3 Vec2ToVec3Position(in Vector2 position, float height)
    {
        return new Vector3(position.x, height, position.y);
    }

    public static Vector2 Vec3ToVec2Position(in Vector3 position)
    {
        return new Vector2(position.x, position.z);
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (isActiveAndEnabled && _routeMove != null)
            _routeMove.Update(deltaTime);
    }

    protected override void OnLateUpdate(float deltaTime)
    {
        base.OnLateUpdate(deltaTime);

        oldGridPosition = PositionToGrid(worldPosition);
        worldPosition += moveVector;
        oldMoveVector = moveVector;
        moveVector = Vector3.zero;
        isExtruded = false;

        if (isLanding)
        {
            float collide = CollisionUtility.CollideGround(worldPosition, 1.0f, Layer.Ground);
            worldPosition.y += collide;
        }

        var log = logPosition[0];
        if (Mathf.Abs(log.x - worldPosition.x) < 1.0f && Mathf.Abs(log.y - worldPosition.y) < 1.0f && Mathf.Abs(log.z - worldPosition.z) < 1.0f)
        {
            ChangeScale(deltaTime);
            return;
        }

        // This is presumed, very hard to understand this code
        int top = logPosition.Length - 1;
        while (top - 1 >= 0)
        {
            logPosition[top].x = logPosition[top-1].x;
            logPosition[top].y = logPosition[top-1].y;
            logPosition[top].z = logPosition[top-1].z;
            top--;
        }

        logPosition[0].x = worldPosition.x;
        logPosition[0].y = worldPosition.y;
        logPosition[0].z = worldPosition.z;

        logcount++;
        if (logcount > 3)
            logcount = 3;

        ChangeScale(deltaTime);
        return;
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
                base.ProcessSequence(deltaTime);
                break;

            case SequenceID.ScriptMove:
                EvEntityCmd.ScriptMove(deltaTime);
                break;

            case SequenceID.ScriptStop:
                break;
        }
    }

    public DIR GetDir()
    {
        return GetDir(yawAngle);
    }

    public static DIR GetDir(float dir)
    {
        float angle = (dir + 360.0f) % 360.0f;

        if (angle < 45.0f)
            return DIR.DIR_DOWN;
        if (angle < 135.0f)
            return DIR.DIR_LEFT;
        if (angle < 225.0f)
            return DIR.DIR_UP;
        if (angle < 315.0f)
            return DIR.DIR_RIGHT;

        return DIR.DIR_DOWN;
    }

    public void SetDir(DIR dir)
    {
        switch (dir)
        {
            case DIR.DIR_UP:
                yawAngle = 180.0f;
                break;

            case DIR.DIR_DOWN:
                yawAngle = 0.0f;
                break;

            case DIR.DIR_LEFT:
                yawAngle = 90.0f;
                break;

            case DIR.DIR_RIGHT:
                yawAngle = 270.0f;
                break;
        }

        SetYawAngleDirect(yawAngle);
    }

    public static int GetIdleAnimation(FieldObjectEntity entity)
    {
        var character = entity as FieldCharacterEntity;
        if (character != null)
        {
            character.GetIdleAnimationIndex(out int index, out _);
            return index;
        }

        var pokemon = entity as FieldPokemonEntity;
        if (pokemon != null)
            return pokemon.GetIdleAnimationIndex();

        return 0;
    }

    public static int GetWalkAnimation(FieldObjectEntity entity)
    {
        var character = entity as FieldCharacterEntity;
        if (character != null)
            return character.GetWalkAnimationIndex();

        var pokemon = entity as FieldPokemonEntity;
        if (pokemon != null)
            return pokemon.GetWalkAnimationIndex();

        return 1;
    }

    public void SetScaleData(float start = 1.0f, float end = 1.0f, float time = 0.0f)
    {
        _scaleChangeFlag = true;
        _scaleStart = start;
        _scaleEnd = end;
        _scaleTime = time;
        _scaleProgressTime = 0.0f;
    }

    private void ChangeScale(float deltaTime)
    {
        if (!_scaleChangeFlag)
            return;

        _scaleProgressTime += deltaTime;

        float scale = Mathf.Lerp(_scaleStart, _scaleEnd, _scaleProgressTime / _scaleTime);
        transform.SetLocalScale(new Vector3(scale, scale, scale));

        if (_scaleTime <= _scaleProgressTime)
        {
            _scaleChangeFlag = false;
            _scaleStart = 0.0f;
            _scaleEnd = 0.0f;
            _scaleTime = 0.0f;
            _scaleProgressTime = 0.0f;
        }
    }

    public class SequenceID : BaseEntity.SequenceID
    {
	    public const int Active = 4096;
        public const int ScriptMove = 8193;
        public const int ScriptStop = 8194;
        protected const int User = 8192;
    }
}