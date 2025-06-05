namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POS : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻前")]
		GRP_OPT_ATK_NEAR = 1,
		[ShortName("攻奥")]
		GRP_OPT_ATK_FAR = 2,
        [ShortName("防前")]
        GRP_OPT_DEF_NEAR = 3,
        [ShortName("防奥")]
        GRP_OPT_DEF_FAR = 4,
	}
}