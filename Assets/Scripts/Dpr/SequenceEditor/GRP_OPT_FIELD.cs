namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_FIELD : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("Ｆスタ観有")]
		GRP_OPT_FIELD_STADIUM = 190,
        [ShortName("Ｆスタ?")]
        GRP_OPT_FIELD_NO_STADIUM = 191,
        [ShortName("Ｆスタ観無")]
        GRP_OPT_FIELD_NO_AUDIENCE = 192,
	}
}