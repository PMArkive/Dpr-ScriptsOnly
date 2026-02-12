namespace Dpr.Contest
{
	public class HeartUp : AContestSkillBase
	{
		public override int CalcAppealPoint()
		{
			return this.skillData.Length;
		}
		
		// TODO
		protected override void OnLaunchSkillEffect(SkillBonusParam bonusParam) { }
	}
}