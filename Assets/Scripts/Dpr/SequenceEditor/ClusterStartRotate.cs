using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterStartRotate, "orange", "one_frame", "")]
	public class ClusterStartRotate : Macro
	{
		public Vector3 min;
		public Vector3 max;
		
		public ClusterStartRotate(Macro macro) : base(macro)
        {
            min = ParseVector3(macro.GetValue("min"));
            max = ParseVector3(macro.GetValue("max"));
        }
    }
}