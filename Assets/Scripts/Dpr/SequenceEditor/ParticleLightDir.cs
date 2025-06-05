using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleLightDir, "green", "one_frame", "")]
	public class ParticleLightDir : Macro
	{
		public bool reset;
		public Vector3 dir;
		public bool flip;
		public SEQ_DEF_POS flipTrg;
		
		public ParticleLightDir(Macro macro) : base(macro)
        {
            reset = ParseBool(macro.GetValue("reset"), 0);
            dir = ParseVector3(macro.GetValue("dir"));
            flip = ParseBool(macro.GetValue("flip"), 0);
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
        }
    }
}