using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleMoveSpecialPos, "green", "", "")]
	public class ParticleMoveSpecialPos : Macro
	{
		public SEQ_DEF_SPPOS pos;
		public Vector3 ofs;
		public bool isFlip;
		public bool isRot;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleMoveSpecialPos(Macro macro) : base(macro)
        {
            pos = Parse_SEQ_DEF_SPPOS(macro.GetValue("pos"));
            ofs = ParseVector3(macro.GetValue("ofs"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}