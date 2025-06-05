namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialChangeWeather, "purple", "one_frame", "")]
	public class SpecialChangeWeather : Macro
	{
		public SEQ_DEF_WEATHER type;
		
		public SpecialChangeWeather(Macro macro) : base(macro)
        {
            type = Parse_SEQ_DEF_WEATHER(macro.GetValue("type"));
        }
    }
}