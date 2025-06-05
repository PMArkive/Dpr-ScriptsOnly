namespace Dpr.Battle.Logic
{
    public enum OperationPriority : byte
    {
        ESCAPE = 6,
        POKECHANGE = 5,
        NONE = 5,
        ITEM = 4,
        CHEER = 3,
        G_START = 2,
        FIGHT = 1,
        SKIP = 1,
        ESCAPE_WILD = 1,
        RAIDBOSS_EXTRA_ACTION = 0,
    }
}