namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundSetSwitch, "blue", "one_frame", "")]
	public class Old3DSoundSetSwitch : Macro
	{
		public string group;
		public string name;
		
		public Old3DSoundSetSwitch(Macro macro) : base(macro)
        {
            group = ParseString(macro.GetValue("group"));
            name = ParseString(macro.GetValue("name"));
        }
    }
}