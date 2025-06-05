using Pml;
using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialFieldEffectCreate, "purple", "one_frame", "PreloadGroundParticle")]
	public class SpecialFieldEffectCreate : Macro
	{
		public SEQ_DEF_FWAZA_TYPE type;
		public Vector3 ofs;
		
		public SpecialFieldEffectCreate(Macro macro) : base(macro)
        {
            type = Parse_SEQ_DEF_FWAZA_TYPE(macro.GetValue("type"));
            ofs = ParseVector3(macro.GetValue("ofs"));
        }
    }
}