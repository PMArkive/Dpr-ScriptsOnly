namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_RARE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻レア")]
		GRP_OPT_ATK_RARE = 60,
        [ShortName("攻普通")]
        GRP_OPT_ATK_NO_RARE = 61,
	}
}