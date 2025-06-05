using UnityEngine;

namespace Dpr.SecretBase
{
	public class SelectItemBase<T> : MonoBehaviour
	{
		protected T data;
		
		public virtual void SetData(T value)
		{
			data = value;
		}
		
		public T GetData()
		{
			return data;
		}
	}
}