namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_SIZE_COMP : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻≧防")]
		GRP_OPT_ATK_OVER_DEF = 105,
        [ShortName("攻＜防")]
        GRP_OPT_ATK_UNDEF_DEF = 106,
	}
}