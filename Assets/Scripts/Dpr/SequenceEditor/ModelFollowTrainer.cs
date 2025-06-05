using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelFollowTrainer, "pink", "one_frame", "")]
	public class ModelFollowTrainer : Macro
	{
		public bool isEnable;
		public SEQ_DEF_TRAINER trg;
		public string node;
		public bool isPos;
		public bool isRot;
		public bool isScl;
		public Vector3 pos;
		public Vector3 rot;
		public bool changeLight;
		public bool checkVisible;
		
		public ModelFollowTrainer(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            isPos = ParseBool(macro.GetValue("isPos"), 1);
            isRot = ParseBool(macro.GetValue("isRot"), 1);
            isScl = ParseBool(macro.GetValue("isScl"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            rot = ParseVector3(macro.GetValue("rot"));
            changeLight = ParseBool(macro.GetValue("changeLight"), 0);
            checkVisible = ParseBool(macro.GetValue("checkVisible"), 0);
        }
    }
}