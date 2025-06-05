using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterRotate, "orange", "", "")]
	public class ClusterRotate : Macro
	{
		public Vector3 scale;
		public bool relative;

		public ClusterRotate(Macro macro) : base(macro)
        {
            scale = ParseVector3(macro.GetValue("scale"));
            relative = ParseBool(macro.GetValue("relative"));
        }
    }
}