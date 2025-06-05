using Audio;
using UnityEngine;

public class BicycleJump
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _diffPos;
    private Vector3 _jumpVector;
    private bool _gear;
    private Seq _seqNo;
    private bool _left;
    private float _workX;
    private float _jumpSpeed;
    private float _jumpHeight;
    private float _jumpZusaCnt;
    private const float JumpHeight_g3 = 0.8f;
    private const float JumpHeight_g4 = 1.0f;
    private const float JumpSpeed_g3 = 6.0f;
    private const float JumpSpeed_g4 = 10.0f;
    private const float JumpZusaTime = 0.1f;

    public void SetUp(Vector3 startpos, Vector3 endpos, bool gear)
    {
        _gear = gear;
        _seqNo = Seq.Start;
        _startPos = startpos;
        _endPos = endpos;

        _diffPos = endpos - startpos;
        _diffPos.y = 0.0f;
        _jumpVector = _diffPos.normalized;

        _left = _startPos.x < _endPos.x;
        _jumpHeight = gear ? JumpHeight_g4 : JumpHeight_g3;
        _jumpSpeed = gear ? JumpSpeed_g4 : JumpSpeed_g3;
        _workX = 0.0f;
        _jumpZusaCnt = 0.0f;
    }

    public Vector3 Update(float deltatime, out Seq end, ref Vector3 worldpos)
    {
        if (_gear)
            return FastGear(deltatime, out end, ref worldpos);
        else
            return SlowGear(deltatime, out end, ref worldpos);
    }

    private Vector3 JumpAction(float deltatime, ref Vector3 worldpos)
    {
        var pos = new Vector3(0.0f, _endPos.y, _endPos.z);

        if (_seqNo == Seq.Start)
        {
            AudioManager.Instance.PlaySe(AK.EVENTS.S_FI005, null);
            _seqNo = Seq.Jump;
        }

        if (_seqNo == Seq.Jump)
        {
            pos.x = _jumpSpeed * deltatime;
            _workX += pos.x;

            float heightMult = Mathf.Abs(_workX/_diffPos.x + _workX/_diffPos.x);
            heightMult = heightMult <= 1.0f ? heightMult : 2.0f - heightMult;
            pos.y += heightMult * _jumpHeight;
        }

        if (_left)
        {
            if (_endPos.x <= worldpos.x + pos.x)
            {
                _seqNo = Seq.EndFollow;
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI038, null);
            }
        }
        else
        {
            if (worldpos.x - pos.x <= _endPos.x)
                _seqNo = Seq.EndFollow;

            pos.x = -pos.x;
        }

        return pos;
    }

    private Vector3 SlowGear(float deltatime, out Seq end, ref Vector3 worldpos)
    {
        var pos = JumpAction(deltatime, ref worldpos);

        if (_seqNo == Seq.EndFollow)
        {
            _seqNo = Seq.End;
            pos = _endPos;
            pos.x -= worldpos.x;
        }

        end = _seqNo;
        return pos;
    }

    private Vector3 FastGear(float deltatime, out Seq end, ref Vector3 worldpos)
    {
        var pos = Vector3.zero;
        if (_seqNo < Seq.EndFollow)
           pos = JumpAction(deltatime, ref worldpos);

        if (_seqNo != Seq.EndFollow)
        {
            end = _seqNo;
            return pos;
        }

        var direction = new Vector3(_left ? 0.5f : -0.5f, 0.0f, 0.0f);
        var newPos = worldpos + direction;
        var gridPos = FieldObjectEntity.PositionToGrid(newPos);

        GameManager.GetAttribute(gridPos, out int code, out int stop);
        if (AttributeID.MATR_IsTakeOffLeft(code) || AttributeID.MATR_IsTakeOffRight(code))
        {
            EntityManager.activeFieldPlayer.GetInputVector(out Vector2 input, out float magnitude, deltatime, out bool _);
            float angle = EntityManager.activeFieldPlayer.InputAtanAngle(ref input);
            angle = EntityManager.activeFieldPlayer.InputYawAngle(angle);
            angle = angle >= 0.0f ? angle : angle + 360.0f;
            angle %= 360.0f;

            if (magnitude != 0.0f)
            {
                if ((!_left && 225.0f < angle && angle < 315.0f) ||
                    (_left && 45.0 < angle && angle < 135.0))
                {
                    var endPos = _endPos;
                    float movedBy = _gear ? 4.0f : 2.0f;
                    if (_left)
                        movedBy = -movedBy;

                    endPos.x += movedBy;
                    SetUp(_endPos, endPos, _gear);
                    end = _seqNo;
                    return new Vector3(0.0f, _endPos.y, _endPos.z);
                }
            }

            _seqNo = Seq.End;
            end = _seqNo;
            return new Vector3(_endPos.x - worldpos.x, _endPos.y, angle);
        }
        else
        {
            if (stop == 128)
            {
                _seqNo = Seq.End;
                end = _seqNo;
                return new Vector3(_endPos.x - worldpos.x, _endPos.y, newPos.z);
            }

            var collideDir = new Vector3(_left ? 1.0f : -1.0f, 0.0f, 0.0f);
            var result = CollisionUtility.CollideObstacle(worldpos, 0.4f, direction, _jumpSpeed * deltatime, out bool _,
                out bool isCollision, out float _, out Vector3 _, Layer.Obstacle | Layer.Jump, 0.0f);

            float finalX = result.x;
            if (!isCollision)
            {
                _jumpZusaCnt += deltatime;
                float newX = result.x + worldpos.x;
                if ((!_left && _endPos.x <= newX) ||
                    (_left && newX <= _endPos.x))
                {
                    finalX = _endPos.x - newX;
                    _seqNo = Seq.End;
                }

                if (_jumpZusaCnt >= JumpZusaTime)
                    _seqNo = Seq.End;

                end = _seqNo;
                return new Vector3(finalX, _endPos.y, _endPos.z);
            }

            _seqNo = Seq.End;
            end = _seqNo;
            return new Vector3(0.0f, _endPos.y, _endPos.z);
        }
    }

    public enum Seq : int
    {
        Start = 0,
        Jump = 1,
        EndFollow = 2,
        End = 3,
    }
}