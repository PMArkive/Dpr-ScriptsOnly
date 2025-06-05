using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffSpBackColFlg, "lightgreen", "", "")]
	public class EffSpBackColFlg : Macro
	{
		public bool visible;
		public Vector3 col;
		public float alpha;
		public bool subCamera;
		
		public EffSpBackColFlg(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}