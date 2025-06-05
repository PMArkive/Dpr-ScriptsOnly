using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleRotateOffset, "green", "", "")]
	public class ParticleRotateOffset : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleRotateOffset(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}