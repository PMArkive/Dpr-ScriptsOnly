namespace Dpr.SecretBase
{
	public class StateBase<T, Owner>
	{
		protected SecretBaseMasterDataManager masterData;
		
		// TODO
		public void Initialize(SecretBaseMasterDataManager masterData) { }
		
		public StateBase(T type)
		{
			Type = type;
		}
		
		public T Type { get; }
		
		// TODO
		public virtual void Enter(Owner owner) { }
		
		// TODO
		public virtual void Execute(Owner owner) { }
		
		// TODO
		public virtual void Exit(Owner owner) { }
	}
}