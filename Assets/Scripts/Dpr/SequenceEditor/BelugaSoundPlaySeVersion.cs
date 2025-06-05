namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.BelugaSoundPlaySeVersion, "blue", "one_frame", "")]
    public class BelugaSoundPlaySeVersion : Macro
	{
		public string pikaEvent;
		public string eeveEvent;
		public bool is3d;
		
		public BelugaSoundPlaySeVersion(Macro macro) : base(macro)
        {
            pikaEvent = ParseString(macro.GetValue("pikaEvent"));
            eeveEvent = ParseString(macro.GetValue("eeveEvent"));
            is3d = ParseBool(macro.GetValue("is3d"), 1);
        }
	}
}