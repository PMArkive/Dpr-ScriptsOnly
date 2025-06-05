namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetAnimation, "pink", "one_frame", "")]
	public class ModelSetAnimation : Macro
	{
		public string file;
		public bool loop;
		public int slot;
		
		public ModelSetAnimation(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
            loop = ParseBool(macro.GetValue("loop"), 0);
            slot = ParseInt(macro.GetValue("slot"), 0);
        }
    }
}