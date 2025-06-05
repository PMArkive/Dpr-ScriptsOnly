namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonAttackMotion, "red", "one_frame", "CheckAttackMotionTimming")]
	public class PokemonAttackMotion : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_ATK_MOT motion;
		
		public PokemonAttackMotion(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            motion = Parse_SEQ_DEF_ATK_MOT(macro.GetValue("motion"));
        }
    }
}