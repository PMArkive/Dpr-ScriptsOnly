namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMotionStateBool, "red", "one_frame", "")]
	public class PokemonMotionStateBool : Macro
	{
		public SEQ_DEF_POS trg;
		public string state;
		public bool flg;
		
		public PokemonMotionStateBool(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
            flg = ParseBool(macro.GetValue("flg"), 0);
        }
    }
}