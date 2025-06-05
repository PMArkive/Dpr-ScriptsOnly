using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraMoveRelativePoke, "yellow", "", "PreloadCameraAnimation")]
	public class SubCameraMoveRelativePoke : Macro
	{
		public SEQ_DEF_POS poke;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public int rate;
		public bool isFlip;
		public bool isScale;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElemPos;
		public bool[] enableElemTrg;
		
		public SubCameraMoveRelativePoke(Macro macro) : base(macro)
        {
            poke = Parse_SEQ_DEF_POS(macro.GetValue("poke"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isScale = ParseBool(macro.GetValue("isScale"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
            enableElemTrg = ParseBoolArray(macro.GetValue("enableElemTrg"), 1, 1, 1);
        }
	}
}