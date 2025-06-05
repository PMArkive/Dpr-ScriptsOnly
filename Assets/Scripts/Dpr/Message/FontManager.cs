using SmartPoint.AssetAssistant;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dpr.Message
{
    public class FontManager : SingletonMonoBehaviour<FontManager>
    {
        [SerializeField]
        private TextFontData textFontData;
        [SerializeField]
        private FontMaterialData fontMaterialData;
        [SerializeField]
        private TMP_SpriteAsset spriteFontAsset;
        private Dictionary<int, FontAssetInfo> fontInfoTable = new Dictionary<int, FontAssetInfo>();
        private Dictionary<int, FontMaterialProperty> materialPropertyTable = new Dictionary<int, FontMaterialProperty>();
        private Dictionary<int, Material> materialTable = new Dictionary<int, Material>();
        private FontAssetLoader fontAssetLoader = new FontAssetLoader();
        private int useEFIGSCount;

        protected override bool Awake()
        {
            fontAssetLoader.OnAwake();
            useEFIGSCount = 0;
            return base.Awake();
        }

        private void Start()
        {
            LoadAllFontAsset();
            InitializeMaterialSetting();

            Sequencer.onDestroy += Destroy;
        }

        private void InitializeMaterialSetting()
        {
            materialPropertyTable.Add(0, fontMaterialData.defaultMaterialProperty);
            for (int i=0; i<fontMaterialData.materialPropertyArray.Length; i++)
                materialPropertyTable.Add(i + 1, fontMaterialData.materialPropertyArray[i]);
        }

        private void Destroy()
        {
            Sequencer.onDestroy -= Destroy;
            DestroyAllFontAsset();
            fontAssetLoader.OnFinalize();
        }

        private void DestroyAllFontAsset()
        {
            ClearAllFontAtlas();
            ClearMaterialTable();
            UnloadFontAssets();
            fontInfoTable = null;
        }

        public bool IsRunning { get => fontAssetLoader.RunningLoad; }

        public void LoadAllFontAsset()
        {
            RegistLoadTask(MessageEnumData.MsgLangId.JPN);
            RegistLoadTask(MessageEnumData.MsgLangId.USA);
            RegistLoadTask(MessageEnumData.MsgLangId.FRA);
            RegistLoadTask(MessageEnumData.MsgLangId.ITA);
            RegistLoadTask(MessageEnumData.MsgLangId.DEU);
            RegistLoadTask(MessageEnumData.MsgLangId.ESP);
            RegistLoadTask(MessageEnumData.MsgLangId.KOR);
            RegistLoadTask(MessageEnumData.MsgLangId.SCH);
            RegistLoadTask(MessageEnumData.MsgLangId.TCH);
            fontAssetLoader.PerformLoad();
        }

        public void LoadFontAssetByLangId(MessageEnumData.MsgLangId langId)
        {
            RegistLoadTask(langId);
            fontAssetLoader.PerformLoad();
        }

        private void RegistLoadTask(MessageEnumData.MsgLangId langId)
        {
            int language = (int)langId;
            if (MessageHelper.IsEFIGS(langId))
            {
                language = 2;
                useEFIGSCount++;
            }

            if (HasFontDataModel(language))
                return;

            if (fontAssetLoader.HasLoadTaskByLanguageId((MessageEnumData.MsgLangId)language))
                return;

            fontAssetLoader.RegistLoadFontAssetTask(langId, OnFinishedLoadFontAsset);
        }

        public void UnloadFontAssets()
        {
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.JPN);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.USA);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.FRA);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.ITA);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.DEU);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.ESP);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.KOR);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.SCH);
            UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId.TCH);
            fontInfoTable.Clear();
        }

        private void UnloadFontAssetByLanguageId(MessageEnumData.MsgLangId langId)
        {
            var language = ConvertLangIdToKey(langId);

            if (!HasFontDataModel(language))
                return;

            if (!MessageHelper.IsEFIGS(langId) || --useEFIGSCount < 1)
            {
                var fontAssetInfo = fontInfoTable[language];
                fontAssetInfo.ClearFallbackFontAtlas();
                Destroy(fontAssetInfo.fontAsset);
                fontInfoTable.Remove(language);
            }
        }

        public TMP_FontAsset GetFontAsset()
        {
            return GetFontAssetByLangId(UserLanguageId);
        }

        public TMP_FontAsset GetFontAssetByLangId(MessageEnumData.MsgLangId langId)
        {
            return GetFontAssetInfoByLangId(langId)?.fontAsset;
        }

        public FontAssetInfo GetFontAssetInfo()
        {
            return GetFontAssetInfoByLangId(UserLanguageId);
        }

        public FontAssetInfo GetFontAssetInfoByLangId(MessageEnumData.MsgLangId langId)
        {
            var language = ConvertLangIdToKey(langId);
            if (HasFontDataModel(language))
                return fontInfoTable[language];

            MessageHelper.EmitLog(string.Format("Target Language Not Found : {0}", langId), LogType.Error);
            return null;
        }

        public void ClearAllFontAtlas()
        {
            foreach (var key in fontInfoTable.Keys)
                fontInfoTable[key].ClearFallbackFontAtlas();
        }

        public void ClearFontAtlasByLanugageId(MessageEnumData.MsgLangId langId)
        {
            var language = ConvertLangIdToKey(langId);
            if (HasFontDataModel(language))
                fontInfoTable[language].ClearFallbackFontAtlas();
            else
                MessageHelper.EmitLog(string.Format("Target Language Not Found : {0}", langId), LogType.Error);
        }

        public void ReloadMaterialTable()
        {
            ClearMaterialTable();

            var material = fontInfoTable[ConvertLangIdToKey(UserLanguageId)].fontAsset.material;

            foreach (int key in materialPropertyTable.Keys)
                materialTable.Add(key, CreateMaterial(material, materialPropertyTable[key]));
        }

        private void ClearMaterialTable()
        {
            foreach (int key in materialTable.Keys)
                Destroy(materialTable[key]);

            materialTable.Clear();
        }

        private Material CreateMaterial(Material baseMaterial, FontMaterialProperty fontMaterialProperty)
        {
            var material = new Material(baseMaterial);

            if (fontMaterialProperty.useFace)
            {
                material.SetColor(FontMaterialProperty.PropFaceColor, fontMaterialProperty.faceColor);
                material.SetFloat(FontMaterialProperty.PropOutlineSoftness, fontMaterialProperty.faceSoftness);
                material.SetFloat(FontMaterialProperty.PropFaceDilate, fontMaterialProperty.faceDilate);
            }

            if (fontMaterialProperty.useOutline)
            {
                material.SetColor(FontMaterialProperty.PropOutlineColor, fontMaterialProperty.outlineColor);
                material.SetFloat(FontMaterialProperty.PropOutlineWidth, fontMaterialProperty.outlineThickness);
            }

            if (fontMaterialProperty.useGlow)
            {
                material.SetColor(FontMaterialProperty.PropGlowColor, fontMaterialProperty.glowColor);
                material.SetFloat(FontMaterialProperty.PropGlowOffset, fontMaterialProperty.glowOffset);
                material.SetFloat(FontMaterialProperty.PropGlowInner, fontMaterialProperty.glowInner);
                material.SetFloat(FontMaterialProperty.PropGlowOuter, fontMaterialProperty.glowOuter);
                material.SetFloat(FontMaterialProperty.PropGlowPower, fontMaterialProperty.glowPower);
            }

            if (fontMaterialProperty.useUnderlay)
            {
                material.EnableKeyword("UNDERLAY_ON");
                material.SetColor(FontMaterialProperty.PropUnderlayColor, fontMaterialProperty.underlayColor);
                material.SetFloat(FontMaterialProperty.PropUnderlayOffsetX, fontMaterialProperty.underlayOffsetX);
                material.SetFloat(FontMaterialProperty.PropUnderlayOffsetY, fontMaterialProperty.underlayOffsetY);
                material.SetFloat(FontMaterialProperty.PropUnderlayDilate, fontMaterialProperty.underLayDilate);
                material.SetFloat(FontMaterialProperty.PropUnderlaySoftness, fontMaterialProperty.underlaySoftness);
            }

            if (fontMaterialProperty.useDebugSetting)
            {
                material.SetFloat(FontMaterialProperty.PropDebugSettingGradientScale, fontMaterialProperty.debugSettingGradientScale);
                material.SetFloat(FontMaterialProperty.PropDebugSettingSharpness, fontMaterialProperty.debugSettingSharpness);
            }

            return material;
        }

        public void ChangeFontMaterial(TextMeshProUGUI text, int materialIndex = 0)
        {
            if (materialIndex < materialPropertyTable.Count)
            {
                text.fontMaterial = materialTable[materialIndex];
                text.spriteAsset = spriteFontAsset;
                text.UpdateFontAsset();
            }
            else
            {
                MessageHelper.EmitLog(string.Format("Material Index is over Table Count : {0}", materialIndex), LogType.Error);
            }
        }

        private void OnFinishedLoadFontAsset(LoadFontAssetTask loadTask)
        {
            var fontAsset = loadTask.Asset as TMP_FontAsset;
            MaterialReferenceManager.AddFontAsset(fontAsset);

            var newObj = Instantiate(fontAsset);
            if (newObj != null)
            {
                var fontAssetInfo = new FontAssetInfo(textFontData.GetTextParamByLanguageId(loadTask.langId), newObj);
                fontInfoTable.Add((int)fontAssetInfo.LangId, fontAssetInfo);
            }
            else
            {
                MessageHelper.EmitLog("Failed Load FontAsset : " + loadTask.fileName, LogType.Error);
            }
        }

        private bool HasFontDataModel(MessageEnumData.MsgLangId langId)
        {
            return HasFontDataModel((int)langId);
        }

        private bool HasFontDataModel(int key)
        {
            return fontInfoTable.ContainsKey(key);
        }

        private int ConvertLangIdToKey(MessageEnumData.MsgLangId langId)
        {
            var language = MessageHelper.ConvertMsgId(langId);
            return MessageHelper.IsEFIGS(language) ? 2 : (int)language;
        }

        private MessageEnumData.MsgLangId UserLanguageId { get => MessageManager.Instance.UserLanguageID; }
    }
}