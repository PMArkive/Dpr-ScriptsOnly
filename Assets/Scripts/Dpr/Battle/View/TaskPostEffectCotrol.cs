using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public class TaskPostEffectCotrol : Task
	{
		protected SequenceCameraObject _cameraObject;
		
		public TaskPostEffectCotrol(SequenceCameraObject cameraObject)
		{
			_cameraObject = cameraObject;
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _cameraObject);
		}
		
		protected override void OnUpdate(int frame, float raito)
		{
			if (_cameraObject != null)
			{
				var postEffects = _cameraObject.GetPostEffects();
				var pfxParam = postEffects.GetPfxParam();
                postEffects.SetPfxParam(OnUpdate(frame, raito, ref pfxParam));
			}
		}
		
		protected virtual PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam)
		{
			return pfxParam;
		}
	}
}