namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundFinishCheckInvalid, "blue", "one_frame", "")]
	public class OldSoundFinishCheckInvalid : Macro
	{
		public bool enable;
		
		public OldSoundFinishCheckInvalid(Macro macro) : base(macro)
        {
            enable = ParseBool(macro.GetValue("enable"), 1);
        }
    }
}