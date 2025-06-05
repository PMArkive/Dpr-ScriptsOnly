using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffLightDirection, "lightgreen", "", "")]
	public class EffLightDirection : Macro
	{
		public Vector3 dir;
		
		public EffLightDirection(Macro macro) : base(macro)
        {
            dir = ParseVector3(macro.GetValue("dir"));
        }
    }
}