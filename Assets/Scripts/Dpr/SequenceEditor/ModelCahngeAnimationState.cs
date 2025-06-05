namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelCahngeAnimationState, "pink", "one_frame", "")]
	public class ModelCahngeAnimationState : Macro
	{
		public string state;
		
		public ModelCahngeAnimationState(Macro macro) : base(macro)
        {
            state = ParseString(macro.GetValue("state"));
        }
    }
}