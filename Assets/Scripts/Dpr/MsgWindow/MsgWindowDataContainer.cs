using Audio;
using Dpr.Message;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.MsgWindow
{
    public class MsgWindowDataContainer
    {
        private Dictionary<int, RoadsignViewData> roadsignViewDataTable;
        private Dictionary<int, string> speakerNameTable;
        private Dictionary<int, uint> soundTagDataTable;
        private RoadsignTexData[] roadsignTextureArray;
        private Sprite[] windowFrameSprArray;
        private Sprite[] windowBGSprArray;
        private Sprite[] textureResourceArray;
        private Object[] assetResourceArray;
        private int loadedCount;

        public void Dispose()
        {
            roadsignViewDataTable?.Clear();
            speakerNameTable?.Clear();
            soundTagDataTable?.Clear();

            windowFrameSprArray = null;
            windowBGSprArray = null;
            textureResourceArray = null;
            roadsignTextureArray = null;
        }

        public bool Loading { get => loadedCount < assetResourceArray.Length; }
        public Dictionary<int, RoadsignViewData> RoadsignViewDataTable { get => roadsignViewDataTable; }
        public Dictionary<int, string> SpeakerNameTable { get => speakerNameTable; }
        public Dictionary<int, uint> SoundTagDataTable { get => soundTagDataTable; }
        public Sprite[] WindowFrameSprArray { get => windowFrameSprArray; }
        public Sprite[] WindowBGSprArray { get => windowBGSprArray; }

        public Sprite GetCommonSprByIndex(int index)
        {
            if (index < textureResourceArray.Length)
                return textureResourceArray[index];

            MessageHelper.EmitLog(string.Format("Indexout of CommonResourceArray size {0} - index : {1}", textureResourceArray.Length, index));
            return null;
        }

        public GameObject GetInstantiadedAssetByIndex(int index, Transform parent)
        {
            if (index < assetResourceArray.Length)
                return Object.Instantiate(assetResourceArray[index], parent) as GameObject;

            MessageHelper.EmitLog(string.Format("Indexout of CommonResourceArray size {0} - index : {1}", textureResourceArray.Length, index));
            return null;
        }

        public void FormatMsgWindowData(MsgWindowData msgWindowData)
        {
            CreateSpeakerNameTable(msgWindowData.SpeakerNameData);
            CreateRoadsignTextureArray(msgWindowData.RoadsignResourceData);
            CreateRoadsignViewDataTable(msgWindowData.RoadsignViewData);
            CreateWindowFrameSprArray(msgWindowData.WindowFrameData);
            CreateWindowBGSprArray(msgWindowData.WindowBGData);
            CreateTextureResourceArray(msgWindowData.TextureResourceData);
            CreateAssetResourceArray(msgWindowData.AssetResourceData);
            CreateSoundTagData(msgWindowData.SoundTagData);
        }

        private void CreateSpeakerNameTable(MsgWindowData.SheetSpeakerNameData[] speakerNameDatas)
        {
            if (speakerNameTable != null)
                return;

            speakerNameTable = new Dictionary<int, string>();
            for (int i=0; i<speakerNameDatas.Length; i++)
            {
                if (!speakerNameTable.ContainsKey(speakerNameDatas[i].label.GetHashCode()))
                    speakerNameTable.Add(speakerNameDatas[i].label.GetHashCode(), speakerNameDatas[i].talk_label);
            }
        }

        private void CreateRoadsignTextureArray(MsgWindowData.SheetRoadsignResourceData[] resourceDatas)
        {
            if (roadsignTextureArray != null)
                return;

            roadsignTextureArray = new RoadsignTexData[resourceDatas.Length];
            for (int i=0; i<resourceDatas.Length; i++)
            {
                var sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.SHAREDUI, resourceDatas[i].textureName);

                if (sprite == null)
                {
                    MessageHelper.EmitLog("Texture not found in spriteAtlasShared : " + resourceDatas[i].textureName, LogType.Error);

                    var texData = new RoadsignTexData
                    {
                        size = new Vector2(resourceDatas[i].width, resourceDatas[i].height)
                    };
                    roadsignTextureArray[resourceDatas[i].id] = texData;
                }
                else
                {
                    if (roadsignTextureArray[resourceDatas[i].id] != null)
                        MessageHelper.EmitLog(string.Format("Already set Roadsign Texture - Index : {0}", resourceDatas[i].id), LogType.Error);
                    else
                    {
                        var texData = new RoadsignTexData
                        {
                            spr = sprite,
                            size = new Vector2(resourceDatas[i].width, resourceDatas[i].height),
                        };
                        roadsignTextureArray[resourceDatas[i].id] = texData;
                    }
                        
                }
            }
        }

        private void CreateRoadsignViewDataTable(MsgWindowData.SheetRoadsignViewData[] viewDatas)
        {
            if (roadsignViewDataTable != null)
                return;

            roadsignViewDataTable = new Dictionary<int, RoadsignViewData>();
            for (int i=0; i<viewDatas.Length; i++)
            {
                if (!roadsignViewDataTable.ContainsKey(viewDatas[i].id))
                {
                    var viewData = new RoadsignViewData
                    {
                        spritePtr = roadsignTextureArray[viewDatas[i].roadSignID].spr,
                        rotZ = viewDatas[i].rotZ,
                        position = viewDatas[i].position,
                        texSize = roadsignTextureArray[viewDatas[i].roadSignID].size
                    };
                    roadsignViewDataTable.Add(viewDatas[i].id, viewData);
                }
            }
        }

        private void CreateWindowFrameSprArray(MsgWindowData.SheetWindowFrameData[] windowFrameDatas)
        {
            if (windowFrameSprArray != null)
                return;

            windowFrameSprArray = new Sprite[windowFrameDatas.Length];
            for (int i=0; i<windowFrameDatas.Length; i++)
            {
                var sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.SHAREDUI, windowFrameDatas[i].textureName);

                if (sprite == null)
                    MessageHelper.EmitLog("Texture not found in spriteAtlasShared : " + windowFrameDatas[i].textureName, LogType.Error);
                else if (windowFrameSprArray[windowFrameDatas[i].winType] != null)
                    MessageHelper.EmitLog(string.Format("Already set WindowFrame Texture - Index : {0}", windowFrameDatas[i].winType), LogType.Error);
                else
                    windowFrameSprArray[windowFrameDatas[i].winType] = sprite;
            }
        }

        private void CreateWindowBGSprArray(MsgWindowData.SheetWindowBGData[] windowBGDatas)
        {
            if (windowBGSprArray != null)
                return;

            windowBGSprArray = new Sprite[windowBGDatas.Length];
            for (int i=0; i<windowBGDatas.Length; i++)
            {
                var sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.SHAREDUI, windowBGDatas[i].textureName);

                if (sprite == null)
                    MessageHelper.EmitLog("Texture not found in spriteAtlasShared : " + windowBGDatas[i].textureName, LogType.Error);
                else if (windowBGSprArray[windowBGDatas[i].id] != null)
                    MessageHelper.EmitLog(string.Format("Already set Window BG Texture - Index : {0}", windowBGDatas[i].id), LogType.Error);
                else
                    windowBGSprArray[windowBGDatas[i].id] = sprite;
            }
        }

        private void CreateTextureResourceArray(MsgWindowData.SheetTextureResourceData[] textureResourceData)
        {
            if (textureResourceArray != null)
                return;

            textureResourceArray = new Sprite[textureResourceData.Length];
            for (int i=0; i<textureResourceData.Length; i++)
            {
                var sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.SHAREDUI, textureResourceData[i].textureName);

                if (sprite == null)
                    MessageHelper.EmitLog("Texture not found in spriteAtlasShared : " + textureResourceData[i].textureName, LogType.Error);
                else if (textureResourceArray[textureResourceData[i].id] != null)
                    MessageHelper.EmitLog(string.Format("Already set Common UITexture - Index : {0}", textureResourceData[i].id), LogType.Error);
                else
                    textureResourceArray[textureResourceData[i].id] = sprite;
            }
        }

        private void CreateAssetResourceArray(MsgWindowData.SheetAssetResourceData[] assetResourceData)
        {
            if (assetResourceArray != null)
                return;

            assetResourceArray = new Object[assetResourceData.Length];
            for (int i=0; i<assetResourceData.Length; i++)
                LoadAssetBundle(assetResourceData[i].id, assetResourceData[i].assetBundlePath);
        }

        private void LoadAssetBundle(int dataIndex, string assetBundlePath)
        {
            AssetManager.AppendAssetBundleRequest(assetBundlePath, true, (eventType, name, asset) =>
            {
                if (eventType == RequestEventType.Cached)
                    AssetManager.UnloadAssetBundle(assetBundlePath);

                if (eventType != RequestEventType.Activated)
                    return;

                loadedCount++;

                if (asset == null)
                    MessageHelper.EmitLog("Asset Not Found - path " + assetBundlePath);

                if (assetResourceArray[dataIndex] != null)
                    MessageHelper.EmitLog(string.Format("Already Loasd Asset - Index : {0} ; path {1}", dataIndex, assetBundlePath), LogType.Error);
                else
                    assetResourceArray[dataIndex] = asset;

            }, null);
        }

        private void CreateSoundTagData(MsgWindowData.SheetSoundTagData[] soundTagData)
        {
            if (soundTagDataTable != null)
                return;

            soundTagDataTable = new Dictionary<int, uint>();
            for (int i=0; i<soundTagData.Length; i++)
            {
                if (soundTagDataTable.ContainsKey(soundTagData[i].id))
                    MessageHelper.EmitLog(string.Format("Already Add key : {0}", soundTagData[i].id), LogType.Error);
                else if (soundTagData[i].id < 2)
                    MessageHelper.EmitLog(string.Format("Can not use key : {0}", soundTagData[i].id), LogType.Error);
                else
                    soundTagDataTable.Add(soundTagData[i].id, AudioManager.Instance.GetIdByName(soundTagData[i].soundEventName));
            }
        }
    }
}