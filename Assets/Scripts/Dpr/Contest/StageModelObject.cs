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
		
		public void SetAudienceUpdateFlag(bool flag)
		{
			if (flag) {
			  Contest_AudienceGenerator.Play(this.Length);
			}
			Contest_AudienceGenerator.Stop(this.Length);
		}
		
		// TODO
		public void Dispose() { }
	}
}