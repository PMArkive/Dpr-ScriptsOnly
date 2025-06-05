namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_TRAINER_TRG : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("対象1味方")]
		GRP_OPT_TRG1_SELF = 70,
        [ShortName("対象1敵")]
        GRP_OPT_TRG1_ENEMY = 71,
        [ShortName("対象2味方")]
        GRP_OPT_TRG2_SELF = 72,
        [ShortName("対象2敵")]
        GRP_OPT_TRG2_ENEMY = 73,
	}
}