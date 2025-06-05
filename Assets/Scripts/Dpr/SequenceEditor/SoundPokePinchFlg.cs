namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundPokePinchFlg, "blue", "", "")]
	public class SoundPokePinchFlg : Macro
	{
		public bool isRTPC;
		public bool isPlay;
		
		public SoundPokePinchFlg(Macro macro) : base(macro)
        {
            isRTPC = ParseBool(macro.GetValue("isRTPC"), 1);
            isPlay = ParseBool(macro.GetValue("isPlay"), 1);
        }
    }
}