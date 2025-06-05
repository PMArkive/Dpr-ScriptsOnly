namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestDprModelAnimationPlayIndex, "orange", "", "")]
	public class ContestDprModelAnimationPlayIndex : Macro
	{
		public int index;
		public float duration;
		public float startTime;
		public bool isLoop;
		
		public ContestDprModelAnimationPlayIndex(Macro macro) : base(macro)
        {
            index = ParseInt(macro.GetValue("index"), 0);
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
            isLoop = ParseBool(macro.GetValue("isLoop"), 0);
        }
    }
}