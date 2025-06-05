using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerRotate, "lightyellow", "", "")]
	public class TrainerRotate : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public Vector3 rot;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public TrainerRotate(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            rot = ParseVector3(macro.GetValue("rot"));
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}