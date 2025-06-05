using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraMoveSpecialPos, "yellow", "", "")]
    public class CameraMoveSpecialPos : Macro
	{
		public SEQ_DEF_SPPOS posTrg;
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public bool isFlip;
		public bool isRot;
		public SEQ_DEF_MOVETYPE move;
		
		public CameraMoveSpecialPos(Macro macro) : base(macro)
		{
            posTrg = Parse_SEQ_DEF_SPPOS(macro.GetValue("posTrg"));
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
	}
}