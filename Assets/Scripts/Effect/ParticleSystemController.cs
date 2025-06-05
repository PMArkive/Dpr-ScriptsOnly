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
		
		// TODO
		public StopStateBits stopStateBits { get; }
		
		// TODO
		public void Setup(ParticleSystem particleSystem, UnityAction<object> onFinished, object reference) { }
		
		// TODO
		public void Stop(bool isForce) { }
		
		// TODO
		public void OnParticleSystemStopped() { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private void Finish() { }
		
		// TODO
		public void SetMultiplyColor(Color color) { }

		public enum StopStateBits : int
		{
			None = 0,
			Stopping = 1,
			Stopped = 2,
			Manual = 4,
		}
	}
}