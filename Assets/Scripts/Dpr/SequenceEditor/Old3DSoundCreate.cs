namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundCreate, "blue", "", "")]
	public class Old3DSoundCreate : Macro
	{
		public string regist;
		
		public Old3DSoundCreate(Macro macro) : base(macro)
        {
            regist = ParseString(macro.GetValue("regist"));
        }
    }
}