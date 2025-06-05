using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestModelScale, "orange", "", "")]
	public class ContestModelScale : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ContestModelScale(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}