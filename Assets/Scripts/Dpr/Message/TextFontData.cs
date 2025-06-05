using System;
using UnityEngine;

namespace Dpr.Message
{
    [CreateAssetMenu(fileName = "TextFontData", menuName = "ScriptableObjects/TextFontData")]
    public class TextFontData : ScriptableObject
    {
        public TextParameter[] textParamArray;

        public TextParameter GetTextParamByLanguageId(MessageEnumData.MsgLangId langId)
        {
            var param = Array.Find(textParamArray, x => x.langId == langId);
            if (param == null)
                MessageHelper.EmitLog(string.Format("TextParameter not found LanguageId : {0}", param.langId), LogType.Error);

            return param;
        }
    }
}