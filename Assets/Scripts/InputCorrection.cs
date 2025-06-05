using GameData;
using System;
using UnityEngine;

public class InputCorrection
{
    private static bool _isCrossMode;
    private static Vector2 _oldBaseInput;

    public static Vector2 FieldMoveCorrection(Vector2 baseinput)
    {
        if (baseinput != Vector2.zero)
        {
            if (_oldBaseInput != Vector2.zero)
            {
                if (_isCrossMode)
                    _oldBaseInput = CrossCorrection(baseinput, out _isCrossMode);
                else
                    _oldBaseInput = baseinput;
            }
            else
            {
                _oldBaseInput = CrossCorrection(baseinput, out _isCrossMode);
            }
        }
        else
        {
            _oldBaseInput = baseinput;
        }

        return _oldBaseInput;
    }

    private static Vector2 CrossCorrection(Vector2 baseinput, out bool result)
    {
        float magnitude = Math.Min(baseinput.sqrMagnitude, 1.0f);
        float deg = ((float)Math.Atan2(baseinput.x, baseinput.y) * Mathf.Rad2Deg + 360.0f) % 360.0f;
        float angle = DataManager.GetFieldCommonParam(FieldCommon.ParamIndx.CrossAngle);

        result = true;

        angle = (2.0f - magnitude) * angle * 0.5f;

        float newX = 0.0f;
        if (deg <= 360.0f - angle && angle + 0.0f <= deg)
        {
            result = false;
            newX = baseinput.x;
        }
        baseinput.x = newX;

        return baseinput;
    }
}