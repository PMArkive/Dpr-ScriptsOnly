using System.Collections.Generic;
using TMPro;

namespace Dpr.Message
{
    public class FontAssetInfo
    {
        public TMP_FontAsset fontAsset;
        public TextParameter textParam;
        private Dictionary<int, int> absFontSizeTable = new Dictionary<int, int>();

        public FontAssetInfo(TextParameter textParam, TMP_FontAsset fontAsset)
        {
            this.textParam = textParam;
            this.fontAsset = fontAsset;

            var faceInfo = this.fontAsset.faceInfo;
            faceInfo.lineHeight = textParam.lineHeight;
            this.fontAsset.faceInfo = faceInfo;

            for (int i=0; i<textParam.absFontSizeArray.Length; i++)
            {
                var item = textParam.absFontSizeArray[i];
                if (absFontSizeTable.ContainsKey(item.fontSize))
                    MessageHelper.EmitLog(string.Format("Failed Add absFontSizeTable : Already Add Key {0} in Language {1}", item.fontSizeId, textParam.langId), UnityEngine.LogType.Error);
                else
                    absFontSizeTable.Add((int)item.fontSizeId, item.fontSize);
            }
        }

        public MessageEnumData.MsgLangId LangId { get => textParam.langId; }
        public int LanguageIdToInt { get => (int)textParam.langId; }

        public float GetBaseLine()
        {
            return textParam.baseLineHeight;
        }

        public int GetAbsFontSizeBySizeID(MessageEnumData.UIFontSizeID fontSizeId)
        {
            return absFontSizeTable[(int)fontSizeId];
        }

        public void AddCharacters(string str)
        {
            fontAsset.HasCharacters(str.Replace("\n", string.Empty), out _, false, true);
        }

        public void ClearFallbackFontAtlas()
        {
            if (fontAsset == null)
                return;

            foreach (var item in fontAsset.fallbackFontAssetTable)
            {
                if (item.atlasPopulationMode == AtlasPopulationMode.Dynamic)
                    item.ClearFontAssetData(false);
            }
        }
    }
}