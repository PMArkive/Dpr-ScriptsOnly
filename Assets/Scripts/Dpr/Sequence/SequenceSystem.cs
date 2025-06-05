using Audio;
using Dpr.Battle.View;
using Dpr.SequenceEditor;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Sequence
{
	[Serializable]
	public abstract class SequenceSystem : ISequenceCallback, IDisposable
	{
		public const int DEFAULT_SEQUENCE_SYSTEM_STEP_CNT = 1;
		public const int MAX_COMMAND_NUM = 1024;

		public const float ONE_FRAME_TIME = 0.033333f;

		public static readonly Color PARTICLE_MULTIPLY_RESET_COLOR = Color.white;
		public static readonly Vector3 BACKGROUND_DEFAULT_POSITION = Vector3.zero;
		public static readonly Vector3 BACKGROUND_DEFAULT_ROTATION = Vector3.zero;
		public static readonly Vector3 BACKGROUND_DEFAULT_SCALE = Vector3.one;

		public const string WWISE_PLAY_VOICE_EV = "Play_PV_EV_{0:d3}_{1:d2}_{2}";
		public const string WWISE_PLAY_VOICE_BTL = "Play_PV_Btl_{0:d3}_{1:d2}_{2}";
		public const string WWISE_PLAY_VOICE_BTL_SWITCH = "Play_PV_Btl_{0:d3}_{1:d2}_00";

		protected BTLV_ENVIRONMENT_PARAM _environmentParam;
		protected Coroutine _seqFileLoadCoroutine;
		protected List<Coroutine> _preLoadCoroutines;
		protected Dictionary<string, AudioData> _cachedSoundBank = new Dictionary<string, AudioData>();
		protected int _step;
		protected float _sequenceElapsedTime;
		protected float _sequenceInterpolationTime;

		public SequenceFile SequenceFile { get; set; }
		public int CurrentFrame { get; set; } = -1;
		public float CurrentTime { get => _sequenceElapsedTime; }
		public int MaxFrame { get; set; } = -1;
		public float MaxTime { get => Mathe.FrameToSecond(MaxFrame); }
		protected List<CommandParam> Commands { get; set; }
		protected bool IsCommandSkip { get; set; }
		public bool IsPause { get; set; }
		public bool IsLoadedSequenceFile { get => SequenceFile != null && Commands != null; }
		public bool IsPreLoaded { get => _preLoadCoroutines.Count == 0; }
		public bool IsFinishSequence { get; set; }
		protected bool IsInterpolationTime { get; set; }
		
		public SequenceSystem()
		{
			_step = 0;
			_sequenceElapsedTime = 0.0f;
			_seqFileLoadCoroutine = null;
			_preLoadCoroutines = new List<Coroutine>(MAX_COMMAND_NUM);
			_cachedSoundBank = new Dictionary<string, AudioData>();
			SequenceFile = null;
			CurrentFrame = -1;
			MaxFrame = -1;
			Commands = new List<CommandParam>(MAX_COMMAND_NUM);
			IsCommandSkip = false;
			IsPause = true;
			IsFinishSequence = false;
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public virtual void UnInitialize() { }

		// TODO
		public abstract void LoadSequence(string path, bool isWaitCamera = false);

		// TODO
		public abstract void SetPause(bool value);

		// TODO
		public abstract void Stop();
		
		// TODO
		public void Update(float deltaTime, int step = 1) { }
		
		// TODO
		public void LateUpdate(float deltaTime) { }
		
		// TODO
		private bool IsUpdateValid() { return default; }
		
		// TODO
		protected void CheckPreLoadCount() { }
		
		// TODO
		protected void StepFrame(float deltaTime) { }
		
		// TODO
		protected virtual void OnUpdate(float deltaTime, int step) { }
		
		// TODO
		protected virtual void OnLateUpdate(float deltaTime, int step) { }
		
		// TODO
		protected virtual void OnComplete() { }
		
		// TODO
		protected void SetSkipCommand(bool isSkip) { }
		
		// TODO
		public virtual void SkipFrame(int frame, bool isReset = true) { }
		
		// TODO
		public virtual void CommandCallback(SequenceFile file, CommandParam param, bool isSkip) { }
		
		// TODO
		public virtual void CommandCallbackLate(SequenceFile file, CommandParam param, bool isSkip) { }
		
		// TODO
		public void SetupEnvironmentParam() { }
		
		// TODO
		public BTLV_ENVIRONMENT_PARAM GetEnvironmentParam() { return default; }
		
		// TODO
		public List<CommandParam> FindCommands(CommandNo commandNo) { return default; }
	}
}