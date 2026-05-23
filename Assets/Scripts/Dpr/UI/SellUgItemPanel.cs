using Dpr.Message;
using Pml.UgFather;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SellUgItemPanel : MonoBehaviour
	{
		[SerializeField]
		private Image itemIconImage;
		[SerializeField]
		private UIText itemNameText;
		[SerializeField]
		private UIText tradeInfoText;
		[SerializeField]
		private UIText haveCountText;

		private MessageMsgFile msgFile;
		
		public void Initialize()
		{
			msgFile = MessageManager.Instance.GetMsgFile("ss_fld_shop");
			SetPanelActive(false);
		}
		
		public void ShowSellItemPanel(UgFatherDataManager.SellItemData data)
		{
			itemIconImage.sprite = data.iconSpr;

			MessageWordSetHelper.SetUgItemNameWord(0, data.ugItemID);
			itemNameText.text = msgFile.GetFormattedMessage("SS_fld_shop_299");

            MessageWordSetHelper.SetDigitWord(0, data.price);
			tradeInfoText.text = msgFile.GetFormattedMessage("SS_fld_shop_319");

            MessageWordSetHelper.SetDigitWord(0, data.haveCount);
			haveCountText.text = msgFile.GetFormattedMessage("SS_fld_shop_302");

            SetPanelActive(true);
        }
		
		public void HideSellItemPanel()
		{
            SetPanelActive(false);
        }
		
		private void SetPanelActive(bool active)
		{
			if (gameObject.activeSelf != active)
				gameObject.SetActive(active);
		}
	}
}