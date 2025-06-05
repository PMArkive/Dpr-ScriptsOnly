namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialChangePokemon, "purple", "", "")]
	public class SpecialChangePokemon : Macro
	{
		public SEQ_DEF_POS trg;
		public bool noLoad;
		
		public SpecialChangePokemon(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            noLoad = ParseBool(macro.GetValue("noLoad"));
        }
    }
}