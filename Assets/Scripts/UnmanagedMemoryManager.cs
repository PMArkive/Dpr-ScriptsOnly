using System;
using System.Collections.Generic;

public class UnmanagedMemoryManager
{
	public static List<AllocInfo> s_NeedFreeList = new List<AllocInfo>();
	
	// TODO
	public static IntPtr Alloc(int size) { return default; }
	
	// TODO
	public static IntPtr Alloc<T>() { return default; }
	
	// TODO
	public static bool Free(IntPtr p) { return default; }
	
	// TODO
	public static void DestroyStructure<T>(IntPtr p) { }
	
	// TODO
	public static IntPtr WriteObject<T>(T obj, ref int bufferSize, int allocSize = 0) { return default; }
	
	// TODO
	public static bool ReadObject<T>(IntPtr p, ref T obj) { return default; }
	
	// TODO
	public static IntPtr WriteArray<T>(T[] array, ref int bufferSize) { return default; }
	
	// TODO
	public static bool ReadArray<T>(IntPtr p, int arrayLength, ref T[] array) { return default; }
	
	// TODO
	public static IntPtr WriteList<T>(List<T> list, ref int bufferSize) { return default; }
	
	// TODO
	public static bool ReadList<T>(IntPtr p, int listCount, ref List<T> list) { return default; }
	
	// TODO
	public static IntPtr WriteUtf8(string str, ref int bufferSize) { return default; }
	
	// TODO
	public static string ReadUtf8(IntPtr pStr, int stringSize) { return default; }
	
	// TODO
	public static IntPtr WriteUtf16(string str, ref int bufferSize) { return default; }
	
	// TODO
	public static string ReadUtf16(IntPtr pStr, int stringSize) { return default; }
	
	// TODO
	public static void ValidateAllocInfo() { }

	public class AllocInfo
	{		
		public IntPtr ptr { get; set; }
		public int size { get; set; }
		
		public AllocInfo(IntPtr _ptr, int _size)
		{
			ptr = _ptr;
			size = _size;
		}
	}
}