namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DCreate, "blue", "", "")]
	public class Sound3DCreate : Macro
	{
		public string regist;
		public bool isVoice;
		
		public Sound3DCreate(Macro macro) : base(macro)
        {
            regist = ParseString(macro.GetValue("regist"));
            isVoice = ParseBool(macro.GetValue("isVoice"), 0);
        }
    }
}