﻿namespace Dpr.Battle.Logic
{
    public enum InterruptCode : byte
    {
        NONE = 0,
        POKE_CHANGE = 1,
        POKE_COVER = 2,
        LEVELUP = 3,
        QUIT_SHOWDOWN = 4,
        QUIT_ESCAPE = 5,
        QUIT_CAPTURE = 6,
        QUIT_TURNOVER = 7,
        QUIT_SAFARIBALL = 8,
    }
}