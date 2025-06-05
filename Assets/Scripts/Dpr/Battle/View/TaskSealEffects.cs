using Dpr.Battle.View.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskSealEffects : Task
	{
		private ObjectEntity _ballEntity;
		private List<BtlvEffectInstance> _ballEffectInstances;
		private FromToPair<Vector3>[] _ballPositions;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		// TODO
		public TaskSealEffects(ObjectEntity entity, List<BtlvEffectInstance> sealEffects, float adjustHeight, int frame, bool isContest) { }
		
		// TODO
		protected override void OnDispose() { }
		
		// TODO
		protected override void OnUpdate(int frame, float raito) { }
	}
}