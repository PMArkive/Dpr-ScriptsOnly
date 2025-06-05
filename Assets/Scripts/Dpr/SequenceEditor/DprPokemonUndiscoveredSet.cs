using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprPokemonUndiscoveredSet, "red", "", "")]
	public class DprPokemonUndiscoveredSet : Macro
	{
		public SEQ_DEF_POS trg;
		public Vector3 startColor;
		public Vector3 endColor;
		public SEQ_DEF_MOVETYPE move;
		public bool isForce;
		
		public DprPokemonUndiscoveredSet(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            startColor = ParseVector3(macro.GetValue("startColor"), 0.0f, 0.0f, 0.0f);
            startColor = ParseVector3(macro.GetValue("endColor"), 1.0f, 1.0f, 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            isForce = ParseBool(macro.GetValue("isForce"), 0);
        }
    }
}