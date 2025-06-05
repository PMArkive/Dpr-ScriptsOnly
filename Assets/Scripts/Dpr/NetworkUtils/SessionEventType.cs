﻿namespace Dpr.NetworkUtils
{
    public enum SessionEventType : int
    {
        None = 0,
        JoinIn_Mine = 1,
        JoinIn_OtherPlayer = 2,
        ChangeHost_Mine = 3,
        ChangeHost_OtherPlayer = 4,
        Leave_Mine = 5,
        Leave_OtherPlayer = 6,
        GamingError = 7,
        Crash = 8,
        ResumeGame = 9,
    }
}