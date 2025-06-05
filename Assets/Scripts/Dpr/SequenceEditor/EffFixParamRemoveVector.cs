namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFixParamRemoveVector, "lightgreen", "one_frame", "")]
	public class EffFixParamRemoveVector : Macro
	{
		public SEQ_DEF_POS trg;
		public bool trgPoke;
		public bool trgTra;
		public string name;
		
		public EffFixParamRemoveVector(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            trgPoke = ParseBool(macro.GetValue("trgPoke"), 1);
            trgTra = ParseBool(macro.GetValue("trgTra"), 0);
            name = ParseString(macro.GetValue("name"));
        }
    }
}