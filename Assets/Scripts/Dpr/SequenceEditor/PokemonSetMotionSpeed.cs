namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonSetMotionSpeed, "red", "one_frame", "")]
	public class PokemonSetMotionSpeed : Macro
	{
		public bool flg;
		public SEQ_DEF_POS trg;
		public float speed;
		
		public PokemonSetMotionSpeed(Macro macro) : base(macro)
        {
            flg = ParseBool(macro.GetValue("flg"), 0);
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            speed = ParseFloat(macro.GetValue("speed"));
        }
    }
}