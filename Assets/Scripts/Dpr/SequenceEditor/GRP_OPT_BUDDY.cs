namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_BUDDY : int
	{
		GRP_OPT_NONE = 0,
        [ShortName("攻相")]
        GRP_OPT_ATK_BUDDY = 1,
        [ShortName("攻相?")]
        GRP_OPT_ATK_NOT_BUDDY = 2,
        [ShortName("防相")]
        GRP_OPT_DEF_BUDDY = 3,
        [ShortName("防相?")]
        GRP_OPT_DEF_NOT_BUDDY = 4,
	}
}