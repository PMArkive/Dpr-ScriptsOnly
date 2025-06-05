using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffShadowBoxSet, "lightgreen", "", "")]
	public class EffShadowBoxSet : Macro
	{
		public Vector3 minVec;
		public Vector3 maxVec;
		public bool subCamera;
		public bool isReset;
		public bool rerative;
		
		// TODO
		public EffShadowBoxSet(Macro macro) : base(macro)
        {
            minVec = ParseVector3(macro.GetValue("minVec"), -5000.0f, -1000.0f, -5000.0f);
            maxVec = ParseVector3(macro.GetValue("maxVec"), 5000.0f, 1000.0f, 5000.0f);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            rerative = ParseBool(macro.GetValue("rerative"), 0);
        }
    }
}