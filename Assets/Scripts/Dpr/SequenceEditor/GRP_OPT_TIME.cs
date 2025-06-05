namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_TIME : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("昼晴")]
		GRP_OPT_TIME_DAY = 50,
        [ShortName("夕晴")]
        GRP_OPT_TIME_EVENING = 51,
        [ShortName("夜晴")]
        GRP_OPT_TIME_NIGHT = 52,
        [ShortName("昼曇")]
        GRP_OPT_TIME_DAY_CLOUD = 53,
        [ShortName("夕曇")]
        GRP_OPT_TIME_EVENING_CLOUD = 54,
        [ShortName("夜曇")]
        GRP_OPT_TIME_NIGHT_CLOUD = 55,
        [ShortName("朝")]
        GRP_OPT_PERIOD_OF_DAY_MORNINT = 56,
        [ShortName("昼")]
        GRP_OPT_PERIOD_OF_DAY_DAYTIME = 57,
        [ShortName("夕方")]
        GRP_OPT_PERIOD_OF_DAY_EVENING = 58,
        [ShortName("夜")]
        GRP_OPT_PERIOD_OF_DAY_NIGHT = 59,
        [ShortName("深夜")]
        GRP_OPT_PERIOD_OF_DAY_MIDNIGHT = 60,
	}
}