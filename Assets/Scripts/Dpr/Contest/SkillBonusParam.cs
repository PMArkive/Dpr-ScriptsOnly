namespace Dpr.Contest
{
	public class SkillBonusParam
	{
		public float addHeartGaugeBonus = 1.0f;
		public bool forceSuccess;
		public bool keepTension;
		
		public void Reset()
		{
            addHeartGaugeBonus = 1.0f;
			forceSuccess = false;
			keepTension = false;
        }
	}
}