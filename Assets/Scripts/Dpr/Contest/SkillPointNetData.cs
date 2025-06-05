using Dpr.NetworkUtils;

namespace Dpr.Contest
{
	public class SkillPointNetData : ANetData<SkillPointData>
	{
		public override byte GetDataID { get => (byte)SendDataType.SkillPoint; }
	}
}