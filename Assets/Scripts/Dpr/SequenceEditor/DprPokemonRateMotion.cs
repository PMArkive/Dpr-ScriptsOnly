namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonRateMotion, "red", "one_frame", "")]
	public class DprPokemonRateMotion : Macro
	{
		public SEQ_DEF_POS trg;
		public int index;
		public float duration;
		public float startTime;
		
		public DprPokemonRateMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            index = ParseInt(macro.GetValue("index"), 0);
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
        }
    }
}