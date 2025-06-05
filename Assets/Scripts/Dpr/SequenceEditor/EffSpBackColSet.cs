using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffSpBackColSet, "lightgreen", "", "")]
	public class EffSpBackColSet : Macro
	{
		public Vector3 col;
		public float alpha;
		public bool subCamera;
		
		public EffSpBackColSet(Macro macro) : base(macro)
        {
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}