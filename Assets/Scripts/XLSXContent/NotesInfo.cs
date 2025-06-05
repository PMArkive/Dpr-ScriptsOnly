using Dpr.Contest;
using System;
using UnityEngine;

namespace XLSXContent
{
	[Serializable]
	public class NotesInfo : ScriptableObject
	{
		public SheetNoteData[] NoteData;
		
		public SheetNoteData this[int index] => NoteData[index];

		[Serializable]
		public class SheetNoteData
		{
			public bool valid_flag;
			public ushort id;
			public float beat;
			public NoteTypeID noteType;
		}
	}
}