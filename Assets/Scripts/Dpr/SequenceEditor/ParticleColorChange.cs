using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleColorChange, "lightgreen", "", "")]
	public class ParticleColorChange : Macro
	{
		public bool reset;
		public bool isGauge;
		public Vector3 col;
		public float alpha;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleColorChange(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"), 0);
            isGauge = ParseBool(macro.GetValue("isGauge"), 0);
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}