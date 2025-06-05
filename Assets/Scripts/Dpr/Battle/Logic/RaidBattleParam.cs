namespace Dpr.Battle.Logic
{
	public class RaidBattleParam
	{
		public byte bossGrade;
		public bool isBossRare;
		public RaidRewardItemData[] rewards = Arrays.InitializeWithDefaultInstances<RaidRewardItemData>(BattleDefConst.RAID_REWARD_ITEM_MAX);
		public RaidBossDesc bossDesc = new RaidBossDesc();
		public RaidBossCaptureDifficulty bossCaptureDifficulty;
		public bool needApplyCaptureCoefForSpGDuplication;
		
		// TODO
		public void CopyFrom(RaidBattleParam src) { }
	}
}