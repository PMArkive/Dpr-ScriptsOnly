using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Nintendo.MessageStudio.Lib
{
    public class BinFlwFile : BinLibmsFileBase
    {
        protected override IntPtr InitObject(IntPtr resourcePtr)
        {
            return Libms.LMS_InitFlowchart(resourcePtr);
        }

        protected override void CloseObject(IntPtr objectPtr)
        {
            Libms.LMS_CloseFlowchart(objectPtr);
        }

        public int GetNodeNum()
        {
            return Libms.LMS_GetNodeNum(FileObjectPtr);
        }

        public int GetEntryNodeIndex(string label)
        {
            return Libms.LMS_GetEntryNodeIndex(FileObjectPtr, label);
        }

        public LMSFlowNodeData GetNodeData(int index)
        {
            var nodeDataPtr = Libms.LMS_GetNodeDataPtr(FileObjectPtr, index);
            var bytes = new byte[16];
            Marshal.Copy(nodeDataPtr, bytes, 0, 16);

            var nodeData = new LMSFlowNodeData();
            nodeData.NodeType = (LMSFlowNodeType)bytes[0];
            nodeData.ParamType = (LMSFlowParamType)bytes[1];
            nodeData.Reserved = BitConverter.ToUInt16(bytes, 2);
            nodeData.ParamValue = BitConverter.ToUInt32(bytes, 4);
            nodeData.Rawdata0 = BitConverter.ToUInt16(bytes, 8);
            nodeData.Rawdata1 = BitConverter.ToUInt16(bytes, 10);
            nodeData.Rawdata2 = BitConverter.ToUInt16(bytes, 12);
            nodeData.Rawdata3 = BitConverter.ToUInt16(bytes, 14);
            nodeData.Entry = default;

            return nodeData;
        }

        public ushort[] GetCaseIndexesFromBranchNode(int index)
        {
            var nodeData = GetNodeData(index);
            // TODO: Where the hell is the array size
            return null;
        }

        public string GetFlowParamText(int offset)
        {
            return Marshal.PtrToStringAnsi(Libms.LMS_GetFlowParamText(FileObjectPtr, offset));
        }

        [Conditional("DEBUG")]
        public void GetIndexTest(int index)
        {
            _ = Libms.LMS_GetNodeDataPtr(FileObjectPtr, index);
        }
    }
}