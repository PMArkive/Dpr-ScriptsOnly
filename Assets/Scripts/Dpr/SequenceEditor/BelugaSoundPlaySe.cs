namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.BelugaSoundPlaySe, "blue", "one_frame", "")]
    public class BelugaSoundPlaySe : Macro
	{
		public string @event;
		public bool is3d;
		
		public BelugaSoundPlaySe(Macro macro) : base(macro)
        {
            @event = ParseString(macro.GetValue("event"));
			is3d = ParseBool(macro.GetValue("is3d"), 1);
        }
	}
}