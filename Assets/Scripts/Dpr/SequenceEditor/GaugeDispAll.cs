namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GaugeDispAll, "lightblue", "one_frame", "")]
	public class GaugeDispAll : Macro
	{
		public bool visible;
		
		public GaugeDispAll(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
        }
    }
}