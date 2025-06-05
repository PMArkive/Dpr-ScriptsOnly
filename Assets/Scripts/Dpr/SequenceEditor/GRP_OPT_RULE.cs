namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_RULE : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("S")]
		GRP_OPT_SINGLE = 1,
        [ShortName("D")]
        GRP_OPT_DOUBLE = 2,
        [ShortName("R")]
        GRP_OPT_ROYAL = 3,
        [ShortName("NS")]
        GRP_OPT_NOT_SINGLE = 4,
        [ShortName("NWS")]
        GRP_OPT_NOT_WILD_SINGLE = 5,
        [ShortName("RAID")]
        GRP_OPT_RAID = 6,
        [ShortName("N_RAID")]
        GRP_OPT_NOT_RAID = 7,
        [ShortName("SFR")]
        GRP_OPT_SAFARI = 8,
	}
}