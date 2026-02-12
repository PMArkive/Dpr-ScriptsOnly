using UnityEngine;

namespace Dpr.UnderGround.UgFather
{
	public class UgFatherBase : MonoBehaviour
	{
		public FieldCharacterEntity FieldCharacterEntity { get; private set; }

        protected OnEventEnd onEventEndCallback;

        public void Initialize(FieldCharacterEntity entity, OnEventEnd eventEndCallback)
        {
        	this.Length = entity;
        	this[0] = eventEndCallback;
        }
		
		// TODO
		public virtual void OnTalkEvent() { }
		
		// TODO
		public virtual void OnUpdate(float deltaTime) { }
		
		// TODO
		private void LookAtPlayer() { }

		public delegate void OnEventEnd();
	}
}