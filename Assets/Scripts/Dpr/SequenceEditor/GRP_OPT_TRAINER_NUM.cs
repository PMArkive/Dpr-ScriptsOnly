namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_TRAINER_NUM : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("前1人")]
		GRP_OPT_ATK_TR1 = 75,
        [ShortName("前2人")]
        GRP_OPT_ATK_TR2 = 76,
        [ShortName("奥1人")]
        GRP_OPT_DEF_TR1 = 77,
        [ShortName("奥2人")]
        GRP_OPT_DEF_TR2 = 78,
	}
}