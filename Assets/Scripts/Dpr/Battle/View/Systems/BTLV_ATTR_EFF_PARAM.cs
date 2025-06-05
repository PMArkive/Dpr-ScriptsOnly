namespace Dpr.Battle.View.Systems
{
	public struct BTLV_ATTR_EFF_PARAM
	{
		public EffectBattleID attrEffectID;
		public EffectBattleID streamLineEffectID;
		
		// TODO
		public void SetStreamLineEffectID(PeriodOfDay day, EffectBattleID[] ids) { }
		
		public static BTLV_ATTR_EFF_PARAM Factory()
		{
			return new BTLV_ATTR_EFF_PARAM()
			{
				attrEffectID = EffectBattleID.NONE,
				streamLineEffectID = EffectBattleID.NONE,
			};
		}
	}
}