using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class ListView<T, Data> : MonoBehaviour
	{
		[SerializeField]
		protected RectTransform content;
		[SerializeField]
		protected T itemBase;
		protected List<T> itemList = new List<T>();
		
		// TODO
		private void Start() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		protected virtual void Init() { }
		
		// TODO
		public virtual int AddItem(Data data) { return default; }
		
		// TODO
		public virtual void ClearItem() { }
	}
}