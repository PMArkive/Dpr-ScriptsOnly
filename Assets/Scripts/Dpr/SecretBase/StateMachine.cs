using System.Collections.Generic;

namespace Dpr.SecretBase
{
	public class StateMachine<T, Owner>
	{
		private Dictionary<T, StateBase<T, Owner>> states = new Dictionary<T, StateBase<T, Owner>>();
		private StateBase<T, Owner> current;
		private StateBase<T, Owner> prev;
		private Owner owner;
		
		public StateMachine(Owner owner)
		{
			this.owner = owner;
			states = new Dictionary<T, StateBase<T, Owner>>();
		}
		
		// TODO
		public void AddState(StateBase<T, Owner> state) { }
		
		// TODO
		public void ChangeState(T type) { }
		
		// TODO
		public void OverlapState(T type) { }
		
		// TODO
		public void ChangePrevState() { }
		
		// TODO
		public void Update() { }
		
		// TODO
		public T GetCurrentType() { return default; }
	}
}