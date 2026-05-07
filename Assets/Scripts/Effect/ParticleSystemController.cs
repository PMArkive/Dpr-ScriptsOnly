using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Effect
{
	public class ParticleSystemController : MonoBehaviour
	{
		private UnityAction<object> _onFinished;
		private object _reference;
		private ParticleSystem _particleSystem;
		private ParticleSystem[] _particleSystems;
		private MaterialController[] _materialControllers;
		private StopStateBits _stopStateBits;

		public StopStateBits stopStateBits => _stopStateBits;
		
		public void Setup(ParticleSystem particleSystem, UnityAction<object> onFinished, object reference)
		{
			_materialControllers = particleSystem.transform.GetComponentsInChildren<MaterialController>(true);
			_particleSystem = GetComponent<ParticleSystem>();
            _particleSystems = _materialControllers.Select(x => x.GetParticleSystem()).ToArray();
			_onFinished = onFinished;
			_reference = reference;

			_stopStateBits = StopStateBits.None;
		}
		
		public void Stop(bool isForce)
		{
			OnParticleSystemStopped();

            _stopStateBits |= StopStateBits.Manual;

			if (isForce)
				Finish();
        }
		
		public void OnParticleSystemStopped()
        {
            if (!_stopStateBits.HasFlag(StopStateBits.Stopped))
                _stopStateBits |= StopStateBits.Stopped;
        }
		
		public bool OnUpdate(float deltaTime)
		{
			if (_stopStateBits.HasFlag(StopStateBits.Stopped))
				return false;

			if (!_stopStateBits.HasFlag(StopStateBits.Stopping))
				return true;

            if (_stopStateBits.HasFlag(StopStateBits.Manual))
			{
				for (int i=0; i<_particleSystems.Length; i++)
				{
					var system = _particleSystems[i];

					if (system == null)
						break;

					if (system.main.startLifetime.mode == ParticleSystemCurveMode.Constant)
					{
						if (!float.IsInfinity(system.main.startLifetime.constant) && system.IsAlive(false))
							return true;
					}
					else
					{
						if (system.IsAlive(false))
                            return true;
                    }
				}
			}
			else
			{
				if (_particleSystem != null && _particleSystem.IsAlive(true))
					return true;
			}

			Finish();
			return false;
        }
		
		private void Finish()
		{
			_stopStateBits |= StopStateBits.Stopped;

			_onFinished?.Invoke(_reference);
			_onFinished = null;

			_reference = null;
			_particleSystem = null;
			_particleSystems = null;
			_materialControllers = null;
		}
		
		public void SetMultiplyColor(Color color)
		{
			if (_materialControllers.IsNullOrEmpty())
				return;

			for (int i=0; i<_materialControllers.Length; i++)
				_materialControllers[i]?.SetMultiplyColor(color);
		}

		public enum StopStateBits : int
		{
			None = 0,
			Stopping = 1,
			Stopped = 2,
			Manual = 4,
		}
	}
}