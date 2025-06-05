namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DPlayVoice, "blue", "one_frame", "")]
	public class Sound3DPlayVoice : Macro
	{
		public SEQ_DEF_POS trg;
		public string voiceType;
		public bool is2DSound;
		public bool IsPinch;
		public bool isGPoke;
		
		public Sound3DPlayVoice(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            voiceType = ParseString(macro.GetValue("voiceType"));
            is2DSound = ParseBool(macro.GetValue("is2DSound"), 0);
            IsPinch = ParseBool(macro.GetValue("IsPinch"), 0);
            isGPoke = ParseBool(macro.GetValue("isGPoke"), 0);
        }
    }
}