using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonMoveRelativeTrainer, "red", "", "")]
	public class PokemonMoveRelativeTrainer : Macro
	{
		public SEQ_DEF_POS moveTrg;
		public SEQ_DEF_TRAINER trg;
		public string node;
		public Vector3 pos;
		public bool isRot;
		public bool forceUpdate;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonMoveRelativeTrainer(Macro macro) : base(macro)
        {
            moveTrg = Parse_SEQ_DEF_POS(macro.GetValue("moveTrg"));
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            pos = ParseVector3(macro.GetValue("pos"));
            isRot = ParseBool(macro.GetValue("isRot"), 0);
            forceUpdate = ParseBool(macro.GetValue("forceUpdate"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}