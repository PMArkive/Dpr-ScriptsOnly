namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffBackGroundChangeAnimState, "pink", "one_frame", "")]
	public class EffBackGroundChangeAnimState : Macro
	{
		public string state;
		
		public EffBackGroundChangeAnimState(Macro macro) : base(macro)
        {
            state = ParseString(macro.GetValue("state"));
        }
    }
}