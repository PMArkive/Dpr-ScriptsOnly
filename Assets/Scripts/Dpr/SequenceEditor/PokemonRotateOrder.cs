namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonRotateOrder, "red", "one_frame", "")]
	public class PokemonRotateOrder : Macro
	{
		public SEQ_DEF_POS trgPoke;
		public SEQ_DEF_ROTATE_ORDER rotOrder;
		public SEQ_DEF_MOVETYPE move;
		
		public PokemonRotateOrder(Macro macro) : base(macro)
        {
            trgPoke = Parse_SEQ_DEF_POS(macro.GetValue("trgPoke"));
            rotOrder = Parse_SEQ_DEF_ROTATE_ORDER(macro.GetValue("rotOrder"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}