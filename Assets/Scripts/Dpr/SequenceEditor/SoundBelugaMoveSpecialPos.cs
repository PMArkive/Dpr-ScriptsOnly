using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaMoveSpecialPos, "blue", "", "")]
	public class SoundBelugaMoveSpecialPos : Macro
	{
		public SEQ_DEF_SPPOS pos;
		public Vector3 ofs;
		public bool isFlip;
		public bool isRot;
		
		public SoundBelugaMoveSpecialPos(Macro macro) : base(macro)
        {
            pos = Parse_SEQ_DEF_SPPOS(macro.GetValue("pos"));
            ofs = ParseVector3(macro.GetValue("ofs"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
        }
    }
}