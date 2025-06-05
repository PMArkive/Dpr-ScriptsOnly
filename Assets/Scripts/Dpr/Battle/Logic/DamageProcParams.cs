using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public class DamageProcParams
	{
		public BTL_POKEPARAM[] bpp = new BTL_POKEPARAM[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		public ushort[] dmg = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		public TypeAffinity.AffinityID[] affAry = new TypeAffinity.AffinityID[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		public CriticalType[] criticalTypes = new CriticalType[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		public KoraeruCause[] koraeru_cause = new KoraeruCause[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
    }
}