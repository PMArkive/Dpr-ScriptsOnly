namespace Dpr.Contest
{
	public sealed class NotesDataModel : NotesData
	{
		public float arriveSec;
		public int index;
		public bool emitFlag = true;
		public bool isLast;
		
		public NotesDataModel(int index, bool valid_flag, ushort id, float arriveSec, NoteTypeID notesType, bool isLast)
		{
			this.valid_flag = valid_flag;
			this.index = index;
			this.id = id;
			this.notesType = notesType;
			this.arriveSec = arriveSec;
			this.isLast = isLast;

			Reset();
		}
		
		public void Reset()
		{
            emitFlag = true;
        }
	}
}