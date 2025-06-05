using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterSpeedDiffuse, "orange", "one_frame", "")]
	public class ClusterSpeedDiffuse : Macro
	{
		public CLUSTER_POS center;
		public Vector3 offset;
		public float spd;
		public float acc;
		
		public ClusterSpeedDiffuse(Macro macro) : base(macro)
        {
            center = Parse_CLUSTER_POS(macro.GetValue("center"));
            offset = ParseVector3(macro.GetValue("offset"));
            spd = ParseFloat(macro.GetValue("spd"));
            acc = ParseFloat(macro.GetValue("acc"), 1.0f);
        }
    }
}