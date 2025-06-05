﻿namespace Dpr.Battle.Logic
{
    public enum BtlResult : int
    {
        BTL_RESULT_LOSE = 0,
        BTL_RESULT_WIN = 1,
        BTL_RESULT_DRAW = 2,
        BTL_RESULT_RUN = 3,
        BTL_RESULT_RUN_ENEMY = 4,
        BTL_RESULT_CAPTURE = 5,
        BTL_RESULT_COMM_ERROR = 6,
        BTL_RESULT_FORCE_QUIT = 7,
        BTL_RESULT_MAX = 8,
        BTL_RESULT_LOSE_NOT_GAMEOVER_FOR_SKY = 9,
    }
}