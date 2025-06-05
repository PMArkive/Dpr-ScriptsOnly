using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffCharaLightDirection, "lightgreen", "", "")]
	public class EffCharaLightDirection : Macro
	{
		public bool reset;
		public Vector3 dir;
		public bool flip;
		public SEQ_DEF_POS flipTrg;
		
		public EffCharaLightDirection(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"));
            dir = ParseVector3(macro.GetValue("dir"));
            flip = ParseBool(macro.GetValue("flip"));
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
        }
    }
}