using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleScale, "green", "", "")]
	public class ParticleScale : Macro
	{
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleScale(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            relative = ParseBool(macro.GetValue("relative"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}