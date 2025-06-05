namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialChangeReferencePokemon, "purple", "", "")]
	public class SpecialChangeReferencePokemon : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_POS @ref;
		public bool noLoad;
		
		public SpecialChangeReferencePokemon(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            @ref = Parse_SEQ_DEF_POS(macro.GetValue("ref"));
            noLoad = ParseBool(macro.GetValue("noLoad"));
        }
    }
}