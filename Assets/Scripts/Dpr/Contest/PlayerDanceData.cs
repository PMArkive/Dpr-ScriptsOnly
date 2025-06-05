namespace Dpr.Contest
{
	public class PlayerDanceData
	{
		public int currentNoteDataIndex;
		public int[] tapTimingCountArray;
		public int totalDanceScore;
		public int stackLiveScore;
		public int skillScore;
		public int danceScore;
		public TensionID tension = TensionID.Normal;
		public int successCount;
		public int failedCount;
		public int nextTensionUpCount;
		public int nextTensionDownCount;
		public int heartGaugeValue;
		public AContestSkillBase contestSkill;
		protected SkillBonusParam bonusParam = new SkillBonusParam();
		protected bool usedSkill;
		protected bool canEmitHeart = true;
	}
}