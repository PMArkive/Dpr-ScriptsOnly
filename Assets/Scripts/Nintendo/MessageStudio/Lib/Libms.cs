using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Nintendo.MessageStudio.Lib
{
    public static class Libms
    {
        private const string LibmsDllFileName = "__Internal";

        // TODO
        //[MonoPInvokeCallbackAttribute]
        private static IntPtr Alloc(int size)
        {
            return Marshal.AllocHGlobal(size);
        }

        // TODO
        //[MonoPInvokeCallbackAttribute]
        private static void Free(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        public static extern void LMS_SetMemFuncs(LMSMallocPtr pMalloc, LMSFreePtr pFree);

        public static extern IntPtr LMS_InitMessage(IntPtr pResource);

        public static extern void LMS_CloseMessage(IntPtr pFile);

        public static extern int LMS_SearchMessageBlockByName(IntPtr pFile, string pBlockName);

        public static extern IntPtr LMS_GetMessageBlockInfoByName(IntPtr pFile, string pBlockName);

        public static extern int LMS_GetTextNum(IntPtr pFile);

        public static extern int LMS_GetTextIndexByLabel(IntPtr pFile, string labelName);

        public static extern IntPtr LMS_GetText(IntPtr pFile, int nTextIndex);

        public static extern int LMS_GetTextSize(IntPtr pFile, int nTextIndex);

        public static extern IntPtr LMS_GetTextByLabel(IntPtr pFile, string labelName);

        public static extern int LMS_GetLabelByTextIndex(IntPtr pFile, int nTextIndex, StringBuilder labelName);

        public static extern int LMS_GetTextStyle(IntPtr pFile, int nTextIndex);

        public static extern int LMS_GetTextStyleByLabel(IntPtr pFile, string labelName);

        public static extern uint LMS_GetAttributeSize(IntPtr pFile);

        public static extern IntPtr LMS_GetAttribute(IntPtr pFile, int index);

        public static extern IntPtr LMS_GetAttributeText(IntPtr pFile, uint offset);

        public static extern int LMS_GetAttrFilteredOffset(IntPtr pFile, int nAttrIndex);

        public static extern IntPtr LMS_InitProject(IntPtr pResource);

        public static extern void LMS_CloseProject(IntPtr pFile);

        public static extern int LMS_SearchProjectBlockByName(IntPtr pFile, string pBlockName);

        public static extern int LMS_GetColorIndexByName(IntPtr pFile, string pName);

        public static extern int LMS_GetColor(IntPtr pFile, int nColorIndex, ref LMSColor pColor);

        public static extern int LMS_GetColorByName(IntPtr pFile, string pName, ref LMSColor pColor);

        public static extern int LMS_GetColorNum(IntPtr pFile);

        public static extern int LMS_GetContentsNum(IntPtr pFile);

        public static extern IntPtr LMS_GetContentPath(IntPtr pFile, int nContentIndex);

        public static extern int LMS_GetAttrInfoIndexByName(IntPtr pFile, string pName);

        public static extern LibmsType LMS_GetAttrType(IntPtr pFile, int nAttrIndex);

        public static extern int LMS_GetAttrOffset(IntPtr pFile, int nAttrIndex);

        public static extern LibmsType LMS_GetAttrTypeByName(IntPtr pFile, string pName);

        public static extern int LMS_GetAttrOffsetByName(IntPtr pFile, string pName);

        public static extern IntPtr LMS_GetAttrListItemName(IntPtr pFile, int nAttrIndex, int nItemIndex);

        public static extern IntPtr LMS_GetAttrListItemNameByName(IntPtr pFile, string pAttrName, int nItemIndex);

        public static extern int LMS_GetAttrNum(IntPtr pFile);

        public static extern int LMS_GetAttrListItemNum(IntPtr pFile, int nAttrIndex);

        public static extern IntPtr LMS_GetTagGroupName(IntPtr pFile, ushort nGroupId);

        public static extern IntPtr LMS_GetTagName(IntPtr pFile, ushort nGroupId, ushort nTagId);

        public static extern IntPtr LMS_GetTagParamName(IntPtr pFile, ushort nGroupId, ushort nTagId, ushort nParamIndex);

        public static extern LibmsType LMS_GetTagParamType(IntPtr pFile, ushort nGroupId, ushort nTagId, ushort nParamIndex);

        public static extern IntPtr LMS_GetTagListItemName(IntPtr pFile, ushort nGroupId, ushort nTagId, ushort nParamIndex, ushort nItemIndex);

        public static extern int LMS_GetTagGroupNum(IntPtr pFile);

        public static extern int LMS_GetTagNum(IntPtr pFile, ushort nGroupId);

        public static extern int LMS_GetTagParamNum(IntPtr pFile, ushort nGroupId, ushort nTagId);

        public static extern int LMS_GetTagListItemNum(IntPtr pFile, ushort nGroupId, ushort nTagId, ushort nParamIndex);

        public static extern int LMS_GetStyleIndexByName(IntPtr pFile, string pStyleName);

        public static extern int LMS_GetRegionWidth(IntPtr pFile, int nStyleIndex);

        public static extern int LMS_GetRegionWidthByName(IntPtr pFile, string pStyleName);

        public static extern int LMS_GetLineNum(IntPtr pFile, int nStyleIndex);

        public static extern int LMS_GetLineNumByName(IntPtr pFile, string pStyleName);

        public static extern int LMS_GetFontIndex(IntPtr pFile, int nStyleIndex);

        public static extern int LMS_GetFontIndexByName(IntPtr pFile, string pStyleName);

        public static extern int LMS_GetBaseColorIndex(IntPtr pFile, int nStyleIndex);

        public static extern int LMS_GetBaseColorIndexByName(IntPtr pFile, string pStyleName);

        public static extern int LMS_GetStyleNum(IntPtr pFile);

        public static extern IntPtr LMS_InitFlowchart(IntPtr pResource);

        public static extern void LMS_CloseFlowchart(IntPtr pFile);

        public static extern int LMS_GetNodeNum(IntPtr pFile);

        public static extern int LMS_GetEntryNodeIndex(IntPtr pFile, string pLabel);

        public static extern IntPtr LMS_GetNodeDataPtr(IntPtr pFile, int index);

        public static extern int LMS_GetFlowNodeIndex(IntPtr pFile, IntPtr pNode);

        public static extern IntPtr LMS_GetCaseIndexesFromBranchNode(IntPtr pFile, int index);

        public static extern IntPtr LMS_GetFlowParamText(IntPtr pFile, int offset);

        public delegate IntPtr LMSMallocPtr(int size);
        public delegate void LMSFreePtr(IntPtr ptr);
    }
}
