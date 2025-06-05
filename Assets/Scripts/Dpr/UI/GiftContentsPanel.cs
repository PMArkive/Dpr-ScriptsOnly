using DPData.MysteryGift;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftContentsPanel : MonoBehaviour
	{
		private const int TextLineMargin = 26;
		private const string MessageFileName = "ss_net_mystery";

		private static readonly string[] ItemLabelNames = new string[]
		{
            "SS_net_mystery_099", "SS_net_mystery_100", "SS_net_mystery_101", "SS_net_mystery_102",
            "SS_net_mystery_103", "SS_net_mystery_100", "SS_net_mystery_105", "SS_net_mystery_324",
        };
		private static readonly string[] DressUpLabelNames = new string[]
        {
            "",                   "SS_net_mystery_107", "SS_net_mystery_108", "SS_net_mystery_109",
            "SS_net_mystery_110", "SS_net_mystery_111", "SS_net_mystery_112", "SS_net_mystery_326",
        };
        private static readonly string[] UnderGroundItemLabelNames = new string[]
        {
            "SS_net_mystery_314", "SS_net_mystery_315", "SS_net_mystery_316", "SS_net_mystery_317",
            "SS_net_mystery_318", "SS_net_mystery_319", "SS_net_mystery_320", "SS_net_mystery_325",
        };

        [SerializeField]
		private UIText titleText;
		[SerializeField]
		private UIText receiveDateText;
		[SerializeField]
		private UIText contentsText;
		
		// TODO
		public void Setup(RecvData data)
		{
			// TODO
			IEnumerable DelaySetup() { return default; }
        }
		
		// TODO
		private void SetupContentTextLineSpacing() { }
		
		// TODO
		private void SetReceiveDateText(long timestamp) { }
		
		// TODO
		private void SetContentsText(RecvData data) { }
	}
}