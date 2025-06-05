using System;
using System.Runtime.InteropServices;

namespace Nintendo.MessageStudio.Lib
{
    public class BinPrjFile : BinLibmsFileBase
    {
        protected override IntPtr InitObject(IntPtr resourcePtr)
        {
            return Libms.LMS_InitProject(resourcePtr);
        }

        protected override void CloseObject(IntPtr objectPtr)
        {
            Libms.LMS_CloseProject(objectPtr);
        }

        public int SearchProjectBlock(string name)
        {
            return Libms.LMS_SearchProjectBlockByName(FileObjectPtr, name);
        }

        public int GetColorIndex(string name)
        {
            return Libms.LMS_GetColorIndexByName(FileObjectPtr, name);
        }

        public LMSColor GetColor(int index)
        {
            LMSColor color = new LMSColor();
            Libms.LMS_GetColor(FileObjectPtr, index, ref color);
            return color;
        }

        public LMSColor GetColor(string name)
        {
            LMSColor color = new LMSColor();
            Libms.LMS_GetColorByName(FileObjectPtr, name, ref color);
            return color;
        }

        public int GetColorNum()
        {
            return Libms.LMS_GetColorNum(FileObjectPtr);
        }

        public int GetContentsNum()
        {
            return Libms.LMS_GetContentsNum(FileObjectPtr);
        }

        public string GetContentPath(int index)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetContentPath(FileObjectPtr, index));
        }

        public int GetAttrInfoIndex(string name)
        {
            return Libms.LMS_GetAttrInfoIndexByName(FileObjectPtr, name);
        }

        public LibmsType GetAttrType(int index)
        {
            return Libms.LMS_GetAttrType(FileObjectPtr, index);
        }

        public LibmsType GetAttrType(string name)
        {
            return Libms.LMS_GetAttrTypeByName(FileObjectPtr, name);
        }

        public int GetAttrOffset(int index)
        {
            return Libms.LMS_GetAttrOffset(FileObjectPtr, index);
        }

        public int GetAttrOffset(string name)
        {
            return Libms.LMS_GetAttrOffsetByName(FileObjectPtr, name);
        }

        public string GetAttrListItemName(int attrIndex, int itemIndex)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetAttrListItemName(FileObjectPtr, attrIndex, itemIndex));
        }

        public string GetAttrListItemName(string attrName, int itemIndex)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetAttrListItemNameByName(FileObjectPtr, attrName, itemIndex));
        }

        public int GetAttrNum()
        {
            return Libms.LMS_GetAttrNum(FileObjectPtr);
        }

        public int GetAttrListItemNum(int attrIndex)
        {
            return Libms.LMS_GetAttrListItemNum(FileObjectPtr, attrIndex);
        }

        public string GetTagGroupName(ushort groupId)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetTagGroupName(FileObjectPtr, groupId));
        }

        public string GetTagName(ushort groupId, ushort tagId)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetTagName(FileObjectPtr, groupId, tagId));
        }

        public string GetTagParamName(ushort groupId, ushort tagId, ushort paramId)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetTagParamName(FileObjectPtr, groupId, tagId, paramId));
        }

        public LibmsType GetTagParamType(ushort groupId, ushort tagId, ushort paramId)
        {
            return Libms.LMS_GetTagParamType(FileObjectPtr, groupId, tagId, paramId);
        }

        public string GetTagListItemName(ushort groupId, ushort tagId, ushort paramId, ushort itemIndex)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetTagListItemName(FileObjectPtr, groupId, tagId, paramId, itemIndex));
        }

        public int GetTagGroupNum()
        {
            return Libms.LMS_GetTagGroupNum(FileObjectPtr);
        }

        public int GetTagNum(ushort groupId)
        {
            return Libms.LMS_GetTagNum(FileObjectPtr, groupId);
        }

        public int GetTagParamNum(ushort groupId, ushort tagId)
        {
            return Libms.LMS_GetTagParamNum(FileObjectPtr, groupId, tagId);
        }

        public int GetTagListItemNum(ushort groupId, ushort tagId, ushort paramId)
        {
            return Libms.LMS_GetTagListItemNum(FileObjectPtr, groupId, tagId, paramId);
        }

        public int GetStyleIndex(string name)
        {
            return Libms.LMS_GetStyleIndexByName(FileObjectPtr, name);
        }

        public int GetRegionWidth(int index)
        {
            return Libms.LMS_GetRegionWidth(FileObjectPtr, index);
        }

        public int GetRegionWidth(string name)
        {
            return Libms.LMS_GetRegionWidthByName(FileObjectPtr, name);
        }

        public int GetLineNum(int index)
        {
            return Libms.LMS_GetLineNum(FileObjectPtr, index);
        }

        public int GetLineNum(string name)
        {
            return Libms.LMS_GetLineNumByName(FileObjectPtr, name);
        }

        public int GetFontIndex(int index)
        {
            return Libms.LMS_GetFontIndex(FileObjectPtr, index);
        }

        public int GetFontIndex(string name)
        {
            return Libms.LMS_GetFontIndexByName(FileObjectPtr, name);
        }

        public int GetBaseColorIndex(int index)
        {
            return Libms.LMS_GetBaseColorIndex(FileObjectPtr, index);
        }

        public int GetBaseColorIndex(string name)
        {
            return Libms.LMS_GetBaseColorIndexByName(FileObjectPtr, name);
        }

        public int GetStyleNum()
        {
            return Libms.LMS_GetStyleNum(FileObjectPtr);
        }
    }
}