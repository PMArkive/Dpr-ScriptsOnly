namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DSetSwitch, "blue", "one_frame", "")]
	public class Sound3DSetSwitch : Macro
	{
		public string group;
		public string name;
		
		public Sound3DSetSwitch(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}