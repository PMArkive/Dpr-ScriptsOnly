namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.RaidWallGaugeUpdate, "lightblue", "one_frame", "")]
	public class RaidWallGaugeUpdate : Macro
	{
		public int frame;
		
		public RaidWallGaugeUpdate(Macro macro) : base(macro)
        {
            frame = ParseInt(macro.GetValue("isEnable"), 0);
        }
    }
}