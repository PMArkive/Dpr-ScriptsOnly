namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprModelAnimationPlayIndex, "pink", "", "")]
	public class DprModelAnimationPlayIndex : Macro
	{
		public int index;
		public float duration;
		public float startTime;
		public bool isLoop;
		
		public DprModelAnimationPlayIndex(Macro macro) : base(macro)
        {
            index = ParseInt(macro.GetValue("index"), 0);
            duration = ParseFloat(macro.GetValue("duration"));
            startTime = ParseFloat(macro.GetValue("startTime"));
            isLoop = ParseBool(macro.GetValue("isLoop"), 0);
        }
    }
}