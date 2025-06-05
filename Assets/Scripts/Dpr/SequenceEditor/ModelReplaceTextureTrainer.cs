namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelReplaceTextureTrainer, "pink", "one_frame", "")]
	public class ModelReplaceTextureTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_TR_TEX type;
		public string matName;
		public int texNo;
		
		public ModelReplaceTextureTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            type = Parse_SEQ_DEF_TR_TEX(macro.GetValue("type"));
            matName = ParseString(macro.GetValue("matName"));
            texNo = ParseInt(macro.GetValue("texNo"));
        }
    }
}