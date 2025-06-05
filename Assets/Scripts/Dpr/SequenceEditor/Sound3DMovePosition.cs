using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DMovePosition, "blue", "", "")]
	public class Sound3DMovePosition : Macro
	{
		public Vector3 pos;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public Sound3DMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}