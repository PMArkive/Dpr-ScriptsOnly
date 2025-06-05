using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Battle.View.ScriptableObjects
{
	[CreateAssetMenu(fileName = "BattleCameraSequenceData", menuName = "ScriptableObjects/BattleView/Create BattleCameraSequenceData")]
	public class BattleCameraSequenceData : ScriptableObject
	{
		[SerializeField]
		private List<Sequence> _sequenceList;

		[Serializable]
		public class Sequence
		{
			public bool isFire { get; set; }
			public int Count { get; set; }
			public Ease Ease { get; set; }
			public int StartCount { get; set; }
			public int EndCount { get; set; }
		}
	}
}