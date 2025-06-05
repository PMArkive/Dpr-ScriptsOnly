using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleShaderParam, "lightgreen", "", "")]
	public class ParticleShaderParam : Macro
	{
		public bool reset;
		public Vector3 col;
		public float alpha;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleShaderParam(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"), 0);
            col = ParseVector3(macro.GetValue("col"), 1.0f, 1.0f, 1.0f);
            alpha = ParseFloat(macro.GetValue("alpha"), 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}