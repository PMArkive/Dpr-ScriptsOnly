using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraMoveRelativeTrainer, "yellow", "", "")]
    public class CameraMoveRelativeTrainer : Macro
	{
		public SEQ_DEF_TRAINER trgChara;
		public string node;
		public Vector3 pos;
		public Vector3 trg;
		public float fov;
		public int rate;
		public bool isFlip;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElemPos;
		public bool[] enableElemTrg;
		
		public CameraMoveRelativeTrainer(Macro macro) : base(macro)
		{
            trgChara = Parse_SEQ_DEF_TRAINER(macro.GetValue("trgChara"));
            node = ParseString(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            trg = ParseVector3(macro.GetValue("trg"));
            fov = ParseFloat(macro.GetValue("fov"));
            rate = ParseInt(macro.GetValue("rate"), 100);
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElemPos = ParseBoolArray(macro.GetValue("enableElemPos"), 1, 1, 1);
            enableElemTrg = ParseBoolArray(macro.GetValue("enableElemTrg"), 1, 1, 1);
        }
	}
}