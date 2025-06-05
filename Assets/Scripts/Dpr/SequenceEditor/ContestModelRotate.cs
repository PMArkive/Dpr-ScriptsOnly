using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestModelRotate, "pink", "", "")]
	public class ContestModelRotate : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ContestModelRotate(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}