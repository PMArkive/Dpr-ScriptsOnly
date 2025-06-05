namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.BelugaSoundPlayVoice, "blue", "one_frame", "")]
    public class BelugaSoundPlayVoice : Macro
	{
		public int player;
		public SEQ_DEF_POS trg;
		public VOICE_TYPE type;
		
		public BelugaSoundPlayVoice(Macro macro) : base(macro)
        {
            player = ParseInt(macro.GetValue("player"));
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            type = Parse_VOICE_TYPE(macro.GetValue("type"));
        }
	}
}