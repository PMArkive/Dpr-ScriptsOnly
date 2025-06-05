using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleMemory
    {
        [NonSerialized]
        private static Dictionary<string, byte[]> _memoryLookupFromAssetPath = new Dictionary<string, byte[]>();

        public static bool LoadFromFile(string path)
        {
            Debug.Log("LoadFromPackFile: " + path);

            if (!File.Exists(path))
            {
                Debug.Log("File not found!: " + path);
                return false;
            }

            Debug.Log("PackFile Open: " + path);
            byte[] data = File.ReadAllBytes(path);

            int headerSize = Marshal.SizeOf<AssetBundlePackHeader>();
            int nodeSize = Marshal.SizeOf<AssetBundlePackNode>();

            IntPtr headerPtr = Marshal.AllocHGlobal(headerSize);
            Marshal.Copy(data, 0, headerPtr, headerSize);
            AssetBundlePackHeader header = Marshal.PtrToStructure<AssetBundlePackHeader>(headerPtr);

            int nodeCount = header.count;
            int nodeTotalSize = nodeCount * nodeSize;

            IntPtr nodesPtr = Marshal.AllocHGlobal(nodeTotalSize);
            Marshal.Copy(data, headerSize, nodesPtr, nodeTotalSize);

            AssetBundlePackNode[] nodes = new AssetBundlePackNode[nodeCount];
            int offset = 0;
            for (int i=0; i<nodeCount; i++)
            {
                nodes[i] = Marshal.PtrToStructure<AssetBundlePackNode>(nodesPtr + offset);
                offset += nodeSize;
            }

            for (int i=0; i<nodes.Length; i++)
            {
                if (!_memoryLookupFromAssetPath.ContainsKey(nodes[i].name))
                {
                    byte[] nodeData = new byte[nodes[i].dataSize];
                    Array.Copy(data, nodeTotalSize + headerSize + nodes[i].offsetInBytes, nodeData, 0, nodes[i].dataSize);
                    Debug.Log("Entry Memory AssetBundle: " + nodes[i].name);
                    _memoryLookupFromAssetPath.Add(nodes[i].name, nodeData);
                }
            }

            return true;
        }

        public static bool GetBuffer(string path, out byte[] buffer)
        {
            return _memoryLookupFromAssetPath.TryGetValue(path, out buffer);
        }
    }
}