namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_STADIUM_SIZE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("スタ広")]
		GRP_OPT_STADIUM_SIZE_WIDE = 220,
        [ShortName("スタ狭")]
        GRP_OPT_STADIUM_SIZE_NARROW = 221,
        [ShortName("木目")]
        GRP_OPT_STADIUM_G015 = 222,
        [ShortName("タイル")]
        GRP_OPT_STADIUM_G016 = 223,
        [ShortName("森洋館")]
        GRP_OPT_STADIUM_G021 = 224,
	}
}