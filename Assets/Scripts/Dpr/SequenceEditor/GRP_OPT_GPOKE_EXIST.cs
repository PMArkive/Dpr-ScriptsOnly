namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_GPOKE_EXIST : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("G有")]
		GRP_OPT_GPOKE_EXIST = 66,
        [ShortName("G無")]
        GRP_OPT_GPOKE_NOT_EXIST = 67,
        [ShortName("G敵")]
        GRP_OPT_GPOKE_ENEMY_EXIST = 68,
        [ShortName("G味")]
        GRP_OPT_GPOKE_SELF_EXIST = 69,
        [ShortName("G両")]
        GRP_OPT_GPOKE_BOTH_EXIST = 70,
	}
}