namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundPokePinchFlg, "blue", "", "")]
	public class OldSoundPokePinchFlg : Macro
	{
		public bool isRTPC;
		public bool isPlay;
		
		public OldSoundPokePinchFlg(Macro macro) : base(macro)
        {
            isRTPC = ParseBool(macro.GetValue("isRTPC"), 1);
            isPlay = ParseBool(macro.GetValue("isPlay"), 1);
        }
    }
}