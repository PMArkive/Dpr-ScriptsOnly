using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleMoveRelativeTrainer, "green", "", "")]
	public class ParticleMoveRelativeTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public string node;
		public Vector3 pos;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleMoveRelativeTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}