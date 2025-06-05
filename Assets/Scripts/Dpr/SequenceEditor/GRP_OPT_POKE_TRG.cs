namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_POKE_TRG : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("対象1ポケ味方")]
		GRP_OPT_TRG1_POKE_SELF = 130,
        [ShortName("対象1ポケ敵")]
        GRP_OPT_TRG1_POKE_ENEMY = 131,
        [ShortName("対象2ポケ味方")]
        GRP_OPT_TRG2_POKE_SELF = 132,
        [ShortName("対象2ポケ敵")]
        GRP_OPT_TRG2_POKE_ENEMY = 133,
        [ShortName("対象1ポケ味方1")]
        GRP_OPT_TRG1_POKE_SELF1 = 134,
        [ShortName("対象1ポケ味方2")]
        GRP_OPT_TRG1_POKE_SELF2 = 135,
        [ShortName("対象1ポケ味方3")]
        GRP_OPT_TRG1_POKE_SELF3 = 136,
        [ShortName("対象1ポケ味方4")]
        GRP_OPT_TRG1_POKE_SELF4 = 137,
	}
}