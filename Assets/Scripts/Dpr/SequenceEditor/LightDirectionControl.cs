using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.LightDirectionControl, "lightgreen", "one_frame", "")]
	public class LightDirectionControl : Macro
	{
		public LIGHT_TYPE type;
		public SEQ_DEF_LIGHT_TRG_SIDE trgSide;
		public bool poke;
		public bool gpoke;
		public bool trainer;
		public bool background;
		public bool shadow;
		public Vector3 dir;
		public bool flip;
		public SEQ_DEF_POS flipTrg;
		
		public LightDirectionControl(Macro macro) : base(macro)
        {
            type = Parse_LIGHT_TYPE(macro.GetValue("type"));
            trgSide = Parse_SEQ_DEF_LIGHT_TRG_SIDE(macro.GetValue("trgSide"));
            poke = ParseBool(macro.GetValue("poke"), 0);
            gpoke = ParseBool(macro.GetValue("gpoke"), 0);
            trainer = ParseBool(macro.GetValue("trainer"), 0);
            background = ParseBool(macro.GetValue("background"), 0);
            shadow = ParseBool(macro.GetValue("shadow"), 0);
            dir = ParseVector3(macro.GetValue("dir"));
            flip = ParseBool(macro.GetValue("flip"), 0);
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
        }
    }
}