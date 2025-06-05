namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelReplaceTexture, "pink", "one_frame", "")]
	public class ModelReplaceTexture : Macro
	{
		public string file;
		public string matName;
		public int texNo;

		public ModelReplaceTexture(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
            matName = ParseString(macro.GetValue("matName"));
            texNo = ParseInt(macro.GetValue("texNo"));
        }
    }
}