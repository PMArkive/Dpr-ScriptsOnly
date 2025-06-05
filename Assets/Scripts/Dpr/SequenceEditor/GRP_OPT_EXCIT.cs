namespace Dpr.SequenceEditor
{
	public enum GRP_OPT_EXCIT : int
	{
		GRP_OPT_NONE = 0,
		[ShortName("盛急所")]
		GRP_OPT_EXCIT_CRITICAL = 201,
        [ShortName("盛眠火麻")]
        GRP_OPT_EXCIT_SICK = 202,
        [ShortName("盛繰出")]
        GRP_OPT_EXCIT_INTRO_POKE = 203,
        [ShortName("盛繰最後")]
        GRP_OPT_EXCIT_LAST_INTRO_POKE = 204,
        [ShortName("盛Ｇポケ")]
        GRP_OPT_EXCIT_CHANGE_GPOKE = 205,
        [ShortName("盛倒れ")]
        GRP_OPT_EXCIT_POKE_DOWN = 206,
        [ShortName("盛Ｇ倒")]
        GRP_OPT_EXCIT_GPOKE_DOWN = 207,
        [ShortName("盛決着")]
        GRP_OPT_EXCIT_FINISH = 208,
        [ShortName("盛上?")]
        GRP_OPT_EXCIT_NONE = 200,
	}
}