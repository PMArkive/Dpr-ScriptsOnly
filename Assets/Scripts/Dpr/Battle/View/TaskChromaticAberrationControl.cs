using DG.Tweening;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskChromaticAberrationControl : TaskPostEffectCotrol
	{
		private FromToPair<Vector2> _disper;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskChromaticAberrationControl(SequenceCameraObject cameraObject, Vector2 disper, int lifeTime, Ease easingType) : base(cameraObject)
		{
			_disper = new FromToPair<Vector2>(cameraObject.GetPostEffects().GetPfxParam().chromaticAberrationMagnificationDispersion, disper);
			_lifeTime = lifeTime;
			_easingType = easingType;
		}
		
		// TODO
		protected override PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam) { return default; }
	}
}