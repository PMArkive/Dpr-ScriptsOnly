using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SequenceEditor
{
	[Serializable]
	public sealed class CommandParam
	{
		public Group Group;
		public bool IsAlreadyCalled;
		public int StartFrame;
		public int EndFrame;
		public int GroupNo;
		public CommandNo CommandNo;
		public Macro Macro;
		public List<GroupOption> GroupOption;
		
		public float StartTime { get => 1.0f / Application.targetFrameRate * StartFrame; }
		public float EndTime { get => 1.0f / Application.targetFrameRate * EndFrame; }

        public CommandParam()
		{
			// Empty, declared explicitly
		}
		
		public CommandParam(CommandParam other)
		{
			Group = other.Group;
			IsAlreadyCalled = false;
			CommandNo = other.Macro.CommandNo;
			StartFrame = other.StartFrame;
			EndFrame = other.EndFrame;
			GroupNo = other.GroupNo;
			GroupOption = other.GroupOption;
			Macro = other.Macro;
			Macro.CamFile = other.Macro.CamFile;
		}
		
		// TODO
		public GroupOption GetGroupOption(GRP_OPT option) { return default; }
		
		// TODO
		public int GetOptionValue(GRP_OPT option) { return default; }
		
		// TODO
		public bool TryGetOptionValue(GRP_OPT option, out int value)
		{
			value = default;
			return default;
		}
	}
}