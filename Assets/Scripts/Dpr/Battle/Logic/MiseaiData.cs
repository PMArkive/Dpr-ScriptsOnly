using Pml;

namespace Dpr.Battle.Logic
{
	public class MiseaiData
	{
		public PokeParty iPtrPartyFullMember;
		public sbyte[] memberSelectedIndex = new sbyte[DefineConstants.BTL_PARTY_MEMBER_MAX];
		
		public MiseaiData()
		{
			Clear();
		}
		
		public void Clear()
		{
			iPtrPartyFullMember = null;

			memberSelectedIndex[0] = -1;
			memberSelectedIndex[1] = -1;
			memberSelectedIndex[2] = -1;
			memberSelectedIndex[3] = -1;
			memberSelectedIndex[4] = -1;
			memberSelectedIndex[5] = -1;
		}
	}
}