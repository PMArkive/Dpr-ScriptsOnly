namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_SCENE_TYPE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("BTL")]
		GRP_OPT_SCENE_TYPE_BATTLE = 1,
        [ShortName("CNT")]
        GRP_OPT_SCENE_TYPE_CONTEST = 2,
        [ShortName("SPR")]
        GRP_OPT_SCENE_TYPE_SEAL_PREVIEW = 3,
        [ShortName("N_BTL")]
        GRP_OPT_SCENE_TYPE_NOT_BATTLE = 4,
        [ShortName("N_CNT")]
        GRP_OPT_SCENE_TYPE_NOT_CONTEST = 5,
        [ShortName("N_SPR")]
        GRP_OPT_SCENE_TYPE_NOT_SEAL_PREVIEW = 6,
	}
}