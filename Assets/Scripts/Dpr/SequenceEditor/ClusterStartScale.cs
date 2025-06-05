using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterStartScale, "orange", "one_frame", "")]
	public class ClusterStartScale : Macro
	{
		public Vector3 min;
		public Vector3 max;
		public bool sync;
		
		public ClusterStartScale(Macro macro) : base(macro)
        {
            min = ParseVector3(macro.GetValue("min"), 1.0f, 1.0f, 1.0f);
            max = ParseVector3(macro.GetValue("max"), 1.0f, 1.0f, 1.0f);
            sync = ParseBool(macro.GetValue("sync"), 1);
        }
    }
}