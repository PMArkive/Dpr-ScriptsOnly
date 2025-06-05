namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POKE_SIZE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻L")]
		GRP_OPT_ATK_L = 100,
        [ShortName("攻＜M")]
        GRP_OPT_ATK_UNDER_M = 101,
        [ShortName("防L")]
        GRP_OPT_DEF_L = 102,
        [ShortName("防＜M")]
        GRP_OPT_DEF_UNDER_M = 103,
        [ShortName("攻＜L以外")]
        GRP_OPT_ATK_SIZE_OTHER = 104,
        [ShortName("防＜L以外")]
        GRP_OPT_DEF_SIZE_OTHER = 105,
	}
}