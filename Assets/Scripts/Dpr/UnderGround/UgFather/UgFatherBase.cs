using UnityEngine;

namespace Dpr.UnderGround.UgFather
{
	public class UgFatherBase : MonoBehaviour
	{
		public FieldCharacterEntity FieldCharacterEntity { get; set; }

        protected OnEventEnd onEventEndCallback;

        // TODO
        public void Initialize(FieldCharacterEntity entity, OnEventEnd eventEndCallback) { }
		
		// TODO
		public virtual void OnTalkEvent() { }
		
		// TODO
		public virtual void OnUpdate(float deltaTime) { }
		
		// TODO
		private void LookAtPlayer() { }

		public delegate void OnEventEnd();
	}
}