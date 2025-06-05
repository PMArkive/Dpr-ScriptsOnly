namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.UniQualitySettingsShadow, "violet", "one_frame", "")]
	public class UniQualitySettingsShadow : Macro
	{
		public bool isReset;
		public float shadowDistance;
		public float shadowNearPlaneOffset;
		
		public UniQualitySettingsShadow(Macro macro) : base(macro)
        {
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            shadowDistance = ParseFloat(macro.GetValue("shadowDistance"), 20.0f);
            shadowNearPlaneOffset = ParseFloat(macro.GetValue("shadowNearPlaneOffset"), 3.0f);
        }
    }
}