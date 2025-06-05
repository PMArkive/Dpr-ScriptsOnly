namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFixParamSetFloat, "lightgreen", "", "")]
	public class EffFixParamSetFloat : Macro
	{
		public SEQ_DEF_POS trg;
		public bool trgPoke;
		public bool trgTra;
		public string name;
		public float startParam;
		public float endParam;
		public SEQ_DEF_MOVETYPE move;
		public SEQ_DEF_FIXPARAM_CALC calc;
		
		public EffFixParamSetFloat(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            trgPoke = ParseBool(macro.GetValue("trgPoke"), 1);
            trgTra = ParseBool(macro.GetValue("trgTra"), 0);
            name = ParseString(macro.GetValue("name"));
            startParam = ParseFloat(macro.GetValue("startParam"));
            endParam = ParseFloat(macro.GetValue("endParam"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            calc = Parse_SEQ_DEF_FIXPARAM_CALC(macro.GetValue("calc"));
        }
    }
}