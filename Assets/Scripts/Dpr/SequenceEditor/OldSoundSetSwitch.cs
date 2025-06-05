namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundSetSwitch, "blue", "one_frame", "")]
	public class OldSoundSetSwitch : Macro
	{
		public string group;
		public string name;
		
		public OldSoundSetSwitch(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}