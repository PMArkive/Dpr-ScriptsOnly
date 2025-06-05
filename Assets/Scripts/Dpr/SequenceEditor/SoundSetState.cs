namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundSetState, "blue", "one_frame", "")]
	public class SoundSetState : Macro
	{
		public string group;
		public string name;
		
		public SoundSetState(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}