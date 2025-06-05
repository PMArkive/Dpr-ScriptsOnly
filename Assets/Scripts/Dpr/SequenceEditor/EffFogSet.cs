using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffFogSet, "lightgreen", "", "")]
	public class EffFogSet : Macro
	{
		public SEQ_DEF_FOG_MODE mode;
		public float nearLen;
		public float maxLen;
		public float strength;
		public Vector3 colorScale;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffFogSet(Macro macro) : base(macro)
        {
            mode = Parse_SEQ_DEF_FOG_MODE(macro.GetValue("mode"));
            nearLen = ParseFloat(macro.GetValue("nearLen"), 32.0f);
            maxLen = ParseFloat(macro.GetValue("maxLen"), 6000.0f);
            strength = ParseFloat(macro.GetValue("strength"), 1.0f);
            colorScale = ParseVector3(macro.GetValue("colorScale"), 1.0f, 1.0f, 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}