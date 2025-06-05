using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleMovePosition, "green", "", "")]
	public class ParticleMovePosition : Macro
	{
		public Vector3 pos;
		public bool relative;
		public bool isRotPos;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public ParticleMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}