using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public abstract class BattleObject : BtlvBehaviour, ITranslationObject
	{
		protected Vector3 m_translation = Vector3.zero;
		protected Vector3 m_translationOffset = Vector3.zero;
        protected Vector3 m_translationGOffset = Vector3.zero;
        protected Vector3 m_scale = Vector3.one;
        protected Vector3 m_scaleOffset = Vector3.one;
        protected Vector3 m_beforeTranslation = Vector3.zero;
        protected Vector3 m_nodeScaleTranslation = Vector3.zero;
        protected Vector3 m_nodeRotateTranslation = Vector3.zero;
        protected Vector3 m_rotVec = Vector3.zero;
        protected Vector3 m_rotVecOffset = Vector3.zero;
        protected bool m_isVisible;
		protected bool m_isSubVisible;
		protected bool m_suspendUpdate;
		protected bool m_autoRotate;
		protected bool m_isVisibleCameraHit;
		protected bool m_isSubVisibleCameraHit;
		protected float _animSpeed = 1.0f;

		public int Index { get; set; } = -1;
		public bool IsEnable { get; set; } = true;
		public int Priority { get; set; }
		public Vector3 NodeScaleTranslation { get; set; }
		public Vector3 NodeRotateTranslation { get; set; }
		
		// TODO
		protected void Awake() { }
		
		// TODO
		protected virtual void OnDestroy() { }
		
		// TODO
		protected void Initialize() { }
		
		// TODO
		protected virtual void InitializeMember() { }
		
		// TODO
		public void SetTranslationVec(Vector3 translation) { }
		
		// TODO
		public Vector3 GetTranslationVec() { return default; }
		
		// TODO
		public void SetTranslationOffset(Vector3 translation) { }
		
		// TODO
		public Vector3 GetTranslationOffset() { return default; }
		
		// TODO
		public void SetScaleVec(Vector3 scale) { }
		
		// TODO
		public Vector3 GetScaleVec() { return default; }
		
		// TODO
		public void SetScaleOffset(Vector3 scale) { }
		
		// TODO
		public Vector3 GetScaleOffset() { return default; }
		
		// TODO
		public void SetNodeScaleTranslation(Vector3 translation) { }
		
		// TODO
		public Vector3 GetNodeScaleTranslation() { return default; }
		
		// TODO
		public void SetNodeRotateTranslation(Vector3 translation) { }
		
		// TODO
		public Vector3 GetNodeRotateTranslation() { return default; }
		
		// TODO
		public void SetRotationVec(Vector3 rot) { }
		
		// TODO
		public Vector3 GetRotationVec() { return default; }
		
		// TODO
		public void SetRotationVecOffset(Vector3 rot) { }
		
		// TODO
		public Vector3 GetRotationVecOffset() { return default; }
		
		// TODO
		public bool IsActive() { return default; }
		
		// TODO
		public virtual void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public virtual void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		protected void UpdateSTR() { }
		
		// TODO
		public Vector3 GetCalcTranslation() { return default; }
		
		// TODO
		public Vector3 GetCalcScale() { return default; }
		
		// TODO
		public Vector3 GetCalcRot() { return default; }

		public enum ModelType : int
		{
			None = 0,
			Trainer = 1,
			Pokemon = 2,
		}
	}
}