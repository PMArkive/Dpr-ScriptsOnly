namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.UIFogSet, "lightgreen", "one_frame", "")]
	public class UIFogSet : Macro
	{
		public SEQ_DEF_UI_FOG param;
		
		public UIFogSet(Macro macro) : base(macro)
		{
            param = Parse_SEQ_DEF_UI_FOG(macro.GetValue("param"));
        }
	}
}