using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonMovePositionRelativeStage, "orange", "", "")]
	public class ContestPokemonMovePositionRelativeStage : Macro
	{
		public SEQ_DEF_POS trg;
		public Vector3 pos;
		public bool relative;
		public bool isRotPos;
		public bool isFlip;
		public SEQ_DEF_MOVETYPE move;
		public bool[] enableElem;
		
		public ContestPokemonMovePositionRelativeStage(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            isRotPos = ParseBool(macro.GetValue("isRotPos"));
            isFlip = ParseBool(macro.GetValue("isFlip"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            enableElem = ParseBoolArray(macro.GetValue("enableElem"), 1, 1, 1);
        }
    }
}