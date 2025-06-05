using UnityEngine;

namespace Dpr.Contest
{
	public sealed class StageModelObject
	{
		public GameObject modelObj;
		private AudienceGenerator generator;
		private Transform modelTransform;
		
		public Vector3 Position { get => modelTransform.position; }
		
		public StageModelObject(GameObject modelObj)
		{
			this.modelObj = modelObj;

			modelTransform = modelObj.transform;
			generator = modelObj.GetComponent<AudienceGenerator>();
		}
		
		// TODO
		public void MovePosition(float moveX, Camera camera) { }
		
		// TODO
		public void SetAudienceUpdateFlag(bool flag) { }
		
		// TODO
		public void Dispose() { }
	}
}