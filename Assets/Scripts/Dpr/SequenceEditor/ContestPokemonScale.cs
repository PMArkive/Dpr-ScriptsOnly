using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonScale, "orange", "", "")]
	public class ContestPokemonScale : Macro
	{
		public SEQ_DEF_POS trg;
		public Vector3 scale;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public ContestPokemonScale(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}