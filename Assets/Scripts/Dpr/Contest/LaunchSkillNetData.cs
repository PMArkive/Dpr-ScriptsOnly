using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class LaunchSkillNetData : ANetData<LaunchSkillData>
	{
		public override byte GetDataID { get => (byte)SendDataType.LaunchSkill; }
	}
}