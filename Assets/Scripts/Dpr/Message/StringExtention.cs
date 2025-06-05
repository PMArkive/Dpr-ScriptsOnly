namespace Dpr.Message
{
    public static class StringExtention
    {
        public static string GetInvalidRichText(this string str)
        {
            return str.Replace("<", string.Format("<{0}", MessageHelper.ConvertUnicodeToChar(MessageDataConstants.ZERO_SPACE_CODE)));
        }
    }
}