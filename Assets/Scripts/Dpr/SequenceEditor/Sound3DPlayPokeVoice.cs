namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DPlayPokeVoice, "blue", "one_frame", "")]
	public class Sound3DPlayPokeVoice : Macro
	{
		public SEQ_DEF_POS trg;
		public VOICE_TYPE playType;
		public string voiceName;
		public bool IsPinch;
		public bool isGPoke;
		
		public Sound3DPlayPokeVoice(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            playType = Parse_VOICE_TYPE(macro.GetValue("playType"));
            voiceName = ParseString(macro.GetValue("voiceName"));
            IsPinch = ParseBool(macro.GetValue("IsPinch"), 0);
            isGPoke = ParseBool(macro.GetValue("isGPoke"), 0);
        }
    }
}