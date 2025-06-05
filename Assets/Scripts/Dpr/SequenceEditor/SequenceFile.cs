using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dpr.SequenceEditor
{
	[CreateAssetMenu(fileName = "SequenceFile", menuName = "ScriptableObjects/BattleView/Create SequenceFile")]
	public sealed class SequenceFile : ScriptableObject
	{
		[SerializeField]
		private List<Group> _groupData = new List<Group>();
		private List<CommandParam> _cachedCommandParams;
		
		// TODO
		public static Macro Cast(Macro macro) { return default; }
		
		public List<Group> GroupData { get => _groupData; set => _groupData = value; }
		public int MaxFrame { get => GetCommandParams().Max(x => x.EndFrame) + 1; }
		public bool HasChainAttack { get; set; }
		
		// TODO
		public List<CommandParam> GetCommandParams() { return default; }
	}
}