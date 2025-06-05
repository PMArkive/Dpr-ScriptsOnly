namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundSetState, "blue", "one_frame", "")]
	public class OldSoundSetState : Macro
	{
		public string group;
		public string name;
		
		public OldSoundSetState(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}