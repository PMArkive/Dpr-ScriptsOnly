using System.Text;

namespace Dpr.Message
{
    public class WordDataModel
    {
        public bool isUse;
        public StringBuilder sb = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
        public MessageEnumData.MsgEventID endEventId;
        public MessageEnumData.MsgLangId languageId;
        public float tagValue;
        public float strWidth = -1.0f;
        public bool bIsRichTextTag;

        public int Length { get => bIsRichTextTag ? 0 : sb.Length; }
        public int StrLength { get => sb.Length; }
        public bool IsNewLineEvent
        {
            get
            {
                switch (endEventId)
                {
                    case MessageEnumData.MsgEventID.NewLine:
                    case MessageEnumData.MsgEventID.ScrollPage:
                    case MessageEnumData.MsgEventID.ScrollLine:
                        return true;

                    default:
                        return false;
                }
            }
        }

        public void Init()
        {
            Reset();
        }

        private void Reset()
        {
            bIsRichTextTag = false;
            endEventId = MessageEnumData.MsgEventID.None;
            sb.Clear();
            tagValue = 0.0f;
            strWidth = -1.0f;
        }

        public void AppendStr(string message)
        {
            sb.Append(message);
        }

        public string GetMessage()
        {
            return sb.ToString();
        }

        public string GetMessageSubstring(int startIndex)
        {
            return sb.ToString(startIndex, 1);
        }

        public void Clear()
        {
            isUse = false;
            Reset();
        }
    }
}