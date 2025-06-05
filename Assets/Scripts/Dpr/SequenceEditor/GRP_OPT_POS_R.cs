namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POS_R : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("攻R前")]
		GRP_OPT_ATK_R_NEAR = 1,
        [ShortName("攻R右")]
        GRP_OPT_ATK_R_RIGHT = 2,
        [ShortName("攻R奥")]
        GRP_OPT_ATK_R_FAR = 3,
        [ShortName("攻R左")]
        GRP_OPT_ATK_R_LEFT = 4,
	}
}