namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraCheckGroundFlg, "yellow", "one_frame", "")]
    public class CameraCheckGroundFlg : Macro
	{
		public bool flg;
		
		public CameraCheckGroundFlg(Macro macro) : base(macro)
        {
            flg = ParseBool(macro.GetValue("flg"), 1);
        }
	}
}