namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraCheckGroundFlg, "yellow", "one_frame", "")]
	public class SubCameraCheckGroundFlg : Macro
	{
		public bool flg;
		
		public SubCameraCheckGroundFlg(Macro macro) : base(macro)
        {
            flg = ParseBool(macro.GetValue("flg"), 1);
        }
	}
}