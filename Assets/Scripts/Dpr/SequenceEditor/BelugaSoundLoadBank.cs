namespace Dpr.SequenceEditor
{
	[Macro(CommandNo.BelugaSoundLoadBank, "blue", "one_frame", "")]
	public class BelugaSoundLoadBank : Macro
	{
		public string name;
		
		public BelugaSoundLoadBank(Macro macro) : base(macro)
        {
            name = ParseString(macro.GetValue("name"));
        }
	}
}