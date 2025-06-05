namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundFinishCheckInvalid, "blue", "one_frame", "")]
	public class SoundFinishCheckInvalid : Macro
	{
		public bool enable;
		
		public SoundFinishCheckInvalid(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
        }
    }
}