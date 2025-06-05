using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffBackGroundLightColor, "lightgreen", "", "")]
	public class EffBackGroundLightColor : Macro
	{
		public bool reset;
		public Vector3 col;
		
		public EffBackGroundLightColor(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"));
            col = ParseVector3(macro.GetValue("col"));
        }
    }
}