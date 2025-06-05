using System.Collections.Generic;

namespace Dpr.Contest
{
	public sealed class CollectNotesDataModel
	{
		private List<NotesDensityData> containNotesDataList = new List<NotesDensityData>();
		private List<int> notesNumList = new List<int>();
		private List<int> notesIndexList = new List<int>();
		
		// TODO
		public void CreateContainsNotesData(List<NotesDataModel> notesList, float beatSec, float skillAnimDuration, int bgmSigunature) { }
		
		// TODO
		private NotesDensityData CreateContainNotesData(List<NotesDataModel> notesList, int noteIndex, float endTime) { return default; }
		
		// TODO
		public int FindNotesIndexByDensityOarder(int index) { return default; }

		private sealed class NotesDensityData
		{
			public int notesNum;
			public int startNoteIndex;
			public int endNoteIndex;
		}
	}
}