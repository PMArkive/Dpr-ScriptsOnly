namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestUserPokemonAttackMotion, "orange", "one_frame", "CheckAttackMotionTimming")]
	public class ContestUserPokemonAttackMotion : Macro
	{
		public SEQ_DEF_ATK_MOT motion;
		
		public ContestUserPokemonAttackMotion(Macro macro) : base(macro)
        {
            motion = Parse_SEQ_DEF_ATK_MOT(macro.GetValue("motion"));
        }
    }
}