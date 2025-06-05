namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GaugeDamage, "lightblue", "", "")]
	public class GaugeDamage : Macro
	{
		public SEQ_DEF_POS trg;
		public bool disable;
		
		public GaugeDamage(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            disable = ParseBool(macro.GetValue("disable"), 0);
        }
    }
}