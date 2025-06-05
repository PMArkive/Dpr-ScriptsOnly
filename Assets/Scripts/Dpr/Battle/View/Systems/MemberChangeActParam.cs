using Dpr.Battle.Logic;

namespace Dpr.Battle.View.Systems
{
	public struct MemberChangeActParam
	{
		public BtlvPos vpos;
		public byte clientID;
		
		// TODO
		public static MemberChangeActParam Factory() { return default; }
	}
}