namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetAutoRotate, "pink", "one_frame", "")]
	public class ModelSetAutoRotate : Macro
	{
		public bool isEnable;
		
		public ModelSetAutoRotate(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}