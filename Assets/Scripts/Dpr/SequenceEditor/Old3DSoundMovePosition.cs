using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundMovePosition, "blue", "", "")]
	public class Old3DSoundMovePosition : Macro
	{
		public Vector3 pos;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public Old3DSoundMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}