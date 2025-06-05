namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.RotomStartEvent, "darkred", "one_frame", "")]
	public class RotomStartEvent : Macro
	{
		public ROTOM_EFFECT type;
		
		public RotomStartEvent(Macro macro) : base(macro)
        {
            type = Parse_ROTOM_EFFECT(macro.GetValue("type"));
        }
    }
}