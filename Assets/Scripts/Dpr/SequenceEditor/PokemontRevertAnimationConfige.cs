namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemontRevertAnimationConfige, "red", "one_frame", "")]
	public class PokemontRevertAnimationConfige : Macro
	{
		public SEQ_DEF_POS trg;
		
		public PokemontRevertAnimationConfige(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}