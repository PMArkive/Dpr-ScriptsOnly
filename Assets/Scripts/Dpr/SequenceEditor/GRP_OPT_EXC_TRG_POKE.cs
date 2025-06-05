namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_EXC_TRG_POKE : int
	{
		GRP_OPT_NONE = 0,
        [ShortName("ブイゼル")]
        GRP_OPT_EXC_TRG1_POKE_BUIZEL = 300,
        [ShortName("ブイゼル?")]
        GRP_OPT_EXC_TRG1_POKE_BUIZEL_NONE = 301,
        [ShortName("フローゼル")]
        GRP_OPT_EXC_TRG1_POKE_FLOATZEL = 302,
        [ShortName("フローゼル?")]
        GRP_OPT_EXC_TRG1_POKE_FLOATZEL_NONE = 303,
        [ShortName("ブイゼル系?")]
        GRP_OPT_EXC_TRG1_POKE_BUIZEL_GROUP_NONE = 304,
	}
}