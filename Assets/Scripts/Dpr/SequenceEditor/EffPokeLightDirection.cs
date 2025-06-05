using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffPokeLightDirection, "lightgreen", "", "")]
	public class EffPokeLightDirection : Macro
	{
		public LIGHT_TYPE type;
		public SEQ_DEF_POS trg;
		public Vector3 dir;
		
		// TODO
		public EffPokeLightDirection(Macro macro) : base(macro)
        {
            type = Parse_LIGHT_TYPE(macro.GetValue("type"));
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            dir = ParseVector3(macro.GetValue("dir"));
        }
    }
}