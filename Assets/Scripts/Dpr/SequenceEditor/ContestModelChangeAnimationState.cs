namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestModelChangeAnimationState, "pink", "one_frame", "")]
	public class ContestModelChangeAnimationState : Macro
	{
		public string state;
		
		public ContestModelChangeAnimationState(Macro macro) : base(macro)
        {
            state = ParseString(macro.GetValue("state"));
        }
    }
}