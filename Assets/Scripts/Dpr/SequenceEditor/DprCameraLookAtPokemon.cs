namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraLookAtPokemon, "yellow", "", "")]
	public class DprCameraLookAtPokemon : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public SEQ_DEF_MOVETYPE move;
		
		public DprCameraLookAtPokemon(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}