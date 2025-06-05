namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_LL : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻＜L")]
		GRP_OPT_ATK_UNDER_L = 0,
        [ShortName("攻LL")]
        GRP_OPT_ATK_LL = 0,
        [ShortName("防＜L")]
        GRP_OPT_DEF_UNDER_L = 0,
        [ShortName("防LL")]
        GRP_OPT_DEF_LL = 0,
        [ShortName("前LL")]
        GRP_OPT_THIS_LL = 0,
        [ShortName("前＜LL")]
        GRP_OPT_THIS_NOT_LL = 0,
        [ShortName("奥LL")]
        GRP_OPT_BACK_LL = 0,
        [ShortName("奥＜LL")]
        GRP_OPT_BACK_NOT_LL = 0,
	}
}