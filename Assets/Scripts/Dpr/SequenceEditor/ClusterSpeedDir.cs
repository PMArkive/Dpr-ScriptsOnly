using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterSpeedDir, "orange", "one_frame", "")]
	public class ClusterSpeedDir : Macro
	{
		public Vector3 rot;
		public int rotRand;
		public float spd;
		public float acc;
		
		public ClusterSpeedDir(Macro macro) : base(macro)
        {
            rot = ParseVector3(macro.GetValue("rot"));
            rotRand = ParseInt(macro.GetValue("rotRand"));
            spd = ParseFloat(macro.GetValue("spd"));
            acc = ParseFloat(macro.GetValue("acc"), 1.0f);
        }
    }
}