using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterScale, "orange", "", "")]
	public class ClusterScale : Macro
	{
		public Vector3 scale;
		public bool relative;
		
		public ClusterScale(Macro macro) : base(macro)
		{
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            relative = ParseBool(macro.GetValue("relative"));
        }
	}
}