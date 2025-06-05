using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterAccelGravity, "orange", "one_frame", "")]
    public class ClusterAccelGravity : Macro
	{
		public CLUSTER_POS type;
		public Vector3 pos;
		public bool relative;
		public float power;
		
		public ClusterAccelGravity(Macro macro) : base(macro)
        {
            type = Parse_CLUSTER_POS(macro.GetValue("type"));
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            power = ParseFloat(macro.GetValue("power"));
        }
    }
}