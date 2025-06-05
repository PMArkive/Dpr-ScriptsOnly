using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFixParamSetVector, "lightgreen", "", "")]
	public class EffFixParamSetVector : Macro
	{
		public SEQ_DEF_POS trg;
		public bool trgPoke;
		public bool trgTra;
		public string name;
		public Vector3 startVec;
		public Vector3 endVec;
		public SEQ_DEF_MOVETYPE move;
		public SEQ_DEF_FIXPARAM_CALC calc;
		
		public EffFixParamSetVector(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            trgPoke = ParseBool(macro.GetValue("trgPoke"), 1);
            trgTra = ParseBool(macro.GetValue("trgTra"), 0);
            name = ParseString(macro.GetValue("name"));
            startVec = ParseVector3(macro.GetValue("startParam"));
            endVec = ParseVector3(macro.GetValue("endParam"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            calc = Parse_SEQ_DEF_FIXPARAM_CALC(macro.GetValue("calc"));
        }
    }
}