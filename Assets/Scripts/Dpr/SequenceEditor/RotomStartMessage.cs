namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.RotomStartMessage, "darkred", "one_frame", "")]
	public class RotomStartMessage : Macro
	{
		public ROTOM_EFFECT type;
		public int opt;
		
		public RotomStartMessage(Macro macro) : base(macro)
        {
            type = Parse_ROTOM_EFFECT(macro.GetValue("type"));
            opt = ParseInt(macro.GetValue("opt"));
        }
    }
}