using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonLookAt, "red", "", "")]
	public class PokemonLookAt : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 ofs;
		
		public PokemonLookAt(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseVector3(macro.GetValue("ofs"));
        }
    }
}