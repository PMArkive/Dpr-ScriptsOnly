namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DPlayPokeVoiceObject, "blue", "one_frame", "")]
	public class Sound3DPlayPokeVoiceObject : Macro
	{
		public SEQ_DEF_POS trg;
		public string node;
		public VOICE_TYPE playType;
		public string voiceName;
		
		public Sound3DPlayPokeVoiceObject(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            playType = Parse_VOICE_TYPE(macro.GetValue("playType"));
            voiceName = ParseString(macro.GetValue("voiceName"));
        }
    }
}