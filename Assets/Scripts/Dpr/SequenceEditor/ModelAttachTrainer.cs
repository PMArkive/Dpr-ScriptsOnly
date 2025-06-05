using Dpr.SecretBase;
using UnityEngine.UI;
namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelAttachTrainer, "pink", "one_frame", "")]
	public class ModelAttachTrainer : Macro
	{
		public bool isEnable;
		public SEQ_DEF_TRAINER trg;
		public string node;
		public bool changeLight;
		public bool isAnimScl;
		public bool isLocalScl;
		
		public ModelAttachTrainer(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            changeLight = ParseBool(macro.GetValue("changeLight"), 0);
            isAnimScl = ParseBool(macro.GetValue("isAnimScl"), 0);
            isLocalScl = ParseBool(macro.GetValue("isLocalScl"), 0);
        }
    }
}