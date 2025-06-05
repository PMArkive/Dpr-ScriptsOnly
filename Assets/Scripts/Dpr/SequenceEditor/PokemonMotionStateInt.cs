namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMotionStateInt, "red", "one_frame", "")]
	public class PokemonMotionStateInt : Macro
	{
		public SEQ_DEF_POS trg;
		public string state;
		public int number;
		
		public PokemonMotionStateInt(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
            number = ParseInt(macro.GetValue("number"), 0);
        }
    }
}