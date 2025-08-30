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

		public SequenceFile SequenceFile { get; protected set; }
		public int CurrentFrame { get; protected set; } = -1;
		public float CurrentTime { get => _sequenceElapsedTime; }
		public int MaxFrame { get; protected set; } = -1;
		public float MaxTime { get => Mathe.FrameToSecond(MaxFrame); }
		protected List<CommandParam> Commands { get; set; }
		protected bool IsCommandSkip { get; set; }
		public bool IsPause { get; protected set; }
		public bool IsLoadedSequenceFile { get => SequenceFile != null && Commands != null; }
		public bool IsPreLoaded { get => _preLoadCoroutines.Count == 0; }
		public bool IsFinishSequence { get; protected set; }
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
		
		public void Dispose()
		{
			UnInitialize();
		}
		
		// TODO
		public virtual void UnInitialize() { }

		public abstract void LoadSequence(string path, bool isWaitCamera = false);

		public abstract void SetPause(bool value);

		public abstract void Stop();
		
		public void Update(float deltaTime, int step = DEFAULT_SEQUENCE_SYSTEM_STEP_CNT)
		{
			CheckPreLoadCount();

			if (IsUpdateValid())
			{
				_step = step;
				OnUpdate(deltaTime, step);
			}
		}

		// TODO
		public void LateUpdate(float deltaTime) { }
		
		private bool IsUpdateValid()
		{
			if (IsPause)
				return false;

			if (SequenceFile == null)
				return false;

			return !IsFinishSequence;
		}
		
		// TODO
		protected void CheckPreLoadCount() { }
		
		// TODO
		protected void StepFrame(float deltaTime) { }
		
		protected virtual void OnUpdate(float deltaTime, int step)
        {
            // Empty
        }

        protected virtual void OnLateUpdate(float deltaTime, int step)
        {
            // Empty
        }

        protected virtual void OnComplete()
		{
			SequenceFile = null;
			Commands = null;
			CurrentFrame = -1;
			_sequenceElapsedTime = 0.0f;
			_sequenceInterpolationTime = 0.0f;
			IsInterpolationTime = false;
		}
		
		protected void SetSkipCommand(bool isSkip)
		{
			IsCommandSkip = isSkip;
		}
		
		// TODO
		public virtual void SkipFrame(int frame, bool isReset = true) { }
		
		public virtual void CommandCallback(SequenceFile file, CommandParam param, bool isSkip)
		{
			// Empty
		}
		
		public virtual void CommandCallbackLate(SequenceFile file, CommandParam param, bool isSkip)
        {
            // Empty
        }

        // TODO
        public void SetupEnvironmentParam() { }
		
		public BTLV_ENVIRONMENT_PARAM GetEnvironmentParam()
		{
			return _environmentParam;
		}
		
		public List<CommandParam> FindCommands(CommandNo commandNo)
		{
			if (Commands.IsNullOrEmpty())
				return null;

			return Commands.FindAll(x => x.CommandNo == commandNo);
		}
	}
}