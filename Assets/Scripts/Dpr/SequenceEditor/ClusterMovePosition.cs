using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterMovePosition, "orange", "", "")]
	public class ClusterMovePosition : Macro
	{
		public Vector3 pos;
		public bool relative;
		
		public ClusterMovePosition(Macro macro) : base(macro)
		{
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
        }
	}
}