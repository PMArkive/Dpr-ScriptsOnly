using Nintendo.MessageStudio.Lib;
using System.Text;

namespace Dpr.Message
{
    public class MessageTagAnalyzer
    {
        private const int SYSTEM_TAG_SIZE = 20;
        private StringBuilder systemTagStrBuilder = new StringBuilder(SYSTEM_TAG_SIZE);
        private const int MAX_WORD_SIZE = 30;
        private const int BYTE_SIZE = 2;
        private const int MIN_BYTE_LENGTH = 4;
        private StringBuilder wordStrBuilder = new StringBuilder(MAX_WORD_SIZE);
        private byte[] byteArray = new byte[BYTE_SIZE];

        // TODO
        public LabelTagDataModel CustomTagAnalysis(ushort tagGroup, ushort tag, byte[] tagParams) { return null; }

        // TODO
        private void NameTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void DigitTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void GrmTagProcess(LabelTagDataModel tagDataModel) { }

        // TODO
        private void ENTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void FRTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void ITTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void DETagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void ESTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void KorTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void SCTagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void Character1TagProcess(LabelTagDataModel tagDataModel) { }

        // TODO
        private void Character2TagProcess(LabelTagDataModel tagDataModel) { }

        // TODO
        private void Ctrl1TagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private string ConvertCtrl1TagToRichText(MessageEnumData.Ctrl1ID ctrl1ID, float value) { return null; }

        // TODO
        private void Ctrl2TagProcess(LabelTagDataModel tagDataModel, byte[] tagParams) { }

        // TODO
        private void EmitErrorLog(MessageEnumData.GroupTagID groupTagId) { }

        // TODO
        public LabelTagDataModel ColorTagAnalysis(ColorTagInfo colorTagInfo) { return null; }

        // TODO
        public LabelTagDataModel FontTagAnalysis(FontTagInfo fontTagInfo) { return null; }

        // TODO
        private string GetFontFileName(int fontFileIndex) { return null; }

        // TODO
        public LabelTagDataModel SizeTagAnalysis(SizeTagInfo sizeTagInfo) { return null; }

        // TODO
        private string[] ExtractGrmWords(byte[] tagParams) { return null; }

        // TODO
        private int GetWordByteLength(byte[] tagParams, int startIndex) { return 0; }
    }
}