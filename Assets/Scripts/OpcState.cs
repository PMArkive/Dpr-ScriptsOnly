using System;
using UnityEngine;

public class OpcState : MonoBehaviour
{
    public OnlineState _curretOnlineState;
    private Action<OnlineState> _OnChangeState;

    // TODO
    public void SetOnChangeState(Action<OnlineState> action) { }

    // TODO
    public void OnChangeOnlineState(OnlineState state) { }

    // TODO
    public OnlineState GetOnlineState() { return OnlineState.NONE; }

    // TODO
    public bool IsCanTalkState() { return false; }

    public enum OnlineState : int
    {
        NONE = 0,
        DIG_FOSILL = 1,
        SECRETBASE_ACTION = 2,
        RECRUITMENT_BATTLE = 3,
        RECRUITMENT_TRADE = 4,
        RECRUITMENT_RECORD = 5,
        RECRUITMENT_GREETINGS = 6,
        RECRUITMENT_BALL_DECORATION = 7,
        COMMUNICATE = 8,
        LIKES = 9,
        CROSS = 10,
        EXCLAMATION = 11,
        TOGETHER = 12,
        GET = 13,
        NOW_DIG_FOSILE = 14,
        NOW_MENU = 15,
        NOW_BATTLE = 16,
        NOW_BATTLE_UNION = 17,
        NOW_TRADE = 18,
        NOW_RECORD = 19,
        NOW_GREETINGS = 20,
        NOW_BALL_DECORATION = 21,
        _NULL = 22,
    }
}