using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraAnimationTrainer, "yellow", "one_frame", "PreloadCameraAnimationTrainer")]
	public class DprCameraAnimationTrainer : Macro
	{
		public SEQ_DEF_TR_CAM camType;
		public string camFile;
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_NODE_MODEL node;
		public Vector3 pos;
		public bool isFlip;
		public bool isScale;
		public bool isRot;
		public bool forceUpdate;
		public bool isLoseCam;
		
		public DprCameraAnimationTrainer(Macro macro) : base(macro)
        {
            camType = Parse_SEQ_DEF_TR_CAM(macro.GetValue("camType"));
            camFile = ParseString(macro.GetValue("camFile"));
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = (SEQ_DEF_NODE_MODEL)ParseInt(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isScale = ParseBool(macro.GetValue("isScale"), 0);
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            isLoseCam = ParseBool(macro.GetValue("isLoseCam"), 0);
        }
    }
}