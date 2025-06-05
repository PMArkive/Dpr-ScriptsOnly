namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialDeleteParticle, "purple", "one_frame", "")]
	public class SpecialDeleteParticle : Macro
	{
		public string file;
		
		public SpecialDeleteParticle(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
        }
    }
}