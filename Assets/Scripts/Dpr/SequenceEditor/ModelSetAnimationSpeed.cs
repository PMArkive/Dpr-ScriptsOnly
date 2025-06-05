namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetAnimationSpeed, "pink", "one_frame", "")]
	public class ModelSetAnimationSpeed : Macro
	{
		public float speed;
		public int slot;
		
		public ModelSetAnimationSpeed(Macro macro) : base(macro)
        {
            speed = ParseFloat(macro.GetValue("speed"));
            slot = ParseInt(macro.GetValue("slot"), 0);
        }
    }
}