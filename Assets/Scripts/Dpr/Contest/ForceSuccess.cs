namespace Dpr.Contest
{
	public class ForceSuccess : AContestSkillBase
	{
		public override int CalcAppealPoint()
		{
			return this.skillData.Length;
		}
		
		// TODO
		protected override void OnLaunchSkillEffect(SkillBonusParam bonusParam) { }
	}
}