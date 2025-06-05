namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundSetSwitch, "blue", "one_frame", "")]
	public class SoundSetSwitch : Macro
	{
		public string group;
		public string name;
		
		public SoundSetSwitch(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}