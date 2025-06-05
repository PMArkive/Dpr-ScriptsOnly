using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleMultiplyColorSet, "green", "", "")]
	public class DprParticleMultiplyColorSet : Macro
	{
		public bool reset;
		public Vector3 col;
		public float alpha;
		public SEQ_DEF_MOVETYPE move;
		
		public DprParticleMultiplyColorSet(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"), 0);
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"), 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}