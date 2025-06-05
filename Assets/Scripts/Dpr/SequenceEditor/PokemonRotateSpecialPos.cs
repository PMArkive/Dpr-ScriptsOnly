using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonRotateSpecialPos, "red", "", "")]
	public class PokemonRotateSpecialPos : Macro
	{
		public SEQ_DEF_POS trgPoke;
		public SEQ_DEF_SPPOS pos;
		public Vector3 ofs;
		public bool isFlip;
		public bool isRot;
		public float rotOfs;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonRotateSpecialPos(Macro macro) : base(macro)
        {
            trgPoke = Parse_SEQ_DEF_POS(macro.GetValue("trgPoke"));
            pos = Parse_SEQ_DEF_SPPOS(macro.GetValue("pos"));
            ofs = ParseVector3(macro.GetValue("ofs"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            rotOfs = ParseFloat(macro.GetValue("rotOfs"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}