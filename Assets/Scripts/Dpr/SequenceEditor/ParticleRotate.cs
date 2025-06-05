using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleRotate, "green", "", "")]
	public class ParticleRotate : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleRotate(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}