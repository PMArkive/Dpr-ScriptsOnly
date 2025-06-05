namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialChangePokemonFromSimpleParam, "purple", "", "")]
	public class SpecialChangePokemonFromSimpleParam : Macro
	{
		public SEQ_DEF_POS trg;
		public int Monsno;
		public int Form;
		public SEQ_DEF_POKE_G gType;
		
		public SpecialChangePokemonFromSimpleParam(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            Monsno = ParseInt(macro.GetValue("Monsno"));
            Form = ParseInt(macro.GetValue("Form"));
            gType = Parse_SEQ_DEF_POKE_G(macro.GetValue("gType"));
        }
    }
}