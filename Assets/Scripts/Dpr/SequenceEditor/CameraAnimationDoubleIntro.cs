using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraAnimationDoubleIntro, "yellow", "one_frame", "")]
    public class CameraAnimationDoubleIntro : Macro
	{
		public string envfile;
		public string motfileA;
		public string motfileB;
		public string motfileC;
		public SEQ_DEF_POS trgA;
		public SEQ_DEF_POS trgB;
		public SEQ_DEF_NODE node;
		public Vector3 pos;
		public bool isFlip;
		public bool isRot;
		public bool forceUpdate;
		
		public CameraAnimationDoubleIntro(Macro macro) : base(macro)
        {
            envfile = ParseString(macro.GetValue("envfile"));
            motfileA = ParseString(macro.GetValue("motfileA"));
            motfileB = ParseString(macro.GetValue("motfileB"));
            motfileC = ParseString(macro.GetValue("motfileC"));
            trgA = Parse_SEQ_DEF_POS(macro.GetValue("trgA"));
            trgB = Parse_SEQ_DEF_POS(macro.GetValue("trgB"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
        }
	}
}