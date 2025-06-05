using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerMove, "lightyellow", "", "")]
	public class TrainerMove : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public Vector3 pos;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public TrainerMove(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}