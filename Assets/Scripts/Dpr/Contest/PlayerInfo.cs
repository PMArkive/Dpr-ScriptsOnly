using Dpr.Message;
using Pml;
using XLSXContent;

namespace Dpr.Contest
{
	public class PlayerInfo
	{
		public string nickname;
		public MessageEnumData.MsgLangId langID;
		public Sex sex;
		public TrainerTable.SheetTrainerType trainerType;
		
		public string LocalizeNickName()
		{
			return MessageHelper.SurroundFontTag(nickname.GetInvalidRichText(), langID);
		}
	}
}