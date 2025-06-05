using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationPoke, "yellow", "one_frame", "PreloadCameraAnimation")]
    public class CameraAnimationPoke : Macro
	{
		public string camFile;
		public string anmFile;
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public bool isFlip;
		public bool isScale;
		public bool isRot;
		public bool forceUpdate;
		
		public CameraAnimationPoke(Macro macro) : base(macro)
        {
            camFile = ParseString(macro.GetValue("camFile"));
            anmFile = ParseString(macro.GetValue("anmFile"));
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isScale = ParseBool(macro.GetValue("isScale"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
        }
	}
}