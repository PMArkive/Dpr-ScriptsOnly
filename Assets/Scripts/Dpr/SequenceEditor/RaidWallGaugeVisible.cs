namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.RaidWallGaugeVisible, "lightblue", "one_frame", "")]
	public class RaidWallGaugeVisible : Macro
	{
		public bool visible;
		
		public RaidWallGaugeVisible(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
        }
    }
}