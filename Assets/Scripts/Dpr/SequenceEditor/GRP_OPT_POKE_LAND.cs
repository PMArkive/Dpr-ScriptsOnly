namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POKE_LAND : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("着地通常")]
		GRP_OPT_POKE_LAND_NORMAL = 120,
        [ShortName("着地飛行")]
        GRP_OPT_POKE_LAND_FLY = 121,
        [ShortName("着地地面")]
        GRP_OPT_POKE_LAND_GROUND = 122,
        [ShortName("G替着通常")]
        GRP_OPT_POKE_LAND_EX_NORMAL = 123,
        [ShortName("G替着飛行")]
        GRP_OPT_POKE_LAND_EX_FLY = 124,
        [ShortName("G替着地面")]
        GRP_OPT_POKE_LAND_EX_GROUND = 125,
        [ShortName("G替着飛地")]
        GRP_OPT_POKE_LAND_EX_FL_GRO = 126,
        [ShortName("G替着地飛")]
        GRP_OPT_POKE_LAND_EX_GRO_FL = 127,
        [ShortName("対2着通常")]
        GRP_OPT_POKE2_LAND_NORMAL = 128,
        [ShortName("対2着飛行")]
        GRP_OPT_POKE2_LAND_FLY = 129,
        [ShortName("対2着地面")]
        GRP_OPT_POKE2_LAND_GROUND = 130,
	}
}