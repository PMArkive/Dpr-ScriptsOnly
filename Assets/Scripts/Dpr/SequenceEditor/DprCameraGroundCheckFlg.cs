namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprCameraGroundCheckFlg, "yellow", "one_frame", "")]
	public class DprCameraGroundCheckFlg : Macro
	{
		public bool isEnable;
		public float height;
		public bool isFreeze;
		
		public DprCameraGroundCheckFlg(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"));
            height = ParseFloat(macro.GetValue("height"), 0.1f);
            isFreeze = ParseBool(macro.GetValue("isFreeze"), 0);
        }
    }
}