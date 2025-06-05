using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Dpr.Battle.Logic
{
    public unsafe static class BattleUnmanagedMem
    {
        private static List<ELEM> m_Elems = new List<ELEM>(64);

        public static void* Malloc(long size, Allocator allocator = Allocator.Persistent, int alignment = 16)
        {
            var dest = UnsafeUtility.Malloc(size, alignment, allocator);
            UnsafeUtility.MemSet(dest, 0, size);

            var item = new ELEM();
            item.allocator = allocator;
            item.pAddr = dest;

            m_Elems.Add(item);

            return dest;
        }

        public static void Free(void* pAddr)
        {
            for (int i=0; i<m_Elems.Count; i++)
            {
                if (m_Elems[i].pAddr == pAddr)
                {
                    UnsafeUtility.Free(pAddr, m_Elems[i].allocator);
                    m_Elems.RemoveAt(i);
                    break;
                }
            }
        }

        public static void FreeAll()
        {
            for (int i=0; i<m_Elems.Count; i++)
                UnsafeUtility.Free(m_Elems[i].pAddr, m_Elems[i].allocator);

            m_Elems.Clear();
        }

        private struct ELEM
        {
	        public void* pAddr;
            public Allocator allocator;
        }
    }
}