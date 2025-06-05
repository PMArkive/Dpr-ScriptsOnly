namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POKE_SIZE_VPOS : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("PN1＝L")]
		GRP_OPT_POKE_SIZE_NEAR1_L = 272,
        [ShortName("PN1＜M")]
        GRP_OPT_POKE_SIZE_NEAR1_UNDER_M = 273,
        [ShortName("PN2＝L")]
        GRP_OPT_POKE_SIZE_NEAR2_L = 274,
        [ShortName("PN2＜M")]
        GRP_OPT_POKE_SIZE_NEAR2_UNDER_M = 275,
        [ShortName("PF1＝L")]
        GRP_OPT_POKE_SIZE_FAR1_L = 276,
        [ShortName("PF1＜M")]
        GRP_OPT_POKE_SIZE_FAR1_UNDER_M = 277,
        [ShortName("PF2＝L")]
        GRP_OPT_POKE_SIZE_FAR2_L = 278,
        [ShortName("PF2＜M")]
        GRP_OPT_POKE_SIZE_FAR2_UNDER_M = 279,
	}
}