using System;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskModelDelete : Task
	{
		private GameObject m_oHdlModel;
		private Action _onFinishAction;
		
		protected override bool IsFinishCondition { get => _lifeTime < _frame; }
		
		public TaskModelDelete(GameObject go, Action finishAction, int lifeTime)
		{
			m_oHdlModel = go;
			_frame = 0;
			_onFinishAction = finishAction;
			_lifeTime = lifeTime;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref m_oHdlModel);
			Mem.Del(ref _onFinishAction);
		}
		
		protected override void OnFinishTask()
		{
			m_oHdlModel.SetActive(false);
			_onFinishAction?.Invoke();
		}
	}
}