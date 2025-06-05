namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.VibrationPlay, "blue", "one_frame", "")]
	public class VibrationPlay : Macro
	{
		public string hash;
		
		public VibrationPlay(Macro macro) : base(macro)
        {
            hash = ParseString(macro.GetValue("hash"));
        }
    }
}