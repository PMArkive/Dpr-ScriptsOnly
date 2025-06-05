namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DPokeSoundPlayVoice, "blue", "one_frame", "")]
	public class Old3DPokeSoundPlayVoice : Macro
	{
		public SEQ_DEF_POS trg;
		public string node;
		public VOICE_TYPE playType;
		public string voiceName;
		
		public Old3DPokeSoundPlayVoice(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            playType = Parse_VOICE_TYPE(macro.GetValue("playType"));
            voiceName = ParseString(macro.GetValue("voiceName"));
        }
    }
}