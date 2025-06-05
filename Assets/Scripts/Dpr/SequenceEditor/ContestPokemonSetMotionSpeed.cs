namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPokemonSetMotionSpeed, "orange", "one_frame", "")]
	public class ContestPokemonSetMotionSpeed : Macro
	{
		public bool flg;
		public SEQ_DEF_POS trg;
		public float speed;
		
		public ContestPokemonSetMotionSpeed(Macro macro) : base(macro)
        {
            flg = ParseBool(macro.GetValue("flg"));
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            speed = ParseFloat(macro.GetValue("speed"));
        }
    }
}