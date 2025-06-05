namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetAnimationConfig, "pink", "one_frame", "PreloadModelAnimationConfig")]
	public class ModelSetAnimationConfig : Macro
	{
		public string file;
		
		public ModelSetAnimationConfig(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
        }
    }
}