using Pml.PokePara;

namespace Dpr.Demo
{
	public class ConditionParam
	{
		public byte[] PrevCondition = new byte[6]; // TODO: Find a proper constant for these?
		public byte[] NowCondition = new byte[6];
        public byte[] AddCondition = new byte[6];
        public Taste taste;
		public TasteJudge tasteJudge;
		
		// TODO
		public bool IsConditionUp(Condition condition) { return default; }
		
		// TODO
		public bool IsConditionMax(Condition condition) { return default; }
	}
}