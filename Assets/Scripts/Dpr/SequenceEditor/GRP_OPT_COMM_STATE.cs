namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_COMM_STATE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("非通")]
		GRP_OPT_NOT_COMM = 40,
		[ShortName("通信")]
		GRP_OPT_COMM = 41,
	}
}