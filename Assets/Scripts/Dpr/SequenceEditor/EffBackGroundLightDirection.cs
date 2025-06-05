using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffBackGroundLightDirection, "lightgreen", "", "")]
	public class EffBackGroundLightDirection : Macro
	{
		public bool reset;
		public Vector3 dir;
		public bool flip;
		public SEQ_DEF_POS flipTrg;
		
		public EffBackGroundLightDirection(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"));
            dir = ParseVector3(macro.GetValue("dir"));
            flip = ParseBool(macro.GetValue("flip"));
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
        }
    }
}