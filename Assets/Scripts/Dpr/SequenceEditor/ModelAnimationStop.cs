namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelAnimationStop, "pink", "one_frame", "")]
	public class ModelAnimationStop : Macro
	{
		public int slot;
		
		public ModelAnimationStop(Macro macro) : base(macro)
        {
            slot = ParseInt(macro.GetValue("slot"), 0);
        }
    }
}