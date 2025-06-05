using System;
using System.Collections.Generic;

namespace Dpr.Contest
{
	public class DanceOtherUser : DanceNPC
	{
		private bool bIsGamerActive;
		
		public DanceOtherUser(ContestPlayerEntity entity, CollectNotesDataModel collectNotesData, List<NotesDataModel> notesDataList, Action<ADancePlayer> onLockSkill) : base(entity, collectNotesData, notesDataList, onLockSkill)
		{
			bIsGamerActive = true;
			playerType = PlayerType.Other;
		}
		
		public bool IsGamerActive { get => bIsGamerActive; }
		
		// TODO
		protected override void UpdateAction() { }
		
		// TODO
		public void SwitchUserToNPC(float elapsedTime) { }
		
		// TODO
		protected override void OnChangeMultiMode(bool isHost) { }
	}
}