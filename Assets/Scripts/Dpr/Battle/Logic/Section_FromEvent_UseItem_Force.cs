using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_UseItem_Force : Section
	{
		public Section_FromEvent_UseItem_Force(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		// TODO
		private void displayItemEffect(in ServerCommandPutter.UseItemCommandParam param, UseEffectType effectType, bool isUsed) { }
		
		// TODO
		private void afterItemEquip(BTL_POKEPARAM poke, ushort itemID) { }

		public enum UseEffectType : int
		{
			Normal = 0,
			Force = 1,
			Disable = 2,
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort itemID;
			public bool isAteKinomi;
			public UseEffectType useEffectType;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isAteKinomi = false;
				useEffectType = UseEffectType.Normal;
			}
		}

		public class Result
		{
			public bool isUsed;
		}
	}
}