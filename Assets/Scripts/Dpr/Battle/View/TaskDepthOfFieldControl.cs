using DG.Tweening;
using Dpr.SequenceEditor;
using SmartPoint.Rendering;
using System;

namespace Dpr.Battle.View
{
	public sealed class TaskDepthOfFieldControl : TaskPostEffectCotrol
	{
		private Mode _mode;
		private bool _isAutoFocus;
		private Tuple<float, float> _fNumber;
		private Tuple<float, float> _focusDistance;
		private Tuple<float, float> _farDepth;
		private Tuple<float, float> _focalLength;
		private Tuple<float, float> _distance;
		private Tuple<float, float> _blurry;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskDepthOfFieldControl(SequenceCameraObject cameraObject, bool isAutoFocus, float fNumber, float focusDistance, int lifeTime, Ease easingType) : base(cameraObject)
		{
			_mode = Mode.SWSH;

			var postEffects = cameraObject.GetPostEffects();
			var pfxParam = postEffects.GetPfxParam();

			_isAutoFocus = isAutoFocus;
			_fNumber = new Tuple<float, float>(pfxParam.dofFocalLength, fNumber);
			_focusDistance = new Tuple<float, float>(pfxParam.dofDistance, focusDistance);
			_lifeTime = lifeTime;
			_easingType = easingType;

            postEffects.SetPfxParam(pfxParam);
        }
		
		public TaskDepthOfFieldControl(SequenceCameraObject cameraObject, float farDepth, float focalLength, float distance, float blurry, int lifeTime, Ease easingType) : base(cameraObject)
		{
            _mode = Mode.DPR;
			_cameraObject = cameraObject;

            var postEffects = cameraObject.GetPostEffects();
            var pfxParam = postEffects.GetPfxParam();

			_farDepth = new Tuple<float, float>(pfxParam.dofFarDepth, farDepth);
			_focalLength = new Tuple<float, float>(pfxParam.dofFocalLength, focalLength);
			_distance = new Tuple<float, float>(pfxParam.dofDistance, distance);
			_blurry = new Tuple<float, float>(DepthOfField.blurry, blurry);
			_lifeTime = lifeTime;
			_easingType = easingType;

			postEffects.SetPfxParam(pfxParam);
        }
		
		protected override void OnDispose()
		{
			Mem.Del(ref _cameraObject);
		}
		
		// TODO
		protected override PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam) { return default; }

		private enum Mode : int
		{
			SWSH = 0,
			DPR = 1,
		}
	}
}