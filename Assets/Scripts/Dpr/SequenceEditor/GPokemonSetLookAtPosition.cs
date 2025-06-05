using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GPokemonSetLookAtPosition, "red", "", "")]
	public class GPokemonSetLookAtPosition : Macro
	{
		public bool enable;
		public SEQ_DEF_POS trg;
		public Vector3 pos;
		public bool relative;
		public bool isRotPos;
		public bool isFlip;
		public bool[] enableElem;
		
		public GPokemonSetLookAtPosition(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 0);
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 0);
            isFlip = ParseBool(macro.GetValue("isFlip"), 0);
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}