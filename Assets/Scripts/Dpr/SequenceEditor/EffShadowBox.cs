using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffShadowBox, "lightgreen", "", "")]
	public class EffShadowBox : Macro
	{
		public Vector3 minVec;
		public Vector3 maxVec;
		public bool rerative;
		
		public EffShadowBox(Macro macro) : base(macro)
        {
            minVec = ParseVector3(macro.GetValue("minVec"));
            maxVec = ParseVector3(macro.GetValue("maxVec"));
            rerative = ParseBool(macro.GetValue("rerative"), 1);
        }
    }
}