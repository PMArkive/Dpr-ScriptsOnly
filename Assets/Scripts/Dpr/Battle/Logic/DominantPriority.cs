﻿namespace Dpr.Battle.Logic
{
    public enum DominantPriority : byte
    {
        RAIDBOSS_ANGRY_WAZA_ON_ANGRIED = 4,
        RAIDBOSS_ANGRY_WAZA_ON_ATTACK = 4,
        INTERRUPT = 3,
        DEFAULT = 2,
        POSTPONE = 1,
        RAIDBOSS_ANGRY_WAZA_ON_TURNEND = 0,
    }
}