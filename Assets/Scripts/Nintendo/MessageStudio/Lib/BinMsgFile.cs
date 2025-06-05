using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Nintendo.MessageStudio.Lib
{
    public class BinMsgFile : BinLibmsFileBase
    {
        public void SetMSBTFileData(byte[] byteDataArray)
        {
            IntPtr resourcePtr = Marshal.AllocHGlobal(byteDataArray.Length);
            Marshal.Copy(byteDataArray, 0, resourcePtr, byteDataArray.Length);
            ResetResourceFilePtr(resourcePtr);
        }

        protected override IntPtr InitObject(IntPtr resourcePtr)
        {
            return Libms.LMS_InitMessage(resourcePtr);
        }

        protected override void CloseObject(IntPtr objectPtr)
        {
            Libms.LMS_CloseMessage(objectPtr);
        }

        public int SearchMessageBlock(string block)
        {
            return Libms.LMS_SearchMessageBlockByName(FileObjectPtr, block);
        }

        public BlockInfo GetBlockInfo(string block)
        {
            return (BlockInfo)Marshal.PtrToStructure(Libms.LMS_GetMessageBlockInfoByName(FileObjectPtr, block), typeof(BlockInfo));
        }

        public byte[] GetAttributes(string label)
        {
            return GetAttributes(Libms.LMS_GetTextIndexByLabel(FileObjectPtr, label));
        }

        public byte[] GetAttributes(int index)
        {
            var length = (int)Libms.LMS_GetAttributeSize(FileObjectPtr);

            if (length == 0)
                return null;

            var bytes = new byte[length];
            Marshal.Copy(Libms.LMS_GetAttribute(FileObjectPtr, index), bytes, 0, length);
            return bytes;
        }

        public sbyte GetInt8Attribute(byte[] attr, int index)
        {
            return (sbyte)attr[Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index)];
        }

        public byte GetUInt8Attribute(byte[] attr, int index)
        {
            return attr[Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index)];
        }

        public short GetInt16Attribute(byte[] attr, int index)
        {
            return BitConverter.ToInt16(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public ushort GetUInt16Attribute(byte[] attr, int index)
        {
            return BitConverter.ToUInt16(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public int GetInt32Attribute(byte[] attr, int index)
        {
            return BitConverter.ToInt32(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public uint GetUInt32Attribute(byte[] attr, int index)
        {
            return BitConverter.ToUInt32(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public float GetFloatAttribute(byte[] attr, int index)
        {
            return BitConverter.ToSingle(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public double GetDoubleAttribute(byte[] attr, int index)
        {
            return BitConverter.ToDouble(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index));
        }

        public string GetStringAttribute(byte[] attr, int index)
        {
            return Marshal.PtrToStringUni(Libms.LMS_GetAttributeText(FileObjectPtr, BitConverter.ToUInt32(attr, Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index))));
        }

        public int GetListAttribute(byte[] attr, int index)
        {
            return attr[Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index)];
        }

        public int GetIndexAttribute(int labelIndex, int attributeID)
        {
            return GetIndexAttribute(GetAttributes(labelIndex), attributeID);
        }

        public int GetIndexAttribute(byte[] attr, int index)
        {
            var offset = Libms.LMS_GetAttrFilteredOffset(FileObjectPtr, index);
            return attr[offset+1] * 256 + attr[offset];
        }

        public int GetStyle(string label)
        {
            return Libms.LMS_GetTextStyleByLabel(FileObjectPtr, label);
        }

        public int GetStyle(int index)
        {
            return Libms.LMS_GetTextStyle(FileObjectPtr, index);
        }

        public string GetLabel(int index)
        {
            var sb = new StringBuilder(0x100);
            if (Libms.LMS_GetLabelByTextIndex(FileObjectPtr, index, sb) > 0)
                return sb.ToString();
            else
                return null;
        }

        public int GetTextNum()
        {
            return Libms.LMS_GetTextNum(FileObjectPtr);
        }

        public int GetTextIndex(string label)
        {
            return Libms.LMS_GetTextIndexByLabel(FileObjectPtr, label);
        }

        public int GetTextSize(int index)
        {
            return Libms.LMS_GetTextSize(FileObjectPtr, index);
        }

        public IntPtr GetText(string strLabel)
        {
            if (!IsFileLoaded)
                return IntPtr.Zero;

            return Libms.LMS_GetTextByLabel(FileObjectPtr, strLabel);
        }

        public IntPtr GetText(int index)
        {
            if (!IsFileLoaded)
                return IntPtr.Zero;

            return Libms.LMS_GetText(FileObjectPtr, index);
        }
    }
}