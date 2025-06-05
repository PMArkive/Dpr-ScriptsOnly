using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelRotate, "pink", "", "")]
	public class ModelRotate : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ModelRotate(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}